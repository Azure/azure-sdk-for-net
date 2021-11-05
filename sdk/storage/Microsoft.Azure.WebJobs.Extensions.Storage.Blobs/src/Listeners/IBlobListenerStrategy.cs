// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal interface IBlobListenerStrategy : IBlobNotificationStrategy, IDisposable
    {
        void Start();

        void Cancel();
    }
}
