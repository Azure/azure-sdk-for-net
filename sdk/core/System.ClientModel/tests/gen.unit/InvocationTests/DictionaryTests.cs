// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit.InvocationTests
{
    internal class DictionaryTests : InvocationTestBase
    {
        protected override string TypeStringFormat => "Dictionary<string, {0}>";

        protected override List<TypeValidation> TypeValidations => [AssertDictionary];

        private static void AssertDictionary(ModelExpectation expectation, bool invocationDuped, Dictionary<string, TypeBuilderSpec> dict)
        {
            TypeBuilderSpec dictionaryType = ValidateBuilder(expectation.Namespace, expectation, dict);

            if (invocationDuped)
            {
                var dupedDictionaryType = ValidateBuilder("TestProject1", expectation, dict);
            }

            Assert.That(dict.TryGetValue($"{expectation.Namespace}.{expectation.TypeName}", out var itemModel), Is.True);
            Assert.That(dictionaryType.Type.ItemType, Is.EqualTo(itemModel!.Type));
            expectation.ModelValidation(itemModel);
        }

        private static TypeBuilderSpec ValidateBuilder(string lookupName, ModelExpectation expectation, Dictionary<string, TypeBuilderSpec> dict)
        {
            Assert.That(dict.TryGetValue($"{lookupName}.Dictionary<string, {expectation.TypeName}>", out var dictionaryType), Is.True);
            Assert.That(dictionaryType!.Type.Name, Is.EqualTo($"Dictionary<string, {expectation.TypeName}>"));
            Assert.That(dictionaryType.Type.Namespace, Is.EqualTo("System.Collections.Generic"));
            Assert.That(dictionaryType.Type.ItemType, Is.Not.Null);
            Assert.That(dictionaryType.Kind, Is.EqualTo(TypeBuilderKind.IDictionary));
            Assert.That(dictionaryType.Type.TypeCaseName, Is.EqualTo($"Dictionary_string_{expectation.TypeName}_"));
            Assert.That(dictionaryType.Type.CamelCaseName, Is.EqualTo($"dictionary_string_{expectation.TypeName}_"));
            Assert.That(dictionaryType.ContextType, Is.EqualTo(s_localContext));
            return dictionaryType;
        }
    }
}
