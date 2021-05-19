// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Iot.TimeSeriesInsights
{
    /// <summary>
    /// The options for <see cref="TimeSeriesInsightsClient"/>
    /// </summary>
    public class TimeSeriesInsightsClientOptions : ClientOptions
    {
        internal const ServiceVersion LatestVersion = ServiceVersion.V2020_07_31;

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSeriesInsightsClientOptions"/>.
        /// </summary>
        public TimeSeriesInsightsClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;
        }

        /// <summary>
        /// The template service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// 2020-07-31
            /// </summary>
#pragma warning disable CA1707 // Remove the underscores from member name
            V2020_07_31 = 1
#pragma warning restore
        }

        internal string GetVersionString()
        {
            return Version switch
            {
                ServiceVersion.V2020_07_31 => "2020-07-31",
                _ => throw new ArgumentException(Version.ToString()),
            };
        }
    }
}
