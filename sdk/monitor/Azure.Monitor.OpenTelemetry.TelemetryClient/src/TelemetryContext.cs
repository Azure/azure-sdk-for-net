// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Azure.Monitor.OpenTelemetry.TelemetryClient
{
    /// <summary>
    /// Represents a context for sending telemetry to the Application Insights service.
    /// </summary>
    public sealed class TelemetryContext
    {
        internal IDictionary<string, string> GlobalPropertiesValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="TelemetryContext"/> class.
        /// </summary>
        public TelemetryContext()
            : this(new Dictionary<string, string>())
        {
        }

        internal TelemetryContext(IDictionary<string, string> globalProperties)
        {
            this.GlobalPropertiesValue = globalProperties;
        }

        /// <summary>
        /// Gets a dictionary of application-defined property values which are global in scope.
        /// Future SDK versions could serialize this separately from the item level properties.
        /// <a href="https://go.microsoft.com/fwlink/?linkid=525722#properties">Learn more</a>
        /// </summary>
        public IDictionary<string, string> GlobalProperties
        {
            get
            {
                return LazyInitializer.EnsureInitialized(ref GlobalPropertiesValue,
                    () => new ConcurrentDictionary<string, string>());
            }
        }
    }
}
