using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doodle.Infrastructure.SharedModels;

namespace Customer.Api.Interfaces
{
    public interface ILeadRepo 
    {
        Task<dynamic> ContactbasedOnLead(ContactAndLogs input);
        Task<List<CommonModel>> GetCurrentStatusValue(int? userId);
        Task<List<CommonModel>> GetLeadSourceValue(int? userId);

        Task<dynamic> GetCommunicationLogs(int? userId = null);
    }
}
