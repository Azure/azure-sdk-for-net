// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.DigitalTwins.Core.Serialization;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    [Category("Unit")]
    [Parallelizable(ParallelScope.All)]
    public class BasicRelationshipUnitTests
    {
        [Test]
        public void BasicRelationship_DeseralizesAllProps()
        {
            // arrange

            const string expectedRelationshipId = "relationshipId123";
            const string expectedRelationship = "relationship123";
            const string expectedSourceId = "sourceId123";
            const string expectedTargetId = "targetId123";
            const string expectedCustomPropKey = "customPropKey123";
            const string expectedCustomPropVal = "customPropVal123";

            string relationshipJson = "{" +
                $"\"$relationshipId\": \"{expectedRelationshipId}\"," +
                $"\"$relationshipName\": \"{expectedRelationship}\"," +
                $"\"$sourceId\": \"{expectedSourceId}\"," +
                $"\"$targetId\": \"{expectedTargetId}\"," +
                $"\"{expectedCustomPropKey}\": \"{expectedCustomPropVal}\"" +
            "}";

            // act
            BasicRelationship actual = JsonSerializer.Deserialize<BasicRelationship>(relationshipJson);

            // assert

            actual.Id.Should().Be(expectedRelationshipId);
            actual.Name.Should().Be(expectedRelationship);
            actual.SourceId.Should().Be(expectedSourceId);
            actual.TargetId.Should().Be(expectedTargetId);
            actual.CustomProperties[expectedCustomPropKey].ToString().Should().Be(expectedCustomPropVal);
        }
    }
}
