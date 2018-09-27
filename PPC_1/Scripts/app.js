function mostrarTabela() {
    $('#tabelaescondida').show();
    $('#tdCursos').hide();
    
};

function AdicionarReadonly() {
    $('input').add('readonly');
}

//function PreencherDadosCoordenador(CPF) {
//    $('#preencheauto').val(CPF);
//    //$('.preencheauto1').add('placeholder', MaiorTitulacao);
//}

//java script puro 
//function PreencherDadosCoordenador() {
//    var x = document.getElementById("selectCoordenador").value;
//    document.getElementById("preencheauto").value = x;

//}

//Sem mostrar a função no html
//var x = document.getElementById("selectCoordenador");
//x.onchange = function () {
//document.getElementById("preencheauto").value = x.value;
//}

//$("#selectCoordenador").change(function () {
//    $("#preencheauto").val($(this).val());
//})


$("#selectCoordenador").change(function () {
    var id = $(this).val();
    $.ajax({
        type: 'GET',
        url: 'BuscarCoordenador',
        dataType: 'json',
        data: { id: id },
        success: function (retorno) {
            $("#preencheauto").val(retorno.CPF);
            $("#preencheauto1").val(retorno.MaiorTitulacao);
            $("#preencheautoid").val(retorno.Id);
        },
        error: function (e) {
            console.log(e);
        }
    });
})

