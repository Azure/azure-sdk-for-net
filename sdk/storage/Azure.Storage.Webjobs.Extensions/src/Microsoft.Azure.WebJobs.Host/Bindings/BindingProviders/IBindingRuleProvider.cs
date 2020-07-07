// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Interface for providing binding rules.
    /// </summary>
    /// <remarks>
    /// This enables <see cref="IBindingProvider"/>s to be self describing which
    /// supports tooling scenarios.
    /// </remarks>
    internal interface IBindingRuleProvider
    {
        /// <summary>
        /// Gets the <see cref="BindingRule"/>s for this binding. 
        /// </summary>
        /// <returns></returns>
        IEnumerable<BindingRule> GetRules();

        /// <summary>
        /// Gets the default binding type for the specified binding options.
        /// </summary>
        /// <param name="attribute">The binding attribute. This does not need to be resolved.</param>
        /// <param name="access">The direction of the binding.</param>
        /// <param name="requestedType">The requested binding type. Specify object if none is requested,
        /// otherwise provide a specific type (e.g. string, byte[], stream, JObject).
        /// </param>
        /// <returns>Null if unknown. Else a type that the parameter can be bound to. </returns>
        Type GetDefaultType(Attribute attribute, FileAccess access, Type requestedType);
    }
}