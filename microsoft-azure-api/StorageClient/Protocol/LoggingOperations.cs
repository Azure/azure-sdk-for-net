//-----------------------------------------------------------------------
// <copyright file="LoggingOperations.cs" company="Microsoft">
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
//    Contains code for the LoggingOperations enum.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;

    /// <summary>
    /// Enumeration representing the state of logging in a service.
    /// </summary>
    [Flags]
    public enum LoggingOperations
    {
        /// <summary>
        /// Logging is disabled.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// Log read operations.
        /// </summary>
        Read = 0x1,

        /// <summary>
        /// Log write operations.
        /// </summary>
        Write = 0x2,

        /// <summary>
        /// Log delete operations.
        /// </summary>
        Delete = 0x4,

        /// <summary>
        /// Log all operations.
        /// </summary>
        All = 0x7
    }
}
