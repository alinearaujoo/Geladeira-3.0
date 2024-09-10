using System.Collections.Generic;
using System.Text;

namespace GeladeiraAPI.Domain
{

    // Representa um container dentro de um andar da geladeira
    public sealed class Container
    {
        private readonly List<Item> _items; // Lista de itens armazenados no container

        private const int MAX_POSICOES = 4; // Número máximo de posições para itens no container

        // Propriedade pública que representa o número do container
        public int NumeroContainer { get; } 

        // Construtor privado para garantir que containers sejam criados apenas através do método de fábrica
        private Container(int numeroContainer) 
        {
            NumeroContainer = numeroContainer;
            _items = []; // Inicializa a lista de itens
            for (int i = 0; i < MAX_POSICOES; i++) 
            {
                _items.Add(new Item()); // Adiciona itens vazios em cada posição
            }
        }

        // Método de fábrica para criar um novo container
        public static Container CriarContainer(int numeroContainer) => new(numeroContainer); // Retorna o container criado

        // Método para adicionar um item em uma posição específica no container
        internal void AdicionarItem(int posicao, Item item) 
        {
            // Verifica se a posição está dentro do intervalo permitido
            if (posicao < 0 || posicao >= MAX_POSICOES) 
                throw new Exception("Posição inválida."); // Lança exceção se a posição estiver fora do intervalo permitido

            // Verifica se a posição já está ocupada
            if (_items[posicao].IdItem != 0) // Verifica se o item existe
                throw new Exception("Posição já ocupada."); // Lança exceção se a posição estiver ocupada

            // Adiciona o item na posição especificada
            _items[posicao] = item; 
        }

        // Método para remover um item de uma posição específica no container
        internal void RemoverItem(int posicao) // Recebe a posição que deseja remover
        {
            // Verifica se a posição está dentro do intervalo permitido
            if (posicao < 0 || posicao >= MAX_POSICOES) 
                throw new Exception("Posição inválida."); // Lança exceção se a posição estiver fora do intervalo permitido

            // Remove o item da posição especificada, reinicializando-a
            _items[posicao] = new Item();
        }

        // Método para limpar todos os itens do container
        internal void LimparContainer()
        {
            // Reinicializa todas as posições do container
            for (int i = 0; i < MAX_POSICOES; i++) // Itera sobre cada posição
            {
                _items[i] = new Item(); // Reinicializa o item da posição especificada
            }
        }


        // Método para imprimir os itens armazenados no container
        internal string ImprimirItens()
        {
            StringBuilder sb = new(); // Usado para construir a string de saída
            sb.AppendLine($"Container {NumeroContainer}"); // Adiciona informações do container à saída

            // Itera sobre cada item e adiciona informações sobre itens não vazios
            for (int i = 0; i < _items.Count; i++) 
            {
                var item = _items[i]; // Recebe o item da posição especificada
                if (item.IdItem != 0) // Verifica se o item existe
                {
                    sb.AppendLine($"  Posição {i}: {item.Descricao}"); // Adiciona descrição do item
                }
            }
            return sb.ToString(); // Retorna a string com o conteúdo formatado
        }
    }
}