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

        internal static void AssertList(string type, Action<TypeRef> modelValidator, Dictionary<string, TypeBuilderSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey($"List<{type}>"));
            var listJsonModel = dict[$"List<{type}>"];
            Assert.AreEqual($"List<{type}>", listJsonModel.Type.Name);
            Assert.AreEqual("System.Collections.Generic", listJsonModel.Type.Namespace);
            Assert.IsNotNull(listJsonModel.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.IList, listJsonModel.Kind);

            var genericArgument = listJsonModel.Type.ItemType!;
            modelValidator(genericArgument);
        }
    }
}
