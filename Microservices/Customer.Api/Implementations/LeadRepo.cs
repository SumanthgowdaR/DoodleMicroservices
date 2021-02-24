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
    public class LeadRepo : ILeadRepo
    {
        public readonly IUnitOfWork _uom;
        public LeadRepo(IUnitOfWork uom)
        {
            _uom = uom;
        }
        public async Task<dynamic> ContactbasedOnLead(ContactAndLogs input)
        {

            //save details to communication logs
            var details = new CommunicationLogs()
            {
                Id = input.LogId,
                LeadId = input.LeadId,
                CommunicationDate = DateTime.Now.ToString("dd-MM-yyyy") ,
                CommunicationMode = input.CommunicationMode,
                Status = input.Status,
            };


            await _uom.commLogs.AddAsync(details);

            //save details to Leads table

            var checkUserExist = _uom.LeadTable.GetAll().Any(x => x.Id == input.LeadId && x.ContactDetail == input.ContactDetail);


            
            if (checkUserExist)
            {
                var cd = _uom.LeadTable.GetAll().Single(x => x.Id == input.LeadId && x.ContactDetail == input.ContactDetail);
                
                    cd.CurrentStatus = input.CurrentStatus;
                    _uom.LeadTable.UpdateLeadTable(cd);
                    

            }
            else
            {
                var leadDetails = new LeadTable()
                {
                    Id = input.LeadId,
                    ContactDetail = input.ContactDetail,
                    CommunicationMode = input.CommunicationMode,
                    LeadSource = input.LeadSource,
                    CurrentStatus = input.Status,
                    LeadAmountRequired = input.Loan
                };

                await _uom.LeadTable.AddAsync(leadDetails);
            }



            var result = await _uom.CommitAsync();

            //if success get the user details to ui


            if (result > 0)
            {
               return await _uom.LeadTable.GetCustomerAllDetails(input);
            }
            else
            {
                return null;
            }
           
        }

        public async Task<dynamic> GetCommunicationLogs(int? userId = null)
        {
            var comlog =  _uom.commLogs.GetAll();
            if (userId != null)
            {

                var contacts = _uom.commLogs.GetAll();
                var res = (from c in contacts
                           join l in comlog on c.LeadId equals l.Id
                           where c.Id == userId
                           select l).ToList();
                return res;
            }
            else
            {
                return comlog.ToList();
            }
        }

        public async Task<List<CommonModel>> GetCurrentStatusValue(int? userId)
        {
            var res = _uom.csv.GetAll().Select(x => new CommonModel
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();

            if (userId != null)
            {
                //get from contact details
                return res.Where(x => x.Id == userId).ToList();
            }
            else
            {
                return res.ToList();
            }
            
        }

        public async Task<List<CommonModel>> GetLeadSourceValue(int? userId)
        {
            var res = _uom.Lead.GetAll().Select(x => new CommonModel
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();

            if (userId != null)
            {
                //get from contact details
                return res.Where(x => x.Id == userId).ToList();
            }
            else
            {
                return res.ToList();
            }
        }
    }
}
