// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.AgentServer.Tests.Utils
{
    internal class ResultValidationHelper
    {
        public static void ValidateString(JsonElement jsonElement, string expected)
        {
            Assert.AreEqual(JsonValueKind.String, jsonElement.ValueKind);
            var status = jsonElement.GetString();
            Assert.AreEqual(expected, status!);
        }

        public static void ValidateNonEmptyArray(JsonElement jsonElement)
        {
            Assert.AreEqual(JsonValueKind.Array, jsonElement.ValueKind);
            var output = jsonElement.EnumerateArray();
            Assert.True(output.Any());
        }
    }
}
