// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Collections.Generic;

namespace Azure.Generator.Mgmt.Tests
{
    internal class GeneratedCodeE2ETests
    {
        [Test]
        public void FlattenedCollectionGetterInitializesNestedCollection()
        {
            var data = new global::Azure.Generator.MgmtTypeSpec.Tests.BarSettingsResourceData(
                "propertyLeft",
                "anotherPropertyLeft",
                "innerProp2",
                1,
                new Dictionary<string, string>(),
                new[] { "prop1" },
                2,
                global::Azure.Generator.MgmtTypeSpec.Tests.Models.MgmtTypeSpecTestsModelFactory.LimitJsonObject());

            data.RandomCollectionProp.Add("item");
            data.AdditionalCollectionProp.Add(1);

            Assert.That(data.RandomCollectionProp, Is.EqualTo(new[] { "item" }));
            Assert.That(data.AdditionalCollectionProp, Is.EqualTo(new[] { 1 }));
        }
    }
}
