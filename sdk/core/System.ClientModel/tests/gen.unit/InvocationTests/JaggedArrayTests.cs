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

        private void AssertJaggedArray(ModelExpectation expectation, bool invocationDuped, Dictionary<string, TypeBuilderSpec> dict)
        {
            TypeBuilderSpec arrayArrayModel = ValidateBuilder(expectation.Namespace, expectation, dict, out var arrayModel);

            if (invocationDuped)
            {
                var dupedArrayArrayModel = ValidateBuilder("TestProject1", expectation, dict, out var dupedArrayModel);
            }

            Assert.IsTrue(dict.TryGetValue($"{expectation.Namespace}.{expectation.TypeName}", out var itemModel));
            Assert.AreEqual(itemModel!.Type, arrayModel!.Type.ItemType);
            expectation.ModelValidation(itemModel);
        }

        private static TypeBuilderSpec ValidateBuilder(string lookupName, ModelExpectation expectation, Dictionary<string, TypeBuilderSpec> dict, out TypeBuilderSpec? innerArray)
        {
            Assert.IsTrue(dict.TryGetValue($"{lookupName}.{expectation.TypeName}[][]", out var arrayArrayModel));
            Assert.AreEqual($"{expectation.TypeName}[][]", arrayArrayModel!.Type.Name);
            Assert.AreEqual(lookupName, arrayArrayModel.Type.Namespace);
            Assert.IsNotNull(arrayArrayModel.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.Array, arrayArrayModel.Kind);
            Assert.AreEqual(1, arrayArrayModel.Type.ArrayRank);
            Assert.AreEqual($"{expectation.TypeName}_Array_Array_", arrayArrayModel.Type.TypeCaseName);
            Assert.AreEqual($"{char.ToLower(expectation.TypeName[0])}{expectation.TypeName.Substring(1)}_Array_Array_", arrayArrayModel.Type.CamelCaseName);
            Assert.AreEqual(expectation.Context, arrayArrayModel.ContextType);

            var genericArgument = arrayArrayModel.Type.ItemType!;
            Assert.AreEqual($"{expectation.TypeName}[]", genericArgument.Name);
            Assert.AreEqual(lookupName, genericArgument.Namespace);
            Assert.IsNotNull(genericArgument.ItemType);
            Assert.AreEqual(1, genericArgument.ArrayRank);
            Assert.AreEqual($"{expectation.TypeName}_Array_", genericArgument.TypeCaseName);
            Assert.AreEqual($"{char.ToLower(expectation.TypeName[0])}{expectation.TypeName.Substring(1)}_Array_", genericArgument.CamelCaseName);

            Assert.IsTrue(dict.TryGetValue($"{lookupName}.{expectation.TypeName}[]", out innerArray));
            Assert.AreEqual($"{expectation.TypeName}[]", innerArray!.Type.Name);
            Assert.AreEqual(lookupName, innerArray.Type.Namespace);
            Assert.IsNotNull(innerArray.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.Array, innerArray.Kind);
            Assert.AreEqual(1, innerArray.Type.ArrayRank);
            Assert.AreEqual($"{expectation.TypeName}_Array_", innerArray.Type.TypeCaseName);
            Assert.AreEqual($"{char.ToLower(expectation.TypeName[0])}{expectation.TypeName.Substring(1)}_Array_", innerArray.Type.CamelCaseName);
            Assert.AreEqual(expectation.Context, innerArray.ContextType);
            return arrayArrayModel;
        }
    }
}
