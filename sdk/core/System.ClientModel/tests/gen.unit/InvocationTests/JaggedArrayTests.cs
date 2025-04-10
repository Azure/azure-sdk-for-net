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
            Assert.IsTrue(dict.TryGetValue($"{expectation.Namespace}.{expectation.TypeName}[][]", out var arrayArrayModel));
            Assert.AreEqual($"{expectation.TypeName}[][]", arrayArrayModel!.Type.Name);
            Assert.AreEqual(expectation.Namespace, arrayArrayModel.Type.Namespace);
            Assert.IsNotNull(arrayArrayModel.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.Array, arrayArrayModel.Kind);
            Assert.AreEqual(1, arrayArrayModel.Type.ArrayRank);
            Assert.AreEqual($"{expectation.TypeName}_Array_Array_", arrayArrayModel.Type.TypeCaseName);
            Assert.AreEqual($"{char.ToLower(expectation.TypeName[0])}{expectation.TypeName.Substring(1)}_Array_Array_", arrayArrayModel.Type.CamelCaseName);
            Assert.AreEqual(expectation.Context, arrayArrayModel.ContextType);
            Assert.IsNull(arrayArrayModel.Type.Alias);

            var genericArgument = arrayArrayModel.Type.ItemType!;
            Assert.AreEqual($"{expectation.TypeName}[]", genericArgument.Name);
            Assert.AreEqual(expectation.Namespace, genericArgument.Namespace);
            Assert.IsNotNull(genericArgument.ItemType);
            Assert.AreEqual(1, genericArgument.ArrayRank);
            Assert.AreEqual($"{expectation.TypeName}_Array_", genericArgument.TypeCaseName);
            Assert.AreEqual($"{char.ToLower(expectation.TypeName[0])}{expectation.TypeName.Substring(1)}_Array_", genericArgument.CamelCaseName);

            Assert.IsTrue(dict.TryGetValue($"{expectation.Namespace}.{expectation.TypeName}[]", out var arrayModel));
            Assert.AreEqual($"{expectation.TypeName}[]", arrayModel!.Type.Name);
            Assert.AreEqual(expectation.Namespace, arrayModel.Type.Namespace);
            Assert.IsNotNull(arrayModel.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.Array, arrayModel.Kind);
            Assert.AreEqual(1, arrayModel.Type.ArrayRank);
            Assert.AreEqual($"{expectation.TypeName}_Array_", arrayModel.Type.TypeCaseName);
            Assert.AreEqual($"{char.ToLower(expectation.TypeName[0])}{expectation.TypeName.Substring(1)}_Array_", arrayModel.Type.CamelCaseName);
            Assert.AreEqual(expectation.Context, arrayModel.ContextType);
            Assert.IsNull(arrayModel.Type.Alias);

            if (invocationDuped)
            {
                Assert.IsTrue(dict.TryGetValue($"TestProject1.{expectation.TypeName}[][]", out var dupedArrayArrayModel));
                Assert.AreEqual($"{expectation.TypeName}[][]", dupedArrayArrayModel!.Type.Name);
                Assert.AreEqual("TestProject1", dupedArrayArrayModel.Type.Namespace);
                Assert.IsNotNull(dupedArrayArrayModel.Type.ItemType);
                Assert.AreEqual(TypeBuilderKind.Array, dupedArrayArrayModel.Kind);
                Assert.AreEqual(1, dupedArrayArrayModel.Type.ArrayRank);
                Assert.AreEqual($"{expectation.TypeName}_Array_Array_", dupedArrayArrayModel.Type.TypeCaseName);
                Assert.AreEqual($"{char.ToLower(expectation.TypeName[0])}{expectation.TypeName.Substring(1)}_Array_Array_", dupedArrayArrayModel.Type.CamelCaseName);
                Assert.AreEqual(expectation.Context, dupedArrayArrayModel.ContextType);
                Assert.IsNotNull(dupedArrayArrayModel.Type.Alias);
                Assert.AreEqual($"{expectation.TypeName}_0[][]", dupedArrayArrayModel.Type.Alias);

                var dupedGenericArgument = dupedArrayArrayModel.Type.ItemType!;
                Assert.AreEqual($"{expectation.TypeName}[]", dupedGenericArgument.Name);
                Assert.AreEqual("TestProject1", dupedGenericArgument.Namespace);
                Assert.IsNotNull(dupedGenericArgument.ItemType);
                Assert.AreEqual(1, dupedGenericArgument.ArrayRank);
                Assert.AreEqual($"{expectation.TypeName}_Array_", dupedGenericArgument.TypeCaseName);
                Assert.AreEqual($"{char.ToLower(expectation.TypeName[0])}{expectation.TypeName.Substring(1)}_Array_", dupedGenericArgument.CamelCaseName);

                Assert.IsTrue(dict.TryGetValue($"TestProject1.{expectation.TypeName}[]", out var dupedArrayModel));
                Assert.AreEqual($"{expectation.TypeName}[]", dupedArrayModel!.Type.Name);
                Assert.AreEqual("TestProject1", dupedArrayModel.Type.Namespace);
                Assert.IsNotNull(dupedArrayModel.Type.ItemType);
                Assert.AreEqual(TypeBuilderKind.Array, dupedArrayModel.Kind);
                Assert.AreEqual(1, dupedArrayModel.Type.ArrayRank);
                Assert.AreEqual($"{expectation.TypeName}_Array_", dupedArrayModel.Type.TypeCaseName);
                Assert.AreEqual($"{char.ToLower(expectation.TypeName[0])}{expectation.TypeName.Substring(1)}_Array_", dupedArrayModel.Type.CamelCaseName);
                Assert.AreEqual(expectation.Context, dupedArrayModel.ContextType);
                Assert.IsNotNull(dupedArrayModel.Type.Alias);
                Assert.AreEqual($"{expectation.TypeName}_0[]", dupedArrayModel.Type.Alias);
            }

            Assert.IsTrue(dict.TryGetValue($"{expectation.Namespace}.{expectation.TypeName}", out var itemModel));
            Assert.AreEqual(itemModel!.Type, arrayModel.Type.ItemType);
            expectation.ModelValidation(itemModel);
        }
    }
}
