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

            Assert.That(dict.TryGetValue($"{expectation.Namespace}.{expectation.TypeName}", out var itemModel), Is.True);
            Assert.That(listModel.Type.ItemType, Is.EqualTo(itemModel!.Type));
            expectation.ModelValidation(itemModel);
        }

        private static TypeBuilderSpec ValidateBuilder(string lookupName, ModelExpectation expectation, Dictionary<string, TypeBuilderSpec> dict)
        {
            Assert.That(dict.TryGetValue($"{lookupName}.List<{expectation.TypeName}>", out var listModel), Is.True);
            Assert.That(listModel!.Type.Name, Is.EqualTo($"List<{expectation.TypeName}>"));
            Assert.That(listModel.Type.Namespace, Is.EqualTo("System.Collections.Generic"));
            Assert.That(listModel.Type.ItemType, Is.Not.Null);
            Assert.That(listModel.Kind, Is.EqualTo(TypeBuilderKind.IList));
            Assert.That(listModel.Type.TypeCaseName, Is.EqualTo($"List_{expectation.TypeName}_"));
            Assert.That(listModel.Type.CamelCaseName, Is.EqualTo($"list_{expectation.TypeName}_"));
            Assert.That(listModel.Type.ArrayRank, Is.EqualTo(0));
            Assert.That(listModel.ContextType, Is.EqualTo(s_localContext));
            return listModel;
        }
    }
}
