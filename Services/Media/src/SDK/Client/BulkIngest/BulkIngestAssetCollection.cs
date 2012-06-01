// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MediaServices.Client;

namespace Microsoft.WindowsAzure.MediaServices.Client.BulkIngest
{
    /// <summary>
    /// Represents a collection of Assets for bulk ingest.
    /// </summary>
    internal class BulkIngestAssetCollection : BaseAssetCollection
    {
        private readonly List<IAsset> _assetTracking;
        private readonly string _outputFolder;
        private readonly List<IContentKey> _contentKeyTracking;
        private readonly string[] _protectionKeyIds;

        internal BulkIngestAssetCollection(string[] protectionKeyIds, List<IAsset> assetTracking, List<IContentKey> contentKeyTracking, string outputFolder)
        {
            _assetTracking = assetTracking;
            _outputFolder = outputFolder;
            _contentKeyTracking = contentKeyTracking;
            _protectionKeyIds = protectionKeyIds;
        }

        public override IAsset CreateEmptyAsset(string assetName, AssetCreationOptions options)
        {
            throw new NotSupportedException();
        }

        public override Task<IAsset> CreateAsync(string[] files, string primaryFile, AssetCreationOptions options, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public override Task<IAsset> CreateAsync(string[] files, string primaryFile, TimeSpan uploadAccessDuration, AssetCreationOptions options, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates an Asset containing the provided files.
        /// </summary>
        /// <param name="files">The files that make up an Asset.</param>
        /// <param name="primaryFile">The name of the file to be used as the primary file when creating the Asset.</param>
        /// <param name="options">A <see cref="AssetCreationOptions"/> value that specifies how to create an Asset.</param>
        /// <returns>An Asset representing the provided <paramref name="files"/> created according to the specified creation <paramref name="options"/>.</returns>
        public override IAsset Create(string[] files, string primaryFile, AssetCreationOptions options)
        {
            return Create(files, primaryFile, options, skipFileVerification: false);
        }

        public override IAsset Create(string[] files, string primaryFile, TimeSpan uploadAccessDuration, AssetCreationOptions options)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates an Asset containing the provided files.
        /// </summary>
        /// <param name="files">The files that make up an Asset.</param>
        /// <param name="primaryFile">The name of the file to be used as the primary file when creating the Asset.</param>
        /// <param name="options">A <see cref="AssetCreationOptions"/> value that specifies how to create an Asset.</param>
        /// <param name="skipFileVerification">true to skip file existence verification; otherwise false to verify that the provided files exist.</param>
        /// <returns>An Asset representing the provided <paramref name="files"/> created according to the specified creation <paramref name="options"/>.</returns>
        // TODO, 26165, Share this functionality with AssetContext.
        public IAsset Create(string[] files, string primaryFile, AssetCreationOptions options, bool skipFileVerification)
        {
            ValidateAssetCreationArguments(files, primaryFile);

            if (!skipFileVerification)
            {
                ValidateFilesAndCorrectNames(files);
            }

            using (NullableFileEncryption fileEncryption = new NullableFileEncryption())
            {
                var localAsset = new BulkIngestAssetData(Path.GetFileNameWithoutExtension(files[0]));

                _assetTracking.Add(localAsset);

                if (options.HasFlag(AssetCreationOptions.StorageEncrypted))
                {
                    if (string.IsNullOrWhiteSpace(_outputFolder) || !Directory.Exists(_outputFolder))
                    {
                        throw new InvalidOperationException(StringTable.BulkIngestAssetEncryptionRequiresAnOutputFolderSpecified);
                    }

                    fileEncryption.Init();
                    EncryptFiles(files, fileEncryption.FileEncryption);

                    int protectionKeyIndex = Convert.ToInt32(ContentKeyType.StorageEncryption, CultureInfo.InvariantCulture);
                    if ((_protectionKeyIds == null) || string.IsNullOrEmpty(_protectionKeyIds[protectionKeyIndex]))
                    {
                        throw new ArgumentException("Unknown ProtectionKeyId for ContentKeyType.StorageEncryption");
                    }
                    X509Certificate2 cert = BaseContentKeyCollection.GetCertificateForProtectionKeyId(null, _protectionKeyIds[protectionKeyIndex]);
                    ContentKeyData contentKey = BulkIngestContentKeyCollection.CreateStorageContentKey(fileEncryption.FileEncryption, cert);

                    _contentKeyTracking.Add(contentKey);
                    localAsset.ContentKeys.Add(contentKey);
                }

                localAsset.FilesList.AddRange(files.Select(f => new FileInfoData { Name = Path.GetFileName(f) }));

                SetFileInformation(primaryFile, options, fileEncryption.FileEncryption, localAsset);

                return localAsset;
            }
        }

        private static void ValidateFilesAndCorrectNames(IList<string> files)
        {
            for (int index = 0; index < files.Count; index++)
            {
                string file = files[index];
                FileInfo fileInfo = new FileInfo(file);

                if (!fileInfo.Exists)
                {
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, StringTable.BulkIngestProvidedFileDoesNotExist, file), "files");
                }

                FileInfo[] matchingFiles = fileInfo.Directory.GetFiles(fileInfo.Name, SearchOption.TopDirectoryOnly);

                files[index] = matchingFiles[0].FullName;
            }
        }

        private void EncryptFiles(string[] files, FileEncryption fileEncryption)
        {
            for (int i = 0; i < files.Length; i++)
            {
                var iv = fileEncryption.CreateInitializationVectorForFile(Path.GetFileName(files[i]));
                // Create a crypto stream wrapping the clear stream. When read from it will encrypt the file on the fly.
                // This works because AES CTR is a two way encryption mode.
                var file = File.OpenRead(files[i]);
                try
                {
                    using (var inputStream = new CryptoStream(file, fileEncryption.GetTransform(iv), CryptoStreamMode.Read))
                    {
                        file = null;
                        var outputPath = Path.Combine(_outputFolder, Path.GetFileName(files[i]));
                        using (var outputStream = File.Open(outputPath, FileMode.CreateNew))
                        {
                            // Use an explicit read buffer size so that the CTR mode index is predictable
                            inputStream.CopyTo(outputStream, bufferSize: 4096);
                            outputStream.Flush();
                        }
                        files[i] = outputPath;
                    }
                }
                finally
                {
                    if (file != null)
                    {
                        file.Dispose();
                    }
                }
            }
        }

        public override void Update(IAsset asset)
        {
        }

        /// <summary>
        /// Marks the specified Asset as deleted.
        /// </summary>
        /// <param name="asset">The asset to delete from the underlying collection.</param>        
        public override void Delete(IAsset asset)
        {
            _assetTracking.Remove(asset);
        }

        protected override IQueryable<IAsset> Queryable
        {
            get { return _assetTracking.AsQueryable(); }
        }
    }
}
