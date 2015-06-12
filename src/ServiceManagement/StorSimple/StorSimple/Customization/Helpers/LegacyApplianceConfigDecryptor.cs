// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.WindowsAzure.Management.StorSimple.Properties;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Microsoft.WindowsAzure.Management.StorSimple
{
    internal class LegacyApplianceConfigDecryptor
    {
        private readonly byte[] Salt = Encoding.ASCII.GetBytes("{D55EB64F-1F13-44AF-8B0B-53D5895DE418}");

        /// <summary>
        /// Decrypt the legacy config file encrypted by AES algorithm
        /// </summary>
        /// <param name="decryptionKey">key for decryption</param>
        /// <param name="configFileName">config file name</param>
        /// <returns>Stream of decrypted data</returns>
        internal Stream Decrypt(string decryptionKey, string configFileName)
        {
            if (string.IsNullOrEmpty(decryptionKey))
            {
                throw new ArgumentException(Resources.MigrationConfigDecryptionKeyNotFound);
            }

            if (!File.Exists(configFileName))
            {
                throw new FileNotFoundException(Resources.MigrationConfigFileNotFound, configFileName);
            }

            string configFile = File.ReadAllText(configFileName);
            if (string.IsNullOrEmpty(configFile))
            {
                throw new ArgumentException(Resources.MigrationConfigFileEmpty);
            }

            byte[] configFileEncryptedContent = Convert.FromBase64String(configFile);
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(decryptionKey, Salt);
            using (AesCryptoServiceProvider algorithm = new AesCryptoServiceProvider())
            {
                algorithm.Key = key.GetBytes(algorithm.KeySize / 8);
                algorithm.IV = key.GetBytes(algorithm.BlockSize / 8);

                ICryptoTransform decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV);
                using (MemoryStream decryptedMemoryStream = new MemoryStream())
                {
                    using (CryptoStream decryptedStream = new CryptoStream(decryptedMemoryStream, decryptor, CryptoStreamMode.Write))
                    {
                        decryptedStream.Write(configFileEncryptedContent, 0, configFileEncryptedContent.Length);
                    }

                    return new MemoryStream(decryptedMemoryStream.ToArray());
                }
            }
        }
    }
}