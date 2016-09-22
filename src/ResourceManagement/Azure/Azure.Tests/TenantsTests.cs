// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static Microsoft.Azure.Management.V2.Resource.ResourceManager2;

namespace Azure.Tests
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
            IAuthenticated resourceManager = ResourceManager2.Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials);
            return resourceManager;
        }
    }
}
