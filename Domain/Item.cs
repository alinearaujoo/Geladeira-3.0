namespace GeladeiraAPI.Domain
{

    // Representa um item que pode ser armazenado em um container
    public sealed class Item
    {
        // Propriedade pública que armazena o identificador do item
        public int IdItem { get; set; }

        // Propriedade pública que armazena a descrição do item
        public string Descricao { get; set; }

        // Construtor padrão que inicializa o item com valores padrão
        public Item()
        {
            IdItem = 0; // Define o identificador do item como 0 (não atribuído)
            Descricao = string.Empty; // Define a descrição como uma string vazia
        }

        // Construtor sobrecarregado que inicializa o item com valores específicos
        public Item(int id, string descricao)
        {
            IdItem = id; // Define o identificador do item com o valor fornecido
            Descricao = descricao; // Define a descrição do item com o valor fornecido
        }
    }
}