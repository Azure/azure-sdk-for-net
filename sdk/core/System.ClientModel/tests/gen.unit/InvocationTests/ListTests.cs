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

        internal static void AssertList(ModelExpectation expectation, Dictionary<string, TypeBuilderSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey($"List<{expectation.TypeName}>"));
            var listJsonModel = dict[$"List<{expectation.TypeName}>"];
            Assert.AreEqual($"List<{expectation.TypeName}>", listJsonModel.Type.Name);
            Assert.AreEqual("System.Collections.Generic", listJsonModel.Type.Namespace);
            Assert.IsNotNull(listJsonModel.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.IList, listJsonModel.Kind);
            Assert.AreEqual($"List_{expectation.TypeName}_", listJsonModel.Type.TypeCaseName);
            Assert.AreEqual($"list_{expectation.TypeName}_", listJsonModel.Type.CamelCaseName);
            Assert.AreEqual(0, listJsonModel.Type.ArrayRank);
            Assert.AreEqual(s_localContext, listJsonModel.ContextType);

            var itemModel = dict[expectation.TypeName];
            Assert.IsNotNull(itemModel);
            Assert.AreEqual(itemModel.Type, listJsonModel.Type.ItemType);
            expectation.ModelValidation(itemModel);
        }
    }
}
