// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
console.log("Hello wai");
var button = document.getElementById("buy");
button.addEventListener("click", function () {
    console.log("You clicked" + $(this).text());
});

var info = $(".product-props li");
info.on("click", function () {
    console.log("You clicked" + $(this).text());
});

var loginToggle = $("#loginToggle");
var popupform = $(".popup-form");

loginToggle.on("click", function () {
    popupform.toggle(1000);
});