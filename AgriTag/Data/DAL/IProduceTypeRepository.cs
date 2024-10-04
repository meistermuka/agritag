using AgriTag.Models;

namespace AgriTag.Data.DAL
{
    public interface IProduceTypeRepository : IDisposable
    {
        IEnumerable<ProduceType> GetProduceTypes();
        Task<ProduceType?> GetProduceTypeByID(string id);
        Task InsertProduceType(ProduceType produceType);
        void UpdateProduceType(ProduceType produceType);
        void DeleteProduceTypeByID(string id);
        void Save();
    }
}
