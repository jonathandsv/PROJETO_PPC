function mostrarTabela() {
    $('#tabelaescondida').show();
    $('#tdCursos').hide();
    
};

function AdicionarReadonly() {
    $('input').add('readonly');
}

function PreencherDadosCoordenador(CPF) {
    $('#preencheauto').prop('placeholder', CPF);
    //$('.preencheauto1').add('placeholder', MaiorTitulacao);
}