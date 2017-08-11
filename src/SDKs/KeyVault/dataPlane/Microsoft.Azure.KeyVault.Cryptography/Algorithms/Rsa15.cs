// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Linq;
using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    public class Rsa15 : RsaEncryption
    {
        public const string AlgorithmName = "RSA_15";

        public Rsa15()
            : base( AlgorithmName )
        {
        }

        public override ICryptoTransform CreateEncryptor( AsymmetricAlgorithm key )
        {
            RSA csp = key as RSA;

            if ( csp == null )
                throw new ArgumentException( "key must be an instance of RSA", "key" );

            return new Rsa15Encryptor( csp );
        }

        public override ICryptoTransform CreateDecryptor( AsymmetricAlgorithm key )
        {
            RSA csp = key as RSA;

            if ( csp == null )
                throw new ArgumentException( "key must be an instance of RSA", "key" );

            return new Rsa15Decryptor( csp );
        }

        /// <summary>
        /// RSA 15 Decryptor
        /// </summary>
        /// <remarks>
        /// While this class has a reference to an IDisposable object,
        /// it is not the owner of the object and will not Dispose it.
        /// </remarks>
        class Rsa15Decryptor : ICryptoTransform
        {
            private readonly RSA _csp;

            internal Rsa15Decryptor( RSA csp )
            {
                _csp = csp;
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
                throw new NotImplementedException();
            }

            public byte[] TransformFinalBlock( byte[] inputBuffer, int inputOffset, int inputCount )
            {
                byte[] block = inputBuffer.Skip( inputOffset ).Take( inputCount ).ToArray();

#if FullNetFx
                if ( _csp is RSACryptoServiceProvider )
                {
                    return ( ( RSACryptoServiceProvider )_csp ).Decrypt( block, false );
                }

                throw new CryptographicException( string.Format( "{0} is not supported", _csp.GetType().FullName ) );
#elif NETSTANDARD
                return _csp.Decrypt( block, RSAEncryptionPadding.Pkcs1 );
#else
                #error Unknown Framework
#endif
            }

            public void Dispose()
            {
                // Intentionally empty
            }
        }

        /// <summary>
        /// RSA 15 Encryptor
        /// </summary>
        /// <remarks>
        /// While this class has a reference to an IDisposable object,
        /// it is not the owner of the object and will not Dispose it.
        /// </remarks>
        class Rsa15Encryptor : ICryptoTransform
        {
            private readonly RSA _csp;

            internal Rsa15Encryptor( RSA csp )
            {
                _csp = csp;
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
                throw new NotImplementedException();
            }

            public byte[] TransformFinalBlock( byte[] inputBuffer, int inputOffset, int inputCount )
            {
                byte[] block = inputBuffer.Skip( inputOffset ).Take( inputCount ).ToArray();

#if FullNetFx
                if ( _csp is RSACryptoServiceProvider )
                {
                    return ( ( RSACryptoServiceProvider )_csp ).Encrypt( block, false );
                }

                throw new CryptographicException( string.Format( "{0} is not supported", _csp.GetType().FullName ) );
#elif NETSTANDARD
                return _csp.Encrypt( block, RSAEncryptionPadding.Pkcs1 );
#else
                #error Unknown Framework
#endif
            }

            public void Dispose()
            {
                // Intentionally empty
            }
        }
    }
}
