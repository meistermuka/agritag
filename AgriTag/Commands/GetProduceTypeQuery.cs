using AgriTag.Dtos;
using MediatR;

namespace AgriTag.Commands
{
    public class GetProduceTypeQuery : IRequest<ProduceTypeDto>
    {
        public string Id { get; set; }
        public GetProduceTypeQuery(string id)
        {
            Id = id;
        }
    }
}
