let selectContacto = document.getElementById("IdCon");
let txtDescripcion = document.getElementById("Descripcion");
let txtFecha = document.getElementById("Fecha");
var message,pattern;

function init() {
    message = "6 dígitos";
    pattern = /^[0-9]{6}$/;

    selectContacto.addEventListener("change", function () {
        console.log("Valor de Selector:" + selectContacto.value);
        var num = Number.parseInt(selectContacto.value);
        if (num === 0) {
            message = "6 dígitos";
            pattern = /^[0-9]{6}$/;
            console.log("Entra a:" + 0);
        } else if (num === 1) {
            message = "10 dígitos";
            pattern = /^[0-9]{10}$/;
            console.log("Entra a:" + 1);
        } else if (num === 2) {
            message = "formato12_@gmail.com[.mx]";
            pattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.([a-zA-Z]{2,4})+$/;
            console.log("Entra a:" + 2);
        } else if (num === 3) {
            message = "http[s]://www.formato123.com";
            pattern = /^(?:(?:https?|ftp):\/\/)(?:\S+(?::\S*)?@)?(?:(?!10(?:\.\d{1,3}){3})(?!127(?:\.\d{1,3}){3})(?!169\.254(?:\.\d{1,3}){2})(?!192\.168(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\u00a1-\uffff0-9]+-?)*[a-z\u00a1-\uffff0-9]+)(?:\.(?:[a-z\u00a1-\uffff0-9]+-?)*[a-z\u00a1-\uffff0-9]+)*(?:\.(?:[a-z\u00a1-\uffff]{2,})))(?::\d{2,5})?(?:\/[^\s]*)?$/;
            console.log("Entra a:" + 3);
        } else {
            message = "";
            pattern = /[A-Za-z]+/;
            console.log("Default");
        }
        document.getElementsByClassName("text-danger")[2].textContent = "Formato inválido: " + message;
    }, false);

    txtDescripcion.addEventListener("keyup", function () {
        if (pattern.test(txtDescripcion.value)) {
            document.getElementsByClassName("btn-default")[0].disabled = false;
            document.getElementsByClassName("text-danger")[2].textContent = "";
        } else {
            document.getElementsByClassName("btn-default")[0].disabled = true;
            document.getElementsByClassName("text-danger")[2].textContent = "Formato inválido: " + message;
        }
        /*console.log(txtDescripcion.value);
        if (txtDescripcion.value.match(pattern) != null ){
            document.getElementsByClassName("text-danger")[2].textContent = "";
        } else {
            document.getElementsByClassName("text-danger")[2].textContent = "Formato inválido: " + message;
        }*/
    }, false);
}

window.addEventListener("load", init, false);