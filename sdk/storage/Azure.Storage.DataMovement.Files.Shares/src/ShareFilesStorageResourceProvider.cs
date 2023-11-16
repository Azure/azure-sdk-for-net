﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Files.Shares;

namespace Azure.Storage.DataMovement.Files.Shares
{
    /// <summary>
    /// Provider for a <see cref="StorageResource"/> configured for an Azure File Share Storage resource.
    /// </summary>
    public class ShareFilesStorageResourceProvider : StorageResourceProvider
    {
        /// <summary>
        /// Delegate for fetching a shared key credential for a given URI.
        /// </summary>
        /// <param name="uri">
        /// URI of resource to fetch credential for.
        /// </param>
        /// <param name="readOnly">
        /// Whether the permission can be read-only.
        /// </param>
        public delegate StorageSharedKeyCredential GetStorageSharedKeyCredential(string uri, bool readOnly);

        /// <summary>
        /// Delegate for fetching a token credential for a given URI.
        /// </summary>
        /// <param name="uri">
        /// URI of resource to fetch credential for.
        /// </param>
        /// <param name="readOnly">
        /// Whether the permission can be read-only.
        /// </param>
        public delegate TokenCredential GetTokenCredential(string uri, bool readOnly);

        /// <summary>
        /// Delegate for fetching a SAS credential for a given URI.
        /// </summary>
        /// <param name="uri">
        /// URI of resource to fetch credential for.
        /// </param>
        /// <param name="readOnly">
        /// Whether the permission can be read-only.
        /// </param>
        public delegate AzureSasCredential GetAzureSasCredential(string uri, bool readOnly);

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
        private readonly GetStorageSharedKeyCredential _getStorageSharedKeyCredential;
        private readonly GetTokenCredential _getTokenCredential;
        private readonly GetAzureSasCredential _getAzureSasCredential;

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
            _getStorageSharedKeyCredential = (_, _) => credential;
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
            _getTokenCredential = (_, _) => credential;
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
            _getAzureSasCredential = (_, _) => credential;
        }

        /// <summary>
        /// <para>
        /// Constructs this provider to use the given delegate for acquiring a credential when making a new File Share
        /// see cref="StorageResource"/>.
        /// </para>
        /// <para>
        /// This instance will use the given <see cref="GetStorageSharedKeyCredential"/> to fetch a credential
        /// when constructing the underlying Azure.Storage.Files.Shares client, e.g.
        /// <see cref="ShareFileClient(Uri, StorageSharedKeyCredential, ShareClientOptions)"/>.
        /// The delegate will only be used when the provider needs to construct a client in the first place. It will
        /// not be used when creating a <see cref="StorageResource"/> from a pre-existing client, e.g.
        /// <see cref="FromClient(ShareFileClient, ShareFileStorageResourceOptions)"/>.
        /// </para>
        /// </summary>
        /// <param name="getStorageSharedKeyCredentialAsync">
        /// Delegate for acquiring a credential.
        /// </param>
        public ShareFilesStorageResourceProvider(GetStorageSharedKeyCredential getStorageSharedKeyCredentialAsync)
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
        /// This instance will use the given <see cref="GetTokenCredential"/> to fetch a credential
        /// when constructing the underlying Azure.Storage.Files.Shares client, e.g.
        /// <see cref="ShareFileClient(Uri, TokenCredential, ShareClientOptions)"/>.
        /// The delegate will only be used when the provider needs to construct a client in the first place. It will
        /// not be used when creating a <see cref="StorageResource"/> from a pre-existing client, e.g.
        /// <see cref="FromClient(ShareFileClient, ShareFileStorageResourceOptions)"/>.
        /// </para>
        /// </summary>
        /// <param name="getTokenCredentialAsync">
        /// Delegate for acquiring a credential.
        /// </param>
        public ShareFilesStorageResourceProvider(GetTokenCredential getTokenCredentialAsync)
        {
            _credentialType = CredentialType.SharedKey;
            _getTokenCredential = getTokenCredentialAsync;
        }

