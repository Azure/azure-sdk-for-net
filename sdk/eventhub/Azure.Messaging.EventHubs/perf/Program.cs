// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Azure.Messaging.EventHubs.Tests;
using Azure.Test.Perf;

// Ensure that there is an active Event Hubs namespace that can be used across all
// scenarios.  Requesting the connection string will trigger an exception if the necessary
// resources are not available.

_ = EventHubsTestEnvironment.Instance.EventHubsConnectionString;

// Allow the framework to execute the test scenarios.

await PerfProgram.Main(Assembly.GetEntryAssembly(), args);
