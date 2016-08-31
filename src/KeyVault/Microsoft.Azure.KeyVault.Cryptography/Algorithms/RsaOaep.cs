// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Linq;
using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    public class RsaOaep : RsaEncryption
    {
        public const string AlgorithmName = "RSA-OAEP";

        public RsaOaep()
            : base( AlgorithmName )
        {
        }

        public override ICryptoTransform CreateEncryptor( AsymmetricAlgorithm key )
        {
            RSACryptoServiceProvider csp = key as RSACryptoServiceProvider;

            if ( csp == null )
                throw new ArgumentException( "key must be an instance of RSACryptoServiceProvider", "key" );

            return new RsaOaepEncryptor( csp );
        }

        public override ICryptoTransform CreateDecryptor( AsymmetricAlgorithm key )
        {
            RSACryptoServiceProvider csp = key as RSACryptoServiceProvider;

            if ( csp == null )
                throw new ArgumentException( "key must be an instance of RSACryptoServiceProvider", "key" );

            return new RsaOaepDecryptor( csp );
        }

        /// <summary>
        /// RSA 15 Decryptor
        /// </summary>
        /// <remarks>
        /// While this class has a reference to an IDisposable object,
        /// it is not the owner of the object and will not Dispose it.
        /// </remarks>
        class RsaOaepDecryptor : ICryptoTransform
        {
            private readonly RSACryptoServiceProvider _csp;

            internal RsaOaepDecryptor( RSACryptoServiceProvider csp )
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

                return _csp.Decrypt( block, true );
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
        class RsaOaepEncryptor : ICryptoTransform
        {
            private readonly RSACryptoServiceProvider _csp;

            internal RsaOaepEncryptor( RSACryptoServiceProvider csp )
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

                return _csp.Encrypt( block , true );
            }

            public void Dispose()
            {
                // Intentionally empty
            }
        }
    }
}
