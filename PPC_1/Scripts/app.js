﻿//inicio da configuração da seção cursos
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

$("#alterarCadastroCurso").click(function () {
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

//Pagina de PPCs

$(".selectCurso").change(function () {
    var id = $(this).val();
    $("#preencheautoidcurso").val(id);

    $.ajax({
        type: 'GET',
        url: 'BuscarPpc',
        dataType: 'json',
        data: { id: id },
        success: function (retorno) {
            if (retorno.Id == 1) {
                $("#PerfilDoCurso").attr('readonly', 'readonly');
                $("#PerfilDoEgresso").attr('readonly', 'readonly');
                $("#FormaDeAcesso").attr('readonly', 'readonly');
                $("#RepresetacaoGrafica").attr('readonly', 'readonly');
                $("#SistemaAvaliacaoEnsinoAprendizagem").attr('readonly', 'readonly');
                $("#SistemaAvaliacaoCurso").attr('readonly', 'readonly');
                $("#TCC").attr('readonly', 'readonly');
                $("#EstagioCurricular").attr('readonly', 'readonly');
                $("#PraticaAtenPCD").attr('readonly', 'readonly');
                $(".salvarppc").prop('disabled', 'disabled');
                alert("Curso já escolhido para um PPC anterior! Escolha outro Curso.");
            }
            else {
                $("#PerfilDoCurso").removeAttr('readonly', 'readonly');
                $("#PerfilDoEgresso").removeAttr('readonly', 'readonly');
                $("#FormaDeAcesso").removeAttr('readonly', 'readonly');
                $("#RepresetacaoGrafica").removeAttr('readonly', 'readonly');
                $("#SistemaAvaliacaoEnsinoAprendizagem").removeAttr('readonly', 'readonly');
                $("#SistemaAvaliacaoCurso").removeAttr('readonly', 'readonly');
                $("#TCC").removeAttr('readonly', 'readonly');
                $("#EstagioCurricular").removeAttr('readonly', 'readonly');
                $("#PraticaAtenPCD").removeAttr('readonly', 'readonly');
                $(".salvarppc").removeAttr('disabled');
            }
        },
        error: function (e) {
            console.log(e);
        },
    });
})

//$("#salvarppc").click(function () {
//    $("#modal-info").modal();
//})
//$("#modal").click(function () {
//    $("#modal-info").css("display", "block");
//})

$(".CarregarPPCs").click(function () {
    var id = $(this).attr('iddoppc');
    $.ajax({
        type: 'GET',
        url: 'BuscarPpcT',
        dataType: 'json',
        data: { id: id },
        success: function (retorno) {
            $("#PerfilDoCurso").val(retorno.PerfilDoCurso);
            $("#PerfilDoCurso").attr('readonly', 'readonly');
            $("#PerfilDoEgresso").val(retorno.PerfilDoEgresso);
            $("#PerfilDoEgresso").attr('readonly', 'readonly');
            $("#FormaDeAcesso").val(retorno.FormaDeAcesso);
            $("#FormaDeAcesso").attr('readonly', 'readonly');
            $("#RepresetacaoGrafica").val(retorno.RepresentacaoGrafica);
            $("#RepresetacaoGrafica").attr('readonly', 'readonly');
            $("#SistemaAvaliacaoEnsinoAprendizagem").val(retorno.SistemaAvaliacaoEnsinoAprendizagem);
            $("#SistemaAvaliacaoEnsinoAprendizagem").attr('readonly', 'readonly');
            $("#SistemaAvaliacaoCurso").val(retorno.SistemaAvaliacaoCurso);
            $("#SistemaAvaliacaoCurso").attr('readonly', 'readonly');
            $("#TCC").val(retorno.TCC);
            $("#TCC").attr('readonly', 'readonly');
            $("#EstagioCurricular").val(retorno.EstagioCurricular);
            $("#EstagioCurricular").attr('readonly', 'readonly');
            $("#PraticaAtenPCD").val(retorno.PraticaAtenPCD);
            $("#PraticaAtenPCD").attr('readonly', 'readonly');
            $("#IdPPC").val(retorno.Id);
            $("#IdCurso").val(retorno.IdCurso);

            $("#salvar").prop('disabled', 'disabled');
            $("#selecaoDeCurso").prop('disabled', 'disabled');
            

            var id = retorno.IdCurso;
            buscarCursoIni(id);

            mostrarTabela();
        },
        erro: function (e) {
            console.log(e);
        }


    });
})

function buscarCursoIni(id) {
    $.ajax({
        type: 'GET',
        url: 'BuscarCursos',
        dataType: 'json',
        data: { id: id },
        success: function (retorno) {
            $("#selecaoDeCurso").append("<option value=" + (retorno.Id) + " >" + (retorno.DenominacaoCurso) + "</option>");
        },
        error: function (e) {
            console.log(e);
        },
    });
}

$("#alterarCadastroPpc").click(function () {
    $("#PerfilDoCurso").removeAttr('readonly');
    $("#PerfilDoEgresso").removeAttr('readonly');
    $("#FormaDeAcesso").removeAttr('readonly');
    $("#RepresetacaoGrafica").removeAttr('readonly');
    $("#SistemaAvaliacaoEnsinoAprendizagem").removeAttr('readonly');
    $("#SistemaAvaliacaoCurso").removeAttr('readonly');
    $("#TCC").removeAttr('readonly');
    $("#EstagioCurricular").removeAttr('readonly');
    $("#PraticaAtenPCD").removeAttr('readonly');
    $("#PraticaAtenPCD").removeAttr('readonly');
    $("#selecaoDeCurso").removeAttr('disabled');
    $("#salvar").removeAttr('disabled');

    carregarSelecaoDeCurso();
});

function carregarSelecaoDeCurso() {
    $.ajax({
        type: 'GET',
        url: 'BuscarCursosT',
        dataType: 'json',
        success: function (retorno) {
            for (var i = 0; i < retorno.length; i++) {
                $("#selecaoDeCurso").append("<option value=" + (retorno[i].Id) + " > " + (retorno[i].DenominacaoCurso) + " </option > ");
            }

        },
        error: function (e) {
            console.log(e);
        }

    });
}

// Fim seção PPC

//Pagina de Disciplinas

$(".CarregarDisciplinas").click(function () {
    var id = $(this).attr('iddadisciplina');
    $.ajax({
        type: 'GET',
        url: 'BuscarDisciplinas',
        dataType: 'json',
        data: { id: id },
        success: function (retorno) {
            $("#Nome").val(retorno.Nome);
            $("#Nome").attr('readonly', 'readonly');
            $("#Semestre").val(retorno.Semestre);
            $("#Semestre").attr('readonly', 'readonly');
            $("#CargaHoraria").val(retorno.CargaHoraria);
            $("#CargaHoraria").attr('readonly', 'readonly');

            $("#salvar").prop('disabled', 'disabled');
            $("#selecaoDeCurso").prop('disabled', 'disabled');


            var id = retorno.IdCurso;
            buscarCursoIni(id);

            mostrarTabela();
        },
        erro: function (e) {
            console.log(e);
        }


    });
})

$("#alterarCadastroDisciplina").click(function () {
    $("#Nome").removeAttr('readonly');
    $("#Semestre").removeAttr('readonly');
    $("#CargaHoraria").removeAttr('readonly');
    $("#selecaoDeCurso").removeAttr('disabled');
    $("#salvar").removeAttr('disabled');

    carregarSelecaoDeCurso();
});


// Fim da Página de Disciplinas

// Página de Matriz Curricular

$(".BuscarDiscVinculadas").change(function () {
    var id = $(this).val();
    var idD = 0
    $("#preechedados").val(id);
    //var qlimpar = $("#tabelaDeDisciplinas").find("tbody").find("tr").length;
    $("#tabelaDeDisciplinas").find("tbody").find("tr").remove(".disciplinaCarregada");
    BuscarVinculoDisciplinaCurso(id, idD);
})

function BuscarVinculoDisciplinaCurso(idC, idD) {
    $.ajax({
        type: 'POST',
        url: 'BuscarDisciplinaVinculadaCurso',
        dataType: 'json',
        data: {
            idC: idC,
            idD: idD
        },
        success: function (retorno) {
            var comparacao = retorno.length;
            if (comparacao > 0) {
                for (var i = 0; i < retorno.length; i++) {
                    $("#tabelaDeDisciplinas").find("tbody").append("<tr class = " + "disciplinaCarregada" + " ><th>" + (retorno[i].Nome) + "</tr></th>");
                }
            }
            else {
                alert("Curso ainda não possui disciplinas vinculadas!");
            }
        },
        error: function (e) {
            console.log(e);
        },
    });
}
var iddadisciplina = 0;
var iddocurso = 0;

$(".selecaoDisciplina").change(function () {
    iddadisciplina = $(this).val();
    iddocurso = $("#preechedados").val();
});

$("#adicionarDisciplina").click(function () {
    $.ajax({
        type: 'POST',
        url: 'NovaDisciplinaMatriz',
        dataType: 'json',
        data: {
            idDisciplina: iddadisciplina,
            idCurso: iddocurso
        },
        success: function (retorno) {
            if (retorno == true) {
                $("#tabelaDeDisciplinas").find("tbody").find("tr").remove(".disciplinaCarregada");
                var idD = 0
                BuscarVinculoDisciplinaCurso(iddocurso, idD);
            }
            else {
                alert("Disciplina já vinculada ao curso selecionado!");
            }
            
        },
        error: function (e) {
            console.log(e);
        },
    });
});

//Fim das páginas de matriz curricular 

//Página de Cronogramas de atividades 


$(".CarregarCronograma").click(function () {
    var id = $(this).attr('iddocronograma');
    $.ajax({
        type: 'GET',
        url: 'BuscarCronograma',
        dataType: 'json',
        data: { id: id },
        success: function (retorno) {
            $("#IdCronograma").val(retorno.Id);
            $("#NAula").val(retorno.NAula);
            $("#NAula").attr('readonly', 'readonly');
            $("#Descricao").val(retorno.Descricao);
            $("#Descricao").attr('readonly', 'readonly');

            $("#salvar").prop('disabled', 'disabled');

            mostrarTabela();
        },
        erro: function (e) {
            console.log(e);
        }
    });
})

$("#alterarCadastroCronograma").click(function () {
    $("#NAula").removeAttr('readonly');
    $("#Descricao").removeAttr('readonly');
    $("#salvar").removeAttr('disabled');

});

// Fim do Cronograma de Atividades 


// Página de professores 

$(".salvarProf").click(function () {
    var comando = $(this).attr('idcomando');
    if (comando == 1) {
        CadastrarProfessorAtuacaoIesDadosPessoais();
    }
    if (comando == 2) {
        CadastrarProfessorAtuacaoIesGeral();
    }
    if (comando == 3) {
        CadastrarProfessorAtuacaoIesAtuacaoProfissional();
    }
    if (comando == 4) {
        CadastrarProfessorAtuacaoIesPublicacoes();
    }
});

function CadastrarProfessorAtuacaoIesDadosPessoais() {
    var professor = {};
    professor.Nome = $("#Nome").val();
    professor.CPF = $("#CPF").val();
    professor.MaiorTitulacao = $("#MaiorTitulacao").val();
    professor.AreaFormacao = $("#AreaFormacao").val();
    professor.CurriculoLattos = $("#CurriculoLattos").val();
    professor.DataAtualizacao = $("#DataAtualizacao").val();

    $.ajax({
        type: 'POST',
        url: 'CadastrarProfessorAtuacaoIesDadosPessoais',
        dataType: 'json',
        data: { professor: JSON.stringify(professor) },
        success: function (retorno) {
                $("#idProf").val(retorno.Id);
                alert("Cadastro inicial concluido com sucesso! Acesse a aba de Atuação na IES e complete o cadastro do professor," +
                    "caso saia dessa página agora terá que acessar: Professor-Todos os professores-Editar, para continuar com o cadastro do professor");
        }, 
        erro: function (e) {
            console.log(e);
        }
    });
};

function CadastrarProfessorAtuacaoIesGeral() {
    var professor = {};
    professor.Id = $("#idProf").val();
    professor.Matricula = $("#Matricula").val();
    professor.DataAdmissao = $("#DataAdmissao").val();
    professor.HorasNde = $("#HorasNde").val();
    professor.OrientacaoTcc = $("#OrientacaoTcc").val();
    professor.AtividadesExtraClasseNoCurso = $("#AtividadesExtraClasseNoCurso").val();
    professor.AtividadesExtraClasseOutrosCursos = $("#AtividadesExtraClasseOutrosCursos").val();
    professor.CoordenacaoCurso = $("#CoordenacaoCurso").val();
    professor.CoordenacaoOutrosCursos = $("#CoordenacaoOutrosCursos").val();
    professor.QtdeHorasCurso = $("#QtdeHorasCurso").val();
    professor.QtdeHorasOutrosCusos = $("#QtdeHorasOutrosCursos").val();
    professor.Pesquisa = $("#Pesquisa").val();
    professor.IdDisciplina = $("#IdDisciplina").val();
    professor.IdDisciplinaOutrosCursos = $("#IdDisciplinaOutrosCursos").val();

    $.ajax({
        type: 'POST',
        url: 'CadastrarProfessorAtuacaoIesGeral',
        dataType: 'json',
        data: { professor: JSON.stringify(professor) },
        success: function () {
            alert("Salvo! Passe para a aba de Atuação Profissional");
        },
        erro: function (e) {
            console.log(e);
        }
    });

}

function CadastrarProfessorAtuacaoIesAtuacaoProfissional() {

    //var TempoDeVinculoIniterrupto = $("#TempoDeVinculoIniterrupto").val();
    //TempoDeVinculoIniterrupto = formatardata(TempoDeVinculoIniterrupto);
    //var TempoMagisterioSuperior = $("#TempoMagisterioSuperior").val();
    //TempoMagisterioSuperior = formatardata(TempoMagisterioSuperior);
    //var ExperienciaEmCursoADistacia = $("#ExperienciaEmCursoADistacia").val();
    //ExperienciaEmCursoADistacia = formatardata(ExperienciaEmCursoADistacia);
    //var TempoExperienciaProfissional = $("#TempoExperienciaProfissional").val();
    //TempoExperienciaProfissional = formatardata(TempoExperienciaProfissional);

    var professor = {};
    professor.Id = $("#idProf").val();
    professor.MembroNde = $("#MembroNde").prop('checked');
    professor.MembroColegiado = $("#MembroColegiado").prop('checked');
    professor.DocenteFormacao = $("#DocenteFormacao").prop('checked');
    professor.TempoDeVinculoIniterrupto = $("#TempoDeVinculoIniterrupto").val();
    professor.TempoMagisterioSuperior = $("#TempoExperienciaMagisterioSuperior").val();
    professor.ExperienciaEmCursoADistacia = $("#ExperienciaEmCursoADistacia").val();
    professor.TempoExperienciaProfissional = $("#TempoExperienciaProfissional").val();
    professor.QtdeParticipacoesEventos = $("#QtdeParticipacoesEventos").val();

    $.ajax({
        type: 'POST',
        url: 'CadastrarProfessorAtuacaoIesAtuacaoProfissional',
        dataType: 'json',
        data: { professor: JSON.stringify(professor) },
        success: function () {
            alert("Salvo com sucesso! passe para a aba de Publicações");
        },
        erro: function (e) {
            console.log(e);
        }
    });
}

$(".calculardiferenca").change(function () {
    var data1 = $(this).val();
    var arrdata1 = data1.split("/");
    data1formatada = arrdata1[1] + "-" + arrdata1[0] + "-" + arrdata1[2];
    data1 = new Date(data1formatada);
    var campodediferenca = $(this).attr('total');
    data1moment = moment(data1, "DD/MM/YYYY");

    //var diferenca = dataAtual(data1);

    var hoje = new Date();
    hojemoment = hoje.getDate() + "/" + (hoje.getMonth() + 1) + "/" + hoje.getFullYear();
    hojemoment = moment(hojemoment, "DD/MM/YYYY");
    var diferenca = 0;
    if (data1.getDate() + (data1.getMonth() + 1) + data1.getFullYear() <= hoje.getDate() + (hoje.getMonth() + 1) + hoje.getFullYear()) {
        if (data1.getMonth() == hoje.getMonth() && data1.getFullYear() == hoje.getFullYear()) {
            diferenca = data1moment.diff(hojemoment, 'day');
            diaoumes = 1;
            $("#total" + campodediferenca).val(diferenca + " Dias atras");
        }
        else {
            diferenca = data1moment.diff(hojemoment, 'month');
            diaoumes = 2;
            $("#total" + campodediferenca).val(diferenca + " Meses atras");
        }
    }
    else {
        alert("Data inicial maior que a data Atual! Por favor adicione outra data.");
    }

    //if (diaoumes == 1) {
    //    $("#total" + campodediferenca).val(diferenca + " Dias atras");
    //}
    //else {
    //    $("#total" + campodediferenca).val(diferenca + " Meses atras");
    //}
    //if (Math.sign(diferenca) == -1) {
    //    $("#total" + campodediferenca).val(diferenca + "Dias atras");
    //}
});

//function dataAtual(data1) {
//    var hoje = new Date();
//    hoje = hoje.getDate() + "/" + (data2.getMonth() + 1) + "/" + data2.getFullYear();
//    hoje = moment(hoje, "DD/MM/YYYY");
//    var diaoumes = 0;
//    var diferenca = 0;
//    if (data1 >= hoje) {
//        if (parseInt(data1["_i"].slice(3, 5)) == parseInt(hoje["_i"].slice(3, 5)) && parseInt(data1["_i"].slice(6)) == parseInt(hoje["_i"].slice(6))) {
//            diferenca = data1.diff(hoje, 'day');
//            diaoumes = 1;    
//        }
//        else {
//            diferenca = data1.diff(hoje, 'month');
//            diaoumes = 2;
//        }
//    }
//    else {
//        alert("Data incorreta inserida");
//    }
//    return diferenca, diaoumes;
//}




// Teste de formatação para calculo de data 
//function formatardata(string) {
//    var ano = string.slice(0, 4);
//    var mes = string.slice(5, 7);
//    var dia = string.slice(8);
//    var dataCerta = dia.concat("/", mes, "/", ano);
//    return dataCerta;
//}

function CadastrarProfessorAtuacaoIesPublicacoes() {
    var professor = {};
    professor.Id = $("#idProf").val();
    professor.ArtigosPublicadosPeriodosCientificosNaArea = $("#ArtigosPublicadosPeriodosCientificosNaArea").val();
    professor.ArtigosPublicadosPeriodosCientificosOutrasAreas = $("#ArtigosPublicadosPeriodosCientificosOutrasAreas").val();
    professor.LivrosPublicadosNaArea = $("#LivrosPrublicadosNaArea").val();
    professor.LivrosPublicadosEmOutrasAreas = $("#LivrosPublicadosEmOutrasAreas").val();
    professor.TrabalhosCompletosPublicadosAnuaisNaArea = $("#TrabalhosCompletosPublicadosAnuaisNaArea").val();
    professor.TrabalhosResumosPublicadosAnuaisNaArea = $("#TrabalhosResumosPublicadosAnuaisNaArea").val();
    professor.PropriedadeintelectualDepositado = $("#PropriedadeintelectualDepositado").val();
    professor.PropriedadeIntelectualRegistrado = $("#PropriedadeIntelectualRegistrado").val();
    professor.TraducaoDeLivrosCapitulosArtigosPublicados = $("#TraducaoDeLivrosCapitulosArtigosPublicados").val();
    professor.ProjetosProducoesTecnicosArtisticosCulturais = $("#ProjetosProducoesTecnicosArtisticosCulturais").val();
    professor.ProducaoDidaticoPedagogicoRelevante = $("#ProducaoDidaticoPedagogicoRelevante").val();

    $.ajax({
        type: 'POST',
        url: 'CadastrarProfessorAtuacaoIesPublicacoes',
        dataType: 'json',
        data: { professor: JSON.stringify(professor) },
        success: function () {
            alert("Cadastro de Finalizado com sucesso!");
        },
        erro: function (e) {
            console.log(e);
        }
    });
}



//parte de adicionar disciplina ao professor, precisa ser feito alguns ajustes 
//em nomes de variaveis e verificar na lista de requisitos a necessidade de vincular disciplinas à professor
var iddoprofessor = 0;

$("#adicionarDisciplinaProfessor").click(function () {
    iddoprofessor = $("#idProf").val();
    $.ajax({
        type: 'POST',
        url: 'NovaDisciplinaProfessor',
        dataType: 'json',
        data: {
            idDisciplina: iddadisciplina,
            idProfessor: iddoprofessor
        },
        success: function (retorno) {
            if (retorno == true) {
                $("#tabelaDeDisciplinas").find("tbody").find("tr").remove(".disciplinaCarregada");
                var idD = 0;
                BuscarVinculoDisciplinaProfessor(iddoprofessor, idD);
            }
            else {
                alert("Disciplina já vinculada ao Professor!");
            }

        },
        error: function (e) {
            console.log(e);
        },
    });
});

function BuscarVinculoDisciplinaProfessor(idC, idD) {
    $.ajax({
        type: 'POST',
        url: 'BuscarDisciplinaVinculadaProfessor',
        dataType: 'json',
        data: {
            idC: idC,
            idD: idD
        },
        success: function (retorno) {
            var comparacao = retorno.length;
            if (comparacao > 0) {
                for (var i = 0; i < retorno.length; i++) {
                    $("#tabelaDeDisciplinas").find("tbody").append("<tr class = " + "disciplinaCarregada" + " ><th>" + (retorno[i].Nome) + "</tr></th>");
                }
            }
            else {
                alert("Curso ainda não possui disciplinas vinculadas!");
            }
        },
        error: function (e) {
            console.log(e);
        },
    });
}

$(".CarregarProfessor").click(function () {
    var id = $(this).attr('iddoprofessor');
    $.ajax({
        type: 'POST',
        url: 'GetProfessor',
        dataType: 'json',
        data: { id: id },
        success: function (retorno) {
            $("#Nome").val(retorno.Nome);
            $("#Nome").prop('readonly', 'readonly');
            $("#CPF").val(retorno.CPF);
            $("#CPF").prop('readonly', 'readonly');
            $("#MaiorTitulacao").val(retorno.MaiorTitulacao);
            $("#MaiorTitulacao").prop('readonly', 'readonly');
            $("#AreaFormacao").val(retorno.AreaFormacao);
            $("#AreaFormacao").prop('readonly', 'readonly');
            $("#CurriculoLattos").val(retorno.CurriculoLattos);
            $("#CurriculoLattos").prop('readonly', 'readonly');
            $("#DataAtualizacao").val(retorno.DataAtualizacao);
            $("#DataAtualizacao").prop('readonly', 'readonly');

            $("#Matricula").val(retorno.Matricula);
            $("#Matricula").prop('readonly', 'readonly');
            $("#DataAdmissao").val(retorno.DataAdmissao);
            $("#DataAdmissao").prop('readonly', 'readonly');
            $("#HorasNde").val(retorno.HorasNde);
            $("#HorasNde").prop('readonly', 'readonly');
            $("#OrientacaoTcc").val(retorno.OrientacaoTcc);
            $("#OrientacaoTcc").prop('readonly', 'readonly');
            $("#CoordenacaoCurso").val(retorno.CoordenacaoCurso);
            $("#CoordenacaoCurso").prop('readonly', 'readonly');
            $("#CoordenacaoOutrosCursos").val(retorno.CoordenacaoOutrosCursos);
            $("#CoordenacaoOutrosCursos").prop('readonly', 'readonly');
            $("#Pesquisa").val(retorno.Pesquisa);
            $("#Pesquisa").prop('readonly', 'readonly');
            $("#AtividadesExtraClasseNoCurso").val(retorno.AtividadesExtraClasseNoCurso);
            $("#AtividadesExtraClasseNoCurso").prop('readonly', 'readonly');
            $("#AtividadesExtraClasseOutrosCursos").val(retorno.AtividadesExtraClasseOutrosCursos);
            $("#AtividadesExtraClasseOutrosCursos").prop('readonly', 'readonly');
            $("#QtdeHorasCurso").val(retorno.QtdeHorasCurso);
            $("#QtdeHorasCurso").prop('readonly', 'readonly');
            $("#QtdeHorasOutrosCursos").val(retorno.QtdeHorasOutrosCursos);
            $("#QtdeHorasOutrosCursos").prop('readonly', 'readonly');

            $("#TempoDeVinculoIniterrupto").val(retorno.TempoDeVinculoIniterrupto);
            $("#TempoDeVinculoIniterrupto").prop('readonly', 'readonly');
            $("#total1").val(retorno.total1);
            $("#total1").prop('readonly', 'readonly');
            $("#total2").val(retorno.total2);
            $("#total2").prop('readonly', 'readonly');
            $("#total3").val(retorno.total2);
            $("#total3").prop('readonly', 'readonly');
            $("#total4").val(retorno.total2);
            $("#total4").prop('readonly', 'readonly');
            $("#QtdeParticipacoesEventos").val(retorno.QtdeParticipacoesEventos);
            $("#QtdeParticipacoesEventos").prop('readonly', 'readonly');

            $("#ArtigosPublicadosPeriodosCientificosNaArea").val(retorno.ArtigosPublicadosPeriodosCientificosNaArea);
            $("#ArtigosPublicadosPeriodosCientificosNaArea").prop('readonly', 'readonly');
            $("#ArtigosPublicadosPeriodosCientificosOutrasAreas").val(retorno.ArtigosPublicadosPeriodosCientificosOutrasAreas);
            $("#ArtigosPublicadosPeriodosCientificosOutrasAreas").prop('readonly', 'readonly');
            $("#LivrosPublicadosNaArea").val(retorno.LivrosPrublicadosNaArea);
            $("#LivrosPublicadosNaArea").prop('readonly', 'readonly');
            $("#LivrosPublicadosEmOutrasAreas").val(retorno.LivrosPublicadosEmOutrasAreas);
            $("#LivrosPublicadosEmOutrasAreas").prop('readonly', 'readonly');
            $("#TrabalhosCompletosPublicadosAnuaisNaArea").val(retorno.TrabalhosCompletosPublicadosAnuaisNaArea);
            $("#TrabalhosCompletosPublicadosAnuaisNaArea").prop('readonly', 'readonly');
            $("#TrabalhosResumosPublicadosAnuaisNaArea").val(retorno.TrabalhosResumosPublicadosAnuaisNaArea);
            $("#TrabalhosResumosPublicadosAnuaisNaArea").prop('readonly', 'readonly');
            $("#PropriedadeintelectualDepositado").val(retorno.PropriedadeintelectualDepositado);
            $("#PropriedadeintelectualDepositado").prop('readonly', 'readonly');
            $("#PropriedadeIntelectualRegistrado").val(retorno.PropriedadeIntelectualRegistrado);
            $("#PropriedadeIntelectualRegistrado").prop('readonly', 'readonly');
            $("#TraducaoDeLivrosCapitulosArtigosPublicados").val(retorno.TraducaoDeLivrosCapitulosArtigosPublicados);
            $("#TraducaoDeLivrosCapitulosArtigosPublicados").prop('readonly', 'readonly');
            $("#ProjetosProducoesTecnicosArtisticosCulturais").val(retorno.ProjetosProducoesTecnicosArtisticosCulturais);
            $("#ProjetosProducoesTecnicosArtisticosCulturais").prop('readonly', 'readonly');
            $("#ProducaoDidaticoPedagogicoRelevante").val(retorno.ProducaoDidaticoPedagogicoRelevante);
            $("#ProducaoDidaticoPedagogicoRelevante").prop('readonly', 'readonly');
            $("#Id_Curso").val(retorno.Id);

            $(".salvarProf").prop('disabled', 'disabled');

            var id = retorno.CoordenadorCurso;
            buscarCoordenadorIni(id);

            mostrarTabela();
        },
        erro: function (e) {
            console.log(e);
        }


    });
})

$("#alterarCadastroProfessor").click(function () {
    $("#Nome").removeAttr('readonly');
    $("#CPF").removeAttr('readonly');
    $("#MaiorTitulacao").removeAttr('readonly');
    $("#AreaFormacao").removeAttr('readonly');
    $("#CurriculoLattos").removeAttr('readonly');
    $("#DataAtualizacao").removeAttr('readonly');

    $("#Matricula").removeAttr('readonly');
    $("#DataAdmissao").removeAttr('readonly');
    $("#HorasNde").removeAttr('readonly');
    $("#OrientacaoTcc").removeAttr('readonly');
    $("#CoordenacaoCurso").removeAttr('readonly');
    $("#CoordenacaoOutrosCursos").removeAttr('readonly');
    $("#Pesquisa").removeAttr('readonly');
    $("#AtividadesExtraClasseNoCurso").removeAttr('readonly');
    $("#AtividadesExtraClasseOutrosCursos").removeAttr('readonly');
    $("#QtdeHorasCurso").removeAttr('readonly');
    $("#QtdeHorasOutrosCursos").removeAttr('readonly');

    $("#TempoDeVinculoIniterrupto").removeAttr('readonly');
    $("#total1").removeAttr('readonly');
    $("#total2").removeAttr('readonly');
    $("#total3").removeAttr('readonly');
    $("#total4").removeAttr('readonly');
    $("#QtdeParticipacoesEventos").removeAttr('readonly');

    $("#ArtigosPublicadosPeriodosCientificosNaArea").removeAttr('readonly');
    $("#ArtigosPublicadosPeriodosCientificosOutrasAreas").removeAttr('readonly');
    $("#LivrosPublicadosNaArea").removeAttr('readonly');
    $("#LivrosPublicadosEmOutrasAreas").removeAttr('readonly');
    $("#TrabalhosCompletosPublicadosAnuaisNaArea").removeAttr('readonly');
    $("#TrabalhosResumosPublicadosAnuaisNaArea").removeAttr('readonly');
    $("#PropriedadeintelectualDepositado").removeAttr('readonly');
    $("#PropriedadeIntelectualRegistrado").removeAttr('readonly');
    $("#TraducaoDeLivrosCapitulosArtigosPublicados").removeAttr('readonly');
    $("#ProjetosProducoesTecnicosArtisticosCulturais").removeAttr('readonly');
    $("#ProducaoDidaticoPedagogicoRelevante").removeAttr('readonly');
    $(".salvarProf").removeAttr('disabled');
});

