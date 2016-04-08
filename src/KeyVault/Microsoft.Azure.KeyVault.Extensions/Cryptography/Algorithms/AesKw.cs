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
using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    public abstract class AesKw : KeyWrapAlgorithm
    {
        const int BlockSizeInBits  = 64;
        const int BlockSizeInBytes = BlockSizeInBits >> 3;

        static readonly byte[] _defaultIv = new byte[] { 0xA6, 0xA6, 0xA6, 0xA6, 0xA6, 0xA6, 0xA6, 0xA6 };

        protected static RNGCryptoServiceProvider Rng = new RNGCryptoServiceProvider();

        protected AesKw( string name ) : base( name )
        {
            
        }

        public ICryptoTransform CreateEncryptor( byte[] key )
        {
            return CreateEncryptor( key, null );
        }

        public override ICryptoTransform CreateEncryptor( byte[] key, byte[] iv )
        {
            if ( key == null )
                throw new ArgumentNullException( "key" );

            if ( key.Length != 128 >> 3 && key.Length != 192 >> 3 && key.Length != 256 >> 3 )
                throw new ArgumentException( "key length must be 128, 192 or 256 bits" );

            if ( iv != null && iv.Length != 8 )
                throw new ArgumentException( "iv length must be 64 bits" );

            return new AesKwEncryptor( key, iv ?? DefaultIv );
        }

        public ICryptoTransform CreateDecryptor( byte[] key )
        {
            return CreateDecryptor( key, null );
        }

        public override ICryptoTransform CreateDecryptor( byte[] key, byte[] iv)
        {
            if ( key == null )
                throw new ArgumentNullException( "key" );

            if ( key.Length != 128 >> 3 && key.Length != 192 >> 3 && key.Length != 256 >> 3 )
                throw new ArgumentException( "key length must be 128, 192 or 256 bits" );

            if ( iv != null && iv.Length != 8 )
                throw new ArgumentException( "iv length must be 64 bits" );

            return new AesKwDecryptor( key, iv ?? DefaultIv );
        }

        private static byte[] DefaultIv
        {
            get { return (byte[])_defaultIv.Clone(); }
        }

        static byte[] GetBytes( UInt64 i )
        {
            byte[] temp = BitConverter.GetBytes( i );

            if ( BitConverter.IsLittleEndian )
            {
                Array.Reverse( temp );
            }

            return temp;
        }

        protected static byte[] Take( int count, byte[] source )
        {
            if ( source.Length == count )
                return source;

            var target = new byte[count];

            Array.Copy( source, target, count );

            return target;
        }

        class AesKwEncryptor : ICryptoTransform
        {
            private Aes    _aes;
            private byte[] _iv;

            internal AesKwEncryptor( byte[] keyBytes, byte[] iv )
            {
                // Create the AES provider
                _aes = Aes.Create();

                _aes.Mode    = CipherMode.ECB;
                _aes.Padding = PaddingMode.None;
                _aes.KeySize = keyBytes.Length * 8;
                _aes.Key     = keyBytes;

                // Set the AES IV to Zeroes
                var aesIv = new byte[_aes.BlockSize >> 3];

                aesIv.Zero();

                _aes.IV = aesIv;

                // Remember the real IV
                _iv = iv.Clone() as byte[];
            }

            public bool CanReuseTransform
            {
                get { throw new NotImplementedException(); }
            }

            public bool CanTransformMultipleBlocks
            {
                get { throw new NotImplementedException(); }
            }

            public int InputBlockSize
            {
                get { throw new NotImplementedException(); }
            }

            public int OutputBlockSize
            {
                get { throw new NotImplementedException(); }
            }

            public int TransformBlock( byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset )
            {
                // No support for block-by-block transformation
                throw new NotImplementedException();
            }

            public byte[] TransformFinalBlock( byte[] inputBuffer, int inputOffset, int inputCount )
            {
                if ( inputBuffer == null )
                    throw new ArgumentNullException( "inputBuffer" );

                if ( inputBuffer.Length == 0 )
                    throw new ArgumentNullException( "inputBuffer", "The length of the inputBuffer parameter cannot be zero" );

                if ( inputCount <= 0 )
                    throw new ArgumentOutOfRangeException( "inputCount", "The inputCount parameter must not be zero or negative" );

                if ( inputCount % 8 != 0 )
                    throw new ArgumentOutOfRangeException( "inputCount", "The inputCount parameter must be a multiple of 64 bits" );

                if ( inputOffset < 0 )
                    throw new ArgumentOutOfRangeException( "inputOffset", "The inputOffset parameter must not be negative" );

                if ( inputOffset + inputCount > inputBuffer.Length )
                    throw new ArgumentOutOfRangeException( "inputCount", "The sum of inputCount and inputOffset parameters must not be larger than the length of inputBuffer" );


                /*
                   1) Initialize variables.

                       Set A = IV, an initial value (see 2.2.3)
                       For i = 1 to n
                           R[i] = P[i]

                   2) Calculate intermediate values.

                       For j = 0 to 5
                           For i=1 to n
                               B = AES(K, A | R[i])
                               A = MSB(64, B) ^ t where t = (n*j)+i
                               R[i] = LSB(64, B)

                   3) Output the results.

                       Set C[0] = A
                       For i = 1 to n
                           C[i] = R[i]
                */

                // The default initialization vector from RFC3394
                byte[]   a  = _iv;

                // The number of input blocks
                var      n  = inputCount >> 3;

                // The set of input blocks
                byte[]  r  = new byte[n << 3];

                Array.Copy( inputBuffer, inputOffset, r, 0, inputCount );

                var    encryptor = _aes.CreateEncryptor();
                byte[] block     = new byte[16];

                // Calculate intermediate values
                for ( var j = 0; j < 6; j++ )
                {
                    for ( var i = 0; i < n; i++ )
                    {
                        // T = ( n * j ) + i
                        var t = (ulong)( ( n * j ) + i + 1 );

                        // B = AES( K, A | R[i] )

                        // First, block = A | R[i]
                        Array.Copy( a, block, a.Length );
                        Array.Copy( r, i << 3, block, 64 >> 3, 64 >> 3 );

                        // Second, AES( K, block )
                        var b = encryptor.TransformFinalBlock( block, 0, 16 );

                        // A = MSB( 64, B )
                        Array.Copy( b, a, 64 >> 3 );
                        
                        // A = A ^ t
                        a.Xor( GetBytes( t ), true );
                        
                        // R[i] = LSB( 64, B )
                        Array.Copy( b, 64 >> 3, r, i << 3, 64 >> 3 );
                    }
                }

                var c = new byte[( n + 1 ) << 3];

                Array.Copy( a, c, a.Length );

                for ( var i = 0; i < n; i++ )
                {
                    Array.Copy( r, i << 3, c, ( i + 1 ) << 3, 8 );
                }

                return c;
            }

            public void Dispose()
            {
                Dispose( true );
                GC.SuppressFinalize( this );
            }

            protected virtual void Dispose( bool disposing )
            {
                if ( disposing )
                {
                    if ( _aes != null )
                    {
                        _aes.Dispose();
                        _aes = null;
                    }
                }
            }
        }

        class AesKwDecryptor : ICryptoTransform
        {
            private Aes    _aes;
            private byte[] _iv;

            internal AesKwDecryptor( byte[] keyBytes, byte[] iv )
            {
                // Create the AES provider
                _aes = Aes.Create();

                _aes.Mode    = CipherMode.ECB;
                _aes.Padding = PaddingMode.None;
                _aes.KeySize = keyBytes.Length * 8;
                _aes.Key     = keyBytes;

                // Set the AES IV to Zeroes
                var aesIv = new byte[_aes.BlockSize >> 3];

                aesIv.Zero();

                _aes.IV = aesIv;

                // Remember the real IV
                _iv = iv.Clone() as byte[];
            }

            public bool CanReuseTransform
            {
                get { throw new NotImplementedException(); }
            }

            public bool CanTransformMultipleBlocks
            {
                get { throw new NotImplementedException(); }
            }

            public int InputBlockSize
            {
                get { throw new NotImplementedException(); }
            }

            public int OutputBlockSize
            {
                get { throw new NotImplementedException(); }
            }

            public int TransformBlock( byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset )
            {
                // No support for block-by-block transformation
                throw new NotImplementedException();
            }

            public byte[] TransformFinalBlock( byte[] inputBuffer, int inputOffset, int inputCount )
            {
                if ( inputBuffer == null )
                    throw new ArgumentNullException( "inputBuffer" );

                if ( inputBuffer.Length == 0 )
                    throw new ArgumentNullException( "inputBuffer", "The length of the inputBuffer parameter cannot be zero" );

                if ( inputCount <= 0 )
                    throw new ArgumentOutOfRangeException( "inputCount", "The inputCount parameter must not be zero or negative" );

                if ( inputCount % 8 != 0 )
                    throw new ArgumentOutOfRangeException( "inputCount", "The inputCount parameter must be a multiple of 64 bits" );

                if ( inputOffset < 0 )
                    throw new ArgumentOutOfRangeException( "inputOffset", "The inputOffset parameter must not be negative" );

                if ( inputOffset + inputCount > inputBuffer.Length )
                    throw new ArgumentOutOfRangeException( "inputCount", "The sum of inputCount and inputOffset parameters must not be larger than the length of inputBuffer" );


                /*
                    1) Initialize variables.

                        Set A = C[0]
                        For i = 1 to n
                            R[i] = C[i]

                    2) Compute intermediate values.

                        For j = 5 to 0
                            For i = n to 1
                                B = AES-1(K, (A ^ t) | R[i]) where t = n*j+i
                                A = MSB(64, B)
                                R[i] = LSB(64, B)

                    3) Output results.

                    If A is an appropriate initial value (see 2.2.3),
                    Then
                        For i = 1 to n
                            P[i] = R[i]
                    Else
                        Return an error
                */

                // A = C[0]
                byte[]   a  = new byte[BlockSizeInBytes];

                Array.Copy( inputBuffer, inputOffset, a, 0, BlockSizeInBytes );

                // The number of input blocks
                var      n  = ( inputCount - BlockSizeInBytes ) >> 3;

                // The set of input blocks
                byte[]   r  = new byte[n << 3];

                Array.Copy( inputBuffer, inputOffset + BlockSizeInBytes, r, 0, inputCount - BlockSizeInBytes );

                var    encryptor = _aes.CreateDecryptor();
                byte[] block     = new byte[16];

                // Calculate intermediate values
                for ( var j = 5; j >= 0; j-- )
                {
                    for ( var i = n; i > 0; i-- )
                    {
                        // T = ( n * j ) + i
                        var t = (ulong)( ( n * j ) + i );

                        // B = AES-1(K, (A ^ t) | R[i] )

                        // First, A = ( A ^ t )
                        a.Xor( GetBytes( t ), true );

                        // Second, block = ( A | R[i] )
                        Array.Copy( a, block, BlockSizeInBytes );
                        Array.Copy( r, ( i - 1 ) << 3, block, BlockSizeInBytes, BlockSizeInBytes );

                        // Third, b = AES-1( block )
                        var b = encryptor.TransformFinalBlock( block, 0, 16 );

                        // A = MSB(64, B)
                        Array.Copy( b, a, BlockSizeInBytes );

                        // R[i] = LSB(64, B)
                        Array.Copy( b, BlockSizeInBytes, r, ( i - 1 ) << 3, BlockSizeInBytes );
                    }
                }

                if ( a.SequenceEqualConstantTime( _iv ) )
                {
                    var c = new byte[n << 3];

                    for ( var i = 0; i < n; i++ )
                    {
                        Array.Copy( r, i << 3, c, i << 3, 8 );
                    }

                    return c;
                }
                else
                {
                    throw new CryptographicException( "Data is not authentic" );
                }
            }

            public void Dispose()
            {
                Dispose( true );
                GC.SuppressFinalize( this );
            }

            protected virtual void Dispose( bool disposing )
            {
                if ( disposing )
                {
                    if ( _aes != null )
                    {
                        _aes.Dispose();
                        _aes = null;
                    }
                }
            }
        }
    }
}
