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

        private void AssertJaggedArray(string type, string expectedNamespace, Action<TypeRef> modelValidator, Dictionary<string, TypeBuilderSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey($"{type}[][]"));
            var arrayModel = dict[$"{type}[][]"];
            Assert.AreEqual($"{type}[][]", arrayModel.Type.Name);
            Assert.AreEqual(expectedNamespace, arrayModel.Type.Namespace);
            Assert.IsNotNull(arrayModel.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.Array, arrayModel.Kind);

            var genericArgument = arrayModel.Type.ItemType!;
            Assert.AreEqual($"{type}[]", genericArgument.Name);
            Assert.AreEqual(expectedNamespace, genericArgument.Namespace);
            Assert.IsNotNull(genericArgument.ItemType);

            var genericArgument2 = genericArgument.ItemType!;
            modelValidator(genericArgument2);
        }
    }
}
