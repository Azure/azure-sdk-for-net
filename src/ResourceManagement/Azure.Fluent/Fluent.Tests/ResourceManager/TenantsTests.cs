// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Xunit;

namespace Fluent.Tests.ResourceManager
{
    public class TenantsTests
    {

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CanListTenants()
        {
            var authenticated = TestHelper.Authenticate();
            var tenants = authenticated.Tenants.List();
            Assert.True(tenants.Count > 0);
        }
    }
}
