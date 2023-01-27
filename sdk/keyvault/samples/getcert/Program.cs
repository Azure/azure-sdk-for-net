// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.IO;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Certificates;
using Azure.Security.KeyVault.Secrets;

internal static class Program
{
    private static async Task<int> RunAsync(
        Uri vaultUri,
        string certificateName,
        string message,
        IConsole console)
    {
        CancellationToken cancellationToken = s_cancellationTokenSource.Token;

        // Allow only credentials appropriate for this interactive tool sample.
        DefaultAzureCredential credential = new DefaultAzureCredential(
            new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = true,
                ExcludeManagedIdentityCredential = true,
            });

        // Get the certificate to use for encrypting and decrypting.
        CertificateClient certificateClient = new CertificateClient(vaultUri, credential);
        KeyVaultCertificateWithPolicy certificate = await certificateClient.GetCertificateAsync(certificateName, cancellationToken: cancellationToken);

        // Make sure the private key is exportable.
        if (certificate.Policy?.Exportable != true)
        {
            console.Error.WriteLine($@"Error: certificate ""{certificateName}"" is not exportable.");
            return 1;
        }
        else if (certificate.Policy?.KeyType != CertificateKeyType.Rsa)
        {
            console.Error.WriteLine($@"Error: certificate type ""{certificate.Policy?.KeyType}"" cannot be used to locally encrypt and decrypt.");
            return 1;
        }

        // Get the managed secret which contains the public and private key (if exportable).
        string secretName = ParseSecretName(certificate.SecretId);

        SecretClient secretClient = new SecretClient(vaultUri, credential);
        KeyVaultSecret secret = await secretClient.GetSecretAsync(secretName, cancellationToken: cancellationToken);

        // Get a certificate pair from the secret value.
        X509Certificate2 pfx = ParseCertificate(secret);

        // Decode and encrypt the message.
        byte[] plaintext = Encoding.UTF8.GetBytes(message);

        using RSA encryptor = pfx.GetRSAPublicKey();
        byte[] ciphertext = encryptor.Encrypt(plaintext, RSAEncryptionPadding.OaepSHA256);

        console.Out.WriteLine($"Encrypted message: {Convert.ToBase64String(ciphertext)}");

        // Decrypt and encode the message.
        using RSA decryptor = pfx.GetRSAPrivateKey();
        plaintext = decryptor.Decrypt(ciphertext, RSAEncryptionPadding.OaepSHA256);

        message = Encoding.UTF8.GetString(plaintext);
        console.Out.WriteLine($"Decrypted message: {message}");

        return 0;
    }

    private static string ParseSecretName(Uri secretId)
    {
        if (secretId.Segments.Length < 3)
        {
            throw new InvalidOperationException($@"The secret ""{secretId}"" does not contain a valid name.");
        }

        return secretId.Segments[2].TrimEnd('/');
    }

    private static X509Certificate2 ParseCertificate(KeyVaultSecret secret)
    {
        if (string.Equals(secret.Properties.ContentType, CertificateContentType.Pkcs12.ToString(), StringComparison.InvariantCultureIgnoreCase))
        {
            byte[] pfx = Convert.FromBase64String(secret.Value);
            return new X509Certificate2(pfx);
        }

        // For PEM, you'll need to extract the base64-encoded message body.
        // .NET 5.0 introduces the System.Security.Cryptography.PemEncoding class to make this easier.
        if (string.Equals(secret.Properties.ContentType, CertificateContentType.Pem.ToString(), StringComparison.InvariantCultureIgnoreCase))
        {
            StringBuilder privateKeyBuilder = new StringBuilder();
            StringBuilder publicKeyBuilder = new StringBuilder();

            using StringReader reader = new StringReader(secret.Value);
            StringBuilder currentKeyBuilder = null;

            string line = reader.ReadLine();
            while (line != null)
            {
                if (line.Equals("-----BEGIN PRIVATE KEY-----", StringComparison.OrdinalIgnoreCase))
                {
                    currentKeyBuilder = privateKeyBuilder;
                }
                else if (line.Equals("-----BEGIN CERTIFICATE-----", StringComparison.OrdinalIgnoreCase))
                {
                    currentKeyBuilder = publicKeyBuilder;
                }
                else if (line.StartsWith("-----", StringComparison.Ordinal))
                {
                    currentKeyBuilder = null;
                }
                else if (currentKeyBuilder is null)
                {
                    throw new InvalidOperationException("Invalid PEM-encoded certificate.");
                }
                else
                {
                    currentKeyBuilder.Append(line);
                }

                line = reader.ReadLine();
            }

            string privateKeyBase64 = privateKeyBuilder?.ToString() ?? throw new InvalidOperationException("No private key found in certificate.");
            string publicKeyBase64 = publicKeyBuilder?.ToString() ?? throw new InvalidOperationException("No public key found in certificate.");

            byte[] privateKey = Convert.FromBase64String(privateKeyBase64);
            byte[] publicKey = Convert.FromBase64String(publicKeyBase64);

            X509Certificate2 certificate = new X509Certificate2(publicKey);

            using RSA rsa = RSA.Create();
            rsa.ImportPkcs8PrivateKey(privateKey, out _);

            return certificate.CopyWithPrivateKey(rsa);
        }

        throw new NotSupportedException($@"Certificate encoding ""{secret.Properties.ContentType}"" is not supported.");
    }

    #region Configuration
    // Expose RootCommand for invoking directly via optional tests.
    internal static readonly RootCommand Command;
    private static readonly CancellationTokenSource s_cancellationTokenSource;

    static Program()
    {
        Command = new RootCommand("Encrypts and decrypts a message using a certificate from Azure Key Vault")
        {
            new Option<Uri>(
                alias: "--vault-name",
                description: "Key Vault name or URI, e.g. my-vault or https://my-vault-vault.azure.net",
                parseArgument: result =>
                {
                    string value = result.Tokens.Single().Value;
                    if (Uri.TryCreate(value, UriKind.Absolute, out Uri vaultUri) ||
                        Uri.TryCreate($"https://{value}.vault.azure.net", UriKind.Absolute, out vaultUri))
                    {
                        return vaultUri;
                    }

                    result.ErrorMessage = "Must specify a vault name or URI";
                    return null!;
                }
            )
            {
                Name = "vaultUri",
                IsRequired = true,
            },

            new Option<string>(
                aliases: new[] { "-n", "--certificate-name" },
                description: "Name of the certificate to use for encrypting and decrypting."
            )
            {
                IsRequired = true,
            },

            new Option<string>(
                aliases: new[] { "-m", "--message" },
                description: "The message to encrypt and decrypt."
            ),
        };

        Command.Handler = CommandHandler.Create<Uri, string, string, IConsole>(RunAsync);

        s_cancellationTokenSource = new CancellationTokenSource();
    }

    private static async Task<int> Main(string[] args)
    {
        Console.CancelKeyPress += (_, args) =>
        {
            Console.Error.WriteLine("Canceling...");
            s_cancellationTokenSource.Cancel();

            args.Cancel = true;
        };

        return await Command.InvokeAsync(args);
    }
    #endregion
}
