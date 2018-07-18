//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.KeyVault.Core
{
    /// <summary>
    /// Interface for key resolvers.
    /// </summary>
    public interface IKeyResolver
    {
        /// <summary>
        /// Provides an IKey implementation for the specified key identifier.
        /// </summary>
        /// <param name="kid">The key identifier to resolve</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>The resolved IKey implementation or null</returns>
        /// <remarks>Implementations should check the format of the kid to ensure that it is recognized. Null, rather than 
        /// an exception, should be returned for unrecognized key identifiers to enable chaining of key resolvers.</remarks>
        Task<IKey> ResolveKeyAsync( string kid, CancellationToken token );
    }
}