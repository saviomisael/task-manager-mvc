let btnAddTask = document.querySelector(".menu-bar-home-page button");

function goCreateTaskPage() {
    window.location = "/tarefas/criar-tarefa"
}

btnAddTask.onclick = goCreateTaskPage;