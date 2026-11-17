// sanity check
console.log("Conectado.");

// Botones
var btnAgregarEvidencia = document.querySelector("#btnAgregarEvidencia");

var formularioEvidenciaNueva = document.querySelector("#formularioEvidenciaNueva");
var slcTipoEvidencia = document.querySelector('[id*="slcTipoEvidencia"]');

var btnCancelarAgregarEvidencia = document.querySelector("#btnCancelarAgregarEvidencia");
var btnDescartarRecomendacion = document.querySelector("#btnDescartarRecomendacion");
var pAvisoEvidenciaInvalida = document.querySelector("#pAvisoEvidenciaInvalida");
var divEvidenciaIngresada = document.querySelector("#divEvidenciaIngresada");

var divDatosBasicosEvidencias = document.querySelector("#divDatosBasicosEvidencias");
var divTipoEvidenciaFisica = document.querySelector("#divTipoEvidenciaFisica");
var divTipoEvidenciaGrabacion = document.querySelector("#divTipoEvidenciaGrabacion");
var divTipoEvidenciaTestimonio = document.querySelector("#divTipoEvidenciaTestimonio");

var btnRegistrarEvidencia = document.querySelector("#btnRegistrarEvidencia");

var formEvidenciaNueva = document.querySelector("#formEvidenciaNueva");

// --------------------- //

let evidenciaIndex = 0;

document.getElementById('btnAgregarEvidenciaNueva').addEventListener("click", fCargaDeEvidenciasEnCasoNuevo)

function fCargaDeEvidenciasEnCasoNuevo() {

    const template = document.getElementById('formularioEvidenciaNueva').innerHTML;

    const evidenciaNumerada = template.replaceAll('{INDEX}', evidenciaIndex);

    document.getElementById('contenedor-evidencias').insertAdjacentHTML('beforeend', evidenciaNumerada);

    evidenciaIndex++;

    fLlamarListeners();
}

// --------------------- //

// Eventos
    // de tipo click
// if (btnAgregarEvidencia) {
//     document.querySelector("#btnAgregarEvidencia").addEventListener("click", fMostrarFormulario);
// }

fLlamarListeners();
function fLlamarListeners() {

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
            slcTipoEvidencia.addEventListener("change", fCambiarOpcionEvidencia);
    }
}

fContenedoresAMostrarPorDefecto();

// --- Funciones ---

function fContenedoresAMostrarPorDefecto() {
    console.log("fContenedoresAMostrarPorDefecto.");

    if (formularioEvidenciaNueva) {
        formularioEvidenciaNueva.style.display = "none";
    }

    if (pAvisoEvidenciaInvalida) {
        pAvisoEvidenciaInvalida.style.display = "none";
    }

    if (btnAgregarEvidencia) {
        btnAgregarEvidencia.style.display = "block";
    }

    if (formEvidenciaNueva) {
        formEvidenciaNueva.reset();
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

    // formularioEvidenciaNueva.style.display = "block";
    btnAgregarEvidencia.style.display = "none";
}

function fCambiarOpcionEvidencia() {
    fOcultarDatosEspecificosDeEvidencias();

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
    if (slcTipoEvidencia.value == "") {
        console.log(" fCambiarOpcionEvidencia 15 11");
    }
}

function fDescartarRecomendacion() {
    console.log("fDescartarRecomendacion");
    document.querySelector("#formCasoRecomendacion").remove();
}
