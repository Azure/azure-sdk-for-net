// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Utilities;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests.Utilities
{
    public class ResourceHelpersTests
    {
        [TestCase]
        public void GetOperationId_WithNullCrossLanguageDefinitionId_ReturnsOperationName()
        {
            // Arrange
            var operation = InputFactory.Operation("GetFoo");
            var serviceMethod = InputFactory.BasicServiceMethod(
                name: "GetFoo",
                operation: operation,
                crossLanguageDefinitionId: null);

            // Act
            var result = ResourceHelpers.GetOperationId(serviceMethod);

            // Assert
            Assert.AreEqual("GetFoo", result);
        }

        [TestCase]
        public void GetOperationId_WithEmptyCrossLanguageDefinitionId_ReturnsOperationName()
        {
            // Arrange
            var operation = InputFactory.Operation("GetBar");
            var serviceMethod = InputFactory.BasicServiceMethod(
                name: "GetBar",
                operation: operation,
                crossLanguageDefinitionId: string.Empty);

            // Act
            var result = ResourceHelpers.GetOperationId(serviceMethod);

            // Assert
            Assert.AreEqual("GetBar", result);
        }

        [TestCase]
        public void GetOperationId_WithSinglePartCrossLanguageDefinitionId_ReturnsOperationName()
        {
            // Arrange
            var operation = InputFactory.Operation("GetBaz");
            var serviceMethod = InputFactory.BasicServiceMethod(
                name: "GetBaz",
                operation: operation,
                crossLanguageDefinitionId: "MgmtTypeSpec");

            // Act
            var result = ResourceHelpers.GetOperationId(serviceMethod);

            // Assert
            Assert.AreEqual("GetBaz", result);
        }

        [TestCase]
        public void GetOperationId_WithTwoPartCrossLanguageDefinitionId_ReturnsFormattedId()
        {
            // Arrange
            var operation = InputFactory.Operation("get");
            var serviceMethod = InputFactory.BasicServiceMethod(
                name: "Get",
                operation: operation,
                crossLanguageDefinitionId: "MgmtTypeSpec.Foos.get");

            // Act
            var result = ResourceHelpers.GetOperationId(serviceMethod);

            // Assert
            Assert.AreEqual("Foos_Get", result);
        }

        [TestCase]
        public void GetOperationId_WithResourceOperation_ReturnsFormattedId()
        {
            // Arrange
            var operation = InputFactory.Operation("get");
            var serviceMethod = InputFactory.BasicServiceMethod(
                name: "Get",
                operation: operation,
                crossLanguageDefinitionId: "MgmtTypeSpec.Bars.get");

            // Act
            var result = ResourceHelpers.GetOperationId(serviceMethod);

            // Assert
            Assert.AreEqual("Bars_Get", result);
        }

        [TestCase]
        public void GetOperationId_WithListBySubscription_ReturnsFormattedId()
        {
            // Arrange
            var operation = InputFactory.Operation("listBySubscription");
            var serviceMethod = InputFactory.BasicServiceMethod(
                name: "ListBySubscription",
                operation: operation,
                crossLanguageDefinitionId: "MgmtTypeSpec.Foos.listBySubscription");

            // Act
            var result = ResourceHelpers.GetOperationId(serviceMethod);

            // Assert
            Assert.AreEqual("Foos_ListBySubscription", result);
        }

        [TestCase]
        public void GetOperationId_WithProviderAction_ReturnsFormattedId()
        {
            // Arrange
            var operation = InputFactory.Operation("previewActions");
            var serviceMethod = InputFactory.BasicServiceMethod(
                name: "PreviewActions",
                operation: operation,
                crossLanguageDefinitionId: "MgmtTypeSpec.MgmtTypeSpec.previewActions");

            // Act
            var result = ResourceHelpers.GetOperationId(serviceMethod);

            // Assert
            Assert.AreEqual("MgmtTypeSpec_PreviewActions", result);
        }

        [TestCase]
        public void GetOperationId_WithLowercaseMethodName_CapitalizesFirstLetter()
        {
            // Arrange
            var operation = InputFactory.Operation("delete");
            var serviceMethod = InputFactory.BasicServiceMethod(
                name: "Delete",
                operation: operation,
                crossLanguageDefinitionId: "MgmtTypeSpec.Resources.delete");

            // Act
            var result = ResourceHelpers.GetOperationId(serviceMethod);

            // Assert
            Assert.AreEqual("Resources_Delete", result);
        }

        [TestCase]
        public void GetOperationId_WithMultipleNamespaceParts_UsesLastTwo()
        {
            // Arrange
            var operation = InputFactory.Operation("get");
            var serviceMethod = InputFactory.BasicServiceMethod(
                name: "Get",
                operation: operation,
                crossLanguageDefinitionId: "Azure.MgmtTypeSpec.Services.Resources.get");

            // Act
            var result = ResourceHelpers.GetOperationId(serviceMethod);

            // Assert
            Assert.AreEqual("Resources_Get", result);
        }

        [TestCase]
        public void IsOperatingOnCurrentResource_ForDelete_WhenOperationPathMatchesResourceIdPattern_ReturnsTrue()
        {
            // Arrange
            var operation = InputFactory.Operation("delete", path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}");
            var serviceMethod = InputFactory.BasicServiceMethod(
                name: "Delete",
                operation: operation);
            var resourceMethod = new ResourceMethod(
                ResourceOperationKind.Delete,
                serviceMethod,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}",
                ResourceScope.ResourceGroup,
                null,
                InputFactory.Client("VirtualMachines"));
            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}";

            // Act
            var result = ResourceHelpers.IsOperatingOnCurrentResource(resourceMethod, resourceIdPattern);

            // Assert
            Assert.IsTrue(result);
        }

        [TestCase]
        public void IsOperatingOnCurrentResource_ForRead_WhenOperationPathMatchesResourceIdPattern_ReturnsTrue()
        {
            // Arrange
            var operation = InputFactory.Operation("get", path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}");
            var serviceMethod = InputFactory.BasicServiceMethod(
                name: "Get",
                operation: operation);
            var resourceMethod = new ResourceMethod(
                ResourceOperationKind.Read,
                serviceMethod,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}",
                ResourceScope.ResourceGroup,
                null,
                InputFactory.Client("VirtualMachines"));
            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}";

            // Act
            var result = ResourceHelpers.IsOperatingOnCurrentResource(resourceMethod, resourceIdPattern);

            // Assert
            Assert.IsTrue(result);
        }

        [TestCase]
        public void IsOperatingOnCurrentResource_ForRead_WhenOperationPathDifferentFromResourceIdPattern_ReturnsFalse()
        {
            // Arrange
            var operation = InputFactory.Operation("getChildResource", path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/childResources/{childName}");
            var serviceMethod = InputFactory.BasicServiceMethod(
                name: "GetChildResource",
                operation: operation);
            var resourceMethod = new ResourceMethod(
                ResourceOperationKind.Read,
                serviceMethod,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/childResources/{childName}",
                ResourceScope.ResourceGroup,
                null,
                InputFactory.Client("VirtualMachines"));
            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}";

            // Act
            var result = ResourceHelpers.IsOperatingOnCurrentResource(resourceMethod, resourceIdPattern);

            // Assert
            Assert.IsFalse(result);
        }

        [TestCase]
        public void IsOperatingOnCurrentResource_ForList_WhenOperationPathDifferentFromResourceIdPattern_ReturnsFalse()
        {
            // Arrange
            var operation = InputFactory.Operation("listChildResources", path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/childResources");
            var serviceMethod = InputFactory.BasicServiceMethod(
                name: "ListChildResources",
                operation: operation);
            var resourceMethod = new ResourceMethod(
                ResourceOperationKind.List,
                serviceMethod,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/childResources",
                ResourceScope.ResourceGroup,
                null,
                InputFactory.Client("VirtualMachines"));
            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}";

            // Act
            var result = ResourceHelpers.IsOperatingOnCurrentResource(resourceMethod, resourceIdPattern);

            // Assert
            Assert.IsFalse(result);
        }

        [TestCase]
        public void IsOperatingOnCurrentResource_ForAction_ReturnsTrue()
        {
            // Arrange - Action operations always return true regardless of path
            var operation = InputFactory.Operation("customAction", path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/someAction");
            var serviceMethod = InputFactory.BasicServiceMethod(
                name: "CustomAction",
                operation: operation);
            var resourceMethod = new ResourceMethod(
                ResourceOperationKind.Action,
                serviceMethod,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/someAction",
                ResourceScope.ResourceGroup,
                null,
                InputFactory.Client("VirtualMachines"));
            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}";

            // Act
            var result = ResourceHelpers.IsOperatingOnCurrentResource(resourceMethod, resourceIdPattern);

            // Assert
            Assert.IsTrue(result);
        }

        [TestCase]
        public void IsOperatingOnCurrentResource_ForCreate_ReturnsTrue()
        {
            // Arrange - Create operations always return true regardless of path
            var operation = InputFactory.Operation("createOrUpdate", path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}");
            var serviceMethod = InputFactory.BasicServiceMethod(
                name: "CreateOrUpdate",
                operation: operation);
            var resourceMethod = new ResourceMethod(
                ResourceOperationKind.Create,
                serviceMethod,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}",
                ResourceScope.ResourceGroup,
                null,
                InputFactory.Client("VirtualMachines"));
            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}";

            // Act
            var result = ResourceHelpers.IsOperatingOnCurrentResource(resourceMethod, resourceIdPattern);

            // Assert
            Assert.IsTrue(result);
        }

        [TestCase]
        public void IsOperatingOnCurrentResource_ForUpdate_ReturnsTrue()
        {
            // Arrange - Update operations always return true regardless of path
            var operation = InputFactory.Operation("update", path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}");
            var serviceMethod = InputFactory.BasicServiceMethod(
                name: "Update",
                operation: operation);
            var resourceMethod = new ResourceMethod(
                ResourceOperationKind.Update,
                serviceMethod,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}",
                ResourceScope.ResourceGroup,
                null,
                InputFactory.Client("VirtualMachines"));
            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}";

            // Act
            var result = ResourceHelpers.IsOperatingOnCurrentResource(resourceMethod, resourceIdPattern);

            // Assert
            Assert.IsTrue(result);
        }

        [TestCase("Read", false, false, true, ExpectedResult = "Get")]
        [TestCase("Read", false, false, false, ExpectedResult = null)]
        [TestCase("Read", true, false, true, ExpectedResult = "GetAsync")]
        [TestCase("Read", true, false, false, ExpectedResult = null)]
        [TestCase("List", false, true, false, ExpectedResult = null)]
        [TestCase("List", true, true, false, ExpectedResult = null)]
        [TestCase("List", false, true, true, ExpectedResult = "GetAll")]
        [TestCase("List", true, true, true, ExpectedResult = "GetAllAsync")]
        [TestCase("Delete", false, false, true, ExpectedResult = "Delete")]
        [TestCase("Delete", false, false, false, ExpectedResult = null)]
        [TestCase("Delete", true, false, true, ExpectedResult = "DeleteAsync")]
        [TestCase("Delete", true, false, false, ExpectedResult = null)]
        public string? GetOperationMethodName_ReturnsExpectedMethodName(
            string operationKindString,
            bool isAsync,
            bool isResourceCollection,
            bool isOperatingOnCurrentResource)
        {
            var operationKind = Enum.Parse<ResourceOperationKind>(operationKindString);
            return ResourceHelpers.GetOperationMethodName(operationKind, isAsync, isResourceCollection, isOperatingOnCurrentResource);
        }
    }
}
