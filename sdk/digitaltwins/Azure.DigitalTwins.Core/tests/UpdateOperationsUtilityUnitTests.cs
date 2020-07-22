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
    public class UpdateOperationsUtilityUnitTests
    {
        [Test]
        public void UpdateOperationsUtility_BuildAdd()
        {
            // arrange

            const string addOp = "add";
            const string replaceOp = "replace";
            const string removeOp = "remove";

            const string addPath = "/addComponentPath123";
            const string addValue = "value123";
            const string replacePath = "/replaceComponentPath123";
            const string replaceValue = "value456";
            const string removePath = "/removeComponentPath123";

            var dtUpdateUtility = new UpdateOperationsUtility();
            dtUpdateUtility.AppendAddOp(addPath, addValue);
            dtUpdateUtility.AppendReplaceOp(replacePath, replaceValue);
            dtUpdateUtility.AppendRemoveOp(removePath);

            // act
            string actual = dtUpdateUtility.Serialize();

            // assert

            JsonDocument parsed = JsonDocument.Parse(actual);
            parsed.RootElement.ValueKind.Should().Be(JsonValueKind.Array, "operations should be nested in an array");
            parsed.RootElement.GetArrayLength().Should().Be(3, "three operations were included");

            JsonElement addElement = parsed.RootElement[0];
            addElement.GetProperty("op").GetString().Should().Be(addOp);
            addElement.GetProperty("path").GetString().Should().Be(addPath);
            addElement.GetProperty("value").GetString().Should().Be(addValue);

            JsonElement replaceElement = parsed.RootElement[1];
            replaceElement.GetProperty("op").GetString().Should().Be(replaceOp);
            replaceElement.GetProperty("path").GetString().Should().Be(replacePath);
            replaceElement.GetProperty("value").GetString().Should().Be(replaceValue);

            JsonElement removeElement = parsed.RootElement[2];
            removeElement.GetProperty("op").GetString().Should().Be(removeOp);
            removeElement.GetProperty("path").GetString().Should().Be(removePath);
            removeElement.TryGetProperty("value", out _).Should().BeFalse();
        }
    }
}
