// sanity check
console.log("Conectado.");

// Botones
var btnAgregarEvidencia = document.querySelector("#btnAgregarEvidencia");

var formularioEvidenciaNueva = document.querySelector("#formularioEvidenciaNueva");
var slcTipoEvidencia = document.querySelector("#slcTipoEvidencia");
var btnCancelarAgregarEvidencia = document.querySelector("#btnCancelarAgregarEvidencia");
var btnDescartarRecomendacion = document.querySelector("#btnDescartarRecomendacion");
var pAvisoEvidenciaInvalida = document.querySelector("#pAvisoEvidenciaInvalida");
var divEvidenciaIngresada = document.querySelector("#divEvidenciaIngresada");

var divDatosBasicosEvidencias = document.querySelector("#divDatosBasicosEvidencias");
var divTipoEvidenciaFisica = document.querySelector("#divTipoEvidenciaFisica");
var divTipoEvidenciaGrabacion = document.querySelector("#divTipoEvidenciaGrabacion");
var divTipoEvidenciaTestimonio = document.querySelector("#divTipoEvidenciaTestimonio");

var btnRegistrarEvidencia = document.querySelector("#btnRegistrarEvidencia");

// Eventos
    // de tipo click
if (btnAgregarEvidencia) {
    document.querySelector("#btnAgregarEvidencia").addEventListener("click", fMostrarFormulario);
}

if (btnCancelarAgregarEvidencia) {
    document.querySelector("#btnCancelarAgregarEvidencia").addEventListener("click", fContenedoresAMostrarPorDefecto);
}

if (btnDescartarRecomendacion) {
    console.log("btnDescartarRecomendacion");
    document.querySelector("#btnDescartarRecomendacion").addEventListener("click", fDescartarRecomendacion);
}

if (btnRegistrarEvidencia) {
    document.querySelector("#btnRegistrarEvidencia").addEventListener("click", fRegistrarEvidencia);
}

    // de tipo change
if (slcTipoEvidencia) {
    document.querySelector("#slcTipoEvidencia").addEventListener("change", fCambiarOpcionEvidencia);
}

fContenedoresAMostrarPorDefecto();

// --- Funciones ---

function fContenedoresAMostrarPorDefecto() {
    console.log("fContenedoresAMostrarPorDefecto.");
    slcTipoEvidencia.value = "x";
    if (formularioEvidenciaNueva) {
        formularioEvidenciaNueva.style.display = "none";
    }

    if (pAvisoEvidenciaInvalida) {
        pAvisoEvidenciaInvalida.style.display = "none";
    }

    if (btnAgregarEvidencia) {
        btnAgregarEvidencia.style.display = "block";
    }

    fOcultarDatosEspecificosDeEvidencias();
}

function fOcultarDatosEspecificosDeEvidencias() {
    if (divTipoEvidenciaFisica) {
        divTipoEvidenciaFisica.style.display = "none";
    }

    if (divTipoEvidenciaGrabacion) {
        divTipoEvidenciaGrabacion.style.display = "none";
    }

    if (divTipoEvidenciaTestimonio) {
        divTipoEvidenciaTestimonio.style.display = "none";
    }
}

function fMostrarFormulario() {
    console.log("fMostrarFormulario.");

    formularioEvidenciaNueva.style.display = "block";
    btnAgregarEvidencia.style.display = "none";
}

function fCambiarOpcionEvidencia() {
    fOcultarDatosEspecificosDeEvidencias()

    if (this.value == "x") {
    }

    if (this.value == "Fisica") {
        divTipoEvidenciaFisica.style.display = "block";
    }

    if (this.value == "Grabacion") {
        divTipoEvidenciaGrabacion.style.display = "block";
    }

    if (this.value === "Testimonio") {
        divTipoEvidenciaTestimonio.style.display = "block";
    }
}

function fRegistrarEvidencia() {
    if (slcTipoEvidencia.value == "x") {
        console.log(" fCambiarOpcionEvidencia 15 11");
    } else {
        /*
        divEvidenciaIngresada.innerHTML =
        `<div class="alert alert-success d-flex align-items-center" role="alert">
            <svg class="bi flex-shrink-0 me-2" role="img" aria-label="Success:"><use xlink:href="#check-circle-fill" /></svg>
            <div>
                @TempData["EvidenciaIngresada"]
            </div>
        </div>`;
        */
    }
}

function fDescartarRecomendacion() {
    console.log("fDescartarRecomendacion");
    document.querySelector("#formCasoRecomendacion").remove();
}
