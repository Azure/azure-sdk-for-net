// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
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
        public void GetOperationMethodName_WhenApplyMethodRenamingEnabled_ReturnsOverride()
        {
            var plugin = ManagementMockHelpers.LoadMockPlugin();
            // Default flag value is true; assert explicit-positive behavior.
            plugin.Setup(p => p.IsApplyMethodRenamingEnabled()).Returns(true);

            Assert.AreEqual("GetAsync", ResourceHelpers.GetOperationMethodName(ResourceOperationKind.Read, isAsync: true, isResourceCollection: false));
            Assert.AreEqual("Get", ResourceHelpers.GetOperationMethodName(ResourceOperationKind.Read, isAsync: false, isResourceCollection: false));
            Assert.AreEqual("GetAllAsync", ResourceHelpers.GetOperationMethodName(ResourceOperationKind.List, isAsync: true, isResourceCollection: true));
            Assert.AreEqual("CreateOrUpdate", ResourceHelpers.GetOperationMethodName(ResourceOperationKind.Create, isAsync: false, isResourceCollection: false));
            Assert.AreEqual("Delete", ResourceHelpers.GetOperationMethodName(ResourceOperationKind.Delete, isAsync: false, isResourceCollection: false));
        }

        [TestCase]
        public void GetOperationMethodName_WhenApplyMethodRenamingDisabled_ReturnsNull()
        {
            var plugin = ManagementMockHelpers.LoadMockPlugin();
            plugin.Setup(p => p.IsApplyMethodRenamingEnabled()).Returns(false);

            // All operation kinds should return null so the TypeSpec method name is used downstream.
            Assert.IsNull(ResourceHelpers.GetOperationMethodName(ResourceOperationKind.Read, isAsync: true, isResourceCollection: false));
            Assert.IsNull(ResourceHelpers.GetOperationMethodName(ResourceOperationKind.List, isAsync: true, isResourceCollection: true));
            Assert.IsNull(ResourceHelpers.GetOperationMethodName(ResourceOperationKind.Create, isAsync: false, isResourceCollection: false));
            Assert.IsNull(ResourceHelpers.GetOperationMethodName(ResourceOperationKind.Delete, isAsync: false, isResourceCollection: false));
        }

        [TestCase]
        public void GetExtensionOperationMethodName_WhenApplyMethodRenamingEnabled_ReturnsOverride()
        {
            var plugin = ManagementMockHelpers.LoadMockPlugin();
            plugin.Setup(p => p.IsApplyMethodRenamingEnabled()).Returns(true);

            Assert.AreEqual("GetAccounts", ResourceHelpers.GetExtensionOperationMethodName(ResourceOperationKind.List, "Account", isAsync: false));
            Assert.AreEqual("GetAccount", ResourceHelpers.GetExtensionOperationMethodName(ResourceOperationKind.Read, "Account", isAsync: false));
            Assert.AreEqual("CreateOrUpdateAccount", ResourceHelpers.GetExtensionOperationMethodName(ResourceOperationKind.Create, "Account", isAsync: false));
            Assert.AreEqual("DeleteAccount", ResourceHelpers.GetExtensionOperationMethodName(ResourceOperationKind.Delete, "Account", isAsync: false));
            Assert.AreEqual("UpdateAccount", ResourceHelpers.GetExtensionOperationMethodName(ResourceOperationKind.Update, "Account", isAsync: false));
        }

        [TestCase]
        public void GetExtensionOperationMethodName_WhenApplyMethodRenamingDisabled_ReturnsNull()
        {
            var plugin = ManagementMockHelpers.LoadMockPlugin();
            plugin.Setup(p => p.IsApplyMethodRenamingEnabled()).Returns(false);

            // When the flag is disabled, TypeSpec-provided method names (e.g., a user-chosen `list` that
            // should not become `GetAccounts`) flow through untouched.
            Assert.IsNull(ResourceHelpers.GetExtensionOperationMethodName(ResourceOperationKind.List, "Account", isAsync: false));
            Assert.IsNull(ResourceHelpers.GetExtensionOperationMethodName(ResourceOperationKind.Read, "Account", isAsync: false));
            Assert.IsNull(ResourceHelpers.GetExtensionOperationMethodName(ResourceOperationKind.Create, "Account", isAsync: false));
            Assert.IsNull(ResourceHelpers.GetExtensionOperationMethodName(ResourceOperationKind.Delete, "Account", isAsync: false));
            Assert.IsNull(ResourceHelpers.GetExtensionOperationMethodName(ResourceOperationKind.Update, "Account", isAsync: false));
        }
    }
}
