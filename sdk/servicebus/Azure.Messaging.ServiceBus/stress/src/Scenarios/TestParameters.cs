// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Azure.Messaging.ServiceBus.Stress;

/// <summary>
///   The set of configurations to use for a test scenario run.
/// </summary>
///
public class TestParameters : IDisposable
{
    // Resource Configurations

    /// <summary>
    ///   The Service Bus Namespace connection string to use for a test run.
    /// </summary>
    ///
    public string ServiceBusConnectionString = string.Empty;

    /// <summary>
    ///   The name of the Service Bus Queue to use for a test run.
    /// </summary>
    ///
    public string QueueName = string.Empty;

    // Test Run Configurations

    /// <summary>
    ///   The number of hours to run a test scenario for.
    /// </summary>
    ///
    public int DurationInHours = 1;

    /// <summary>
    ///   The handler to use for processing messages in this test's processor instance.
    /// <summary/>
    ///
    public Func<ProcessMessageEventArgs, Task> messageHandler;

    /// <summary>
    ///   The handler to use for processing errors in this test's processor instance.
    /// <summary/>
    ///
    public Func<ProcessErrorEventArgs, Task> errorHandler;

    /// <summary>
    ///   The hasher to use when hashing event bodies for validation.
    /// </summary>
    ///
    public SHA256 Sha256Hash = SHA256.Create();

    /// <summary>If the <see cref="TestParameters" /> instance has been disposed.</summary>
    private bool _disposed = false;

    public void Dispose()
    {
        if (!_disposed)
        {
            Sha256Hash.Dispose();
            _disposed = true;
        }
    }
}
