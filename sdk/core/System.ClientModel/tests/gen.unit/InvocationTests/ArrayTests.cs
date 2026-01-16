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

        internal static void AssertArray(ModelExpectation expectation, bool invocationDuped, Dictionary<string, TypeBuilderSpec> dict)
        {
            TypeBuilderSpec arrayModel = ValidateBuilder(expectation.Namespace, expectation, dict);

            if (invocationDuped)
            {
                var dupeArrayModel = ValidateBuilder("TestProject1", expectation, dict);
            }

            Assert.That(dict.TryGetValue($"{expectation.Namespace}.{expectation.TypeName}", out var itemModel), Is.True);
            Assert.That(arrayModel.Type.ItemType, Is.EqualTo(itemModel!.Type));
            expectation.ModelValidation(itemModel);
        }

        private static TypeBuilderSpec ValidateBuilder(string lookupName, ModelExpectation expectation, Dictionary<string, TypeBuilderSpec> dict)
        {
            Assert.That(dict.TryGetValue($"{lookupName}.{expectation.TypeName}[]", out var arrayModel), Is.True);
            Assert.That(arrayModel!.Type.Name, Is.EqualTo($"{expectation.TypeName}[]"));
            Assert.That(arrayModel.Type.Namespace, Is.EqualTo(lookupName));
            Assert.That(arrayModel.Type.ItemType, Is.Not.Null);
            Assert.That(arrayModel.Kind, Is.EqualTo(TypeBuilderKind.Array));
            Assert.That(arrayModel.Type.ArrayRank, Is.EqualTo(1));
            Assert.That(arrayModel.Type.TypeCaseName, Is.EqualTo($"{expectation.TypeName}_Array_"));
            Assert.That(arrayModel.Type.CamelCaseName, Is.EqualTo($"{char.ToLower(expectation.TypeName[0])}{expectation.TypeName.Substring(1)}_Array_"));
            Assert.That(arrayModel.ContextType, Is.EqualTo(expectation.Context));
            return arrayModel;
        }
    }
}
