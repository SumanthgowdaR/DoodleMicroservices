using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Api.Interfaces;
using Doodle.Dal.UnitOfWork;
using Doodle.Infrastructure.SharedModels;
using Doodle.SqlEntities.Entities;

namespace Customer.Api.Implementations
{
    public class CustomerRepo : ICustomer
    {
        public readonly IUnitOfWork _uom;
        public CustomerRepo(IUnitOfWork uom)
        {
            _uom = uom;
        }

        public async Task<bool> Customers(Contact input)
        {
            var details = new Contactdetails()
            {
                Id = input.Id,
                ContactName = input.ContactName,
                ContactNumber = input.ContactNumber,
                Dob = input.Dob,
                Email = input.Email,
                Gender = input.Gender
            };            


            return await _uom.Customer.SaveCustomers(details);
            
        }

        public async Task<bool> UpdateCustomers(int userId, int leadId)
        {
            var cd =  _uom.Customer.GetAll().Single(x => x.Id == userId);
            if(cd.LeadId == null)
            {
                cd.LeadId = leadId;
                _uom.Customer.UpdateLeadTable(cd);
            }
            var result = await _uom.CommitAsync();
            return result > 0 ? true : false;
        }
    }
}
