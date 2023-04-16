using AutoMapper;
using Balance.Application.Dtos;
using Balance.Core.Constants;
using Balance.Core.Entities;
using Balance.Core.Exceptions;
using Balance.Core.Interfaces.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Application.Services
{
    public class RequestLogService : IRequestLogService
    {
        private readonly IRequestLogRepo _requestLogRepo;

        public RequestLogService(IRequestLogRepo requestLogRepo) 
        {
            _requestLogRepo = requestLogRepo;
        }

        public async Task<int> Log(RequestLog log)
        {
            return await _requestLogRepo.InsertAsync(log);
        }
    }
}
