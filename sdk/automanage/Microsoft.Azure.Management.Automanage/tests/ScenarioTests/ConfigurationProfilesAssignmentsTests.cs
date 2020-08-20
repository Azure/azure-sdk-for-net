// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
namespace Automanage.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Automanage.Tests.Helpers;
    using Microsoft.Azure.Management.Automanage;
    using Microsoft.Azure.Management.Automanage.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Xunit.Abstractions;

    public class ConfigurationProfilesAssignmentsTests : TestBase
    {
        private RecordedDelegatingHandler handler;

        public ConfigurationProfilesAssignmentsTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ConfigurationProfilesAssignmentsGetsExpectedProfile()
        {
            var thisType = this.GetType();
            using (MockContext context = MockContext.Start(thisType))
            {
                var automanageClient = GetAutomanagementClient(context, handler);

                var actual = automanageClient.Accounts.Get("AMVM-SubLib-017-ABP", "AMVM-SubLib-017_group");

                Assert.NotNull(actual);
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ConfigurationProfilesAssignmentsAssignsExpectedProfile()
        {
            var thisType = this.GetType();
            using (MockContext context = MockContext.Start(thisType))
            {
                var automanageClient = GetAutomanagementClient(context, handler);

                var actual = automanageClient.Accounts.Get("AMVM-SubLib-017-ABP", "AMVM-SubLib-017_group");

                Assert.NotNull(actual);
            }
        }
    }
}