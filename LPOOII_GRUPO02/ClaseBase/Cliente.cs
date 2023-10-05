using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase
{
    public class Cliente
    {
        private int cli_Id;

        public int Cli_Id
        {
            get { return cli_Id; }
            set { cli_Id = value; }
        }
        private long cli_DNI;

        public long Cli_DNI
        {
            get { return cli_DNI; }
            set { cli_DNI = value; }
        }
        private string cli_Apellido;

        public string Cli_Apellido
        {
            get { return cli_Apellido; }
            set { cli_Apellido = value; }
        }
        private string cli_Nombre;

        public string Cli_Nombre
        {
            get { return cli_Nombre; }
            set { cli_Nombre = value; }
        }
        private long cli_Telefono;

        public long Cli_Telefono
        {
            get { return cli_Telefono; }
            set { cli_Telefono = value; }
        }

        public Cliente()
        {
        }
    }
}
