using System;

namespace Equipo_Negocio
{
    public static class CommonBC
    {
        private static Equipo_DALC.PCEEntities _modeloEquipo;

        public static Equipo_DALC.PCEEntities ModeloEquipo
        {
            get
            {
                if (_modeloEquipo == null)
                {
                    _modeloEquipo = new Equipo_DALC.PCEEntities();
                }
                return _modeloEquipo;
            }
        }

        static CommonBC()
        {
            // Constructor estático para inicialización, si es necesario.
        }
    }
}


