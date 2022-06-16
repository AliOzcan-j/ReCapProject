using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

//DataAccess sınıflarının ihtiyacı olacak ortak CRUD metodları tanıtılır
//DataAccess->Abstract->IclassDal interfacelerinde ortak olacak
//Bu referanslar kullanılmak istenen teknolojiye istendiği kadar eklenebilir
//Consol uygulaması için yazılan InMemory veya EntityFramework teknolojisi farklı ->
//işleyişe sahip olsa da yaptıkları iş aynı ancak EF ekstradan birkaç adıma daha ihtiyaç duyuyor
//Bu yüzden EF için EfEntityRepositoryBase oluşturuldu

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class, IEntity, new()//where-> T bir class, IEntity ve newlenebilir olmak şartıyla bu Repositoryi kullanabilir
    {
        List<T> GetAll(Expression<Func<T, bool>> filter=null);//bir filtre verilebilir veya verilmemiş olabilir
        T Get(Expression<Func<T, bool>> filter);//Filtre verme zorunlu, yalnızca bir entity dönderir
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
