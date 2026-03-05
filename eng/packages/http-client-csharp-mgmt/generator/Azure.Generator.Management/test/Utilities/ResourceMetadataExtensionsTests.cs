// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;
using System;

namespace Azure.Generator.Mgmt.Tests.Utilities
{
    public class ResourceMetadataExtensionsTests
    {
        // Helper to create a minimal resource model for tests
        private static InputModelType CreateResourceModel(string name)
        {
            return InputFactory.Model(name,
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                ],
                decorators: []);
        }

        /// <summary>
        /// Tests that when a nested resource has a List operation with resourceScope set to the parent resource ID,
        /// the method is categorized into the collection (enabling GetAll generation).
        /// This is the expected behavior when resourceScope is correctly set by the emitter.
        /// </summary>
        [Test]
        public void CategorizeMethods_ListWithCorrectResourceScope_GoesToCollection()
        {
            // Arrange: Create a nested resource with a parent ARM resource
            // Parent: /subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.Foo/parents/{parentName}
            // Child:  /subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.Foo/parents/{parentName}/children/{childName}
            const string parentResourceId = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Foo/parents/{parentName}";
            const string childResourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Foo/parents/{parentName}/children/{childName}";
            const string listOperationPath = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Foo/parents/{parentName}/children";

            var listOperation = InputFactory.Operation(name: "list", path: listOperationPath);
            var listMethod = InputFactory.BasicServiceMethod("list", listOperation, crossLanguageDefinitionId: "Test.Children.list");
            var resourceModel = CreateResourceModel("ChildModel");

            // Create resource metadata with the List method having resourceScope set to parentResourceId
            var resourceMetadata = new ResourceMetadata(
                ResourceIdPattern: childResourceIdPattern,
                ResourceName: "Child",
                ResourceType: "Microsoft.Foo/parents/children",
                ResourceModel: resourceModel,
                ResourceScope: ResourceScope.ResourceGroup,
                Methods: new[]
                {
                    // List operation with resourceScope correctly set to parentResourceId
                    new ResourceMethod(
                        ResourceOperationKind.List,
                        listMethod,
                        listOperationPath,
                        ResourceScope.ResourceGroup,
                        parentResourceId, // resourceScope = parentResourceId (correct)
                        null!)
                },
                SingletonResourceName: null,
                ParentResourceId: parentResourceId,
                ChildResourceIds: Array.Empty<string>());

            // Act
            var categorized = resourceMetadata.CategorizeMethods();

            // Assert
            // The list method should be in the collection (since resourceScope == parentResourceId)
            Assert.AreEqual(0, categorized.MethodsInResource.Count, "List method should NOT be in resource");
            Assert.AreEqual(1, categorized.MethodsInCollection.Count, "List method SHOULD be in collection");
            Assert.AreEqual(0, categorized.MethodsInExtension.Count, "List method should NOT be in extension");
        }

        /// <summary>
        /// Documents that when a nested resource's List operation has null resourceScope,
        /// the generator routes it to extension instead of collection. This scenario is
        /// prevented by the emitter's postProcessArmResources which always populates
        /// resourceScope correctly for list operations.
        /// </summary>
        [Test]
        public void CategorizeMethods_NestedResource_ListWithNullResourceScope_GoesToExtension()
        {
            // Arrange: Nested resource where list operation has null resourceScope
            const string parentResourceId = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Foo/parents/{parentName}";
            const string childResourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Foo/parents/{parentName}/children/{childName}";
            const string listOperationPath = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Foo/parents/{parentName}/children";

            var listOperation = InputFactory.Operation(name: "list", path: listOperationPath);
            var listMethod = InputFactory.BasicServiceMethod("list", listOperation, crossLanguageDefinitionId: "Test.Children.list");
            var resourceModel = CreateResourceModel("ChildModel");

            var resourceMetadata = new ResourceMetadata(
                ResourceIdPattern: childResourceIdPattern,
                ResourceName: "Child",
                ResourceType: "Microsoft.Foo/parents/children",
                ResourceModel: resourceModel,
                ResourceScope: ResourceScope.ResourceGroup,
                Methods: new[]
                {
                    new ResourceMethod(
                        ResourceOperationKind.List,
                        listMethod,
                        listOperationPath,
                        ResourceScope.ResourceGroup,
                        null, // null resourceScope causes incorrect routing
                        null!)
                },
                SingletonResourceName: null,
                ParentResourceId: parentResourceId,
                ChildResourceIds: Array.Empty<string>());

            // Act
            var categorized = resourceMetadata.CategorizeMethods();

            // Assert: With null resourceScope, list incorrectly goes to extension
            Assert.AreEqual(0, categorized.MethodsInResource.Count);
            Assert.AreEqual(0, categorized.MethodsInCollection.Count);
            Assert.AreEqual(1, categorized.MethodsInExtension.Count);
        }

        /// <summary>
        /// Tests that for a top-level resource (no ARM parent), a List operation
        /// with null resourceScope is correctly categorized into collection when
        /// operationScope matches resourceScope.
        /// </summary>
        [Test]
        public void CategorizeMethods_TopLevelResource_ListWithMatchingOperationScope_GoesToCollection()
        {
            // Arrange: Top-level RG resource with no parent ARM resource
            const string resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Foo/resources/{resourceName}";
            const string listOperationPath = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Foo/resources";

            var listOperation = InputFactory.Operation(name: "list", path: listOperationPath);
            var listMethod = InputFactory.BasicServiceMethod("list", listOperation, crossLanguageDefinitionId: "Test.Resources.list");
            var resourceModel = CreateResourceModel("ResourceModel");

            var resourceMetadata = new ResourceMetadata(
                ResourceIdPattern: resourceIdPattern,
                ResourceName: "Resource",
                ResourceType: "Microsoft.Foo/resources",
                ResourceModel: resourceModel,
                ResourceScope: ResourceScope.ResourceGroup,
                Methods: new[]
                {
                    // For top-level resources, resourceScope can be null; we rely on operationScope matching
                    new ResourceMethod(
                        ResourceOperationKind.List,
                        listMethod,
                        listOperationPath,
                        ResourceScope.ResourceGroup, // operationScope
                        null, // resourceScope can be null for top-level resources
                        null!)
                },
                SingletonResourceName: null,
                ParentResourceId: null, // No parent ARM resource
                ChildResourceIds: Array.Empty<string>());

            // Act
            var categorized = resourceMetadata.CategorizeMethods();

            // Assert: For top-level resources, when parentResourceId is null,
            // the code falls through to check operationScope == resourceScope
            Assert.AreEqual(0, categorized.MethodsInResource.Count);
            Assert.AreEqual(1, categorized.MethodsInCollection.Count, "Top-level list should be in collection");
            Assert.AreEqual(0, categorized.MethodsInExtension.Count);
        }
    }
}
