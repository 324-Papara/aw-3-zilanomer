using MediatR;
using Para.Base.Response;
using Para.Bussiness.Cqrs;
using Para.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Command.Delete
{
    public class CustomerPhoneDeleteCommandHandler : IRequestHandler<DeleteCustomerPhoneCommand, ApiResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomerPhoneDeleteCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse> Handle(DeleteCustomerPhoneCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.CustomerPhoneRepository.Delete(request.PhoneId);
            await unitOfWork.Complete();
            return new ApiResponse();
        }
    }
}
