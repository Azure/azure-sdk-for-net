// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    /// <summary> An instance of Exception represents a handled or unhandled exception that occurred during execution of the monitored application. </summary>
    internal partial class TelemetryExceptionData : MonitorDomain
    {
        /// <summary> Initializes a new instance of <see cref="TelemetryExceptionData"/>. </summary>
        /// <param name="version"> Schema version. </param>
        /// <param name="exceptions"> Exception chain - list of inner exceptions. </param>
        /// <param name="properties">Collection of custom properties.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="exceptions"/> is null. </exception>
        internal TelemetryExceptionData(int version, IEnumerable<TelemetryExceptionDetails> exceptions, IDictionary<string, string> properties) : base(version)
        {
            Argument.AssertNotNull(exceptions, nameof(exceptions));

            Exceptions = exceptions.ToList();
            Properties = properties;
            Measurements = new ChangeTrackingDictionary<string, double>();
        }
    }
}
