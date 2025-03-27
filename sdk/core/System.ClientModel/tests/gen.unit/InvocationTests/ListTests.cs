// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit.InvocationTests
{
    internal class ListTests : InvocationTestBase
    {
        protected override List<TypeValidation> TypeValidations => [AssertList];

        protected override string TypeStringFormat => "List<{0}>";

        internal static void AssertList(string type, Action<TypeRef> modelValidator, Dictionary<string, TypeGenerationSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey($"List<{type}>"));
            var listJsonModel = dict[$"List<{type}>"];
            Assert.AreEqual($"List<{type}>", listJsonModel.Type.Name);
            Assert.AreEqual("System.Collections.Generic", listJsonModel.Type.Namespace);
            Assert.AreEqual(1, listJsonModel.Type.GenericArguments.Count);
            Assert.AreEqual(ModelInfoKind.IEnumerable, listJsonModel.Kind);

            var genericArgument = listJsonModel.Type.GenericArguments[0];
            modelValidator(genericArgument);
        }
    }
}
