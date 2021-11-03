let ObjAlerta = new Object();

ObjAlerta.AlertaTela = function (tipo, mensagem) {
    $("#AlertaJS").html("");

    let classeTipoAlerta = "";

    if (tipo == 1) {
        classeTipoAlerta = "alert alert-success";
    }
    if (tipo == 2) {
        classeTipoAlerta = "alert alert-warning";
    }
    if (tipo == 3) {
        classeTipoAlerta = "alert alert-danger";
    }

    let divAlert = $("<div>", { class: classeTipoAlerta });
    divAlert.append('<a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>');
    divAlert.append(`<strong>${mensagem}</strong>`);

    $("#AlertaJS").html(divAlert);

    window.setTimeout(function () {
        $(".alert").fadeOut(1500, 0).slideUp(500, function () {
            $(this).remove();
        });
    }, 5000);
}