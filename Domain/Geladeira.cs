using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeladeiraAPI.Domain
{

    // Representa a geladeira que contém uma lista de andares
    public sealed class Geladeira
    {
        // Lista interna que armazena os andares da geladeira
        private readonly List<Andar> Andares;

        // Constante que define o número máximo de andares permitido na geladeira
        private const int MAX_ANDARES = 3;

        // Construtor privado para evitar a criação direta de instâncias
        // Inicializa a lista de andares
        private Geladeira() => Andares = [];

        // Método de fábrica estático para criar uma nova instância de Geladeira
        public static Geladeira CriarGeladeira() => new Geladeira();

        // Método para adicionar um novo andar à geladeira
        public void CriarAndar(string descricao)
        {
            // Verifica se o número máximo de andares já foi atingido
            if (Andares.Count >= MAX_ANDARES)
                throw new Exception("Número máximo de andares atingido.");

            // Cria um novo andar e adiciona à lista de andares
            var andar = Andar.CriarAndar(Andares.Count, descricao);
            Andares.Add(andar);
        }

        // Método para adicionar um novo container a um andar específico
        public void CriarContainer(int numeroAndar, int numeroContainer)
        {
            // Obtém o andar especificado pelo número
            var andar = ObterAndar(numeroAndar);
            // Cria um novo container dentro do andar obtido
            andar.CriarContainer(numeroContainer);
        }

        // Método para adicionar um item a um container específico
        public void AdicionarItem(int numAndar, int numContainer, int posicao, Item item)
        {
            // Obtém o andar especificado pelo número
            var andar = ObterAndar(numAndar);
            // Obtém o container especificado pelo número dentro do andar
            var container = andar.ObterContainer(numContainer);
            // Adiciona o item ao container na posição especificada
            container.AdicionarItem(posicao, item);
        }

        // Método para remover um item de um container específico
        public void RemoverItem(int numAndar, int numContainer, int posicao)
        {
            // Obtém o andar especificado pelo número
            var andar = ObterAndar(numAndar);
            // Obtém o container especificado pelo número dentro do andar
            var container = andar.ObterContainer(numContainer);
            // Remove o item do container na posição especificada
            container.RemoverItem(posicao);
        }

        // Método para limpar todos os itens de um container específico
        public void LimparContainer(int numAndar, int numContainer)
        {
            // Obtém o andar especificado pelo número
            var andar = ObterAndar(numAndar);
            // Obtém o container especificado pelo número dentro do andar
            var container = andar.ObterContainer(numContainer);
            // Limpa todos os itens do container
            container.LimparContainer();
        }

        // Método para imprimir o conteúdo de todos os andares da geladeira
        public string ImprimirConteudo()
        {
            StringBuilder sb = new();
            // Itera sobre todos os andares e adiciona a impressão dos itens ao StringBuilder
            foreach (var andar in Andares)
            {
                sb.AppendLine(andar.ImprimirItens());
            }
            // Retorna a representação em string do conteúdo da geladeira
            return sb.ToString();
        }

        // Método privado para obter um andar específico pelo número
        private Andar ObterAndar(int numero)
        {
            // Verifica se o número do andar está dentro do intervalo válido
            if (numero < 0 || numero >= Andares.Count)
                throw new Exception("Número do andar inválido.");

            // Retorna o andar correspondente ao número especificado
            return Andares[numero];
        }


        //Implementando API ao sistema

        //Retorna todos os itens
        public List<Item> GetAllItems()
        {
            return Andares.SelectMany(andar => andar.Containers().SelectMany(container => container.Items())).ToList();
        }

        //Retorna o item específico mostrando o andar e a posição
        public (Item item, int andar, int container)? GetItemById(int id) 
        {
            foreach (var andar in Andares) 
            {
                foreach (var container in andar.Containers())
                {
                    var item = container.Items().FirstOrDefault(i => i.IdItem == id); 
                    if (item != null) 
                    {
                        return (item, andar.Numero, container.NumeroContainer);
                    }
                }
            }
            return null; 
        }

        public void AddItem(Item item, int andar, int container) 
        {
            int posicao = 1;
            Andares[andar].Containers()[container].AdicionarItem(posicao, item); 
        }

        public void UpdateItem(int id, Item newItem) 
        {
            //Retorna o item específico mostrando o andar e a posição
            var itemInfo = GetItemById(id); 
            if (itemInfo != null) 
            {
                var (item, andar, container) = itemInfo.Value; 
                item.IdItem = newItem.IdItem;
                item.Descricao = newItem.Descricao;
            }
        }

        //Exclui um item de uma posição
        public void DeleteItem(int id) 
        {
            foreach (var andar in Andares) 
            {
                foreach (var container in andar.Containers()) 
                {
                    var item = container.Items().FirstOrDefault(i => i.IdItem == id); 
                    if (item != null) 
                    {
                        container.Items().Remove(item);
                        return; 
                    }
                }
            }
        }
    }
}


