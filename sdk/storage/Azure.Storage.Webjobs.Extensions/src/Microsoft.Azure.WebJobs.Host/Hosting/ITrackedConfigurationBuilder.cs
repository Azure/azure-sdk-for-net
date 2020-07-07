// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Host.Hosting
{
    internal interface ITrackedConfigurationBuilder
    {
        IConfigurationBuilder ConfigurationBuilder { get; set; }

        IEnumerable<IConfigurationSource> TrackedConfigurationSources { get; }

        void ResetTracking();
    }
}
