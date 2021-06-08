const btnAddTask = document.querySelector(".menu-bar-home-page button");
const modalContainer = document.querySelector(".modal-container");
const allDeleteTaskImages = document.querySelectorAll(".delete-task-img");
const closeModalButton = document.querySelector(".close-modal");

const goCreateTaskPage = () => {
    window.location = "/tarefas/criar-tarefa"
}

const changePositionFooter = () => {
    let tasks = document.querySelectorAll(".task-wrapper");

    if (tasks.length <= 2 && screen.width < 1024) {
        document.querySelector(".footer").style.position = "fixed";
    }

    if (tasks.length < 3 && screen.width > 1024) {
        document.querySelector(".footer").style.position = "fixed";
    }
}

const showModal = () => {
    modalContainer
        .classList
        .add("show-modal");
}

const closeModal = () => {
    modalContainer
        .classList
        .remove("show-modal");
}

const addInputForDeleteTaskModal = ({ taskId, categoryId }) => {
    const form = document.querySelector("form[name='delete-task']");

    if (!form.innerHTML.includes('taskId' || 'categoryId')) {
        form.innerHTML = `<input type='hidden' name='taskId' value=${taskId} />
<input type='hidden' name='categoryId' value=${categoryId} />
${form.innerHTML}`;
    } else {
        form.querySelector("input[name='taskId']").value = taskId;
        form.querySelector("input[name='categoryId']").value = categoryId;
    }

}

btnAddTask.onclick = goCreateTaskPage;

changePositionFooter();

allDeleteTaskImages.forEach((element) => {
    element.addEventListener("click", (e) => {
        showModal();

        addInputForDeleteTaskModal(element.dataset);
    });
})

closeModalButton.onclick = closeModal;
