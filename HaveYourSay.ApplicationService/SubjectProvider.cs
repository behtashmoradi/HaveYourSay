using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaveYourSay.ApplicationService.Contract;
using HaveYourSay.Domain.Model;

namespace HaveYourSay.ApplicationService
{
    public class SubjectProvider:ISubjectProvider
    {
        public ISubject GetSubject(Guid subjectId)
        {
            throw new NotImplementedException();
        }
    }
}
