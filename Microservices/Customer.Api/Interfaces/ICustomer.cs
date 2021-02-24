using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doodle.Infrastructure.SharedModels;

namespace Customer.Api.Interfaces
{
    public interface ICustomer
    {
        Task<bool> Customers(Contact input);
        Task<bool> UpdateCustomers(int userId, int leadId);
    }
}
