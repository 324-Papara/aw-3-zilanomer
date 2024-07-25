﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Para.Base.Response;
using Para.Bussiness.Cqrs;
using Para.Data.Domain;
using Para.Schema;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Para.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddressController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerAddressController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ApiResponse<List<CustomerAddressResponse>>> Get()
        {
            var operation = new GetAllCustomerAddressesQuery();
            var result = await mediator.Send(operation);
            return result;
        }


        [HttpPost]
        public async Task<ApiResponse<CustomerAddressResponse>> Post([FromBody] CustomerAddressRequest value)
        {
            var operation = new CreateCustomerAddressCommand(value);
            var result = await mediator.Send(operation);
            return result;
        }


        [HttpGet("{addressId}")]
        public async Task<ApiResponse<CustomerAddressResponse>> Get([FromRoute] long addressId)
        {
            var operation = new GetCustomerAddressByIdQuery(addressId);
            var result = await mediator.Send(operation);
            return result;
        }


        [HttpPut("{addressId}")]
        public async Task<ApiResponse> Put([FromRoute] long addressId, [FromBody] CustomerAddressRequest value)
        {
            var operation = new UpdateCustomerAddressCommand(addressId, value);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{addressId}")]
        public async Task<ApiResponse> Delete([FromRoute] long addressId)
        {
            var operation = new DeleteCustomerAddressCommand(addressId);
            var result = await mediator.Send(operation);
            return result;
        }
    }
}