// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Microsoft.Extensions.Configuration;

namespace Azure.Identity.Tests.ConfigurableCredentials
{
    /// <summary>
    /// Minimal ClientSettings for e2e creation tests.
    /// </summary>
    internal class E2ETestSettings : ClientSettings
    {
        public string Endpoint { get; set; }

        protected override void BindCore(IConfigurationSection section)
        {
            Endpoint = section["Endpoint"];
        }
    }
}
