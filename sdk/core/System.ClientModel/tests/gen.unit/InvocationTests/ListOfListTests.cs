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

        internal static void AssertListOfList(string type, Action<TypeRef> modelValidator, Dictionary<string, TypeBuilderSpec> dict)
        {
            Assert.IsTrue(dict.ContainsKey($"List<List<{type}>>"));
            var listListJsonModel = dict[$"List<List<{type}>>"];
            Assert.AreEqual($"List<List<{type}>>", listListJsonModel.Type.Name);
            Assert.AreEqual("System.Collections.Generic", listListJsonModel.Type.Namespace);
            Assert.AreEqual(1, listListJsonModel.Type.GenericArguments.Count);
            Assert.AreEqual(TypeBuilderKind.IList, listListJsonModel.Kind);

            var genericArgument = listListJsonModel.Type.GenericArguments[0];
            Assert.AreEqual($"List<{type}>", genericArgument.Name);
            Assert.AreEqual("System.Collections.Generic", genericArgument.Namespace);
            Assert.AreEqual(1, genericArgument.GenericArguments.Count);

            var innerGenericArgument = genericArgument.GenericArguments[0];
            modelValidator(innerGenericArgument);
        }
    }
}
