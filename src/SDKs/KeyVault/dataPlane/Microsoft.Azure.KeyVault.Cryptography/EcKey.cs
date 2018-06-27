// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
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
    /// An elliptic curve key.
    /// </summary>
    public class EcKey : IKey
    {
        public const string P256 = "P-256";
        public const string P384 = "P-384";
        public const string P521 = "P-521";
        public const string P256K = "P-256K";

        private static readonly string DefaultCurve = P256;

        private ECDsa _ecdsa;

        /// <summary>
        /// Key Identifier
        /// </summary>
        public string Kid { get; }

        /// <summary>
        /// Constructor, creates a P-256 key with a GUID identifier.
        /// </summary>
        public EcKey() : this( Guid.NewGuid().ToString( "D" ), DefaultCurve )
        {
        }

        /// <summary>
        /// Constructor, creates a P-256 key.
        /// </summary>
        /// <param name="kid">The key identifier to use</param>
        public EcKey( string kid ) : this( kid, DefaultCurve )
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="kid">The key identifier to use</param>
        /// <param name="curve">The name of elliptic curve to use</param>
        public EcKey( string kid, string curve )
        {
            if ( string.IsNullOrWhiteSpace( kid ) )
                throw new ArgumentNullException( nameof( kid ) );

            Kid = kid;

            var kcp = new CngKeyCreationParameters();
            kcp.ExportPolicy = CngExportPolicies.AllowPlaintextExport;
            kcp.KeyUsage = CngKeyUsages.Signing;

            CngAlgorithm cngAlgo;
            switch ( curve )
            {
                case P256:
                    cngAlgo = CngAlgorithm.ECDsaP256;
                    DefaultSignatureAlgorithm = Es256.AlgorithmName;
                    break;

                case P384:
                    cngAlgo = CngAlgorithm.ECDsaP384;
                    DefaultSignatureAlgorithm = Es384.AlgorithmName;
                    break;

                case P521:
                    cngAlgo = CngAlgorithm.ECDsaP521;
                    DefaultSignatureAlgorithm = Es512.AlgorithmName;
                    break;

                case P256K:
                    cngAlgo = CngAlgorithm_Generic_ECDSA;
                    kcp.Parameters.Add( new CngProperty( NativeMethods.BCRYPT_ECC_PARAMETERS, Secp256k1Parameters.CurveBlob, CngPropertyOptions.None ) );
                    DefaultSignatureAlgorithm = ES256K.AlgorithmName;
                    break;

                default:
                    throw new ArgumentException( $"Unsupported curve: \"{curve}\"." );
            }

            var key = CngKey.Create( cngAlgo, null, kcp );
            _ecdsa = new ECDsaCng( key );
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="kid">The key identifier to use</param>
        /// <param name="curve">The name of elliptic curve to use; supported values are constants described in this class.</param>
        /// <param name="x">The value of public point field X.</param>
        /// <param name="y">The value of public point field Y.</param>
        /// <param name="d">The value of private key D. If null, only the public key operations will be allowed.</param>
        public EcKey( string kid, string curve, byte[] x, byte[] y, byte[] d = null )
        {
            if ( string.IsNullOrWhiteSpace( kid ) )
                throw new ArgumentNullException( nameof( kid ) );

            if ( string.IsNullOrWhiteSpace( curve ) )
                throw new ArgumentNullException( nameof( curve ) );

            if ( x == null )
                throw new ArgumentNullException( nameof( x ) );

            if ( y == null )
                throw new ArgumentNullException( nameof( y ) );

            Kid = kid;

            CngKey key;

            switch ( curve )
            {
                case P256:
                    key = ImportNistKey( NativeMethods.BCRYPT_ECDSA_PRIVATE_P256_MAGIC, NativeMethods.BCRYPT_ECDSA_PUBLIC_P256_MAGIC, 32, x, y, d );
                    DefaultSignatureAlgorithm = Es256.AlgorithmName;
                    break;

                case P384:
                    key = ImportNistKey( NativeMethods.BCRYPT_ECDSA_PRIVATE_P384_MAGIC, NativeMethods.BCRYPT_ECDSA_PUBLIC_P384_MAGIC, 48, x, y, d );
                    DefaultSignatureAlgorithm = Es384.AlgorithmName;
                    break;

                case P521:
                    key = ImportNistKey( NativeMethods.BCRYPT_ECDSA_PRIVATE_P521_MAGIC, NativeMethods.BCRYPT_ECDSA_PUBLIC_P521_MAGIC, 66, x, y, d );
                    DefaultSignatureAlgorithm = Es512.AlgorithmName;
                    break;

                case P256K:
                    key = ImportGenericKey( Secp256k1Parameters, x, y, d );
                    DefaultSignatureAlgorithm = ES256K.AlgorithmName;
                    break;

                default:
                    throw new ArgumentException( $"Invalid curve name: \"{curve}\"", nameof( curve ) );
            }

            _ecdsa = new ECDsaCng( key );
        }

        private CngKey ImportNistKey( int privateMagic, int publicMagic, int size, byte[] x, byte[] y, byte[] d )
        {
            if ( d == null || IsZero( d ) )
                return ImportNistPublicKey( publicMagic, size, x, y );

            return ImportNistPrivateKey( privateMagic, size, x, y, d );
        }

        private CngKey ImportNistPublicKey( int magic, int sizeInBytes, byte[] x, byte[] y )
        {
            // Format described by BCRYPT_ECCKEY_BLOB (BCRYPT_ECCPUBLIC_BLOB).
            // https://msdn.microsoft.com/en-us/library/windows/desktop/aa375520(v=vs.85).aspx

            var keyBlob = new byte[4 + 4 + sizeInBytes + sizeInBytes];
            using ( var writer = new BinaryWriter( new MemoryStream( keyBlob ) ) )
            {
                writer.Write( magic );
                writer.Write( sizeInBytes );
                AlignAndWrite( writer, x, sizeInBytes, nameof( x ) );
                AlignAndWrite( writer, y, sizeInBytes, nameof( y ) );
            }

            return CngKey.Import( keyBlob, CngKeyBlobFormat.EccPublicBlob );
        }

        private CngKey ImportNistPrivateKey( int magic, int sizeInBytes, byte[] x, byte[] y, byte[] d )
        {
            // Format described by BCRYPT_ECCKEY_BLOB (BCRYPT_ECCPRIVATE_BLOB).
            // https://msdn.microsoft.com/en-us/library/windows/desktop/aa375520(v=vs.85).aspx

            var keyBlob = new byte[4 + 4 + sizeInBytes + sizeInBytes + sizeInBytes];
            using ( var writer = new BinaryWriter( new MemoryStream( keyBlob ) ) )
            {
                writer.Write( magic );
                writer.Write( sizeInBytes );
                AlignAndWrite( writer, x, sizeInBytes, nameof( x ) );
                AlignAndWrite( writer, y, sizeInBytes, nameof( y ) );
                AlignAndWrite( writer, d, sizeInBytes, nameof( d ) );
            }

            return CngKey.Import( keyBlob, CngKeyBlobFormat.EccPrivateBlob );
        }

        private CngKey ImportGenericKey( EcKeyCurveParameters curveParameters, byte[] x, byte[] y, byte[] d )
        {
            if ( d == null || IsZero( d ) )
                return ImportGenericPublicKey( curveParameters, x, y );

            return ImportGenericPrivateKey( curveParameters, x, y, d );
        }

        private CngKey ImportGenericPublicKey( EcKeyCurveParameters curveParameters, byte[] x, byte[] y )
        {
            /*  struct BCRYPT_ECCFULLKEY_BLOB
                {
                    ULONG dwMagic;              // BCRYPT_ECDSA_PUBLIC_GENERIC_MAGIC or BCRYPT_ECDSA_PRIVATE_GENERIC_MAGIC
                    BCRYPT_ECC_PARAMETER_HEADER curveParameters;
                    BYTE Qx[cbFieldLength]      // X-coordinate of the public point.
                    BYTE Qy[cbFieldLength]      // Y-coordinate of the public point.
                    BYTE d[cbSubgroupOrder]     // Private key. Zero if only public key is required.
                }
            */

            var keyBlob = new byte[curveParameters.KeyBlobSize];
            using ( var writer = new BinaryWriter( new MemoryStream( keyBlob ) ) )
            {
                writer.Write( NativeMethods.BCRYPT_ECDSA_PUBLIC_GENERIC_MAGIC );
                curveParameters.WriteTo( writer );

                var size = curveParameters.KeySizeInBytes;
                AlignAndWrite( writer, x, size, nameof( x ) );
                AlignAndWrite( writer, y, size, nameof( y ) );
            }

            return CngKey.Import( keyBlob, CngKeyBlobFormat_Generic_Public );
        }

        private CngKey ImportGenericPrivateKey( EcKeyCurveParameters curveParameters, byte[] x, byte[] y, byte[] d )
        {
            /*  struct BCRYPT_ECCFULLKEY_BLOB
                {
                    ULONG dwMagic;              // BCRYPT_ECDSA_PUBLIC_GENERIC_MAGIC or BCRYPT_ECDSA_PRIVATE_GENERIC_MAGIC
                    BCRYPT_ECC_PARAMETER_HEADER curveParameters;
                    BYTE Qx[cbFieldLength]      // X-coordinate of the public point.
                    BYTE Qy[cbFieldLength]      // Y-coordinate of the public point.
                    BYTE d[cbSubgroupOrder]     // Private key. Zero if only public key is required.
                }
            */

            var keyBlob = new byte[curveParameters.KeyBlobSize];
            using ( var writer = new BinaryWriter( new MemoryStream( keyBlob ) ) )
            {
                writer.Write( NativeMethods.BCRYPT_ECDSA_PRIVATE_GENERIC_MAGIC );
                curveParameters.WriteTo( writer );

                var size = curveParameters.KeySizeInBytes;
                AlignAndWrite( writer, x, size, nameof( x ) );
                AlignAndWrite( writer, y, size, nameof( y ) );
                AlignAndWrite( writer, d, size, nameof( d ) );
            }

            return CngKey.Import( keyBlob, CngKeyBlobFormat_Generic_Private );
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="kid">The key identifier to use</param>
        /// <param name="ecdsa">The ECDsa object for the key</param>
        /// <remarks>The ECDsa object is IDisposable, this class will hold a
        /// reference to the ECDsa object but will not dispose it, the caller
        /// of this constructor is responsible for the lifetime of this
        /// parameter.</remarks>
        public EcKey( string kid, ECDsa ecdsa )
        {
            if ( string.IsNullOrWhiteSpace( kid ) )
                throw new ArgumentNullException( nameof( kid ) );

            if ( ecdsa == null )
                throw new ArgumentNullException( nameof( ecdsa ) );

            Kid = kid;

            // NOTE: ECDsa is disposable and that may lead to runtime errors later.
            _ecdsa = ecdsa;
        }

        // Intentionally excluded.
        //~EcKey()
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
                if ( _ecdsa != null )
                {
                    _ecdsa.Dispose();
                    _ecdsa = null;
                }
            }
        }

        #region IKey implementation

        public string DefaultEncryptionAlgorithm => null;

        public string DefaultKeyWrapAlgorithm => null;

        public string DefaultSignatureAlgorithm { get; set; }

        public Task<byte[]> DecryptAsync( byte[] ciphertext, byte[] iv, byte[] authenticationData = null, byte[] authenticationTag = null, string algorithm = RsaOaep.AlgorithmName, CancellationToken token = default( CancellationToken ) )
        {
            throw MethodNotSupported( nameof( DecryptAsync ) );
        }

        public Task<Tuple<byte[], byte[], string>> EncryptAsync( byte[] plaintext, byte[] iv = null, byte[] authenticationData = null, string algorithm = RsaOaep.AlgorithmName, CancellationToken token = default( CancellationToken ) )
        {
            throw MethodNotSupported( nameof( EncryptAsync ) );
        }

        public Task<Tuple<byte[], string>> WrapKeyAsync( byte[] key, string algorithm = RsaOaep.AlgorithmName, CancellationToken token = default( CancellationToken ) )
        {
            throw MethodNotSupported( nameof( WrapKeyAsync ) );
        }

        public Task<byte[]> UnwrapKeyAsync( byte[] encryptedKey, string algorithm = RsaOaep.AlgorithmName, CancellationToken token = default( CancellationToken ) )
        {
            throw MethodNotSupported( nameof( UnwrapKeyAsync ) );
        }

        private Exception MethodNotSupported( string methodName )
        {
            throw new NotSupportedException( $"Method {methodName} cannot is not supported by EcKey {Kid}." );
        }

        public Task<Tuple<byte[], string>> SignAsync( byte[] digest, string algorithm, CancellationToken token = default( CancellationToken ) )
        {
            if ( _ecdsa == null )
                throw new ObjectDisposedException( $"EcKey {Kid} is disposed" );

            if ( algorithm == null )
                algorithm = DefaultSignatureAlgorithm;

            if ( digest == null )
                throw new ArgumentNullException( nameof( digest ) );

            var algo = AlgorithmResolver.Default[algorithm] as AsymmetricSignatureAlgorithm;
            var transform = algo?.CreateSignatureTransform( _ecdsa );

            if ( algo == null || transform == null )
                throw new NotSupportedException( $"algorithm {algorithm} is not supported by EcKey {Kid}" );

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

        public Task<bool> VerifyAsync( byte[] digest, byte[] signature, string algorithm, CancellationToken token = default( CancellationToken ) )
        {
            if ( _ecdsa == null )
                throw new ObjectDisposedException( $"EcKey {Kid} is disposed" );

            if ( digest == null )
                throw new ArgumentNullException( nameof( digest ) );

            if ( signature == null )
                throw new ArgumentNullException( nameof( signature ) );

            if ( algorithm == null )
                algorithm = DefaultSignatureAlgorithm;

            var algo = AlgorithmResolver.Default[algorithm] as AsymmetricSignatureAlgorithm;
            var transform = algo?.CreateSignatureTransform( _ecdsa );

            if ( algo == null || transform == null )
                throw new NotSupportedException( $"algorithm {algorithm} is not supported by EcKey {Kid}" );

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

        #region Utilities

        private static bool IsZero( byte[] v )
        {
            if ( v == null )
                return true;

            for ( var i = 0; i < v.Length; ++i )
                if ( v[i] != 0 )
                    return false;

            return true;
        }

        private static void AlignAndWrite( BinaryWriter writer, byte[] bytes, int size, string paramName )
        {
            if ( bytes.Length >= size )
            {
                for ( var i = 0; i < bytes.Length - size; ++i )
                    if ( bytes[i] != 0 )
                        throw new ArgumentException( $"Value of {paramName} is bigger than allowed for this key." );

                writer.Write( bytes, bytes.Length - size, size );
                return;
            }

            for ( var i = bytes.Length; i < size; ++i )
                writer.Write( (byte) 0 );
            writer.Write( bytes );
        }

        private static readonly CngKeyBlobFormat CngKeyBlobFormat_Generic_Public = new CngKeyBlobFormat( NativeMethods.BCRYPT_ECCFULLPUBLIC_BLOB );
        private static readonly CngKeyBlobFormat CngKeyBlobFormat_Generic_Private = new CngKeyBlobFormat( NativeMethods.BCRYPT_ECCFULLPRIVATE_BLOB );

        private static readonly CngAlgorithm CngAlgorithm_Generic_ECDSA = new CngAlgorithm( "ECDSA" );

        private static EcKeyCurveParameters _secp256k1Parameters;

        private static EcKeyCurveParameters Secp256k1Parameters
        {
            get
            {
                if ( _secp256k1Parameters != null )
                    return _secp256k1Parameters;

                return _secp256k1Parameters = new EcKeyCurveParameters
                {
                    // Copied from http://www.secg.org/sec2-v2.pdf and verified to match https://en.bitcoin.it/wiki/Secp256k1.
                    CurveType = EcKeyCurveType.PrimeShortWeierstrass,
                    Hash = null,
                    Prime = Convert.FromBase64String( "/////////////////////////////////////v///C8=" ),
                    A = Convert.FromBase64String( "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=" ),
                    B = Convert.FromBase64String( "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAc=" ),
                    Gx = Convert.FromBase64String( "eb5mfvncu6xVoGKVzocLBwKb/NstzijZWfKBWxb4F5g=" ),
                    Gy = Convert.FromBase64String( "SDradyajxGVdpPv8DhEIqP0XtEimhVQZnEfQj/sQ1Lg=" ),
                    Order = Convert.FromBase64String( "/////////////////////rqu3OavSKA7v9JejNA2QUE=" ),
                    Cofactor = Convert.FromBase64String( "AQ==" ),
                    Seed = Convert.FromBase64String( "" ),
                };
            }
        }

        #endregion
    }

    internal sealed class EcKeyCurveParameters
    {
        public EcKeyCurveType CurveType { get; set; }
        public string Hash { get; set; }
        public byte[] Prime { get; set; }
        public byte[] A { get; set; }
        public byte[] B { get; set; }
        public byte[] Gx { get; set; }
        public byte[] Gy { get; set; }
        public byte[] Order { get; set; }
        public byte[] Cofactor { get; set; }
        public byte[] Seed { get; set; }

        public int KeySizeInBytes => Prime.Length;

        public int CurveBlobSize
        {
            get
            {
                var cbFieldLength = Prime.Length;
                var cbSubgroupOrder = Order.Length;
                var cbCofactor = Cofactor.Length;
                var cbSeed = Seed.Length;

                var size = 7 * sizeof( uint ) + 5 * cbFieldLength + cbSubgroupOrder + cbCofactor + cbSeed;

                return size;
            }
        }

        public byte[] CurveBlob
        {
            get
            {
                var result = new byte[CurveBlobSize];
                using ( var writer = new BinaryWriter( new MemoryStream( result ) ) )
                    WriteTo( writer );
                return result;
            }
        }

        public int KeyBlobSize
        {
            get
            {
                var cbFieldLength = Prime.Length;
                var size = sizeof( uint ) + CurveBlobSize + 3 * cbFieldLength;
                return size;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine( $"new {nameof( EcKeyCurveParameters )}" );
            sb.AppendLine( "{" );
            sb.AppendLine( $"    {nameof( CurveType )} = {nameof( EcKeyCurveType )}.{CurveType}," );
            var hashDesc = Hash == null ? "null" : $"\"{Hash}\"";
            sb.AppendLine( $"    {nameof( Hash )} = {hashDesc}," );
            sb.AppendLine( $"    {nameof( Prime )} = {GetBytesDesc( Prime )}," );
            sb.AppendLine( $"    {nameof( A )} = {GetBytesDesc( A )}," );
            sb.AppendLine( $"    {nameof( B )} = {GetBytesDesc( B )}," );
            sb.AppendLine( $"    {nameof( Gx )} = {GetBytesDesc( Gx )}," );
            sb.AppendLine( $"    {nameof( Gy )} = {GetBytesDesc( Gy )}," );
            sb.AppendLine( $"    {nameof( Order )} = {GetBytesDesc( Order )}," );
            sb.AppendLine( $"    {nameof( Cofactor )} = {GetBytesDesc( Cofactor )}," );
            sb.AppendLine( $"    {nameof( Seed )} = {GetBytesDesc( Seed )}," );
            sb.AppendLine( "}" );
            return sb.ToString();
        }

        private static string GetBytesDesc( byte[] bytes )
        {
            if ( bytes == null )
                return "null";
            var base64 = Convert.ToBase64String( bytes );
            return $"Convert.FromBase64String(\"{base64}\")";
        }

        public void WriteTo( BinaryWriter writer )
        {
            /*
                struct BCRYPT_ECC_PARAMETER_HEADER
                {
                    ULONG                   dwVersion;              //Version of the structure
                    ECC_CURVE_TYPE_ENUM     dwCurveType;            //Supported curve types.
                    ECC_CURVE_ALG_ID_ENUM   dwCurveGenerationAlgId; //For X.592 verification purposes, if we include Seed we will need to include the algorithm ID.
                    ULONG                   cbFieldLength;          //Byte length of the fields P, A, B, X, Y.
                    ULONG                   cbSubgroupOrder;        //Byte length of the subgroup.
                    ULONG                   cbCofactor;             //Byte length of cofactor of G in E.
                    ULONG                   cbSeed;                 //Byte length of the seed used to generate the curve.
                    //P[cbFieldLength]              Prime specifying the base field.
                    //A[cbFieldLength]              Coefficient A of the equation y^2 = x^3 + A*x + B mod p
                    //B[cbFieldLength]              Coefficient B of the equation y^2 = x^3 + A*x + B mod p
                    //Gx[cbFieldLength]             X-coordinate of the base point.
                    //Gy[cbFieldLength]             Y-coordinate of the base point.
                    //n[cbSubgroupOrder]            Order of the group generated by G = (x,y)
                    //h[cbCofactor]                 Cofactor of G in E.
                    //S[cbSeed]                     Seed of the curve.
                }
             */

            var cbFieldLength = Prime.Length;
            var cbSubgroupOrder = Order.Length;
            var cbCofactor = Cofactor.Length;
            var cbSeed = Seed.Length;

            writer.Write( 1 ); // version
            writer.Write( ToCurveType( CurveType ) );
            writer.Write( ToCurveGenerationAlgId( Hash ) );
            writer.Write( cbFieldLength );
            writer.Write( cbSubgroupOrder );
            writer.Write( cbCofactor );
            writer.Write( cbSeed );

            AlignAndWrite( writer, Prime, cbFieldLength, nameof( Prime ) );
            AlignAndWrite( writer, A, cbFieldLength, nameof( A ) );
            AlignAndWrite( writer, B, cbFieldLength, nameof( B ) );
            AlignAndWrite( writer, Gx, cbFieldLength, nameof( Gx ) );
            AlignAndWrite( writer, Gy, cbFieldLength, nameof( Gy ) );
            AlignAndWrite( writer, Order, cbSubgroupOrder, nameof( Order ) );
            AlignAndWrite( writer, Cofactor, cbCofactor, nameof( Cofactor ) );
            AlignAndWrite( writer, Seed, cbSeed, nameof( Seed ) );
        }

        private static int ToCurveType( EcKeyCurveType type )
        {
            switch ( type )
            {
                case EcKeyCurveType.PrimeMontgomery:
                    return NativeMethods.BCRYPT_ECC_PRIME_MONTGOMERY_CURVE;

                case EcKeyCurveType.PrimeShortWeierstrass:
                    return NativeMethods.BCRYPT_ECC_PRIME_SHORT_WEIERSTRASS_CURVE;

                case EcKeyCurveType.PrimeTwistedEdwards:
                    return NativeMethods.BCRYPT_ECC_PRIME_TWISTED_EDWARDS_CURVE;

                default:
                    throw new InvalidOperationException( $"Unsupported curve type: {type}" );
            }
        }

        private static int ToCurveGenerationAlgId( string hash )
        {
            if ( !string.IsNullOrWhiteSpace( hash ) )
                throw new InvalidOperationException( $"Unsupported curve generation hash algorithm: {hash}" );
            return NativeMethods.BCRYPT_NO_CURVE_GENERATION_ALG_ID;
        }

        private static void AlignAndWrite( BinaryWriter writer, byte[] bytes, int size, string paramName )
        {
            if ( bytes.Length >= size )
            {
                for ( var i = 0; i < bytes.Length - size; ++i )
                    if ( bytes[i] != 0 )
                        throw new ArgumentException( $"Value of {paramName} is bigger than allowed for this curve." );

                writer.Write( bytes, bytes.Length - size, size );
                return;
            }

            for ( var i = bytes.Length; i < size; ++i )
                writer.Write( (byte) 0 );

            writer.Write( bytes );
        }
    }

    internal enum EcKeyCurveType
    {
        Characteristic2,
        Implicit,
        Named,
        PrimeMontgomery,
        PrimeShortWeierstrass,
        PrimeTwistedEdwards
    }
}