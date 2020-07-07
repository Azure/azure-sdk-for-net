// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Provides context information for job function invocations.
    /// </summary>
    public class ExecutionContext
    {
        /// <summary>
        /// Gets or sets the job function invocation ID
        /// </summary>
        public Guid InvocationId { get; set; }

        /// <summary>
        /// Gets or sets the name of the function being invoked
        /// </summary>
        public string FunctionName { get; set; }

        /// <summary>
        /// Gets or sets the function directory. This is <see cref="FunctionAppDirectory"/> concatenated with <see cref="FunctionName"/>
        /// </summary>
        public string FunctionDirectory { get; set; }

        /// <summary>
        /// Gets or sets the function application directory as determined by the host.  May be null if not set. 
        /// </summary>
        /// <remarks>
        /// A host can set this via <see cref="CoreJobHostConfigurationExtensions.UseCore(JobHostConfiguration, string)"/>
        /// </remarks>
        public string FunctionAppDirectory { get; set; }
    }
}
