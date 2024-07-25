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
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, ApiResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.CustomerRepository.Delete(request.CustomerId);
            await unitOfWork.Complete();
            return new ApiResponse();
        }
    }
}
