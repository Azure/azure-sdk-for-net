// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Azure.Test;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Graph.RBAC.Tests
{
    public class UserTests : GraphTestBase
    {
        [Fact]
        public void CreateDeleteUserTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                //Test
                User user = CreateUser(context);
                DeleteUser(context, user.UserPrincipalName);
                //verify the user has been deleted.
                Assert.Throws<GraphErrorException>(() => { SearchUser(context, user.UserPrincipalName); });
            }
        }
    }
}

