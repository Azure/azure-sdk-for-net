﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal interface IBlobListenerStrategy : IBlobNotificationStrategy, IDisposable
    {
        void Start();

        void Cancel();
    }
}
