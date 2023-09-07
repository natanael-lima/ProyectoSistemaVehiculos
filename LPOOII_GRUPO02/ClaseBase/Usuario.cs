using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase
{
    public class Usuario
    {
        private int user_Id;

        public int User_Id
        {
            get { return user_Id; }
            set { user_Id = value; }
        }
        private string user_Name;

        public string User_Name
        {
            get { return user_Name; }
            set { user_Name = value; }
        }
        private string user_Password;

        public string User_Password
        {
            get { return user_Password; }
            set { user_Password = value; }
        }
        private string user_Nombre;

        public string User_Nombre
        {
            get { return user_Nombre; }
            set { user_Nombre = value; }
        }
        private string user_Apellido;

        public string User_Apellido
        {
            get { return user_Apellido; }
            set { user_Apellido = value; }
        }
        private string user_Rol;

        public string User_Rol
        {
            get { return user_Rol; }
            set { user_Rol = value; }
        }

        public Usuario()
        {
            throw new System.NotImplementedException();
        }
    }
}
