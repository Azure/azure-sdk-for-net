// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Support.Models;
using Microsoft.Azure.Management.Support.Tests.Helpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Management.Support.Tests.ScenarioTests
{
    public class CommunicationTests
    {
        [Fact]
        public void CommunicationCreateTest()
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

                    var communicationDetails = CreateCommunication(client, ticketName, "test subject", "test body");

                    Assert.True(!string.IsNullOrWhiteSpace(communicationDetails.Id));
                    Assert.Equal("microsoft.support/communications", communicationDetails.Type, ignoreCase: true);
                    Assert.True(!string.IsNullOrWhiteSpace(communicationDetails.Name));
                }
            }
        }

        [Fact]
        public void CommunicationGetListTest()
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

                    var communicationDetails1 = CreateCommunication(client, ticketName, "test subject 1", "test body 1");
                    var communicationDetails2 = CreateCommunication(client, ticketName, "test subject 2", "test body 2");

                    var communications = client.Communications.List(ticketName);

                    foreach(var communication in communications)
                    {
                        Assert.True(!string.IsNullOrWhiteSpace(communication.Id));
                        Assert.Equal("microsoft.support/communications", communication.Type, ignoreCase: true);
                        Assert.True(!string.IsNullOrWhiteSpace(communication.Name));
                    }

                    communications = client.Communications.List(ticketName, 1);
                    Assert.Single(communications);
                    Assert.NotNull(communications.NextPageLink);

                    foreach (var communication in communications)
                    {
                        Assert.True(!string.IsNullOrWhiteSpace(communication.Id));
                        Assert.Equal("microsoft.support/communications", communication.Type, ignoreCase: true);
                        Assert.True(!string.IsNullOrWhiteSpace(communication.Name));
                    }
                }
            }
        }

        [Fact]
        public void CommunicationGetTest()
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

                    Console.WriteLine($"Created support ticket with id: {supportTicketDetails.SupportTicketId}");
                    Console.WriteLine($"Ticket with name: {ticketName} was created successfully. Support ticket id is {supportTicketDetails.SupportTicketId}");

                    var communicationDetails = CreateCommunication(client, ticketName, "test subject", "test body");

                    communicationDetails = client.Communications.Get(ticketName, communicationDetails.Name);

                    Assert.True(!string.IsNullOrWhiteSpace(communicationDetails.Id));
                    Assert.Equal("microsoft.support/communications", communicationDetails.Type, ignoreCase: true);
                    Assert.True(!string.IsNullOrWhiteSpace(communicationDetails.Name));
                }
            }
        }

        private static CommunicationDetails CreateCommunication(MicrosoftSupportClient client, string ticketName, string subject, string body)
        {
            var createCommunicationParameters = new CommunicationDetails
            {
                Subject = subject,
                Body = body,
                Sender = "user@contoso.com"
            };

            var communicationName = TestUtilities.GenerateName("Communication");
            Console.WriteLine($"Creating communication with name: {communicationName} for ticket {ticketName}");

            var communicationDetails = client.Communications.Create(ticketName, communicationName, createCommunicationParameters);
            return communicationDetails;
        }
    }
}
