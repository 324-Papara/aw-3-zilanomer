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
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ApiResponse<CustomerResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<ApiResponse<CustomerResponse>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var mapped = mapper.Map<CustomerRequest, Customer>(request.Request);
            mapped.CustomerNumber = new Random().Next(1000000, 9999999);
            await unitOfWork.CustomerRepository.Insert(mapped);
            await unitOfWork.Complete();

            var response = mapper.Map<CustomerResponse>(mapped);
            return new ApiResponse<CustomerResponse>(response);
        }
    }
}
