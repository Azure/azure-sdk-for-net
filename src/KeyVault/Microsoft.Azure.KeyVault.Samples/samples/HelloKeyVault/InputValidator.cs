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
using System.Security.Cryptography;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.WebKey;

namespace Sample.Microsoft.HelloKeyVault
{
    // Contains the validators and parsers of the input argument
    class InputValidator
    {
        string[] args;

        public InputValidator( string[] args )
        {
            this.args = args;
        }

        /// <summary>
        /// Parse input arguments and get the operations list, if no operation is provided all the operations are being performed
        /// </summary>
        /// <returns> the operation list </returns>
        public List<KeyOperationType> GetKeyOperations()
        {
            List<KeyOperationType> keyOperations = new List<KeyOperationType>();
            foreach ( var arg in args )
            {
                var result = new KeyOperationType();
                if ( Enum.TryParse<KeyOperationType>( arg, true, out result ) )
                {
                    keyOperations.Add( result );
                }
            }

            // if no operation found use the default
            if ( keyOperations.Count == 0 )
            {
                Console.Out.WriteLine( "No operation is provided. Executing all the key and secret operations!" );
                keyOperations.Add( KeyOperationType.CREATE_KEY );
                keyOperations.Add( KeyOperationType.GET_KEY );                
                keyOperations.Add( KeyOperationType.IMPORT_KEY );
                keyOperations.Add( KeyOperationType.BACKUP_RESTORE );
                keyOperations.Add( KeyOperationType.SIGN_VERIFY );
                keyOperations.Add( KeyOperationType.WRAP_UNWRAP );
                keyOperations.Add( KeyOperationType.ENCRYPT );
                keyOperations.Add( KeyOperationType.DECRYPT );
                keyOperations.Add( KeyOperationType.UPDATE_KEY );
                keyOperations.Add( KeyOperationType.LIST_KEYVERSIONS );
                keyOperations.Add( KeyOperationType.DELETE_KEY );
                keyOperations.Add( KeyOperationType.CREATE_SECRET );
                keyOperations.Add( KeyOperationType.GET_SECRET );
                keyOperations.Add( KeyOperationType.LIST_SECRETS );
                keyOperations.Add( KeyOperationType.DELETE_SECRET );
            }
            return keyOperations;
        }

        /// <summary>
        /// Gets plain text to be encrypted, if the argument is not provided returns the default plain text
        /// </summary>
        /// <returns> plain text </returns>
        public byte[] GetPlainText()
        {
            var tag = "-text";
            var text = GetArgumentValue( tag );

            if ( text == string.Empty )
            {
                Console.Out.WriteLine( tag + " is not provided. Using default value!" );
                text = File.ReadAllText( "plainText.txt" );
            }

            return System.Text.Encoding.UTF8.GetBytes( text );
        }

        /// <summary>
        /// Gets plain text to be encrypted, if the argument is not provided returns the default plain text
        /// </summary>
        /// <returns> plain text </returns>
        public byte[] GetCipherText()
        {
            var tag = "-text";
            var text = GetArgumentValue( tag );
            
            if ( text == string.Empty )
            {
                Console.Out.WriteLine( tag + " is not provided. Using default value!" );
                text = File.ReadAllText( "cipherText.txt" );
            }

            return Convert.FromBase64String(text);
        }

        /// <summary>
        /// Gets digest hash value, if the argument is not provided returns the default digest value
        /// </summary>
        /// <returns> digest hash </returns>
        public byte[] GetDigestHash()
        {
            var tag = "-digestfile";
            var digestfile = GetArgumentValue( tag );
            var digest = RandomHash<SHA256CryptoServiceProvider>( 32 );
            if ( digestfile != string.Empty )
            {
                digest = File.ReadAllBytes( digestfile );
            }
            else
            {
                Console.Out.WriteLine( tag + " is not provided. Using default value!" );
            }
            return digest;
        }

        /// <summary>
        /// Gets sign algorithm, if the argument is not provided returns the default sign algorithm
        /// </summary>
        /// <returns> sign algorithm </returns>
        public string GetSignAlgorithm()
        {
            var tag = "-algo";
            var algorithm = GetArgumentValue( tag );
            if ( algorithm == string.Empty )
            {
                algorithm = JsonWebKeySignatureAlgorithm.RS256;
                Console.Out.WriteLine( tag + " is not provided. Using default value!" );
            }
            return algorithm;
        }

        /// <summary>
        /// Gets encryption algorithm, if the argument is not provided returns the default encryption algorithm
        /// </summary>
        /// <returns> encryption algorithm </returns>
        public string GetEncryptionAlgorithm()
        {
            var tag = "-algo";
            var algorithm = GetArgumentValue( tag );
            if ( algorithm == string.Empty )
            {
                algorithm = JsonWebKeyEncryptionAlgorithm.RSAOAEP;
                Console.Out.WriteLine( tag + " is not provided. Using default value!" );
            }
            return algorithm;
        }

