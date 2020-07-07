// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    [Obsolete("Will be removed in a future release")]
    public interface IWatcher
    {
        ParameterLog GetStatus();
    }
}
