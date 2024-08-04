using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipo_Negocio
{
    public class EquipoReportes
    {
        public int ReporteEquiposDisponibles()
        {
            return Convert.ToInt32(CommonBC.ModeloEquipo.spObtenerCantidadEquiposMasculinos().First().Value);
        }

        public int ReporteEquiposNoDisponibles()
        {
            return Convert.ToInt32(CommonBC.ModeloEquipo.spObtenerCantidadEquiposFemeninos().First().Value);
        }

    }
}
