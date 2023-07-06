// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using KeyResolvers;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

var thumbprint = args.Length > 0 ? args[0] : throw new Exception("Certificate thumbprint required");
var key = args.Length > 1 ? args[1] : RandomKey();

using var resolver = new CertificateStoreKeyResolver(StoreName.My, StoreLocation.CurrentUser);
var kek = resolver.Resolve(thumbprint) ?? throw new Exception($"No certificate with thumbprint {thumbprint} found");

var encryptedKey = kek.WrapKey("RSA-OAEP", Convert.FromBase64String(key));
Console.WriteLine($"Encrypted key (base64): {Convert.ToBase64String(encryptedKey)}");

var decryptedKey = kek.UnwrapKey("RSA-OAEP", encryptedKey);
Console.WriteLine($"Decrypted key matches: {decryptedKey.SequenceEqual(Convert.FromBase64String(key))}");

static string RandomKey()
{
    byte[] key = new byte[32];

    using var rng = RandomNumberGenerator.Create();
    rng.GetBytes(key);

    return Convert.ToBase64String(key);
}