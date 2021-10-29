function cargarDatos() {
    console.log('Cargando datos...');
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
          //  document.getElementById("texto1").innerHTML = this.responseText;
            document.getElementById("texto1").value = this.responseText;
        }
    };
    xhttp.open("GET", "data.txt", true);
    xhttp.send();
}

function cargarDatosManejador01(){
    console.log('Cargando datos desde manejador de servidor...');
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var t = document.createTextNode(this.responseText);
            var h = document.createElement("span");
            h.appendChild(t);
            var container = document.getElementById("container");
            container.innerHTML = null;
            container.appendChild(h);

        } else if (this.readyState == 4 && this.status == 400) {
            alert("error de carga");
            }
        };
        xhttp.open("POST", "Handler1.ashx", true);
        xhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        var dataToSend = "parametro1" + document.getElementById("").value +  "parametro2" + document.getElementById("");
        xhttp.send(dataToSend);
    }



function enviarFormulario() {
    var obj ={};
    obj.nombre = $("#nombre").val();
    obj.apellido = $("#apellidos").val();
    obj.edad = $("#edad").val();
    obj.dni = $("#dni").val();
    obj.email = $("#email").val();

    var jsonData= JSON.stringify(obj);



    $.ajax({
        url: 'Handler1.ashx',
        type: 'POST',
        data: { jsonData: jsonData },
        success: function (data) {
            var res = JSON.parse(data);
            if (res.estado == "Error") {
                // alert("Error el mail tiene que tenr formato valido")
                console.log("Error el mail tiene que tenr formato valido")
            } else {
                console.log("El dominio del email es: " + obj.email + " " + "El dni: " + obj.dni + "El nombre es: " + obj.nombre + "El apelldio es: " + obj.apellido + "La edad es: " + obj.edad)
                addNewItem(obj)
                 console.log(getAll());
               // var arrayMostarDiv = getAll();
               // document.getElementById("result").innertHTML = arrayMostarDiv;
            }
            console.log(data);
            addNewItem(data)
        },
        error: function (errorText) {
            alert("Wwoops something went wrong !");
        }
    });
}