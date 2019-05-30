// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.ServerManagement
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    using Models;

    /// <summary>
    /// utlity methods
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// encrypt string using gateway settings
        /// </summary>
        /// <param name="status">gateway status <see cref="GatewayStatus"/> contains settings for encryption</param>
        /// <param name="source">source <see cref="string"/> to encrypt</param>
        /// <returns>base 64 encoded string after encryption</returns>
        public static string EncryptUsingGatewaySettings(GatewayStatus status, string source)
        {
            if (string.IsNullOrEmpty(source)) return source;
            if (status == null) throw new ArgumentNullException(nameof(status), "gateway status not set");

            var result = string.Empty;
            var jwk = status.EncryptionJwk;

#if NET45
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(
                    new RSAParameters
                    {
                        Exponent = Convert.FromBase64String(jwk.E),
                        Modulus =
                                Convert.FromBase64String(
                                    jwk.N.Replace('_', '/')
                                .Replace('-', '+')
                                .PadRight(jwk.N.Length + ((4 - (jwk.N.Length % 4)) % 4), '='))
                    });

                var bytes = rsa.Encrypt(Encoding.UTF8.GetBytes(source), true);
                result = System.Convert.ToBase64String(bytes);
            }
#elif PORTABLE
            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(
                    new RSAParameters
                    {
                        Exponent = Convert.FromBase64String(jwk.E),
                        Modulus =
                                Convert.FromBase64String(
                                    jwk.N.Replace('_', '/')
                                .Replace('-', '+')
                                .PadRight(jwk.N.Length + ((4 - (jwk.N.Length % 4)) % 4), '='))
                    });

                var bytes = rsa.Encrypt(Encoding.UTF8.GetBytes(source), RSAEncryptionPadding.Pkcs1);
                result = System.Convert.ToBase64String(bytes);
            }
#endif

            return result;
        }
    }
}
