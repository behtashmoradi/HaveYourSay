using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaveYourSay.Domain.Model;

namespace HaveYourSay.Repository
{
    public interface ISubjectRepository
    {
        ISubject GetSubject(Guid subjectId);
        IEnumerable<IObjective> GetObjectives(Guid subjectId);
    }
}
