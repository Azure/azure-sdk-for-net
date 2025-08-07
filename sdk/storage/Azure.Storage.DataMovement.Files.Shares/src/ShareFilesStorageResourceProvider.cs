// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
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
        private readonly Func<Uri, CancellationToken, ValueTask<StorageSharedKeyCredential>> _getStorageSharedKeyCredential;
        private readonly Func<Uri, CancellationToken, ValueTask<AzureSasCredential>> _getAzureSasCredential;

        #region ctors
        /// <summary>
        /// <para>
        /// Constructs this provider to use no credentials when making a new Share File Storage
        /// <see cref="StorageResource"/>.
        /// </para>
        /// <para>
        /// This instance will NOT use any credential when constructing the underlying
        /// Azure.Storage.Files.Shares client, e.g. <see cref="ShareFileClient(Uri, ShareClientOptions)"/>.
        /// This is for the purpose of either anonymous access when constructing the client.
        /// </para>
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
            _getStorageSharedKeyCredential = (_, _) => new ValueTask<StorageSharedKeyCredential>(credential);
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
            _getAzureSasCredential = (_, _) => new ValueTask<AzureSasCredential>(credential);
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
        public ShareFilesStorageResourceProvider(Func<Uri, CancellationToken, ValueTask<StorageSharedKeyCredential>> getStorageSharedKeyCredentialAsync)
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
        public ShareFilesStorageResourceProvider(Func<Uri, CancellationToken, ValueTask<AzureSasCredential>> getAzureSasCredentialAsync)
        {
            _credentialType = CredentialType.Sas;
            _getAzureSasCredential = getAzureSasCredentialAsync;
        }
        #endregion

        #region Abstract Class Implementation
        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override async ValueTask<StorageResource> FromSourceAsync(TransferProperties properties, CancellationToken cancellationToken)
        {
            ShareFileSourceCheckpointDetails checkpointDetails;
            using (MemoryStream stream = new(properties.SourceCheckpointDetails))
            {
                checkpointDetails = ShareFileSourceCheckpointDetails.Deserialize(stream);
            }

            ShareFileStorageResourceOptions options = new()
            {
                ShareProtocol = checkpointDetails.ShareProtocol
            };

            return properties.IsContainer
                ? await FromDirectoryAsync(properties.SourceUri, options).ConfigureAwait(false)
                : await FromFileAsync(properties.SourceUri, options).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override async ValueTask<StorageResource> FromDestinationAsync(TransferProperties properties, CancellationToken cancellationToken)
        {
            ShareFileDestinationCheckpointDetails checkpointDetails;
            using (MemoryStream stream = new(properties.DestinationCheckpointDetails))
            {
                checkpointDetails = ShareFileDestinationCheckpointDetails.Deserialize(stream);
            }

            ShareFileStorageResourceOptions options = new()
            {
                FileAttributes = checkpointDetails.FileAttributes,
                _isFileAttributesSet = checkpointDetails.IsFileAttributesSet,
                FilePermissions = checkpointDetails.FilePermission,
                CacheControl = checkpointDetails.CacheControl,
                _isCacheControlSet = checkpointDetails.IsCacheControlSet,
                ContentDisposition = checkpointDetails.ContentDisposition,
                _isContentDispositionSet = checkpointDetails.IsContentDispositionSet,
                ContentEncoding = checkpointDetails.ContentEncoding,
                _isContentEncodingSet = checkpointDetails.IsContentEncodingSet,
                ContentLanguage = checkpointDetails.ContentLanguage,
                _isContentLanguageSet = checkpointDetails.IsContentLanguageSet,
                ContentType = checkpointDetails.ContentType,
                _isContentTypeSet = checkpointDetails.IsContentTypeSet,
                FileCreatedOn = checkpointDetails.FileCreatedOn,
                _isFileCreatedOnSet = checkpointDetails.IsFileCreatedOnSet,
                FileLastWrittenOn = checkpointDetails.FileLastWrittenOn,
                _isFileLastWrittenOnSet = checkpointDetails.IsFileLastWrittenOnSet,
                FileChangedOn = checkpointDetails.FileChangedOn,
                _isFileChangedOnSet = checkpointDetails.IsFileChangedOnSet,
                DirectoryMetadata = checkpointDetails.DirectoryMetadata,
                _isDirectoryMetadataSet = checkpointDetails.IsDirectoryMetadataSet,
                FileMetadata = checkpointDetails.FileMetadata,
                _isFileMetadataSet = checkpointDetails.IsFileMetadataSet,
                ShareProtocol = checkpointDetails.ShareProtocol,
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
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// The configured storage resource.
        /// </returns>
        public async ValueTask<StorageResource> FromDirectoryAsync(
            Uri directoryUri,
            ShareFileStorageResourceOptions options = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            ShareClientOptions clientOptions = GetUserAgentClientOptions();

            ShareDirectoryClient CreateTokenClient()
            {
                clientOptions.ShareTokenIntent = ShareTokenIntent.Backup;
                return new ShareDirectoryClient(directoryUri, _tokenCredential, clientOptions);
            }

            ShareDirectoryClient client = _credentialType switch
            {
                CredentialType.None => new ShareDirectoryClient(directoryUri, clientOptions),
                CredentialType.SharedKey => new ShareDirectoryClient(directoryUri, await _getStorageSharedKeyCredential(directoryUri, cancellationToken).ConfigureAwait(false), clientOptions),
                CredentialType.Token => CreateTokenClient(),
            CredentialType.Sas => new ShareDirectoryClient(directoryUri, await _getAzureSasCredential(directoryUri, cancellationToken).ConfigureAwait(false), clientOptions),
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
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// The configured storage resource.
        /// </returns>
        public async ValueTask<StorageResource> FromFileAsync(
            Uri fileUri,
            ShareFileStorageResourceOptions options = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            ShareClientOptions clientOptions = GetUserAgentClientOptions();

            ShareFileClient CreateTokenClient()
            {
                clientOptions.ShareTokenIntent = ShareTokenIntent.Backup;
                return new ShareFileClient(fileUri, _tokenCredential, clientOptions);
            }

            ShareFileClient client = _credentialType switch
            {
                CredentialType.None => new ShareFileClient(fileUri, clientOptions),
                CredentialType.SharedKey => new ShareFileClient(fileUri, await _getStorageSharedKeyCredential(fileUri, cancellationToken).ConfigureAwait(false), clientOptions),
                CredentialType.Token => CreateTokenClient(),
                CredentialType.Sas => new ShareFileClient(fileUri, await _getAzureSasCredential(fileUri, cancellationToken).ConfigureAwait(false), clientOptions),
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
        public static StorageResource FromClient(
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
        public static StorageResource FromClient(
            ShareFileClient client,
            ShareFileStorageResourceOptions options = default)
        {
            return new ShareFileStorageResource(client, options);
        }
        #endregion

        private static ArgumentException BadCredentialTypeException(CredentialType credentialType)
            => new ArgumentException(
                $"No support for credential type {Enum.GetName(typeof(CredentialType), credentialType)}.");

        private static ShareClientOptions GetUserAgentClientOptions()
        {
            ShareClientOptions options = new ShareClientOptions();

            // We grab the assembly of ShareFilesStorageResourceProvider which is Azure.Storage.DataMovement.Files.Shares.
            // From there we can grab the version of the Assembly.
            Assembly assembly = typeof(ShareFilesStorageResourceProvider).Assembly;
            AssemblyInformationalVersionAttribute versionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            if (versionAttribute == null)
            {
                throw Azure.Storage.Errors.RequiredVersionClientAssembly(assembly, versionAttribute);
            }
            // Now using a policy, update the user agent string with the version and add the policy
            // to the client options.
            DataMovementUserAgentPolicy policy = new(versionAttribute.InformationalVersion);
            options.AddPolicy(policy, HttpPipelinePosition.PerCall);
            return options;
        }
    }
}
