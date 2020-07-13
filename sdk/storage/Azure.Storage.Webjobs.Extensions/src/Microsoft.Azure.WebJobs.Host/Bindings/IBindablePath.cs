﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Defines an interface for performing path bindings.
    /// </summary>
    /// <typeparam name="TPath">The type of the path binding.</typeparam>
    internal interface IBindablePath<TPath>
    {
        /// <summary>
        /// Gets a value indicating whether this path is bound.
        /// </summary>
        bool IsBound { get; }

        /// <summary>
        /// Gets the collection of parameter names for the path.
        /// </summary>
        IEnumerable<string> ParameterNames { get; }

        /// <summary>
        /// Bind to the path.
        /// </summary>
        /// <param name="bindingData">The binding data.</param>
        /// <returns>The path binding.</returns>
        TPath Bind(IReadOnlyDictionary<string, object> bindingData);

        /// <summary>
        /// Gets a string representation of the path.
        /// </summary>
        /// <returns></returns>
        string ToString();
    }
}
