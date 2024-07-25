using AutoMapper;
using MediatR;
using Para.Base.Response;
using Para.Bussiness.Cqrs;
using Para.Data.Domain;
using Para.Data.UnitOfWork;
using Para.Schema;

namespace Para.Bussiness.Command
{
    public class CustomerAddressUpdateCommandHandler : IRequestHandler<UpdateCustomerAddressCommand, ApiResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CustomerAddressUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> Handle(UpdateCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            var mapped = mapper.Map<CustomerAddressRequest, CustomerAddress>(request.Request);
            mapped.Id = request.AddressId;
            unitOfWork.CustomerAddressRepository.Update(mapped);
            await unitOfWork.Complete();
            return new ApiResponse();
        }
    }
}
