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

            Assert.That(dict.TryGetValue($"{expectation.Namespace}.{expectation.TypeName}", out var itemModel), Is.True);
            Assert.That(romJsonModel.Type.ItemType, Is.EqualTo(itemModel!.Type));
            expectation.ModelValidation(itemModel);
        }

        private static TypeBuilderSpec ValidateBuilder(string lookupName, ModelExpectation expectation, Dictionary<string, TypeBuilderSpec> dict)
        {
            Assert.That(dict.TryGetValue($"{lookupName}.ReadOnlyMemory<{expectation.TypeName}>", out var romJsonModel), Is.True);
            Assert.That(romJsonModel!.Type.Name, Is.EqualTo($"ReadOnlyMemory<{expectation.TypeName}>"));
            Assert.That(romJsonModel.Type.Namespace, Is.EqualTo("System"));
            Assert.That(romJsonModel.Type.ItemType, Is.Not.Null);
            Assert.That(romJsonModel.Kind, Is.EqualTo(TypeBuilderKind.ReadOnlyMemory));
            Assert.That(romJsonModel.Type.TypeCaseName, Is.EqualTo($"ReadOnlyMemory_{expectation.TypeName}_"));
            Assert.That(romJsonModel.Type.CamelCaseName, Is.EqualTo($"readOnlyMemory_{expectation.TypeName}_"));
            Assert.That(romJsonModel.Type.ArrayRank, Is.EqualTo(0));
            Assert.That(romJsonModel.ContextType, Is.EqualTo(s_localContext));
            return romJsonModel;
        }
    }
}
