// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.DigitalTwins.Core.QueryBuilder;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    public class FromQueryTests
    {
        [Test]
        public void FromQuery_DigitalTwins()
        {
            var query = new FromQuery(null, null);
            query.From(AdtCollection.DigitalTwins);
            query.GetQueryText()
                .Should()
                .Be("FROM DigitalTwins");
        }

        [Test]
        public void FromQuery_Relationships()
        {
            var query = new FromQuery(null, null);
            query.From(AdtCollection.Relationships);
            query.GetQueryText()
                .Should()
                .Be("FROM Relationships");
        }

        [Test]
        public void FromQuery_Override()
        {
            var query = new FromQuery(null, null);
            query.From("DIGITALTWINS");
            query.GetQueryText()
                .Should()
                .Be("FROM DIGITALTWINS");
        }
    }
}