        /// <summary>
        /// <para>
        /// Constructs this provider to use the given delegate for acquiring a credential when making a new File Share
        /// <see cref="StorageResource"/>.
        /// </para>
        /// <para>
        /// This instance will use the given <see cref="GetAzureSasCredential"/> to fetch a credential
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
        /// Delegate for acquiring a credential.
        /// </param>
        public ShareFilesStorageResourceProvider(GetAzureSasCredential getAzureSasCredentialAsync)
        {
            _credentialType = CredentialType.SharedKey;
            _getAzureSasCredential = getAzureSasCredentialAsync;
        }
        #endregion

        #region Abstract Class Implementation
        /// <inheritdoc/>
        protected override Task<StorageResource> FromSourceAsync(DataTransferProperties properties, CancellationToken cancellationToken)
        {
            // Source share file data currently empty, so no specific properties to grab

            return Task.FromResult(properties.IsContainer
                ? FromDirectory(properties.SourceUri.AbsoluteUri)
                : FromFile(properties.SourceUri.AbsoluteUri));
        }

        /// <inheritdoc/>
        protected override Task<StorageResource> FromDestinationAsync(DataTransferProperties properties, CancellationToken cancellationToken)
        {
            ShareFileDestinationCheckpointData checkpointData;
            using (MemoryStream stream = new(properties.DestinationCheckpointData))
            {
                checkpointData = ShareFileDestinationCheckpointData.Deserialize(stream);
            }

            ShareFileStorageResourceOptions options = new()
            {
                SmbProperties = checkpointData.SmbProperties,
                HttpHeaders = checkpointData.ContentHeaders,
                DirectoryMetadata = checkpointData.DirectoryMetadata,
                FileMetadata = checkpointData.FileMetadata,
            };

            return Task.FromResult(properties.IsContainer
                ? FromDirectory(properties.DestinationUri.AbsoluteUri, options)
                : FromFile(properties.DestinationUri.AbsoluteUri, options));
        }

        /// <summary>
        /// For use in testing. Internal wrapper for protected member
        /// <see cref="StorageResourceProvider.FromSourceAsync(DataTransferProperties, CancellationToken)"/>.
        /// </summary>
        internal async Task<StorageResource> FromSourceInternalHookAsync(
            DataTransferProperties props,
            CancellationToken cancellationToken = default)
            => await FromSourceAsync(props, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// For use in testing. Internal wrapper for protected member
        /// <see cref="StorageResourceProvider.FromDestinationAsync(DataTransferProperties, CancellationToken)"/>.
        /// </summary>
        internal async Task<StorageResource> FromDestinationInternalHookAsync(
            DataTransferProperties props,
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
        public StorageResource FromDirectory(string directoryUri, ShareFileStorageResourceOptions options = default)
        {
            ShareDirectoryClient client = _credentialType switch
            {
                CredentialType.None => new ShareDirectoryClient(new Uri(directoryUri)),
                CredentialType.SharedKey => new ShareDirectoryClient(new Uri(directoryUri), _getStorageSharedKeyCredential(directoryUri, false)),
                CredentialType.Token => new ShareDirectoryClient(new Uri(directoryUri), _getTokenCredential(directoryUri, false)),
                CredentialType.Sas => new ShareDirectoryClient(new Uri(directoryUri), _getAzureSasCredential(directoryUri, false)),
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
        public StorageResource FromFile(string fileUri, ShareFileStorageResourceOptions options = default)
        {
            ShareFileClient client = _credentialType switch
            {
                CredentialType.None => new ShareFileClient(new Uri(fileUri)),
                CredentialType.SharedKey => new ShareFileClient(new Uri(fileUri), _getStorageSharedKeyCredential(fileUri, false)),
                CredentialType.Token => new ShareFileClient(new Uri(fileUri), _getTokenCredential(fileUri, false)),
                CredentialType.Sas => new ShareFileClient(new Uri(fileUri), _getAzureSasCredential(fileUri, false)),
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

        private static ArgumentException BadResourceTypeException(ResourceType resourceType)
            => new ArgumentException(
                $"No support for resource type {Enum.GetName(typeof(ResourceType), resourceType)}.");

        private static ArgumentException BadCredentialTypeException(CredentialType credentialType)
            => new ArgumentException(
                $"No support for credential type {Enum.GetName(typeof(CredentialType), credentialType)}.");
    }
}
