let ObjVenda = new Object();

ObjVenda.AddCarrinho = function (idProduto) {
    let nome = $("#nome_" + idProduto).val();
    let qtde = $("#qtde_" + idProduto).val();

    $.ajax({
        type: "POST",
        url: "/api/adicionarprodutocarrinho",
        dataType: "JSON",
        cache: false,
        async: true,
        data: { "id": idProduto, "nome": nome, "qtde": qtde },
        success: function (data) {
            if (data.sucesso) {
                ObjAlerta.AlertaTela(1, "Produto adicionado ao carrinho!")
            }
            else {
                ObjAlerta.AlertaTela(2, "Necessário estar logado")
            }
        }
    });
}

ObjVenda.CarregaProdutos = function () {
    $.ajax({
        type: "GET",
        url: "/api/listaprodutos",
        dataType: "JSON",
        cache: false,
        async: true,
        success: function (data) {
            let htmlConteudo = "";

            data.forEach(function (Entitie) {
                htmlConteudo += "<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4'>";

                let idNome = "nome_" + Entitie.id;
                let idQtde = "qtde_" + Entitie.id;

                htmlConteudo += "<label id='" + idNome + "' > Produto: " + Entitie.nome + "</label></br>";
                htmlConteudo += "<label> Valor: " + Entitie.valor + "</label></br>";
                htmlConteudo += "Quantidade : <input type='number' value='1' id='" + idQtde + "'>";

                htmlConteudo += "<input type='button' onclick='ObjVenda.AddCarrinho(" + Entitie.id + ")' value='Comprar'></br>";

                htmlConteudo += "</div>";
            });
            $("#divVenda").html(htmlConteudo);
        }
    });
}

ObjVenda.CarregaQtdeCar = function () {
    $("#qtdeCarrinho").text(" (0)");
    $.ajax({
        type: "GET",
        url: "/api/qtdeprodutoscar",
        dataType: "JSON",
        cache: false,
        async: true,
        success: function (data) {

            if (data.sucesso) {
                $("#qtdeCarrinho").text(" (" + data.qtde + ")");
            }
        }
    });
    setTimeout(ObjVenda.CarregaQtdeCar, 10000);
}

$(function () {
    ObjVenda.CarregaProdutos();
    ObjVenda.CarregaQtdeCar();
});