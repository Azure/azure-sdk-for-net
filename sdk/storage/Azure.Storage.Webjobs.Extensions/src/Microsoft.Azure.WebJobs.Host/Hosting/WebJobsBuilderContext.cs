// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Context containing the common services on the WebJobs host. Some properties may be null until set by the host.
    /// </summary>
    public class WebJobsBuilderContext
    {
        /// <summary>
        /// Gets or sets the <see cref="IConfiguration"/> containing the merged configuration of the application and the host.
        /// </summary>
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// Gets or sets the name of the environment. The host automatically sets this property to the value of the of the "environment" key as specified in configuration.
        /// </summary>
        public string EnvironmentName { get; set; }

        /// <summary>
        /// Gets or sets the absolute path to the directory that contains the application content files.
        /// </summary>
        public string ApplicationRootPath { get; set; }
    }
}
