//-----------------------------------------------------------------------
// <copyright file="LoggingOperations.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
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
