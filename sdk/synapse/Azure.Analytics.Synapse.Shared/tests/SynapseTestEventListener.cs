// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;

namespace Azure.Analytics.Synapse.Tests
{
    /// <summary>
    /// Wraps an <see cref="AzureEventSourceListener"/> when running live tests.
    /// </summary>
    internal class SynapseTestEventListener : IDisposable
    {
        private AzureEventSourceListener _listener;

        /// <summary>
        /// Creates a new instance of the <see cref="SynapseTestEventListener"/> class.
        /// </summary>
        public SynapseTestEventListener()
        {
            // Log responses when running live tests for diagnostics.
            if ("Live".Equals(Environment.GetEnvironmentVariable("AZURE_SYNAPSE_TEST_MODE"), StringComparison.OrdinalIgnoreCase))
            {
                _listener = AzureEventSourceListener.CreateConsoleLogger(EventLevel.Verbose);
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (_listener != null)
            {
                _listener.Dispose();
                _listener = null;
            }
        }
    }
}
