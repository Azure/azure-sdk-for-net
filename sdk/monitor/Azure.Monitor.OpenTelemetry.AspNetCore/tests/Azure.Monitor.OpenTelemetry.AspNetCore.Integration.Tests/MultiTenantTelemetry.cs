// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Monitor.Query.Logs.Models;
using NUnit.Framework;

#if NET
namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    internal static class MultiTenantTelemetry
    {
        internal sealed class Record
        {
            internal Record(string recordId, string workspaceId, string resourceId, string table, string operationId, string parentId)
            {
                RecordId = recordId;
                WorkspaceId = workspaceId;
                ResourceId = resourceId;
                Table = table;
                OperationId = operationId;
                ParentId = parentId;
            }

            internal string RecordId { get; }
            internal string WorkspaceId { get; }
            internal string ResourceId { get; }
            internal string Table { get; }
            internal string OperationId { get; }
            internal string ParentId { get; }
        }

        internal static HashSet<string> ValidateQuery(IReadOnlyDictionary<string, Record> expected, IEnumerable<Record> observed, LogsQueryResultStatus status)
        {
            Assert.That(status, Is.EqualTo(LogsQueryResultStatus.Success), "Partial queries cannot establish completeness or tenant isolation.");
            var seen = new HashSet<string>();
            foreach (var record in observed)
            {
                Assert.That(expected.TryGetValue(record.RecordId, out var item), Is.True, $"Unexpected record {record.RecordId} in {record.ResourceId}.");
                Assert.That(record.WorkspaceId, Is.EqualTo(item!.WorkspaceId).IgnoreCase, $"Wrong workspace for {record.RecordId}.");
                Assert.That(record.ResourceId, Is.EqualTo(item.ResourceId).IgnoreCase, $"Wrong resource for {record.RecordId}.");
                Assert.That(record.Table, Is.EqualTo(item.Table), $"Wrong signal for {record.RecordId}.");
                Assert.That(record.OperationId, Is.EqualTo(item.OperationId), $"Trace correlation mismatch for {record.RecordId}.");
                Assert.That(record.ParentId, Is.EqualTo(item.ParentId), $"Parent correlation mismatch for {record.RecordId}.");
                seen.Add(record.RecordId);
            }
            return seen;
        }
    }
}
#endif