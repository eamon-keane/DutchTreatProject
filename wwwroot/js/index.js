﻿
$(document).ready(function () {
    var x = 0;
    var s = "";


    console.log("Hello pluralsight");

    var theForm = $("#theForm");

    theForm.hide();

    var button = $("#buyButton");

    button.on("click", function () {
        console.log("Buying Item");
    });

    var productInfo = $(".product-props li");

    productInfo.on("click", function () {
        console.log("you clicked on" + $(this).text());
    });

    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".popup-form");

    $loginToggle.on("click", function () {
        $popupForm.toggle(1000);
    });



});