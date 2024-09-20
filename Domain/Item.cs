using GeladeiraAPI.Domain;

namespace GeladeiraAPI.Domain
{

    // Representa um item que pode ser armazenado em um container
    public class Item
    {
        // Propriedade pública que armazena o identificador do item
        public int IdItem { get; set; }

        public int Nome { get; set; }

        // Propriedade pública que armazena a descrição do item
        public string Descricao { get; set; }

        // Propriedade que armazena o número do andar
        public int Andar { get; set; }

        // Propriedade que armazena o número do container
        public int Container { get; set; }

        // Propriedade que armazena a posição do item
        public int Posicao { get; set; }

        // Construtor padrão que inicializa o item com valores padrão
        public Item()
        {
            
        }

        // Construtor sobrecarregado que inicializa o item com valores específicos
        public Item(int id, string Nome)
        {
            IdItem = id; 
            Nome = Nome; 
        }
    }
}