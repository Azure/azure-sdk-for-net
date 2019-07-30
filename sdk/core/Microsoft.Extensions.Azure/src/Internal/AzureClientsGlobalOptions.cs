// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using System;
using System.Collections.Generic;

namespace Microsoft.Extensions.Azure.Internal
{
    internal class AzureClientsGlobalOptions
    {
        public Func<IServiceProvider, TokenCredential> CredentialFactory { get; set; } = _ => new DefaultAzureCredential();
        public List<Action<ClientOptions, IServiceProvider>> ConfigureOptionDelegates { get; } = new List<Action<ClientOptions, IServiceProvider>>();
    }
}