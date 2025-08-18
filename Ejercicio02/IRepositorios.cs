using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public interface IRepositorios <T>
    {
        void Agregar(T objeto);
        void Modificar(T objeto);
        List<T> ListarTodos();
        T Buscar(int id);
        void Eliminar(int id);
    }
}
