// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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