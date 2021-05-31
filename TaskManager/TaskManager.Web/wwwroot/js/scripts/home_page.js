let btnAddTask = document.querySelector(".menu-bar-home-page button");

function goCreateTaskPage() {
    window.location = "/tarefas/criar-tarefa"
}

const changePositionFooter = () => {
    let tasks = document.querySelectorAll(".task-wrapper");

    if (tasks.length <= 1 && screen.width < 1024) {
        document.querySelector("footer").style.position = "fixed";
    }

    if (tasks.length > 3 && screen.width > 1024) {
        document.querySelector("footer").style.position = "fixed";
    }
}

btnAddTask.onclick = goCreateTaskPage;

changePositionFooter();