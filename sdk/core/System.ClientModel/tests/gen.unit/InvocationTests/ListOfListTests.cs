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

        internal static void AssertListOfList(ModelExpectation expectation, bool invocationDuped, Dictionary<string, TypeBuilderSpec> dict)
        {
            TypeBuilderSpec listListModel = ValidateBuilder(expectation.Namespace, expectation, dict, out var listModel);

            if (invocationDuped)
            {
                var dupedListListModel = ValidateBuilder("TestProject1", expectation, dict, out var dupedListModel);
            }

            Assert.IsTrue(dict.TryGetValue($"{expectation.Namespace}.{expectation.TypeName}", out var itemModel));
            Assert.AreEqual(itemModel!.Type, listModel!.Type.ItemType);
            expectation.ModelValidation(itemModel);
        }

        private static TypeBuilderSpec ValidateBuilder(string lookupName, ModelExpectation expectation, Dictionary<string, TypeBuilderSpec> dict, out TypeBuilderSpec? innerList)
        {
            Assert.IsTrue(dict.TryGetValue($"{lookupName}.List<List<{expectation.TypeName}>>", out var listListModel));
            Assert.AreEqual($"List<List<{expectation.TypeName}>>", listListModel!.Type.Name);
            Assert.AreEqual("System.Collections.Generic", listListModel.Type.Namespace);
            Assert.IsNotNull(listListModel.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.IList, listListModel.Kind);
            Assert.AreEqual(0, listListModel.Type.ArrayRank);
            Assert.AreEqual($"List_List_{expectation.TypeName}_", listListModel.Type.TypeCaseName);
            Assert.AreEqual($"list_List_{expectation.TypeName}_", listListModel.Type.CamelCaseName);
            Assert.AreEqual(s_localContext, listListModel.ContextType);

            var genericArgument = listListModel.Type.ItemType!;
            Assert.AreEqual($"List<{expectation.TypeName}>", genericArgument.Name);
            Assert.AreEqual("System.Collections.Generic", genericArgument.Namespace);
            Assert.IsNotNull(genericArgument.ItemType);
            Assert.AreEqual(0, genericArgument.ArrayRank);
            Assert.AreEqual($"List_{expectation.TypeName}_", genericArgument.TypeCaseName);
            Assert.AreEqual($"list_{expectation.TypeName}_", genericArgument.CamelCaseName);

            Assert.IsTrue(dict.TryGetValue($"{lookupName}.List<{expectation.TypeName}>", out innerList));
            Assert.AreEqual($"List<{expectation.TypeName}>", innerList!.Type.Name);
            Assert.AreEqual("System.Collections.Generic", innerList.Type.Namespace);
            Assert.IsNotNull(innerList.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.IList, innerList.Kind);
            Assert.AreEqual(0, innerList.Type.ArrayRank);
            Assert.AreEqual($"List_{expectation.TypeName}_", innerList.Type.TypeCaseName);
            Assert.AreEqual($"list_{expectation.TypeName}_", innerList.Type.CamelCaseName);
            Assert.AreEqual(s_localContext, innerList.ContextType);
            return listListModel;
        }
    }
}
