// SOLO CODIGO DEL LAYOUT Y OTROS COMUNES

let button_Nav = document.getElementById('Menu');
let Side = document.getElementById('Side');
let Main = document.querySelector('.Main');


button_Nav.addEventListener('click', () => {
    if (Side.classList.contains('Side_Navbar')) {
        Side.classList.replace('Side_Navbar', 'Side_Navbar_Hide');
        Main.style.marginLeft = "0%";
    }
    else {
        Side.classList.replace('Side_Navbar_Hide', 'Side_Navbar');
        Main.style.marginLeft = "20%";
    }
})

let Boton_Collapse = document.getElementById("Boton-Collapse");
let Cuerpo_Collapse = document.getElementById("Cuerpo-Collapse");

function MostrarCollapse() {
    if (Cuerpo_Collapse != null) {
        if (Cuerpo_Collapse.classList.contains("Cuerpo-Collapse-Activo")) {
            Cuerpo_Collapse.classList.remove("Cuerpo-Collapse-Activo");
            Cuerpo_Collapse.classList.add("Cuerpo-Collapse-Inactivo");
        } else {
            Cuerpo_Collapse.classList.remove("Cuerpo-Collapse-Inactivo");
            Cuerpo_Collapse.classList.add("Cuerpo-Collapse-Activo");
        }
    }
}
if (Boton_Collapse != null) {
    Boton_Collapse.addEventListener('click', MostrarCollapse)
}