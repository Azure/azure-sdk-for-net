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

#if !PORTABLE

using System;
using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography
{

    /// <summary>
    /// Supported algorithm names. Do not add to this enumeration
    /// without also modifying IncrementHash.Create / CreateHMAC
    /// </summary>
    public enum HashAlgorithmName
    {
        SHA256,
        SHA384,
        SHA512,
    }

    public sealed class IncrementalHash : IDisposable
    {
        private static readonly byte[] NullBuffer = new byte[0];

        public static IncrementalHash CreateHMAC( HashAlgorithmName algorithmName, byte[] key )
        {
            HMAC hmac = null;

            switch ( algorithmName )
            {
                case HashAlgorithmName.SHA256:
                    hmac = new HMACSHA256( key );
                    break;

                case HashAlgorithmName.SHA384:
                    hmac = new HMACSHA384( key );
                    break;

                case HashAlgorithmName.SHA512:
                    hmac = new HMACSHA512( key );
                    break;

                default:
                    throw new NotSupportedException( "Unsupported HashAlgorithmName" );
            }

            return new IncrementalHash( hmac );
        }

        private HMAC _hmac;

        private IncrementalHash( HMAC hmac )
        {
            _hmac = hmac;
        }

        public void AppendData( byte[] data )
        {
            if ( _hmac == null ) throw new ObjectDisposedException( "IncrementalHash" );

            _hmac.TransformBlock( data, 0, data.Length, data, 0 );
        }

        public byte[] GetHashAndReset()
        {
            // This is the only opportunity we have to finalize the hash for dnx451
            _hmac.TransformFinalBlock( NullBuffer, 0, 0 );

            return _hmac.Hash;
        }

        public void Dispose()
        {
            if ( _hmac != null )
            {
                _hmac.Dispose();
                _hmac = null;
            }
        }
    }

}

#endif
