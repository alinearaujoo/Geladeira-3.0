using System.Collections.Generic;
using System.Text;

namespace GeladeiraAPI.Domain
{

    // Representa um andar dentro da geladeira
    public sealed class Andar
    {
        private readonly List<Container> _containers; // Lista de containers no andar

        private const int MAX_CONTAINERS = 2; // Número máximo de containers permitidos por andar

        // Propriedades públicas do andar
        public int Numero { get; }
        public string Descricao { get; }

        // Construtor privado para garantir que andares sejam criados apenas através do método de fábrica
        private Andar(int numero, string descricao)
        {
            Numero = numero;
            Descricao = descricao;
            _containers = []; // Inicializa a lista de containers
        }

        // Método de fábrica para criar um novo andar
        public static Andar CriarAndar(int numero, string descricao) => new(numero, descricao);

        // Método para criar um novo container dentro do andar
        internal void CriarContainer(int numeroContainer)
        {
            // Verifica se o número máximo de containers já foi atingido
            if (_containers.Count >= MAX_CONTAINERS)
                throw new Exception("Número máximo de containers atingido.");

            // Cria um novo container e adiciona à lista de containers do andar
            var container = Container.CriarContainer(numeroContainer);
            _containers.Add(container);
        }

        // Método para obter um container específico por seu número
        internal Container ObterContainer(int numeroContainer)
        {
            // Procura o container na lista pelo número
            var container = _containers.Find(c => c.NumeroContainer == numeroContainer);
            if (container is null)
                throw new Exception("Número do container inválido."); // Lança exceção se o container não for encontrado

            return container;
        }

        // Método para imprimir os itens de todos os containers do andar
        internal string ImprimirItens()
        {
            StringBuilder sb = new(); // Usado para construir a string de saída
            sb.AppendLine($"Andar {Numero}: {Descricao}"); // Adiciona informações do andar à saída

            // Itera sobre cada container e adiciona suas informações à saída
            foreach (var container in _containers)
            {
                sb.AppendLine(container.ImprimirItens());
            }
            return sb.ToString(); // Retorna a string com o conteúdo formatado
        }
    }
}