// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Reflection;
#if NET6_0_OR_GREATER
using System.Text.Json.Nodes;
#endif
using Azure.Monitor.Query.Models;
using NUnit.Framework;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    internal static class TelemetryValidationHelper
    {
        public static void ValidateExpectedTelemetry(string description, LogsTable? logsTable, object expectedTelemetry)
        {
            TestContext.Out.WriteLine($"{nameof(ValidateExpectedTelemetry)}: '{description}'");

            Assert.IsNotNull(logsTable, $"({description}) Expected a non-null table.");
            Assert.AreEqual(1, logsTable!.Rows.Count, $"({description}) Expected 1 row in the table but found {logsTable.Rows.Count} rows.");

            var row = logsTable.Rows[0];
            foreach (PropertyInfo property in expectedTelemetry.GetType().GetProperties())
            {
                if (property.Name == "Properties")
                {
                    var jsonString = row[property.Name].ToString();
                    Assert.IsNotNull(jsonString, $"({description}) Expected a non-null value for {property.Name}");
                    var expectedProperties = property.GetValue(expectedTelemetry, null) as List<KeyValuePair<string, string>>;
                    Assert.IsNotNull(expectedProperties, $"({description}) Expected a non-null value for {nameof(expectedTelemetry)}.Properties");

                    ValidateProperties(
                        description: description,
                        jsonString: jsonString!,
                        expectedProperties: expectedProperties!);
                }
                else
                {
                    TestContext.Out.WriteLine($"Property: '{property.Name}' ExpectedValue: '{property.GetValue(expectedTelemetry, null)}' ActualValue: '{row[property.Name]}'");

                    Assert.AreEqual(
                        expected: property.GetValue(expectedTelemetry, null),
                        actual: row[property.Name],
                        message: $"({description}) Expected {property.Name} to be '{property.GetValue(expectedTelemetry, null)}' but found '{logsTable.Rows[0][property.Name]}'.");
                }
            }

            TestContext.Out.WriteLine();
        }

        private static void ValidateProperties(string description, string jsonString, List<KeyValuePair<string, string>> expectedProperties)
        {
#if NET6_0_OR_GREATER
            var jsonNode = JsonNode.Parse(jsonString);
            Assert.IsNotNull(jsonNode, $"({description}) Expected a non-null JSON node.");

            foreach (var expectedProperty in expectedProperties)
            {
                var jsonValue = jsonNode![expectedProperty.Key];
                Assert.IsNotNull(jsonValue, $"({description}) Expected a non-null JSON value for Properties.'{expectedProperty.Key}'.");
                var actualValue = jsonValue!.ToString();

                TestContext.Out.WriteLine($"Properties.'{expectedProperty.Key}' ExpectedValue: '{expectedProperty.Value}' ActualValue: '{actualValue}'");

                Assert.AreEqual(
                    expected: expectedProperty.Value,
                    actual: actualValue,
                    message: $"({description}) Expected Properties.'{expectedProperty.Key}' to be '{expectedProperty.Value}' but found '{actualValue}'.");
            }
#endif
        }

        public struct ExpectedAppDependency
        {
            public string Data { get; set; }
            public string AppRoleName { get; set; }
        }

        public struct ExpectedAppRequest
        {
            public string Url { get; set; }
            public string AppRoleName { get; set; }
        }

        public struct ExpectedAppMetric
        {
            public string Name { get; set; }
            public string AppRoleName { get; set; }
            public List<KeyValuePair<string, string>> Properties { get; set; }
        }

        public struct ExpectedAppTrace
        {
            public string Message { get; set; }
            public string AppRoleName { get; set; }
        }
    }
}
