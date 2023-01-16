
// Write your JavaScript code.

function Validate() {
    var user = document.getElementById("inputEmail3").value;
    var pass = document.getElementById("inputPassword3").value;

    if (user != "" && pass != "") {
        document.getElementById("loginForm").submit();
    } else if (user != "" && pass == "") {
        alert("Por favor introduzca la contraseña");
    } else if (user == "" && pass != "") {
        alert("Por favor introduzca su correo electronico");
    } else {
        alert("Por favor introduzca su correo y contraseña para acceder");
    }
}


//To show and hide password in login

function ShowPass() {
    document.getElementById("inputPassword3").type = "text";
    document.getElementById("logIcon").innerHTML = '<span class="material-symbols-outlined"  onclick="HidePass()">visibility</span><small onclick="HidePass()">Ocultar contraseña</small >';
}

function HidePass() {
    document.getElementById("inputPassword3").type = "password";
    document.getElementById("logIcon").innerHTML = '<span class="material-symbols-outlined"  onclick="ShowPass()">visibility_off</span><small onclick="ShowPass()"> Ver contraseña</small>';
}
