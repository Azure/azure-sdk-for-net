// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Identity
{
    internal readonly struct ExtendedTokenRequestContext
    {
        public ExtendedTokenRequestContext(TokenRequestContext context, IList<string> errors = default)
        {
            Context = context;

            Errors = errors;
        }

        public TokenRequestContext Context { get; }

        public IList<string> Errors { get; }
    }
}