        /// <summary>
        /// Gets symmetric key, if the argument is not provided returns the default symmetric key
        /// </summary>
        /// <returns> symmetric key </returns>
        public byte[] GetSymmetricKey()
        {
            var tag = "-symkeyfile";
            var symmetricKeyFile = GetArgumentValue( tag );
            var symmetricKey = SymmetricAlgorithm.Create().Key;
            if ( symmetricKeyFile != string.Empty )
            {
                symmetricKey = File.ReadAllBytes( symmetricKeyFile );
            }
            else
            {
                Console.Out.WriteLine( tag + " is not provided. Using default value!" );
            }
            return symmetricKey;
        }

        /// <summary>
        /// Gets vault address, if the argument is not provided returns the address of the default vault
        /// </summary>
        /// <returns> valut address</returns>
        public string GetVaultAddress()
        {
            var tag = "-vault";
            string keyVaultVaultAddress = GetArgumentValue( tag );
            if ( keyVaultVaultAddress == string.Empty )
            {
                keyVaultVaultAddress = ConfigurationManager.AppSettings["VaultUrl"];
                Console.Out.WriteLine( tag + " is not provided. Using default value: " + keyVaultVaultAddress );
            }
            return keyVaultVaultAddress;
        }

        /// <summary>
        /// Gets the setting to enable/disable tracing 
        /// </summary>
        /// <returns>true for enable, false for disable</returns>
        public bool GetTracingEnabled()
        {
            var value = ConfigurationManager.AppSettings["TracingEnabled"];
            bool enable = false;

            bool.TryParse( value, out enable );
            return enable;
        }

        /// <summary>
        /// Get key ID from argument list
        /// </summary>
        /// <returns> key ID </returns>
        public string GetKeyId()
        {
            var tag = "-keyid";
            string keyId = GetArgumentValue( tag );
            if ( keyId == string.Empty )
            {
                throw new Exception( tag + " argument is missing" );
            }
            return keyId;
        }

        /// <summary>
        /// Get key name from argument list
        /// </summary>
        /// <param name="mandatory"> whether the cli parameter is mandatory or not </param>
        /// <returns> the name of the key </returns>
        public string GetKeyName(bool mandatory = false, bool allowDefault = true)
        {
            var tag = "-keyname";
            string name = GetArgumentValue( tag );
            if ( name == string.Empty )
            {
                if ( mandatory == true )
                {
                    throw new Exception( tag + " argument is missing" );
                }
                if ( allowDefault )
                {
                    name = "mykey";
                    Console.Out.WriteLine( tag + " is not provided. Using default value: " + name );
                }
            }
            return name;
        }

        /// <summary>
        /// Get secret name from argument list
        /// </summary>
        /// <param name="mandatory"> whether the cli parameter is mandatory or not </param>
        /// <returns> the name of the secret </returns>
        public string GetSecretName( bool mandatory = false, bool allowDefault = true )
        {
            var tag = "-secretname";
            string name = GetArgumentValue( tag );

            if ( name == string.Empty )
            {
                if ( mandatory == true )
                {
                    throw new Exception( tag + " argument is missing" );
                }
                if ( allowDefault )
                {
                    name = "mysecret";
                    Console.Out.WriteLine( tag + " is not provided. Using default value: " + name );
                }
            }
            return name;
        }

        /// <summary>
        /// Get secret value from argument list
        /// </summary>
        /// <returns> the name of the secret </returns>
        public string GetSecretValue()
        {
            var tag = "-secretvalue";
            string value = GetArgumentValue( tag );
            if ( value == string.Empty )
            {
                value = "default secret value";
                Console.Out.WriteLine( tag + " is not provided. Using new guid: " + value );
            }
            return value;
        }

        /// <summary>
        /// Get a set of key:value pairs to use as tags for keys/secrets
        /// </summary>
        /// <returns> dictionary to use as tags </returns>
        public Dictionary<string, string> GetTags()
        {
            return new Dictionary<string, string> { { "purpose", "demo Key Vault operations" }, { "app", "HelloKeyVault" } };
        }

        /// <summary>
        /// Get secret content type from argument list
        /// </summary>
        /// <returns> the content type of the secret </returns>
        public string GetSecretContentType()
        {
            var tag = "-secretcontenttype";
            string value = GetArgumentValue(tag);
            if (value == string.Empty)
            {
                value = "plaintext";
                Console.Out.WriteLine(tag + " is not provided. Using default value: " + value);
            }
            return value;
        }

        /// <summary>
        /// Get secret or key name from argument list
        /// </summary>
        /// <returns> secret name </returns>
        public string GetKeyVersion()
        {
            var tag = "-keyversion";
            string version = GetArgumentValue( tag );
            if ( version == string.Empty )
            {
                Console.Out.WriteLine( tag + " is not provided.");
            }
            return version;
        }

        /// <summary>
        /// Get secret or key name from argument list
        /// </summary>
        /// <returns> secret name </returns>
        public string GetSecretVersion()
        {
            var tag = "-secretversion";
            string version = GetArgumentValue( tag );
            if ( version == string.Empty )
            {
                Console.Out.WriteLine( tag + " is not provided." );
            }
            return version;
        }

