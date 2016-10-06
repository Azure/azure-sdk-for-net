// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Xunit;
using static Microsoft.Azure.Management.Resource.Fluent.ResourceManager;

namespace Fluent.Tests.ResourceManager
{
    public class TenantsTests
    {

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CanListTenants()
        {
            var resourceManager = CreateResourceManager();
            var tenants = resourceManager.Tenants.List();
            Assert.True(tenants.Count > 0);
        }

        private IAuthenticated CreateResourceManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(@"C:\my.azureauth");
            IAuthenticated resourceManager = Microsoft.Azure.Management.Resource.Fluent.ResourceManager.Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials);
            return resourceManager;
        }
    }
}
