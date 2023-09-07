using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase
{
    public class TipoVehiculo
    {
        private int tv_Id;

        public int Tv_Id
        {
            get { return tv_Id; }
            set { tv_Id = value; }
        }
        private string tv_Descripcion;

        public string Tv_Descripcion
        {
            get { return tv_Descripcion; }
            set { tv_Descripcion = value; }
        }
        private decimal tv_Tarifa;

        public decimal Tv_Tarifa
        {
            get { return tv_Tarifa; }
            set { tv_Tarifa = value; }
        }

        public TipoVehiculo()
        {
            throw new System.NotImplementedException();
        }
    }
}
