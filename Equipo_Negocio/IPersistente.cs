using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipo_Negocio
{
    public interface IPersistente
    {
        bool Create();
        bool Read(int EquipoId);
        bool Update();
        bool Delete(int EquipoId);
    }
}
