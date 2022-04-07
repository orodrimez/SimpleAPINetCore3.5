using ExamenYache.Models;
using System.Collections.Generic;

namespace ExamenYache.Repository.IRepository
{
    public interface IFrutaRepository
    {
        ICollection<Fruta> GetFrutas();
        ICollection<Fruta> GetFrutas(int skip);
        Fruta GetFruta(string FrutaClave);
        bool ExisteFruta(string Nombre);
        bool CrearFruta(Fruta fruta);
        bool ActualizarFruta(Fruta fruta);
        bool Guardar();
    }
}
