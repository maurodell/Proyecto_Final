using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;
using Abstraccion;

namespace BLL
{
    public class BLLCategoria : IRepositorio<BECategoria>
    {
        public BLLCategoria()
        {
            mppCategoria = new MPPCategoria();
        }
        MPPCategoria mppCategoria;
        public bool Alta(int Parametro)
        {
            return mppCategoria.Alta(Parametro);
        }

        public bool Baja(int Parametro)
        {
            return mppCategoria.Baja(Parametro);
        }

        public bool Crear(BECategoria Parametro)
        {
            return mppCategoria.Crear(Parametro);
        }
        public List<BECategoria> Listar()
        {
            return mppCategoria.Listar();
        }
        public List<BECategoria> ListarTodos()
        {
            return mppCategoria.ListarTodos();
        }
        public List<BECategoria> Buscar(string Parametro)
        {
            return mppCategoria.Buscar(Parametro);
        }
        public bool Eliminar(int Parametro)
        {
            return mppCategoria.Eliminar(Parametro);
        }

        public bool Modificar(BECategoria Parametro, string parametro2)
        {
            return mppCategoria.Modificar(Parametro, parametro2);
        }
    }
}
