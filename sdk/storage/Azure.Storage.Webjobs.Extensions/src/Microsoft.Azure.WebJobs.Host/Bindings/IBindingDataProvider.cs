// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Interface defining methods used to generate binding contracts as well as binding data
    /// based on those contracts.
    /// </summary>
    public interface IBindingDataProvider
    {
        /// <summary>
        /// Gets the binding contract.
        /// </summary>
        IReadOnlyDictionary<string, Type> Contract { get; }

        /// <summary>
        /// Returns the binding data for the specified value.
        /// </summary>
        /// <param name="value">The value to return binding data for.</param>
        /// <returns>The collection of binding data or null.</returns>
        IReadOnlyDictionary<string, object> GetBindingData(object value);
    }
}
