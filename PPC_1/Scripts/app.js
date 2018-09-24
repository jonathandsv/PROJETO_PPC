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

$("#selectCoordenador").change(function () {
    var slt = "";
    $("option[value]").text(function () {
        slt = $(this).val();
    });
    $("#preencheauto").val(slt); 
})
    
