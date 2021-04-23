
document.getElementById("btnregistrar").disabled = true;

$(document).ready(function () {

	document.getElementById("rdsi").checked = true;
	$("#divvendeimpuestos").show();

})


/* VIZUALIZAR IMAGEN*/

$("#imagen").change(function () {

    let imagen = this.files[0];

    if (imagen["type"] != "image/jpeg" && imagen["type"] != "image/png") {
        $("#imagen").val("");
        $(".previsualizar").attr("src", "../Content/img/img_logo/TuLogo.png");
        alert("Debe subir una imagen en formato jpeg o png");
    } else if (imagen["size"] > 2000000) {
        $("#imagen").val("");
        $(".previsualizar").attr("src", "../Content/img/img_logo/TuLogo.png");
        alert("La imagen debe tener como maximo 2MB");
    } else {
        var datosImagen = new FileReader;
        datosImagen.readAsDataURL(imagen);

        $(datosImagen).on("load", function (event) {
            var rutaImagen = event.target.result;
            $(".previsualizar").attr("src", rutaImagen);
        })
    }

})

/***************************************************/

$("#rdsi").on("click", function () {
   
	document.getElementById("rdno").checked = false;
	document.getElementById("rdsi").checked = true;
	$("#divvendeimpuestos").show();
})

$("#rdno").on("click", function () {
   
	document.getElementById("rdno").checked = true;
	document.getElementById("rdsi").checked = false;
	$("#divvendeimpuestos").hide();
})


/*************************************/

$("#btnsiguiente").on("click", function () {

    let razonsocial = $("#txtrazonsocial").val();
    let ruc = $("#txtruc").val();
    let email = $("#txtemail").val();

    if (razonsocial == "") {
        $("#msjrazonsocial").html("El capo razon social no debe estar vaicio").css("color", "red");
        $("#txtrazonsocial").css("border-color", "red");
        $("#txtrazonsocial").focus();
    } else if (ruc == "") {
        $("#msjruc").html("El capo ruc no debe estar vaicio").css("color", "red");
        $("#txtjruc").css("border-color", "red");
        $("#txtjruc").focus();
    } else if (email == "") {
        $("#msjemail").html("El capo email no debe estar vaicio").css("color", "red");
        $("#txtemail").css("border-color", "red");
        $("#txtemail").focus();

    } else if (!validaEmail(email)) {
        $("#msjemail").html("Debe ingresar un email valido").css("color", "red");
        $("#txtemail").css("border-color", "red");

    } else {
        var paramss = new Object();
        paramss.razonsocial = razonsocial;
        paramss.ruc = ruc;
        paramss.email = email;

        Post("RegistroEmpresa/validarRegistro", paramss).done(function (datos) {
            if (datos.dt.response == "ok") {
                $(".divregistroempresa").hide();
                $(".divregistrousersuperadmin").show();



                document.getElementById("btnregistrar").disabled = true;

            } else {
                swal({
                    position: "top-end",
                    type: "error",
                    title: datos.dt.response,
                    text: 'Por favor valida el campo solicitado',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'


                })


            }


        })

    }
})




$("#txtrazonsocial").keyup(function () {
    let razonsocial = $("#txtrazonsocial").val();
    if (razonsocial == "") {
        $("#msjrazonsocial").html("El campo de razon social no debe estar vacio").css("color", "red");
        $("#txtrazonsocial").css("border-color", "red");

    } else {
        $("#msjrazonsocial").html("").css("color", "red");
        $("#txtrazonsocial").css("border-color", "");

    }

})


$("#txtruc").keyup(function () {
    let ruc = $("#txtruc").val();
    if (ruc == "") {
        $("#msjruc").html("El capo ruc no debe estar vaicio").css("color", "red");
        $("#txtruc").css("border-color", "red");

    } else {
        $("#msjruc").html("").css("color", "red");
        $("#txtruc").css("border-color", "");

    }

})


$("#txtemail").keyup(function () {
    let email = $("#txtemail").val();
    if (email == "") {
        $("#msjemail").html("El capo email no debe estar vaicio").css("color", "red");
        $("#txtemail").css("border-color", "red");

    } else {
        if (!validaEmail(email)) {
            $("#msjemail").html("Debe ingresar un email valido").css("color", "red");
            $("#txtemail").css("border-color", "red");


        } else {

            $("#msjemail").html("").css("color", "red");
            $("#txtemail").css("border-color", "");

        } 


    }

})

