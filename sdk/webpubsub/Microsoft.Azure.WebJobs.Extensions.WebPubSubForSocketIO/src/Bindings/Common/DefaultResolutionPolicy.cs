// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Bindings.Path;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Copy from: https://github.com/Azure/azure-webjobs-sdk/blob/v3.0.29/src/Microsoft.Azure.WebJobs.Host/Bindings/DefaultResolutionPolicy.cs.
    /// </summary>
    /// <summary>
    /// Resolution policy for { } in  binding templates.
    /// The default policy is just a direct substitution for the binding data.
    /// Derived policies can enforce formatting / escaping when they do injection.
    /// </summary>
#pragma warning disable CS0618
    internal class DefaultResolutionPolicy : IResolutionPolicy
    {
        public string TemplateBind(PropertyInfo propInfo, Attribute attribute, BindingTemplate template, IReadOnlyDictionary<string, object> bindingData)
        {
            return template.Bind(bindingData);
        }
    }
}
#pragma warning restore CS0618