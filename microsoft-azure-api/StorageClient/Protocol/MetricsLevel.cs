//-----------------------------------------------------------------------
// <copyright file="MetricsLevel.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
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
