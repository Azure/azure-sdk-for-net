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

        private static void AssertDictionary(string type, string expectedNamespace, Action<TypeRef> modelValidator, Dictionary<string, TypeBuilderSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey($"Dictionary<string, {type}>"));
            var firstType = dict[$"Dictionary<string, {type}>"];
            Assert.AreEqual($"Dictionary<string, {type}>", firstType.Type.Name);
            Assert.AreEqual("System.Collections.Generic", firstType.Type.Namespace);
            Assert.IsNotNull(firstType.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.IDictionary, firstType.Kind);

            var genericArgument = firstType.Type.ItemType!;
            modelValidator(genericArgument);
        }
    }
}
