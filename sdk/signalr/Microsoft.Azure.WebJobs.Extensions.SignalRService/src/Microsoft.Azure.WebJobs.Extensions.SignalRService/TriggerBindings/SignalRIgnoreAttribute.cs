// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// In class based model, mark the parameter explicitly not to be a SignalR parameter.
    /// That means it won't be bound to a InvocationMessage argument.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public class SignalRIgnoreAttribute : Attribute
    {
    }
}