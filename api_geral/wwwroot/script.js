const API_URL = 'http://localhost:5082/api/despesas';
let despesas = [];

function calcularValorComJuros(valor) {
  return valor + (valor * 0.10); // Calcula o valor com 10% de juros
}

function criarLinha(d) {
  const valorAtualizado = calcularValorComJuros(d.valor);
  
  return `
    <tr>
      <td>${d.titulo}</td>
      <td>${d.data.split('T')[0]}</td>
      <td>R$ ${valorAtualizado.toFixed(2)}</td>
      <td>${d.formaPagamento}</td>
      <td>${d.categoria}</td>
      <td>
        <button class="btn btn-sm btn-outline-primary" onclick="editar(${d.id})"><i class="bi bi-pencil"></i></button>
        <button class="btn btn-sm btn-outline-danger" onclick="excluir(${d.id})"><i class="bi bi-trash"></i></button>
      </td>
    </tr>`;
}

function renderizar(lista = despesas) {
  // Exibe a lista de despesas com o valor atualizado
  document.getElementById('listaDespesas').innerHTML = lista.map(criarLinha).join('');
  document.getElementById('totalDespesas').textContent = lista.length;

  // Calcula o total com 10% de juros
  const total = lista.reduce((soma, d) => soma + calcularValorComJuros(d.valor), 0);
  document.getElementById('valorTotal').textContent = 'R$ ' + total.toFixed(2);
}

async function carregar() {
  const resposta = await fetch(API_URL);
  despesas = await resposta.json();
  renderizar();
}

async function salvar(event) {
  event.preventDefault();

  const id = document.getElementById('despesaId').value;
  const dados = {
    titulo: document.getElementById('titulo').value,
    data: document.getElementById('data').value,
    valor: parseFloat(document.getElementById('valor').value), // Valor original, sem os juros
    formaPagamento: document.getElementById('formaPagamento').value,
    categoria: document.getElementById('categoria').value
  };

  let metodo, url;

  if (id) {
    dados.id = parseInt(id);
    metodo = 'PUT';
    url = `${API_URL}/${id}`;
  } else {
    metodo = 'POST';
    url = API_URL;
  }

  await fetch(url, {
    method: metodo,
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(dados)
  });

  document.getElementById('formDespesa').reset();
  carregar();
}

async function editar(id) {
  const resposta = await fetch(`${API_URL}/${id}`);
  const d = await resposta.json();

  document.getElementById('despesaId').value = d.id;
  document.getElementById('titulo').value = d.titulo;
  document.getElementById('data').value = d.data.split('T')[0];
  document.getElementById('valor').value = d.valor; // Valor original
  document.getElementById('formaPagamento').value = d.formaPagamento;
  document.getElementById('categoria').value = d.categoria;
}

async function excluir(id) {
  await fetch(`${API_URL}/${id}`, { method: 'DELETE' });
  carregar();
}

function filtrar() {
  const categoria = document.getElementById('filtroCategoria').value;
  if (categoria) {
    const filtradas = despesas.filter(d => d.categoria === categoria);
    renderizar(filtradas);
  } else {
    renderizar(despesas);
  }
}

function limparFiltro() {
  document.getElementById('filtroCategoria').value = '';
  renderizar(despesas);
}

document.addEventListener('DOMContentLoaded', carregar);
document.getElementById('formDespesa').addEventListener('submit', salvar);
document.getElementById('filtroCategoria').addEventListener('change', filtrar);
