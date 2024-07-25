using MediatR;
using Para.Base.Response;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Cqrs
{
    
        public record CreateCustomerAddressCommand(CustomerAddressRequest Request) : IRequest<ApiResponse<CustomerAddressResponse>>;
        public record UpdateCustomerAddressCommand(long AddressId, CustomerAddressRequest Request) : IRequest<ApiResponse>;
        public record DeleteCustomerAddressCommand(long AddressId) : IRequest<ApiResponse>;
        public record GetAllCustomerAddressesQuery() : IRequest<ApiResponse<List<CustomerAddressResponse>>>;
        public record GetCustomerAddressByIdQuery(long AddressId) : IRequest<ApiResponse<CustomerAddressResponse>>;
        public record GetCustomerAddressByParametersQuery(long CustomerId, string Country, string City) : IRequest<ApiResponse<List<CustomerAddressResponse>>>;


    
}
