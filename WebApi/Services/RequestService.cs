using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApi.Constants;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Services
{
    public class RequestService: IRequestService
    {
        private readonly IRepository<Request> _requestRepository;
        public RequestService(IRepository<Request> requestRepository)
        {
            _requestRepository = requestRepository;
        }
        public async Task<ResultResponse> AddRequest(int MobileNumber)
        {
            try
            {
                var request = await _requestRepository.FirstAsync(MobileNumber);
                if (request == null)
                {
                    var obj = new Request(MobileNumber, DateTime.Now);
                    await _requestRepository.AddAsync(obj);
                    return new ResultResponse
                    {
                        Status = 1,
                        Message = "Request is Added"
                    };

                }
                else
                {
                    return new ResultResponse
                    {
                        Status = 2,
                        Message = "MobileNumber was added before"
                    };
                }
            }
            catch(Exception ex)
            {
                return new ResultResponse
                {
                    Status = 3,
                    Message = "Something error"
                };
            }
        }
    }
}