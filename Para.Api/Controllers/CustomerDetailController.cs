using MediatR;
using Microsoft.AspNetCore.Mvc;
using Para.Base.Response;
using Para.Bussiness.Cqrs;
using Para.Schema;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Para.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/CustomerDetail
        [HttpGet]
        public async Task<ApiResponse<List<CustomerDetailResponse>>> Get()
        {
            var operation = new GetAllCustomerDetailsQuery();
            var result = await _mediator.Send(operation);
            return result;
        }

        // GET: api/CustomerDetail/{detailId}
        [HttpGet("{detailId}")]
        public async Task<ApiResponse<CustomerDetailResponse>> Get([FromRoute] long detailId)
        {
            var operation = new GetCustomerDetailByIdQuery(detailId);
            var result = await _mediator.Send(operation);
            return result;
        }

        // GET: api/CustomerDetail/search
        [HttpGet("search")]
        public async Task<ApiResponse<List<CustomerDetailResponse>>> GetByParameters([FromQuery] long customerId, [FromQuery] string fatherName, [FromQuery] string motherName)
        {
            var operation = new GetCustomerDetailByParametersQuery(customerId, fatherName, motherName);
            var result = await _mediator.Send(operation);
            return result;
        }

        // POST: api/CustomerDetail
        [HttpPost]
        public async Task<ApiResponse<CustomerDetailResponse>> Post([FromBody] CustomerDetailRequest value)
        {
            var operation = new CreateCustomerDetailCommand(value);
            var result = await _mediator.Send(operation);
            return result;
        }

        // PUT: api/CustomerDetail/{detailId}
        [HttpPut("{detailId}")]
        public async Task<ApiResponse> Put(long detailId, [FromBody] CustomerDetailRequest value)
        {
            var operation = new UpdateCustomerDetailCommand(detailId, value);
            var result = await _mediator.Send(operation);
            return result;
        }

        // DELETE: api/CustomerDetail/{detailId}
        [HttpDelete("{detailId}")]
        public async Task<ApiResponse> Delete(long detailId)
        {
            var operation = new DeleteCustomerDetailCommand(detailId);
            var result = await _mediator.Send(operation);
            return result;
        }
    }
}
