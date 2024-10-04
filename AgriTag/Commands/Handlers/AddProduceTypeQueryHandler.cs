using AgriTag.Data.DAL;
using AgriTag.Dtos;
using AgriTag.Models;
using MediatR;

namespace AgriTag.Commands.Handlers
{
    public class AddProduceTypeQueryHandler : IRequestHandler<AddProduceTypeQuery, ProduceTypeDto>
    {
        private readonly IProduceTypeRepository _produceTypeRepository;

        public AddProduceTypeQueryHandler(IProduceTypeRepository produceTypeRepository)
        {
            _produceTypeRepository = produceTypeRepository;
        }

        public async Task<ProduceTypeDto> Handle(AddProduceTypeQuery request, CancellationToken cancellationToken)
        {
            ProduceType newProduceType = new()
            {
                ProduceTypeId = Guid.NewGuid(),
                Name = request.ProduceType.Name,
                Description = request.ProduceType.Description,
                IsDeleted = false
            };
            await _produceTypeRepository.InsertProduceType(newProduceType);
            return request.ProduceType;
        }
    }
}
