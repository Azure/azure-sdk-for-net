// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Listeners;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host
{
    public interface IDrainModeManager
    {
        bool IsDrainModeEnabled { get; }

        void RegisterListener(IListener listener);

        void RegisterTokenSource(Guid guid, CancellationTokenSource tokenSource);

        void UnRegisterTokenSource(Guid guid);

        Task EnableDrainModeAsync(CancellationToken cancellationToken);
    }
}