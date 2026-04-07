document.addEventListener('DOMContentLoaded', () => {
    const boardContainer = document.getElementById('board');
    const addColumnBtn = document.getElementById('add-column-btn');
    const loginBtn = document.getElementById('login-btn');

    // Modals
    const modal = document.getElementById('modal');
    const modalTitle = document.getElementById('modal-title');
    const modalInput = document.getElementById('modal-input');
    const btnCancel = document.getElementById('modal-cancel');
    const btnSave = document.getElementById('modal-save');
    
    // Login Modals
    const loginModal = document.getElementById('login-modal');
    const loginCancel = document.getElementById('login-cancel');
    const loginSubmit = document.getElementById('login-submit');

    let currentAction = null; 
    let actionData = {};

    // Initial Data matching the image context
    const defaultData = [
        { id: 'col-1', title: 'In Progress', tasks: [{ id: 'task-1', content: 'Implement new fluid background' }], highlight: false },
        { id: 'col-2', title: 'Done', tasks: [], highlight: false },
        { id: 'col-3', title: 'Under review', tasks: [{id: 'task-2', content: 'Glassmorphism UI update'}], highlight: true },
        { id: 'col-4', title: 'Ready for review', tasks: [], highlight: false }
    ];

    let boardData = JSON.parse(localStorage.getItem('kanban_data_v2'));
    if (!boardData || boardData.length === 0) {
        boardData = defaultData;
    }

    function saveToLocaleStorage() {
        localStorage.setItem('kanban_data_v2', JSON.stringify(boardData));
    }

    // Modal logic
    function openModal(title, initialValue, action, data) {
        modalTitle.textContent = title;
        modalInput.value = initialValue;
        currentAction = action;
        actionData = data;
        modal.classList.remove('hidden');
        setTimeout(() => modalInput.focus(), 100);
    }
    function closeModal() {
        modal.classList.add('hidden');
        modalInput.value = '';
    }

    btnCancel.addEventListener('click', closeModal);
    btnSave.addEventListener('click', handleModalSave);
    modalInput.addEventListener('keydown', (e) => {
        if(e.key === 'Enter') handleModalSave();
        if(e.key === 'Escape') closeModal();
    });

    // Login logic
    loginBtn.addEventListener('click', () => {
        loginModal.classList.remove('hidden');
    });
    loginCancel.addEventListener('click', () => {
        loginModal.classList.add('hidden');
    });
    loginSubmit.addEventListener('click', () => {
        // Just mock login
        alert('Login successful!');
        loginModal.classList.add('hidden');
    });

    function handleModalSave() {
        const val = modalInput.value.trim();
        if (!val) return;

        if (currentAction === 'new_column') {
            const newCol = { id: 'col-' + Date.now(), title: val, tasks: [], highlight: false };
            boardData.push(newCol);
        } else if (currentAction === 'new_task') {
            const col = boardData.find(c => c.id === actionData.colId);
            if (col) {
                col.tasks.push({ id: 'task-' + Date.now(), content: val });
            }
        } else if (currentAction === 'edit_task') {
            for (const col of boardData) {
                const task = col.tasks.find(t => t.id === actionData.taskId);
                if (task) {
                    task.content = val;
                    break;
                }
            }
        } else if (currentAction === 'edit_col') {
             const col = boardData.find(c => c.id === actionData.colId);
             if (col) col.title = val;
        }

        saveToLocaleStorage();
        renderBoard();
        closeModal();
    }

    // Render logic
    function renderBoard() {
        boardContainer.innerHTML = '';

        boardData.forEach(colData => {
            const colEl = document.createElement('div');
            colEl.className = 'column';
            colEl.dataset.id = colData.id;
            colEl.dataset.highlight = colData.highlight || "false"; // Style from image 

            const headerEl = document.createElement('div');
            headerEl.className = 'column-header';
            
            const titleEl = document.createElement('h2');
            titleEl.className = 'column-title';
            titleEl.textContent = colData.title;

            const actionsElBtn = document.createElement('div');
            actionsElBtn.className = 'col-actions';
            
            const editColBtn = document.createElement('button');
            editColBtn.className = 'icon-btn';
            editColBtn.innerHTML = '<span class="material-symbols-outlined">edit</span>';
            editColBtn.addEventListener('click', () => {
                 openModal('Edit Column', colData.title, 'edit_col', {colId: colData.id});
            });

            const delColBtn = document.createElement('button');
            delColBtn.className = 'icon-btn';
            delColBtn.innerHTML = '<span class="material-symbols-outlined">delete</span>';
            delColBtn.addEventListener('click', () => {
                if(confirm('Delete column and all its tasks?')) {
                    boardData = boardData.filter(c => c.id !== colData.id);
                    saveToLocaleStorage();
                    renderBoard();
                }
            });

            // Toggle highlight visual style
            const toggleHighlightBtn = document.createElement('button');
            toggleHighlightBtn.className = 'icon-btn';
            toggleHighlightBtn.innerHTML = '<span class="material-symbols-outlined">star</span>';
            toggleHighlightBtn.addEventListener('click', () => {
                 colData.highlight = !colData.highlight;
                 saveToLocaleStorage();
                 renderBoard();
            });

            actionsElBtn.appendChild(toggleHighlightBtn);
            actionsElBtn.appendChild(editColBtn);
            actionsElBtn.appendChild(delColBtn);

            headerEl.appendChild(titleEl);
            headerEl.appendChild(actionsElBtn);

            const addBtn = document.createElement('button');
            addBtn.className = 'add-task-btn';
            addBtn.innerHTML = '<span class="material-symbols-outlined">add</span> Add a task';
            addBtn.addEventListener('click', () => {
                openModal('New Task', '', 'new_task', { colId: colData.id });
            });

            const listEl = document.createElement('div');
            listEl.className = 'task-list';
            listEl.dataset.id = colData.id;

            colData.tasks.forEach(task => {
                const taskEl = document.createElement('div');
                taskEl.className = 'task';
                taskEl.dataset.id = task.id;

                const contentEl = document.createElement('div');
                contentEl.className = 'task-content';
                contentEl.textContent = task.content;

                const tActionsEl = document.createElement('div');
                tActionsEl.className = 'task-actions';

                const editBtn = document.createElement('button');
                editBtn.className = 'icon-btn';
                editBtn.innerHTML = '<span class="material-symbols-outlined">edit</span>';
                editBtn.addEventListener('click', (e) => {
                    e.stopPropagation();
                    openModal('Edit Task', task.content, 'edit_task', {taskId: task.id});
                });

                const delBtn = document.createElement('button');
                delBtn.className = 'icon-btn';
                delBtn.innerHTML = '<span class="material-symbols-outlined">close</span>';
                delBtn.addEventListener('click', (e) => {
                    e.stopPropagation();
                    const col = boardData.find(c => c.id === colData.id);
                    if(col) {
                        col.tasks = col.tasks.filter(t => t.id !== task.id);
                        saveToLocaleStorage();
                        renderBoard();
                    }
                });

                tActionsEl.appendChild(editBtn);
                tActionsEl.appendChild(delBtn);

                taskEl.appendChild(contentEl);
                taskEl.appendChild(tActionsEl);
                listEl.appendChild(taskEl);
            });

            colEl.appendChild(headerEl);
            colEl.appendChild(addBtn); // Add task is under header in new design
            colEl.appendChild(listEl);
            boardContainer.appendChild(colEl);
        });

        initSortable();
    }

    function initSortable() {
        const lists = document.querySelectorAll('.task-list');
        lists.forEach(list => {
            new Sortable(list, {
                group: 'kanban',
                animation: 150,
                ghostClass: 'sortable-ghost',
                onEnd: function () {
                    rebuildStateFromDOM();
                }
            });
        });
        
        new Sortable(boardContainer, {
            animation: 150,
            ghostClass: 'sortable-ghost',
            onEnd: function() {
                 rebuildStateFromDOM();
            }
        });
    }

    function rebuildStateFromDOM() {
        const newBoardData = [];
        const cols = document.querySelectorAll('.column');
        
        cols.forEach(colEl => {
            const colId = colEl.dataset.id;
            const title = colEl.querySelector('.column-title').textContent;
            const highlight = colEl.dataset.highlight === 'true';
            
            const tasks = [];
            const taskEls = colEl.querySelectorAll('.task');
            
            taskEls.forEach(taskEl => {
                 const taskId = taskEl.dataset.id;
                 const content = taskEl.querySelector('.task-content').textContent;
                 tasks.push({id: taskId, content: content});
            });

            newBoardData.push({id: colId, title, tasks: tasks, highlight: highlight});
        });

        boardData = newBoardData;
        saveToLocaleStorage();
    }

    addColumnBtn.addEventListener('click', () => {
        openModal('New Column', '', 'new_column', {});
    });

    renderBoard();
});
