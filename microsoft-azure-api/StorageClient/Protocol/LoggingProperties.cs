//-----------------------------------------------------------------------
// <copyright file="LoggingProperties.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the LoggingProperties class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class representing the service properties pertaining to logging.
    /// </summary>
    public class LoggingProperties
    {
        /// <summary>
        /// Gets or sets the version of the analytics service.
        /// </summary>
        /// <value>A string identifying the version of the service.</value>
        public string Version
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the state of logging.
        /// </summary>
        /// <value>A combination of <see cref="LoggingOperations"/> flags describing the operations that are logged.</value>
        public LoggingOperations LoggingOperations
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the logging retention policy.
        /// </summary>
        /// <value>The number of days to retain the logs.</value>
        public int? RetentionDays
        {
            get;
            set;
        }
    }
}
