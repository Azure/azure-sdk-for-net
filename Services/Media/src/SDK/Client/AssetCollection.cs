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
using System.Data.Services.Client;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Represents a collection of Assets for a <see cref="CloudMediaContext"/>.
    /// </summary>
    public class AssetCollection : BaseAssetCollection
    {
        private readonly DataServiceContext _dataContext;
        private readonly CloudMediaContext _cloudMediaContext;
        private readonly Lazy<IQueryable<IAsset>> _assetQuery;
        private readonly BlobTransferClient _blobTransferClient;
        private int _totalFiles;
        private long _totalBytesToSend;
        private static readonly TimeSpan _defaultUploadAccessDuration = TimeSpan.FromHours(12);

        internal AssetCollection(CloudMediaContext cloudMediaContext)
        {
            _cloudMediaContext = cloudMediaContext;
            _dataContext = cloudMediaContext.DataContext;
            _assetQuery = new Lazy<IQueryable<IAsset>>(() => _cloudMediaContext.DataContext.CreateQuery<AssetData>(AssetSet));
            _blobTransferClient = new BlobTransferClient();
            _blobTransferClient.NumberOfConcurrentTransfers = cloudMediaContext.NumberOfConcurrentTransfers;
            _blobTransferClient.ParallelTransferThreadCount = cloudMediaContext.ParallelTransferThreadCount;
            _blobTransferClient.TransferProgressChanged += new EventHandler<BlobTransferProgressChangedEventArgs>(TransferProgressChanged);
            _totalFiles = 0;
        }

        protected override IQueryable<IAsset> Queryable
        {
            get { return _assetQuery.Value; }
        }

        /// <summary>
        /// Creates an asset that doesn't contain any files and  <see cref="AssetState"/> is  Initialised. 
        /// </summary>
        /// <param name="assetName">Asset Name</param>
        /// <param name="options">A <see cref="AssetCreationOptions"/> which will be associated with created asset</param>
        public override IAsset CreateEmptyAsset(string assetName, AssetCreationOptions options)
        {
            AssetData tempAsset = new AssetData
            {
                Name = assetName,
                Options = (int)options
            };

            _dataContext.AddObject(AssetSet, tempAsset);
            _dataContext.SaveChanges();

            if (options.HasFlag(AssetCreationOptions.StorageEncrypted))
            {
                using (var fileEncryption = new NullableFileEncryption())
                {
                    CreateStorageContentKey(tempAsset, fileEncryption, _cloudMediaContext);
                }
            }
            
            return tempAsset;
        }


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
        public override Task<IAsset> CreateAsync(string[] files, string primaryFile, AssetCreationOptions options, CancellationToken cancellationToken)
        {
            return CreateAsync(files, primaryFile, uploadAccessDuration: _defaultUploadAccessDuration, options: options, cancellationToken: cancellationToken);
        }


       

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
        [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling"), SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Object is disposed in finally block")]
        public override Task<IAsset> CreateAsync(string[] files, string primaryFile, TimeSpan uploadAccessDuration, AssetCreationOptions options, CancellationToken cancellationToken)
        {

            if (uploadAccessDuration < TimeSpan.Zero || uploadAccessDuration > TimeSpan.MaxValue)
            {
                throw new ArgumentOutOfRangeException("uploadAccessDuration");
            }

            ValidateAssetCreationArguments(files, primaryFile);
            var tempAsset = CreateEmptyAsset(Path.GetFileNameWithoutExtension(files[0]), options);

            ILocator locator;
            var policy = PrepareAssetForUploadProcess((AssetData)tempAsset, uploadAccessDuration, out locator);
            
            var task = tempAsset.UploadFilesAsync(files, _blobTransferClient, locator, cancellationToken);
            return Task<IAsset>.Factory.StartNew(() =>
                                              {
                                                  for (int i = 0; i < files.Length; i++)
                                                  {
                                                      var size = new FileInfo(files[i]).Length;
                                                      Interlocked.Add(ref _totalBytesToSend, size);
                                                      Interlocked.Increment(ref _totalFiles);
                                                    
                                                  }
                                                  task.Wait();
                                                  return tempAsset;
                                              }).ContinueWith(ts => PostFileUploadActionsToCommitAsset(policy, ts, tempAsset, primaryFile,files.Count(), options), cancellationToken);

           
        }

        private IAsset PostFileUploadActionsToCommitAsset(IAccessPolicy policy, Task<IAsset> ts, IAsset tempAsset, string primaryFile,int totalFiles, AssetCreationOptions options)
        {
            Interlocked.Add(ref _totalFiles, totalFiles * -1);
            if (!ts.IsFaulted)
            {
                UpdatePrimaryFile(tempAsset, primaryFile, options);
                tempAsset.Publish();
                foreach (var locator in tempAsset.Locators)
                {
                     _cloudMediaContext.Locators.Revoke(locator);
                }
                _cloudMediaContext.AccessPolicies.Delete(policy);
                _cloudMediaContext.DataContext.SaveChanges();
            }
           

            if (ts.IsFaulted)
            {
                var exception  = ts.Exception.Flatten();
                
                if(exception.InnerExceptions.Count == 1)
                {
                    throw exception.InnerException;
                }

                throw exception;
            }

            // Fetch new asset so readonly fields are now filled out
            IAsset assetToReturn = ((IQueryable<AssetData>) Queryable).Where(c => c.Id == tempAsset.Id).First();
            return assetToReturn;
        }

        private void UpdatePrimaryFile(IAsset tempAsset, string primaryFile, AssetCreationOptions options)
        {
            if (ShouldUpdateFileInformation(primaryFile, options))
            {
                IAsset assetToEdit = ((IQueryable<AssetData>) Queryable).Where(c => c.Id == tempAsset.Id).First();

                foreach (FileInfoData file in assetToEdit.Files)
                {
                    if (primaryFile != null &&
                        string.Equals(Path.GetFileName(primaryFile), file.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        file.IsPrimary = true;
                        OnUpdatedFileInfo(file);
                    }
                }

                _dataContext.SaveChanges();
            }
        }

        private static ContentKeyData CreateStorageContentKey(AssetData tempAsset, NullableFileEncryption fileEncryption, CloudMediaContext cloudMediaContext)
        {
            // Create the content key
            fileEncryption.Init();

            // Encrypt it for delivery to Nimbus
            X509Certificate2 certToUse =
                ContentKeyCollection.GetCertificateToEncryptContentKey(cloudMediaContext.DataContext, ContentKeyType.StorageEncryption);
            ContentKeyData contentKeyData = BaseContentKeyCollection.CreateStorageContentKey(
                fileEncryption.FileEncryption,
                certToUse);

            cloudMediaContext.DataContext.AddObject(ContentKeyCollection.ContentKeySet, contentKeyData);
            cloudMediaContext.DataContext.SaveChanges();

            // associate it with the asset
            ((IAsset)tempAsset).ContentKeys.Add(contentKeyData);
            return contentKeyData;

        }
       
        internal override void OnUpdatedFileInfo(FileInfoData file)
        {
            _dataContext.UpdateObject(file);
        }
        private IAccessPolicy PrepareAssetForUploadProcess(AssetData tempAsset, TimeSpan uploadAccessDuration,out ILocator locator)
        {
          
            IAccessPolicy policy =
                this._cloudMediaContext.AccessPolicies.Create(
                    "UploadUrl",
                    uploadAccessDuration,
                    AccessPermissions.Write);

            locator = _cloudMediaContext.Locators.CreateSasLocator(tempAsset, policy);
            return policy;
        }

        /// <summary>
        /// Creates an Asset containing the provided files.
        /// </summary>
        /// <param name="files">The files that make up an Asset.</param>
        /// <param name="primaryFile">The name of the file to be used as the primary file when creating the Asset.</param>
        /// <param name="options">A <see cref="CancellationToken"/> to cancel Create operation.</param>
        /// <returns>An Asset representing the provided <paramref name="files"/> created according to the specified creation <paramref name="options"/>.</returns>
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
        public override IAsset Create(string[] files, string primaryFile, AssetCreationOptions options)
        {
            var task = CreateAsync(files, primaryFile, options, CancellationToken.None);
            return task.Result;
        }

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
        public override IAsset Create(string[] files, string primaryFile, TimeSpan uploadAccessDuration, AssetCreationOptions options)
        {
            var task = CreateAsync(files, primaryFile,uploadAccessDuration, options, CancellationToken.None);
            return task.Result;
        }


        /// <summary>
        /// Updates an Asset
        /// </summary>
        /// <param name="asset">The Asset to be updated.</param>
        public override void Update(IAsset asset)
        {
            VerifyAsset(asset);
            _dataContext.UpdateObject(asset);
            _dataContext.SaveChanges();
        }

        void TransferProgressChanged(object sender, BlobTransferProgressChangedEventArgs e)
        {
            FireUploadProgress(new UploadProgressEventArgs(e.LocalFile, _totalFiles, e.BytesSent, _totalBytesToSend));
        }

        /// <summary>
        /// Deletes provided asset and the associated locators.
        /// </summary>
        /// <param name="asset">The Asset to delete</param>
        public override void Delete(IAsset asset)
        {
            if(asset ==null)
            {
                throw new ArgumentNullException("asset");
            }
            VerifyAsset(asset);
            
            _dataContext.SaveChanges();
            _dataContext.DeleteObject(asset);
            _dataContext.SaveChanges();

            foreach (var locator in asset.Locators)
            {
                _dataContext.Detach(locator);
            }
        }
      
    }
}
