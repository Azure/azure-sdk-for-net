// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Servicebus.Fluent;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Tests.ServiceBus
{
    public class ServiceBusTests
    {
        [Fact]
        public void CanCRUDOnSimpleNamespace()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("javasbmrg");
                try
                {
                    var resourceManager = TestHelper.CreateResourceManager();
                    var serviceBusManager = TestHelper.CreateServiceBusManager();
                    Region region = Region.USEast;

                    var rgCreatable = resourceManager.ResourceGroups
                        .Define(rgName)
                        .WithRegion(region);

                    var namespaceDNSLabel = TestUtilities.GenerateName("jvsbns");
                    var nspace = serviceBusManager.Namespaces
                            .Define(namespaceDNSLabel)
                            .WithRegion(region)
                            .WithNewResourceGroup(rgCreatable)
                            .WithSku(NamespaceSku.PremiumCapacity1)
                            .Create();

                    var namespaces = serviceBusManager.Namespaces.ListByGroup(rgName);
                    Assert.NotNull(namespaces);
                    Assert.True(namespaces.Count > 0);
                    var found = false;
                    foreach (var n in namespaces)
                    {
                        if (n.Name.Equals(nspace.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.True(found);

                    Assert.NotNull(nspace.DnsLabel);
                    Assert.True(nspace.DnsLabel.Equals(namespaceDNSLabel, StringComparison.OrdinalIgnoreCase));
                    Assert.NotNull(nspace.Fqdn);
                    Assert.True(nspace.Fqdn.Contains(namespaceDNSLabel));
                    Assert.NotNull(nspace.Sku);
                    Assert.True(nspace.Sku.Equals(NamespaceSku.PremiumCapacity1));
                    Assert.NotNull(nspace.Region);
                    Assert.True(nspace.Region.Equals(region));
                    Assert.NotNull(nspace.ResourceGroupName);
                    Assert.True(nspace.ResourceGroupName.Equals(rgName, StringComparison.OrdinalIgnoreCase));
                    Assert.NotNull(nspace.CreatedAt);
                    Assert.NotNull(nspace.Queues);
                    Assert.Equal(0, nspace.Queues.List().Count);
                    Assert.NotNull(nspace.Topics);
                    Assert.Equal(0, nspace.Topics.List().Count());
                    Assert.NotNull(nspace.AuthorizationRules);
                    var defaultNsRules = nspace.AuthorizationRules.List();
                    Assert.Equal(1, defaultNsRules.Count());
                    var defaultNsRule = defaultNsRules.get(0);
                    Assert.True(defaultNsRule.Name.equalsIgnoreCase("RootManageSharedAccessKey"));
                    Assert.NotNull(defaultNsRule.rights());
                    Assert.NotNull(defaultNsRule.NamespaceName);
                    Assert.True(defaultNsRule.NamespaceName.equalsIgnoreCase(namespaceDNSLabel));
                    Assert.NotNull(defaultNsRule.resourceGroupName());
                    Assert.True(defaultNsRule.ResourceGroupName.equalsIgnoreCase(rgName));
                    nspace.Update()
                        .WithSku(NamespaceSku.PremiumCapacity2)
                        .Apply();
                    Assert.True(nspace.Sku.Equals(NamespaceSku.PremiumCapacity2));
                    // TODO: There is a bug in LRO implementation of ServiceBusNamespace DELETE operation (Last poll returns 404, reported this to RP]
                    //
                    // serviceBusManager.Namespaces.DeleteByGroup(rgName, nspace.Name);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                    }
                    catch
                    {
                    }
                }
            }
        }

        [Fact]
        public void CanCreateNamespaceThenCRUDOnQueue()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("javasbmrg");
                try
                {
                    var resourceManager = TestHelper.CreateResourceManager();
                    var serviceBusManager = TestHelper.CreateServiceBusManager();
                    Region region = Region.USEast;

                    var rgCreatable = resourceManager.ResourceGroups
                        .Define(rgName)
                        .WithRegion(region);

                    var namespaceDNSLabel = TestUtilities.GenerateName("jvsbns");
                    var nspace = serviceBusManager.Namespaces
                        .Define(namespaceDNSLabel)
                            .WithRegion(region)
                            .WithNewResourceGroup(rgCreatable)
                            .WithSku(NamespaceSku.PremiumCapacity1)
                        .Create();
                    Assert.NotNull(nspace);
                    Assert.NotNull(nspace.Inner);

                    String queueName = TestUtilities.GenerateName("queue1-");
                    var queue = nspace.Queues
                            .Define(queueName)
                            .Create();

                    Assert.NotNull(queue);
                    Assert.NotNull(queue.Inner);
                    Assert.NotNull(queue.Name);
                    Assert.True(queue.Name.Equals(queueName, StringComparison.OrdinalIgnoreCase));

                    // Default lock duration is 1 minute, assert TimeSpan("00:01:00") parsing
                    //
                    Assert.Equal("00:01:00", queue.Inner.LockDuration);
                    Assert.Equal(60, queue.LockDurationInSeconds);

                    var dupDetectionDuration = queue.DuplicateMessageDetectionHistoryDuration;
                    Assert.NotNull(dupDetectionDuration);
                    Assert.Equal(10, dupDetectionDuration.TotalMinutes);
                    // Default message TTL is TimeSpan.Max, assert parsing
                    //
                    Assert.Equal("10675199.02:48:05.4775807", queue.Inner.DefaultMessageTimeToLive);
                    var msgTtlDuration = queue.DefaultMessageTtlDuration;
                    Assert.NotNull(msgTtlDuration);
                    // Assert the default ttl TimeSpan("10675199.02:48:05.4775807") parsing
                    //
                    Assert.Equal(10675199, msgTtlDuration.Days);
                    Assert.Equal(2, msgTtlDuration.Hours);
                    Assert.Equal(48, msgTtlDuration.Minutes);
                    // Assert the default max size In MB
                    //
                    Assert.Equal(1024, queue.MaxSizeInMB);
                    var queuesInNamespace = nspace.Queues.List();
                    Assert.NotNull(queuesInNamespace);
                    Assert.True(queuesInNamespace.Count() > 0);
                    IQueue foundQueue = null;
                    foreach (var q in queuesInNamespace)
                    {
                        if (q.Name.Equals(queueName, StringComparison.OrdinalIgnoreCase))
                        {
                            foundQueue = q;
                            break;
                        }
                    }
                    Assert.NotNull(foundQueue);
                    // Dead lettering disabled by default
                    //
                    Assert.False(foundQueue.IsDeadLetteringEnabledForExpiredMessages);
                    foundQueue = foundQueue.Update()
                            .WithMessageLockDurationInSeconds(120)
                            .WithDefaultMessageTTL(new TimeSpan(0, 20, 0))
                            .WithExpiredMessageMovedToDeadLetterQueue()
                            .WithMessageMovedToDeadLetterQueueOnMaxDeliveryCount(25)
                            .Apply();
                    Assert.Equal(120, foundQueue.LockDurationInSeconds);
                    Assert.True(foundQueue.IsDeadLetteringEnabledForExpiredMessages);
                    Assert.Equal(25, foundQueue.MaxDeliveryCountBeforeDeadLetteringMessage);
                    nspace.Queues.DeleteByName(foundQueue.Name);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                    }
                    catch
                    {
                    }
                }
            }
        }
    }
}
