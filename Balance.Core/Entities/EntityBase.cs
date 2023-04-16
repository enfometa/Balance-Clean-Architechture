using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Core.Entities
{
    public class EntityBase
    {
        [Computed]
        public int Id { get; set; }
    }
}
