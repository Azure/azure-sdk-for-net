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

        private void AssertMultiDimensionalArray(ModelExpectation expectation, bool invocationDuped, Dictionary<string, TypeBuilderSpec> dict)
        {
            TypeBuilderSpec arrayModel = ValidateBuilder(expectation.Namespace, expectation, dict);

            if (invocationDuped)
            {
                var dupedArrayModel = ValidateBuilder("TestProject1", expectation, dict);
            }

            Assert.IsTrue(dict.TryGetValue($"{expectation.Namespace}.{expectation.TypeName}", out var itemModel));
            Assert.AreEqual(itemModel!.Type, arrayModel.Type.ItemType);
            expectation.ModelValidation(itemModel);
        }

        private static TypeBuilderSpec ValidateBuilder(string lookupName, ModelExpectation expectation, Dictionary<string, TypeBuilderSpec> dict)
        {
            Assert.IsTrue(dict.TryGetValue($"{lookupName}.{expectation.TypeName}[,]", out var arrayModel));
            Assert.AreEqual($"{expectation.TypeName}[,]", arrayModel!.Type.Name);
            Assert.AreEqual(lookupName, arrayModel.Type.Namespace);
            Assert.IsNotNull(arrayModel.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.MultiDimensionalArray, arrayModel.Kind);
            Assert.AreEqual(2, arrayModel.Type.ArrayRank);
            Assert.AreEqual($"{expectation.TypeName}_Array_d1_", arrayModel.Type.TypeCaseName);
            Assert.AreEqual($"{char.ToLower(expectation.TypeName[0])}{expectation.TypeName.Substring(1)}_Array_d1_", arrayModel.Type.CamelCaseName);
            Assert.AreEqual(expectation.Context, arrayModel.ContextType);
            return arrayModel;
        }
    }
}
