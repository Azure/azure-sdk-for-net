// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace EventHub.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using Microsoft.Azure.Management.EventHub;
    using Microsoft.Azure.Management.EventHub.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    public partial class ScenarioTests
    {
        [Fact]
        public void SchemaGroupCreateUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);
                var location = "South Central US";
                this.ResourceManagementClient.GetLocationFromProvider();
                var resourceGroup = string.Empty;
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(EventHubManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }
                var namespaceName = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix); try
                {
                    var createNamespaceResponse = this.EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new EHNamespace()
                    {
                        Location = location,
                        Sku = new Sku
                        {
                            Name = SkuName.Standard,
                            Tier = SkuTier.Standard
                        },
                        Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        }
                    });
                    Assert.NotNull(createNamespaceResponse);
                    Assert.Equal(createNamespaceResponse.Name, namespaceName);
                    TestUtilities.Wait(TimeSpan.FromSeconds(5)); // Create a SchemaGroup
                    var schemaName = TestUtilities.GenerateName(EventHubManagementHelper.SchemaPrefix);
                    var createSchemaGroupResponse = this.EventHubManagementClient.SchemaRegistry.CreateOrUpdate(resourceGroup, namespaceName, schemaName,
                    new SchemaGroup()
                    {
                        SchemaType = SchemaType.Avro,
                        SchemaCompatibility = SchemaCompatibility.Forward,
                        GroupProperties = new Dictionary<string, string>() { { "TestKey", "TestValue" }, { "TestKey1", "TestValue1" } }
                    });
                    Assert.NotNull(createSchemaGroupResponse);
                    Assert.Equal(createSchemaGroupResponse.Name, schemaName);
                    Assert.Equal(createSchemaGroupResponse.SchemaCompatibility, SchemaCompatibility.Forward);
                    Assert.Equal(createSchemaGroupResponse.SchemaType, SchemaType.Avro);
                    Assert.True(createSchemaGroupResponse.GroupProperties.Count == 2);
                    // Namesapce1
                    var namespaceName1 = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix);
                    var createPremiumNamespaceResponse = this.EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName1,
                    new EHNamespace()
                    {
                        Location = location,
                        Sku = new Sku
                        {
                            Name = SkuName.Standard,
                            Tier = SkuTier.Standard
                        },
                        Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        }
                    });
                    var schemaName1 = TestUtilities.GenerateName(EventHubManagementHelper.SchemaPrefix); var createSchemaGroupResponse1 = this.EventHubManagementClient.SchemaRegistry.CreateOrUpdate(resourceGroup, namespaceName1, schemaName1,
                        new SchemaGroup()
                        {
                            SchemaType = SchemaType.Avro,
                            SchemaCompatibility = SchemaCompatibility.Backward
                        }); Assert.NotNull(createSchemaGroupResponse1);
                    Assert.Equal(createSchemaGroupResponse1.Name, schemaName1);
                    Assert.Equal(createSchemaGroupResponse1.SchemaCompatibility, SchemaCompatibility.Backward);
                    Assert.Equal(createSchemaGroupResponse1.SchemaType, SchemaType.Avro); var namespaceName2 = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix);
                    var createNamespaceResponse2 = this.EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName2,
                    new EHNamespace()
                    {
                        Location = location,
                        Sku = new Sku
                        {
                            Name = SkuName.Standard,
                            Tier = SkuTier.Standard
                        },
                        Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        }
                    });
                    var schemaName2 = TestUtilities.GenerateName(EventHubManagementHelper.SchemaPrefix); var createSchemaGroupResponse2 = this.EventHubManagementClient.SchemaRegistry.CreateOrUpdate(resourceGroup, namespaceName2, schemaName2,
                    new SchemaGroup()
                    {
                        SchemaType = SchemaType.Avro,
                        SchemaCompatibility = SchemaCompatibility.None
                    }); Assert.NotNull(createSchemaGroupResponse2);
                    Assert.Equal(createSchemaGroupResponse2.Name, schemaName2);
                    Assert.Equal(createSchemaGroupResponse2.SchemaCompatibility, SchemaCompatibility.None);
                    Assert.Equal(createSchemaGroupResponse2.SchemaType, SchemaType.Avro);
                    // Get the created Schemagroup
                    var getSchemagroupResponse = EventHubManagementClient.SchemaRegistry.Get(resourceGroup, namespaceName, schemaName);
                    Assert.NotNull(getSchemagroupResponse);
                    Assert.Equal(getSchemagroupResponse.Name, schemaName);
                    Assert.Equal(getSchemagroupResponse.SchemaCompatibility, SchemaCompatibility.Forward);
                    Assert.Equal(getSchemagroupResponse.SchemaType, SchemaType.Avro); // Get the created Schemagroup
                    var getSchemagroupResponse1 = EventHubManagementClient.SchemaRegistry.Get(resourceGroup, namespaceName1, schemaName1);
                    Assert.NotNull(getSchemagroupResponse1);
                    Assert.Equal(getSchemagroupResponse1.Name, schemaName1);
                    Assert.Equal(getSchemagroupResponse1.SchemaCompatibility, SchemaCompatibility.Backward);
                    Assert.Equal(getSchemagroupResponse1.SchemaType, SchemaType.Avro); // Get the created Schemagroup
                    var getSchemagroupResponse2 = EventHubManagementClient.SchemaRegistry.Get(resourceGroup, namespaceName2, schemaName2);
                    Assert.NotNull(getSchemagroupResponse2);
                    Assert.Equal(getSchemagroupResponse2.Name, schemaName2);
                    Assert.Equal(getSchemagroupResponse2.SchemaCompatibility, SchemaCompatibility.None);
                    Assert.Equal(getSchemagroupResponse2.SchemaType, SchemaType.Avro); // Get all Event Hubs for a given NameSpace
                    var getListSchemaGroupResponse = EventHubManagementClient.SchemaRegistry.ListByNamespace(resourceGroup, namespaceName1);
                    Assert.NotNull(getListSchemaGroupResponse);
                    Assert.True(getListSchemaGroupResponse.Count<SchemaGroup>() == 1); // Delete the SchemaGroups
                    EventHubManagementClient.SchemaRegistry.Delete(resourceGroup, namespaceName, schemaName);
                    EventHubManagementClient.SchemaRegistry.Delete(resourceGroup, namespaceName1, schemaName1);
                    EventHubManagementClient.SchemaRegistry.Delete(resourceGroup, namespaceName2, schemaName2); TestUtilities.Wait(TimeSpan.FromSeconds(5)); // Delete namespace and check for the NotFound exception
                    EventHubManagementClient.Namespaces.DeleteWithHttpMessagesAsync(resourceGroup, namespaceName, null, default(CancellationToken)).ConfigureAwait(false);
                    EventHubManagementClient.Namespaces.DeleteWithHttpMessagesAsync(resourceGroup, namespaceName1, null, default(CancellationToken)).ConfigureAwait(false);
                    EventHubManagementClient.Namespaces.DeleteWithHttpMessagesAsync(resourceGroup, namespaceName2, null, default(CancellationToken)).ConfigureAwait(false);
                }
                finally
                {
                    //Delete Resource Group
                    this.ResourceManagementClient.ResourceGroups.DeleteWithHttpMessagesAsync(resourceGroup, null, default(CancellationToken)).ConfigureAwait(false);
                    Console.WriteLine("End of SchemaGrouptest");
                }
            }
        }
    }
}

