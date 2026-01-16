console.log("Macaco")


function buscarPorAutor() {
    let idAutor = $("#idAutor").val();

    $.ajax({
        url: "http://localhost:58677/api/libro/autor/" + idAutor,
        type: "GET",
        success: function (data) {
            let lista = $("#listaLibros");
            lista.empty();

            data.forEach(libro => {
                let li = $("<li>")
                    .addClass("list-group-item list-group-item-action")
                    .text(libro.Titulo)
                    .click(function () {
                        mostrarDetalle(libro);
                    });

                lista.append(li);
            });
        },
        error: function () {
            alert("Error al buscar libros por autor");
        }
    });
}

// Mostrar detalle
function mostrarDetalle(libro) {
    $("#detalleLibro").html(`
        <p><b>Título:</b> ${libro.Titulo}</p>
        <p><b>Autor:</b> ${libro.Autor.Nombre}</p>
        <p><b>Fecha:</b> ${libro.FechaPublicacion}</p>
        <p><b>Editorial:</b> ${libro.Editorial.Nombre}</p>
    `);
}

//  Buscar por título
function buscarPorTitulo() {
    let titulo = $("#titulo").val();

    $.ajax({
        url: "http://localhost:58677/api/libro/titulo/" + titulo,
        type: "GET",
        success: function (data) {
            if (data && data.length > 0) {
                let libro = data[0];

                // Convertir la fecha a formato legible
                let fechaPublicacion = new Date(libro.AñoPublicacion)
                    .toLocaleDateString("es-MX");

                $("#resultadoTitulo").html(`
                    <p><b>ID Libro:</b> ${libro.IdLibro}</p>
                    <p><b>Título:</b> ${libro.Titulo}</p>
                    <p><b>Año de Publicación:</b> ${fechaPublicacion}</p>
                    <p><b>ID Autor:</b> ${libro.IdAutor}</p>
                    <p><b>ID Editorial:</b> ${libro.IdEditorial}</p>
                `);
            } else {
                $("#resultadoTitulo").html(
                    "<p class='text-danger'>No se encontró el libro</p>"
                );
            }
        },
        error: function () {
            alert("Error al buscar por título");
        }
    });
}

//  Agregar libro
function agregarLibro() {
    let libro = {
        Titulo: $("#nuevoTitulo").val(),
        AñoPublicacion: $("#nuevaFecha").val(), 
        IdAutor: parseInt($("#nuevoAutor").val()),
        IdEditorial: parseInt($("#nuevaEditorial").val())
    };

    $.ajax({
        url: "http://localhost:58677/api/libro/add",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(libro),
        success: function (response) {
            alert(response);
        },
        error: function (xhr) {
            alert("Error al agregar el libro");
            console.error(xhr.responseText);
        }
    });
}
