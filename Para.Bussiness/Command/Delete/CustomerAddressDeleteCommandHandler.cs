using MediatR;
using Para.Base.Response;
using Para.Bussiness.Cqrs;
using Para.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Command
{
    public class CustomerAddressDeleteCommandHandler : IRequestHandler<DeleteCustomerAddressCommand, ApiResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomerAddressDeleteCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse> Handle(DeleteCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.CustomerAddressRepository.Delete(request.AddressId);
            await unitOfWork.Complete();
            return new ApiResponse();
        }
    }
}