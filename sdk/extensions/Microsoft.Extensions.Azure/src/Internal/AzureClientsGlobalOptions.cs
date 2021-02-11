// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.Azure
{
    internal class AzureClientsGlobalOptions
    {
        public Func<IServiceProvider, TokenCredential> CredentialFactory { get; set; } = _ => new DefaultAzureCredential();
        public List<Action<ClientOptions, IServiceProvider>> ConfigureOptionDelegates { get; } = new List<Action<ClientOptions, IServiceProvider>>();
        public Func<IServiceProvider, IConfiguration> ConfigurationRootResolver { get; set; }
    }
}