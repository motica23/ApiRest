using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi;
using webapi.Models;

namespace ApiRest.Services
{
    public class TareaService : ITareaService
    {
        Context _context;

        public TareaService(Context context)
        {
            this._context = context;
        }

        public bool Save(Tarea tarea)
        {
            _context.Tareas.Add(tarea);

                if(_context.SaveChanges() > 0)
                {
                    return true;
                }

                return false;
        }

        public IEnumerable<Tarea> Get()
        {
            return _context.Tareas;
        }

        public bool Update (Guid Id, Tarea tarea)
        {
            var entity = _context.Tareas.Find(Id);

            if (entity == null)
            {
                return false;
            }

            entity.Descripcion = tarea.Descripcion;
            entity.PrioridadTarea = tarea.PrioridadTarea;
            entity.Resumen = tarea.Resumen;
            entity.Titulo = tarea.Titulo;

            if(_context.SaveChanges() == 0)
            {
                return false;    
            }            

            return true;
        }

        public bool Delete(Guid id)
        {
            var entity = _context.Tareas.Find(id);

            if(entity == null)
            {
                return false;
            }

    
            _context.Remove(entity);

            return true;

        }

    }

    public interface ITareaService
    {
        bool Delete(Guid id);
        bool Update (Guid Id, Tarea tarea);
        bool Save(Tarea tarea);
        IEnumerable<Tarea> Get();
    }
}