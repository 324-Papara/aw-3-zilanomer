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
    public class CustomerDetailDeleteCommandHandler : IRequestHandler<DeleteCustomerDetailCommand, ApiResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomerDetailDeleteCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse> Handle(DeleteCustomerDetailCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.CustomerDetailRepository.Delete(request.DetailId);
            await unitOfWork.Complete();
            return new ApiResponse();
        }
    }
}
