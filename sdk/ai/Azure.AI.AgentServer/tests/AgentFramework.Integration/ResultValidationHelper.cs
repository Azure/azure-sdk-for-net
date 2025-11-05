using System.Text.Json;
using Xunit;

namespace AgentFramework.Integration.Tests
{
    internal class ResultValidationHelper
    {
        /// <summary>
        /// Validates whether jsonElement is expected string value.
        /// </summary>
        /// <param name="jsonElement">the jsonElement to be validated</param>
        /// <param name="expected">expected string</param>
        public static void ValidateString(JsonElement jsonElement, string expected)
        {
            Assert.Equal(JsonValueKind.String, jsonElement.ValueKind);
            var status = jsonElement.GetString();
            Assert.Equal(expected, status);
        }

        /// <summary>
        /// Validates that the specified jsonElement is a non-empty array.
        /// </summary>
        /// <param name="jsonElement">The jsonElement to validate. Must be a non-null array token.</param>
        public static void ValidateNonEmptyArray(JsonElement jsonElement)
        {
            Assert.Equal(JsonValueKind.Array, jsonElement.ValueKind);
            var output = jsonElement.EnumerateArray();
            Assert.True(output.Any());
        }
    }
}
