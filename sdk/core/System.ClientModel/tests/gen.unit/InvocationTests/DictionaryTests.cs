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

            Assert.IsTrue(dict.TryGetValue($"{expectation.Namespace}.{expectation.TypeName}", out var itemModel));
            Assert.AreEqual(itemModel!.Type, dictionaryType.Type.ItemType);
            expectation.ModelValidation(itemModel);
        }

        private static TypeBuilderSpec ValidateBuilder(string lookupName, ModelExpectation expectation, Dictionary<string, TypeBuilderSpec> dict)
        {
            Assert.IsTrue(dict.TryGetValue($"{lookupName}.Dictionary<string, {expectation.TypeName}>", out var dictionaryType));
            Assert.AreEqual($"Dictionary<string, {expectation.TypeName}>", dictionaryType!.Type.Name);
            Assert.AreEqual("System.Collections.Generic", dictionaryType.Type.Namespace);
            Assert.IsNotNull(dictionaryType.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.IDictionary, dictionaryType.Kind);
            Assert.AreEqual($"Dictionary_string_{expectation.TypeName}_", dictionaryType.Type.TypeCaseName);
            Assert.AreEqual($"dictionary_string_{expectation.TypeName}_", dictionaryType.Type.CamelCaseName);
            Assert.AreEqual(s_localContext, dictionaryType.ContextType);
            return dictionaryType;
        }
    }
}
