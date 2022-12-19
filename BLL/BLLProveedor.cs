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
    public class BLLProveedor : IRepositorio<BEProveedor>
    {
        public BLLProveedor()
        {
            mppProveedor = new MPPProveedor();
        }
        MPPProveedor mppProveedor;
        public bool Alta(int Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int Parametro)
        {
            throw new NotImplementedException();
        }

        public List<BEProveedor> Buscar(string Parametro)
        {
            return mppProveedor.Buscar(Parametro);
        }

        public bool Crear(BEProveedor Parametro)
        {
            return mppProveedor.Crear(Parametro);
        }
        public bool Eliminar(int Parametro)
        {
            return mppProveedor.Eliminar(Parametro);
        }

        public List<BEProveedor> Listar()
        {
            return mppProveedor.Listar();
        }

        public List<BEProveedor> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BEProveedor Parametro, string parametro2)
        {
            return mppProveedor.Modificar(Parametro, parametro2);
        }
    }
}
