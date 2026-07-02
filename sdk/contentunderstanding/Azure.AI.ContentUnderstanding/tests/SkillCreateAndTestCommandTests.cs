// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Text.Json.Nodes;
using AzureSdkContentUnderstanding.Skills;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Unit tests for the pure helpers in <c>tools/cu-skill/CreateAndTestCommand.cs</c>
    /// (mirrors Python's <c>tests/test_skills_create_and_test.py</c>). The CLI
    /// entry point (<c>RunAsync</c>) and the network-dependent helpers are not
    /// covered here — they require an Azure client and live recording.
    /// </summary>
    public class SkillCreateAndTestCommandTests
    {
        private static JsonObject Scalar(string value, double conf)
            => new() { ["type"] = "string", ["valueString"] = value, ["confidence"] = conf };

        private static JsonObject Number(double value, double conf)
            => new() { ["type"] = "number", ["valueNumber"] = value, ["confidence"] = conf };

        private static JsonObject ArrayOfObjects(JsonArray items)
            => new() { ["type"] = "array", ["valueArray"] = items };

        private static JsonObject ObjectField(JsonObject inner)
            => new() { ["type"] = "object", ["valueObject"] = inner };

        [Test]
        public void Summarize_NestedArrayAndObjectFields_FlattenedToLeafRows()
        {
            var lineItem1 = new JsonObject
            {
                ["itemCode"] = Scalar("A123", 0.80),
                ["amount"] = Number(60.0, 0.92),
            };
            var lineItem2 = new JsonObject
            {
                ["itemCode"] = Scalar("B456", 0.70),
                ["amount"] = Number(30.0, 0.90),
            };
            var addressInner = new JsonObject
            {
                ["street"] = Scalar("123 Main St", 0.88),
            };

            var fields = new JsonObject
            {
                ["invoiceNumber"] = Scalar("INV-100", 0.95),
                ["lineItems"] = ArrayOfObjects(new JsonArray(
                    ObjectField(lineItem1),
                    ObjectField(lineItem2))),
                ["address"] = ObjectField(addressInner),
            };

            var content = new JsonObject { ["fields"] = fields };
            var doc = new JsonObject { ["contents"] = new JsonArray(content) };

            var results = new[] { (DocName: "docX", Doc: doc) };
            var output = CreateAndTestCommand.Summarize(results);

            // Leaf rows present.
            StringAssert.Contains("lineItems[].itemCode", output);
            StringAssert.Contains("lineItems[].amount", output);
            StringAssert.Contains("address.street", output);
            StringAssert.Contains("invoiceNumber", output);

            // The old aggregate-only behaviour would emit a bare `lineItems`
            // or `address` row with `n/a` confidence and no children. The new
            // behaviour must not emit those.
            foreach (var line in output.Split('\n'))
            {
                var stripped = line.Trim();
                Assert.That(
                    !(stripped.StartsWith("lineItems ") || stripped.StartsWith("address ")),
                    $"aggregate-only row leaked: {line}");
            }

            // Lowest-confidence section should surface the 0.700 leaf.
            StringAssert.Contains("0.700", output);
            var lowIdx = output.IndexOf("lowest-confidence", System.StringComparison.Ordinal);
            Assert.That(lowIdx, Is.GreaterThanOrEqualTo(0), "no 'lowest-confidence' section");
            var lowSection = output.Substring(lowIdx);
            StringAssert.Contains("lineItems[].itemCode", lowSection);
        }
    }
}
