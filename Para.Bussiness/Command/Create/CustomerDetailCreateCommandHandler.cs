using AutoMapper;
using MediatR;
using Para.Base.Response;
using Para.Bussiness.Cqrs;
using Para.Data.Domain;
using Para.Data.UnitOfWork;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Command.Create
{
    public class CustomerDetailCreateCommandHandler : IRequestHandler<CreateCustomerDetailCommand, ApiResponse<CustomerDetailResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CustomerDetailCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<ApiResponse<CustomerDetailResponse>> Handle(CreateCustomerDetailCommand request, CancellationToken cancellationToken)
        {
            var mapped = mapper.Map<CustomerDetailRequest, CustomerDetail>(request.Request);
            await unitOfWork.CustomerDetailRepository.Insert(mapped);
            await unitOfWork.Complete();

            var response = mapper.Map<CustomerDetailResponse>(mapped);
            return new ApiResponse<CustomerDetailResponse>(response);
        }
    }
}
