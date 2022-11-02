using System.Collections.Generic;

namespace Lab4_Grupo2.Models.Datos
{
    public class Singleton
    {
        private static Singleton _instance = null;
        public static Singleton Instance
        {
            get
            {
                if (_instance == null) _instance = new Singleton();
                return _instance;
            }
        }
        public Clases.Heap<Paciente> Pacientes = new Clases.Heap<Paciente>();
        public List<Paciente> Historial = new List<Paciente>();
    }
}
