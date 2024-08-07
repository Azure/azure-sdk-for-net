// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("CommunicationJobRouterModelFactory")]
    [CodeGenSuppress("WaitTimeExceptionTrigger", typeof(TimeSpan))]
    public static partial class JobRouterModelFactory
    {
    }
}
