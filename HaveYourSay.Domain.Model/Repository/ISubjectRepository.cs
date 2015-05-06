using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaveYourSay.Domain.Model.Repository
{
    public interface ISubjectRepository
    {
        Guid CreateClient(Client client);
        Guid CreateSubscription(Guid clientId, Subscription subscription);

        Guid CreateSubject(Guid clientId, Guid subscriptionId, ISubject subject);

        void CreateObjectives(Guid clientId, Guid subscriptionId, Guid subjectId, IEnumerable<IObjective> objectives);

        IEnumerable<Subscription> GetSubscriptions(Guid clientId);
        IEnumerable<ISubject> GetSubjects(Guid clientId, Guid subscriptionId);
        IEnumerable<IObjective> GetObjectives(Guid clientId, Guid subscriptionId, Guid subjectId);
    }
}
