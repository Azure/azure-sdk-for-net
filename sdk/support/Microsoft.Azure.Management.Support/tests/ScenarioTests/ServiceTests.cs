// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Management.Support.Tests.ScenarioTests
{
    public class ServiceTests
    {
        [Fact]
        public void ServiceListTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MicrosoftSupportClient>())
                {
                    var serviceList = client.Services.List();
                    Assert.True(serviceList.Count() > 0);
                }
            }
        }

        [Fact]
        public void GetServiceTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MicrosoftSupportClient>())
                {
                    var serviceList = client.Services.List();
                    var service = client.Services.Get(serviceList.First().Name);
                    Assert.True(!string.IsNullOrWhiteSpace(service.Id));
                    Assert.Equal("microsoft.support/services", service.Type, ignoreCase: true);
                    Assert.True(!string.IsNullOrWhiteSpace(service.Name));
                    Assert.True(!string.IsNullOrWhiteSpace(service.DisplayName));
                }
            }
        }
    }
}
