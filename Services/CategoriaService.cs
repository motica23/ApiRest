using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi;
using webapi.Models;

namespace ApiRest.Services
{
    public class CategoriaService : ICategoriaService
    {
        Context _context;
        public IEnumerable<Categoria> Get()
        {
            return _context.Categorias;
        }

        public CategoriaService(Context context)
        {
            this._context = context;
        }
        
        public bool Save(Categoria categoria)
        {
            _context.Add(categoria);
            
            if(_context.SaveChanges() == 0)
            {
                return false;
            }

            return true;
        }

        public bool Update (Guid id, Categoria categoria)
        {
            var entity = _context.Categorias.Find(id);

            if(entity == null)
            {
                return false;               
            }

            entity.Nombre = categoria.Nombre;
            entity.Descripcion = categoria.Descripcion;
            entity.Peso = categoria.Peso;

            if(_context.SaveChanges() == 0)
            {
                return false;
            }

            return true;
        }

        public bool Delete(Guid id)
        {
            var entity = _context.Categorias.Find(id);

            if(entity == null)
            {
                
                return false;
            }

            _context.Remove(entity);

            _context.SaveChanges();
            
            return true;
        }
    }

    public interface ICategoriaService
    {
        IEnumerable<Categoria> Get();
        bool Save(Categoria categoria);
        bool Update (Guid id, Categoria categoria);
        bool Delete(Guid id);
    }
}