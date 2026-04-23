// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            Assert.That(result, Is.EqualTo("GetFoo"));
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
            Assert.That(result, Is.EqualTo("GetBar"));
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
            Assert.That(result, Is.EqualTo("GetBaz"));
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
            Assert.That(result, Is.EqualTo("Foos_Get"));
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
            Assert.That(result, Is.EqualTo("Bars_Get"));
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
            Assert.That(result, Is.EqualTo("Foos_ListBySubscription"));
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
            Assert.That(result, Is.EqualTo("MgmtTypeSpec_PreviewActions"));
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
            Assert.That(result, Is.EqualTo("Resources_Delete"));
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
            Assert.That(result, Is.EqualTo("Resources_Get"));
        }
    }
}
