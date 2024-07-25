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

namespace Para.Bussiness.Command.Update
{
    public class CustomerDetailUpdateCommandHandler : IRequestHandler<UpdateCustomerDetailCommand, ApiResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CustomerDetailUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<ApiResponse> Handle(UpdateCustomerDetailCommand request, CancellationToken cancellationToken)
        {
            var mapped = mapper.Map<CustomerDetailRequest, CustomerDetail>(request.Request);
            mapped.Id = request.DetailId;
            unitOfWork.CustomerDetailRepository.Update(mapped);
            await unitOfWork.Complete();
            return new ApiResponse();
        }
    }
}
