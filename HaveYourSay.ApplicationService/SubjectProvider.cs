using System;
using System.Collections.Generic;
using HaveYourSay.ApplicationService.Contract;
using HaveYourSay.Domain.Model;

namespace HaveYourSay.ApplicationService
{
    public class SubjectProvider : ISubjectProvider
    {
        public ISubject GetSubject(Guid subjectId)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<IObjective> GetObjectives(Guid subjectId)
        {
            throw new NotImplementedException();
        }
    }
}
