// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Microsoft.Extensions.Configuration;

namespace Azure.Core.Tests.Identity.Samples.DocSnippets
{
    /// <summary>
    /// Placeholder settings type used by the configuration / DI documentation snippets.
    /// </summary>
    internal class MyClientSettings : ClientSettings
    {
        public string Endpoint { get; set; }

        public ClientPipelineOptions Options { get; } = new ClientPipelineOptions();

        protected override void BindCore(IConfigurationSection section)
        {
            Endpoint = section["Endpoint"];
        }
    }
}
