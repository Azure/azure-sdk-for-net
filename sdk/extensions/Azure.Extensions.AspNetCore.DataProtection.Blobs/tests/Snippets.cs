// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Identity;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.Extensions.AspNetCore.DataProtection.Blobs.Tests
{
    public class Snippets
    {
        private class StartupIdentity
        {
            #region Snippet:IdentityAuth
            public void ConfigureServices(IServiceCollection services)
            {
                services
                    .AddDataProtection()
                    .PersistKeysToAzureBlobStorage(new Uri("<full-blob-URI>"), new DefaultAzureCredential());
            }
            #endregion
        }

        private class StartupConnectionString
        {
            #region Snippet:ConnectionString
            public void ConfigureServices(IServiceCollection services)
            {
                services
                    .AddDataProtection()
                    .PersistKeysToAzureBlobStorage("<connection string>", "<container name>", "<blob name>");
            }
            #endregion
        }
    }
}