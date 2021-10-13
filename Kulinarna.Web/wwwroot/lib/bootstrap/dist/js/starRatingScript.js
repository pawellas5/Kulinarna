'use strict'

let changeColor = function () {

    let star1 = document.getElementById("star1");
    let star2 = document.getElementById("star2");
    let star3 = document.getElementById("star3");
    let star4 = document.getElementById("star4");
    let star5 = document.getElementById("star5");

    //Rate 1
    star1.addEventListener("mouseover", function () {

        star1.style.color = "rgba(255,215,0)";

    });
    star1.addEventListener("mouseout", function () {
        star1.style.color = "rgba(255, 215, 0, 0.4)"
    });

    //Rate2
    star2.addEventListener("mouseover", function () {
        star1.style.color = "rgba(255,215,0)";
        star2.style.color = "rgba(255,215,0)";
    });
    star2.addEventListener("mouseout", function () {
        star1.style.color = "rgba(255, 215, 0, 0.4)"
        star2.style.color = "rgba(255, 215, 0, 0.4)"
    });

    //Rate3
    star3.addEventListener("mouseover", function () {
        star1.style.color = "rgba(255,215,0)";
        star2.style.color = "rgba(255,215,0)";
        star3.style.color = "rgba(255,215,0)";
    });
    star3.addEventListener("mouseout", function () {
        star1.style.color = "rgba(255, 215, 0, 0.4)"
        star2.style.color = "rgba(255, 215, 0, 0.4)"
        star3.style.color = "rgba(255, 215, 0, 0.4)"
    });

    //Rate4
    star4.addEventListener("mouseover", function () {
        star1.style.color = "rgba(255,215,0)";
        star2.style.color = "rgba(255,215,0)";
        star3.style.color = "rgba(255,215,0)";
        star4.style.color = "rgba(255,215,0)";
    });
    star4.addEventListener("mouseout", function () {
        star1.style.color = "rgba(255, 215, 0, 0.4)";
        star2.style.color = "rgba(255, 215, 0, 0.4)";
        star3.style.color = "rgba(255, 215, 0, 0.4)";
        star4.style.color = "rgba(255, 215, 0, 0.4)";
    });

    //Rate5
    star5.addEventListener("mouseover", function () {
        star1.style.color = "rgba(255,215,0)";
        star2.style.color = "rgba(255,215,0)";
        star3.style.color = "rgba(255,215,0)";
        star4.style.color = "rgba(255,215,0)";
        star5.style.color = "rgba(255,215,0)";
    });
    star5.addEventListener("mouseout", function () {
        star1.style.color = "rgba(255, 215, 0, 0.4)";
        star2.style.color = "rgba(255, 215, 0, 0.4)";
        star3.style.color = "rgba(255, 215, 0, 0.4)";
        star4.style.color = "rgba(255, 215, 0, 0.4)";
        star5.style.color = "rgba(255, 215, 0, 0.4)";
    })
}


//Div toggle that is based on user type
let switchDivs = function (div_id) {
    let divElem = document.getElementById(div_id);
    divElem.classList.contains("d-none") ? divElem.classList.remove("d-none") : divElem.classList.add("d-none");
}



changeColor();
switchDivs();



