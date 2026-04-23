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

        [TestCase(ResourceOperationKind.List, true, "GetFoosAsync")]
        [TestCase(ResourceOperationKind.List, false, "GetFoos")]
        [TestCase(ResourceOperationKind.Read, true, "GetFooAsync")]
        [TestCase(ResourceOperationKind.Read, false, "GetFoo")]
        [TestCase(ResourceOperationKind.Create, true, "CreateOrUpdateFooAsync")]
        [TestCase(ResourceOperationKind.Create, false, "CreateOrUpdateFoo")]
        [TestCase(ResourceOperationKind.Delete, true, "DeleteFooAsync")]
        [TestCase(ResourceOperationKind.Delete, false, "DeleteFoo")]
        [TestCase(ResourceOperationKind.Update, true, "UpdateFooAsync")]
        [TestCase(ResourceOperationKind.Update, false, "UpdateFoo")]
        public void GetExtensionOperationMethodName_WithoutClientNameOverride_UsesHardcodedPattern(ResourceOperationKind kind, bool isAsync, string expected)
        {
            // When the operation's OriginalName matches the spec-side op name from CrossLanguageDefinitionId,
            // there is no @@clientName override and the hardcoded naming pattern is used. This also covers
            // the case of TCGC's automatic ARM list renames (e.g. listBySubscription -> GetBySubscription),
            // which appear as differences between Operation.Name and Operation.OriginalName but are NOT user
            // intent and should still fall through to the canonical pattern.
            var operation = InputFactory.Operation("GetBySubscription", originalName: "listBySubscription");
            var serviceMethod = InputFactory.BasicServiceMethod(
                name: "GetBySubscription",
                operation: operation,
                crossLanguageDefinitionId: "MgmtTypeSpec.Foos.listBySubscription");

            var result = ResourceHelpers.GetExtensionOperationMethodName(serviceMethod, kind, "Foo", isAsync);

            Assert.AreEqual(expected, result);
        }

        [TestCase(true, "GetFrontDoorWebApplicationFirewallPoliciesByFrontDoorWebApplicationFirewallPolicyAsync")]
        [TestCase(false, "GetFrontDoorWebApplicationFirewallPoliciesByFrontDoorWebApplicationFirewallPolicy")]
        public void GetExtensionOperationMethodName_WithClientNameOverride_UsesOverride(bool isAsync, string expected)
        {
            // Simulates @@clientName(WebApplicationFirewallPolicies.listBySubscription,
            //   "GetFrontDoorWebApplicationFirewallPoliciesByFrontDoorWebApplicationFirewallPolicy", "csharp").
            // Operation.OriginalName reflects the user-specified override, which differs from the
            // spec-side op name in CrossLanguageDefinitionId. The generated extension method should
            // honor this override rather than falling through to the hardcoded "Get{Resource}s" pattern.
            const string overrideName = "GetFrontDoorWebApplicationFirewallPoliciesByFrontDoorWebApplicationFirewallPolicy";
            var operation = InputFactory.Operation(overrideName, originalName: overrideName);
            var serviceMethod = InputFactory.BasicServiceMethod(
                name: overrideName,
                operation: operation,
                crossLanguageDefinitionId: "FrontDoor.WebApplicationFirewallPolicies.listBySubscription");

            var result = ResourceHelpers.GetExtensionOperationMethodName(
                serviceMethod,
                ResourceOperationKind.List,
                "FrontDoorWebApplicationFirewallPolicy",
                isAsync);

            Assert.AreEqual(expected, result);
        }

        [TestCase]
        public void GetExtensionOperationMethodName_WithMissingOriginalName_UsesHardcodedPattern()
        {
            // When OriginalName is not populated by the input source (e.g. older code models), the
            // detector returns false to preserve backwards-compatible behavior.
            var operation = InputFactory.Operation("list");
            var serviceMethod = InputFactory.BasicServiceMethod(
                name: "List",
                operation: operation,
                crossLanguageDefinitionId: "MgmtTypeSpec.Foos.list");

            var result = ResourceHelpers.GetExtensionOperationMethodName(
                serviceMethod,
                ResourceOperationKind.List,
                "Foo",
                isAsync: false);

            Assert.AreEqual("GetFoos", result);
        }
    }
}
