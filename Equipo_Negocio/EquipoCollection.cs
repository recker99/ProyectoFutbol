using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipo_Negocio
{
    public class EquipoCollection : ObservableCollection<Equipo>
    {
        public List<Equipo> ReadAll()
        {
            try
            {
                var equipos = CommonBC.ModeloEquipo.vwEquipo;
                return ObtenerEquipos(equipos.ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los equipos: " + ex.Message);
                return new List<Equipo>();
            }
        }

        private List<Equipo> ObtenerEquipos(List<Equipo_DALC.vwEquipo> equiposDALC)
        {
            return equiposDALC.Select(e => new Equipo
            {
                EquipoId = e.EquipoId,
                NombreEquipo = e.NombreEquipo,
                CantidadJugadores = e.CantidadJugadores,
                NombreDT = e.NombreDT,
                TipoEquipo = e.TipoEquipo,
                CapitanEquipo = e.CapitanEquipo,
                TieneSub21 = e.TieneSub21
            }).ToList();
        }

        public void ActualizarEquipo(Equipo equipo)
        {
            var index = this.IndexOf(equipo);
            if (index != -1)
            {
                this[index] = equipo;
                OnPropertyChanged(new PropertyChangedEventArgs("Item[" + index + "]"));
            }
        }

    }
}
