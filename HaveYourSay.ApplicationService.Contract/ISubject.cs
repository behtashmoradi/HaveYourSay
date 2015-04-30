using System;
using System.Collections.Generic;

namespace HaveYourSay.ApplicationService.Contract
{
    public interface ISubject
    {
        Guid Id { get; }
        string Name { get; }
    }
}
