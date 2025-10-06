// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Identity;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.Extensions.AspNetCore.DataProtection.Keys.Tests
{
    public class Snippets
    {
        private class StartupIdentity
        {
            #region Snippet:ProtectKeysWithAzureKeyVault
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddDataProtection()
                        .ProtectKeysWithAzureKeyVault(new Uri("<Key-ID>"), new DefaultAzureCredential());
            }
            #endregion
        }
    }
}
