using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaveYourSay.ApplicationService.Contract
{
    public interface ISubjectProvider
    {
        ISubject GetSubject(Guid subjectId);
    }
}
