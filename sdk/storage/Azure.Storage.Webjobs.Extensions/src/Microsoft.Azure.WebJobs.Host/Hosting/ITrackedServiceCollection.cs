// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;


namespace Microsoft.Azure.WebJobs.Host.Hosting
{
    internal interface ITrackedServiceCollection
    {
        IServiceCollection ServiceCollection { get; set; }

        IEnumerable<ServiceDescriptor> TrackedCollectionChanges { get; }

        void ResetTracking();
    }
}
