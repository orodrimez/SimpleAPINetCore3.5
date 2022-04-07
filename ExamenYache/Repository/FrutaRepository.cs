using ExamenYache.Data;
using ExamenYache.Models;
using ExamenYache.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace ExamenYache.Repository
{
    public class FrutaRepository : IFrutaRepository
    {

        private readonly ApplicationDBContext _DbContext;
        public FrutaRepository(ApplicationDBContext dBContext)
        {
            _DbContext = dBContext;
        }

        public ICollection<Fruta> GetFrutas()
        {
            return _DbContext.Fruta.OrderBy(p => p.Nombre).ToList();
        }
        public ICollection<Fruta> GetFrutas(int skip) 
        {
            return _DbContext.Fruta.OrderBy(p => p.Id).Skip(skip).Take(5).ToList();
        }
        public Fruta GetFruta(string FrutaClave) 
        {
            return _DbContext.Fruta.FirstOrDefault(f => f.Clave.ToLower().Trim().Equals(FrutaClave.ToLower().Trim()));
        }
        public bool ExisteFruta(string Nombre) 
        {
            return _DbContext.Fruta.Where(f => f.Nombre.ToLower().Trim().Equals(Nombre.ToLower().Trim())).Any();
        }
        public bool CrearFruta(Fruta fruta)
        {
            _DbContext.Fruta.Add(fruta);
            return Guardar();
        }
        public bool ActualizarFruta(Fruta fruta) 
        {
            _DbContext.Fruta.Update(fruta);
            return Guardar();
        }
        public bool Guardar()
        {
            return _DbContext.SaveChanges() >= 0 ? true : false;
        }

    }
}