        /// <summary>
        /// Get secret ID from argument list
        /// </summary>
        /// <returns> secret ID </returns>
        internal string GetSecretId()
        {
            var tag = "-secretid";
            string secretId = GetArgumentValue( tag );
            if (secretId == string.Empty)
            {
                throw new Exception( tag + " argument is missing" );
            }
            return secretId;
        }

        /// <summary>
        /// Gets key bundle from args or uses a default key bundle
        /// </summary>
        /// <param name="args"> the input arguments of the console program </param>
        /// <returns> key bundle </returns>
        public KeyBundle GetKeyBundle()
        {
            // Default Key Bundle
            var defaultKeyBundle = new KeyBundle
            {
                Key = new JsonWebKey()
                {
                    Kty = GetKeyType(),
                },
                Attributes = new KeyAttributes()
                {
                    Enabled = true,
                    Expires = UnixEpoch.FromUnixTime(int.MaxValue),
                    NotBefore = UnixEpoch.FromUnixTime(0),
                }
            };

            return defaultKeyBundle;
        }

        internal string GetKeyType()
        {
            var tag = "-keytype";
            string keyType = GetArgumentValue( tag );
            if ( keyType == string.Empty )
            {
                keyType = JsonWebKeyType.Rsa;
                Console.Out.WriteLine( tag + " is not provided. Selecting key type as: " + keyType );
            }
            return keyType;
        }

        /// <summary>
        /// Gets the import key bundle
        /// </summary>
        /// <returns> key bundle </returns>
        internal KeyBundle GetImportKeyBundle()
        {
            var rsa    = new RSACryptoServiceProvider( 2048 );
            var webKey = CreateJsonWebKey(rsa.ExportParameters(true));

            // Default import Key Bundle
            var importKeyBundle = new KeyBundle
            {
                Key = webKey,
                Attributes = new KeyAttributes()
                {
                    Enabled = true,
                    Expires = UnixEpoch.FromUnixTime(int.MaxValue),
                    NotBefore = UnixEpoch.FromUnixTime(0),
                }
            };

            return importKeyBundle;
        }

        /// <summary>
        /// Gets the update key attribute
        /// </summary>
        /// <returns> Key attribute to update </returns>
        internal KeyAttributes GetUpdateKeyAttribute()
        {
            return new KeyAttributes()
            {
                Enabled = true,
                Expires = DateTime.UtcNow.AddDays( 2 ) ,
                NotBefore = DateTime.UtcNow.AddDays( -1 ) 
            };
        }

        /// <summary>
        /// Gets the update key attribute
        /// </summary>
        /// <returns> Key attribute to update </returns>
        internal SecretAttributes GetSecretAttributes()
        {
            return new SecretAttributes()
            {
                Enabled = true,
                Expires = DateTime.UtcNow.AddYears( 1 ),
                NotBefore = DateTime.UtcNow.AddDays( -1 ) 
            };
        }

        /// <summary>
        /// Creates a random hash of type T
        /// </summary>
        /// <typeparam name="T"> a derived class from HashAlgorithm</typeparam>
        /// <param name="length"> the length of the hash code </param>
        /// <returns> hash code </returns>
        private static byte[] RandomHash<T>( int length )
        {
            var data = RandomBytes( length );
            var hash = ( ( ( T )Activator.CreateInstance( typeof( T ) ) ) as HashAlgorithm ).ComputeHash( data );
            return hash;
        }

        /// <summary>
        /// Gets random bytes
        /// </summary>
        /// <param name="length"> the array length of the random bytes </param>
        /// <returns> array of random bytes </returns>
        private static byte[] RandomBytes( int length )
        {
            var bytes = new byte[length];
            Random rnd = new Random();
            rnd.NextBytes( bytes );
            return bytes;
        }

        /// <summary>
        /// Gets the argument value according to the proceding key
        /// </summary>
        /// <param name="argTag"> arg tag</param>
        /// <returns> argument value </returns>
        private string GetArgumentValue( string argTag )
        {
            string result = string.Empty;
            for ( int i = 0; i < args.Count(); i++ )
            {
                if ( string.Compare( args[i], argTag, true ) == 0 )
                {
                    if ( i + 1 < args.Count() )
                    {
                        result = args[i + 1];
                    }
                    break;
                }
            }
            return result;
        }


        /// <summary>
        /// Converts a RSAParameters object to a WebKey of type RSA.
        /// </summary>
        /// <param name="rsaParameters">The RSA parameters object to convert</param>
        /// <returns>A WebKey representing the RSA object</returns>
        private JsonWebKey CreateJsonWebKey(RSAParameters rsaParameters)
        {
            var key = new JsonWebKey
            {
                Kty = JsonWebKeyType.Rsa,
                E = rsaParameters.Exponent,
                N = rsaParameters.Modulus,
                D = rsaParameters.D,
                DP = rsaParameters.DP,
                DQ = rsaParameters.DQ,
                QI = rsaParameters.InverseQ,
                P = rsaParameters.P,
                Q = rsaParameters.Q
            };

            return key;
        }
    }
}
