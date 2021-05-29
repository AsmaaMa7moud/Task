using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Constants;

namespace WebApi.Interfaces
{
   public interface IRequestService
    {

        Task<ResultResponse> AddRequest(int MobileNumber);
    }
}
