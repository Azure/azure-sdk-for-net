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

        internal static void AssertArray(string type, Action<TypeRef> modelValidator, Dictionary<string, TypeBuilderSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey($"{type}[]"));
            var arrayJsonModel = dict[$"{type}[]"];
            Assert.AreEqual($"{type}[]", arrayJsonModel.Type.Name);
            if (type == JsonModel)
            {
                Assert.AreEqual("TestProject", arrayJsonModel.Type.Namespace);
            }
            else
            {
                Assert.AreEqual("System.ClientModel.Tests.Client.Models.ResourceManager.Compute", arrayJsonModel.Type.Namespace);
            }
            Assert.AreEqual(1, arrayJsonModel.Type.GenericArguments.Count);
            Assert.AreEqual(TypeBuilderKind.Array, arrayJsonModel.Kind);

            var genericArgument = arrayJsonModel.Type.GenericArguments[0];
            modelValidator(genericArgument);
        }
    }
}
