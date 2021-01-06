// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

namespace Azure.Extensions.AspNetCore.DataProtection.Keys.Tests
{
    public class Snippets
    {
        public void ConfigurationHelloWorld()
        {
            #region Snippet:ConfigurationAddAzureKeyVault
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddAzureKeyVault(new Uri("<Vault URI>"), new DefaultAzureCredential());

            IConfiguration configuration = builder.Build();
            Console.WriteLine(configuration["MySecret"]);
            #endregion
        }
    }
}
