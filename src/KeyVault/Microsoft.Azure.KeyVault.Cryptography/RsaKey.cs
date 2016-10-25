// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.Core;
using Microsoft.Azure.KeyVault.Cryptography;
using Microsoft.Azure.KeyVault.Cryptography.Algorithms;

#if NETSTANDARD
using TaskException = System.Threading.Tasks.Task;
#endif

namespace Microsoft.Azure.KeyVault
{
    /// <summary>
    /// An RSA key.
    /// </summary>
    public class RsaKey : IKey, IDisposable
    {
        public const int KeySize1024 = 1024;
        public const int KeySize2048 = 2048;

        private static readonly int DefaultKeySize = KeySize2048;

        private RSA _csp;

        /// <summary>
        /// Key Identifier
        /// </summary>
        public string Kid { get; private set; }

        /// <summary>
        /// Constructor, creates a 2048 bit key with a GUID identifier.
        /// </summary>
        public RsaKey() : this( Guid.NewGuid().ToString( "D" ), DefaultKeySize )
        {
        }

        /// <summary>
        /// Constructor, creates a 2048 bit RSA key.
        /// </summary>
        /// <param name="kid">The key identifier to use</param>
        public RsaKey( string kid ) : this( kid, DefaultKeySize )
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="kid">The key identifier to use</param>
        /// <param name="keySize">The size of the key</param>
        public RsaKey( string kid, int keySize )
        {
            if ( string.IsNullOrWhiteSpace( kid ) )
                throw new ArgumentNullException( "kid" );

            Kid = kid;

            _csp = RSA.Create();

            _csp.KeySize = keySize;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="kid">The key identifier to use</param>
        /// <param name="keyParameters">The RSA parameters for the key</param>
        public RsaKey( string kid, RSAParameters keyParameters )
        {
            if ( string.IsNullOrWhiteSpace( kid ) )
                throw new ArgumentNullException( "kid" );

            Kid = kid;

            _csp = RSA.Create();
            _csp.ImportParameters( keyParameters );
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="kid">The key identifier to use</param>
        /// <param name="csp">The RSA object for the key</param>
        /// <remarks>The RSA object is IDisposable, this class will hold a
        /// reference to the RSA object but will not dispose it, the caller
        /// of this constructor is responsible for the lifetime of this
        /// parameter.</remarks>
        public RsaKey( string kid, RSA csp )
        {
            if ( string.IsNullOrWhiteSpace( kid ) )
                throw new ArgumentNullException( "kid" );

            if ( csp == null )
                throw new ArgumentNullException( "csp" );

            Kid = kid;

            // NOTE: RSA is disposable and that may lead to runtime errors later.
            _csp = csp;
        }

        // Intentionally excluded.
        //~RsaKey()
        //{
        //    Dispose( false );
        //}

        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        protected virtual void Dispose( bool disposing )
        {
            // Clean up managed resources if Dispose was called
            if ( disposing )
            {
                if ( _csp != null )
                {
                    _csp.Dispose();
                    _csp = null;
                }
            }

            // Clean up native resources always
        }

#region IKey implementation

        public string DefaultEncryptionAlgorithm
        {
            get { return RsaOaep.AlgorithmName; }
        }

        public string DefaultKeyWrapAlgorithm
        {
            get { return RsaOaep.AlgorithmName; }
        }

        public string DefaultSignatureAlgorithm
        {
            get { return Rs256.AlgorithmName; }
        }
        
        public Task<byte[]> DecryptAsync( byte[] ciphertext, byte[] iv, byte[] authenticationData = null, byte[] authenticationTag = null, string algorithm = RsaOaep.AlgorithmName, CancellationToken token = default(CancellationToken) )
        {
            if ( _csp == null )
                throw new ObjectDisposedException( string.Format( "RsaKey {0} is disposed", Kid ) );

            if ( string.IsNullOrWhiteSpace( algorithm ) )
                algorithm = DefaultEncryptionAlgorithm;

            if ( ciphertext == null || ciphertext.Length == 0 )
                throw new ArgumentNullException( "ciphertext" );

            if ( iv != null )
                throw new ArgumentException( "Initialization vector must be null", "iv" );

            if ( authenticationData != null )
                throw new ArgumentException( "Authentication data must be null", "authenticationData" );

            // TODO: Not available via the RSA class
            //if ( _csp.PublicOnly )
            //    throw new NotSupportedException( "Decrypt is not supported because no private key is available" );

            AsymmetricEncryptionAlgorithm algo = AlgorithmResolver.Default[algorithm] as AsymmetricEncryptionAlgorithm;

            if ( algo == null )
                throw new NotSupportedException( "algorithm is not supported" );

            using ( var encryptor = algo.CreateDecryptor( _csp ) )
            {
                try
                {
                    var result = encryptor.TransformFinalBlock( ciphertext, 0, ciphertext.Length );

                    return Task.FromResult( result );
                }
                catch ( Exception ex )
                {
                    return TaskException.FromException<byte[]>( ex );
                }
            }
        }

        public Task<Tuple<byte[], byte[], string>> EncryptAsync( byte[] plaintext, byte[] iv = null, byte[] authenticationData = null, string algorithm = RsaOaep.AlgorithmName, CancellationToken token = default(CancellationToken) )
        {
            if ( _csp == null )
                throw new ObjectDisposedException( string.Format( "RsaKey {0} is disposed", Kid ) );

            if ( string.IsNullOrWhiteSpace( algorithm ) )
                algorithm = DefaultEncryptionAlgorithm;

            if ( plaintext == null || plaintext.Length == 0 )
                throw new ArgumentNullException( "plaintext" );

            if ( iv != null )
                throw new ArgumentException( "Initialization vector must be null", "iv" );

            if ( authenticationData != null )
                throw new ArgumentException( "Authentication data must be null", "authenticationData" );

            AsymmetricEncryptionAlgorithm algo = AlgorithmResolver.Default[algorithm] as AsymmetricEncryptionAlgorithm;

            if ( algo == null )
                throw new NotSupportedException( "algorithm is not supported" );

            using ( var encryptor = algo.CreateEncryptor( _csp ) )
            {
                try
                {
                    var result = new Tuple<byte[], byte[], string>( encryptor.TransformFinalBlock( plaintext, 0, plaintext.Length ), null, algorithm );

                    return Task.FromResult( result );
                }
                catch ( Exception ex )
                {
                    return TaskException.FromException<Tuple<byte[], byte[], string>>( ex );
                }
            }
        }

        public Task<Tuple<byte[], string>> WrapKeyAsync( byte[] key, string algorithm = RsaOaep.AlgorithmName, CancellationToken token = default(CancellationToken) )
        {
            if ( _csp == null )
                throw new ObjectDisposedException( string.Format( "RsaKey {0} is disposed", Kid ) );

            if ( string.IsNullOrWhiteSpace( algorithm ) )
                algorithm = DefaultKeyWrapAlgorithm;

            if ( key == null || key.Length == 0 )
                throw new ArgumentNullException( "key" );

            AsymmetricEncryptionAlgorithm algo = AlgorithmResolver.Default[algorithm] as AsymmetricEncryptionAlgorithm;

            if ( algo == null )
                throw new NotSupportedException( "algorithm is not supported" );

            using ( var encryptor = algo.CreateEncryptor( _csp ) )
            {
                try
                {
                    var result = new Tuple<byte[], string>( encryptor.TransformFinalBlock( key, 0, key.Length ), algorithm );

                    return Task.FromResult( result );
                }
                catch ( Exception ex )
                {
                    return TaskException.FromException<Tuple<byte[], string>>( ex );
                }
            }
        }

        public Task<byte[]> UnwrapKeyAsync( byte[] encryptedKey, string algorithm = RsaOaep.AlgorithmName, CancellationToken token = default(CancellationToken) )
        {
            if ( _csp == null )
                throw new ObjectDisposedException( string.Format( "RsaKey {0} is disposed", Kid ) );

            if ( string.IsNullOrWhiteSpace( algorithm ) )
                algorithm = DefaultKeyWrapAlgorithm;

            if ( encryptedKey == null || encryptedKey.Length == 0 )
                throw new ArgumentNullException( "encryptedKey" );

            // TODO: Not available via the RSA class
            //if ( _csp.PublicOnly )
            //    throw new NotSupportedException( "UnwrapKey is not supported because no private key is available" );

            AsymmetricEncryptionAlgorithm algo = AlgorithmResolver.Default[algorithm] as AsymmetricEncryptionAlgorithm;

            if ( algo == null )
                throw new NotSupportedException( "algorithm is not supported" );

            using ( var encryptor = algo.CreateDecryptor( _csp ) )
            {
                try
                {
                    var result =  encryptor.TransformFinalBlock( encryptedKey, 0, encryptedKey.Length );

                    return Task.FromResult( result );
                }
                catch ( Exception ex )
                {
                    return TaskException.FromException<byte[]>( ex );
                }
            }
        }

        public Task<Tuple<byte[], string>> SignAsync( byte[] digest, string algorithm, CancellationToken token = default(CancellationToken) )
        {
            if ( _csp == null )
                throw new ObjectDisposedException( string.Format( "RsaKey {0} is disposed", Kid ) );

            if ( algorithm == null )
                algorithm = DefaultSignatureAlgorithm;

            if ( digest == null )
                throw new ArgumentNullException( "digest" );

            // TODO: Not available via the RSA class
            //if ( _csp.PublicOnly )
            //    throw new NotSupportedException( "Sign is not supported because no private key is available" );

            AsymmetricSignatureAlgorithm algo      = AlgorithmResolver.Default[algorithm] as AsymmetricSignatureAlgorithm;
            ISignatureTransform          transform = algo != null ? algo.CreateSignatureTransform( _csp ) : null;

            if ( algo == null || transform == null )
                throw new NotSupportedException( "algorithm is not supported" );

            try
            {
                var result = new Tuple<byte[], string>( transform.Sign( digest ), algorithm );

                return Task.FromResult( result );
            }
            catch ( Exception ex )
            {
                return TaskException.FromException<Tuple<byte[], string>>( ex );
            }
        }

        public Task<bool> VerifyAsync( byte[] digest, byte[] signature, string algorithm, CancellationToken token = default(CancellationToken) )
        {
            if ( _csp == null )
                throw new ObjectDisposedException( string.Format( "RsaKey {0} is disposed", Kid ) );

            if ( digest == null )
                throw new ArgumentNullException( "digest" );

            if ( signature == null )
                throw new ArgumentNullException( "signature" );

            if ( algorithm == null )
                algorithm = DefaultSignatureAlgorithm;

            AsymmetricSignatureAlgorithm algo = AlgorithmResolver.Default[algorithm] as AsymmetricSignatureAlgorithm;
            ISignatureTransform          transform = algo != null ? algo.CreateSignatureTransform( _csp ) : null;

            if ( algo == null || transform == null )
                throw new NotSupportedException( "algorithm is not supported" );

            try
            {
                var result = transform.Verify( digest, signature );

                return Task.FromResult( result );
            }
            catch ( Exception ex )
            {
                return TaskException.FromException<bool>( ex );
            }
        }

#endregion
    }
}
