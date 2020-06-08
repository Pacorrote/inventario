var precio;
var cantidad;


var buscarPrecio = function () {
    var id_pro = $("#IdPro").val();
    var txtCantidad = $("#Cantidad");
    var txtTotal = $("#Total");
    $.ajax({
        url: "/Detalles/Precio",
        data: { id: id_pro },
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        async: true,
        success: function (result) {
            precio = result.CostoUnitario;
            cantidad = result.Cantidad;
            console.log(txtCantidad.val() === "");
            if (txtCantidad.val() === "") {

                txtTotal.val(0);

            } else {
                var num = parseInt(txtCantidad.val());
                txtTotal.val(num * precio);
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error al consultar datos del controlador");
        }
    });
};

$("#IdPro").change(buscarPrecio);

$("#Cantidad").keyup(function () {
    var num = $("#Cantidad").val();
    var txtTotal = $("#Total");
   // $("#message-danger").css({ color: "red" });
    if (num > cantidad) {
        $("#message-danger").text("Valor supera la cantidad disponible: " + cantidad);
        txtTotal.val(0);
    } else if (num <= 0) {
        txtTotal.val(0);
        $("#message-danger").text("");

    } else {
        txtTotal.val(num * precio);
        $("#message-danger").text("");
    }

});


$("#Total").prop('disabled', true);
buscarPrecio();