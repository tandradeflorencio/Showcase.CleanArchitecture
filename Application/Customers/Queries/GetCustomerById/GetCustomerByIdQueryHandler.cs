using Dapper;
using Showcase.CleanArchitecture.Application.Abstractions.Messaging;
using Showcase.CleanArchitecture.Domain.Exceptions;
using System.Data;

namespace Showcase.CleanArchitecture.Application.Customers.Queries.GetCustomerById
{
    internal sealed class GetCustomerByIdQueryHandler(IDbConnection dbConnection) : IQueryHandler<GetCustomerByIdQuery, CustomerResponse>
    {
        public async Task<CustomerResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            const string Query = @"Select   ""Id"",
                                            ""Name"",
                                            ""Document""
                                   From     ""Customer""
                                   Where    ""Id"" = @customerId";

            var customer = await dbConnection.QueryFirstOrDefaultAsync<CustomerResponse>(Query, new { request.CustomerId });

            if (customer is null)
            {
                throw new CustomerNotFoundException(request.CustomerId);
            }

            return customer;
        }
    }
}