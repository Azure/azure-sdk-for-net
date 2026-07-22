// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// Binds the validation status of the incoming security token to a function return value or parameter.
    /// </summary>
    [AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Parameter)]
    [Binding]
    public class SecurityTokenValidationAttribute : Attribute
    {
    }
}