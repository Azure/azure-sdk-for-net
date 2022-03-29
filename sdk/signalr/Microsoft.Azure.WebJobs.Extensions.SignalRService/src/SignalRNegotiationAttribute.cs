// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// An input binding attribute to bind <see cref="NegotiationContext"/> to the function parameter.
    /// </summary>
    /// <remarks>Designed for function languages except C# to customize negotiation routing.</remarks>
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class SignalRNegotiationAttribute : NegotiationBaseAttribute
    {
    }
}