// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.Configuration.KeyVault.Tests
{
    internal class MyClientSettings : ClientSettings
    {
        protected override void BindCore(IConfigurationSection section)
        {
        }
    }
}
