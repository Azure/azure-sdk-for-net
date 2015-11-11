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
using System.Globalization;
using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    public abstract class AesCbcHmacSha2 : SymmetricEncryptionAlgorithm
    {
        protected AesCbcHmacSha2( string name )
            : base( name )
        {
        }

        public override ICryptoTransform CreateDecryptor( byte[] key, byte[] iv, byte[] authenticationData )
        {
            if ( key == null )
                throw new CryptographicException( "No key material" );

            if ( iv == null )
                throw new CryptographicException( "No initialization vector" );

            if ( authenticationData == null )
                throw new CryptographicException( "No associated data" );

            // Create the Decryptor
            return new AesCbcHmacSha2Decryptor( Name, key, iv, authenticationData );
        }

        public override ICryptoTransform CreateEncryptor( byte[] key, byte[] iv, byte[] authenticationData )
        {
            if ( key == null )
                throw new CryptographicException( "No key material" );

            if ( iv == null )
                throw new CryptographicException( "No initialization vector" );

            if ( authenticationData == null )
                throw new CryptographicException( "No associated data" );

            // Create the Encryptor
            return new AesCbcHmacSha2Encryptor( Name, key, iv, authenticationData );
        }

        private static void GetAlgorithmParameters( string algorithm, byte[] key, out byte[] aes_key, out byte[] hmac_key, out HMAC hmac )
        {
            switch ( algorithm )
            {
                case Aes128CbcHmacSha256.AlgorithmName:
                    {
                        if ( ( key.Length << 3 ) < 256 )
                            throw new CryptographicException( string.Format( CultureInfo.CurrentCulture, "{0} key length in bits {1} < 256", algorithm, key.Length << 3 ) );

                        hmac_key = new byte[128 >> 3];
                        aes_key  = new byte[128 >> 3];
                        Array.Copy( key, hmac_key, 128 >> 3 );
                        Array.Copy( key, 128 >> 3, aes_key, 0, 128 >> 3 );

                        hmac = new HMACSHA256( hmac_key );

                        break;
                    }

                case Aes192CbcHmacSha384.AlgorithmName:
                    {
                        if ( ( key.Length << 3 ) < 384 )
                            throw new CryptographicException( string.Format( CultureInfo.CurrentCulture, "{0} key length in bits {1} < 384", algorithm, key.Length << 3 ) );

                        hmac_key = new byte[192 >> 3];
                        aes_key  = new byte[192 >> 3];
                        Array.Copy( key, hmac_key, 192 >> 3 );
                        Array.Copy( key, 192 >> 3, aes_key, 0, 192 >> 3 );

                        hmac = new HMACSHA384( hmac_key );

                        break;
                    }

                case Aes256CbcHmacSha512.AlgorithmName:
                    {
                        if ( ( key.Length << 3 ) < 512 )
                            throw new CryptographicException( string.Format( CultureInfo.CurrentCulture, "{0} key length in bits {1} < 512", algorithm, key.Length << 3 ) );

                        hmac_key = new byte[256 >> 3];
                        aes_key  = new byte[256 >> 3];
                        Array.Copy( key, hmac_key, 256 >> 3 );
                        Array.Copy( key, 256 >> 3, aes_key, 0, 256 >> 3 );

                        hmac = new HMACSHA512( hmac_key );

                        break;
                    }

                default:
                    {
                        throw new CryptographicException( string.Format( CultureInfo.CurrentCulture, "Unsupported algorithm: {0}", algorithm ) );
                    }
            }
        }

        class AesCbcHmacSha2Encryptor : IAuthenticatedCryptoTransform
        {
            readonly byte[]  _hmac_key;

            readonly byte[]  _associated_data_length;

            Aes              _aes;
            HMAC             _hmac;

            ICryptoTransform _inner;
            byte[]           _tag;

            internal AesCbcHmacSha2Encryptor( string name, byte[] key, byte[] iv, byte[] associatedData )
            {
                // Split the key to get the AES key, the HMAC key and the HMAC object
                byte[] aesKey;

                GetAlgorithmParameters( name, key, out aesKey, out _hmac_key, out _hmac );

                // Create the AES provider
                _aes = Aes.Create();

                _aes.Mode    = CipherMode.CBC;
                _aes.Padding = PaddingMode.PKCS7;
                _aes.KeySize = aesKey.Length * 8;
                _aes.Key     = aesKey;
                _aes.IV      = iv;

                _inner = _aes.CreateEncryptor();

                _associated_data_length = ConvertToBigEndian( associatedData.Length * 8 );

                // Prime the hash.
                _hmac.TransformBlock( associatedData, 0, associatedData.Length, associatedData, 0 );
                _hmac.TransformBlock( iv, 0, iv.Length, iv, 0 );
            }

            public byte[] Tag
            {
                get { return _tag; }
            }

            public bool CanReuseTransform
            {
	            get { return _inner.CanReuseTransform; }
            }

            public bool CanTransformMultipleBlocks
            {
	            get { return _inner.CanTransformMultipleBlocks; }
            }

            public int InputBlockSize
            {
	            get { return _inner.InputBlockSize; }
            }

            public int OutputBlockSize
            {
	            get { return _inner.OutputBlockSize; }
            }

            public int TransformBlock( byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset )
            {
                // Encrypt the block
                var result = _inner.TransformBlock( inputBuffer, inputOffset, inputCount, outputBuffer, outputOffset );

                // Add it to the running hash
                _hmac.TransformBlock( outputBuffer, outputOffset, result, outputBuffer, outputOffset );

                return result;
            }

            public byte[] TransformFinalBlock( byte[] inputBuffer, int inputOffset, int inputCount )
            {
                // Encrypt the block
                var result = _inner.TransformFinalBlock( inputBuffer, inputOffset, inputCount );

                // Add it to the running hash
                _hmac.TransformBlock( result, 0, result.Length, result, 0 );

                // Add the associated_data_length bytes to the hash
                _hmac.TransformFinalBlock( _associated_data_length, 0, _associated_data_length.Length );

                // Compute the tag
                _tag = new byte[_hmac_key.Length];
                Array.Copy( _hmac.Hash, _tag, _hmac_key.Length );

                return result;
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
                    if ( _inner != null )
                    {
                        _inner.Dispose();
                        _inner = null;
                    }

                    if ( _hmac != null )
                    {
                        _hmac.Dispose();
                        _hmac = null;
                    }

                    if ( _aes != null )
                    {
                        _aes.Dispose();
                        _aes = null;
                    }
                }
            }
        }

        class AesCbcHmacSha2Decryptor : IAuthenticatedCryptoTransform
        {
            readonly byte[]  _hmac_key;

            readonly byte[]  _associated_data_length;

            Aes              _aes;
            HMAC             _hmac;

            ICryptoTransform _inner;
            byte[]           _tag;

            internal AesCbcHmacSha2Decryptor( string name, byte[] key, byte[] iv, byte[] associatedData )
            {
                // Split the key to get the AES key, the HMAC key and the HMAC object
                byte[] aesKey;

                GetAlgorithmParameters( name, key, out aesKey, out _hmac_key, out _hmac );

                // Create the AES provider
                _aes = Aes.Create();

                _aes.Mode    = CipherMode.CBC;
                _aes.Padding = PaddingMode.PKCS7;
                _aes.KeySize = aesKey.Length * 8;
                _aes.Key     = aesKey;
                _aes.IV      = iv;

                _inner = _aes.CreateDecryptor();

                _associated_data_length = ConvertToBigEndian( associatedData.Length * 8 );

                // Prime the hash.
                _hmac.TransformBlock( associatedData, 0, associatedData.Length, associatedData, 0 );
                _hmac.TransformBlock( iv, 0, iv.Length, iv, 0 );
            }

            public byte[] Tag
            {
                get { return _tag; }
            }

            public bool CanReuseTransform
            {
	            get { return _inner.CanReuseTransform; }
            }

            public bool CanTransformMultipleBlocks
            {
	            get { return _inner.CanTransformMultipleBlocks; }
            }

            public int InputBlockSize
            {
	            get { return _inner.InputBlockSize; }
            }

            public int OutputBlockSize
            {
	            get { return _inner.OutputBlockSize; }
            }

            public int TransformBlock( byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset )
            {
                // Add the cipher text to the running hash
                _hmac.TransformBlock( inputBuffer, inputOffset, inputCount, inputBuffer, inputOffset );

                // Decrypt the cipher text
                return _inner.TransformBlock( inputBuffer, inputOffset, inputCount, outputBuffer, outputOffset );
            }

            public byte[] TransformFinalBlock( byte[] inputBuffer, int inputOffset, int inputCount )
            {
                // Add the cipher text to the running hash
                _hmac.TransformBlock( inputBuffer, inputOffset, inputCount, inputBuffer, inputOffset );

                // Add the associated_data_length bytes to the hash
                _hmac.TransformFinalBlock( _associated_data_length, 0, _associated_data_length.Length );

                // Compute the tag
                _tag = new byte[_hmac_key.Length];
                Array.Copy( _hmac.Hash, _tag, _hmac_key.Length );

                return _inner.TransformFinalBlock( inputBuffer, inputOffset, inputCount );
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
                    if ( _inner != null )
                    {
                        _inner.Dispose();
                        _inner = null;
                    }

                    if ( _hmac != null )
                    {
                        _hmac.Dispose();
                        _hmac = null;
                    }

                    if ( _aes != null )
                    {
                        _aes.Dispose();
                        _aes = null;
                    }
                }
            }
        }

        static byte[] ConvertToBigEndian( Int64 i )
        {
            byte[] temp = BitConverter.GetBytes( i );

            if ( BitConverter.IsLittleEndian )
            {
                Array.Reverse( temp );
            }

            return temp;
        }
    }
}
