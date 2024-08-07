// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    /// <summary>
    /// Mark the parameter as the SignalR parameter that need to bind arguments.
    /// It's mutually exclusive with <see cref="SocketIOTriggerAttribute.ParameterNames"/>. That means
    /// you can not set <see cref="SocketIOTriggerAttribute.ParameterNames"/> and use <see cref="SocketIOParameterAttribute"/>
    /// at the same time.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public class SocketIOParameterAttribute : Attribute
    {
    }
}
