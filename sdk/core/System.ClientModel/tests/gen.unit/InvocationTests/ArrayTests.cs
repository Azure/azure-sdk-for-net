// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit.InvocationTests
{
    internal class ArrayTests : InvocationTestBase
    {
        protected override List<TypeValidation> TypeValidations => [AssertArray];

        protected override string TypeStringFormat => "{0}[]";

        protected override string InitializeObject => "new {0} {{ }}";

        internal static void AssertArray(ModelExpectation expectation, Dictionary<string, TypeBuilderSpec> dict)
        {
            Assert.IsTrue(dict.TryGetValue($"{expectation.Namespace}.{expectation.TypeName}[]", out var arrayModel));
            Assert.AreEqual($"{expectation.TypeName}[]", arrayModel!.Type.Name);
            Assert.AreEqual(expectation.Namespace, arrayModel.Type.Namespace);
            Assert.IsNotNull(arrayModel.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.Array, arrayModel.Kind);
            Assert.AreEqual(1, arrayModel.Type.ArrayRank);
            Assert.AreEqual($"{expectation.TypeName}_Array_", arrayModel.Type.TypeCaseName);
            Assert.AreEqual($"{char.ToLower(expectation.TypeName[0])}{expectation.TypeName.Substring(1)}_Array_", arrayModel.Type.CamelCaseName);
            Assert.AreEqual(expectation.Context, arrayModel.ContextType);

            Assert.IsTrue(dict.TryGetValue($"{expectation.Namespace}.{expectation.TypeName}", out var itemModel));
            Assert.AreEqual(itemModel!.Type, arrayModel.Type.ItemType);
            expectation.ModelValidation(itemModel);
        }
    }
}
