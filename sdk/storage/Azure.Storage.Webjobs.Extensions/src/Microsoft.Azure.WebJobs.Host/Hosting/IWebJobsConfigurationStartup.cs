// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Hosting
{
    /// <summary>
    /// Interface defining a startup action for configuring application configuration
    /// as part of host startup.
    /// </summary>
    public interface IWebJobsConfigurationStartup
    {
        /// <summary>
        /// Performs the startup action for configuring application configuration with an 
        /// <see cref="Extensions.Configuration.IConfigurationBuilder"></see>. The host will call this method at the
        /// right time during host initialization.
        /// </summary>
        /// <param name="context">The builder context</param>
        /// <param name="builder">The <see cref="IWebJobsConfigurationBuilder"/> that can be used to
        /// configure the host application configuration.</param>
        void Configure(WebJobsBuilderContext context, IWebJobsConfigurationBuilder builder);
    }
}
