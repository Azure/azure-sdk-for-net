using System;
using System.Linq;
using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.WebKey
{

    /// <summary>
    /// Numbers that indicate the type of blob.
    /// </summary>
    enum KeyBlobMagicNumber : int
    {
        BCRYPT_ECDSA_PUBLIC_P256_MAGIC = 0x31534345,
        BCRYPT_ECDSA_PRIVATE_P256_MAGIC = 0x32534345,
        BCRYPT_ECDSA_PUBLIC_P384_MAGIC = 0x33534345,
        BCRYPT_ECDSA_PRIVATE_P384_MAGIC = 0x34534345,
        BCRYPT_ECDSA_PUBLIC_P521_MAGIC = 0x35534345,
        BCRYPT_ECDSA_PRIVATE_P521_MAGIC = 0x36534345
    }

    /// <summary>
    /// Because the current version of ECC is not supporting some of the operations needed for WebKey,
    /// those operations are added as ECC extension.
    /// </summary>
    public static class EccExtension
    {
        // Blob structure based on https://msdn.microsoft.com/en-us/library/windows/desktop/aa375520(v=vs.85).aspx
        // and bcrypt https://github.com/dotnet/corefx/blob/master/src/Common/src/Interop/Windows/BCrypt/Interop.Blobs.cs

        /// <summary>
        /// Exports EC parameters by exporting the key blob material and deserializing the blob to
        /// its constructive EC parameters.
        /// </summary>
        /// <param name="ecdsaProvider"> The ECDsa CNG provider </param>
        /// <param name="includePrivateParameters"> Determines whether the private key part is to be exported. </param>
        /// <returns></returns>
        public static ECParameters ExportParameters(this ECDsaCng ecdsaProvider, bool includePrivateParameters)
        {

            if (ecdsaProvider == null)
                throw new ArgumentNullException(nameof(ecdsaProvider));

            var cngKeyBlobFormat = includePrivateParameters ? CngKeyBlobFormat.EccPrivateBlob : CngKeyBlobFormat.EccPublicBlob;
            var ecBlob = ecdsaProvider.Key.Export(cngKeyBlobFormat);

            // BLOB structure
            //-------------------------------------------------------
            // MAGIC   | Key size (L) | X       | Y       | [D]     |
            // 4 bytes | 4 bytes      | L bytes | L bytes | L bytes |
            //-------------------------------------------------------
            var offset = 0;
            var bMagic = new byte[4];
            var bLength = new byte[4];
            Array.Copy(ecBlob, offset, bMagic, 0, bMagic.Length);
            Array.Copy(ecBlob, offset += 4, bLength, 0, bLength.Length);

            var length = BitConverter.ToInt32(bLength, 0);
            var magic = BitConverter.ToInt32(bMagic, 0);
            VerifyMagic(magic, length, includePrivateParameters);

            var ecParameters = new ECParameters();
            ecParameters.Curve = length == 32 ? JsonWebKeyECCurve.P256 : length == 48 ? JsonWebKeyECCurve.P384 : JsonWebKeyECCurve.P521;

            ecParameters.X = new byte[length];
            ecParameters.Y = new byte[length];
            Array.Copy(ecBlob, offset += 4, ecParameters.X, 0, length);
            Array.Copy(ecBlob, offset += length, ecParameters.Y, 0, length);

            if (includePrivateParameters)
            {
                ecParameters.D = new byte[length];
                Array.Copy(ecBlob, offset += length, ecParameters.D, 0, length);
            }
            return ecParameters;
        }

        private static void VerifyMagic(int magic, int length, bool isPrivate)
        {
            if (!validLength.Contains(length))
                throw new CryptographicException(string.Format("Invalid key length {0}. Valid lengths are {1}", length, string.Join(",", validLength)));

            var isValid = false;
            switch (magic)
            {
                case (int)KeyBlobMagicNumber.BCRYPT_ECDSA_PRIVATE_P256_MAGIC:
                    isValid = isPrivate && length == 32;
                    break;
                case (int)KeyBlobMagicNumber.BCRYPT_ECDSA_PUBLIC_P256_MAGIC:
                    isValid = !isPrivate && length == 32;
                    break;
                case (int)KeyBlobMagicNumber.BCRYPT_ECDSA_PRIVATE_P384_MAGIC:
                    isValid = isPrivate && length == 48;
                    break;
                case (int)KeyBlobMagicNumber.BCRYPT_ECDSA_PUBLIC_P384_MAGIC:
                    isValid = !isPrivate && length == 48;
                    break;
                case (int)KeyBlobMagicNumber.BCRYPT_ECDSA_PRIVATE_P521_MAGIC:
                    isValid = isPrivate && length == 66;
                    break;
                case (int)KeyBlobMagicNumber.BCRYPT_ECDSA_PUBLIC_P521_MAGIC:
                    isValid = !isPrivate && length == 66;
                    break;
            }
            if (!isValid)
                throw new CryptographicException(string.Format("Invalid magic {0}.", magic));
        }
        
        private static int[] validLength = new[] { 32, 48, 66 };
    }
}
