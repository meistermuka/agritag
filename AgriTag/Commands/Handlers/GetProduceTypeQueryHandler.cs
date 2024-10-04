using AgriTag.Data.DAL;
using AgriTag.Dtos;
using AgriTag.Models;
using MediatR;

namespace AgriTag.Commands.Handlers
{
    public class GetProduceTypeQueryHandler : IRequestHandler<GetProduceTypeQuery, ProduceTypeDto>
    {
        private readonly IProduceTypeRepository _produceTypeRepository;

        public GetProduceTypeQueryHandler(IProduceTypeRepository produceTypeRepository)
        {
            _produceTypeRepository = produceTypeRepository;
        }
        public async Task<ProduceTypeDto?> Handle(GetProduceTypeQuery request, CancellationToken cancellationToken)
        {
            ProduceTypeDto? fetchedProduceType;
            ProduceType? produceType = await _produceTypeRepository.GetProduceTypeByID(request.Id);
            if (produceType != null)
            {
                fetchedProduceType = new(produceType.Name, produceType.Description);
            } else
            {
                fetchedProduceType = null;
            }
             

            return fetchedProduceType;
        }
    }
}
