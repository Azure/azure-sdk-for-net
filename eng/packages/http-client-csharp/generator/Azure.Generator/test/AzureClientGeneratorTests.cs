// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Tests.TestHelpers;
using NUnit.Framework;
using Azure.Generator.Visitors;

namespace Azure.Generator.Tests
{
    public class AzureClientGeneratorTests
    {
        [Test]
        public void RenamingVisitorsAreBeforeOtherVisitors()
        {
            var generator = MockHelpers.LoadMockGenerator();
            var visitors = generator.Object.Visitors;
            Assert.IsNotNull(visitors);

            Assert.IsInstanceOf<ModelFactoryRenamerVisitor>(visitors[0]);
        }
    }
}