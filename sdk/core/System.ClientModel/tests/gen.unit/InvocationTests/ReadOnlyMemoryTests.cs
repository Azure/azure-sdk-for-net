// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit.InvocationTests
{
    internal class ReadOnlyMemoryTests : InvocationTestBase
    {
        protected override string TypeStringFormat => "ReadOnlyMemory<{0}>";

        protected override List<TypeValidation> TypeValidations => [AssertReadOnlyMemory];

        private void AssertReadOnlyMemory(string type, Action<TypeRef> modelValidator, Dictionary<string, TypeBuilderSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey($"ReadOnlyMemory<{type}>"));
            var arrayJsonModel = dict[$"ReadOnlyMemory<{type}>"];
            Assert.AreEqual($"ReadOnlyMemory<{type}>", arrayJsonModel.Type.Name);
            Assert.AreEqual("System", arrayJsonModel.Type.Namespace);
            Assert.AreEqual(1, arrayJsonModel.Type.GenericArguments.Count);
            Assert.AreEqual(TypeBuilderKind.ReadOnlyMemory, arrayJsonModel.Kind);

            var genericArgument = arrayJsonModel.Type.GenericArguments[0];
            modelValidator(genericArgument);
        }
    }
}
