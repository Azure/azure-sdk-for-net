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

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.Core;

namespace Microsoft.Azure.KeyVault
{
    public class AggregateKeyResolver : IKeyResolver
    {
        private readonly ConcurrentBag<IKeyResolver> _resolvers = new ConcurrentBag<IKeyResolver>();

        public AggregateKeyResolver Add( IKeyResolver resolver )
        {
            if ( resolver == null )
                throw new ArgumentNullException( "resolver" );

            _resolvers.Add( resolver );

            return this;
        }

        #region IKeyResolver

        public async Task<IKey> ResolveKeyAsync( string kid, CancellationToken token )
        {
            foreach ( var resolver in _resolvers )
            {
                IKey resolved = await resolver.ResolveKeyAsync( kid, token ).ConfigureAwait( false );

                if ( resolved != null )
                {
                    return resolved;
                }
            }

            return null;
        }

        #endregion
    }
}
