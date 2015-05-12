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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Azure.KeyVault.Cryptography.Algorithms;

namespace Microsoft.Azure.KeyVault.Cryptography
{
    /// <summary>
    /// Resolves algorithm name to implementations.
    /// </summary>
    public class AlgorithmResolver
    {
        static AlgorithmResolver()
        {
            Default.AddAlgorithm( Aes128CbcHmacSha256.AlgorithmName, new Aes128CbcHmacSha256() );
            Default.AddAlgorithm( Aes192CbcHmacSha384.AlgorithmName, new Aes192CbcHmacSha384() );
            Default.AddAlgorithm( Aes256CbcHmacSha512.AlgorithmName, new Aes256CbcHmacSha512() );

            Default.AddAlgorithm( Aes128Cbc.AlgorithmName, new Aes128Cbc() );
            Default.AddAlgorithm( Aes192Cbc.AlgorithmName, new Aes192Cbc() );
            Default.AddAlgorithm( Aes256Cbc.AlgorithmName, new Aes256Cbc() );

            Default.AddAlgorithm( AesKw128.AlgorithmName, new AesKw128() );
            Default.AddAlgorithm( AesKw192.AlgorithmName, new AesKw192() );
            Default.AddAlgorithm( AesKw256.AlgorithmName, new AesKw256() );

            Default.AddAlgorithm( Rsa15.AlgorithmName, new Rsa15() );
            Default.AddAlgorithm( RsaOaep.AlgorithmName, new RsaOaep() );

            Default.AddAlgorithm( Rs256.AlgorithmName, new Rs256() );
            Default.AddAlgorithm( RsNull.AlgorithmName, new RsNull() );
        }

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes")]
        public static readonly AlgorithmResolver Default = new AlgorithmResolver();

        private readonly Dictionary<string, Algorithm> _algorithms = new Dictionary<string, Algorithm>();

        /// <summary>
        /// Returns the implementation for an algorithm name
        /// </summary>
        /// <param name="algorithmName">The algorithm name</param>
        /// <returns></returns>
        public Algorithm this[ string algorithmName ]
        {
            get { return _algorithms[algorithmName]; }
            set { _algorithms[algorithmName] = value;  }
        }

        /// <summary>
        /// Adds an algorithm to the resolver
        /// </summary>
        /// <param name="algorithmName">The algorithm name</param>
        /// <param name="provider">The provider for the algorithm</param>
        public void AddAlgorithm( string algorithmName, Algorithm provider )
        {
            if ( string.IsNullOrWhiteSpace( algorithmName ) )
                throw new ArgumentNullException( "algorithmName" );

            if ( provider == null )
                throw new ArgumentNullException( "provider" );

            _algorithms[algorithmName] = provider;
        }

        /// <summary>
        /// Removes an algorithm from the resolver
        /// </summary>
        /// <param name="algorithmName">The algorithm name</param>
        public void RemoveAlgorithm( string algorithmName )
        {
            _algorithms.Remove( algorithmName );
        }
    }
}
