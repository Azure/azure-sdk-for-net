// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Communication.JobRouter
{
    [CodeGenType("CommunicationJobRouterModelFactory")]
    [CodeGenSuppress("WaitTimeExceptionTrigger", typeof(TimeSpan))]
    public static partial class JobRouterModelFactory
    {
    }
}
