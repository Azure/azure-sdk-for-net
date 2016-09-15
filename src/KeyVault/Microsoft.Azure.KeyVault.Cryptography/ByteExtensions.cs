// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

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

        internal static byte[] Take( this byte[] self, int count )
        {
            return ByteExtensions.Take( self, 0, count );
        }

        internal static byte[] Take( this byte[] self, int offset, int count )
        {
            if ( self == null )
                throw new ArgumentNullException( "self" );

            if ( offset < 0 )
                throw new ArgumentException( "offset cannot be < 0", "offset" );

            if ( count <= 0 )
                throw new ArgumentException( "count cannot be <= 0", "count" );

            if ( offset + count > self.Length )
                throw new ArgumentException( "offset + count cannot be > self.Length", "count" );

            var result = new byte[count];

            Array.Copy( self, offset, result, 0, count );

            return result;
        }

        internal static void Zero( this byte[] self )
        {
            if ( self == null )
                throw new ArgumentNullException( "self" );

            Array.Clear( self, 0, self.Length );
        }
    }
}
