// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    public class DefaultAzureCredential : ChainedTokenCredential
    {
        public DefaultAzureCredential()
            :this(null)
        {

        }

        public DefaultAzureCredential(IdentityClientOptions options)
            : base(new EnvironmentCredential(options), new ManagedIdentityCredential(options: options))
        {

        }
    }
}
