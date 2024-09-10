using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeladeiraAPI.Domain
{
    internal interface IContainer //Criando a interface IContainer
    {
        void AdicionarItem(int posicao, Item item); //Criando o metodo AdicionarItem
        Item? RetornarItem(int posicao); //Criando o metodo RetornarItem
        void RemoverItem(int posicao); //Criando o metodo RemoverItem
    }
}
