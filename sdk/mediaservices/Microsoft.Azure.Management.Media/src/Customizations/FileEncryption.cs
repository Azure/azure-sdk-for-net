// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;

namespace Microsoft.Azure.Management.Media.StorageEncryption
{
    /// <summary>
    /// Provides file encryption.
    /// </summary>
    [Obsolete("The Azure Media Services StorageEncryption feature has been deprecated in favor of Azure Storage Server Side Encryption.  Existing Asset files with StorageEncryption applied can be decrypted but new Assets cannot use StorageEncryption.")]
    public class FileEncryption : IDisposable
    {
        /// <summary>
        /// The version of the encryption scheme.
        /// </summary>
        public static readonly string SchemeVersion = "1.0";

        /// <summary>
        /// The key size for AES 256.
        /// </summary>
        public const int KeySizeInBytesForAes256 = 32;

        /// <summary>
        /// The key size for AES 256 in bits.
        /// </summary>
        public const int KeySizeInBitsForAes256 = 256;

        /// <summary>
        /// The name of the encryption scheme.
        /// </summary>
        public static readonly string SchemeName = "StorageEncryption";

        private object _lockObject = new object();
        private SymmetricAlgorithm _key;
        private Dictionary<string, ulong> _initializationVectorListByFileName = new Dictionary<string, ulong>();

        /// <summary>
        /// Initializes a new instance of the <see cref="FileEncryption"/> class.
        /// </summary>
        /// <param name="contentKey">The content key.</param>
        /// <param name="keyIdentifier">The key identifier.</param>
        public FileEncryption(byte[] contentKey, Guid keyIdentifier)
        {
            if (keyIdentifier == Guid.Empty)
            {
                throw new ArgumentException("Guid.Empty is not a valid keyIdentifier");
            }

            this.InternalInit(contentKey, keyIdentifier);
        }

        /// <summary>
        /// Gets the key identifier.
        /// </summary>
        public Guid KeyIdentifier { get; private set; }

        /// <summary>
        /// Gets the content key.
        /// </summary>
        /// <returns>The content key.</returns>
        public byte[] GetContentKey()
        {
            return this._key.Key;
        }

        /// <summary>
        /// Determines whether an initialization vector is present for the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>
        ///   <c>true</c> if an initialization vector is present for the specified file name; otherwise, <c>false</c>.
        /// </returns>
        public bool IsInitializationVectorPresent(string fileName)
        {
            bool returnValue = false;

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Cannot be null or empty", "fileName");
            }

            lock(this._lockObject)
            {
                returnValue = this._initializationVectorListByFileName.ContainsKey(fileName);
            }

            return returnValue;
        }

        /// <summary>
        /// Gets the initialization vector for file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>The initialization vector.</returns>
        public ulong GetInitializationVectorForFile(string fileName)
        {
            ulong returnValue = 0;

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Cannot be null or empty", "fileName");
            }

            lock(this._lockObject)
            {
                returnValue = this._initializationVectorListByFileName[fileName];
            }

            return returnValue;
        }

        /// <summary>
        /// Sets the initialization vector for file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="initializationVectorToSet">The initialization vector to set.</param>
        public void SetInitializationVectorForFile(string fileName, ulong initializationVectorToSet)
        {
            ulong temp = 0;

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Cannot be null or empty", "fileName");
            }

            lock(this._lockObject)
            {
                if (!this._initializationVectorListByFileName.TryGetValue(fileName, out temp))
                {
                    this._initializationVectorListByFileName.Add(fileName, initializationVectorToSet);
                }
                else if (this._initializationVectorListByFileName[fileName] != initializationVectorToSet)
                {
                    string message = string.Format(CultureInfo.CurrentCulture, "An initialization vector is already set for {0}.", fileName);
                    throw new InvalidOperationException(message);
                }
            }
        }

        /// <summary>
        /// Gets the file encryption transform.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>The transform.</returns>
        public FileEncryptionTransform GetTransform(string fileName)
        {
            return this.GetTransform(fileName, 0);
        }

        /// <summary>
        /// Gets the file encryption transform.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileOffset">The file offset.</param>
        /// <returns>The transform.</returns>
        public FileEncryptionTransform GetTransform(string fileName, long fileOffset)
        {
            ulong iv = 0;

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Cannot be null or empty", "fileName");
            }

            if (this.IsInitializationVectorPresent(fileName))
            {
                iv = this.GetInitializationVectorForFile(fileName);
            }
            else
            {
                throw new ArgumentException($"No initialization vector is present for {fileName}.  Please add one using the SetInitializationVectorForFile method.");
            }

            return this.GetTransform(iv, fileOffset);
        }

        /// <summary>
        /// Gets the file encryption transform.
        /// </summary>
        /// <param name="initializationVector">The initialization vector.</param>
        /// <returns>The transform.</returns>
        public FileEncryptionTransform GetTransform(ulong initializationVector)
        {
            return this.GetTransform(initializationVector, 0);
        }

        /// <summary>
        /// Gets the file encryption transform.
        /// </summary>
        /// <param name="initializationVector">The initialization vector.</param>
        /// <param name="fileOffset">The file offset.</param>
        /// <returns>The transform.</returns>
        public FileEncryptionTransform GetTransform(ulong initializationVector, long fileOffset)
        {
            ICryptoTransform transform = null;

            lock(this._lockObject)
            {
                // Note that ECB encrypt is always used for AES-CTR whether doing encryption or decryption.
                transform = this._key.CreateEncryptor();
            }

            return new FileEncryptionTransform(transform, initializationVector, fileOffset);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            // Take this object off the finalization queue and prevent the finalization
            // code from running a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._key != null)
                {
                    this._key.Dispose();
                    this._key = null;
                }
            }
        }

        /// <summary>
        /// Intializes this instance.
        /// </summary>
        /// <param name="contentKey">The content key.</param>
        /// <param name="keyIdentifier">The key identifier.</param>
        private void InternalInit(byte[] contentKey, Guid keyIdentifier)
        {
            if ((contentKey != null) && (contentKey.Length != KeySizeInBytesForAes256))
            {
                throw new ArgumentOutOfRangeException("contentKey", "StorageEncryption content keys are 256-bits in length.");
            }

            this.KeyIdentifier = keyIdentifier;

            this._key = Aes.Create();
            this._key.Mode = CipherMode.ECB;
            this._key.Padding = PaddingMode.None;
            if (contentKey != null)
            {
                this._key.Key = contentKey;
            }
            else
            {
                this._key.KeySize = KeySizeInBitsForAes256;
            }
        }
    }
}
