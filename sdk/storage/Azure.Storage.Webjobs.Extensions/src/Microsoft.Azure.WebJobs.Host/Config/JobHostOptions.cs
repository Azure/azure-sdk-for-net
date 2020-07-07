// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Host.Executors;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Represents the configuration settings for a <see cref="JobHost"/>.
    /// </summary>
    public sealed class JobHostOptions
    {
        /// <summary>
        /// Returns true if <see cref="UseDevelopmentSettings"/> has been called on this instance.
        /// </summary>
        internal bool UsingDevelopmentSettings { get; set; }

        
        /// <summary>
        /// Gets or sets a value indicating whether the host should be able to start partially
        /// when some functions are in error. The default is false.
        /// </summary>
        /// <remarks>
        /// Normally when a function encounters an indexing error or its listener fails to start
        /// the error will propagate and the host will not start. However, with this option set,
        /// the host will be allowed to start in "partial" mode:
        ///   - Functions without errors will run normally
        ///   - Functions with indexing errors will not be running
        ///   - Functions listener startup failures will be retried in the background
        ///     until they start.
        /// </remarks>
        public bool AllowPartialHostStartup { get; set; }
    }
}
