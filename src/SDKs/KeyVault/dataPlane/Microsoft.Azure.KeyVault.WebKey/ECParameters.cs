// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Microsoft.Azure.KeyVault.WebKey
{
    /// <summary>
    /// EC parameters class.
    /// </summary>
    public class ECParameters
    {
        /// <summary>
        /// Name of this curve.
        /// </summary>
        public string Curve { get; set; }

        /// <summary>
        /// X coordinate for the Elliptic Curve point.
        /// </summary>
        public byte[] X { get; set; }

        /// <summary>
        /// Y coordinate for the Elliptic Curve point.
        /// </summary>
        public byte[] Y { get; set; }

        /// <summary>
        /// ECC private key.
        /// </summary>
        public byte[] D { get; set; }

        internal ECDsaCng ToEcdsa( bool includePrivateParameters )
        {
            switch ( Curve )
            {
                case JsonWebKeyCurveName.P256:
                    return ToNistCurveEcdsa( includePrivateParameters ? BCRYPT_ECDSA_PRIVATE_P256_MAGIC : BCRYPT_ECDSA_PUBLIC_P256_MAGIC, 32, includePrivateParameters );

                case JsonWebKeyCurveName.P384:
                    return ToNistCurveEcdsa( includePrivateParameters ? BCRYPT_ECDSA_PRIVATE_P384_MAGIC : BCRYPT_ECDSA_PUBLIC_P384_MAGIC, 48, includePrivateParameters );

                case JsonWebKeyCurveName.P521:
                    return ToNistCurveEcdsa( includePrivateParameters ? BCRYPT_ECDSA_PRIVATE_P521_MAGIC : BCRYPT_ECDSA_PUBLIC_P521_MAGIC, 66, includePrivateParameters );

                case JsonWebKeyCurveName.P256K:
                    return ToGenericCurveEcdsa( includePrivateParameters ? BCRYPT_ECDSA_PRIVATE_GENERIC_MAGIC : BCRYPT_ECDSA_PUBLIC_GENERIC_MAGIC, Secp256k1, includePrivateParameters );

                default:
                    var curveDesc = Curve == null ? "null" : $"\"{Curve}\"";
                    throw new InvalidOperationException( $"Invalid curve: {curveDesc}" );
            }
        }

        private ECDsaCng ToNistCurveEcdsa( int dwMagic, int sizeInBytes, bool includePrivateParameters )
        {
            const int sizeOfdwMagic = sizeof( uint );
            const int sizeOfdwSize = sizeof( uint );
            var sizeOfX = sizeInBytes;
            var sizeOfY = sizeInBytes;
            var sizeOfD = includePrivateParameters ? sizeInBytes : 0;

            var keyBlob = new byte[sizeOfdwMagic + sizeOfdwSize + sizeOfX + sizeOfY + sizeOfD];

            using ( var writer = new BinaryWriter( new MemoryStream( keyBlob ) ) )
            {
                writer.Write( dwMagic );
                writer.Write( sizeInBytes );
                AlignAndWrite( writer, X, sizeInBytes, nameof( X ) );
                AlignAndWrite( writer, Y, sizeInBytes, nameof( Y ) );
                if ( includePrivateParameters )
                    AlignAndWrite( writer, D, sizeInBytes, nameof( D ) );
            }

            var key = CngKey.Import( keyBlob, includePrivateParameters ? CngKeyBlobFormat.EccPrivateBlob : CngKeyBlobFormat.EccPublicBlob );
            return new ECDsaCng( key );
        }

        private ECDsaCng ToGenericCurveEcdsa( int dwMagic, BCRYPT_ECC_PARAMETER_HEADER curveParameters, bool includePrivateParameters )
        {
            var sizeInBytes = curveParameters.KeySizeInBytes;
            var keyBlob = new byte[curveParameters.KeyBlobSize];

            using ( var writer = new BinaryWriter( new MemoryStream( keyBlob ) ) )
            {
                writer.Write( dwMagic );
                curveParameters.WriteTo( writer );

                AlignAndWrite( writer, X, sizeInBytes, nameof( X ) );
                AlignAndWrite( writer, Y, sizeInBytes, nameof( Y ) );
                if ( includePrivateParameters )
                    AlignAndWrite( writer, D, sizeInBytes, nameof( D ) );
            }

            var key = CngKey.Import( keyBlob, includePrivateParameters ? CngKeyBlobFormat_EccFullPrivateBlob : CngKeyBlobFormat_EccFullPublicBlob );
            return new ECDsaCng( key );
        }

        private static void AlignAndWrite( BinaryWriter writer, byte[] bytes, int size, string paramName )
        {
            if ( bytes == null )
                throw new ArgumentException( $"Value of {paramName} is null." );

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

        internal static ECParameters FromEcdsa( ECDsaCng ecdsa, bool includePrivateParameters )
        {
            if ( ecdsa == null )
                throw new ArgumentNullException( nameof( ecdsa ) );

            var keyBlobFormat = includePrivateParameters ? CngKeyBlobFormat.EccPrivateBlob : CngKeyBlobFormat.EccPublicBlob;
            var keyBlob = ecdsa.Key.Export( keyBlobFormat );

            // If curve is generic, we need to export again to get the full blob.
            var dwMagic = BitConverter.ToInt32( keyBlob, 0 );
            switch ( dwMagic )
            {
                case BCRYPT_ECDSA_PUBLIC_GENERIC_MAGIC:
                    keyBlob = ecdsa.Key.Export( CngKeyBlobFormat_EccFullPublicBlob );
                    break;
                case BCRYPT_ECDSA_PRIVATE_GENERIC_MAGIC:
                    keyBlob = ecdsa.Key.Export( CngKeyBlobFormat_EccFullPrivateBlob );
                    break;
            }

            var result = new ECParameters();
            using ( var reader = new BinaryReader( new MemoryStream( keyBlob ) ) )
            {
                dwMagic = reader.ReadInt32();
                switch ( dwMagic )
                {
                    case BCRYPT_ECDSA_PUBLIC_P256_MAGIC:
                        ThrowIfPrivateParametersNeeded( includePrivateParameters, BCRYPT_ECDSA_PRIVATE_P256_MAGIC, dwMagic );
                        ReadNistBlob( reader, 32, result, false );
                        result.Curve = JsonWebKeyCurveName.P256;
                        break;

                    case BCRYPT_ECDSA_PRIVATE_P256_MAGIC:
                        ReadNistBlob( reader, 32, result, true );
                        result.Curve = JsonWebKeyCurveName.P256;
                        break;

                    case BCRYPT_ECDSA_PUBLIC_P384_MAGIC:
                        ThrowIfPrivateParametersNeeded( includePrivateParameters, BCRYPT_ECDSA_PRIVATE_P384_MAGIC, dwMagic );
                        ReadNistBlob( reader, 48, result, false );
                        result.Curve = JsonWebKeyCurveName.P384;
                        break;

                    case BCRYPT_ECDSA_PRIVATE_P384_MAGIC:
                        ReadNistBlob( reader, 48, result, true );
                        result.Curve = JsonWebKeyCurveName.P384;
                        break;

                    case BCRYPT_ECDSA_PUBLIC_P521_MAGIC:
                        ThrowIfPrivateParametersNeeded( includePrivateParameters, BCRYPT_ECDSA_PRIVATE_P521_MAGIC, dwMagic );
                        ReadNistBlob( reader, 66, result, false );
                        result.Curve = JsonWebKeyCurveName.P521;
                        break;

                    case BCRYPT_ECDSA_PRIVATE_P521_MAGIC:
                        ReadNistBlob( reader, 66, result, true );
                        result.Curve = JsonWebKeyCurveName.P521;
                        break;

                    case BCRYPT_ECDSA_PUBLIC_GENERIC_MAGIC:
                        ThrowIfPrivateParametersNeeded( includePrivateParameters, BCRYPT_ECDSA_PRIVATE_GENERIC_MAGIC, dwMagic );
                        ReadGenericBlob( reader, 32, result, false );
                        break;

                    case BCRYPT_ECDSA_PRIVATE_GENERIC_MAGIC:
                        ReadGenericBlob( reader, 32, result, true );
                        break;

                    default:
                        throw new NotSupportedException( $"Unexpected CNG key blob type. Magic number: 0x{dwMagic:X}." );
                }
            }

            return result;
        }

        private static void ThrowIfPrivateParametersNeeded( bool privateParametersNeeded, int expectedMagic, int actualMagic )
        {
            if ( privateParametersNeeded )
                throw new InvalidOperationException( $"CNG returned key blob without private parameters. Expected magic: 0x{expectedMagic:X}, Actual magic: 0x{actualMagic:X}" );
        }

        private static void ReadNistBlob( BinaryReader reader, int expectedSize, ECParameters dest, bool includePrivateParameters )
        {
            var size = reader.ReadInt32();
            dest.X = ValidateSize( reader.ReadBytes( size ), expectedSize, nameof( dest.X ) );
            dest.Y = ValidateSize( reader.ReadBytes( size ), expectedSize, nameof( dest.Y ) );
            if ( includePrivateParameters )
                dest.D = ValidateSize( reader.ReadBytes( size ), expectedSize, nameof( dest.D ) );
        }

        private static void ReadGenericBlob( BinaryReader reader, int expectedSize, ECParameters dest, bool includePrivateParameters )
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

            // The magic was read before.

            var curve = new BCRYPT_ECC_PARAMETER_HEADER();
            curve.ReadFrom( reader );

            if ( !curve.Equals( Secp256k1 ) )
                throw new NotSupportedException( $"Unsupported curve: {curve}" );

            dest.Curve = JsonWebKeyCurveName.P256K;

            var cbFieldLength = curve.Prime.Length;
            dest.X = ValidateSize( reader.ReadBytes( cbFieldLength ), expectedSize, nameof( dest.X ) );
            dest.Y = ValidateSize( reader.ReadBytes( cbFieldLength ), expectedSize, nameof( dest.Y ) );
            if ( includePrivateParameters )
                dest.D = ValidateSize( reader.ReadBytes( cbFieldLength ), expectedSize, nameof( dest.D ) );
        }

        private static BCRYPT_ECC_PARAMETER_HEADER _secp256k1;

        private static BCRYPT_ECC_PARAMETER_HEADER Secp256k1
        {
            get
            {
                if ( _secp256k1 != null )
                    return _secp256k1;

                return _secp256k1 = new BCRYPT_ECC_PARAMETER_HEADER
                {
                    dwVersion = 0x1,
                    dwCurveType = 0x1,
                    dwCurveGenerationAlgId = 0x0,
                    Prime = new byte[] {0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFF, 0xFF, 0xFC, 0x2F},
                    A = new byte[] {0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0},
                    B = new byte[] {0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x7},
                    Gx = new byte[] {0x79, 0xBE, 0x66, 0x7E, 0xF9, 0xDC, 0xBB, 0xAC, 0x55, 0xA0, 0x62, 0x95, 0xCE, 0x87, 0xB, 0x7, 0x2, 0x9B, 0xFC, 0xDB, 0x2D, 0xCE, 0x28, 0xD9, 0x59, 0xF2, 0x81, 0x5B, 0x16, 0xF8, 0x17, 0x98},
                    Gy = new byte[] {0x48, 0x3A, 0xDA, 0x77, 0x26, 0xA3, 0xC4, 0x65, 0x5D, 0xA4, 0xFB, 0xFC, 0xE, 0x11, 0x8, 0xA8, 0xFD, 0x17, 0xB4, 0x48, 0xA6, 0x85, 0x54, 0x19, 0x9C, 0x47, 0xD0, 0x8F, 0xFB, 0x10, 0xD4, 0xB8},
                    Order = new byte[] {0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xBA, 0xAE, 0xDC, 0xE6, 0xAF, 0x48, 0xA0, 0x3B, 0xBF, 0xD2, 0x5E, 0x8C, 0xD0, 0x36, 0x41, 0x41},
                    Cofactor = new byte[] {0x1},
                    Seed = new byte[] { },
                };
            }
        }

        private static byte[] ValidateSize( byte[] bytes, int expectedSize, string fieldName )
        {
            if ( bytes.Length > expectedSize )
                for ( var i = 0; i < bytes.Length - expectedSize; ++i )
                    if ( bytes[i] != 0 )
                        throw new InvalidOperationException( $"Key parameter {fieldName} is larger than expected." );
            return bytes;
        }

        internal const int BCRYPT_ECDSA_PUBLIC_P256_MAGIC = 0x31534345;
        internal const int BCRYPT_ECDSA_PRIVATE_P256_MAGIC = 0x32534345;
        internal const int BCRYPT_ECDSA_PUBLIC_P384_MAGIC = 0x33534345;
        internal const int BCRYPT_ECDSA_PRIVATE_P384_MAGIC = 0x34534345;
        internal const int BCRYPT_ECDSA_PUBLIC_P521_MAGIC = 0x35534345;
        internal const int BCRYPT_ECDSA_PRIVATE_P521_MAGIC = 0x36534345;
        internal const int BCRYPT_ECDSA_PUBLIC_GENERIC_MAGIC = 0x50444345;
        internal const int BCRYPT_ECDSA_PRIVATE_GENERIC_MAGIC = 0x56444345;

        internal const string BCRYPT_ECCFULLPUBLIC_BLOB = "ECCFULLPUBLICBLOB";
        internal const string BCRYPT_ECCFULLPRIVATE_BLOB = "ECCFULLPRIVATEBLOB";

        private static readonly CngKeyBlobFormat CngKeyBlobFormat_EccFullPublicBlob = new CngKeyBlobFormat( BCRYPT_ECCFULLPUBLIC_BLOB );
        private static readonly CngKeyBlobFormat CngKeyBlobFormat_EccFullPrivateBlob = new CngKeyBlobFormat( BCRYPT_ECCFULLPRIVATE_BLOB );
    }

    internal sealed class BCRYPT_ECC_PARAMETER_HEADER
    {
        internal const int BCRYPT_ECC_PRIME_SHORT_WEIERSTRASS_CURVE = 0x1;
        internal const int BCRYPT_ECC_PRIME_TWISTED_EDWARDS_CURVE = 0x2;
        internal const int BCRYPT_ECC_PRIME_MONTGOMERY_CURVE = 0x3;

        internal const int BCRYPT_NO_CURVE_GENERATION_ALG_ID = 0x0;

        public int dwVersion;
        public int dwCurveType;
        public int dwCurveGenerationAlgId;
        public byte[] Prime;
        public byte[] A;
        public byte[] B;
        public byte[] Gx;
        public byte[] Gy;
        public byte[] Order;
        public byte[] Cofactor;
        public byte[] Seed;

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
            sb.AppendLine( "{" );
            sb.AppendLine( $"    {nameof( dwVersion )} = 0x{dwVersion:X}," );
            sb.AppendLine( $"    {nameof( dwCurveType )} = 0x{dwCurveType:X}," );
            sb.AppendLine( $"    {nameof( dwCurveGenerationAlgId )} = 0x{dwCurveGenerationAlgId:X}," );
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

            var sb = new StringBuilder();
            sb.Append( "new byte[] { " );
            for ( var i = 0; i < bytes.Length; ++i )
            {
                if ( i > 0 )
                    sb.Append( ", " );
                sb.Append( "0x" ).Append( bytes[i].ToString( "X" ) );
            }
            sb.Append( " }" );

            return sb.ToString();
        }

        public override bool Equals( object obj )
        {
            if ( obj == this )
                return true;

            var other = obj as BCRYPT_ECC_PARAMETER_HEADER;
            if ( other == null )
                return false;

            if ( other.dwVersion != dwVersion )
                return false;

            if ( other.dwCurveType != dwCurveType )
                return false;

            if ( other.dwCurveGenerationAlgId != dwCurveGenerationAlgId )
                return false;

            if ( !BytesEquals( other.Prime, Prime ) )
                return false;

            if ( !BytesEquals( other.A, A ) )
                return false;

            if ( !BytesEquals( other.B, B ) )
                return false;

            if ( !BytesEquals( other.Gx, Gx ) )
                return false;

            if ( !BytesEquals( other.Gy, Gy ) )
                return false;

            if ( !BytesEquals( other.Order, Order ) )
                return false;

            if ( !BytesEquals( other.Cofactor, Cofactor ) )
                return false;
            if ( !BytesEquals( other.Seed, Seed ) )
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return BCRYPT_ECC_PRIME_SHORT_WEIERSTRASS_CURVE.GetHashCode()
                * BCRYPT_ECC_PRIME_TWISTED_EDWARDS_CURVE.GetHashCode()
                * BCRYPT_ECC_PRIME_MONTGOMERY_CURVE.GetHashCode();
        }


        private static bool BytesEquals( byte[] a, byte[] b )
        {
            if ( a == b )
                return true;

            if ( ( a == null ) != ( b == null ) )
                return false;

            if ( a.Length != b.Length )
                return false;

            for ( var i = 0; i < a.Length; ++i )
                if ( a[i] != b[i] )
                    return false;

            return true;
        }

        public void ReadFrom( BinaryReader reader )
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

            dwVersion = reader.ReadInt32();
            dwCurveType = reader.ReadInt32();
            dwCurveGenerationAlgId = reader.ReadInt32();
            var cbFieldLength = reader.ReadInt32();
            var cbSubgroupOrder = reader.ReadInt32();
            var cbCofactor = reader.ReadInt32();
            var cbSeed = reader.ReadInt32();

            Prime = reader.ReadBytes( cbFieldLength );
            A = reader.ReadBytes( cbFieldLength );
            B = reader.ReadBytes( cbFieldLength );
            Gx = reader.ReadBytes( cbFieldLength );
            Gy = reader.ReadBytes( cbFieldLength );
            Order = reader.ReadBytes( cbSubgroupOrder );
            Cofactor = reader.ReadBytes( cbCofactor );
            Seed = reader.ReadBytes( cbSeed );
        }

        public void WriteTo( BinaryWriter writer )
        {
            var cbFieldLength = Prime.Length;
            var cbSubgroupOrder = Order.Length;
            var cbCofactor = Cofactor.Length;
            var cbSeed = Seed.Length;

            writer.Write( dwVersion );
            writer.Write( dwCurveType );
            writer.Write( dwCurveGenerationAlgId );
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

        private static void AlignAndWrite( BinaryWriter writer, byte[] bytes, int size, string paramName )
        {
            if ( bytes == null )
                throw new ArgumentException( $"Value of {paramName} is null." );

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
}