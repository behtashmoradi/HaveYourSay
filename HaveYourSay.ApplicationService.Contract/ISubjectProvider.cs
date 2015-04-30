using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaveYourSay.Domain.Model;

namespace HaveYourSay.ApplicationService.Contract
{
    public interface ISubjectProvider
    {
        ISubject GetSubject(Guid subjectId);

        IEnumerable<IObjective> GetObjectives(Guid subjectId);
    }
}
