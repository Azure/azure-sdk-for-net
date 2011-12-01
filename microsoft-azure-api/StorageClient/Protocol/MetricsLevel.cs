//-----------------------------------------------------------------------
// <copyright file="MetricsLevel.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the MetricsLevel enum.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    /// <summary>
    /// Enumeration representing the state of metrics collection in a service.
    /// </summary>
    public enum MetricsLevel
    {
        /// <summary>
        /// Metrics collection is disabled.
        /// </summary>
        None = 0,

        /// <summary>
        /// Service-level metrics collection is enabled.
        /// </summary>
        Service,

        /// <summary>
        /// Service-level and API metrics collection are enabled.
        /// </summary>
        ServiceAndApi
    }
}
