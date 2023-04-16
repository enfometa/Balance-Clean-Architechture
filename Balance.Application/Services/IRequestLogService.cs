using Balance.Application.Dtos;
using Balance.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Application.Services
{
    public interface IRequestLogService
    {
        Task<int> Log(RequestLog log);
    }
}
