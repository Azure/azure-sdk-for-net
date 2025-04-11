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

        private void AssertReadOnlyMemory(ModelExpectation expectation, bool invocationDuped, Dictionary<string, TypeBuilderSpec> dict)
        {
            TypeBuilderSpec romJsonModel = ValidateBuilder(expectation.Namespace, expectation, dict);

            if (invocationDuped)
            {
                var dupedRomJsonModel = ValidateBuilder("TestProject1", expectation, dict);
            }

            Assert.IsTrue(dict.TryGetValue($"{expectation.Namespace}.{expectation.TypeName}", out var itemModel));
            Assert.AreEqual(itemModel!.Type, romJsonModel.Type.ItemType);
            expectation.ModelValidation(itemModel);
        }

        private static TypeBuilderSpec ValidateBuilder(string lookupName, ModelExpectation expectation, Dictionary<string, TypeBuilderSpec> dict)
        {
            Assert.IsTrue(dict.TryGetValue($"{lookupName}.ReadOnlyMemory<{expectation.TypeName}>", out var romJsonModel));
            Assert.AreEqual($"ReadOnlyMemory<{expectation.TypeName}>", romJsonModel!.Type.Name);
            Assert.AreEqual("System", romJsonModel.Type.Namespace);
            Assert.IsNotNull(romJsonModel.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.ReadOnlyMemory, romJsonModel.Kind);
            Assert.AreEqual($"ReadOnlyMemory_{expectation.TypeName}_", romJsonModel.Type.TypeCaseName);
            Assert.AreEqual($"readOnlyMemory_{expectation.TypeName}_", romJsonModel.Type.CamelCaseName);
            Assert.AreEqual(0, romJsonModel.Type.ArrayRank);
            Assert.AreEqual(s_localContext, romJsonModel.ContextType);
            return romJsonModel;
        }
    }
}
