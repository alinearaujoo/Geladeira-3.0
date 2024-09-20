using System.Collections.Generic;
using System.Text;

namespace GeladeiraAPI.Domain
{

    // Representa um container dentro de um andar da geladeira
    public sealed class Container
    {
        private readonly List<Item> _items; 

        private const int MAX_POSICOES = 4; 

        // Propriedade pública que representa o número do container
        public int NumeroContainer { get; }

        // Construtor privado para garantir que containers sejam criados apenas através do método de fábrica
        private Container(int numeroContainer) 
        {
            NumeroContainer = numeroContainer;
            _items = []; 
            for (int i = 0; i < MAX_POSICOES; i++) 
            {
                _items.Add(new Item()); 
            }
        }

        // Método de fábrica para criar um novo container
        public static Container CriarContainer(int numeroContainer) => new(numeroContainer); 

        // Método para adicionar um item em uma posição específica no container
        internal void AdicionarItem(int posicao, Item item) 
        {
            // Verifica se a posição está dentro do intervalo permitido
            if (posicao < 0 || posicao >= MAX_POSICOES) 
                throw new Exception("Posição inválida."); 

            // Verifica se a posição já está ocupada
            if (_items[posicao].IdItem != 0) 
                throw new Exception("Posição já ocupada."); 

            // Adiciona o item na posição especificada
            _items[posicao] = item; 
        }

        // Método para remover um item de uma posição específica no container
        internal void RemoverItem(int posicao) 
        {
            // Verifica se a posição está dentro do intervalo permitido
            if (posicao < 0 || posicao >= MAX_POSICOES) 
                throw new Exception("Posição inválida.");

            // Remove o item da posição especificada, reinicializando-a
            _items[posicao] = new Item();
        }

        // Método para limpar todos os itens do container
        internal void LimparContainer()
        {
            // Reinicializa todas as posições do container
            for (int i = 0; i < MAX_POSICOES; i++) 
            {
                _items[i] = new Item(); 
            }
        }


        // Método para imprimir os itens armazenados no container
        internal string ImprimirItens()
        {
            StringBuilder sb = new(); 
            sb.AppendLine($"Container {NumeroContainer}"); 

            // Itera sobre cada item e adiciona informações sobre itens não vazios
            for (int i = 0; i < _items.Count; i++) 
            {
                var item = _items[i]; 
                if (item.IdItem != 0) 
                {
                    sb.AppendLine($"  Posição {i}: {item.Descricao}"); 
                }
            }
            return sb.ToString(); 
        }

        public List<Item> Items()
        {
            return _items;
        }
    }
}