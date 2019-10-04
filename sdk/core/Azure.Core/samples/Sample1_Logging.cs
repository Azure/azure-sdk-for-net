// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;
using NUnit.Framework;

namespace Azure.Core.Samples
{
    public partial class CoreSamples
    {
        // AzureEventSourceListener logs lots of useful information automatically to .NET's EventSource.
        // This sample illustrate how to control and access the log information.
        [Test]
        public void Logging()
        {
            #region Snippet:ConsoleLogging
            // Setup a listener to monitor logged events.
            using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger(EventLevel.LogAlways);
            #endregion
        }
    }
}
