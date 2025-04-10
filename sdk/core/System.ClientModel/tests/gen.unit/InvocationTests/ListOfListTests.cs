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

        internal static void AssertListOfList(ModelExpectation expectation, Dictionary<string, TypeBuilderSpec> dict)
        {
            Assert.IsTrue(dict.TryGetValue($"{expectation.Namespace}.List<List<{expectation.TypeName}>>", out var listListJsonModel));
            Assert.AreEqual($"List<List<{expectation.TypeName}>>", listListJsonModel!.Type.Name);
            Assert.AreEqual("System.Collections.Generic", listListJsonModel.Type.Namespace);
            Assert.IsNotNull(listListJsonModel.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.IList, listListJsonModel.Kind);
            Assert.AreEqual(0, listListJsonModel.Type.ArrayRank);
            Assert.AreEqual($"List_List_{expectation.TypeName}_", listListJsonModel.Type.TypeCaseName);
            Assert.AreEqual($"list_List_{expectation.TypeName}_", listListJsonModel.Type.CamelCaseName);
            Assert.AreEqual(s_localContext, listListJsonModel.ContextType);

            var genericArgument = listListJsonModel.Type.ItemType!;
            Assert.AreEqual($"List<{expectation.TypeName}>", genericArgument.Name);
            Assert.AreEqual("System.Collections.Generic", genericArgument.Namespace);
            Assert.IsNotNull(genericArgument.ItemType);
            Assert.AreEqual(0, genericArgument.ArrayRank);
            Assert.AreEqual($"List_{expectation.TypeName}_", genericArgument.TypeCaseName);
            Assert.AreEqual($"list_{expectation.TypeName}_", genericArgument.CamelCaseName);

            Assert.IsTrue(dict.TryGetValue($"{expectation.Namespace}.List<{expectation.TypeName}>", out var listModel));
            Assert.AreEqual($"List<{expectation.TypeName}>", listModel!.Type.Name);
            Assert.AreEqual("System.Collections.Generic", listModel.Type.Namespace);
            Assert.IsNotNull(listModel.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.IList, listModel.Kind);
            Assert.AreEqual(0, listModel.Type.ArrayRank);
            Assert.AreEqual($"List_{expectation.TypeName}_", listModel.Type.TypeCaseName);
            Assert.AreEqual($"list_{expectation.TypeName}_", listModel.Type.CamelCaseName);
            Assert.AreEqual(s_localContext, listModel.ContextType);

            Assert.IsTrue(dict.TryGetValue($"{expectation.Namespace}.{expectation.TypeName}", out var itemModel));
            Assert.AreEqual(itemModel!.Type, listModel.Type.ItemType);
            expectation.ModelValidation(itemModel);
        }
    }
}
