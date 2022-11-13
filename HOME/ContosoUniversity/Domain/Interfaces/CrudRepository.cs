using ContosoUniversity.Domain.Entities.Base;
using ContosoUniversity.Infrastructure.Data;

namespace ContosoUniversity.Domain.Interfaces
{
    public class CrudRepository<T> : ICrudRepository<T> where T : BaseEntity
    {
        protected readonly DBLocalContosoUniversity _dbContext;
        protected IEnumerable<T>? _entities;

    private void SetEntity(Type T){
        if(typeof(T) == typeof(Person)){
        _entities = (IEnumerable<T>)_dbContext.person;
        }else if(typeof(T) == typeof(Course)){
        _entities = (IEnumerable<T>)_dbContext.Courses;
        }else if(typeof(T) == typeof(Departaments)){
        _entities = (IEnumerable<T>)_dbContext.departaments;
        }
        }

        public IEnumerable<T> GetAll()
        {
        return _entities!;
        }
        
        public T GetById(int id)
        {
        return _entities!.Single<T>(x => x.Id == id);
        }

        public IEnumerable<T> FindBy(Func<T, bool> filters)
        {
        return _entities!.Where<T>(filters);
        }

        public CrudRepository()
            {
            _dbContext = new DBLocalContosoUniversity();
            SetEntity(typeof(T));
            }

    }
}