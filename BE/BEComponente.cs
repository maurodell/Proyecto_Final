using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class BEComponente
    {
        public int _codigo { get; set; }
        public string _nombre { get; set; }
        //el tipo se utiliza para verificar si es permiso o familia(rol)
        //solo se utiliza para borrar el rol, identificando si es familia o permisos
        public int _tipo { get; set; }
        public abstract void AgregarHijo(BEComponente componente);
        public abstract IList<BEComponente> ObjenerHijos { get; }
        public abstract void VaciarHijos();
        public BEMenuPermisos Permiso { get; set; }

        public override string ToString()
        {
            return _nombre;
        }
    }
}
