﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Menu
{
    public class MenuPrincipalDTO
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public string Opcao { get; set; }

        public int Nivel { get; set; }
    }
}
