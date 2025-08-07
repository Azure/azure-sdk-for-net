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

        internal static void AssertList(ModelExpectation expectation, bool invocationDuped, Dictionary<string, TypeBuilderSpec> dict)
        {
            TypeBuilderSpec listModel = ValidateBuilder(expectation.Namespace, expectation, dict);

            if (invocationDuped)
            {
                var dupedListModel = ValidateBuilder("TestProject1", expectation, dict);
            }

            Assert.IsTrue(dict.TryGetValue($"{expectation.Namespace}.{expectation.TypeName}", out var itemModel));
            Assert.AreEqual(itemModel!.Type, listModel.Type.ItemType);
            expectation.ModelValidation(itemModel);
        }

        private static TypeBuilderSpec ValidateBuilder(string lookupName, ModelExpectation expectation, Dictionary<string, TypeBuilderSpec> dict)
        {
            Assert.IsTrue(dict.TryGetValue($"{lookupName}.List<{expectation.TypeName}>", out var listModel));
            Assert.AreEqual($"List<{expectation.TypeName}>", listModel!.Type.Name);
            Assert.AreEqual("System.Collections.Generic", listModel.Type.Namespace);
            Assert.IsNotNull(listModel.Type.ItemType);
            Assert.AreEqual(TypeBuilderKind.IList, listModel.Kind);
            Assert.AreEqual($"List_{expectation.TypeName}_", listModel.Type.TypeCaseName);
            Assert.AreEqual($"list_{expectation.TypeName}_", listModel.Type.CamelCaseName);
            Assert.AreEqual(0, listModel.Type.ArrayRank);
            Assert.AreEqual(s_localContext, listModel.ContextType);
            return listModel;
        }
    }
}
