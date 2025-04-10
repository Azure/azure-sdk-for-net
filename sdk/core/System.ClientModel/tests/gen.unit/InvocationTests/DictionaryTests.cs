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
            Assert.IsTrue(dict.TryGetValue($"{expectation.Namespace}.Dictionary<string, {expectation.TypeName}>", out var dictionaryType));
            Assert.AreEqual($"Dictionary<string, {expectation.TypeName}>", dictionaryType!.Type.Name);
            Assert.AreEqual("System.Collections.Generic", dictionaryType.Type.Namespace);
            Assert.IsNotNull(dictionaryType.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.IDictionary, dictionaryType.Kind);
            Assert.AreEqual($"Dictionary_string_{expectation.TypeName}_", dictionaryType.Type.TypeCaseName);
            Assert.AreEqual($"dictionary_string_{expectation.TypeName}_", dictionaryType.Type.CamelCaseName);
            Assert.AreEqual(s_localContext, dictionaryType.ContextType);
            Assert.IsNull(dictionaryType.Type.Alias);

            if (invocationDuped)
            {
                Assert.IsTrue(dict.TryGetValue($"TestProject1.Dictionary<string, {expectation.TypeName}>", out var dupedDictionaryType));
                Assert.AreEqual($"Dictionary<string, {expectation.TypeName}>", dupedDictionaryType!.Type.Name);
                Assert.AreEqual("System.Collections.Generic", dupedDictionaryType.Type.Namespace);
                Assert.IsNotNull(dupedDictionaryType.Type.ItemType);
                Assert.AreEqual(TypeBuilderKind.IDictionary, dupedDictionaryType.Kind);
                Assert.AreEqual($"Dictionary_string_{expectation.TypeName}_", dupedDictionaryType.Type.TypeCaseName);
                Assert.AreEqual($"dictionary_string_{expectation.TypeName}_", dupedDictionaryType.Type.CamelCaseName);
                Assert.AreEqual(s_localContext, dupedDictionaryType.ContextType);
                Assert.IsNotNull(dupedDictionaryType.Type.Alias);
                Assert.AreEqual($"Dictionary<string, {expectation.TypeName}_0>", dupedDictionaryType.Type.Alias);
            }

            Assert.IsTrue(dict.TryGetValue($"{expectation.Namespace}.{expectation.TypeName}", out var itemModel));
            Assert.AreEqual(itemModel!.Type, dictionaryType.Type.ItemType);
            expectation.ModelValidation(itemModel);
        }
    }
}
