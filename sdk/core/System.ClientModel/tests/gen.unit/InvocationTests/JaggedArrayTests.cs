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

            Assert.That(dict.TryGetValue($"{expectation.Namespace}.{expectation.TypeName}", out var itemModel), Is.True);
            Assert.That(arrayModel!.Type.ItemType, Is.EqualTo(itemModel!.Type));
            expectation.ModelValidation(itemModel);
        }

        private static TypeBuilderSpec ValidateBuilder(string lookupName, ModelExpectation expectation, Dictionary<string, TypeBuilderSpec> dict, out TypeBuilderSpec? innerArray)
        {
            Assert.That(dict.TryGetValue($"{lookupName}.{expectation.TypeName}[][]", out var arrayArrayModel), Is.True);
            Assert.That(arrayArrayModel!.Type.Name, Is.EqualTo($"{expectation.TypeName}[][]"));
            Assert.That(arrayArrayModel.Type.Namespace, Is.EqualTo(lookupName));
            Assert.That(arrayArrayModel.Type.ItemType, Is.Not.Null);
            Assert.That(arrayArrayModel.Kind, Is.EqualTo(TypeBuilderKind.Array));
            Assert.That(arrayArrayModel.Type.ArrayRank, Is.EqualTo(1));
            Assert.That(arrayArrayModel.Type.TypeCaseName, Is.EqualTo($"{expectation.TypeName}_Array_Array_"));
            Assert.That(arrayArrayModel.Type.CamelCaseName, Is.EqualTo($"{char.ToLower(expectation.TypeName[0])}{expectation.TypeName.Substring(1)}_Array_Array_"));
            Assert.That(arrayArrayModel.ContextType, Is.EqualTo(expectation.Context));

            var genericArgument = arrayArrayModel.Type.ItemType!;
            Assert.That(genericArgument.Name, Is.EqualTo($"{expectation.TypeName}[]"));
            Assert.That(genericArgument.Namespace, Is.EqualTo(lookupName));
            Assert.That(genericArgument.ItemType, Is.Not.Null);
            Assert.That(genericArgument.ArrayRank, Is.EqualTo(1));
            Assert.That(genericArgument.TypeCaseName, Is.EqualTo($"{expectation.TypeName}_Array_"));
            Assert.That(genericArgument.CamelCaseName, Is.EqualTo($"{char.ToLower(expectation.TypeName[0])}{expectation.TypeName.Substring(1)}_Array_"));

            Assert.That(dict.TryGetValue($"{lookupName}.{expectation.TypeName}[]", out innerArray), Is.True);
            Assert.That(innerArray!.Type.Name, Is.EqualTo($"{expectation.TypeName}[]"));
            Assert.That(innerArray.Type.Namespace, Is.EqualTo(lookupName));
            Assert.That(innerArray.Type.ItemType, Is.Not.Null);
            Assert.That(innerArray.Kind, Is.EqualTo(TypeBuilderKind.Array));
            Assert.That(innerArray.Type.ArrayRank, Is.EqualTo(1));
            Assert.That(innerArray.Type.TypeCaseName, Is.EqualTo($"{expectation.TypeName}_Array_"));
            Assert.That(innerArray.Type.CamelCaseName, Is.EqualTo($"{char.ToLower(expectation.TypeName[0])}{expectation.TypeName.Substring(1)}_Array_"));
            Assert.That(innerArray.ContextType, Is.EqualTo(expectation.Context));
            return arrayArrayModel;
        }
    }
}
