function mostrarTabela() {
    $('#tabelaescondida').show();
    $('#tdCursos').hide();
    
};

function AdicionarReadonly() {
    $('input').add('readonly');
}

function PreencherDadosCoordenador(CPF, MaiorTitulacao) {
    $('.preencheauto').add('placeholder', CPF);
    $('.preencheauto1').add('placeholder', MaiorTitulacao);
}