﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeladeiraAPI.Domain
{
    internal interface IContainer 
    {
        void AdicionarItem(int posicao, Item item); 
        Item? RetornarItem(int posicao); 
        void RemoverItem(int posicao); 
    }
}
