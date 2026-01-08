// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Mgmt.Tests.Utilities
{
    public class ResourceMetadataExtensionsTests
    {
        [TestCase]
        public void CategorizeMethods_WithoutGetOperation_DoesNotAddCreateAsUpdate()
        {
            // Arrange - Create a resource with Create, Delete, List but no Get
            var resourceModel = InputFactory.Model("TestResource");
            var client = InputFactory.Client("TestResourceClient");

            var createOperation = InputFactory.Operation("createOrUpdate");
            var createMethod = InputFactory.BasicServiceMethod(
                name: "CreateOrUpdate",
                operation: createOperation,
                crossLanguageDefinitionId: Guid.NewGuid().ToString());

            var deleteOperation = InputFactory.Operation("delete");
            var deleteMethod = InputFactory.BasicServiceMethod(
                name: "Delete",
                operation: deleteOperation,
                crossLanguageDefinitionId: Guid.NewGuid().ToString());

            var listOperation = InputFactory.Operation("list");
            var listMethod = InputFactory.BasicServiceMethod(
                name: "List",
                operation: listOperation,
                crossLanguageDefinitionId: Guid.NewGuid().ToString());

            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Test.Namespace/testResources/{resourceName}";
            var parentResourceId = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}";

            var methods = new List<ResourceMethod>
            {
                new ResourceMethod(
                    ResourceOperationKind.Create,
                    createMethod,
                    resourceIdPattern,
                    ResourceScope.ResourceGroup,
                    resourceIdPattern,
                    client),
                new ResourceMethod(
                    ResourceOperationKind.Delete,
                    deleteMethod,
                    resourceIdPattern,
                    ResourceScope.ResourceGroup,
                    resourceIdPattern,
                    client),
                new ResourceMethod(
                    ResourceOperationKind.List,
                    listMethod,
                    parentResourceId + "/providers/Test.Namespace/testResources",
                    ResourceScope.ResourceGroup,
                    parentResourceId,
                    client)
            };

            var resourceMetadata = new ResourceMetadata(
                ResourceIdPattern: resourceIdPattern,
                ResourceName: "TestResource",
                ResourceType: "Test.Namespace/testResources",
                ResourceModel: resourceModel,
                ResourceScope: ResourceScope.ResourceGroup,
                Methods: methods,
                SingletonResourceName: null,
                ParentResourceId: null,
                ChildResourceIds: new List<string>());

            // Act
            var result = resourceMetadata.CategorizeMethods();

            // Assert
            // Create should only be in Collection, not in Resource (since there's no Get)
            Assert.That(result.MethodsInCollection.Any(m => m.Kind == ResourceOperationKind.Create), Is.True,
                "Create should be in Collection");
            Assert.That(result.MethodsInResource.Count(m => m.Kind == ResourceOperationKind.Create), Is.EqualTo(0),
                "Create should NOT be in Resource when there's no Get operation");

            // List should be in Collection
            Assert.That(result.MethodsInCollection.Any(m => m.Kind == ResourceOperationKind.List), Is.True,
                "List should be in Collection");
        }

        [TestCase]
        public void CategorizeMethods_WithoutGetOperation_MovesDeleteToCollection()
        {
            // Arrange - Create a resource with Create, Delete, List but no Get
            var resourceModel = InputFactory.Model("TestResource");
            var client = InputFactory.Client("TestResourceClient");

            var createOperation = InputFactory.Operation("createOrUpdate");
            var createMethod = InputFactory.BasicServiceMethod(
                name: "CreateOrUpdate",
                operation: createOperation,
                crossLanguageDefinitionId: Guid.NewGuid().ToString());

            var deleteOperation = InputFactory.Operation("delete");
            var deleteMethod = InputFactory.BasicServiceMethod(
                name: "Delete",
                operation: deleteOperation,
                crossLanguageDefinitionId: Guid.NewGuid().ToString());

            var listOperation = InputFactory.Operation("list");
            var listMethod = InputFactory.BasicServiceMethod(
                name: "List",
                operation: listOperation,
                crossLanguageDefinitionId: Guid.NewGuid().ToString());

            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Test.Namespace/testResources/{resourceName}";
            var parentResourceId = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}";

            var methods = new List<ResourceMethod>
            {
                new ResourceMethod(
                    ResourceOperationKind.Create,
                    createMethod,
                    resourceIdPattern,
                    ResourceScope.ResourceGroup,
                    resourceIdPattern,
                    client),
                new ResourceMethod(
                    ResourceOperationKind.Delete,
                    deleteMethod,
                    resourceIdPattern,
                    ResourceScope.ResourceGroup,
                    resourceIdPattern,
                    client),
                new ResourceMethod(
                    ResourceOperationKind.List,
                    listMethod,
                    parentResourceId + "/providers/Test.Namespace/testResources",
                    ResourceScope.ResourceGroup,
                    parentResourceId,
                    client)
            };

            var resourceMetadata = new ResourceMetadata(
                ResourceIdPattern: resourceIdPattern,
                ResourceName: "TestResource",
                ResourceType: "Test.Namespace/testResources",
                ResourceModel: resourceModel,
                ResourceScope: ResourceScope.ResourceGroup,
                Methods: methods,
                SingletonResourceName: null,
                ParentResourceId: null,
                ChildResourceIds: new List<string>());

            // Act
            var result = resourceMetadata.CategorizeMethods();

            // Assert
            // Delete should be moved to Collection (not in Resource) when there's no Get
            Assert.That(result.MethodsInCollection.Any(m => m.Kind == ResourceOperationKind.Delete), Is.True,
                "Delete should be in Collection when there's no Get operation");
            Assert.That(result.MethodsInResource.Any(m => m.Kind == ResourceOperationKind.Delete), Is.False,
                "Delete should NOT be in Resource when there's no Get operation");
        }

        [TestCase]
        public void CategorizeMethods_WithGetOperation_AddsCreateAsUpdate()
        {
            // Arrange - Create a resource with Create, Get, Delete, List (standard CRUD)
            var resourceModel = InputFactory.Model("TestResource");
            var client = InputFactory.Client("TestResourceClient");

            var createOperation = InputFactory.Operation("createOrUpdate");
            var createMethod = InputFactory.BasicServiceMethod(
                name: "CreateOrUpdate",
                operation: createOperation,
                crossLanguageDefinitionId: Guid.NewGuid().ToString());

            var getOperation = InputFactory.Operation("get");
            var getMethod = InputFactory.BasicServiceMethod(
                name: "Get",
                operation: getOperation,
                crossLanguageDefinitionId: Guid.NewGuid().ToString());

            var deleteOperation = InputFactory.Operation("delete");
            var deleteMethod = InputFactory.BasicServiceMethod(
                name: "Delete",
                operation: deleteOperation,
                crossLanguageDefinitionId: Guid.NewGuid().ToString());

            var listOperation = InputFactory.Operation("list");
            var listMethod = InputFactory.BasicServiceMethod(
                name: "List",
                operation: listOperation,
                crossLanguageDefinitionId: Guid.NewGuid().ToString());

            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Test.Namespace/testResources/{resourceName}";
            var parentResourceId = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}";

            var methods = new List<ResourceMethod>
            {
                new ResourceMethod(
                    ResourceOperationKind.Create,
                    createMethod,
                    resourceIdPattern,
                    ResourceScope.ResourceGroup,
                    resourceIdPattern,
                    client),
                new ResourceMethod(
                    ResourceOperationKind.Read,
                    getMethod,
                    resourceIdPattern,
                    ResourceScope.ResourceGroup,
                    resourceIdPattern,
                    client),
                new ResourceMethod(
                    ResourceOperationKind.Delete,
                    deleteMethod,
                    resourceIdPattern,
                    ResourceScope.ResourceGroup,
                    resourceIdPattern,
                    client),
                new ResourceMethod(
                    ResourceOperationKind.List,
                    listMethod,
                    parentResourceId + "/providers/Test.Namespace/testResources",
                    ResourceScope.ResourceGroup,
                    parentResourceId,
                    client)
            };

            var resourceMetadata = new ResourceMetadata(
                ResourceIdPattern: resourceIdPattern,
                ResourceName: "TestResource",
                ResourceType: "Test.Namespace/testResources",
                ResourceModel: resourceModel,
                ResourceScope: ResourceScope.ResourceGroup,
                Methods: methods,
                SingletonResourceName: null,
                ParentResourceId: null,
                ChildResourceIds: new List<string>());

            // Act
            var result = resourceMetadata.CategorizeMethods();

            // Assert
            // With Get operation, Create should be added to Resource as Update (since there's no separate Update operation)
            Assert.That(result.MethodsInResource.Count(m => m.Kind == ResourceOperationKind.Create), Is.EqualTo(1),
                "Create should be added to Resource as Update when Get exists and no Update operation");
            Assert.That(result.MethodsInCollection.Any(m => m.Kind == ResourceOperationKind.Create), Is.True,
                "Create should also be in Collection");

            // Delete should stay in Resource (not moved to Collection) when there's a Get
            Assert.That(result.MethodsInResource.Any(m => m.Kind == ResourceOperationKind.Delete), Is.True,
                "Delete should be in Resource when Get operation exists");
            Assert.That(result.MethodsInCollection.Any(m => m.Kind == ResourceOperationKind.Delete), Is.False,
                "Delete should NOT be in Collection when Get operation exists");
        }

        [TestCase]
        public void CategorizeMethods_SingletonWithoutGet_KeepsDeleteInResource()
        {
            // Arrange - Create a singleton resource without Get
            var resourceModel = InputFactory.Model("TestSingleton");
            var client = InputFactory.Client("TestSingletonClient");

            var createOperation = InputFactory.Operation("createOrUpdate");
            var createMethod = InputFactory.BasicServiceMethod(
                name: "CreateOrUpdate",
                operation: createOperation,
                crossLanguageDefinitionId: Guid.NewGuid().ToString());

            var deleteOperation = InputFactory.Operation("delete");
            var deleteMethod = InputFactory.BasicServiceMethod(
                name: "Delete",
                operation: deleteOperation,
                crossLanguageDefinitionId: Guid.NewGuid().ToString());

            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Test.Namespace/testResources/{resourceName}/singleton";
            var parentResourceId = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Test.Namespace/testResources/{resourceName}";

            var methods = new List<ResourceMethod>
            {
                new ResourceMethod(
                    ResourceOperationKind.Create,
                    createMethod,
                    resourceIdPattern,
                    ResourceScope.ResourceGroup,
                    resourceIdPattern,
                    client),
                new ResourceMethod(
                    ResourceOperationKind.Delete,
                    deleteMethod,
                    resourceIdPattern,
                    ResourceScope.ResourceGroup,
                    resourceIdPattern,
                    client)
            };

            var resourceMetadata = new ResourceMetadata(
                ResourceIdPattern: resourceIdPattern,
                ResourceName: "TestSingleton",
                ResourceType: "Test.Namespace/testResources/singleton",
                ResourceModel: resourceModel,
                ResourceScope: ResourceScope.ResourceGroup,
                Methods: methods,
                SingletonResourceName: "default",
                ParentResourceId: parentResourceId,
                ChildResourceIds: new List<string>());

            // Act
            var result = resourceMetadata.CategorizeMethods();

            // Assert
            // For singleton, Delete should stay in Resource even without Get
            Assert.That(result.MethodsInResource.Any(m => m.Kind == ResourceOperationKind.Delete), Is.True,
                "Delete should be in Resource for singleton even without Get");
            Assert.That(result.MethodsInCollection.Any(m => m.Kind == ResourceOperationKind.Delete), Is.False,
                "Delete should NOT be in Collection for singleton");
        }
    }
}
