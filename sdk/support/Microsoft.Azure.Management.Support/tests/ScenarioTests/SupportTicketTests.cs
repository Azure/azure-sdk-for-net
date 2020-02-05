// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Support.Tests.Helpers;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Management.Support.Tests.ScenarioTests
{
    public class SupportTicketTests
    {
        [Fact]
        public void SupportTicketCreateTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MicrosoftSupportClient>())
                {
                    var servicesList = client.Services.List();
                    var service = servicesList.Where(x => x.DisplayName.ToLower().Contains("billing")).First();

                    if (service == null)
                    {
                        service = servicesList.First();
                    }

                    var problemClassification = client.ProblemClassifications.List(service.Name).First();

                    var createSupportTicketParams = Util.CreateSupportTicketParametersObject(service.Id, problemClassification.Id);

                    var ticketName = TestUtilities.GenerateName("SdkNetTest");
                    Console.WriteLine($"Creating ticket with name: {ticketName}");

                    var supportTicketDetails = client.SupportTickets.Create(ticketName, createSupportTicketParams);
                    Console.WriteLine($"Ticket with name: {ticketName} was created successfully. Support ticket id is {supportTicketDetails.SupportTicketId}");

                    Assert.True(!string.IsNullOrWhiteSpace(supportTicketDetails.Id));
                    Assert.Equal("microsoft.support/supportTickets", supportTicketDetails.Type, ignoreCase: true);
                    Assert.True(!string.IsNullOrWhiteSpace(supportTicketDetails.Name));
                }
            }
        }

        [Fact]
        public void SupportTicketUpdateTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MicrosoftSupportClient>())
                {
                    var servicesList = client.Services.List();
                    var service = servicesList.Where(x => x.DisplayName.ToLower().Contains("billing")).First();

                    if (service == null)
                    {
                        service = servicesList.First();
                    }

                    var problemClassification = client.ProblemClassifications.List(service.Name).First();
                    var createSupportTicketParams = Util.CreateSupportTicketParametersObject(service.Id, problemClassification.Id);

                    var ticketName = TestUtilities.GenerateName("SdkNetTest");
                    Console.WriteLine($"Creating ticket with name: {ticketName}");

                    var supportTicketDetails = client.SupportTickets.Create(ticketName, createSupportTicketParams);
                    Console.WriteLine($"Ticket with name: {ticketName} was created successfully. Support ticket id is {supportTicketDetails.SupportTicketId}");

                    var updateSupportTicketParameters = new Models.UpdateSupportTicket
                    {
                        ContactDetails = new Models.UpdateContactProfile
                        {
                            FirstName = "first name updated",
                            LastName = "last name updated"
                        }
                    };

                    supportTicketDetails = client.SupportTickets.Update(supportTicketDetails.Name, updateSupportTicketParameters);
                    Assert.Equal("first name updated", supportTicketDetails.ContactDetails.FirstName, ignoreCase: true);
                    Assert.Equal("last name updated", supportTicketDetails.ContactDetails.LastName, ignoreCase: true);
                }
            }
        }

        [Fact]
        public void SupportTicketListTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                IPage<Models.SupportTicketDetails> supportTicketList = null;
                using (var client = context.GetServiceClient<MicrosoftSupportClient>())
                {
                    supportTicketList = client.SupportTickets.List();
                    Assert.True(supportTicketList.Count() > 0);
                }

                if (!string.IsNullOrWhiteSpace(supportTicketList.NextPageLink))
                {
                    using (var client = context.GetServiceClient<MicrosoftSupportClient>())
                    {
                        supportTicketList = client.SupportTickets.ListNext(supportTicketList.NextPageLink);
                        Assert.True(supportTicketList.Count() > 0);
                    }
                }
            }
        }

        [Fact]
        public void SupportTicketListFilterByStatusTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                IPage<Models.SupportTicketDetails> supportTicketList = null;
                using (var client = context.GetServiceClient<MicrosoftSupportClient>())
                {
                    supportTicketList = client.SupportTickets.List(filter: "Status eq 'Closed'");

                    foreach (var supportTicket in supportTicketList)
                    {
                        Assert.Equal("closed", supportTicket.Status, ignoreCase: true);
                    }
                }

                if (!string.IsNullOrWhiteSpace(supportTicketList.NextPageLink))
                {
                    using (var client = context.GetServiceClient<MicrosoftSupportClient>())
                    {
                        supportTicketList = client.SupportTickets.ListNext(supportTicketList.NextPageLink);

                        foreach (var supportTicket in supportTicketList)
                        {
                            Assert.Equal("closed", supportTicket.Status, ignoreCase: true);
                        }
                    }
                }
            }
        }

        [Fact]
        public void SupportTicketListTopCountTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                IPage<Models.SupportTicketDetails> supportTicketList = null;
                using (var client = context.GetServiceClient<MicrosoftSupportClient>())
                {
                    supportTicketList = client.SupportTickets.List(top: 1);
                    Assert.True(supportTicketList.Count() == 1);
                }

                if (!string.IsNullOrWhiteSpace(supportTicketList.NextPageLink))
                {
                    using (var client = context.GetServiceClient<MicrosoftSupportClient>())
                    {
                        supportTicketList = client.SupportTickets.ListNext(supportTicketList.NextPageLink);
                        Assert.True(supportTicketList.Count() == 1);
                    }
                }
            }
        }
        
        [Fact]
        public void SupportTicketGetTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                IPage<Models.SupportTicketDetails> supportTicketList = null;
                using (var client = context.GetServiceClient<MicrosoftSupportClient>())
                {
                    supportTicketList = client.SupportTickets.List();
                    var supportTicket = client.SupportTickets.Get(supportTicketList.First().Name);
                    Assert.True(!string.IsNullOrWhiteSpace(supportTicket.Id));
                    Assert.Equal("microsoft.support/supporttickets", supportTicket.Type, ignoreCase: true);
                    Assert.True(!string.IsNullOrWhiteSpace(supportTicket.Name));
                }
            }
        }
    }
}
