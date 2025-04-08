// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit.InvocationTests
{
    internal class ListOfListTests : InvocationTestBase
    {
        protected override string TypeStringFormat => "List<List<{0}>>";

        protected override List<TypeValidation> TypeValidations => [AssertListOfList, ListTests.AssertList];

        internal static void AssertListOfList(string type, string expectedNamespace, Action<TypeRef> modelValidator, Dictionary<string, TypeBuilderSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey($"List<List<{type}>>"));
            var listListJsonModel = dict[$"List<List<{type}>>"];
            Assert.AreEqual($"List<List<{type}>>", listListJsonModel.Type.Name);
            Assert.AreEqual("System.Collections.Generic", listListJsonModel.Type.Namespace);
            Assert.IsNotNull(listListJsonModel.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.IList, listListJsonModel.Kind);
            Assert.AreEqual(0, listListJsonModel.Type.ArrayRank);
            Assert.AreEqual($"List_List_{type}_", listListJsonModel.Type.TypeCaseName);
            Assert.AreEqual($"list_List_{type}_", listListJsonModel.Type.CamelCaseName);

            var genericArgument = listListJsonModel.Type.ItemType!;
            Assert.AreEqual($"List<{type}>", genericArgument.Name);
            Assert.AreEqual("System.Collections.Generic", genericArgument.Namespace);
            Assert.IsNotNull(genericArgument.ItemType);
            Assert.AreEqual(0, genericArgument.ArrayRank);
            Assert.AreEqual($"List_{type}_", genericArgument.TypeCaseName);
            Assert.AreEqual($"list_{type}_", genericArgument.CamelCaseName);

            var innerGenericArgument = genericArgument.ItemType!;
            modelValidator(innerGenericArgument);
        }
    }
}
