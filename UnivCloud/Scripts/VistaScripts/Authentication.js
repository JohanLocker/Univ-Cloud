let forms = document.querySelector(".Form_Standard");
let form = document.querySelector(".Form");
let Another = document.querySelector(".Another");
let Button = document.getElementById("Login");
let Inputs_all = document.querySelectorAll("input");
let Validation_Alerts = document.querySelectorAll('.Alert-Des');

Inputs_all.forEach(element => { //Quita las alertas al darle focus a cualquier input.
    element.addEventListener('click', () => {
        Validation_Alerts.forEach(elemento => {
            elemento.classList.remove('Show');
        })
    })
})
 //VALIDA LOS ESTADOS PARA DAR COLOR A LAS ALERTAS
function ValidarEstados() {
    Validation_Alerts.forEach(x => {
        let Mensaje = x.innerText;
        let validar = Mensaje.includes("exito");
        if (validar) {
            x.classList.add("Exito");
            x.classList.remove("Error");
        }
        else {
            x.classList.remove("Exito");
            x.classList.add("Error")
        }
    })
}
ValidarEstados();
//Validar los inputs para desplegar una alerta personalizada en caso de que sea incorrecto
function ValidacionAlerta() {
    Validation_Alerts.forEach(x => {
        if (x.innerText == ""){
            x.classList.remove("Show");
        }
        else {
            x.classList.add("Show")
        }
    })
}
ValidacionAlerta();


function ChangeForm() { //Cambia el formulario de login a registro en una misma pagina
    if (forms.classList.contains("Hide")) {
        forms.classList.remove("Hide");
        form.style.height = "400px";
        Inputs_all.forEach(element => element.value = ""); //Limpia los inputs cuando cambia de formulario
    }
    else {
        Validation_Alerts.forEach(x => {
            x.innerHTML = ""
        })
        form.style.height = "470px";
        forms.classList.add("Hide");
    }
}

function ValidarLetras(event) {
    var key = event.keyCode;
    if (key >= 65) {
        return true;
    }
    return false;
}

function deshabilitaRetroceso() {
    window.location.hash = "Again-No-back-button" //chrome
    window.onhashchange = function () { window.location.hash = "no-back-button"; }
}
document.getElementsByTagName('body')[0].addEventListener('load', deshabilitaRetroceso);

/*Inputs_all.forEach((Element) => {
    Element.addEventListener('click', () => {
        if (Element.attributes.getNamedItem("type").value == "text") {
           Element.addEventListener('keypress', function () {
               return false;
           }, true)
        }
        else {
            alert('es numero');
        }
    })
}); *///Invalido


Another.addEventListener("click", ChangeForm);
Button.addEventListener("click", ChangeForm);