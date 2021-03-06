﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Framework.OptionsModel;

namespace Glimpse.Agent.Web
{ 
    public class DefaultRequestIgnorerContentTypeProvider : IRequestIgnorerContentTypeProvider
    {
        public DefaultRequestIgnorerContentTypeProvider(IOptions<GlimpseAgentWebOptions> optionsAccessor)
        {
            var contentTypes = optionsAccessor.Options.IgnoredContentTypes;
            ContentTypes = contentTypes.ToList();
        }

        public IReadOnlyList<string> ContentTypes { get; }
    }
}