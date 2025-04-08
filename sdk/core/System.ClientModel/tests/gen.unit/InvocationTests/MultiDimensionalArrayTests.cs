// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit.InvocationTests
{
    internal class MultiDimensionalArrayTests : InvocationTestBase
    {
        protected override string TypeStringFormat => "{0}[,]";

        protected override List<TypeValidation> TypeValidations => [AssertMultiDimensionalArray];

        protected override string InitializeObject => "new {0} {{ }}";

        private void AssertMultiDimensionalArray(string type, string expectedNamespace, Action<TypeRef> modelValidator, Dictionary<string, TypeBuilderSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey($"{type}[,]"));
            var arrayModel = dict[$"{type}[,]"];
            Assert.AreEqual($"{type}[,]", arrayModel.Type.Name);
            Assert.AreEqual(expectedNamespace, arrayModel.Type.Namespace);
            Assert.IsNotNull(arrayModel.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.MultiDimensionalArray, arrayModel.Kind);
            Assert.AreEqual(2, arrayModel.Type.ArrayRank);
            Assert.AreEqual($"{type}_Array_d1_", arrayModel.Type.TypeCaseName);
            Assert.AreEqual($"{char.ToLower(type[0])}{type.Substring(1)}_Array_d1_", arrayModel.Type.CamelCaseName);

            var genericArgument = arrayModel.Type.ItemType!;
            modelValidator(genericArgument);
        }
    }
}
