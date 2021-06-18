// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.DigitalTwins.Core.QueryBuilder;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    public class WhereStatementTests
    {
        [Test]
        public void WhereStatement_WhereKeyword()
        {
            var query = new WhereStatement(null, null);
            query.GetQueryText()
                .Should()
                .Be("WHERE");
        }
    }
}
