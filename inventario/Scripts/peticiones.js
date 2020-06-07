$("#IdPro").change(function () {
    $.ajax({
        url: "/inventario/Producto",
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        async: true,
        success: function (result) {
            console.log(result);
            console.log(result.length);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error al consultar datos del controlador");
        }
    });
});
$("#Total").prop('disabled', true);