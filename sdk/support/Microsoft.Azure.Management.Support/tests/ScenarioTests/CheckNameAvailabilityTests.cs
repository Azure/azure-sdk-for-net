// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Microsoft.Azure.Management.Support.Tests.ScenarioTests
{
    public class CheckNameAvailabilityTests
    {
        [Fact]
        public void CheckNameAvailabilityTestNameAvailableSupportTicketResource()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MicrosoftSupportClient>())
                {
                    var checkNameInput = new Models.CheckNameAvailabilityInput
                    {
                        Name = TestUtilities.GenerateName("test")
                    };

                    var checkNameOutput = client.SupportTickets.CheckNameAvailability(checkNameInput);
                    Assert.True(checkNameOutput.NameAvailable);
                }
            }
        }

        [Fact]
        public void CheckNameAvailabilityTestNameInvalidSupportTicketResource()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MicrosoftSupportClient>())
                {
                    var checkNameInput = new Models.CheckNameAvailabilityInput
                    {
                        Name = "1111"
                    };

                    var checkNameOutput = client.SupportTickets.CheckNameAvailability(checkNameInput);
                    Assert.False(checkNameOutput.NameAvailable);
                }
            }
        }

        [Fact]
        public void CheckNameAvailabilityTestNameAvailableCommunicationResource()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MicrosoftSupportClient>())
                {
                    var checkNameInput = new Models.CheckNameAvailabilityInput
                    {
                        Name = TestUtilities.GenerateName("testcommunication")
                    };

                    var checkNameOutput = client.Communications.CheckNameAvailability("testticket", checkNameInput);
                    Assert.True(checkNameOutput.NameAvailable);
                }
            }
        }
    }
}
