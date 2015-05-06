using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaveYourSay.Domain.Model
{
    public class Subscription
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
    }
}
