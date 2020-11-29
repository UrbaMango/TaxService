using LiteDB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxService.LiteDB
{
    public interface ILiteDbContext
    {
        LiteDatabase Database { get; }
    }
}
