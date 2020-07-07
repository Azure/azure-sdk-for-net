// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.Host.Triggers
{
    /// <summary>
    /// Defines an interface for representing data returned after a trigger
    /// parameter value is bound.
    /// </summary>
    public interface ITriggerData
    {
        /// <summary>
        /// Gets the <see cref="IValueProvider"/> for the bound parameter value.
        /// </summary>
        IValueProvider ValueProvider { get; }

        /// <summary>
        /// Gets the collection of binding data for the bound parameter value.
        /// </summary>
        IReadOnlyDictionary<string, object> BindingData { get; }
    }
}
