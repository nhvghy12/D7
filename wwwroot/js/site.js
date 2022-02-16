// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function PassRowIndexToModal(action, index) {
    // console.log(index);
    // var action = $('#exampleModal').find('form').attr('action');
    $('#exampleModal').find('form').attr('action', `${action}?index=${index}`);
    $('#exampleModal').modal('show');
}