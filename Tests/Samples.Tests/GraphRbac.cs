// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class GraphRbac : Samples.Tests.TestBase
    {
        public GraphRbac(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact(Skip = "Do not record - Can contain sensitive auth info")]
        [Trait("Samples", "GraphRbac")]
        public void ManageServicePrincipalTest()
        {

            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                RunSampleAsTest(
                    this.GetType().FullName,
                    ManageServicePrincipal.Program.RunSample);
            }
        }

        [Fact(Skip = "Do not record - Can contain sensitive auth info")]
        [Trait("Samples", "GraphRbac")]
        public void ManageServicePrincipalCredentialsTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                RunSampleAsTest(
                    this.GetType().FullName,
                    (authenticated) => ManageServicePrincipalCredentials.Program.RunSample(authenticated, AzureEnvironment.AzureGlobalCloud));
            }
        }
        
        [Fact]
        [Trait("Samples", "GraphRbac")]
        public void ManageUsersGroupsAndRolesTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                RunSampleAsTest(
                    this.GetType().FullName,
                    ManageUsersGroupsAndRoles.Program.RunSample);
            }
        }
    }
}
