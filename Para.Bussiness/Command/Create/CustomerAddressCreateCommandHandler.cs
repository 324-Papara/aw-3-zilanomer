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
    public class CustomerAddressCreateCommandHandler : IRequestHandler<CreateCustomerAddressCommand, ApiResponse<CustomerAddressResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CustomerAddressCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<CustomerAddressResponse>> Handle(CreateCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            var mapped = mapper.Map<CustomerAddressRequest, CustomerAddress>(request.Request);
            await unitOfWork.CustomerAddressRepository.Insert(mapped);
            await unitOfWork.Complete();

            var response = mapper.Map<CustomerAddressResponse>(mapped);
            return new ApiResponse<CustomerAddressResponse>(response);
        }
    }
}