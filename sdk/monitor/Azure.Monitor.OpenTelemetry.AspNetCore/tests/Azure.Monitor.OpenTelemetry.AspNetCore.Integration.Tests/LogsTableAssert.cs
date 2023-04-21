// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.Query.Models;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    public class LogsTableAssert : NUnit.Framework.Assert
    {
        public static void Any(LogsTable? logsTable, string errorMessage)
        {
            var rowCount = logsTable?.Rows.Count;
            if (rowCount == null || rowCount == 0)
            {
                Inconclusive(errorMessage);
            }
            else
            {
                True(true);
            }
        }
    }
}
