// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.EventGrid;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using EventGrid.Tests.TestHelper;
using Xunit;
using System.Threading;

namespace EventGrid.Tests.ScenarioTests
{
    public partial class ScenarioTests
    {
        [Fact]
        public void SystemTopicEventSubscriptionCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                this.InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                string resourcegroup = "testtobedeleted";
                var systemtopicname = TestUtilities.GenerateName(EventGridManagementHelper.SystemTopicPrefix);
                var eventSubscriptionName = TestUtilities.GenerateName(EventGridManagementHelper.EventSubscriptionPrefix);

                // Create system topic 
                var originaltagsdictionary = new Dictionary<string, string>()
                        {
                            {"originaltag1", "originalvalue1"},
                            {"originaltag2", "originalvalue2"}
                        };

                SystemTopic systemtopic = new SystemTopic()
                {
                    Location = location,
                    Tags = originaltagsdictionary,
                    TopicType = "microsoft.storage.storageaccounts",
                    Source = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/testtobedeleted/providers/microsoft.storage/storageaccounts/testtrackedsourcev2",
                };

                try
                {

                    var createsystemtopicresponse = this.EventGridManagementClient.SystemTopics.CreateOrUpdateAsync(resourcegroup, systemtopicname, systemtopic).Result;

                    Assert.NotNull(createsystemtopicresponse);
                    Assert.Equal(createsystemtopicresponse.Name, systemtopicname);

                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                    // get the created systemtopic
                    var getsystemtopicresponse = this.EventGridManagementClient.SystemTopics.Get(resourcegroup, systemtopicname);
                    if (string.Compare(getsystemtopicresponse.ProvisioningState, "succeeded", true) != 0)
                    {
                        TestUtilities.Wait(TimeSpan.FromSeconds(5));
                    }

                    getsystemtopicresponse = this.EventGridManagementClient.SystemTopics.Get(resourcegroup, systemtopicname);
                    Assert.NotNull(getsystemtopicresponse);
                    Assert.Equal("succeeded", getsystemtopicresponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                    Assert.Equal(location, getsystemtopicresponse.Location, StringComparer.CurrentCultureIgnoreCase);

                    // Create Event Subscription to system topic    

                    string scope = $"/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/{resourcegroup}/providers/Microsoft.EventGrid/topics/{systemtopicname}";

                    EventSubscription eventSubscription = new EventSubscription()
                    {
                        Destination = new WebHookEventSubscriptionDestination()
                        {
                            EndpointUrl = AzureFunctionEndpointUrl
                        },
                        Filter = new EventSubscriptionFilter()
                        {
                            IncludedEventTypes = null,
                            IsSubjectCaseSensitive = true,
                            SubjectBeginsWith = "TestPrefix",
                            SubjectEndsWith = "TestSuffix"
                        },
                        Labels = new List<string>()
                        {
                        "TestLabel1",
                        "TestLabel2"
                        }
                    };

                    var createsystemtopiceventsubscriptionresponse = this.EventGridManagementClient.SystemTopicEventSubscriptions.CreateOrUpdateWithHttpMessagesAsync(resourcegroup, systemtopicname, eventSubscriptionName, eventSubscription);
                    createsystemtopiceventsubscriptionresponse.Wait();
                    Assert.NotNull(createsystemtopiceventsubscriptionresponse);

                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                    // get the created systemtopiceventsubscription
                    var getsystemtopiceventsubscriptionresponse = this.EventGridManagementClient.SystemTopicEventSubscriptions.Get(resourcegroup, systemtopicname, eventSubscriptionName);
                    if (string.Compare(getsystemtopiceventsubscriptionresponse.ProvisioningState, "succeeded", true) != 0)
                    {
                        TestUtilities.Wait(TimeSpan.FromSeconds(5));
                    }

                    Assert.Equal("succeeded", getsystemtopicresponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                    Assert.Equal(location, getsystemtopicresponse.Location, StringComparer.CurrentCultureIgnoreCase);

                    // list all systemtopiceventsubscriptions and check previously created event subscription is there
                    var listsystemtopiceventsubscriptionresponse = this.EventGridManagementClient.SystemTopicEventSubscriptions.ListBySystemTopic(resourcegroup, systemtopicname);
                    Assert.NotNull(listsystemtopiceventsubscriptionresponse);
                    Assert.True(listsystemtopiceventsubscriptionresponse.Count() >= 1);

                    //Assert.True(listsystemtopiceventsubscriptionresponse.FirstOrDefault().Name== eventSubscriptionName);
                    var doesEventSubscriptionExist = listsystemtopiceventsubscriptionresponse.Any(ns => ns.Name.Equals(eventSubscriptionName));
                    Assert.True(doesEventSubscriptionExist);

                    // delete Event Subscription
                    this.EventGridManagementClient.SystemTopicEventSubscriptions.DeleteAsync(resourcegroup, systemtopicname, eventSubscriptionName).Wait();
                    listsystemtopiceventsubscriptionresponse = this.EventGridManagementClient.SystemTopicEventSubscriptions.ListBySystemTopic(resourcegroup, systemtopicname);
                    doesEventSubscriptionExist = listsystemtopiceventsubscriptionresponse.Any(ns => ns.Name.Equals(eventSubscriptionName));
                    Assert.False(doesEventSubscriptionExist);
                    // delete systemtopic
                    this.EventGridManagementClient.SystemTopics.DeleteAsync(resourcegroup, systemtopicname).Wait();


                }
                finally
                {
                    var listsystemtopicresponse = this.EventGridManagementClient.SystemTopics.ListByResourceGroup(resourcegroup);
                    var doessystemtopicexist = listsystemtopicresponse.Any(ns => ns.Name.Equals(systemtopicname));
                    // delete Event Subscription
                    IPage<EventSubscription> listsystemtopiceventsubscriptionresponse = null;

                    if (doessystemtopicexist)
                    {
                        listsystemtopiceventsubscriptionresponse = this.EventGridManagementClient.SystemTopicEventSubscriptions.ListBySystemTopic(resourcegroup, systemtopicname);
                        var doesEventSubscriptionExist = listsystemtopiceventsubscriptionresponse.Any(ns => ns.Name.Equals(eventSubscriptionName));
                        if (doesEventSubscriptionExist)
                        {
                            this.EventGridManagementClient.SystemTopicEventSubscriptions.DeleteAsync(resourcegroup, systemtopicname, eventSubscriptionName).Wait();
                        }
                    }
                    // delete systemtopic
                    if (doessystemtopicexist)
                    {
                        this.EventGridManagementClient.SystemTopics.DeleteAsync(resourcegroup, systemtopicname).Wait();
                    }

                }
            }
        }
    }
}