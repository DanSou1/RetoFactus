let loadingModal;

document.addEventListener("DOMContentLoaded", function () {
    const modalElement = document.getElementById('loadingModal');
    loadingModal = new bootstrap.Modal(modalElement, {
        backdrop: 'static',
        keyboard: false
    });
});

function mostrarCargando() {
    loadingModal.show();
}

function ocultarCargando() {
    loadingModal.hide();
}
