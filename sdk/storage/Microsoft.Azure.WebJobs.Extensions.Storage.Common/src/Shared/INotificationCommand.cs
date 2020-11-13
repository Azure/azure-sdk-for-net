// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners
{
    internal interface INotificationCommand
    {
        void Notify();
    }
}
