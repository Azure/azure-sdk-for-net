// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ServiceBus.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Management.ServiceBus;
    using Microsoft.Azure.Management.ServiceBus.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    using System.Threading;
    public partial class ScenarioTests
    {
        [Fact]
        public void StandardToPremiumMigration_withentities()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);

                var location2 = "West Central US";
                var location = "West Central US";

                var testRegions = this.ServiceBusManagementClient.PremiumMessagingRegions.List();

                var namespaceNameStandrad = TestUtilities.GenerateName(ServiceBusManagementHelper.NamespacePrefix); 
                var namespaceNamePremium = TestUtilities.GenerateName(ServiceBusManagementHelper.NamespacePrefix);
                var postmigrationName = TestUtilities.GenerateName(ServiceBusManagementHelper.PostMigrationPrefix);
                var queueName1 = TestUtilities.GenerateName(ServiceBusManagementHelper.QueuesPrefix);
                var queueName2 = TestUtilities.GenerateName(ServiceBusManagementHelper.QueuesPrefix);

                var topicName1 = TestUtilities.GenerateName(ServiceBusManagementHelper.TopicPrefix);
                var topicName2 = TestUtilities.GenerateName(ServiceBusManagementHelper.TopicPrefix);

                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(ServiceBusManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                //Create namespace 1
                var createPremiumNamespaceResponse = this.ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceNamePremium,
                    new SBNamespace()
                    {
                        Location = location,
                        Sku = new SBSku
                        {
                            Name = SkuName.Premium,
                            Tier = SkuTier.Premium
                        },
                        Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        }
                    });

                Assert.NotNull(createPremiumNamespaceResponse);
                Assert.Equal(createPremiumNamespaceResponse.Name, namespaceNamePremium);
                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Create Standard Namespace 
                var createStandardNamespaceResponse = this.ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceNameStandrad,
                    new SBNamespace()
                    {
                        Location = location2,
                        Sku = new SBSku
                        {
                            Name = SkuName.Standard,
                            Tier = SkuTier.Standard,
                            Capacity = 1
                        },
                        Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        }
                    });

                Assert.NotNull(createStandardNamespaceResponse);
                Assert.Equal(createStandardNamespaceResponse.Name, namespaceNameStandrad);
                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                
                // Get created namespaces 

                var getPremiumNamespace = this.ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceNamePremium);

                var getStandardNamespace = this.ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceNameStandrad);
                
                // Add 50 queue to standrad namespace

                for (int count = 0; count < 50; count++)
                {
                    var createdqueue = this.ServiceBusManagementClient.Queues.CreateOrUpdate(resourceGroup, namespaceNameStandrad, TestUtilities.GenerateName(ServiceBusManagementHelper.QueuesPrefix), new SBQueue { });
                }
                
                // Add 50 Topic to standrad namespace

                for (int count = 0; count < 50; count++)
                {
                    var createdtopic = this.ServiceBusManagementClient.Topics.CreateOrUpdate(resourceGroup, namespaceNameStandrad, TestUtilities.GenerateName(ServiceBusManagementHelper.TopicPrefix), new SBTopic { });
                }
                
                // create the Migartion Config

                var createMigrationConfigutationresponse = this.ServiceBusManagementClient.MigrationConfigs.CreateAndStartMigration(resourceGroup, namespaceNameStandrad, new MigrationConfigProperties { PostMigrationName = postmigrationName, TargetNamespace = getPremiumNamespace.Id });

                var getResponseMigrationConfiguration = ServiceBusManagementClient.MigrationConfigs.Get(resourceGroup, namespaceNameStandrad);
                // Wait and check for Provisioning state is succeeded
                while (getResponseMigrationConfiguration.ProvisioningState != "Succeeded" || getResponseMigrationConfiguration.PendingReplicationOperationsCount.HasValue && getResponseMigrationConfiguration.PendingReplicationOperationsCount !=0)
                {
                    getResponseMigrationConfiguration = ServiceBusManagementClient.MigrationConfigs.Get(resourceGroup, namespaceNameStandrad);
                    TestUtilities.Wait(TimeSpan.FromSeconds(30));
                }

                var getMigrationConfiguration = this.ServiceBusManagementClient.MigrationConfigs.Get(resourceGroup, namespaceNameStandrad);

                // List migrationconfigurations
                var ListMigrationconfigurations = this.ServiceBusManagementClient.MigrationConfigs.List(resourceGroup, namespaceNameStandrad);

                // Complete migration
                this.ServiceBusManagementClient.MigrationConfigs.CompleteMigration(resourceGroup, namespaceNameStandrad);

                // check for entity migration
                var QueuesPremiumnamespaceResponse = this.ServiceBusManagementClient.Queues.ListByNamespace(resourceGroup, namespaceNamePremium);

                Assert.Equal(50, QueuesPremiumnamespaceResponse.Count<SBQueue>());
                
                var TopicsPremiumnamespaceResponse = this.ServiceBusManagementClient.Topics.ListByNamespace(resourceGroup, namespaceNamePremium);

                Assert.Equal(50, TopicsPremiumnamespaceResponse.Count<SBTopic>());

                TestUtilities.Wait(TimeSpan.FromSeconds(60));

                // Wait and check for Provisioning state is succeeded for standard namespace
                while (!this.ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceNameStandrad).ProvisioningState.Equals("Succeeded"))
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(30));
                }

                // Wait and check for Provisioning state is succeeded for premium namespace
                while (!this.ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceNamePremium).ProvisioningState.Equals("Succeeded"))
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(30));
                }

                this.ServiceBusManagementClient.Namespaces.Delete(resourceGroup, namespaceNamePremium);

                this.ServiceBusManagementClient.Namespaces.Delete(resourceGroup, namespaceNameStandrad);
                
            }
        }
    }
}