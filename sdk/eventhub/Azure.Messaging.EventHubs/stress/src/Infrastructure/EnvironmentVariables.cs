// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   This class holds the set of all the names of the variables to use from the .env environment file.
/// </summary>
///
public static class EnvironmentVariables
{
    // Shared Resources

    /// <summary>
    ///   The name of the environment variable that holds the instrumentation key for the
    ///   Application Insights resource for the test runs.
    /// </summary>
    ///
    public const string ApplicationInsightsKey = "APPINSIGHTS_INSTRUMENTATIONKEY";

    /// <summary>
    ///   The name of the environment variable that holds the connection string for the
    ///   Event Hubs Namespace resource for the test runs.
    /// </summary>
    ///
    public const string EventHubsConnectionString = "EVENTHUB_NAMESPACE_CONNECTION_STRING";

    // Event Hub Names

    /// <summary>
    ///   The name of the environment variable that holds the name of the Event Hub resource
    ///   for the Event Hub Buffered Producer test scenario.
    /// </summary>
    ///
    public const string EventHubBufferedProducerTest = "EVENTHUB_NAME_BUFFERED_PRODUCER_TEST";

    /// <summary>
    ///   The name of the environment variable that holds the name of the Event Hub resource
    ///   for the Event Hub Producer test scenario.
    /// </summary>
    ///
    public const string EventHubEventProducerTest = "EVENTHUB_NAME_EVENT_PRODUCER_TEST";

    /// <summary>
    ///   The name of the environment variable that holds the name of the Event Hub resource for the
    ///   Event Hub burst Buffered Producer test scenario.
    /// </summary>
    ///
    public const string EventHubBurstBufferedProducerTest = "EVENTHUB_NAME_BURST_BUFFERED_PRODUCER_TEST";

    /// <summary>
    ///   The name of the environment variable that holds the name of the Event Hub resource for the processor test scenario.
    /// </summary>
    ///
    public const string EventHubProcessorTest = "EVENTHUB_NAME_PROCESSOR_TEST";

    /// <summary>
    ///   The name of the environment variable that holds the name of the storage blob resource for the processor test
    ///   scenario.
    /// </summary>
    ///
    public const string StorageBlobProcessorTest = "STORAGE_BLOB_PROCESSOR_TEST";

    /// <summary>
    ///   The name of the environment variable that holds the name of the storage account connection string for the processor test
    ///   scenario.
    /// </summary>
    ///
    public const string StorageAccountProcessorTest = "STORAGE_ACCOUNT_PROCESSOR_TEST";

    // Job Index Information

    /// <summary>
    ///   The name of the environment variable that holds the index of the Kubernetes pod. This variable should
    ///   only be set when deploying tests to the Kubernetes cluster, and it allows each test to run all of its roles
    ///   in separate pods. For more information see
    ///   <see href="https://kubernetes.io/docs/tasks/job/indexed-parallel-processing-static/">Kubernetes Documentation on Indexed Jobs</see>
    /// </summary>
    ///
    public const string JobCompletionIndex = "JOB_COMPLETION_INDEX";
}