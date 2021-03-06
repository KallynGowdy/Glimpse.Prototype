﻿using System.Collections.Generic;

namespace Glimpse.Web
{
    public interface IRequestAuthorizerProvider
    {
        IEnumerable<IRequestAuthorizer> Authorizers { get; }
    }
}