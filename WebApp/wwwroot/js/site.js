// sanity check
console.log("Conectado.");

// Botones
var btnAgregarEvidencia = document.querySelector("#btnAgregarEvidencia");

var formularioEvidenciaNueva = document.querySelector("#formularioEvidenciaNueva");
var slcTipoEvidencia = document.querySelector("#slcTipoEvidencia");
var slcCriterioFiltrado = document.querySelector("#slcCriterioFiltrado");
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


// Eventos
    // de tipo click
if (btnAgregarEvidencia) {
    document.querySelector("#btnAgregarEvidencia").addEventListener("click", fMostrarFormulario);
}

if (btnCancelarAgregarEvidencia) {
    document.querySelector("#btnCancelarAgregarEvidencia").addEventListener("click", fCancelarAgregarEvidencia);
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

if (slcCriterioFiltrado) {
    document.querySelector("#slcCriterioFiltrado").addEventListener("change", fCambiarOpcionCriterio);
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
    fOcultarDatosEspecificosDeFiltrado();
}

function fCancelarAgregarEvidencia() {

    const contenedor = document.getElementById('formularioEvidenciaNueva');

    // inputs, selects y textareas dentro del div
        const campos = contenedor.querySelectorAll('input, select, textarea');

        campos.forEach(campo => {
            if (campo.type === 'checkbox' || campo.type === 'radio') {
                campo.checked = campo.defaultChecked;

            } else if (campo.tagName === 'SELECT') {
                // Para los select, busca cuál opción tenía el atributo 'selected'
                Array.from(campo.options).forEach(opcion => {
                    opcion.selected = opcion.defaultSelected;
                });
            } else {
                // para textos, números, fechas, textareas
                campo.value = campo.defaultValue;
            }
        });

    fContenedoresAMostrarPorDefecto();
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

function fOcultarDatosEspecificosDeFiltrado() {

    document.querySelector("#idABuscar").style.display = "none";
    document.querySelector("#txtNombre").style.display = "none";
    document.querySelector("#edadASuperar").style.display = "none";
}

function fMostrarFormulario() {
    console.log("fMostrarFormulario.");

    formularioEvidenciaNueva.style.display = "block";
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

function fCambiarOpcionCriterio() {
    fOcultarDatosEspecificosDeFiltrado();

    if (this.value == "x") {
    }

    if (this.value == "Nombre") {
        document.querySelector("#txtNombre").style.display = "block";
    }

    if (this.value == "Edad") {
        document.querySelector("#edadASuperar").style.display = "block";
    }

    if (this.value === "idABuscar") {
        document.querySelector("#idABuscars").style.display = "block";
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
