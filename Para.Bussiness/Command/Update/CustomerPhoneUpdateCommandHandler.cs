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
    public class CustomerPhoneUpdateCommandHandler : IRequestHandler<UpdateCustomerPhoneCommand, ApiResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CustomerPhoneUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> Handle(UpdateCustomerPhoneCommand request, CancellationToken cancellationToken)
        {
            var mapped = mapper.Map<CustomerPhoneRequest, CustomerPhone>(request.Request);
            mapped.Id = request.PhoneId;
            unitOfWork.CustomerPhoneRepository.Update(mapped);
            await unitOfWork.Complete();
            return new ApiResponse();
        }
    }
}
