// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs
{
    /// <summary>Defines a resolver for %name% variables in attribute values.</summary>
    public interface INameResolver
    {
        /// <summary>
        /// Resolve a %name% to a value. Resolution is not recursive.
        /// </summary>
        /// <param name="name">The name to resolve (without the %... %)</param>
        /// <returns>The value to which the name resolves, if the name is supported; otherwise <see langword="null"/>.</returns>
        string Resolve(string name);
    }
}
