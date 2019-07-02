// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.Pipeline;
using Azure.Identity;

namespace Azure.Core.Extensions
{
    internal class AzureClientsGlobalOptions
    {
        public Func<IServiceProvider, TokenCredential> Credential { get; set; } = _ => new DefaultAzureCredential();
        public List<Action<ClientOptions, IServiceProvider>> ConfigureOptions { get; } = new List<Action<ClientOptions, IServiceProvider>>();
    }
}