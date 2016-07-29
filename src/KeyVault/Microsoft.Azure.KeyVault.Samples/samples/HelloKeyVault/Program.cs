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
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace Sample.Microsoft.HelloKeyVault
{
    class Program
    {
        static KeyVaultClient keyVaultClient;
        static InputValidator inputValidator;

        static void Main(string[] args)
        {

            KeyBundle keyBundle = null; // The key specification and attributes
            SecretBundle secret = null;
            CertificateBundle certificateBundle = null;
            CertificateOperation certificateOperation = null;
            string keyName = string.Empty;
            string secretName = string.Empty;
            string certificateName = string.Empty;
            string certificateCreateName = string.Empty;

            inputValidator = new InputValidator(args);

            ServiceClientTracing.AddTracingInterceptor(new ConsoleTracingInterceptor());
            ServiceClientTracing.IsEnabled = inputValidator.GetTracingEnabled();

            var clientId = ConfigurationManager.AppSettings["AuthClientId"];
            var cerificateThumbprint = ConfigurationManager.AppSettings["AuthCertThumbprint"];

            var certificate = FindCertificateByThumbprint(cerificateThumbprint);
            var assertionCert = new ClientAssertionCertificate(clientId, certificate);

            keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback( 
                   (authority, resource, scope) => GetAccessToken(authority, resource, scope, assertionCert)), 
                   new InjectHostHeaderHttpMessageHandler());

            // SECURITY: DO NOT USE IN PRODUCTION CODE; FOR TEST PURPOSES ONLY
            //ServicePointManager.ServerCertificateValidationCallback += ( sender, cert, chain, sslPolicyErrors ) => true;

            List<KeyOperationType> successfulOperations = new List<KeyOperationType>();
            List<KeyOperationType> failedOperations = new List<KeyOperationType>();

            foreach (var operation in inputValidator.GetKeyOperations())
            {
                try
                {
                    Console.Out.WriteLine("\n\n {0} is in process ...", operation);
                    switch (operation)
                    {
                        case KeyOperationType.CREATE_KEY:
                            keyBundle = CreateKey(keyBundle, out keyName);
                            break;

                        case KeyOperationType.IMPORT_KEY:
                            keyBundle = ImportKey(out keyName);
                            break;

                        case KeyOperationType.GET_KEY:
                            keyBundle = GetKey(keyBundle);
                            break;

                        case KeyOperationType.LIST_KEYVERSIONS:
                            ListKeyVersions(keyName);
                            break;

                        case KeyOperationType.UPDATE_KEY:
                            keyBundle = UpdateKey(keyName);
                            break;

                        case KeyOperationType.DELETE_KEY:
                            DeleteKey(keyName);
                            break;

                        case KeyOperationType.BACKUP_RESTORE:
                            keyBundle = BackupRestoreKey(keyName);
                            break;

                        case KeyOperationType.SIGN_VERIFY:
                            SignVerify(keyBundle);
                            break;

                        case KeyOperationType.ENCRYPT_DECRYPT:
                            EncryptDecrypt(keyBundle);
                            break;

                        case KeyOperationType.ENCRYPT:
                            Encrypt(keyBundle);
                            break;

                        case KeyOperationType.DECRYPT:
                            Decrypt(keyBundle);
                            break;

                        case KeyOperationType.WRAP_UNWRAP:
                            WrapUnwrap(keyBundle);
                            break;

                        case KeyOperationType.CREATE_SECRET:
                            secret = CreateSecret(out secretName);
                            break;

                        case KeyOperationType.GET_SECRET:
                            secret = GetSecret(secret.Id);
                            break;

                        case KeyOperationType.LIST_SECRETS:
                            ListSecrets();
                            break;

                        case KeyOperationType.DELETE_SECRET:
                            secret = DeleteSecret(secretName);
                            break;

                        case KeyOperationType.CREATE_CERTIFICATE:
                            certificateOperation = CreateCertificate(out certificateCreateName);
                            break;

                        case KeyOperationType.IMPORT_CERTIFICATE:
                            certificateBundle = ImportCertificate(out certificateName);
                            break;

                        case KeyOperationType.EXPORT_CERTIFICATE:
                            var x509Certificate = ExportCertificate(certificateBundle);
                            break;

                        case KeyOperationType.LIST_CERTIFICATEVERSIONS:
                            ListCertificateVersions(certificateName);
                            break;

                        case KeyOperationType.LIST_CERTIFICATES:
                            ListCertificates();
                            break;

                        case KeyOperationType.DELETE_CERTIFICATE:
                            certificateBundle = DeleteCertificate(certificateName);
                            certificateBundle = DeleteCertificate(certificateCreateName);
                            break;
                    }
                    successfulOperations.Add(operation);
                }
                catch (KeyVaultErrorException exception)
                {
                    // The Key Vault exceptions are logged but not thrown to avoid blocking execution for other commands running in batch
                    Console.Out.WriteLine("Operation failed: {0}", exception.Body.Error.Message);
                    failedOperations.Add(operation);
                }

            }

            Console.Out.WriteLine("\n\n---------------Successful Key Vault operations:---------------");
            foreach (KeyOperationType type in successfulOperations)
                Console.Out.WriteLine("\t{0}", type);

            if (failedOperations.Count > 0)
            {
                Console.Out.WriteLine("\n\n---------------Failed Key Vault operations:---------------");
                foreach (KeyOperationType type in failedOperations)
                    Console.Out.WriteLine("\t{0}", type);
            }

            Console.Out.WriteLine();
            Console.Out.Write("Press enter to continue . . .");
            Console.In.Read();
        }

        /// <summary>
        /// Updates key attributes
        /// </summary>
        /// <param name="keyName"> a global key identifier of the key to update </param>
        /// <returns> updated key bundle </returns>
        private static KeyBundle UpdateKey(string keyName)
        {
            var vaultAddress = inputValidator.GetVaultAddress();
            keyName = (keyName == string.Empty) ? inputValidator.GetKeyId() : keyName;

            // Get key attribute to update
            var keyAttributes = inputValidator.GetUpdateKeyAttribute();
            var updatedKey = keyVaultClient.UpdateKeyAsync(vaultAddress, keyName, attributes: keyAttributes).GetAwaiter().GetResult();

            Console.Out.WriteLine("Updated key:---------------");
            PrintoutKey(updatedKey);

            return updatedKey;
        }

        /// <summary>
        /// Import an asymmetric key into the vault
        /// </summary>
        /// <param name="keyName">Key name</param>
        /// <returns> imported key bundle</returns>
        private static KeyBundle ImportKey(out string keyName)
        {
            var vaultAddress = inputValidator.GetVaultAddress();
            keyName = inputValidator.GetKeyName();
            var isHsm = inputValidator.GetKeyType() == JsonWebKeyType.RsaHsm;

            // Get key bundle which is needed for importing a key
            var keyBundle = inputValidator.GetImportKeyBundle();
            var importedKey = keyVaultClient.ImportKeyAsync(vaultAddress, keyName, keyBundle, isHsm).GetAwaiter().GetResult();

            Console.Out.WriteLine("Imported key:---------------");
            PrintoutKey(importedKey);

            return importedKey;
        }

        /// <summary>
        /// Gets the specified key
        /// </summary>
        /// <param name="keyId"> a global key identifier of the key to get </param>
        /// <returns> retrieved key bundle </returns>
        private static KeyBundle GetKey(KeyBundle key)
        {
            KeyBundle retrievedKey;
            string keyVersion = inputValidator.GetKeyVersion();
            string keyName = inputValidator.GetKeyName(allowDefault: false);

            if (keyVersion != string.Empty || keyName != string.Empty)
            {
                var vaultAddress = inputValidator.GetVaultAddress();
                if (keyVersion != string.Empty)
                {
                    keyName = inputValidator.GetKeyName(true);
                    retrievedKey = keyVaultClient.GetKeyAsync(vaultAddress, keyName, keyVersion).GetAwaiter().GetResult();
                }
                else
                {
                    retrievedKey = keyVaultClient.GetKeyAsync(vaultAddress, keyName).GetAwaiter().GetResult();
                }
            }
            else
            {
                // If the key is not initialized get the key id from args
                var keyId = (key != null) ? key.Key.Kid : inputValidator.GetKeyId();

                // Get the key using its ID
                retrievedKey = keyVaultClient.GetKeyAsync(keyId).GetAwaiter().GetResult();
            }

            Console.Out.WriteLine("Retrived key:---------------");
            PrintoutKey(retrievedKey);

            //store the created key for the next operation if we have a sequence of operations
            return retrievedKey;
        }

        /// <summary>
        /// List the versions of a key
        /// </summary>
        /// <param name="keyName"> key name</param>
        private static void ListKeyVersions(string keyName)
        {
            var vaultAddress = inputValidator.GetVaultAddress();
            keyName = (keyName == string.Empty) ? inputValidator.GetKeyId() : keyName;

            var numKeyVersions = 0;
            var maxResults = 1;

            Console.Out.WriteLine("List key versions:---------------");

            var results = keyVaultClient.GetKeyVersionsAsync(vaultAddress, keyName, maxResults).GetAwaiter().GetResult();

            if (results != null)
            {
                numKeyVersions += results.Count();
                foreach (var m in results)
                    Console.Out.WriteLine("\t{0}-{1}", m.Identifier.Name, m.Identifier.Version);
            }

            while (results != null && !string.IsNullOrWhiteSpace(results.NextPageLink))
            {
                results = keyVaultClient.GetKeyVersionsNextAsync(results.NextPageLink).GetAwaiter().GetResult();
                if (results != null)
                {
                    numKeyVersions += results.Count();
                    foreach (var m in results)
                        Console.Out.WriteLine("\t{0}-{1}", m.Identifier.Name, m.Identifier.Version);
                }
            }

            Console.Out.WriteLine("\n\tNumber of versions of key {0} in the vault: {1}", keyName, numKeyVersions);
        }

        /// <summary>
        /// Created the specified key
        /// </summary>
        /// <param name="keyBundle"> key bundle to create </param>
        /// <returns> created key bundle </returns>
        private static KeyBundle CreateKey(KeyBundle keyBundle, out string keyName)
        {
            // Get key bundle which is needed for creating a key
            keyBundle = keyBundle ?? inputValidator.GetKeyBundle();
            var vaultAddress = inputValidator.GetVaultAddress();
            keyName = inputValidator.GetKeyName();

            var tags = inputValidator.GetTags();

            // Create key in the KeyVault key vault
            var createdKey = keyVaultClient.CreateKeyAsync(vaultAddress, keyName, keyBundle.Key.Kty, keyAttributes: keyBundle.Attributes, tags: tags).GetAwaiter().GetResult();

            Console.Out.WriteLine("Created key:---------------");
            PrintoutKey(createdKey);

            // Store the created key for the next operation if we have a sequence of operations
            return createdKey;
        }


        /// <summary>
        /// Creates or updates a secret
        /// </summary>
        /// <returns> The created or the updated secret </returns>
        private static SecretBundle CreateSecret(out string secretName)
        {
            secretName = inputValidator.GetSecretName();
            string secretValue = inputValidator.GetSecretValue();

            var tags = inputValidator.GetTags();

            var contentType = inputValidator.GetSecretContentType();

            var secret = keyVaultClient.SetSecretAsync(inputValidator.GetVaultAddress(), secretName, secretValue, tags, contentType, inputValidator.GetSecretAttributes()).GetAwaiter().GetResult();

            Console.Out.WriteLine("Created/Updated secret:---------------");
            PrintoutSecret(secret);

            return secret;
        }

        /// <summary>
        /// Gets a secret
        /// </summary>
        /// <param name="secretId"> The secret ID </param>
        /// <returns> The created or the updated secret </returns>
        private static SecretBundle GetSecret(string secretId)
        {
            SecretBundle secret;
            string secretVersion = inputValidator.GetSecretVersion();

            if (secretVersion != string.Empty)
            {
                var vaultAddress = inputValidator.GetVaultAddress();
                string secretName = inputValidator.GetSecretName(true);
                secret = keyVaultClient.GetSecretAsync(vaultAddress, secretName, secretVersion).GetAwaiter().GetResult();
            }
            else
            {
                secretId = secretId ?? inputValidator.GetSecretId();
                secret = keyVaultClient.GetSecretAsync(secretId).GetAwaiter().GetResult();
            }
            Console.Out.WriteLine("Retrieved secret:---------------");
            PrintoutSecret(secret);

            return secret;
        }

        /// <summary>
        /// Lists secrets in a vault
        /// </summary>
        private static void ListSecrets()
        {
            var vaultAddress = inputValidator.GetVaultAddress();
            var numSecretsInVault = 0;
            var maxResults = 1;

            Console.Out.WriteLine("List secrets:---------------");
            var results = keyVaultClient.GetSecretsAsync(vaultAddress, maxResults).GetAwaiter().GetResult();

            if (results != null)
            {
                numSecretsInVault += results.Count();
                foreach (var m in results)
                    Console.Out.WriteLine("\t{0}", m.Identifier.Name);
            }

            while (results != null && !string.IsNullOrWhiteSpace(results.NextPageLink))
            {
                results = keyVaultClient.GetSecretsNextAsync(results.NextPageLink).GetAwaiter().GetResult();
                if (results != null)
                {
                    numSecretsInVault += results.Count();
                    foreach (var m in results)
                        Console.Out.WriteLine("\t{0}", m.Identifier.Name);
                }
            }

            Console.Out.WriteLine("\n\tNumber of secrets in the vault: {0}", numSecretsInVault);
        }

        /// <summary>
        /// Deletes secret
        /// </summary>
        /// <param name="secretName"> The secret name</param>
        /// <returns> The deleted secret </returns>
        private static SecretBundle DeleteSecret(string secretName)
        {
            // If the secret is not initialized get the secret Id from args
            var vaultAddress = inputValidator.GetVaultAddress();
            secretName = (secretName == string.Empty) ? inputValidator.GetSecretName() : secretName;

            var secret = keyVaultClient.DeleteSecretAsync(vaultAddress, secretName).GetAwaiter().GetResult();

            Console.Out.WriteLine("Deleted secret:---------------");
            PrintoutSecret(secret);

            return secret;
        }

        /// <summary>
        /// backup the specified key and then restores the key into a vault
        /// </summary>
        /// <param name="keyName"> the name of the key to get </param>
        /// <returns> restored key bundle </returns>
        private static KeyBundle BackupRestoreKey(string keyName)
        {
            var vaultAddress = inputValidator.GetVaultAddress();
            keyName = inputValidator.GetKeyName();

            // Get a backup of the key and cache its backup value
            var backupKeyResult = keyVaultClient.BackupKeyAsync(vaultAddress, keyName).GetAwaiter().GetResult();
            Console.Out.WriteLine(string.Format(
                "The backup key value contains {0} bytes.\nTo restore it into a key vault this value should be provided!", backupKeyResult.Value.Length));

            // Get the vault address from args or use the default one
            var newVaultAddress = inputValidator.GetVaultAddress();

            // Delete any existing key in that vault.
            keyVaultClient.DeleteKeyAsync(vaultAddress, keyName).GetAwaiter().GetResult();

            // Restore the backed up value into the vault
            var restoredKey = keyVaultClient.RestoreKeyAsync(newVaultAddress, backupKeyResult.Value).GetAwaiter().GetResult();

            Console.Out.WriteLine("Restored key:---------------");
            PrintoutKey(restoredKey);

            // Cache the restored key
            return restoredKey;
        }

        /// <summary>
        /// Deletes the specified key
        /// </summary>
        /// <param name="keyName"> the name of the key to delete </param>
        private static void DeleteKey(string keyName)
        {
            // If the key ID is not initialized get the key id from args
            var vaultAddress = inputValidator.GetVaultAddress();
            keyName = (keyName == string.Empty) ? inputValidator.GetKeyName() : keyName;

            // Delete the key with the specified ID
            var keyBundle = keyVaultClient.DeleteKeyAsync(vaultAddress, keyName).GetAwaiter().GetResult();
            Console.Out.WriteLine(string.Format("Key {0} is deleted successfully!", keyBundle.Key.Kid));
        }

        /// <summary>
        /// Wraps a symmetric key and then unwrapps the wrapped key
        /// </summary>
        /// <param name="key"> key bundle </param>
        private static void WrapUnwrap(KeyBundle key)
        {
            KeyOperationResult wrappedKey;

            var algorithm = inputValidator.GetEncryptionAlgorithm();
            byte[] symmetricKey = inputValidator.GetSymmetricKey();

            string keyVersion = inputValidator.GetKeyVersion();

            if (keyVersion != string.Empty)
            {
                var vaultAddress = inputValidator.GetVaultAddress();
                string keyName = inputValidator.GetKeyName(true);
                wrappedKey = keyVaultClient.WrapKeyAsync(vaultAddress, keyName, keyVersion, algorithm, symmetricKey).GetAwaiter().GetResult();
            }
            else
            {
                // If the key ID is not initialized get the key id from args
                var keyId = (key != null) ? key.Key.Kid : inputValidator.GetKeyId();

                // Wrap the symmetric key
                wrappedKey = keyVaultClient.WrapKeyAsync(keyId, algorithm, symmetricKey).GetAwaiter().GetResult();
            }

            Console.Out.WriteLine(string.Format("The symmetric key is wrapped using key id {0} and algorithm {1}", wrappedKey.Kid, algorithm));

            // Unwrap the symmetric key
            var unwrappedKey = keyVaultClient.UnwrapKeyAsync(wrappedKey.Kid, algorithm, wrappedKey.Result).GetAwaiter().GetResult();
            Console.Out.WriteLine(string.Format("The unwrapped key is{0}the same as the original key!",
                symmetricKey.SequenceEqual(unwrappedKey.Result) ? " " : " not "));
        }

        /// <summary>
        /// Encrypts a plain text and then decrypts the encrypted text
        /// </summary>
        /// <param name="key"> key to use for the encryption & decryption operations </param>
        private static void EncryptDecrypt(KeyBundle key)
        {
            KeyOperationResult operationResult;

            var algorithm = inputValidator.GetEncryptionAlgorithm();
            var plainText = inputValidator.GetPlainText();

            string keyVersion = inputValidator.GetKeyVersion();

            operationResult = _encrypt(key, keyVersion, algorithm, plainText);
            
            Console.Out.WriteLine(string.Format("The text is encrypted using key id {0} and algorithm {1}", operationResult.Kid, algorithm));

            // Decrypt the encrypted data
            var decryptedText = keyVaultClient.DecryptAsync(operationResult.Kid, algorithm, operationResult.Result).GetAwaiter().GetResult();

            Console.Out.WriteLine(string.Format("The decrypted text is{0}the same as the original key!",
                plainText.SequenceEqual(decryptedText.Result) ? " " : " not "));
            Console.Out.WriteLine(string.Format("The decrypted text is: {0}",
                Encoding.UTF8.GetString(decryptedText.Result)));
        }

        private static KeyOperationResult _encrypt(KeyBundle key, string keyVersion, string algorithm, byte[] plainText)
        {
            KeyOperationResult operationResult;

            if (keyVersion != string.Empty)
            {
                var vaultAddress = inputValidator.GetVaultAddress();
                string keyName = inputValidator.GetKeyName(true);

                // Encrypt the input data using the specified algorithm
                operationResult = keyVaultClient.EncryptAsync(vaultAddress, keyName, keyVersion, algorithm, plainText).GetAwaiter().GetResult();
            }
            else
            {
                // If the key is not initialized get the key id from args
                var keyId = (key != null) ? key.Key.Kid : inputValidator.GetKeyId();
                // Encrypt the input data using the specified algorithm
                operationResult = keyVaultClient.EncryptAsync(keyId, algorithm, plainText).GetAwaiter().GetResult();
            }

            return operationResult;
        }

        /// <summary>
        /// Encrypts plaintext
        /// </summary>
        /// <param name="key"> key to use for the encryption </param>
        private static void Encrypt(KeyBundle key)
        {
            KeyOperationResult  operationResult;

            var algorithm = inputValidator.GetEncryptionAlgorithm();
            var plainText = inputValidator.GetPlainText();

            string keyVersion = inputValidator.GetKeyVersion();

            operationResult = _encrypt(key, keyVersion, algorithm, plainText);
            
            File.WriteAllText("cipherText.txt", Convert.ToBase64String(operationResult.Result));

            Console.Out.WriteLine(string.Format("The text is encrypted using key id {0} and algorithm {1}", operationResult.Kid, algorithm));
            Console.Out.WriteLine(string.Format("Encrypted text, base-64 encoded: {0}", Convert.ToBase64String(operationResult.Result)));
        }

        /// <summary>
        /// Decrypts cipherText
        /// </summary>
        /// <param name="key"> key to use for the decryption </param>
        private static void Decrypt(KeyBundle key)
        {
            KeyOperationResult operationResult;

            var algorithm = inputValidator.GetEncryptionAlgorithm();
            var cipherText = inputValidator.GetCipherText();

            KeyBundle   localKey;

            localKey = (key ?? GetKey(null));

            // Decrypt the encrypted data
            operationResult = keyVaultClient.DecryptAsync(localKey.KeyIdentifier.ToString(), algorithm, cipherText).GetAwaiter().GetResult();

            Console.Out.WriteLine(string.Format("The decrypted text is: {0}", Encoding.UTF8.GetString(operationResult.Result)));
        }

        /// <summary>
        /// Signs a hash and then verifies the signature
        /// </summary>
        /// <param name="keyId"> a global key identifier of the key to get </param>
        private static void SignVerify(KeyBundle key)
        {
            KeyOperationResult signature;
            var algorithm = inputValidator.GetSignAlgorithm();
            var digest = inputValidator.GetDigestHash();

            string keyVersion = inputValidator.GetKeyVersion();
            if (keyVersion != string.Empty)
            {
                var vaultAddress = inputValidator.GetVaultAddress();
                string keyName = inputValidator.GetKeyName(true);
                signature = keyVaultClient.SignAsync(vaultAddress, keyName, keyVersion, algorithm, digest).GetAwaiter().GetResult();
            }
            else
            {
                // If the key is not initialized get the key id from args
                var keyId = (key != null) ? key.Key.Kid : inputValidator.GetKeyId();

                // Create a signature
                signature = keyVaultClient.SignAsync(keyId, algorithm, digest).GetAwaiter().GetResult();
            }
            Console.Out.WriteLine(string.Format("The signature is created using key id {0} and algorithm {1} ", signature.Kid, algorithm));

            // Verify the signature
            bool isVerified = keyVaultClient.VerifyAsync(signature.Kid, algorithm, digest, signature.Result).GetAwaiter().GetResult();
            Console.Out.WriteLine(string.Format("The signature is {0} verified!", isVerified ? "" : "not "));
        }

        /// <summary>
        /// Creates a certificate
        /// </summary>
        /// <param name="certificateName"> the name of the created certificate </param>
        /// <returns> The created certificate </returns>
        private static CertificateOperation CreateCertificate(out string certificateName)
        {
            var vaultAddress = inputValidator.GetVaultAddress();
            certificateName = inputValidator.GetCertificateName();

            // Create a self-signed certificate backed by a 2048 bit RSA key
            var policy = new CertificatePolicy
            {
                IssuerReference = new IssuerReference
                {
                    Name = "Self",
                },
                KeyProperties = new KeyProperties
                {
                    Exportable = true,
                    KeySize = 2048,
                    KeyType = "RSA"
                },
                SecretProperties = new SecretProperties
                {
                    ContentType = "application/x-pkcs12"
                },
                X509CertificateProperties = new X509CertificateProperties
                {
                    Subject = "CN=KEYVAULTDEMO"
                }
            };

            var tags = inputValidator.GetTags();

            var certificateOperation = keyVaultClient.CreateCertificateAsync(vaultAddress, certificateName, policy,
                    new CertificateAttributes { Enabled = true }, tags).GetAwaiter().GetResult();

            Console.Out.WriteLine("Created certificate:---------------");
            PrintoutCertificateOperation(certificateOperation);

            return certificateOperation;
        }

        /// <summary>
        /// Imports a certificate
        /// </summary>
        /// <param name="certificateName"> the name of the created certificate </param>
        /// <returns> The imported certificate </returns>
        private static CertificateBundle ImportCertificate(out string certificateName)
        {
            var vaultAddress = inputValidator.GetVaultAddress();
            certificateName = inputValidator.GetCertificateName();

            var pfxPath = inputValidator.GetPfxPath();
            var pfxPassword = inputValidator.GetPfxPassword();

            var policy = new CertificatePolicy
            {
                KeyProperties = new KeyProperties
                {
                    Exportable = true,
                    KeyType = "RSA"
                },
                SecretProperties = new SecretProperties
                {
                    ContentType = CertificateContentType.Pfx
                }
            };

            var base64X509 = string.Empty;
            if (File.Exists(pfxPath))
            {
                var x509Collection = new X509Certificate2Collection();
                x509Collection.Import(pfxPath, pfxPassword, X509KeyStorageFlags.Exportable);

                // A pfx can contain a chain            
                var x509Bytes = x509Collection.Cast<X509Certificate2>().Single(s => s.HasPrivateKey).Export(X509ContentType.Pfx, pfxPassword);
                base64X509 = Convert.ToBase64String(x509Bytes);
            }
            else
            {
                base64X509 = "MIIJOwIBAzCCCPcGCSqGSIb3DQEHAaCCCOgEggjkMIII4DCCBgkGCSqGSIb3DQEHAaCCBfoEggX2MIIF8jCCBe4GCyqGSIb3DQEMCgECoIIE / jCCBPowHAYKKoZIhvcNAQwBAzAOBAj15YH9pOE58AICB9AEggTYLrI + SAru2dBZRQRlJY7XQ3LeLkah2FcRR3dATDshZ2h0IA2oBrkQIdsLyAAWZ32qYR1qkWxLHn9AqXgu27AEbOk35 + pITZaiy63YYBkkpR + pDdngZt19Z0PWrGwHEq5z6BHS2GLyyN8SSOCbdzCz7blj3 + 7IZYoMj4WOPgOm / tQ6U44SFWek46QwN2zeA4i97v7ftNNns27ms52jqfhOvTA9c / wyfZKAY4aKJfYYUmycKjnnRl012ldS2lOkASFt + lu4QCa72IY6ePtRudPCvmzRv2pkLYS6z3cI7omT8nHP3DymNOqLbFqr5O2M1ZYaLC63Q3xt3eVvbcPh3N08D1hHkhz / KDTvkRAQpvrW8ISKmgDdmzN55Pe55xHfSWGB7gPw8sZea57IxFzWHTK2yvTslooWoosmGxanYY2IG / no3EbPOWDKjPZ4ilYJe5JJ2immlxPz + 2e2EOCKpDI + 7fzQcRz3PTd3BK + budZ8aXX8aW / lOgKS8WmxZoKnOJBNWeTNWQFugmktXfdPHAdxMhjUXqeGQd8wTvZ4EzQNNafovwkI7IV / ZYoa++RGofVR3ZbRSiBNF6TDj / qXFt0wN / CQnsGAmQAGNiN + D4mY7i25dtTu / Jc7OxLdhAUFpHyJpyrYWLfvOiS5WYBeEDHkiPUa / 8eZSPA3MXWZR1RiuDvuNqMjct1SSwdXADTtF68l / US1ksU657 + XSC + 6ly1A / upz + X71 + C4Ho6W0751j5ZMT6xKjGh5pee7MVuduxIzXjWIy3YSd0fIT3U0A5NLEvJ9rfkx6JiHjRLx6V1tqsrtT6BsGtmCQR1UCJPLqsKVDvAINx3cPA / CGqr5OX2BGZlAihGmN6n7gv8w4O0k0LPTAe5YefgXN3m9pE867N31GtHVZaJ / UVgDNYS2jused4rw76ZWN41akx2QN0JSeMJqHXqVz6AKfz8ICS / dFnEGyBNpXiMRxrY / QPKi / wONwqsbDxRW7vZRVKs78pBkE0ksaShlZk5GkeayDWC / 7Hi / NqUFtIloK9XB3paLxo1DGu5qqaF34jZdktzkXp0uZqpp + FfKZaiovMjt8F7yHCPk + LYpRsU2Cyc9DVoDA6rIgf + uEP4jppgehsxyT0lJHax2t869R2jYdsXwYUXjgwHIV0voj7bJYPGFlFjXOp6ZW86scsHM5xfsGQoK2Fp838VT34SHE1ZXU / puM7rviREHYW72pfpgGZUILQMohuTPnd8tFtAkbrmjLDo + k9xx7HUvgoFTiNNWuq / cRjr70FKNguMMTIrid + HwfmbRoaxENWdLcOTNeascER2a + 37UQolKD5ksrPJG6RdNA7O2pzp3micDYRs / +s28cCIxO//J/d4nsgHp6RTuCu4+Jm9k0YTw2Xg75b2cWKrxGnDUgyIlvNPaZTB5QbMid4x44/lE0LLi9kcPQhRgrK07OnnrMgZvVGjt1CLGhKUv7KFc3xV1r1rwKkosxnoG99oCoTQtregcX5rIMjHgkc1IdflGJkZzaWMkYVFOJ4Weynz008i4ddkske5vabZs37Lb8iggUYNBYZyGzalruBgnQyK4fz38Fae4nWYjyildVfgyo/fCePR2ovOfphx9OQJi+M9BoFmPrAg+8ARDZ+R+5yzYuEc9ZoVX7nkp7LTGB3DANBgkrBgEEAYI3EQIxADATBgkqhkiG9w0BCRUxBgQEAQAAADBXBgkqhkiG9w0BCRQxSh5IAGEAOAAwAGQAZgBmADgANgAtAGUAOQA2AGUALQA0ADIAMgA0AC0AYQBhADEAMQAtAGIAZAAxADkANABkADUAYQA2AGIANwA3MF0GCSsGAQQBgjcRATFQHk4ATQBpAGMAcgBvAHMAbwBmAHQAIABTAHQAcgBvAG4AZwAgAEMAcgB5AHAAdABvAGcAcgBhAHAAaABpAGMAIABQAHIAbwB2AGkAZABlAHIwggLPBgkqhkiG9w0BBwagggLAMIICvAIBADCCArUGCSqGSIb3DQEHATAcBgoqhkiG9w0BDAEGMA4ECNX+VL2MxzzWAgIH0ICCAojmRBO+CPfVNUO0s+BVuwhOzikAGNBmQHNChmJ/pyzPbMUbx7tO63eIVSc67iERda2WCEmVwPigaVQkPaumsfp8+L6iV/BMf5RKlyRXcwh0vUdu2Qa7qadD+gFQ2kngf4Dk6vYo2/2HxayuIf6jpwe8vql4ca3ZtWXfuRix2fwgltM0bMz1g59d7x/glTfNqxNlsty0A/rWrPJjNbOPRU2XykLuc3AtlTtYsQ32Zsmu67A7UNBw6tVtkEXlFDqhavEhUEO3dvYqMY+QLxzpZhA0q44ZZ9/ex0X6QAFNK5wuWxCbupHWsgxRwKftrxyszMHsAvNoNcTlqcctee+ecNwTJQa1/MDbnhO6/qHA7cfG1qYDq8Th635vGNMW1w3sVS7l0uEvdayAsBHWTcOC2tlMa5bfHrhY8OEIqj5bN5H9RdFy8G/W239tjDu1OYjBDydiBqzBn8HG1DSj1Pjc0kd/82d4ZU0308KFTC3yGcRad0GnEH0Oi3iEJ9HbriUbfVMbXNHOF+MktWiDVqzndGMKmuJSdfTBKvGFvejAWVO5E4mgLvoaMmbchc3BO7sLeraHnJN5hvMBaLcQI38N86mUfTR8AP6AJ9c2k514KaDLclm4z6J8dMz60nUeo5D3YD09G6BavFHxSvJ8MF0Lu5zOFzEePDRFm9mH8W0N/sFlIaYfD/GWU/w44mQucjaBk95YtqOGRIj58tGDWr8iUdHwaYKGqU24zGeRae9DhFXPzZshV1ZGsBQFRaoYkyLAwdJWIXTi+c37YaC8FRSEnnNmS79Dou1Kc3BvK4EYKAD2KxjtUebrV174gD0Q+9YuJ0GXOTspBvCFd5VT2Rw5zDNrA/J3F5fMCk4wOzAfMAcGBSsOAwIaBBSxgh2xyF+88V4vAffBmZXv8Txt4AQU4O/NX4MjxSodbE7ApNAMIvrtREwCAgfQ";
            }
            var certificate = keyVaultClient.ImportCertificateAsync(vaultAddress, certificateName, base64X509, pfxPassword,
                    policy).GetAwaiter().GetResult();

            Console.Out.WriteLine("Created certificate:---------------");
            PrintoutCertificate(certificate);

            return certificate;
        }

        /// <summary>
        /// Exports a certificate as X509Certificate object
        /// </summary>
        /// <param name="certificateBundle"> the certificate bundle </param>
        /// <returns> The exported certificate </returns>
        private static X509Certificate ExportCertificate(CertificateBundle certificateBundle)
        {
            // The contents of a certificate can be obtained by using the secret referenced in the certificate bundle
            var certContentSecret =
                keyVaultClient.GetSecretAsync(certificateBundle.SecretIdentifier.Identifier).GetAwaiter().GetResult();

            // Certificates can be exported in a mutiple formats (PFX, PEM).
            // Use the content type to determine how to strongly-type the certificate for the platform
            // The exported certificate doesn't have a password
            if (0 == string.CompareOrdinal(certContentSecret.ContentType, CertificateContentType.Pfx))
            {
                var exportedCertCollection = new X509Certificate2Collection();
                exportedCertCollection.Import(Convert.FromBase64String(certContentSecret.Value));
                return exportedCertCollection.Cast<X509Certificate2>().Single(s => s.HasPrivateKey);
            }

            return null;
        }

        /// <summary>
        /// Lists certificates in a vault
        /// </summary>
        private static void ListCertificates()
        {
            var vaultAddress = inputValidator.GetVaultAddress();
            var numSecretsInVault = 0;
            var maxResults = 1;

            Console.Out.WriteLine("List certificate:---------------");
            var results = keyVaultClient.GetCertificatesAsync(vaultAddress, maxResults).GetAwaiter().GetResult();

            if (results != null)
            {
                numSecretsInVault += results.Count();
                foreach (var m in results)
                    Console.Out.WriteLine("\t{0}", m.Identifier.Name);
            }

            while (results != null && !string.IsNullOrWhiteSpace(results.NextPageLink))
            {
                results = keyVaultClient.GetCertificatesNextAsync(results.NextPageLink).GetAwaiter().GetResult();
                if (results != null && results != null)
                {
                    numSecretsInVault += results.Count();
                    foreach (var m in results)
                        Console.Out.WriteLine("\t{0}", m.Identifier.Name);
                }
            }

            Console.Out.WriteLine("\n\tNumber of certificates in the vault: {0}", numSecretsInVault);
        }

        /// <summary>
        /// List the versions of a certificate
        /// </summary>
        /// <param name="certificateName"> certificate name</param>
        private static void ListCertificateVersions(string certificateName)
        {
            var vaultAddress = inputValidator.GetVaultAddress();
            certificateName = (certificateName == string.Empty) ? inputValidator.GetKeyId() : certificateName;

            var numKeyVersions = 0;
            var maxResults = 1;

            Console.Out.WriteLine("List certificate versions:---------------");

            var results = keyVaultClient.GetCertificateVersionsAsync(vaultAddress, certificateName, maxResults).GetAwaiter().GetResult();

            if (results != null)
            {
                numKeyVersions += results.Count();
                foreach (var m in results)
                    Console.Out.WriteLine("\t{0}-{1}", m.Identifier.Name, m.Identifier.Version);
            }

            while (results != null && !string.IsNullOrWhiteSpace(results.NextPageLink))
            {
                results = keyVaultClient.GetCertificateVersionsNextAsync(results.NextPageLink).GetAwaiter().GetResult();
                if (results != null && results != null)
                {
                    numKeyVersions += results.Count();
                    foreach (var m in results)
                        Console.Out.WriteLine("\t{0}-{1}", m.Identifier.Name, m.Identifier.Version);
                }
            }

            Console.Out.WriteLine("\n\tNumber of versions of certificate {0} in the vault: {1}", certificateName, numKeyVersions);
        }

        /// <summary>
        /// Deletes secret
        /// </summary>
        /// <param name="certificateName"> The certificate name</param>
        /// <returns> The deleted certificate </returns>
        private static CertificateBundle DeleteCertificate(string certificateName)
        {
            // If the secret is not initialized get the secret Id from args
            var vaultAddress = inputValidator.GetVaultAddress();
            certificateName = (certificateName == string.Empty) ? inputValidator.GetCertificateName() : certificateName;

            var certificate = keyVaultClient.DeleteCertificateAsync(vaultAddress, certificateName).GetAwaiter().GetResult();

            Console.Out.WriteLine("Deleted certificate:---------------");
            PrintoutCertificate(certificate);

            return certificate;
        }

        /// <summary>
        /// Prints out key bundle values
        /// </summary>
        /// <param name="keyBundle"> key bundle </param>
        private static void PrintoutKey(KeyBundle keyBundle)
        {
            Console.Out.WriteLine("Key: \n\tKey ID: {0}\n\tKey type: {1}",
                keyBundle.Key.Kid, keyBundle.Key.Kty);

            var expiryDateStr = keyBundle.Attributes.Expires.HasValue
                ? keyBundle.Attributes.Expires.ToString()
                : "Never";

            var notBeforeStr = keyBundle.Attributes.NotBefore.HasValue
                ? keyBundle.Attributes.NotBefore.ToString()
                : UnixTimeJsonConverter.EpochDate.ToString();

            Console.Out.WriteLine("Key attributes: \n\tIs the key enabled: {0}\n\tExpiry date: {1}\n\tEnable date: {2}",
                keyBundle.Attributes.Enabled, expiryDateStr, notBeforeStr);
        }

        /// <summary>
        /// Prints out secret values
        /// </summary>
        /// <param name="secret"> secret </param>
        private static void PrintoutSecret(SecretBundle secret)
        {
            Console.Out.WriteLine("\n\tSecret ID: {0}\n\tSecret Value: {1}",
                secret.Id, secret.Value);

            var expiryDateStr = secret.Attributes.Expires.HasValue
                ? secret.Attributes.Expires.ToString()
                : "Never";

            var notBeforeStr = secret.Attributes.NotBefore.HasValue
                ? secret.Attributes.NotBefore.ToString()
                : UnixTimeJsonConverter.EpochDate.ToString();

            Console.Out.WriteLine("Secret attributes: \n\tIs the key enabled: {0}\n\tExpiry date: {1}\n\tEnable date: {2}\n\tContent type: {3}",
                secret.Attributes.Enabled, expiryDateStr, notBeforeStr, secret.ContentType);

            PrintoutTags(secret.Tags);
        }

        /// <summary>
        /// Prints out the tags for a key/secret
        /// </summary>
        /// <param name="tags"></param>
        private static void PrintoutTags(IDictionary<string, string> tags)
        {
            if (tags != null)
            {
                Console.Out.Write("\tTags: ");
                foreach (string key in tags.Keys)
                {
                    Console.Out.Write("\n\t\t{0} : {1}", key, tags[key]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Prints out certificate bundle values
        /// </summary>
        /// <param name="certificateBundle"> certificate bundle </param>
        private static void PrintoutCertificate(CertificateBundle certificateBundle)
        {
            Console.Out.WriteLine("\n\tCertificate ID: {0}", certificateBundle.Id);

            var expiryDateStr = certificateBundle.Attributes.Expires.HasValue
                ? certificateBundle.Attributes.Expires.ToString()
                : "Never";

            var notBeforeStr = certificateBundle.Attributes.NotBefore.HasValue
                ? certificateBundle.Attributes.NotBefore.ToString()
                : UnixTimeJsonConverter.EpochDate.ToString();

            Console.Out.WriteLine("Certificate attributes: \n\tIs enabled: {0}\n\tExpiry date: {1}\n\tEnable date: {2}\n\tThumbprint: {3}",
                certificateBundle.Attributes.Enabled, expiryDateStr, notBeforeStr, ToHexString(certificateBundle.X5t));

            PrintoutTags(certificateBundle.Tags);

        }

        /// <summary>
        /// Prints out certificate operation values
        /// </summary>
        /// <param name="certificateBundle"> certificate bundle </param>
        private static void PrintoutCertificateOperation(CertificateOperation certificateOperation)
        {
            Console.Out.WriteLine("\n\tCertificate ID: {0}", certificateOperation.Id);

            Console.Out.WriteLine("Certificate Opeation: \n\tStatus: {0}\n\tStatus Detail: {1}\n\tTarget: {2}\n\tIssuer reference name: {3}",
                certificateOperation.Status, certificateOperation.StatusDetails, certificateOperation.Target, certificateOperation.IssuerReference.Name);

        }

        /// <summary>
        /// Gets the access token
        /// </summary>
        /// <param name="authority"> Authority </param>
        /// <param name="resource"> Resource </param>
        /// <param name="scope"> scope </param>
        /// <returns> token </returns>
        public static async Task<string> GetAccessToken(string authority, string resource, string scope, ClientAssertionCertificate assertionCert)
        {            
            var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
            var result = await context.AcquireTokenAsync(resource, assertionCert);

            return result.AccessToken;
        }

        /// <summary>
        /// Helper function to load an X509 certificate
        /// </summary>
        /// <param name="certificateThumbprint">Thumbprint of the certificate to be loaded</param>
        /// <returns>X509 Certificate</returns>
        public static X509Certificate2 FindCertificateByThumbprint(string certificateThumbprint)
        {
            if (certificateThumbprint == null)
                throw new System.ArgumentNullException("certificateThumbprint");

            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            try
            {
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindByThumbprint, certificateThumbprint, false); // Don't validate certs, since the test root isn't installed.
                if (col == null || col.Count == 0)
                    throw new System.Exception(
                        string.Format("Could not find the certificate with thumbprint {0} in the Local Machine's Personal certificate store.", certificateThumbprint));
                return col[0];
            }
            finally
            {
                store.Close();
            }
        }

        /// <summary>
        /// Converts a byte array to a Hex encoded string
        /// </summary>
        /// <param name="input">The byte array to convert</param>
        /// <returns>The Hex encoded form of the input</returns>
        private static string ToHexString(byte[] input)
        {
            if (input == null)
                return string.Empty;

            return BitConverter.ToString(input).Replace("-", string.Empty);
        }
    }
}
