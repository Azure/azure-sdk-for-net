// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Reflection;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.Platform
{
    public class EnvironmentVariableConstantsTests
    {
        [Fact]
        public void VerifyAllEnvironmentVariablesAreAddedToHashSet()
        {
            // Get all const string fields from the EnvironmentVariableConstants class
            var constStringFields = typeof(EnvironmentVariableConstants)
                .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                .Where(f => f.IsLiteral && !f.IsInitOnly && f.FieldType == typeof(string))
                .ToList();

            // Verify that each const string is in the Variables HashSet
            foreach (var field in constStringFields)
            {
                string? constValue = field.GetValue(null)?.ToString();

                if (!EnvironmentVariableConstants.HashSetDefinedEnvironmentVariables.Contains(constValue!))
                {
                    Assert.Fail($"The constant value is not in the Variables HashSet. Name: '{field.Name}' Value: '{constValue}'");
                }
            }
        }
    }
}
