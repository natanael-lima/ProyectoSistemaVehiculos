using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClaseBase 
{
    public class Usuario : INotifyPropertyChanged
    {
        private int user_Id;

        public int User_Id
        {
            get { return user_Id; }
            set { user_Id = value;
            Notificador("user_Id");
            }
        }
        private string user_Name;

        public string User_Name
        {
            get { return user_Name; }
            set { user_Name = value;
            Notificador("user_Name");
            }
        }
        private string user_Password;

        public string User_Password
        {
            get { return user_Password; }
            set { user_Password = value;
            Notificador("user_Password");
            }
        }
        private string user_Nombre;

        public string User_Nombre
        {
            get { return user_Nombre; }
            set { user_Nombre = value;
            Notificador("user_Nombre");
            }
        }
        private string user_Apellido;

        public string User_Apellido
        {
            get { return user_Apellido; }
            set { user_Apellido = value;
            Notificador("user_Apellido");
            }
        }
        private string user_Rol;

        public string User_Rol
        {
            get { return user_Rol; }
            set { user_Rol = value;
            Notificador("user_Rol");
            }
        }

        public Usuario()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Notificador(string pop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(pop));
            }
        }
    }
}
