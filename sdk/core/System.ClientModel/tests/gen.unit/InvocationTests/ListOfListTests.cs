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
            Assert.IsTrue(dict.TryGetValue($"{expectation.Namespace}.List<List<{expectation.TypeName}>>", out var listListJsonModel));
            Assert.AreEqual($"List<List<{expectation.TypeName}>>", listListJsonModel!.Type.Name);
            Assert.AreEqual("System.Collections.Generic", listListJsonModel.Type.Namespace);
            Assert.IsNotNull(listListJsonModel.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.IList, listListJsonModel.Kind);
            Assert.AreEqual(0, listListJsonModel.Type.ArrayRank);
            Assert.AreEqual($"List_List_{expectation.TypeName}_", listListJsonModel.Type.TypeCaseName);
            Assert.AreEqual($"list_List_{expectation.TypeName}_", listListJsonModel.Type.CamelCaseName);
            Assert.AreEqual(s_localContext, listListJsonModel.ContextType);
            Assert.IsNull(listListJsonModel.Type.Alias);

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
            Assert.IsNull(listModel.Type.Alias);

            if (invocationDuped)
            {
                Assert.IsTrue(dict.TryGetValue($"TestProject1.List<List<{expectation.TypeName}>>", out var dupedListListJsonModel));
                Assert.AreEqual($"List<List<{expectation.TypeName}>>", dupedListListJsonModel!.Type.Name);
                Assert.AreEqual("System.Collections.Generic", dupedListListJsonModel.Type.Namespace);
                Assert.IsNotNull(dupedListListJsonModel.Type.ItemType);
                Assert.AreEqual(TypeBuilderKind.IList, dupedListListJsonModel.Kind);
                Assert.AreEqual(0, dupedListListJsonModel.Type.ArrayRank);
                Assert.AreEqual($"List_List_{expectation.TypeName}_", dupedListListJsonModel.Type.TypeCaseName);
                Assert.AreEqual($"list_List_{expectation.TypeName}_", dupedListListJsonModel.Type.CamelCaseName);
                Assert.AreEqual(s_localContext, dupedListListJsonModel.ContextType);
                Assert.IsNotNull(dupedListListJsonModel.Type.Alias);
                Assert.AreEqual($"List<List<{expectation.TypeName}_0>>", dupedListListJsonModel.Type.Alias);

                var dupedGenericArgument = dupedListListJsonModel.Type.ItemType!;
                Assert.AreEqual($"List<{expectation.TypeName}>", dupedGenericArgument.Name);
                Assert.AreEqual("System.Collections.Generic", dupedGenericArgument.Namespace);
                Assert.IsNotNull(dupedGenericArgument.ItemType);
                Assert.AreEqual(0, dupedGenericArgument.ArrayRank);
                Assert.AreEqual($"List_{expectation.TypeName}_", dupedGenericArgument.TypeCaseName);
                Assert.AreEqual($"list_{expectation.TypeName}_", dupedGenericArgument.CamelCaseName);

                Assert.IsTrue(dict.TryGetValue($"TestProject1.List<{expectation.TypeName}>", out var dupedListModel));
                Assert.AreEqual($"List<{expectation.TypeName}>", dupedListModel!.Type.Name);
                Assert.AreEqual("System.Collections.Generic", dupedListModel.Type.Namespace);
                Assert.IsNotNull(dupedListModel.Type.ItemType);
                Assert.AreEqual(TypeBuilderKind.IList, dupedListModel.Kind);
                Assert.AreEqual(0, dupedListModel.Type.ArrayRank);
                Assert.AreEqual($"List_{expectation.TypeName}_", dupedListModel.Type.TypeCaseName);
                Assert.AreEqual($"list_{expectation.TypeName}_", dupedListModel.Type.CamelCaseName);
                Assert.AreEqual(s_localContext, dupedListModel.ContextType);
                Assert.IsNotNull(dupedListModel.Type.Alias);
                Assert.AreEqual($"List<{expectation.TypeName}_0>", dupedListModel.Type.Alias);
            }

            Assert.IsTrue(dict.TryGetValue($"{expectation.Namespace}.{expectation.TypeName}", out var itemModel));
            Assert.AreEqual(itemModel!.Type, listModel.Type.ItemType);
            expectation.ModelValidation(itemModel);
        }
    }
}
