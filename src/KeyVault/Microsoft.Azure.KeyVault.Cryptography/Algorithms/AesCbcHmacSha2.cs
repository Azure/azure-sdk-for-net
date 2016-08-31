// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Globalization;
using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    public abstract class AesCbcHmacSha2 : SymmetricEncryptionAlgorithm
    {
        internal static Aes Create( byte[] key, byte[] iv )
        {
            var aes = Aes.Create();

            aes.Mode    = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = key.Length * 8;
            aes.Key     = key;
            aes.IV      = iv;

            return aes;
        }
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

        private static void GetAlgorithmParameters( string algorithm, byte[] key, out byte[] aes_key, out byte[] hmac_key, out IncrementalHash hmac )
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

                        hmac = IncrementalHash.CreateHMAC( HashAlgorithmName.SHA256, hmac_key );

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

                        hmac = IncrementalHash.CreateHMAC( HashAlgorithmName.SHA384, hmac_key );

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

                        hmac = IncrementalHash.CreateHMAC( HashAlgorithmName.SHA512, hmac_key );

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
            IncrementalHash  _hmac;

            ICryptoTransform _inner;
            byte[]           _tag;

            internal AesCbcHmacSha2Encryptor( string name, byte[] key, byte[] iv, byte[] associatedData )
            {
                // Split the key to get the AES key, the HMAC key and the HMAC object
                byte[] aesKey;

                GetAlgorithmParameters( name, key, out aesKey, out _hmac_key, out _hmac );

                // Create the AES provider
                _aes = AesCbcHmacSha2.Create( aesKey, iv );

                _inner = _aes.CreateEncryptor();

                _associated_data_length = ConvertToBigEndian( associatedData.Length * 8 );

                // Prime the hash.
                _hmac.AppendData( associatedData );
                _hmac.AppendData( iv );
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

                // TODO: This is an inefficient copy
                var data = outputBuffer.Take( outputOffset, result );

                // Add it to the running hash
                _hmac.AppendData( data );

                return result;
            }

            public byte[] TransformFinalBlock( byte[] inputBuffer, int inputOffset, int inputCount )
            {
                // Encrypt the block
                var result = _inner.TransformFinalBlock( inputBuffer, inputOffset, inputCount );

                // Add it to the running hash
                _hmac.AppendData( result );

                // Add the associated_data_length bytes to the hash
                _hmac.AppendData( _associated_data_length );

                // Compute the tag
                _tag = _hmac.GetHashAndReset().Take( _hmac_key.Length );

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
            IncrementalHash  _hmac;

            ICryptoTransform _inner;
            byte[]           _tag;

            internal AesCbcHmacSha2Decryptor( string name, byte[] key, byte[] iv, byte[] associatedData )
            {
                // Split the key to get the AES key, the HMAC key and the HMAC object
                byte[] aesKey;

                GetAlgorithmParameters( name, key, out aesKey, out _hmac_key, out _hmac );

                // Create the AES provider
                _aes = AesCbcHmacSha2.Create( aesKey, iv );

                _inner = _aes.CreateDecryptor();

                _associated_data_length = ConvertToBigEndian( associatedData.Length * 8 );

                // Prime the hash.
                _hmac.AppendData( associatedData );
                _hmac.AppendData( iv );
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
                // TODO: This is an inefficient copy
                var block = inputBuffer.Take( inputOffset, inputCount );

                // Add the cipher text to the running hash
                _hmac.AppendData( block );

                // Decrypt the cipher text
                return _inner.TransformBlock( inputBuffer, inputOffset, inputCount, outputBuffer, outputOffset );
            }

            public byte[] TransformFinalBlock( byte[] inputBuffer, int inputOffset, int inputCount )
            {
                // TODO: This is an inefficient copy
                var block = inputBuffer.Take( inputOffset, inputCount );

                // Add the cipher text to the running hash
                _hmac.AppendData( block );

                // Add the associated_data_length bytes to the hash
                _hmac.AppendData( _associated_data_length );

                // Compute the tag
                _tag = _hmac.GetHashAndReset();

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
