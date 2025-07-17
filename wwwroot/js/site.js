// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Remove add from somee hosting
document.addEventListener('DOMContentLoaded', () => {
    const adds = document.getElementsByTagName('center');
    adds[0].remove();
})