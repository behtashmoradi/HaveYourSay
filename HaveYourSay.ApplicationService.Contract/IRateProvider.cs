using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaveYourSay.ApplicationService.Contract
{
    public interface IRateProvider
    {
        IEnumerable<IObjective> GetObjectives(ISubject subject);
        void Say(ISubject subject, IObjective objective, IOpinion opinion);
        void Say(ISubject subject, IEnumerable<KeyValuePair<IObjective, IOpinion>> opinions);
        IEnumerable<KeyValuePair<IObjective, IOpinion>> Reveal(ISubject subject);
    }
}
