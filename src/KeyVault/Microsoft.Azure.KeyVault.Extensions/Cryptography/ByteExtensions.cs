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

namespace Microsoft.Azure.KeyVault.Cryptography
{
    internal static class ByteExtensions
    {
        internal static bool SequenceEqualConstantTime( this byte[] self, byte[] other )
        {
            if ( self == null )
                throw new ArgumentNullException( "self" );

            if ( other == null )
                throw new ArgumentNullException( "other" );

            // Constant time comparison of two byte arrays
            uint difference = (uint)self.Length ^ (uint)other.Length;

            for ( var i = 0; i < self.Length && i < other.Length; i++ )
            {
                difference |= (uint)( self[i] ^ other[i] );
            }

            return difference == 0;
        }

        internal static byte[] Or( this byte[] self, byte[] other )
        {
            return Or( self, other, 0 );
        }

        internal static byte[] Or( this byte[] self, byte[] other, int offset )
        {
            if ( self == null )
                throw new ArgumentNullException( "self" );

            if ( other == null )
                throw new ArgumentNullException( "other" );

            if ( self.Length > other.Length - offset )
                throw new ArgumentException( "self and other lengths do not match" );

            var result = new byte[self.Length];

            for ( var i = 0; i < self.Length; i++ )
            {
                result[i] = (byte)( self[i] | other[offset + i] );
            }

            return result;
        }

        internal static byte[] Xor( this byte[] self, byte[] other, bool inPlace = false )
        {
            return Xor( self, other, 0, inPlace );
        }

        internal static byte[] Xor( this byte[] self, byte[] other, int offset, bool inPlace = false )
        {
            if ( self == null )
                throw new ArgumentNullException( "self" );

            if ( other == null )
                throw new ArgumentNullException( "other" );

            if ( self.Length > other.Length - offset )
                throw new ArgumentException( "self and other lengths do not match" );

            if ( inPlace )
            {
                for ( var i = 0; i < self.Length; i++ )
                {
                    self[i] = (byte)( self[i] ^ other[offset + i] );
                }

                return self;
            }
            else
            {
                var result = new byte[self.Length];

                for ( var i = 0; i < self.Length; i++ )
                {
                    result[i] = (byte)( self[i] ^ other[offset + i] );
                }

                return result;
            }
        }

        internal static void Zero( this byte[] self )
        {
            if ( self == null )
                throw new ArgumentNullException( "self" );

            Array.Clear(self, 0, self.Length);
        }
    }
}
