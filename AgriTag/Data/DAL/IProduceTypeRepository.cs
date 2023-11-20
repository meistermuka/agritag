using AgriTag.Models;

namespace AgriTag.Data.DAL
{
    public interface IProduceTypeRepository : IDisposable
    {
        IEnumerable<ProduceType> GetProduceTypes();
        ProduceType GetProduceTypeByID(string id);
        void InsertProduceType(ProduceType produceType);
        void UpdateProduceType(ProduceType produceType);
        void Save();
    }
}
