// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Reflection;
#if NET
using System.Text.Json.Nodes;
#endif
using Azure.Monitor.Query.Logs.Models;
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
                    var jsonString = row[property.Name]?.ToString();
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
                    TestContext.Out.WriteLine($"PropertyName: '{property.Name}' ExpectedValue: '{property.GetValue(expectedTelemetry, null)}' ActualValue: '{row[property.Name]}'");

                    Assert.AreEqual(
                        expected: property.GetValue(expectedTelemetry, null)!.ToString(),
                        actual: row[property.Name].ToString(),
                        message: $"({description}) Expected {property.Name} to be '{property.GetValue(expectedTelemetry, null)}' but found '{logsTable.Rows[0][property.Name]}'.");
                }
            }

            TestContext.Out.WriteLine();
        }

        private static void ValidateProperties(string description, string jsonString, List<KeyValuePair<string, string>> expectedProperties)
        {
#if NET
            var jsonNode = JsonNode.Parse(jsonString);
            Assert.IsNotNull(jsonNode, $"({description}) Expected a non-null JSON node.");

            var expectedCount = expectedProperties.Count;
            var actualCount = ((JsonObject)jsonNode!).Count;
            Assert.AreEqual(expectedCount, actualCount, $"({description}) Expected {expectedCount} properties but found {actualCount}.");

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

        /*
         * Notes on field validation:
         * Remember that this test will be run as both a Recording and Live.
         * We can't include unique ids becasue they are unique per test run (ie: Id, OperationId, ParentId, etc).
         * We can't include timing fields because would be unique per test run(ie: TimeGenerated, DurationMS, PerformanceBucket).
         * We can't include client fields because we can't control where these tests run (ie: ClientOS, ClientCity, ClientCountryOrRegion, etc).
         */

        public struct ExpectedAppDependency
        {
            public string Target { get; set; }
            public string DependencyType { get; set; }
            public string Name { get; set; }
            public string Data { get; set; }
            public string Success { get; set; }
            public string ResultCode { get; set; }
            public List<KeyValuePair<string, string>> Properties { get; set; }
            public string UserAuthenticatedId { get; set; }
            public string AppVersion { get; set; }
            public string AppRoleName { get; set; }
            public string AppRoleInstance { get; set; }
            public string ClientIP { get; set; }
            public string Type { get; set; }
        }

        public struct ExpectedAppRequest
        {
            public string Name { get; set; }
            public string Url { get; set; }
            public string Success { get; set; }
            public string ResultCode { get; set; }
            public List<KeyValuePair<string, string>> Properties { get; set; }
            public string OperationName { get; set; }
            public string UserAuthenticatedId { get; set; }
            public string AppVersion { get; set; }
            public string AppRoleName { get; set; }
            public string AppRoleInstance { get; set; }
            public string ClientIP { get; set; }
            public string Type { get; set; }
        }

        public struct ExpectedAppMetric
        {
            public string Name { get; set; }
            public List<KeyValuePair<string, string>> Properties { get; set; }
            public string AppVersion { get; set; }
            public string AppRoleName { get; set; }
            public string AppRoleInstance { get; set; }
            public string Type { get; set; }
        }

        public struct ExpectedAppTrace
        {
            public string Message { get; set; }
            public List<KeyValuePair<string, string>> Properties { get; set; }
            public string SeverityLevel { get; set; }
            public string AppVersion { get; set; }
            public string AppRoleName { get; set; }
            public string AppRoleInstance { get; set; }
            public string ClientIP { get; set; }
            public string Type { get; set; }
        }
    }
}
