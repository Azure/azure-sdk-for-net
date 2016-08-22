
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
            RSACryptoServiceProvider csp = key as RSACryptoServiceProvider;

            if ( csp == null )
                throw new ArgumentException( "key must be an instance of RSACryptoServiceProvider", "key" );

            return new Rsa15Encryptor( csp );
        }

        public override ICryptoTransform CreateDecryptor( AsymmetricAlgorithm key )
        {
            RSACryptoServiceProvider csp = key as RSACryptoServiceProvider;

            if ( csp == null )
                throw new ArgumentException( "key must be an instance of RSACryptoServiceProvider", "key" );

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
            private readonly RSACryptoServiceProvider _csp;

            internal Rsa15Decryptor( RSACryptoServiceProvider csp )
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

                return _csp.Decrypt( block, false );
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
            private readonly RSACryptoServiceProvider _csp;

            internal Rsa15Encryptor( RSACryptoServiceProvider csp )
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

                return _csp.Encrypt( block , false );
            }

            public void Dispose()
            {
                // Intentionally empty
            }
        }
    }
}
