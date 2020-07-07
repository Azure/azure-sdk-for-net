// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.WebJobs
{
    public interface IWebJobsBuilder
    {
        /// <summary>
        /// Gets the <see cref="IServiceCollection"/> where WebJobs services are configured.
        /// </summary>
        IServiceCollection Services { get; }
    }
}
