let BodyData = document.getElementById('BodyData');
let StudentData = document.getElementsByTagName('input');
let AllReg = document.getElementsByTagName('th');
let Accept = document.getElementById('Accept');
let Know = document.getElementById('Know');
let Inputs = document.querySelectorAll('.Grupo input');
let labels = document.querySelectorAll('.Grupo Label');
let [Registration, Name, LastName, Age] = StudentData;
let inputs = Array.from(Inputs);
let [Cedula, Nombre, Apellido, Telefono] = inputs;

inputs.forEach((input) => {
    input.addEventListener('focus', () => {
        input.className = "Input-Rect-Focus";
    })
    input.addEventListener('blur', () => {
        if (input.value === "") {
            input.nextElementSibling.classList.add('label-Rect-Error');
            input.className = "Input-Rect Input-Rect-Error";
        }
        else {
            input.className = "Input-Rect-Validated";
            input.nextElementSibling.classList.remove('label-Rect-Error');
            input.nextElementSibling.classList.add('label-Rect-Focus');
        }
    })
})

function Inserted() {
    InsertStudent(Registration, Name, LastName, Age);
}
for (i = 0; i < AllReg.length; i++) {
    console.log(AllReg[i].innerText);
}
function InsertStudent(Reg, Nam, Las, Ag) {
    for (i = 0; i < AllReg.length; i++) {
        if (Reg.value == AllReg[i].innerText) {
            return alert('La matricula ya esta registrada.');
        }
    }
    return BodyData.innerHTML += `<tr>
        <th>${Reg.value}</th>
        <td>${Nam.value}</td>
        <td>${Las.value}</td>
        <td>${Ag.value}</td>
        </tr>`;
}


/*class Usuario{
    name;
    lastname;
    age;
    prof;
    Usuario(Name, LastName, Age, Prof){
        let name = Name;
        let lastname =  LastName;
        let age =  Age;
        let prof =  Prof;
    }
    SaberEmpleo(){
        console.log(`Mi Empleo es: ${prof}`);
    }
}

let Usuario1 = new Usuario('Johan');


Know.addEventListener('click', )*/
Accept.addEventListener('click', Inserted);