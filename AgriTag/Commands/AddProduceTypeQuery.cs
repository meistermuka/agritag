using AgriTag.Dtos;
using MediatR;

namespace AgriTag.Commands
{
    public class AddProduceTypeQuery : IRequest<ProduceTypeDto>
    {
        public ProduceTypeDto ProduceType { get; set; }
        public AddProduceTypeQuery(ProduceTypeDto produceType)
        {
            ProduceType = produceType;
        }
    }
}
