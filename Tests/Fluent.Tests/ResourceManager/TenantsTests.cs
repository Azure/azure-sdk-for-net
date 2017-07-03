// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Fluent.Tests.ResourceManager
{
    public class Tenants
    {

        [Fact]
        public void CanListTenants()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var authenticated = TestHelper.Authenticate();
                var tenants = authenticated.Tenants.List();
                Assert.True(tenants.Count() > 0);
            }
        }
    }
}
