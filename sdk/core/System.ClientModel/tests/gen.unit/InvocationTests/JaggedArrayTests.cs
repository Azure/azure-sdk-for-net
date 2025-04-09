// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit.InvocationTests
{
    internal class JaggedArrayTests : InvocationTestBase
    {
        protected override string TypeStringFormat => "{0}[][]";

        protected override List<TypeValidation> TypeValidations => [AssertJaggedArray, ArrayTests.AssertArray];

        protected override string InitializeObject => "new {0} {{ }}";

        private void AssertJaggedArray(ModelExpectation expectation, Dictionary<string, TypeBuilderSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey($"{expectation.TypeName}[][]"));
            var arrayArrayModel = dict[$"{expectation.TypeName}[][]"];
            Assert.AreEqual($"{expectation.TypeName}[][]", arrayArrayModel.Type.Name);
            Assert.AreEqual(expectation.Namespace, arrayArrayModel.Type.Namespace);
            Assert.IsNotNull(arrayArrayModel.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.Array, arrayArrayModel.Kind);
            Assert.AreEqual(1, arrayArrayModel.Type.ArrayRank);
            Assert.AreEqual($"{expectation.TypeName}_Array_Array_", arrayArrayModel.Type.TypeCaseName);
            Assert.AreEqual($"{char.ToLower(expectation.TypeName[0])}{expectation.TypeName.Substring(1)}_Array_Array_", arrayArrayModel.Type.CamelCaseName);
            Assert.AreEqual(expectation.Context, arrayArrayModel.ContextType);

            var genericArgument = arrayArrayModel.Type.ItemType!;
            Assert.AreEqual($"{expectation.TypeName}[]", genericArgument.Name);
            Assert.AreEqual(expectation.Namespace, genericArgument.Namespace);
            Assert.IsNotNull(genericArgument.ItemType);
            Assert.AreEqual(1, genericArgument.ArrayRank);
            Assert.AreEqual($"{expectation.TypeName}_Array_", genericArgument.TypeCaseName);
            Assert.AreEqual($"{char.ToLower(expectation.TypeName[0])}{expectation.TypeName.Substring(1)}_Array_", genericArgument.CamelCaseName);

            var arrayModel = dict[$"{expectation.TypeName}[]"];
            Assert.AreEqual($"{expectation.TypeName}[]", arrayModel.Type.Name);
            Assert.AreEqual(expectation.Namespace, arrayModel.Type.Namespace);
            Assert.IsNotNull(arrayModel.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.Array, arrayModel.Kind);
            Assert.AreEqual(1, arrayModel.Type.ArrayRank);
            Assert.AreEqual($"{expectation.TypeName}_Array_", arrayModel.Type.TypeCaseName);
            Assert.AreEqual($"{char.ToLower(expectation.TypeName[0])}{expectation.TypeName.Substring(1)}_Array_", arrayModel.Type.CamelCaseName);
            Assert.AreEqual(expectation.Context, arrayModel.ContextType);

            var itemModel = dict[expectation.TypeName];
            Assert.IsNotNull(itemModel);
            Assert.AreEqual(itemModel.Type, arrayModel.Type.ItemType);
            expectation.ModelValidation(itemModel);
        }
    }
}
