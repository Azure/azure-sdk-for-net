// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.WebJobs
{
    public interface IWebJobsExtensionBuilder
    {
        /// <summary>
        /// Gets the <see cref="IServiceCollection"/> where WebJobs extension services are configured.
        /// </summary>
        IServiceCollection Services { get; }

        /// <summary>
        /// Gets an <see cref="ExtensionInfo"/> instance containing information about the extension being configured by this builder.
        /// </summary>
        ExtensionInfo ExtensionInfo { get; }
    }
}
