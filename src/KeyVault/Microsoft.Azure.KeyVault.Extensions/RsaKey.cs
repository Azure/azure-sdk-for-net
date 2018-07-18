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
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.Core;
using Microsoft.Azure.KeyVault.Cryptography;
using Microsoft.Azure.KeyVault.Cryptography.Algorithms;

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

        private RSACryptoServiceProvider _csp;

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

            _csp = new RSACryptoServiceProvider( keySize );
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

            _csp = new RSACryptoServiceProvider();
            _csp.ImportParameters( keyParameters );
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="kid">The key identifier to use</param>
        /// <param name="csp">The RSA CSP object for the key</param>
        /// <remarks>A new CSP is created using the parameters from the parameter CSP</remarks>
        public RsaKey( string kid, RSACryptoServiceProvider csp )
        {
            if ( string.IsNullOrWhiteSpace( kid ) )
                throw new ArgumentNullException( "kid" );

            if ( csp == null )
                throw new ArgumentNullException( "csp" );

            Kid = kid;

            _csp = new RSACryptoServiceProvider();
            _csp.ImportParameters( csp.PublicOnly ? csp.ExportParameters( false ) : csp.ExportParameters( true ) );
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

        /// <summary>
        /// Indicates whether the RSA key has only public key material.
        /// </summary>
        public bool PublicOnly
        {
            get
            {
                if ( _csp == null )
                    throw new ObjectDisposedException( string.Format( CultureInfo.InvariantCulture, "RsaKey {0} is disposed", Kid ) );

                return _csp.PublicOnly; }
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
        
// Warning 1998: This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
#pragma warning disable 1998

        public async Task<byte[]> DecryptAsync( byte[] ciphertext, byte[] iv, byte[] authenticationData = null, byte[] authenticationTag = null, string algorithm = RsaOaep.AlgorithmName, CancellationToken token = default(CancellationToken) )
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

            if ( _csp.PublicOnly )
                throw new NotSupportedException( "Decrypt is not supported because no private key is available" );

            AsymmetricEncryptionAlgorithm algo = AlgorithmResolver.Default[algorithm] as AsymmetricEncryptionAlgorithm;

            if ( algo == null )
                throw new NotSupportedException( "algorithm is not supported" );

            using ( var encryptor = algo.CreateDecryptor( _csp ) )
            {
                return encryptor.TransformFinalBlock( ciphertext, 0, ciphertext.Length );
            }
        }

        public async Task<Tuple<byte[], byte[], string>> EncryptAsync( byte[] plaintext, byte[] iv = null, byte[] authenticationData = null, string algorithm = RsaOaep.AlgorithmName, CancellationToken token = default(CancellationToken) )
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
                return new Tuple<byte[], byte[], string>( encryptor.TransformFinalBlock( plaintext, 0, plaintext.Length ), null, algorithm );
            }
        }

        public async Task<Tuple<byte[], string>> WrapKeyAsync( byte[] key, string algorithm = RsaOaep.AlgorithmName, CancellationToken token = default(CancellationToken) )
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
                return new Tuple<byte[], string>( encryptor.TransformFinalBlock( key, 0, key.Length ), algorithm );
            }
        }

        public async Task<byte[]> UnwrapKeyAsync( byte[] encryptedKey, string algorithm = RsaOaep.AlgorithmName, CancellationToken token = default(CancellationToken) )
        {
            if ( _csp == null )
                throw new ObjectDisposedException( string.Format( "RsaKey {0} is disposed", Kid ) );

            if ( string.IsNullOrWhiteSpace( algorithm ) )
                algorithm = DefaultKeyWrapAlgorithm;

            if ( encryptedKey == null || encryptedKey.Length == 0 )
                throw new ArgumentNullException( "encryptedKey" );

            if ( _csp.PublicOnly )
                throw new NotSupportedException( "UnwrapKey is not supported because no private key is available" );

            AsymmetricEncryptionAlgorithm algo = AlgorithmResolver.Default[algorithm] as AsymmetricEncryptionAlgorithm;

            if ( algo == null )
                throw new NotSupportedException( "algorithm is not supported" );

            using ( var encryptor = algo.CreateDecryptor( _csp ) )
            {
                return encryptor.TransformFinalBlock( encryptedKey, 0, encryptedKey.Length );
            }
        }

        public async Task<Tuple<byte[], string>> SignAsync( byte[] digest, string algorithm, CancellationToken token = default(CancellationToken) )
        {
            if ( _csp == null )
                throw new ObjectDisposedException( string.Format( "RsaKey {0} is disposed", Kid ) );

            if ( algorithm == null )
                algorithm = DefaultSignatureAlgorithm;

            if ( digest == null )
                throw new ArgumentNullException( "digest" );

            if ( _csp.PublicOnly )
                throw new NotSupportedException( "Sign is not supported because no private key is available" );

            AsymmetricSignatureAlgorithm algo = AlgorithmResolver.Default[algorithm] as AsymmetricSignatureAlgorithm;

            if ( algo == null )
                throw new NotSupportedException( "algorithm is not supported" );

            return new Tuple<byte[], string>( algo.SignHash( _csp, digest ), algorithm );
        }

        public async Task<bool> VerifyAsync( byte[] digest, byte[] signature, string algorithm, CancellationToken token = default(CancellationToken) )
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

            if ( algo == null )
                throw new NotSupportedException( "algorithm is not supported" );

            return algo.VerifyHash( _csp, digest, signature );
        }

#pragma warning restore 1998

        #endregion
    }
}
