// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Primitives;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Expressions
{
    internal class DictionaryExpressionTests
    {
        [Test]
        public void ValidateDictionaryIndexerExpressions()
        {
            var construct = new TestConstruct();
            var expression = construct.Endpoints["reference"];

            Assert.AreEqual(
                "endpoints['reference']",
                expression.ToString()
                );
        }

        private class TestConstruct : ProvisionableConstruct
        {
            protected override void DefineProvisionableProperties()
            {
                _endpoints = DefineDictionaryProperty<string>("endpoints", ["endpoints"], isOutput: true);
            }

            public BicepDictionary<string> Endpoints
            {
                get { Initialize(); return _endpoints!; }
            }
            private BicepDictionary<string>? _endpoints;
        }
    }
}
