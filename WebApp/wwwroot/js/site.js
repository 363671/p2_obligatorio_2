// sanity check
console.log("Conectado.");

// // // // // // // // // // // // // // // // // // // // // // //
// // // // // // // // // // QuerySelectors // // // // // // // //
// // // // // // // // // // // // // // // // // // // // // // //

// Botones
var btnRegistrarEvidencia = document.querySelector("#btnRegistrarEvidencia");
var btnAgregarEvidencia = document.querySelector("#btnAgregarEvidencia");
var btnDescartarRecomendacion = document.querySelector("#btnDescartarRecomendacion");
var btnOKAgregarEvidencia = document.querySelector("#btnOKAgregarEvidencia");
var btnCancelarAgregarEvidencia = document.querySelector("#btnCancelarAgregarEvidencia");

// Avisos
var pAvisoEvidenciaInvalida = document.querySelector("#pAvisoEvidenciaInvalida");

// formularios y selects
var formEvidenciaNueva = document.querySelector("#formEvidenciaNueva");
var formularioEvidenciaNueva = document.querySelector("#formularioEvidenciaNueva");
var slcTipoEvidencia = document.querySelector("#slcTipoEvidencia");
var slcCriterioFiltrado = document.querySelector("#slcCriterioFiltrado");

// contenedores
var divEvidenciaIngresada = document.querySelector("#divEvidenciaIngresada");
var divDatosBasicosEvidencias = document.querySelector("#divDatosBasicosEvidencias");
var divTipoEvidenciaFisica = document.querySelector("#divTipoEvidenciaFisica");
var divTipoEvidenciaGrabacion = document.querySelector("#divTipoEvidenciaGrabacion");
var divTipoEvidenciaTestimonio = document.querySelector("#divTipoEvidenciaTestimonio");

// // // // // // // // // // // // // // // // // // // // // // //
// // // // // // // // // // Eventos // // // // // // // // // //
// // // // // // // // // // // // // // // // // // // // // // //

// de tipo click
if (btnAgregarEvidencia) {
    document.querySelector("#btnAgregarEvidencia").addEventListener("click", fMostrarFormulario);
}

// if (btnOKAgregarEvidencia) {
//     document.querySelector("#btnOKAgregarEvidencia").addEventListener("click", fEstatizarEvidencia);
// }

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

// // // // // // // // // // // // // // // // // // // // // // //
// // // // // // // // // // FUNCIONES // // // // // // // // //
// // // // // // // // // // // // // // // // // // // // // // //

function fEstatizarEvidencia() {
   
}

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

function fOcultarDatosEspecificosDeFiltrado() {

    if(document.querySelector("#txtNombre")){
        document.querySelector("#txtNombre").style.display = "none";
    }

    if (document.querySelector("#edadASuperar")) {
        document.querySelector("#edadASuperar").style.display = "none";
    }

    if (document.querySelector("#antecedentes")) {
        document.querySelector("#antecedentes").style.display = "none";
    }
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

    if (this.value == "Antecedentes") {
        document.querySelector("#antecedentes").style.display = "block";
    }
}

function fRegistrarEvidencia() {
    if (slcTipoEvidencia.value == "") {
        console.log(" fCambiarOpcionEvidencia 15 11");
    }
}

function fDescartarRecomendacion() {
    console.log("fDescartarRecomendacion");
    if (document.querySelector("#formCasoRecomendacion")) {
        document.querySelector("#formCasoRecomendacion").remove();
    }
}