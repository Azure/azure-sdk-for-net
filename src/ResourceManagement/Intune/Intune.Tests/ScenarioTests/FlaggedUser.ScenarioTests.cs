// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Azure.Management.Intune.Tests.Helpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using Microsoft.Azure.Test.HttpRecorder;

namespace Microsoft.Azure.Management.Intune.Tests.ScenarioTests
{
    [Collection("Intune Tests")]
    public class FlaggedUserScenarioTests : TestBase
    {
        /// <summary>
        /// Test class for Flagged user operations.
        /// </summary>
        static FlaggedUserScenarioTests()
        {
            IntuneClientHelper.InitializeEnvironment();
        }

        /// <summary>
        /// Verifies that Get default statuses works
        /// </summary>
        [Fact]
        public void ShouldGetDefaultStatuses()
        {
            using (MockContext context = MockContext.Start("Microsoft.Azure.Management.Intune.Tests.ScenarioTests.FlaggedUserScenarioTests"))
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);
                var defaultStatus = client.GetMAMStatuses(IntuneClientHelper.AsuHostName);
                Assert.Equal("default", defaultStatus.Name);
                Assert.Equal("complete", defaultStatus.Status);
                Assert.Equal("Microsoft.Intune/locations/statuses", defaultStatus.Type);                
            }
        }

        /// <summary>
        /// Verifies that Get flagged users works
        /// </summary>
        [Fact]
        public void ShouldGetFlaggedUsers()
        {
            using (MockContext context = MockContext.Start("Microsoft.Azure.Management.Intune.Tests.ScenarioTests.FlaggedUserScenarioTests"))
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);
                var flaggedUsers = client.GetMAMFlaggedUsers(IntuneClientHelper.AsuHostName).ToList();
                
                Assert.True(flaggedUsers.Count > 0, "Zero flagged users");
                Assert.Equal("Microsoft.Intune/locations/flaggedUsers", flaggedUsers[0].Type);
                Assert.True(flaggedUsers[0].ErrorCount > 0, "Zero errors for the flagged user");
                Assert.NotNull(flaggedUsers[0].FriendlyName);
                Assert.NotNull(flaggedUsers[0].Id);
                Assert.NotNull(flaggedUsers[0].Name);
            }
        }

        /// <summary>
        /// Verifies that Get flagged user by name works
        /// </summary>
        [Fact]
        public void ShouldGetFlaggedUserByName()
        {
            using (MockContext context = MockContext.Start("Microsoft.Azure.Management.Intune.Tests.ScenarioTests.FlaggedUserScenarioTests"))
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);
                var flaggedUsers = client.GetMAMFlaggedUsers(IntuneClientHelper.AsuHostName).ToList();

                Assert.True(flaggedUsers.Count > 0, "Zero flagged users");
                var flaggedUser = client.GetMAMFlaggedUserByName(IntuneClientHelper.AsuHostName, flaggedUsers[0].Name);
                Assert.True(flaggedUser.ErrorCount > 0, "Zero errors for the flagged user");
                Assert.NotNull(flaggedUser.FriendlyName);
                Assert.NotNull(flaggedUser.Id);
                Assert.NotNull(flaggedUser.Name);
            }
        }
        /// <summary>
        /// Verifies that Get flagged enrolled Apps works
        /// </summary>
        [Fact]
        public void ShouldGetFlaggedEnrolledApps()
        {
            using (MockContext context = MockContext.Start("Microsoft.Azure.Management.Intune.Tests.ScenarioTests.FlaggedUserScenarioTests"))
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);
                var flaggedUsers = client.GetMAMFlaggedUsers(IntuneClientHelper.AsuHostName).ToList();
                Assert.True(flaggedUsers.Count > 0, "Zero flagged users");

                var flaggedEnrolledApps = client.GetMAMUserFlaggedEnrolledApps(IntuneClientHelper.AsuHostName, flaggedUsers[0].Name).ToList();
                Assert.True(flaggedEnrolledApps.Count > 0, "Zero flagged enrolled Apps");

                Assert.Equal("Microsoft.Intune/locations/flaggedUsers/flaggedEnrolledApps", flaggedEnrolledApps[0].Type);
                Assert.NotNull(flaggedEnrolledApps[0].Name);
                Assert.NotNull(flaggedEnrolledApps[0].FriendlyName);
                Assert.NotNull(flaggedEnrolledApps[0].Platform);
                Assert.NotNull(flaggedEnrolledApps[0].Id);                
            }
        }
    }
}