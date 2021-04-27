﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Microsoft.Azure.EventHubs.Tests;
using Azure.Test.Perf;

try
{
    // Ensure that there is an active Event Hubs namespace that can be used across all
    // scenarios.  Requesting the connection string will trigger creation of an ephemeral
    // namespace if an existing one wasn't explicitly provided.

    _ = TestUtility.EventHubsConnectionString;

    // Allow the framework to execute the test scenarios.

    await PerfProgram.Main(Assembly.GetEntryAssembly(), args);
}
finally
{
    if (TestUtility.ShouldRemoveNamespaceAfterTestRunCompletion)
    {
        try
        {
            await EventHubScope.DeleteNamespaceAsync(TestUtility.EventHubsNamespace).ConfigureAwait(false);
        }
        catch
        {
            // This should not be considered a critical failure that results in a run failure.  Due
            // to ARM being temperamental, some management operations may be rejected.  Throwing here
            // does not help to ensure resource cleanup.
            //
            // Assume the standard orphan resource cleanup is being run and will take responsibility
            // for cleaning up any orphans.
        }
    }
}
