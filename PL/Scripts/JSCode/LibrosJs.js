console.log("Macaco")

const API_URL = "https://localhost:44300/api/libro";

function buscarPorAutor() {
    let idAutor = document.getElementById("idAutor").value;

    fetch(`${API_URL}/autor/${idAutor}`)
        .then(res => res.json())
        .then(data => {
            let lista = document.getElementById("listaLibros");
            lista.innerHTML = "";

            data.forEach(libro => {
                let li = document.createElement("li");
                li.textContent = libro.Titulo;
                li.onclick = () => mostrarDetalle(libro);
                lista.appendChild(li);
            });
        });
}

    function mostrarDetalle(libro) {
        document.getElementById("detalleLibro").innerHTML = `
        <p><b>Título:</b> ${libro.Titulo}</p>
        <p><b>Autor:</b> ${libro.Autor.Nombre}</p>
        <p><b>Fecha:</b> ${libro.FechaPublicacion}</p>
        <p><b>Editorial:</b> ${libro.Editorial.Nombre}</p>
    `;
}

function buscarPorTitulo() {
    let titulo = document.getElementById("titulo").value;

    fetch(`${API_URL}/titulo/${titulo}`)
        .then(res => res.json())
        .then(data => {
            let libro = data[0]; 
            document.getElementById("resultadoTitulo").innerHTML = `
                <p><b>Título:</b> ${libro.Titulo}</p>
                <p><b>Autor:</b> ${libro.Autor.Nombre}</p>
            `;
        });
}
function agregarLibro() {

    var libro = {
        Titulo: $("#nuevoTitulo").val(),
        Autor: { IdAutor: $("#nuevoAutor").val() },
        Editorial: { IdEditorial: $("#nuevaEditorial").val() },
        FechaPublicacion: $("#nuevaFecha").val()
    };

    $.ajax({
        url: API_URL + "/add",
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

 


