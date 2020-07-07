// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Hosting
{
    /// <summary>
    /// Interface defining a startup configuration action that should be performed
    /// as part of host startup.
    /// </summary>
    public interface IWebJobsStartup2 : IWebJobsStartup
    {
        /// <summary>
        /// Performs the startup configuration action. The host will call this
        /// method at the right time during host initialization.
        /// </summary>
        /// <param name="context">The builder context</param>
        /// <param name="builder">The <see cref="IWebJobsBuilder"/> that can be used to
        /// configure the host.</param>
        void Configure(WebJobsBuilderContext context, IWebJobsBuilder builder);
    }
}
