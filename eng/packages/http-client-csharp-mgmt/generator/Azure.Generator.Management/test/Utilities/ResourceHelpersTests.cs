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
        public void IsDeletingCurrentResource_WhenOperationPathMatchesResourceIdPattern_ReturnsTrue()
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
#pragma warning disable CS0618 // Type or member is obsolete
            var result = ResourceHelpers.IsDeletingCurrentResource(resourceMethod, resourceIdPattern);
#pragma warning restore CS0618 // Type or member is obsolete

            // Assert
            Assert.IsTrue(result);
        }

        [TestCase]
        public void IsDeletingCurrentResource_WhenOperationPathDifferentFromResourceIdPattern_ReturnsFalse()
        {
            // Arrange
            var operation = InputFactory.Operation("deleteChildResource", path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/childResources/{childName}");
            var serviceMethod = InputFactory.BasicServiceMethod(
                name: "DeleteChildResource",
                operation: operation);
            var resourceMethod = new ResourceMethod(
                ResourceOperationKind.Delete,
                serviceMethod,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/childResources/{childName}",
                ResourceScope.ResourceGroup,
                null,
                InputFactory.Client("VirtualMachines"));
            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}";

            // Act
#pragma warning disable CS0618 // Type or member is obsolete
            var result = ResourceHelpers.IsDeletingCurrentResource(resourceMethod, resourceIdPattern);
#pragma warning restore CS0618 // Type or member is obsolete

            // Assert
            Assert.IsFalse(result);
        }

        [TestCase]
        public void IsDeletingCurrentResource_WithDifferentParameterNames_ReturnsTrue()
        {
            // Arrange
            // The operation path has different parameter names but same structure
            var operation = InputFactory.Operation("delete", path: "/subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Compute/virtualMachines/{name}");
            var serviceMethod = InputFactory.BasicServiceMethod(
                name: "Delete",
                operation: operation);
            var resourceMethod = new ResourceMethod(
                ResourceOperationKind.Delete,
                serviceMethod,
                "/subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Compute/virtualMachines/{name}",
                ResourceScope.ResourceGroup,
                null,
                InputFactory.Client("VirtualMachines"));
            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}";

            // Act
#pragma warning disable CS0618 // Type or member is obsolete
            var result = ResourceHelpers.IsDeletingCurrentResource(resourceMethod, resourceIdPattern);
#pragma warning restore CS0618 // Type or member is obsolete

            // Assert
            Assert.IsTrue(result);
        }

        [TestCase]
        public void IsDeletingCurrentResource_WhenNotDeleteOperation_ReturnsTrue()
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
#pragma warning disable CS0618 // Type or member is obsolete
            var result = ResourceHelpers.IsDeletingCurrentResource(resourceMethod, resourceIdPattern);
#pragma warning restore CS0618 // Type or member is obsolete

            // Assert
            Assert.IsTrue(result); // Changed: obsolete method now delegates to IsOperatingOnCurrentResource which returns true for matching Read operations
        }

        [TestCase]
        public void GetOperationMethodName_ForRead_WhenOperatingOnCurrentResource_ReturnsGet()
        {
            // Act
            var result = ResourceHelpers.GetOperationMethodName(ResourceOperationKind.Read, false, false, isOperatingOnCurrentResource: true);

            // Assert
            Assert.AreEqual("Get", result);
        }

        [TestCase]
        public void GetOperationMethodName_ForRead_WhenOperatingOnOtherResource_ReturnsNull()
        {
            // Act
            var result = ResourceHelpers.GetOperationMethodName(ResourceOperationKind.Read, false, false, isOperatingOnCurrentResource: false);

            // Assert
            Assert.IsNull(result);
        }

        [TestCase]
        public void GetOperationMethodName_ForReadAsync_WhenOperatingOnCurrentResource_ReturnsGetAsync()
        {
            // Act
            var result = ResourceHelpers.GetOperationMethodName(ResourceOperationKind.Read, true, false, isOperatingOnCurrentResource: true);

            // Assert
            Assert.AreEqual("GetAsync", result);
        }

        [TestCase]
        public void GetOperationMethodName_ForReadAsync_WhenOperatingOnOtherResource_ReturnsNull()
        {
            // Act
            var result = ResourceHelpers.GetOperationMethodName(ResourceOperationKind.Read, true, false, isOperatingOnCurrentResource: false);

            // Assert
            Assert.IsNull(result);
        }

        [TestCase]
        public void GetOperationMethodName_ForList_WhenOperatingOnOtherResource_ReturnsNull()
        {
            // Act
            var result = ResourceHelpers.GetOperationMethodName(ResourceOperationKind.List, false, true, isOperatingOnCurrentResource: false);

            // Assert
            Assert.IsNull(result);
        }

        [TestCase]
        public void GetOperationMethodName_ForListAsync_WhenOperatingOnOtherResource_ReturnsNull()
        {
            // Act
            var result = ResourceHelpers.GetOperationMethodName(ResourceOperationKind.List, true, true, isOperatingOnCurrentResource: false);

            // Assert
            Assert.IsNull(result);
        }

        [TestCase]
        public void GetOperationMethodName_ForDelete_WhenOperatingOnCurrentResource_ReturnsDelete()
        {
            // Act
            var result = ResourceHelpers.GetOperationMethodName(ResourceOperationKind.Delete, false, false, isOperatingOnCurrentResource: true);

            // Assert
            Assert.AreEqual("Delete", result);
        }

        [TestCase]
        public void GetOperationMethodName_ForDelete_WhenOperatingOnOtherResource_ReturnsNull()
        {
            // Act
            var result = ResourceHelpers.GetOperationMethodName(ResourceOperationKind.Delete, false, false, isOperatingOnCurrentResource: false);

            // Assert
            Assert.IsNull(result);
        }

        [TestCase]
        public void GetOperationMethodName_ForDeleteAsync_WhenOperatingOnCurrentResource_ReturnsDeleteAsync()
        {
            // Act
            var result = ResourceHelpers.GetOperationMethodName(ResourceOperationKind.Delete, true, false, isOperatingOnCurrentResource: true);

            // Assert
            Assert.AreEqual("DeleteAsync", result);
        }

        [TestCase]
        public void GetOperationMethodName_ForDeleteAsync_WhenOperatingOnOtherResource_ReturnsNull()
        {
            // Act
            var result = ResourceHelpers.GetOperationMethodName(ResourceOperationKind.Delete, true, false, isOperatingOnCurrentResource: false);

            // Assert
            Assert.IsNull(result);
        }
    }
}
