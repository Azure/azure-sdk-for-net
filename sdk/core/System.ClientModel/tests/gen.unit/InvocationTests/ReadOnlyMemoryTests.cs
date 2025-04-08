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

        private void AssertReadOnlyMemory(string type, string expectedNamespace, Action<TypeRef> modelValidator, Dictionary<string, TypeBuilderSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey($"ReadOnlyMemory<{type}>"));
            var romJsonModel = dict[$"ReadOnlyMemory<{type}>"];
            Assert.AreEqual($"ReadOnlyMemory<{type}>", romJsonModel.Type.Name);
            Assert.AreEqual("System", romJsonModel.Type.Namespace);
            Assert.IsNotNull(romJsonModel.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.ReadOnlyMemory, romJsonModel.Kind);
            Assert.AreEqual($"ReadOnlyMemory_{type}_", romJsonModel.Type.TypeCaseName);
            Assert.AreEqual($"readOnlyMemory_{type}_", romJsonModel.Type.CamelCaseName);
            Assert.AreEqual(0, romJsonModel.Type.ArrayRank);

            var genericArgument = romJsonModel.Type.ItemType!;
            modelValidator(genericArgument);
        }
    }
}
