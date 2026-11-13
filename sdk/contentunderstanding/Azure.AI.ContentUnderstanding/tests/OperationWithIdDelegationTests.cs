// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Defensive tests for <c>OperationWithId</c> to ensure it properly delegates
    /// all virtual methods from <see cref="Operation{T}"/> to its inner operation.
    /// </summary>
    /// <remarks>
    /// <c>OperationWithId</c> uses the decorator/wrapper pattern around <c>Operation&lt;BinaryData&gt;</c>.
    /// This means it must manually delegate every virtual method. If a method is missed,
    /// the call silently falls back to the base class default instead of reaching the inner
    /// operation's override (e.g., <c>ProtocolOperation&lt;BinaryData&gt;</c>).
    ///
    /// This test uses reflection to detect any virtual methods on <see cref="Operation{T}"/> or
    /// <see cref="Operation"/> that <c>OperationWithId</c> does not override. If Azure.Core adds
    /// new virtual methods in the future, this test will fail, alerting us to add the delegation.
    ///
    /// Regression test for GitHub issue #56840 (GetRehydrationToken returned null).
    /// </remarks>
    [TestFixture]
    public class OperationWithIdDelegationTests
    {
        // Methods that are intentionally NOT overridden in OperationWithId.
        // Each entry must have a justification comment.
        private static readonly HashSet<string> AllowedNonOverrides = new(StringComparer.Ordinal)
        {
            // Object methods — no behavioral impact for the decorator pattern.
            "Equals",
            "GetHashCode",
            "ToString",

            // Sync WaitForCompletion variants — base class defaults call through to the async
            // versions (which DO delegate via UpdateStatusAsync), so these work correctly
            // without explicit overrides.
            "WaitForCompletion",

            // WaitForCompletionResponse variants (on Operation base) — same as above,
            // base implementations call UpdateStatusAsync which is delegated.
            "WaitForCompletionResponse",
            "WaitForCompletionResponseAsync",
        };

        [Test]
        public void OperationWithId_ShouldOverrideAllVirtualMethods()
        {
            // Load the OperationWithId type via reflection (it's internal)
            Type? operationWithIdType = typeof(ContentUnderstandingClient).Assembly
                .GetType("Azure.AI.ContentUnderstanding.OperationWithId");

            Assert.IsNotNull(operationWithIdType,
                "OperationWithId type should exist in the Azure.AI.ContentUnderstanding assembly");

            // Get all virtual methods from the Operation<BinaryData> and Operation base classes
            // that are candidates for delegation.
            Type operationOfBinaryData = typeof(Operation<BinaryData>);
            Type operationBase = typeof(Operation);

            var baseVirtualMethods = operationOfBinaryData
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Concat(operationBase.GetMethods(BindingFlags.Public | BindingFlags.Instance))
                .Where(m => m.IsVirtual && !m.IsFinal)
                .Where(m => m.DeclaringType != typeof(object)) // Exclude System.Object methods
                .Select(m => m.Name)
                .Distinct()
                .ToList();

            // Get methods that OperationWithId explicitly overrides
            var overriddenMethods = new HashSet<string>(
                operationWithIdType!
                    .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                    .Where(m => m.IsVirtual)
                    .Select(m => m.Name),
                StringComparer.Ordinal);

            // Also include properties (get_Value, get_HasValue, etc.)
            var overriddenProperties = new HashSet<string>(
                operationWithIdType
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                    .Select(p => p.Name),
                StringComparer.Ordinal);

            // Find virtual methods that are NOT overridden and NOT in the allowlist
            var missingOverrides = new List<string>();
            foreach (string methodName in baseVirtualMethods)
            {
                // Strip "get_" / "set_" prefix for property accessors
                string baseName = methodName.StartsWith("get_", StringComparison.Ordinal) ||
                                  methodName.StartsWith("set_", StringComparison.Ordinal)
                    ? methodName.Substring(4)
                    : methodName;

                if (AllowedNonOverrides.Contains(baseName))
                    continue;

                // Check if it's overridden as a method or as a property
                bool isOverridden = overriddenMethods.Contains(methodName)
                    || overriddenProperties.Contains(baseName);

                if (!isOverridden)
                {
                    missingOverrides.Add(methodName);
                }
            }

            Assert.IsEmpty(missingOverrides,
                $"OperationWithId is missing overrides for the following virtual methods from " +
                $"Operation<BinaryData>/Operation. These must be delegated to _internalOperation " +
                $"to avoid falling back to the base class default (which may return incorrect values). " +
                $"If a method intentionally should NOT be overridden, add it to the AllowedNonOverrides " +
                $"set with a justification comment.\n\n" +
                $"Missing overrides:\n  - {string.Join("\n  - ", missingOverrides)}");
        }
    }
}
