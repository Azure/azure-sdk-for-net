// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.DigitalTwins.Core.QueryBuilder;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    public class SelectAsQueryTests
    {
        [Test]
        public void SelectAsQuery_SingleSelectAs()
        {
            var selectAsQuery = new SelectAsQuery(null, null);
            selectAsQuery.SelectAs("Temperature", "Temp");
            selectAsQuery.GetQueryText()
                .Should()
                .Be("Temperature AS Temp");
        }

        [Test]
        public void SelectAsQuery_MultipleSelectAs()
        {
            var selectAsQuery = new SelectAsQuery(null, null);
            selectAsQuery.SelectAs("Temperature", "Temp")
                .SelectAs("Humidity", "Hum")
                .SelectAs("Occupants", "Occ");
            selectAsQuery.GetQueryText()
                .Should()
                .Be("Temperature AS Temp, Humidity AS Hum, Occupants AS Occ");
        }

        // pass in null => throw exception or handle it in some way
        // can you replace a string with a number? => Temperature AS 2
    }
}
