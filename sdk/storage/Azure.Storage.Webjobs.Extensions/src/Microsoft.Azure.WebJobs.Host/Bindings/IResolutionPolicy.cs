// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Azure.WebJobs.Host.Bindings.Path;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Resolution policy for "{ }" in  binding templates. 
    /// The default policy is a direct substitution for the binding data.
    /// Derived policies can enforce formatting or escaping when they do injection.
    /// </summary>
    [Obsolete("Not ready for public consumption.")]
    public interface IResolutionPolicy
    {
        /// <summary>
        /// Resolves the provided <see cref="BindingTemplate"/>. 
        /// </summary>        
        /// <param name="propInfo">The property being resolved.</param>
        /// <param name="resolvedAttribute">The Attribute being resolved.</param>
        /// <param name="bindingTemplate">The BindingTemplate for the current property.</param>
        /// <param name="bindingData">The data for the current function invocation.</param>
        /// <returns>The resolved property value.</returns>
        string TemplateBind(PropertyInfo propInfo, Attribute resolvedAttribute, BindingTemplate bindingTemplate, IReadOnlyDictionary<string, object> bindingData);
    }
}
