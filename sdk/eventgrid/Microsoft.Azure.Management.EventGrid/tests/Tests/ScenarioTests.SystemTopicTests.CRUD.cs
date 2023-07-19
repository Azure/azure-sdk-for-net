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

namespace EventGrid.Tests.ScenarioTests
{
    public partial class ScenarioTests
    {
        [Fact]
        public void systemtopiccreategetupdatedelete()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                this.InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                string resourcegroup = "testtobedeleted";
                var systemtopicname = TestUtilities.GenerateName(EventGridManagementHelper.SystemTopicPrefix);

                //        // temporarily commenting this out as this is not yet enabled for the new api version
                // var operationsresponse = this.eventgridmanagementclient.operations.list();

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

                    // get all systemtopics created within a resourcegroup
                    IPage<SystemTopic> systemtopicsinresourcegrouppage = this.EventGridManagementClient.SystemTopics.ListByResourceGroupAsync(resourcegroup).Result;
                    var systemtopicsinresourcegrouplist = new List<SystemTopic>();
                    if (systemtopicsinresourcegrouppage.Any())
                    {
                        systemtopicsinresourcegrouplist.AddRange(systemtopicsinresourcegrouppage);
                        var nextlink = systemtopicsinresourcegrouppage.NextPageLink;
                        while (nextlink != null)
                        {
                            systemtopicsinresourcegrouppage = this.EventGridManagementClient.SystemTopics.ListByResourceGroupNextAsync(nextlink).Result;
                            systemtopicsinresourcegrouplist.AddRange(systemtopicsinresourcegrouppage);
                            nextlink = systemtopicsinresourcegrouppage.NextPageLink;
                        }
                    }

                    Assert.NotNull(systemtopicsinresourcegrouplist);
                    Assert.True(systemtopicsinresourcegrouplist.Count() >= 1);
                    Assert.Contains(systemtopicsinresourcegrouplist, t => t.Name == systemtopicname);
                    Assert.True(systemtopicsinresourcegrouplist.All(ns => ns.Id.Contains(resourcegroup)));

                    IPage<SystemTopic> systemtopicsinresourcegrouppagewithtop = this.EventGridManagementClient.SystemTopics.ListByResourceGroupAsync(resourcegroup, null, 5).Result;
                    var systemtopicsinresourcegrouplistwithtop = new List<SystemTopic>();
                    if (systemtopicsinresourcegrouppagewithtop.Any())
                    {
                        systemtopicsinresourcegrouplistwithtop.AddRange(systemtopicsinresourcegrouppagewithtop);
                        var nextlink = systemtopicsinresourcegrouppagewithtop.NextPageLink;
                        while (nextlink != null)
                        {
                            systemtopicsinresourcegrouppagewithtop = this.EventGridManagementClient.SystemTopics.ListByResourceGroupNextAsync(nextlink).Result;
                            systemtopicsinresourcegrouplistwithtop.AddRange(systemtopicsinresourcegrouppagewithtop);
                            nextlink = systemtopicsinresourcegrouppagewithtop.NextPageLink;
                        }
                    }

                    Assert.NotNull(systemtopicsinresourcegrouplistwithtop);
                    Assert.True(systemtopicsinresourcegrouplistwithtop.Count() >= 1);
                    Assert.Contains(systemtopicsinresourcegrouplistwithtop, t => t.Name == systemtopicname);
                    Assert.True(systemtopicsinresourcegrouplistwithtop.All(ns => ns.Id.Contains(resourcegroup)));

                    // get all systemtopics created within the subscription irrespective of the resourcegroup
                    IPage<SystemTopic> systemtopicsinazuresubscription = this.EventGridManagementClient.SystemTopics.ListBySubscriptionAsync(null, 100).Result;
                    var systemtopicsinazuresubscriptionlist = new List<SystemTopic>();
                    if (systemtopicsinazuresubscription.Any())
                    {
                        systemtopicsinazuresubscriptionlist.AddRange(systemtopicsinazuresubscription);
                        var nextlink = systemtopicsinazuresubscription.NextPageLink;
                        while (nextlink != null)
                        {
                            try
                            {
                                systemtopicsinazuresubscription = this.EventGridManagementClient.SystemTopics.ListBySubscriptionNextAsync(nextlink).Result;
                                systemtopicsinazuresubscriptionlist.AddRange(systemtopicsinazuresubscription);
                                nextlink = systemtopicsinazuresubscription.NextPageLink;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                                break;
                            }
                        }
                    }

                    Assert.NotNull(systemtopicsinazuresubscriptionlist);
                    Assert.True(systemtopicsinazuresubscriptionlist.Count() >= 1);
                    Assert.Contains(systemtopicsinazuresubscriptionlist, t => t.Name == systemtopicname);

                    var replacesystemtopictagsdictionary = new Dictionary<string, string>()
                                {
                                    { "replacedtag1", "replacedvalue1" },
                                    { "replacedtag2", "replacedvalue2" }
                                };

                    // replace the systemtopic
                    systemtopic.Tags = replacesystemtopictagsdictionary;
                    var replacesystemtopicresponse = this.EventGridManagementClient.SystemTopics.CreateOrUpdateAsync(resourcegroup, systemtopicname, systemtopic).Result;

                    Assert.Contains(replacesystemtopicresponse.Tags, tag => tag.Key == "replacedtag1");
                    Assert.DoesNotContain(replacesystemtopicresponse.Tags, tag => tag.Key == "originaltag1");

                    // update the systemtopic with tags & allow traffic from all ips
                    SystemTopicUpdateParameters systemtopicupdateparameters = new SystemTopicUpdateParameters();
                    systemtopicupdateparameters.Tags = new Dictionary<string, string>()
                    {
                        { "updatedtag1", "updatedvalue1" },
                        { "updatedtag2", "updatedvalue2" }
                    };

                    var updatesystemtopicresponse = this.EventGridManagementClient.SystemTopics.UpdateAsync(resourcegroup, systemtopicname, systemtopicupdateparameters).Result;
                    Assert.Contains(updatesystemtopicresponse.Tags, tag => tag.Key == "updatedtag1");
                    Assert.DoesNotContain(updatesystemtopicresponse.Tags, tag => tag.Key == "replacedtag1");
                }
                finally
                {
                    // delete systemtopic
                    this.EventGridManagementClient.SystemTopics.DeleteAsync(resourcegroup, systemtopicname).Wait();
                }
            }
        }
    }
}