// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Provides methods for registering 3rd party extensions (e.g. bindings).
    /// </summary>
    public interface IExtensionRegistry
    {
        /// <summary>
        /// Registers the specified instance.
        /// </summary>
        /// <param name="type">The service type to register the instance for.</param>
        /// <param name="instance">The instance to register.</param>
        void RegisterExtension(Type type, object instance);

        /// <summary>
        /// Returns the collection of extension instances registered for the specified type.
        /// </summary>
        /// <param name="type">The extension type to return instances for.</param>
        /// <returns>The collection of extension instances.</returns>
        IEnumerable<object> GetExtensions(Type type);
    }
}
