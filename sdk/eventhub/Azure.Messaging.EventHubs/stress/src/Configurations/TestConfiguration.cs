// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The set of configurations to use for a test scenario run.
/// </summary>
///
internal class TestConfiguration
{
    // Resource Configurations

    /// <summary>
    ///   The Event Hubs Namespace connection string to use for a test run.
    /// </summary>
    ///
    public string EventHubsConnectionString = string.Empty;

    /// <summary>
    ///   The name of the Event Hub to use for a test run.
    /// </summary>
    ///
    public string EventHub = string.Empty;

    /// <summary>
    ///   The Storage account connection string to use for a test run.
    /// </summary>
    ///
    public string StorageConnectionString = string.Empty;

    /// <summary>
    ///   The blob storage container to use for a test run.
    /// </summary>
    ///
    public string BlobContainer = string.Empty;

    // Test Run Configurations

    /// <summary>
    ///   The number of hours to run a test scenario for.
    /// </summary>
    ///
    public int DurationInHours = 150;
}