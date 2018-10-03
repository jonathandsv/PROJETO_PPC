//inicio da configuração da seção cursos
function mostrarTabela() {
    $('#tabelaescondida').show();
    $('#tdCursos').hide();
    
};

$(".CarregarCursos").click(function () {
    var id = $(this).attr('iddocurso');
    $.ajax({
        type: 'GET',
        url: 'BuscarCursos',
        dataType: 'json',
        data: { id: id },
        success: function (retorno) {
            $("#TipoDeCurso").val(retorno.TipoDeCurso);
            $("#TipoDeCurso").prop('readonly', 'readonly');
            $("#Modalidade").val(retorno.Modalidade);
            $("#Modalidade").prop('readonly', 'readonly');
            $("#Denominacao").val(retorno.DenominacaoCurso);
            $("#Denominacao").prop('readonly', 'readonly');
            $("#Habilitacao").val(retorno.Habilitacao);
            $("#Habilitacao").prop('readonly', 'readonly');
            $("#LocalOferta").val(retorno.LocalDeOferta);
            $("#LocalOferta").prop('readonly', 'readonly');
            $("#TurnosDeFuncionamento").val(retorno.TurnosDeFuncionamento);
            $("#TurnosDeFuncionamento").prop('readonly', 'readonly');
            $("#NumeroDeVagas").val(retorno.NumerosDeVagasCadaTurno);
            $("#NumeroDeVagas").prop('readonly', 'readonly');
            $("#CargaHorariaDoCurso").val(retorno.CargaHorariaDoCurso);
            $("#CargaHorariaDoCurso").prop('readonly', 'readonly');
            $("#RegimeLetivo").val(retorno.RegimeLetivo);
            $("#RegimeLetivo").prop('readonly', 'readonly');
            $("#Periodos").val(retorno.Periodos);
            $("#Periodos").prop('readonly', 'readonly');
            $("#Id_Curso").val(retorno.Id);

            $("#salvar").prop('disabled', 'disabled');
            $("#selecaoDeCoordenador").prop('disabled', 'disabled');

            var id = retorno.CoordenadorCurso;
            buscarCoordenadorIni(id);

            mostrarTabela();
        },
        erro: function (e) {
            console.log(e);
        }

        
    });
})



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


$(".selectCoordenador").change(function () {
    var id = $(this).val();
    buscarCoordenador(id)   
})

function buscarCoordenador(id) {
    var NomeCoordenador = "";
    var IdCoordenador = 5;
    $.ajax({
        type: 'GET',
        url: 'BuscarCoordenador',
        dataType: 'json',
        data: { id: id },
        success: function (retorno) {
            $("#preencheautoCpf").val(retorno.CPF);
            $("#preencheautoMTitulacao").val(retorno.MaiorTitulacao);
            $("#preencheautoid").val(retorno.Id);
        },
        error: function (e) {
            console.log(e);
        },
    });
}

function buscarCoordenadorIni(id) {
    $.ajax({
        type: 'GET',
        url: 'BuscarCoordenador',
        dataType: 'json',
        data: { id: id },
        success: function (retorno) {
            $("#preencheautoCpf").val(retorno.CPF);
            $("#preencheautoMTitulacao").val(retorno.MaiorTitulacao);
            $("#preencheautoid").val(retorno.Id);
            preencheNomeCoordenador(retorno.Nome, retorno.Id);
        },
        error: function (e) {
            console.log(e);
        },
    });
}

function preencheNomeCoordenador(Nome, Id) {
    $("#selecaoDeCoordenador").append("<option value=" + (Id) + " >" + (Nome) + "</option>");
}

$("#alterarCadastro").click(function () {
    $("#TipoDeCurso").removeAttr('readonly');
    $("#Modalidade").removeAttr('readonly');
    $("#Denominacao").removeAttr('readonly');
    $("#Habilitacao").removeAttr('readonly');
    $("#LocalOferta").removeAttr('readonly');
    $("#TurnosDeFuncionamento").removeAttr('readonly');
    $("#NumeroDeVagas").removeAttr('readonly');
    $("#CargaHorariaDoCurso").removeAttr('readonly');
    $("#RegimeLetivo").removeAttr('readonly');
    $("#Periodos").removeAttr('readonly');
    $("#selecaoDeCoordenador").removeAttr('disabled');
    $("#salvar").removeAttr('disabled');
   
    carregarSelecaoDeCoordenador();
});

function carregarSelecaoDeCoordenador() {
    $.ajax({
        type: 'GET',
        url: 'BuscarCoordenadores',
        dataType: 'json',
        success: function (retorno) {
            for (var i = 0; i < retorno.length; i++) {
                $("#selecaoDeCoordenador").append("<option value=" + (retorno[i].Id) + " > " + (retorno[i].Nome) + " </option > ");
            }

        },
        error: function (e) {
            console.log(e);
        }

    });
}


//function retirarReadonly() {
//    document.getElementById("TipoDeCurso").removeAttribute("readonly");
//}

//Fim da seção de cursos