// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;
using Fluent.Tests.Common;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Fluent.Tests.ResourceManager
{
    public class TestProviderInterceptor
    {
        [Fact]
        public void CanAutomaticallyRegisterProvider()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var resourceManager = TestHelper.CreateResourceManager();
                var keyVaultManager = TestHelper.CreateKeyVaultManager();
                var provider = resourceManager.Providers.GetByName("Microsoft.KeyVault");
                Assert.NotNull(provider);

                string rgName = SdkContext.RandomResourceName("rg", 10);
                provider = resourceManager.Providers.Unregister(provider.Namespace);
                while (provider.RegistrationState.Equals("Unregistering"))
                {
                    TestHelper.Delay(5000);
                    provider = resourceManager.Providers.GetByName(provider.Namespace);
                }

                try
                {
                    keyVaultManager.Vaults.Define(SdkContext.RandomResourceName("kv", 10))
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rgName)
                        .WithEmptyAccessPolicy()
                        .Create();

                    provider = resourceManager.Providers.GetByName("Microsoft.KeyVault");
                    Assert.True(string.Equals(provider.RegistrationState, "Registered"));
                    IList<ProviderResourceType> resourceTypes = provider.ResourceTypes;
                    Assert.True(resourceTypes.Count > 0);
                }
                finally
                {
                    resourceManager.ResourceGroups.BeginDeleteByName(rgName);
                }
            }
        }
    }
}
