﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Para.Base.Response;
using Para.Bussiness.Cqrs;
using Para.Schema;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Para.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerPhoneController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerPhoneController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ApiResponse<List<CustomerPhoneResponse>>> Get()
        {
            var operation = new GetAllCustomerPhonesQuery();
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{phoneId}")]
        public async Task<ApiResponse<CustomerPhoneResponse>> Get([FromRoute] long phoneId)
        {
            var operation = new GetCustomerPhoneByIdQuery(phoneId);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        public async Task<ApiResponse<CustomerPhoneResponse>> Post([FromBody] CustomerPhoneRequest value)
        {
            var operation = new CreateCustomerPhoneCommand(value);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPut("{phoneId}")]
        public async Task<ApiResponse> Put(long phoneId, [FromBody] CustomerPhoneRequest value)
        {
            var operation = new UpdateCustomerPhoneCommand(phoneId, value);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{phoneId}")]
        public async Task<ApiResponse> Delete(long phoneId)
        {
            var operation = new DeleteCustomerPhoneCommand(phoneId);
            var result = await mediator.Send(operation);
            return result;
        }
    }
}