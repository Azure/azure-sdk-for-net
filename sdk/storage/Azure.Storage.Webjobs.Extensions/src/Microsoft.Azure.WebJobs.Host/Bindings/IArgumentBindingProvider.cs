// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Reflection;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Defines a provider of argument bindings of the specified type.
    /// </summary>
    /// <typeparam name="TArgumentBinding">The argument binding type.</typeparam>
    public interface IArgumentBindingProvider<TArgumentBinding>
    {
        /// <summary>
        /// Attempt to create an argument binding for the specified parameter.
        /// </summary>
        /// <param name="parameter">The property create a binding for.</param>
        /// <returns>A binding extension if this provider can bind to
        /// the parameter, false otherwise.</returns>
        TArgumentBinding TryCreate(ParameterInfo parameter);
    }
}
