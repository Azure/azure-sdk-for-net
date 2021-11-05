// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal interface IBindableServiceBusPath
    {
        string QueueOrTopicNamePattern { get; }

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
        string Bind(IReadOnlyDictionary<string, object> bindingData);

        /// <summary>
        /// Gets a string representation of the path.
        /// </summary>
        /// <returns></returns>
        string ToString();
    }
}
