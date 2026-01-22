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

            Assert.That(dict.TryGetValue($"{expectation.Namespace}.{expectation.TypeName}", out var itemModel), Is.True);
            Assert.That(listModel!.Type.ItemType, Is.EqualTo(itemModel!.Type));
            expectation.ModelValidation(itemModel);
        }

        private static TypeBuilderSpec ValidateBuilder(string lookupName, ModelExpectation expectation, Dictionary<string, TypeBuilderSpec> dict, out TypeBuilderSpec? innerList)
        {
            Assert.That(dict.TryGetValue($"{lookupName}.List<List<{expectation.TypeName}>>", out var listListModel), Is.True);
            Assert.That(listListModel!.Type.Name, Is.EqualTo($"List<List<{expectation.TypeName}>>"));
            Assert.That(listListModel.Type.Namespace, Is.EqualTo("System.Collections.Generic"));
            Assert.That(listListModel.Type.ItemType, Is.Not.Null);
            Assert.That(listListModel.Kind, Is.EqualTo(TypeBuilderKind.IList));
            Assert.That(listListModel.Type.ArrayRank, Is.EqualTo(0));
            Assert.That(listListModel.Type.TypeCaseName, Is.EqualTo($"List_List_{expectation.TypeName}_"));
            Assert.That(listListModel.Type.CamelCaseName, Is.EqualTo($"list_List_{expectation.TypeName}_"));
            Assert.That(listListModel.ContextType, Is.EqualTo(s_localContext));

            var genericArgument = listListModel.Type.ItemType!;
            Assert.That(genericArgument.Name, Is.EqualTo($"List<{expectation.TypeName}>"));
            Assert.That(genericArgument.Namespace, Is.EqualTo("System.Collections.Generic"));
            Assert.That(genericArgument.ItemType, Is.Not.Null);
            Assert.That(genericArgument.ArrayRank, Is.EqualTo(0));
            Assert.That(genericArgument.TypeCaseName, Is.EqualTo($"List_{expectation.TypeName}_"));
            Assert.That(genericArgument.CamelCaseName, Is.EqualTo($"list_{expectation.TypeName}_"));

            Assert.That(dict.TryGetValue($"{lookupName}.List<{expectation.TypeName}>", out innerList), Is.True);
            Assert.That(innerList!.Type.Name, Is.EqualTo($"List<{expectation.TypeName}>"));
            Assert.That(innerList.Type.Namespace, Is.EqualTo("System.Collections.Generic"));
            Assert.That(innerList.Type.ItemType, Is.Not.Null);
            Assert.That(innerList.Kind, Is.EqualTo(TypeBuilderKind.IList));
            Assert.That(innerList.Type.ArrayRank, Is.EqualTo(0));
            Assert.That(innerList.Type.TypeCaseName, Is.EqualTo($"List_{expectation.TypeName}_"));
            Assert.That(innerList.Type.CamelCaseName, Is.EqualTo($"list_{expectation.TypeName}_"));
            Assert.That(innerList.ContextType, Is.EqualTo(s_localContext));
            return listListModel;
        }
    }
}
