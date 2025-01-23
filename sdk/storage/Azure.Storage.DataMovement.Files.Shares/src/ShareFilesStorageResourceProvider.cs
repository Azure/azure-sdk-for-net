// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace Azure.Storage.DataMovement.Files.Shares
{
    /// <summary>
    /// Provider for a <see cref="StorageResource"/> configured for an Azure File Share Storage resource.
    /// </summary>
    public class ShareFilesStorageResourceProvider : StorageResourceProvider
    {
        private enum ResourceType
        {
            Unknown = 0,
            Share = 1,
            Directory = 2,
            File = 3,
        }

        private enum CredentialType
        {
            None = 0,
            SharedKey = 1,
            Token = 2,
            Sas = 4
        }

        /// <inheritdoc/>
        protected override string ProviderId => "share";

        private readonly CredentialType _credentialType;
        private readonly TokenCredential _tokenCredential;
        private readonly Func<Uri, ValueTask<StorageSharedKeyCredential>> _getStorageSharedKeyCredential;
        private readonly Func<Uri, ValueTask<AzureSasCredential>> _getAzureSasCredential;

        #region ctors
        /// <summary>
        /// Default constrctor.
        /// </summary>
        public ShareFilesStorageResourceProvider()
        {
            _credentialType = CredentialType.None;
        }

        /// <summary>
        /// <para>
        /// Constructs this provider to use the given credential when making a new File Share
        /// <see cref="StorageResource"/>.
        /// </para>
        /// <para>
        /// This instance will use the given <see cref="StorageSharedKeyCredential"/> when constructing the underlying
        /// Azure.Storage.Files.Shares client, e.g. <see cref="ShareFileClient(Uri, StorageSharedKeyCredential, ShareClientOptions)"/>.
        /// The credential will only be used when the provider needs to construct a client in the first place. It will
        /// not be used when creating a <see cref="StorageResource"/> from a pre-existing client, e.g.
        /// <see cref="FromClient(ShareFileClient, ShareFileStorageResourceOptions)"/>.
        /// </para>
        /// </summary>
        /// <param name="credential">
        /// Shared key credential to use when constructing resources.
        /// </param>
        public ShareFilesStorageResourceProvider(StorageSharedKeyCredential credential)
        {
            _credentialType = CredentialType.SharedKey;
            _getStorageSharedKeyCredential = (_) => new ValueTask<StorageSharedKeyCredential>(credential);
        }

        /// <summary>
        /// <para>
        /// Constructs this provider to use the given credential when making a new File Share
        /// <see cref="StorageResource"/>.
        /// </para>
        /// <para>
        /// This instance will use the given <see cref="TokenCredential"/> when constructing the underlying
        /// Azure.Storage.Files.Shares client, e.g. <see cref="ShareFileClient(Uri, TokenCredential, ShareClientOptions)"/>.
        /// The credential will only be used when the provider needs to construct a client in the first place. It will
        /// not be used when creating a <see cref="StorageResource"/> from a pre-existing client, e.g.
        /// <see cref="FromClient(ShareFileClient, ShareFileStorageResourceOptions)"/>.
        /// </para>
        /// </summary>
        /// <param name="credential">
        /// Token credential to use when constructing resources.
        /// </param>
        public ShareFilesStorageResourceProvider(TokenCredential credential)
        {
            _credentialType = CredentialType.Token;
            _tokenCredential = credential;
        }

        /// <summary>
        /// <para>
        /// Constructs this provider to use the given credential when making a new File Share
        /// <see cref="StorageResource"/>.
        /// </para>
        /// <para>
        /// This instance will use the given <see cref="AzureSasCredential"/> when constructing the underlying
        /// Azure.Storage.Files.Shares client, e.g. <see cref="ShareFileClient(Uri, AzureSasCredential, ShareClientOptions)"/>.
        /// The credential will only be used when the provider needs to construct a client in the first place. It will
        /// not be used when creating a <see cref="StorageResource"/> from a pre-existing client, e.g.
        /// <see cref="FromClient(ShareFileClient, ShareFileStorageResourceOptions)"/>.
        /// Additionally, if the given target share resource already has a SAS token in the URI, that token will be
        /// preferred over this credential.
        /// </para>
        /// </summary>
        /// <param name="credential">
        /// SAS credential to use when constructing resources.
        /// </param>
        public ShareFilesStorageResourceProvider(AzureSasCredential credential)
        {
            _credentialType = CredentialType.Sas;
            _getAzureSasCredential = (_) => new ValueTask<AzureSasCredential>(credential);
        }

        /// <summary>
        /// <para>
        /// Constructs this provider to use the given delegate for acquiring a credential when making a new File Share
        /// see cref="StorageResource"/>.
        /// </para>
        /// <para>
        /// This instance will use the given callback to fetch a credential
        /// when constructing the underlying Azure.Storage.Files.Shares client, e.g.
        /// <see cref="ShareFileClient(Uri, StorageSharedKeyCredential, ShareClientOptions)"/>.
        /// The delegate will only be used when the provider needs to construct a client in the first place. It will
        /// not be used when creating a <see cref="StorageResource"/> from a pre-existing client, e.g.
        /// <see cref="FromClient(ShareFileClient, ShareFileStorageResourceOptions)"/>.
        /// </para>
        /// </summary>
        /// <param name="getStorageSharedKeyCredentialAsync">
        /// Callback for acquiring a credential for the given Uri.
        /// </param>
        public ShareFilesStorageResourceProvider(Func<Uri, ValueTask<StorageSharedKeyCredential>> getStorageSharedKeyCredentialAsync)
        {
            _credentialType = CredentialType.SharedKey;
            _getStorageSharedKeyCredential = getStorageSharedKeyCredentialAsync;
        }

        /// <summary>
        /// <para>
        /// Constructs this provider to use the given delegate for acquiring a credential when making a new File Share
        /// <see cref="StorageResource"/>.
        /// </para>
        /// <para>
        /// This instance will use the given callback to fetch a credential
        /// when constructing the underlying Azure.Storage.Files.Shares client, e.g.
        /// <see cref="ShareFileClient(Uri, AzureSasCredential, ShareClientOptions)"/>.
        /// The delegate will only be used when the provider needs to construct a client in the first place. It will
        /// not be used when creating a <see cref="StorageResource"/> from a pre-existing client, e.g.
        /// <see cref="FromClient(ShareFileClient, ShareFileStorageResourceOptions)"/>.
        /// Additionally, if the given target share resource already has a SAS token in the URI, that token will be
        /// preferred over this delegate.
        /// </para>
        /// </summary>
        /// <param name="getAzureSasCredentialAsync">
        /// Callback for acquiring a credential for the given Uri.
        /// </param>
        public ShareFilesStorageResourceProvider(Func<Uri, ValueTask<AzureSasCredential>> getAzureSasCredentialAsync)
        {
            _credentialType = CredentialType.Sas;
            _getAzureSasCredential = getAzureSasCredentialAsync;
        }
        #endregion

        #region Abstract Class Implementation
        /// <inheritdoc/>
        protected override async Task<StorageResource> FromSourceAsync(TransferProperties properties, CancellationToken cancellationToken)
        {
            // Source share file data currently empty, so no specific properties to grab
            return properties.IsContainer
                ? await FromDirectoryAsync(properties.SourceUri).ConfigureAwait(false)
                : await FromFileAsync(properties.SourceUri).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        protected override async Task<StorageResource> FromDestinationAsync(TransferProperties properties, CancellationToken cancellationToken)
        {
            ShareFileDestinationCheckpointDetails checkpointDetails;
            using (MemoryStream stream = new(properties.DestinationCheckpointDetails))
            {
                checkpointDetails = ShareFileDestinationCheckpointDetails.Deserialize(stream);
            }

            ShareFileStorageResourceOptions options = new()
            {
                FileAttributes = checkpointDetails.FileAttributes,
                FilePermissions = new(checkpointDetails.PreserveFilePermission),
                CacheControl = checkpointDetails.CacheControl,
                ContentDisposition = checkpointDetails.ContentDisposition,
                ContentEncoding = checkpointDetails.ContentEncoding,
                ContentLanguage = checkpointDetails.ContentLanguage,
                ContentType = checkpointDetails.ContentType,
                FileCreatedOn = checkpointDetails.FileCreatedOn,
                FileLastWrittenOn = checkpointDetails.FileLastWrittenOn,
                FileChangedOn = checkpointDetails.FileChangedOn,
                DirectoryMetadata = checkpointDetails.DirectoryMetadata,
                FileMetadata = checkpointDetails.FileMetadata,
            };
            return properties.IsContainer
                ? await FromDirectoryAsync(properties.DestinationUri, options).ConfigureAwait(false)
                : await FromFileAsync(properties.DestinationUri, options).ConfigureAwait(false);
        }

        /// <summary>
        /// For use in testing. Internal wrapper for protected member
        /// <see cref="StorageResourceProvider.FromSourceAsync(TransferProperties, CancellationToken)"/>.
        /// </summary>
        internal async Task<StorageResource> FromSourceInternalHookAsync(
            TransferProperties props,
            CancellationToken cancellationToken = default)
            => await FromSourceAsync(props, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// For use in testing. Internal wrapper for protected member
        /// <see cref="StorageResourceProvider.FromDestinationAsync(TransferProperties, CancellationToken)"/>.
        /// </summary>
        internal async Task<StorageResource> FromDestinationInternalHookAsync(
            TransferProperties props,
            CancellationToken cancellationToken = default)
            => await FromDestinationAsync(props, cancellationToken).ConfigureAwait(false);
        #endregion

        #region From Uri
        /// <summary>
        /// Creates a storage resource pointing towards the given container URI.
        /// </summary>
        /// <param name="directoryUri">
        /// Target location.
        /// </param>
        /// <param name="options">
        /// Options for creating the storage resource.
        /// </param>
        /// <returns>
        /// The configured storage resource.
        /// </returns>
        public async ValueTask<StorageResource> FromDirectoryAsync(Uri directoryUri, ShareFileStorageResourceOptions options = default)
        {
            ShareDirectoryClient client = _credentialType switch
            {
                CredentialType.None => new ShareDirectoryClient(directoryUri),
                CredentialType.SharedKey => new ShareDirectoryClient(directoryUri, await _getStorageSharedKeyCredential(directoryUri).ConfigureAwait(false)),
                CredentialType.Token => new ShareDirectoryClient(
                    directoryUri,
                    _tokenCredential,
                    new ShareClientOptions { ShareTokenIntent = ShareTokenIntent.Backup }),
                CredentialType.Sas => new ShareDirectoryClient(directoryUri, await _getAzureSasCredential(directoryUri).ConfigureAwait(false)),
                _ => throw BadCredentialTypeException(_credentialType),
            };
            return new ShareDirectoryStorageResourceContainer(client, options);
        }

        /// <summary>
        /// Creates a storage resource pointing towards the given container URI.
        /// </summary>
        /// <param name="fileUri">
        /// Target location.
        /// </param>
        /// <param name="options">
        /// Options for creating the storage resource.
        /// </param>
        /// <returns>
        /// The configured storage resource.
        /// </returns>
        public async ValueTask<StorageResource> FromFileAsync(Uri fileUri, ShareFileStorageResourceOptions options = default)
        {
            ShareFileClient client = _credentialType switch
            {
                CredentialType.None => new ShareFileClient(fileUri),
                CredentialType.SharedKey => new ShareFileClient(fileUri, await _getStorageSharedKeyCredential(fileUri).ConfigureAwait(false)),
                CredentialType.Token => new ShareFileClient(
                    fileUri,
                    _tokenCredential,
                    new ShareClientOptions { ShareTokenIntent = ShareTokenIntent.Backup }),
                CredentialType.Sas => new ShareFileClient(fileUri, await _getAzureSasCredential(fileUri).ConfigureAwait(false)),
                _ => throw BadCredentialTypeException(_credentialType),
            };
            return new ShareFileStorageResource(client, options);
        }
        #endregion

        #region From Client
        /// <summary>
        /// Creates a storage resource pointing towards the given Azure SDK client.
        /// </summary>
        /// <param name="client">
        /// Target resource presented within an Azure SDK client.
        /// Note: It is NOT guaranteed that properties set within the client's <see cref="ShareClientOptions"/>
        /// will be respected when resuming a transfer.
        /// </param>
        /// <param name="options">
        /// Options for creating the storage resource.
        /// </param>
        /// <returns>
        /// The configured storage resource.
        /// </returns>
        public StorageResource FromClient(
            ShareDirectoryClient client,
            ShareFileStorageResourceOptions options = default)
        {
            return new ShareDirectoryStorageResourceContainer(client, options);
        }

        /// <summary>
        /// Creates a storage resource pointing towards the given Azure SDK client.
        /// </summary>
        /// <param name="client">
        /// Target resource presented within an Azure SDK client.
        /// Note: It is NOT guaranteed that properties set within the client's <see cref="ShareClientOptions"/>
        /// will be respected when resuming a transfer.
        /// </param>
        /// <param name="options">
        /// Options for creating the storage resource.
        /// </param>
        /// <returns>
        /// The configured storage resource.
        /// </returns>
        public StorageResource FromClient(
            ShareFileClient client,
            ShareFileStorageResourceOptions options = default)
        {
            return new ShareFileStorageResource(client, options);
        }
        #endregion

        private static ArgumentException BadCredentialTypeException(CredentialType credentialType)
            => new ArgumentException(
                $"No support for credential type {Enum.GetName(typeof(CredentialType), credentialType)}.");
    }
}
