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
using System.Collections.ObjectModel;
using System.Data.Services.Client;
using System.Data.Services.Common;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.StorageClient;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    [DataServiceKey("Id")]
    internal partial class AssetData : IAsset, ICloudMediaContextInit
    {
        private ReadOnlyCollection<IFileInfo> _fileCollection;
        private ReadOnlyCollection<ILocator> _locatorCollection;
        private IList<IContentKey> _contentKeyCollection;
        private ReadOnlyCollection<IAsset> _parentAssetCollection;
        private CloudMediaContext _cloudMediaContext;

        public AssetData()
        {
            Locators = new List<LocatorData>();
            ContentKeys = new List<ContentKeyData>();
        }

        public void InitCloudMediaContext(CloudMediaContext context)
        {
            _cloudMediaContext = context;
        }

        public List<AssetData> ParentAssets { get; set; }
        public List<FileInfoData> Files { get; set; }
        public List<ContentKeyData> ContentKeys { get; set; }
        public List<LocatorData> Locators { get; set; }

        public Task UploadFilesAsync(string[] files, BlobTransferClient blobTransferClient, ILocator locator,
                                     CancellationToken token)
        {
            if (blobTransferClient == null)
            {
                throw new ArgumentNullException("blobTransferClient");
            }

            if (locator == null)
            {
                throw new ArgumentNullException("locator");
            }

            if (files == null)
            {
                throw new ArgumentNullException("files");
            }

            if (files.Length == 0)
            {
                throw new ArgumentException(StringTable.ArgumentExceptionForEmptyFileArray);
            }

            if (State == (int)AssetState.Published)
            {
                throw new InvalidOperationException(StringTable.InvalidOperationUploadFilesForPublishedAsset);
            }
            IContentKey contentKeyData = null;

            AssetCreationOptions assetCreationOptions = (AssetCreationOptions)Options;
            if (assetCreationOptions.HasFlag(AssetCreationOptions.StorageEncrypted))
            {
                contentKeyData =
                    ((IAsset)this).ContentKeys.Where(c => c.ContentKeyType == ContentKeyType.StorageEncryption).FirstOrDefault();
                if (contentKeyData == null)
                {
                    throw new InvalidOperationException(StringTable.StorageEncryptionContentKeyIsMissing);
                }
            }

            FileEncryption fileEncryption = null;

            if (assetCreationOptions.HasFlag(AssetCreationOptions.StorageEncrypted))
            {
                fileEncryption = new FileEncryption(contentKeyData.GetClearKeyValue(), EncryptionUtils.GetKeyIdAsGuid(contentKeyData.Id));
            }

            List<Task> tasks = new List<Task>();

            for (int i = 0; i < files.Length; i++)
            {
                tasks.Add(blobTransferClient.UploadBlob(
                    new Uri(locator.Path),
                    files[i],
                    fileEncryption,
                    token,
                    RetryPolicies.RetryExponential(RetryPolicies.DefaultClientRetryCount, RetryPolicies.DefaultClientBackoff))
                    );
            }

            return Task.Factory.ContinueWhenAll(tasks.ToArray(), ts => PostUploadAction(ts, fileEncryption, assetCreationOptions), token);
        }

        private void PostUploadAction(Task[] tasks, FileEncryption fileEncryption, AssetCreationOptions assetCreationOptions)
        {
            Uri uriCreateFileInfos =
                new Uri(
                    String.Format(
                        CultureInfo.InvariantCulture,
                        "/CreateFileInfos?assetid='{0}'",
                        Id), UriKind.Relative);
            _cloudMediaContext.DataContext.Execute
                <string>(uriCreateFileInfos);

            _cloudMediaContext.DataContext.
                LoadProperty(this, "Files");
            _fileCollection =
                Files.ToList<IFileInfo>().AsReadOnly();

            foreach (FileInfoData file in _fileCollection)
            {
                if (
                    assetCreationOptions.HasFlag(AssetCreationOptions.StorageEncrypted))
                {
                    //  Update the files associated with the asset with the encryption related metadata
                    BaseAssetCollection.AddEncryptionMetadataToFileInfo(file, fileEncryption);
                    _cloudMediaContext.DataContext.UpdateObject(file);
                }
                else if (assetCreationOptions.HasFlag(AssetCreationOptions.CommonEncryptionProtected))
                {
                    //  Update the files associated with the asset with the encryption related metadata
                    BaseAssetCollection.
                        SetFileInfoForCommonEncryption
                        (file);
                    _cloudMediaContext.DataContext.UpdateObject(file);
                }
            }

            _cloudMediaContext.DataContext.SaveChanges();
            if (fileEncryption != null)
            {
                fileEncryption.Dispose();
            }


            List<Exception> exceptions = tasks.ToList().Where(c => c.IsFaulted).Select(c => c.Exception.Flatten().InnerException).ToList();

            if (exceptions.Count > 0)
            {
                if (exceptions.Count == 1)
                {
                    throw exceptions[0];
                }
                throw new AggregateException(exceptions);
            }
        }

        public void Publish()
        {
            if (_cloudMediaContext == null)
            {
                throw new InvalidOperationException(
                    StringTable.InvalidOperationException_CloudMediaContextIsNotInitialized);
            }
            if (AssetState.Published == GetExposedState(State))
            {
                throw new InvalidOperationException(StringTable.InvalidOperationPublishForPublishedAsset);
            }

            Uri publishUri = new Uri(string.Format(CultureInfo.InvariantCulture, "/Assets('{0}')/Publish", Id),
                                     UriKind.Relative);
            _cloudMediaContext.DataContext.Execute(publishUri, "POST");
        }

        /// <summary>
        ///   Updates an Asset
        /// </summary>
        public void Update()
        {
            _cloudMediaContext.DataContext.UpdateObject(this);
            _cloudMediaContext.DataContext.SaveChanges();
        }


        /// <summary>
        ///   Deletes provided asset and the associated locators.
        /// </summary>
        public void Delete()
        {
            _cloudMediaContext.DataContext.DeleteObject(this);
            _cloudMediaContext.DataContext.SaveChanges();
        }

        ReadOnlyCollection<IFileInfo> IAsset.Files
        {
            get
            {
                if (_fileCollection == null)
                {
                    if (_cloudMediaContext != null)
                    {
                        EntityDescriptor desc = _cloudMediaContext.DataContext.GetEntityDescriptor(this);
                        if (desc != null &&
                            (desc.State == EntityStates.Unchanged || desc.State == EntityStates.Modified))
                        {
                            _cloudMediaContext.DataContext.LoadProperty(this, "Files");
                        }
                    }

                    _fileCollection = Files.ToList<IFileInfo>().AsReadOnly();
                }
                return _fileCollection;
            }
        }

        internal void InvalidateLocatorsCollection()
        {
            Locators.Clear();
            _locatorCollection = null;
        }

        ReadOnlyCollection<ILocator> IAsset.Locators
        {
            get
            {
                if (_locatorCollection == null || Locators == null)
                {
                    if (_cloudMediaContext != null)
                    {
                        EntityDescriptor desc = _cloudMediaContext.DataContext.GetEntityDescriptor(this);
                        if (desc != null && (desc.State == EntityStates.Unchanged || desc.State == EntityStates.Modified))
                        {
                            _cloudMediaContext.DataContext.LoadProperty(this, "Locators");
                        }
                    }

                    if (Locators != null)
                    {
                        _locatorCollection = Locators.ToList<ILocator>().AsReadOnly();
                    }
                    else
                    {
                        return new ReadOnlyCollection<ILocator>(new List<ILocator>());
                    }
                }
                return _locatorCollection;
            }
        }

        IList<IContentKey> IAsset.ContentKeys
        {
            get
            {
                if (_contentKeyCollection == null)
                {
                    if (_cloudMediaContext != null)
                    {
                        EntityDescriptor desc = _cloudMediaContext.DataContext.GetEntityDescriptor(this);
                        if (desc != null &&
                            (desc.State == EntityStates.Unchanged || desc.State == EntityStates.Modified))
                        {
                            _cloudMediaContext.DataContext.LoadProperty(this, "ContentKeys");
                        }

                        _contentKeyCollection =
                            new LinkCollection<IContentKey, ContentKeyData>(_cloudMediaContext.DataContext, this, "ContentKeys", ContentKeys);
                    }
                    else
                    {
                        _contentKeyCollection = new List<IContentKey>(ContentKeys).AsReadOnly();
                    }
                }

                return _contentKeyCollection;
            }
        }

        ReadOnlyCollection<IAsset> IAsset.ParentAssets
        {
            get
            {
                if (_parentAssetCollection == null)
                {
                    if (_cloudMediaContext != null)
                    {
                        EntityDescriptor desc = _cloudMediaContext.DataContext.GetEntityDescriptor(this);
                        if (desc != null && (desc.State == EntityStates.Unchanged || desc.State == EntityStates.Modified))
                        {
                            _cloudMediaContext.DataContext.LoadProperty(this, "ParentAssets");
                        }
                    }
                    _parentAssetCollection = ParentAssets.ToList<IAsset>().AsReadOnly();
                }
                return _parentAssetCollection;
            }
        }

        private static AssetState GetExposedState(int state)
        {
            return (AssetState)state;
        }

        private static AssetCreationOptions GetExposedOptions(int options)
        {
            return (AssetCreationOptions)options;
        }
    }
}
 
