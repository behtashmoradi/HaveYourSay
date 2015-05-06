using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaveYourSay.Infrastructure.Persistence.Model
{
    public class Client : TableEntity
    {
        public Client(Guid clientId, string name)
        {
            this.PartitionKey = string.Format("[{0}]", clientId);
            this.RowKey = name;
        }
    }
}
