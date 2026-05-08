// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Azure.Generator.Mgmt.Tests
{
    internal class ClientNameOverrideHelperTests
    {
        private const string MarkerName = "Azure.ResourceManager.@hasClientNameOverride";

        private static InputDecoratorInfo MarkerDecorator() =>
            new InputDecoratorInfo(MarkerName, new Dictionary<string, BinaryData>());

        private static InputDecoratorInfo UnrelatedDecorator() =>
            new InputDecoratorInfo("Some.Other.@decorator", new Dictionary<string, BinaryData>());

        // ---- InputModelType overload ----

        [Test]
        public void Model_ReturnsFalse_WhenDecoratorAbsent()
        {
            var model = InputFactory.Model("MyResourceUpdate");

            Assert.That(ClientNameOverrideHelper.HasUserProvidedClientName(model), Is.False);
        }

        [Test]
        public void Model_ReturnsTrue_WhenMarkerPresent()
        {
            var model = InputFactory.Model(
                "CustomPatchName",
                decorators: [MarkerDecorator()]);

            Assert.That(ClientNameOverrideHelper.HasUserProvidedClientName(model), Is.True);
        }

        [Test]
        public void Model_IgnoresUnrelatedDecorators()
        {
            var model = InputFactory.Model(
                "MyResourceUpdate",
                decorators: [UnrelatedDecorator()]);

            Assert.That(ClientNameOverrideHelper.HasUserProvidedClientName(model), Is.False);
        }

        // ---- InputServiceMethod overload (marker lives on InputOperation.Decorators) ----

        [Test]
        public void Method_ReturnsFalse_WhenDecoratorAbsent()
        {
            var operation = InputFactory.Operation(name: "list", path: "/foo");
            var method = InputFactory.BasicServiceMethod("List", operation);

            Assert.That(ClientNameOverrideHelper.HasUserProvidedClientName(method), Is.False);
        }

        [Test]
        public void Method_ReturnsTrue_WhenMarkerPresent()
        {
            var operation = InputFactory.Operation(
                name: "list",
                path: "/foo",
                decorators: [MarkerDecorator()]);
            var method = InputFactory.BasicServiceMethod("ListDeleted", operation);

            Assert.That(ClientNameOverrideHelper.HasUserProvidedClientName(method), Is.True);
        }

        [Test]
        public void Method_IgnoresUnrelatedDecorators()
        {
            var operation = InputFactory.Operation(
                name: "list",
                path: "/foo",
                decorators: [UnrelatedDecorator()]);
            var method = InputFactory.BasicServiceMethod("List", operation);

            Assert.That(ClientNameOverrideHelper.HasUserProvidedClientName(method), Is.False);
        }
    }
}
