using GeladeiraAPI.Domain;

class Program //Classe principal onde o programa é executado. Aqui adicionamos alguns itens à geladeira e imprimimos todos os produtos.
{
    public static void Main() //Metodo principal do programa.
    {
        // Cria uma nova instância de Geladeira usando o método de fábrica
        var geladeira = Geladeira.CriarGeladeira();

        // Adiciona dois andares à geladeira com suas respectivas descrições
        geladeira.CriarAndar("Charcutaria, Carnes e Ovos");
        geladeira.CriarAndar("Laticínios e Enlatados");

        // Cria dois containers no primeiro andar (índice 0)
        geladeira.CriarContainer(0, 0);
        geladeira.CriarContainer(0, 1);

        // Adiciona itens nos containers criados
        // Adiciona "Carne de Frango" no container 0 do andar 0, na posição 0
        geladeira.AdicionarItem(0, 0, 0, new Item(1, "Carne de Frango"));
        // Adiciona "Ovos" no container 1 do andar 0, na posição 1
        geladeira.AdicionarItem(0, 1, 1, new Item(2, "Ovos"));

        // Imprime o conteúdo atual da geladeira
        Console.WriteLine("--------------------");
        Console.WriteLine(geladeira.ImprimirConteudo());
        Console.WriteLine("--------------------");

        // Remove o item da posição 0 no container 0 do andar 0
        geladeira.RemoverItem(0, 0, 0);

        // Limpa todos os itens do container 1 no andar 0
        geladeira.LimparContainer(0, 1);

        // Imprime novamente o conteúdo da geladeira após as modificações
        Console.WriteLine(geladeira.ImprimirConteudo());
        Console.WriteLine("--------------------");
    }
}
