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
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Represents the base of all Asset Collections.
    /// </summary>
    public abstract class BaseAssetCollection : BaseCollection<IAsset>
    {
        protected const string AssetSet = "Assets";

        /// <summary>
        /// Creates the empty asset in initialized state
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        /// <param name="options">A <see cref="AssetCreationOptions"/> value that specifies how to create an Asset.</param>
        /// <returns></returns>
        public abstract IAsset CreateEmptyAsset(string assetName, AssetCreationOptions options);

      

        /// <summary>
        /// Asynchronously creates an Asset containing the provided files.
        /// </summary>
        /// <param name="files">The files that make up an Asset.</param>
        /// <param name="primaryFile">The name of the file to be used as the primary file when creating the Asset.</param>
        /// <param name="options">A <see cref="AssetCreationOptions"/> value that specifies how to create an Asset.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel CreateAsync operation.</param>
        /// <returns>An <see cref="Task"/> of type <see cref="IAsset"/>, where IAsset representing the provided representing the provided <paramref name="files"/> created according to the specified creation <paramref name="options"/>.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="files"/> is null.</exception>
        /// <exception cref="ArgumentException">When <paramref name="files"/> is empty.</exception>
        /// <exception cref="ArgumentException">When <paramref name="files"/> contains an empty null or string.</exception>
        /// <exception cref="ArgumentException">When <paramref name="files"/> contains one or more files named the same. 
        /// <remarks>Different file paths does not mater; its the file name that must be unique</remarks></exception>
        /// <exception cref="FileNotFoundException">If the specified <paramref name="primaryFile"/> is not present in the provided <paramref name="files"/> collection.</exception>
        /// <remarks>
        ///     <para>By default Asset files are not transfer or storage encrypted.</para>
        ///     <para>The default upload access duration is 12 hours.</para>
        /// </remarks>
        public abstract Task<IAsset> CreateAsync(string[] files, string primaryFile, AssetCreationOptions options,
                                                 CancellationToken cancellationToken);

        /// <summary>
        /// Asynchronously creates an Asset containing the provided files.
        /// </summary>
        /// <param name="files">The files that make up an Asset.</param>
        /// <param name="primaryFile">The name of the file to be used as the primary file when creating the Asset.</param>
        /// <param name="uploadAccessDuration">The duration for which the asset will be writable. This is used to grant access to upload the specified files to the asset.</param>
        /// <param name="options">A <see cref="AssetCreationOptions"/> value that specifies how to create an Asset.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel CreateAsync operation.</param>
        /// <returns>An <see cref="Task"/> of type <see cref="IAsset"/>, where IAsset representing the provided representing the provided <paramref name="files"/> created according to the specified creation <paramref name="options"/>.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="files"/> is null.</exception>
        /// <exception cref="ArgumentException">When <paramref name="files"/> is empty.</exception>
        /// <exception cref="ArgumentException">When <paramref name="files"/> contains an empty null or string.</exception>
        /// <exception cref="ArgumentException">When <paramref name="files"/> contains one or more files named the same. 
        /// <remarks>Different file paths does not mater; its the file name that must be unique</remarks></exception>
        /// <exception cref="FileNotFoundException">If the specified <paramref name="primaryFile"/> is not present in the provided <paramref name="files"/> collection.</exception>
        /// <remarks>By default Asset files are not transfer or storage encrypted.</remarks>
        public abstract Task<IAsset> CreateAsync(string[] files, string primaryFile, TimeSpan uploadAccessDuration,
                                                 AssetCreationOptions options, CancellationToken cancellationToken);


        /// <summary>
        /// Creates an Asset containing the provided <paramref name="file"/>.
        /// </summary>
        /// <param name="file">The file to create an Asset from.</param>
        /// <returns>An Asset representing the provided file.</returns>
        /// <remarks>By default Asset files are not transfer or storage encrypted.</remarks>
        public IAsset Create(string file)
        {
            return Create(new[] { file }, file, AssetCreationOptions.None);
        }

        /// <summary>
        /// Creates an Asset containing the provided <paramref name="file"/>.
        /// </summary>
        /// <param name="file">The file to create an Asset from.</param>
        /// <param name="options">A <see cref="AssetCreationOptions"/> value that specifies how to create an Asset.</param>
        /// <returns>An Asset representing the provided <paramref name="file"/> created according to the specified <paramref name="options"/>.</returns>
        /// <remarks>By default Asset files are not transfer or storage encrypted.</remarks>
        public IAsset Create(string file, AssetCreationOptions options)
        {
            return Create(new[] { file }, file, options);
        }

        /// <summary>
        /// Creates an Asset containing the provided files.
        /// </summary>
        /// <param name="files">The files that make up an Asset.</param>
        /// <returns>An Asset representing composed of the provided <paramref name="files"/>.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="files"/> is null.</exception>
        /// <exception cref="ArgumentException">If <paramref name="files"/> is empty.</exception>
        /// <remarks>By default Asset files are not transfer or storage encrypted.</remarks>
        public IAsset Create(string[] files)
        {
            if (files == null)
            {
                throw new ArgumentNullException("files");
            }

            if (files.Length == 0)
            {
                throw new ArgumentException(StringTable.ErrorAssetZeroFileCount, "files");
            }

            return Create(files, files[0], AssetCreationOptions.None);
        }

        /// <summary>
        /// Creates an Asset containing the provided files.
        /// </summary>
        /// <param name="files">The files that make up an Asset.</param>
        /// <param name="options">A <see cref="AssetCreationOptions"/> value that specifies how to create an Asset.</param>
        /// <returns>An Asset representing the provided <paramref name="files"/> created according to the specified <paramref name="options"/>.</returns>
        /// <remarks>The first file in the provided files collection will be specified as the Assets primary file.</remarks>
        /// <exception cref="ArgumentNullException">If <paramref name="files"/> is null.</exception>
        /// <exception cref="ArgumentException">If <paramref name="files"/> is empty.</exception>
        /// <remarks>By default Asset files are not transfer or storage encrypted.</remarks>
        public IAsset Create(string[] files, AssetCreationOptions options)
        {
            if (files == null)
            {
                throw new ArgumentNullException("files");
            }

            if (files.Length == 0)
            {
                throw new ArgumentException(StringTable.ErrorAssetZeroFileCount, "files");
            }

            return Create(files, files[0], options);
        }

        /// <summary>
        /// Validates asset creation arguments.
        /// </summary>
        /// <param name="files">List of files for the asset.</param>
        /// <param name="primaryFile">Primary file for the asset.</param>
        internal static void ValidateAssetCreationArguments(string[] files, string primaryFile)
        {
            if (files == null)
            {
                throw new ArgumentNullException("files");
            }

            if (files.Length == 0)
            {
                throw new ArgumentException(StringTable.ErrorAssetZeroFileCount, "files");
            }

            if (files.Any(string.IsNullOrEmpty))
            {
                throw new ArgumentException(StringTable.ErrorCreatingAssetWithEmptyFileName, "files");
            }

            if (files.Select(Path.GetFileName).Distinct(StringComparer.OrdinalIgnoreCase).Count() != files.Length)
            {
                throw new ArgumentException(StringTable.ErrorCreatingAssetWithDuplicateFileNames, "files");
            }

            ValidatePrimaryFile(files, primaryFile);
        }

        /// <summary>
        /// Creates an Asset containing the provided files.
        /// </summary>
        /// <param name="files">The files that make up an Asset.</param>
        /// <param name="primaryFile">The name of the file to be used as the primary file when creating the Asset.</param>
        /// <param name="options">A <see cref="AssetCreationOptions"/> value that specifies how to create an Asset.</param>
        /// <returns>An Asset representing the provided <paramref name="files"/> created according to the specified creation <paramref name="options"/>.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="files"/> is null.</exception>
        /// <exception cref="ArgumentException">When <paramref name="files"/> is empty.</exception>
        /// <exception cref="ArgumentException">When <paramref name="files"/> contains an empty null or string.</exception>
        /// <exception cref="ArgumentException">When <paramref name="files"/> contains one or more files named the same. 
        /// <remarks>Different file paths does not mater; its the file name that must be unique</remarks></exception>
        /// <exception cref="FileNotFoundException">If the specified <paramref name="primaryFile"/> is not present in the provided <paramref name="files"/> collection.</exception>
        /// <remarks>By default Asset files are not transfer or storage encrypted.</remarks>
        public abstract IAsset Create(string[] files, string primaryFile, AssetCreationOptions options);

        /// <summary>
        /// Creates an Asset containing the provided files.
        /// </summary>
        /// <param name="files">The files that make up an Asset.</param>
        /// <param name="primaryFile">The name of the file to be used as the primary file when creating the Asset.</param>
        /// <param name="uploadAccessDuration">The duration for which the asset will be writable. This is used to grant access to upload the specified files to the asset.</param>
        /// <param name="options">A <see cref="AssetCreationOptions"/> value that specifies how to create an Asset.</param>
        /// <returns>
        /// An Asset representing the provided <paramref name="files"/> created according to the specified creation <paramref name="options"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">When <paramref name="files"/> is null.</exception>
        ///   
        /// <exception cref="ArgumentException">When <paramref name="files"/> is empty.</exception>
        ///   
        /// <exception cref="ArgumentException">When <paramref name="files"/> contains an empty null or string.</exception>
        ///   
        /// <exception cref="ArgumentException">When <paramref name="files"/> contains one or more files named the same.
        ///   <remarks>Different file paths does not mater; its the file name that must be unique</remarks></exception>
        ///   
        /// <exception cref="FileNotFoundException">If the specified <paramref name="primaryFile"/> is not present in the provided <paramref name="files"/> collection.</exception>
        /// <remarks>
        /// By default Asset files are not transfer or storage encrypted.
        /// </remarks>
        public abstract IAsset Create(string[] files, string primaryFile, TimeSpan uploadAccessDuration,AssetCreationOptions options);

        /// <summary>
        /// Creates an Asset from the files in a directory.
        /// </summary>
        /// <param name="directory">The directory containing the files making up an Asset.</param>
        /// <param name="primaryFile">The name of the file to be used as the primary file when creating the Asset.</param>
        /// <returns>An Asset representing the files in the provided <paramref name="directory"/> with the specified <paramref name="primaryFile"/>.</returns>
        /// <remarks>By default Asset files are not transfer or storage encrypted.</remarks>
        public IAsset CreateFromDirectory(string directory, string primaryFile)
        {
            return CreateFromDirectory(directory, primaryFile, AssetCreationOptions.None);
        }

        /// <summary>
        /// Creates an Asset from the files in a directory.
        /// </summary>
        /// <param name="directory">The directory containing the files making up an Asset.</param>
        /// <param name="primaryFile">The name of the file to be used as the primary file when creating the Asset.</param>
        /// <param name="options">A <see cref="AssetCreationOptions"/> value that specifies how to create an Asset.</param>
        /// <returns>An Asset representing the files in the provided <paramref name="directory"/> with the specified <paramref name="primaryFile"/>, 
        /// creating according the the specified creation <paramref name="options"/>.</returns>
        /// <remarks>By default Asset files are not transfer or storage encrypted.</remarks>
        public IAsset CreateFromDirectory(string directory, string primaryFile, AssetCreationOptions options)
        {
            string[] files = Directory.GetFiles(directory);
            return Create(files, primaryFile, options);
        }

        /// <summary>
        /// Updates an Asset 
        /// </summary>
        /// <param name="asset">The Asset to be updated.</param>
        public abstract void Update(IAsset asset);

        /// <summary>
        /// Deletes provided asset and the associated locators.
        /// </summary>
        /// <param name="asset">The asset to delete from the underlying collection.</param>
        public abstract void Delete(IAsset asset);
       

        internal void FireUploadProgress(UploadProgressEventArgs args)
        {
            EventHandler<UploadProgressEventArgs> uploadProgressHandler = OnUploadProgress;
            if (uploadProgressHandler != null)
            {
                uploadProgressHandler(this, args);
            }
        }
        
        /// <summary>
        /// Occurs when uploading a file.
        /// </summary>
        public event EventHandler<UploadProgressEventArgs> OnUploadProgress;

        internal static void VerifyAsset(IAsset asset)
        {
            if (!(asset is AssetData))
            {
                throw new InvalidCastException(StringTable.ErrorInvalidAssetType);
            }
        }

        internal static void SetFileInfoForCommonEncryption(FileInfoData file)
        {
            file.IsEncrypted = true;
            file.EncryptionScheme = CommonEncryption.SchemeName;
            file.EncryptionVersion = CommonEncryption.SchemeVersion;
        }

        internal void SetFileInformation(string primaryFile, AssetCreationOptions options, FileEncryption fileEncryption, IAsset localAsset)
        {
            if (ShouldUpdateFileInformation(primaryFile, options))
            {
                foreach (FileInfoData file in localAsset.Files)
                {
                    UpdateFileEncryptionInformation(options, fileEncryption, file);

                    if (primaryFile != null && string.Equals(Path.GetFileName(primaryFile), file.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        file.IsPrimary = true;
                        OnUpdatedFileInfo(file);
                    }
                }
            }
        }

        internal virtual void OnUpdatedFileInfo(FileInfoData file)
        {
        }

        internal void UpdateFileEncryptionInformation(AssetCreationOptions options, FileEncryption fileEncryption, FileInfoData file)
        {
            if (options.HasFlag(AssetCreationOptions.StorageEncrypted))
            {
                //  Update the files associated with the asset with the encryption related metadata
                AddEncryptionMetadataToFileInfo(file, fileEncryption);
                OnUpdatedFileInfo(file);
            }
            else if (options.HasFlag(AssetCreationOptions.CommonEncryptionProtected))
            {
                //  Update the files associated with the asset with the encryption related metadata
                SetFileInfoForCommonEncryption(file);
                OnUpdatedFileInfo(file);
            }
        }

        internal static bool ShouldUpdateFileInformation(string primaryFile, AssetCreationOptions options)
        {
            return options.HasFlag(AssetCreationOptions.StorageEncrypted) ||
                   options.HasFlag(AssetCreationOptions.CommonEncryptionProtected) ||
                   primaryFile != null;
        }

        internal static void AddEncryptionMetadataToFileInfo(FileInfoData file, FileEncryption fileEncryption)
        {
            ulong iv = fileEncryption.GetInitializationVectorForFile(file.Name);

            file.IsEncrypted = true;
            file.EncryptionKeyId = fileEncryption.GetKeyIdentifierAsString();
            file.EncryptionScheme = FileEncryption.SchemeName;
            file.EncryptionVersion = FileEncryption.SchemeVersion;
            file.InitializationVector = iv.ToString(CultureInfo.InvariantCulture);
        }
        
        static internal void ValidatePrimaryFile(string[] files, string primaryFile)
        {
            string primaryFileName = Path.GetFileName(primaryFile);
            if (!files.Select(Path.GetFileName)
                      .Any(fileName => string.Equals(fileName, primaryFileName, StringComparison.OrdinalIgnoreCase)))
            {
                throw new FileNotFoundException(string.Format(CultureInfo.CurrentCulture, StringTable.ErrorPrimaryFileNotFound, primaryFile));
            }
        }
    }
}
