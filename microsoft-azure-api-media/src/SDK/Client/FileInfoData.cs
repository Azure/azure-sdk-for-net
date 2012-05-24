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
using System.ComponentModel;
using System.Data.Services.Common;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.StorageClient;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    [DataServiceKey("Id")]
    internal partial class FileInfoData : IFileInfo, ICloudMediaContextInit
    {
        private IAsset _asset;
        private CloudMediaContext _cloudMediaContext;

        private IAsset Asset
        {
            get
            {
                if (_asset == null)
                {
                    _asset = _cloudMediaContext.Assets.Where(c => c.Id == ParentAssetId).Single();
                }
                return _asset;
            }
        }

        #region ICloudMediaContextInit Members

        public void InitCloudMediaContext(CloudMediaContext context)
        {
            _cloudMediaContext = context;
        }

        #endregion

        #region IFileInfo Members

        IAsset IFileInfo.Asset
        {
            get { return Asset; }
        }

        public Task DownloadToFileAsync(string file,RetryPolicy retryPolicy,CancellationToken cancellationToken)
        {
            FileEncryption fileEncryption = GetFileEncryption();
            IAccessPolicy policy = _cloudMediaContext.AccessPolicies.Create("SdkDownload", TimeSpan.FromHours(12),
                                                                            AccessPermissions.Read);
            ulong iv = Convert.ToUInt64(InitializationVector, CultureInfo.InvariantCulture);

            ILocator locator = _cloudMediaContext.Locators.CreateSasLocator(Asset, policy);

            var uriBuilder = new UriBuilder(locator.Path);
            uriBuilder.Path += "/" + Name;
            Uri fullUrl = uriBuilder.Uri;

            var blobTransfer = new BlobTransferClient
            {
                NumberOfConcurrentTransfers = _cloudMediaContext.NumberOfConcurrentTransfers,
                ParallelTransferThreadCount = _cloudMediaContext.ParallelTransferThreadCount
            };

            blobTransfer.TransferProgressChanged += BlobTransferTransferProgressChanged;
            return blobTransfer
                .DownloadBlob(fullUrl, file, fileEncryption, iv, cancellationToken, retryPolicy)
                .ContinueWith(
                    t =>
                    {
                        blobTransfer.TransferProgressChanged -= BlobTransferTransferProgressChanged;


                        _cloudMediaContext.Locators.Revoke(locator);
                        _cloudMediaContext.AccessPolicies.Delete(policy);
                        if (fileEncryption != null)
                        {
                            fileEncryption.Dispose();
                        }
                    },
                    cancellationToken);
        }

        public Task DownloadToFileAsync(string file, CancellationToken cancellationToken)
        {
            return DownloadToFileAsync(file, RetryPolicies.RetryExponential(RetryPolicies.DefaultClientRetryCount,RetryPolicies.DefaultClientBackoff), cancellationToken);
        }

        public void DownloadToFile(string file)
        {
            DownloadToFileAsync(file,CancellationToken.None).Wait();
        }

        public event EventHandler<DownloadProgressEventArgs> OnDownloadProgress;
        public void Save()
        {
            if (Asset.State != AssetState.Initialized)
            {
                throw new NotSupportedException(StringTable.NotSupportedFileInfoSave);
            }
            _cloudMediaContext.DataContext.UpdateObject(this);
            _cloudMediaContext.DataContext.SaveChanges();
        }

        #endregion

        private FileEncryption GetFileEncryption()
        {
            if (!IsEncrypted)
            {
                return null;
            }

            // We want to support downloading PlayReady encrypted content too.
            if (EncryptionScheme != FileEncryption.SchemeName)
            {
                return null;
            }

            IContentKey key =
                Asset.ContentKeys.Where(c => c.ContentKeyType == ContentKeyType.StorageEncryption).FirstOrDefault();

            Guid keyId = EncryptionUtils.GetKeyIdAsGuid(key.Id);

            return new FileEncryption(key.GetClearKeyValue(), keyId);
        }

        private void BlobTransferTransferProgressChanged(object sender,
                                                          BlobTransferProgressChangedEventArgs e)
        {
            if (OnDownloadProgress != null)
            {
                OnDownloadProgress(this, new DownloadProgressEventArgs(e.BytesSent, e.TotalBytesToSend));
            }
        }
       
    }
}
