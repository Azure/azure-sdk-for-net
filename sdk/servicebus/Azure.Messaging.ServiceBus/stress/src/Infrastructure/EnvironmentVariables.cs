// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Stress;

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
    public const string ServiceBusConnectionString = "STRESS_SERVICEBUS_NAMESPACE_CONNECTION_STRING";

    // Queue Names

    /// <summary>
    ///   The name of the environment variable that holds the name of the Service Bus queue
    ///   for each test.
    /// </summary>
    ///
    public const string ServiceBusQueue = "STRESS_SERVICEBUS_QUEUE";

    /// <summary>
    ///   The name of the environment variable that holds the name of the Service Bus queue
    ///   for each test that requires a sessionful queue.
    /// </summary>
    ///
    public const string ServiceBusSessionQueue = "STRESS_SERVICEBUS_SESSION_QUEUE";

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