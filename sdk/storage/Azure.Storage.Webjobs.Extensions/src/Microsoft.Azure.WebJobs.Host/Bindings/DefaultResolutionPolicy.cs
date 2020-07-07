// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Bindings.Path;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Resolution policy for { } in  binding templates. 
    /// The default policy is just a direct substitution for the binding data. 
    /// Derived policies can enforce formatting / escaping when they do injection. 
    /// </summary>
    internal class DefaultResolutionPolicy : IResolutionPolicy
    {
        public string TemplateBind(PropertyInfo propInfo, Attribute attribute, BindingTemplate template, IReadOnlyDictionary<string, object> bindingData)
        {
            return template.Bind(bindingData);
        }
    }
}
