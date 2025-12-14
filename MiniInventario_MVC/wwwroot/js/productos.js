$(document).ready(function () {
   
    cargaReporte();
});

function cargaReporte() {
    debugger;
    $.get("/Productos/ObtenerReporte", function (data) {
        let html = "";

        data.forEach(p => {
            html += `
                <tr>
                    <td>${p.Nombre}</td>
                    <td>${p.Stock}</td>
                    <td>$${p.Precio}</td>
                    <td>$${p.ValorInventario}</td>
                </tr>
            `;
        });

        $("#tablaProductos").html(html);
    })
        .fail(err => console.error(err));
} 

function crearProducto(){
    debugger;
    const producto = {
        nombre: $("#nombre").val(),
        stock: parseInt($("#stock").val()),
        precio: parseInt($("#precio").val()),
    };

    $.ajax({
        url: "/Productos/CrearProducto",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(producto),
        success: function () {
            cargaReporte();
            limpiar();
        }
    });
}

function limpiar() {
    $("#nombre").val("");
    $("#stock").val("");
    $("#precio").val("");
}