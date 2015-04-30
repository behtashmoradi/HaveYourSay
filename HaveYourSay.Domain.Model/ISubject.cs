using System;

namespace HaveYourSay.Domain.Model
{
    public interface ISubject
    {
        Guid Id { get; }
        string Name { get; }
    }
}
