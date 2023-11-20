using AgriTag.Models;
using Microsoft.EntityFrameworkCore;

namespace AgriTag.Data.DAL
{
    public class ProduceTypeRepository : IProduceTypeRepository, IDisposable
    {
        private AgriTagDbContext context;
        private bool disposed = false;

        public ProduceTypeRepository( AgriTagDbContext context )
        {
            this.context = context;
        }

        public IEnumerable<ProduceType> GetProduceTypes()
        {
            return context.ProduceTypes.ToList();
        }

        public ProduceType GetProduceTypeByID(string id)
        {
            Guid produceTypeId = Guid.Parse( id );
            return context.ProduceTypes.Find(produceTypeId);
        }

        public void InsertProduceType(ProduceType produceType)
        {
            context.ProduceTypes.Add(produceType);
        }

        public void UpdateProduceType(ProduceType produceType)
        {
            context.Entry(produceType).State = EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing )
        {
            if (!disposed)
            { 
                if(disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
