// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    [Obsolete("Will be removed in a future release")]
    public interface IWatchable
    {
        IWatcher Watcher { get; }
    }
}
