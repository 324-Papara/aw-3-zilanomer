using AutoMapper;
using MediatR;
using Para.Base.Response;
using Para.Bussiness.Cqrs;
using Para.Data.Domain;
using Para.Data.UnitOfWork;
using Para.Schema;

namespace Para.Bussiness.Command
{
    public class CustomerPhoneCreateCommandHandler : IRequestHandler<CreateCustomerPhoneCommand, ApiResponse<CustomerPhoneResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CustomerPhoneCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<CustomerPhoneResponse>> Handle(CreateCustomerPhoneCommand request, CancellationToken cancellationToken)
        {
            var mapped = mapper.Map<CustomerPhoneRequest, CustomerPhone>(request.Request);
            await unitOfWork.CustomerPhoneRepository.Insert(mapped);
            await unitOfWork.Complete();

            var response = mapper.Map<CustomerPhoneResponse>(mapped);
            return new ApiResponse<CustomerPhoneResponse>(response);
        }
    }
}
