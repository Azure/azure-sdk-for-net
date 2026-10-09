// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Containers.Apps.Sandbox.Models;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Containers.Apps.Sandbox
{
    [CodeGenSuppress("GetSandboxesClient")]
    [CodeGenSuppress("GetContentPackagesClient")]
    [CodeGenSuppress("GetVolumesClient")]
    [CodeGenSuppress("GetConnectionsClient")]
    [CodeGenSuppress("GetCredentialsClient")]
    [CodeGenSuppress("GetDiskImagesClient")]
    [CodeGenSuppress("GetPublicDiskImagesClient")]
    [CodeGenSuppress("GetEgressPoliciesClient")]
    [CodeGenSuppress("GetSecretsClient")]
    [CodeGenSuppress("GetSnapshotsClient")]
    public partial class SandboxGroupClient
    {
        /// <summary> The subscription identifier of this sandbox group. </summary>
        public virtual string SubscriptionId => _subscriptionId;

        /// <summary> The resource group name of this sandbox group. </summary>
        public virtual string ResourceGroupName => _resourceGroupName;

        /// <summary> The name of this sandbox group. </summary>
        public virtual string Name => _sandboxGroupName;

        /// <summary> The Azure Resource Manager identifier of this sandbox group. </summary>
        public virtual ResourceIdentifier Id => new ResourceIdentifier($"/subscriptions/{_subscriptionId}/resourceGroups/{_resourceGroupName}/providers/Microsoft.App/sandboxGroups/{_sandboxGroupName}");

        /// <summary> Gets a client for a sandbox in this group. </summary>
        /// <param name="id"> The identifier of the sandbox. </param>
        /// <returns> A client scoped to the sandbox. </returns>
        public virtual SandboxClient GetSandbox(string id)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            return new SandboxClient(GetSandboxesClient(), id);
        }

        /// <summary> Gets a client for a connection in this group. </summary>
        /// <param name="id"> The identifier of the connection. </param>
        /// <returns> A client scoped to the connection. </returns>
        public virtual ConnectionClient GetConnection(string id)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            return new ConnectionClient(GetConnectionsClient(), id);
        }

        /// <summary> Gets a client for a content package in this group. </summary>
        /// <param name="id"> The identifier of the content package. </param>
        /// <returns> A client scoped to the content package. </returns>
        public virtual ContentPackageClient GetContentPackage(string id)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            return new ContentPackageClient(GetContentPackagesClient(), id);
        }

        /// <summary> Gets a client for a credential in this group. </summary>
        /// <param name="credentialName"> The name of the credential. </param>
        /// <returns> A client scoped to the credential. </returns>
        public virtual CredentialClient GetCredential(string credentialName)
        {
            Argument.AssertNotNullOrEmpty(credentialName, nameof(credentialName));
            return new CredentialClient(GetCredentialsClient(), credentialName);
        }

        /// <summary> Gets a client for a disk image in this group. </summary>
        /// <param name="id"> The identifier of the disk image. </param>
        /// <returns> A client scoped to the disk image. </returns>
        public virtual DiskImageClient GetDiskImage(string id)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            return new DiskImageClient(GetDiskImagesClient(), id);
        }

        /// <summary> Gets a client for a public disk image. </summary>
        /// <param name="name"> The name of the public disk image. </param>
        /// <returns> A client scoped to the public disk image. </returns>
        public virtual PublicDiskImageClient GetPublicDiskImage(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            return new PublicDiskImageClient(GetPublicDiskImagesClient(), name);
        }

        /// <summary> Gets a client for an egress policy in this group. </summary>
        /// <param name="policyId"> The identifier of the egress policy. </param>
        /// <returns> A client scoped to the egress policy. </returns>
        public virtual EgressPolicyClient GetEgressPolicy(string policyId)
        {
            Argument.AssertNotNullOrEmpty(policyId, nameof(policyId));
            return new EgressPolicyClient(GetEgressPoliciesClient(), policyId);
        }

        /// <summary> Gets a client for a secret in this group. </summary>
        /// <param name="secretId"> The identifier of the secret. </param>
        /// <returns> A client scoped to the secret. </returns>
        public virtual SandboxSecretClient GetSecret(string secretId)
        {
            Argument.AssertNotNullOrEmpty(secretId, nameof(secretId));
            return new SandboxSecretClient(GetSecretsClient(), secretId);
        }

        /// <summary> Gets a client for a snapshot in this group. </summary>
        /// <param name="id"> The identifier of the snapshot. </param>
        /// <returns> A client scoped to the snapshot. </returns>
        public virtual SnapshotClient GetSnapshot(string id)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            return new SnapshotClient(GetSnapshotsClient(), id);
        }

        /// <summary> Gets a client for a volume in this group. </summary>
        /// <param name="volumeName"> The name of the volume. </param>
        /// <returns> A client scoped to the volume. </returns>
        public virtual VolumeClient GetVolume(string volumeName)
        {
            Argument.AssertNotNullOrEmpty(volumeName, nameof(volumeName));
            return new VolumeClient(GetVolumesClient(), volumeName);
        }

        /// <summary> Lists sandboxes as scoped clients. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="labels"> Comma-separated label selector. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual Pageable<SandboxClient> GetSandboxes(string skipToken = default, string labels = default, CancellationToken cancellationToken = default)
        {
            return new ResourcePageable<SandboxProperties, SandboxClient>(
                GetSandboxesClient().GetSandboxes(skipToken, labels, cancellationToken),
                model => new SandboxClient(GetSandboxesClient(), model.Id, model));
        }

        /// <summary> Lists sandboxes as scoped clients asynchronously. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="labels"> Comma-separated label selector. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual AsyncPageable<SandboxClient> GetSandboxesAsync(string skipToken = default, string labels = default, CancellationToken cancellationToken = default)
        {
            return new ResourceAsyncPageable<SandboxProperties, SandboxClient>(
                GetSandboxesClient().GetSandboxesAsync(skipToken, labels, cancellationToken),
                model => new SandboxClient(GetSandboxesClient(), model.Id, model));
        }

        /// <summary> Gets the total number of sandboxes in this group. </summary>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<int> GetSandboxCount(CancellationToken cancellationToken = default)
        {
            Response<SandboxCountResult> response = GetSandboxesClient().GetSandboxCount(cancellationToken);
            return Response.FromValue(response.Value.Count, response.GetRawResponse());
        }

        /// <summary> Gets the total number of sandboxes in this group asynchronously. </summary>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<int>> GetSandboxCountAsync(CancellationToken cancellationToken = default)
        {
            Response<SandboxCountResult> response = await GetSandboxesClient().GetSandboxCountAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value.Count, response.GetRawResponse());
        }

        /// <summary> Lists connections as scoped clients. </summary>
        /// <param name="includeSandboxIds"> Whether to include sandbox identifiers using each connection. </param>
        /// <param name="labels"> Comma-separated key=value labels that all resources must match. </param>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual Pageable<ConnectionClient> GetConnections(bool? includeSandboxIds = default, string labels = default, string skipToken = default, CancellationToken cancellationToken = default)
        {
            return new ResourcePageable<SandboxConnection, ConnectionClient>(
                GetConnectionsClient().GetConnections(includeSandboxIds, labels, skipToken, cancellationToken),
                model => new ConnectionClient(GetConnectionsClient(), model.Id, model));
        }

        /// <summary> Lists connections as scoped clients asynchronously. </summary>
        /// <param name="includeSandboxIds"> Whether to include sandbox identifiers using each connection. </param>
        /// <param name="labels"> Comma-separated key=value labels that all resources must match. </param>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual AsyncPageable<ConnectionClient> GetConnectionsAsync(bool? includeSandboxIds = default, string labels = default, string skipToken = default, CancellationToken cancellationToken = default)
        {
            return new ResourceAsyncPageable<SandboxConnection, ConnectionClient>(
                GetConnectionsClient().GetConnectionsAsync(includeSandboxIds, labels, skipToken, cancellationToken),
                model => new ConnectionClient(GetConnectionsClient(), model.Id, model));
        }

        /// <summary> Lists content packages as scoped clients. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="labels"> Comma-separated label selector. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual Pageable<ContentPackageClient> GetContentPackages(string skipToken = default, string labels = default, CancellationToken cancellationToken = default)
        {
            return new ResourcePageable<ContentPackage, ContentPackageClient>(
                GetContentPackagesClient().GetContentPackages(skipToken, labels, cancellationToken),
                model => new ContentPackageClient(GetContentPackagesClient(), model.Id, model));
        }

        /// <summary> Lists content packages as scoped clients asynchronously. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="labels"> Comma-separated label selector. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual AsyncPageable<ContentPackageClient> GetContentPackagesAsync(string skipToken = default, string labels = default, CancellationToken cancellationToken = default)
        {
            return new ResourceAsyncPageable<ContentPackage, ContentPackageClient>(
                GetContentPackagesClient().GetContentPackagesAsync(skipToken, labels, cancellationToken),
                model => new ContentPackageClient(GetContentPackagesClient(), model.Id, model));
        }

        /// <summary> Lists credentials as scoped clients. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual Pageable<CredentialClient> GetCredentials(string skipToken = default, CancellationToken cancellationToken = default)
        {
            return new ResourcePageable<SandboxGroupCredential, CredentialClient>(
                GetCredentialsClient().GetCredentials(skipToken, cancellationToken),
                model => new CredentialClient(GetCredentialsClient(), model.Name, model));
        }

        /// <summary> Lists credentials as scoped clients asynchronously. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual AsyncPageable<CredentialClient> GetCredentialsAsync(string skipToken = default, CancellationToken cancellationToken = default)
        {
            return new ResourceAsyncPageable<SandboxGroupCredential, CredentialClient>(
                GetCredentialsClient().GetCredentialsAsync(skipToken, cancellationToken),
                model => new CredentialClient(GetCredentialsClient(), model.Name, model));
        }

        /// <summary> Lists disk images as scoped clients. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="labels"> Comma-separated label selector. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual Pageable<DiskImageClient> GetDiskImages(string skipToken = default, string labels = default, CancellationToken cancellationToken = default)
        {
            return new ResourcePageable<DiskImage, DiskImageClient>(
                GetDiskImagesClient().GetDiskImages(skipToken, labels, cancellationToken),
                model => new DiskImageClient(GetDiskImagesClient(), model.Id, model));
        }

        /// <summary> Lists disk images as scoped clients asynchronously. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="labels"> Comma-separated label selector. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual AsyncPageable<DiskImageClient> GetDiskImagesAsync(string skipToken = default, string labels = default, CancellationToken cancellationToken = default)
        {
            return new ResourceAsyncPageable<DiskImage, DiskImageClient>(
                GetDiskImagesClient().GetDiskImagesAsync(skipToken, labels, cancellationToken),
                model => new DiskImageClient(GetDiskImagesClient(), model.Id, model));
        }

        /// <summary> Lists public disk images as scoped clients. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual Pageable<PublicDiskImageClient> GetPublicDiskImages(string skipToken = default, CancellationToken cancellationToken = default)
        {
            return new ResourcePageable<PublicDiskImage, PublicDiskImageClient>(
                GetPublicDiskImagesClient().GetPublicDiskImages(skipToken, cancellationToken),
                model => new PublicDiskImageClient(GetPublicDiskImagesClient(), model.Name, model));
        }

        /// <summary> Lists public disk images as scoped clients asynchronously. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual AsyncPageable<PublicDiskImageClient> GetPublicDiskImagesAsync(string skipToken = default, CancellationToken cancellationToken = default)
        {
            return new ResourceAsyncPageable<PublicDiskImage, PublicDiskImageClient>(
                GetPublicDiskImagesClient().GetPublicDiskImagesAsync(skipToken, cancellationToken),
                model => new PublicDiskImageClient(GetPublicDiskImagesClient(), model.Name, model));
        }

        /// <summary> Lists egress policies as scoped clients. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual Pageable<EgressPolicyClient> GetEgressPolicies(string skipToken = default, CancellationToken cancellationToken = default)
        {
            return new ResourcePageable<NamedEgressPolicy, EgressPolicyClient>(
                GetEgressPoliciesClient().GetEgressPolicies(skipToken, cancellationToken),
                model => new EgressPolicyClient(GetEgressPoliciesClient(), model.Id, model));
        }

        /// <summary> Lists egress policies as scoped clients asynchronously. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual AsyncPageable<EgressPolicyClient> GetEgressPoliciesAsync(string skipToken = default, CancellationToken cancellationToken = default)
        {
            return new ResourceAsyncPageable<NamedEgressPolicy, EgressPolicyClient>(
                GetEgressPoliciesClient().GetEgressPoliciesAsync(skipToken, cancellationToken),
                model => new EgressPolicyClient(GetEgressPoliciesClient(), model.Id, model));
        }

        /// <summary> Lists secrets as scoped clients. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual Pageable<SandboxSecretClient> GetSecrets(string skipToken = default, CancellationToken cancellationToken = default)
        {
            return new ResourcePageable<SandboxSecret, SandboxSecretClient>(
                GetSecretsClient().GetSecrets(skipToken, cancellationToken),
                model => new SandboxSecretClient(GetSecretsClient(), model.Id, model));
        }

        /// <summary> Lists secrets as scoped clients asynchronously. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual AsyncPageable<SandboxSecretClient> GetSecretsAsync(string skipToken = default, CancellationToken cancellationToken = default)
        {
            return new ResourceAsyncPageable<SandboxSecret, SandboxSecretClient>(
                GetSecretsClient().GetSecretsAsync(skipToken, cancellationToken),
                model => new SandboxSecretClient(GetSecretsClient(), model.Id, model));
        }

        /// <summary> Lists snapshots as scoped clients. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="labels"> Comma-separated label selector. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual Pageable<SnapshotClient> GetSnapshots(string skipToken = default, string labels = default, CancellationToken cancellationToken = default)
        {
            return new ResourcePageable<SandboxSnapshot, SnapshotClient>(
                GetSnapshotsClient().GetSnapshots(skipToken, labels, cancellationToken),
                model => new SnapshotClient(GetSnapshotsClient(), model.Id, model));
        }

        /// <summary> Lists snapshots as scoped clients asynchronously. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="labels"> Comma-separated label selector. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual AsyncPageable<SnapshotClient> GetSnapshotsAsync(string skipToken = default, string labels = default, CancellationToken cancellationToken = default)
        {
            return new ResourceAsyncPageable<SandboxSnapshot, SnapshotClient>(
                GetSnapshotsClient().GetSnapshotsAsync(skipToken, labels, cancellationToken),
                model => new SnapshotClient(GetSnapshotsClient(), model.Id, model));
        }

        /// <summary> Gets the total number of snapshots in this group. </summary>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<int> GetSnapshotCount(CancellationToken cancellationToken = default)
        {
            Response<SnapshotCountResult> response = GetSnapshotsClient().GetSnapshotCount(cancellationToken);
            return Response.FromValue(response.Value.Count, response.GetRawResponse());
        }

        /// <summary> Gets the total number of snapshots in this group asynchronously. </summary>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<int>> GetSnapshotCountAsync(CancellationToken cancellationToken = default)
        {
            Response<SnapshotCountResult> response = await GetSnapshotsClient().GetSnapshotCountAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value.Count, response.GetRawResponse());
        }

        /// <summary> Lists volumes as scoped clients. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="labels"> Comma-separated label selector. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual Pageable<VolumeClient> GetVolumes(string skipToken = default, string labels = default, CancellationToken cancellationToken = default)
        {
            return new ResourcePageable<SandboxGroupVolume, VolumeClient>(
                GetVolumesClient().GetVolumes(skipToken, labels, cancellationToken),
                model => new VolumeClient(GetVolumesClient(), model.VolumeName, model));
        }

        /// <summary> Lists volumes as scoped clients asynchronously. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="labels"> Comma-separated label selector. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual AsyncPageable<VolumeClient> GetVolumesAsync(string skipToken = default, string labels = default, CancellationToken cancellationToken = default)
        {
            return new ResourceAsyncPageable<SandboxGroupVolume, VolumeClient>(
                GetVolumesClient().GetVolumesAsync(skipToken, labels, cancellationToken),
                model => new VolumeClient(GetVolumesClient(), model.VolumeName, model));
        }

        /// <summary> Gets the total number of volumes across all volume types in this group. </summary>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<int> GetVolumeCount(CancellationToken cancellationToken = default)
        {
            return ToVolumeCountResponse(GetVolumesClient().GetVolumeCounts(cancellationToken));
        }

        /// <summary> Gets the total number of volumes across all volume types in this group asynchronously. </summary>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<int>> GetVolumeCountAsync(CancellationToken cancellationToken = default)
        {
            return ToVolumeCountResponse(await GetVolumesClient().GetVolumeCountsAsync(cancellationToken).ConfigureAwait(false));
        }

        private static Response<int> ToVolumeCountResponse(Response<VolumeCountResult> response)
        {
            int total = 0;
            foreach (VolumeTypeCount count in response.Value?.Counts ?? throw new InvalidOperationException("The volume count response has no counts."))
            {
                total = checked(total + count.Count);
            }
            return Response.FromValue(total, response.GetRawResponse());
        }

        /// <summary> Creates a sandbox and returns its client. </summary>
        /// <param name="content"> Sandbox create request. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<SandboxClient> CreateSandbox(CreateSandboxContent content, CancellationToken cancellationToken = default)
        {
            Response<SandboxProperties> response = GetSandboxesClient().CreateSandbox(content, cancellationToken);
            return Response.FromValue(new SandboxClient(GetSandboxesClient(), response.Value.Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Creates a sandbox and returns its client asynchronously. </summary>
        /// <param name="content"> Sandbox create request. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<SandboxClient>> CreateSandboxAsync(CreateSandboxContent content, CancellationToken cancellationToken = default)
        {
            Response<SandboxProperties> response = await GetSandboxesClient().CreateSandboxAsync(content, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new SandboxClient(GetSandboxesClient(), response.Value.Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Creates a connection and returns its client. </summary>
        /// <param name="body"> The connection to create. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<ConnectionClient> CreateConnection(CreateConnectionContent body, CancellationToken cancellationToken = default)
        {
            Response<SandboxConnection> response = GetConnectionsClient().CreateConnection(body, cancellationToken);
            return Response.FromValue(new ConnectionClient(GetConnectionsClient(), response.Value.Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Creates a connection and returns its client asynchronously. </summary>
        /// <param name="body"> The connection to create. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<ConnectionClient>> CreateConnectionAsync(CreateConnectionContent body, CancellationToken cancellationToken = default)
        {
            Response<SandboxConnection> response = await GetConnectionsClient().CreateConnectionAsync(body, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ConnectionClient(GetConnectionsClient(), response.Value.Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Sets a credential and returns its client. </summary>
        /// <param name="credentialName"> The name of the credential. </param>
        /// <param name="body"> The credential to set. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<CredentialClient> SetCredential(string credentialName, CreateSandboxGroupCredentialContent body, CancellationToken cancellationToken = default)
        {
            Response<SandboxGroupCredential> response = GetCredentialsClient().SetCredential(credentialName, body, cancellationToken);
            return Response.FromValue(new CredentialClient(GetCredentialsClient(), credentialName, response.Value), response.GetRawResponse());
        }

        /// <summary> Sets a credential and returns its client asynchronously. </summary>
        /// <param name="credentialName"> The name of the credential. </param>
        /// <param name="body"> The credential to set. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<CredentialClient>> SetCredentialAsync(string credentialName, CreateSandboxGroupCredentialContent body, CancellationToken cancellationToken = default)
        {
            Response<SandboxGroupCredential> response = await GetCredentialsClient().SetCredentialAsync(credentialName, body, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new CredentialClient(GetCredentialsClient(), credentialName, response.Value), response.GetRawResponse());
        }

        /// <summary> Creates a disk image and returns its client. </summary>
        /// <param name="body"> The disk image to create. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<DiskImageClient> CreateDiskImage(CreateDiskImageContent body, CancellationToken cancellationToken = default)
        {
            Response<DiskImage> response = GetDiskImagesClient().CreateDiskImage(body, cancellationToken);
            return Response.FromValue(new DiskImageClient(GetDiskImagesClient(), response.Value.Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Creates a disk image and returns its client asynchronously. </summary>
        /// <param name="body"> The disk image to create. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<DiskImageClient>> CreateDiskImageAsync(CreateDiskImageContent body, CancellationToken cancellationToken = default)
        {
            Response<DiskImage> response = await GetDiskImagesClient().CreateDiskImageAsync(body, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new DiskImageClient(GetDiskImagesClient(), response.Value.Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Sets an egress policy and returns its client. </summary>
        /// <param name="policyId"> The identifier of the policy. </param>
        /// <param name="resource"> The policy to set. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<EgressPolicyClient> SetEgressPolicy(string policyId, NamedEgressPolicy resource, CancellationToken cancellationToken = default)
        {
            Response<NamedEgressPolicy> response = GetEgressPoliciesClient().SetEgressPolicy(policyId, resource, cancellationToken);
            return Response.FromValue(new EgressPolicyClient(GetEgressPoliciesClient(), policyId, response.Value), response.GetRawResponse());
        }

        /// <summary> Sets an egress policy and returns its client asynchronously. </summary>
        /// <param name="policyId"> The identifier of the policy. </param>
        /// <param name="resource"> The policy to set. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<EgressPolicyClient>> SetEgressPolicyAsync(string policyId, NamedEgressPolicy resource, CancellationToken cancellationToken = default)
        {
            Response<NamedEgressPolicy> response = await GetEgressPoliciesClient().SetEgressPolicyAsync(policyId, resource, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new EgressPolicyClient(GetEgressPoliciesClient(), policyId, response.Value), response.GetRawResponse());
        }

        /// <summary> Sets a secret and returns its client. </summary>
        /// <param name="secretId"> The identifier of the secret. </param>
        /// <param name="body"> The secret to set. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<SandboxSecretClient> SetSecret(string secretId, SetSecretContent body, CancellationToken cancellationToken = default)
        {
            Response<SandboxSecret> response = GetSecretsClient().SetSecret(secretId, body, cancellationToken);
            return Response.FromValue(new SandboxSecretClient(GetSecretsClient(), secretId, response.Value), response.GetRawResponse());
        }

        /// <summary> Sets a secret and returns its client asynchronously. </summary>
        /// <param name="secretId"> The identifier of the secret. </param>
        /// <param name="body"> The secret to set. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<SandboxSecretClient>> SetSecretAsync(string secretId, SetSecretContent body, CancellationToken cancellationToken = default)
        {
            Response<SandboxSecret> response = await GetSecretsClient().SetSecretAsync(secretId, body, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new SandboxSecretClient(GetSecretsClient(), secretId, response.Value), response.GetRawResponse());
        }

        /// <summary> Creates a snapshot of a sandbox and returns its client. </summary>
        /// <param name="sandboxId"> The identifier of the sandbox. </param>
        /// <param name="body"> The snapshot to create. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<SnapshotClient> CreateSnapshot(string sandboxId, CreateSnapshotContent body, CancellationToken cancellationToken = default)
        {
            Response<SandboxSnapshot> response = GetSandboxesClient().CreateSnapshot(sandboxId, body, cancellationToken);
            return Response.FromValue(new SnapshotClient(GetSnapshotsClient(), response.Value.Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Creates a snapshot of a sandbox and returns its client asynchronously. </summary>
        /// <param name="sandboxId"> The identifier of the sandbox. </param>
        /// <param name="body"> The snapshot to create. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<SnapshotClient>> CreateSnapshotAsync(string sandboxId, CreateSnapshotContent body, CancellationToken cancellationToken = default)
        {
            Response<SandboxSnapshot> response = await GetSandboxesClient().CreateSnapshotAsync(sandboxId, body, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new SnapshotClient(GetSnapshotsClient(), response.Value.Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Creates a volume and returns its client. </summary>
        /// <param name="volumeName"> The name of the volume. </param>
        /// <param name="body"> The volume to create. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<VolumeClient> CreateVolume(string volumeName, SandboxGroupVolume body, CancellationToken cancellationToken = default)
        {
            Response<SandboxGroupVolume> response = GetVolumesClient().CreateVolume(volumeName, body, cancellationToken);
            return Response.FromValue(new VolumeClient(GetVolumesClient(), volumeName, response.Value), response.GetRawResponse());
        }

        /// <summary> Creates a volume and returns its client asynchronously. </summary>
        /// <param name="volumeName"> The name of the volume. </param>
        /// <param name="body"> The volume to create. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<VolumeClient>> CreateVolumeAsync(string volumeName, SandboxGroupVolume body, CancellationToken cancellationToken = default)
        {
            Response<SandboxGroupVolume> response = await GetVolumesClient().CreateVolumeAsync(volumeName, body, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new VolumeClient(GetVolumesClient(), volumeName, response.Value), response.GetRawResponse());
        }

        /// <summary> Forks a volume and returns the new volume's client. </summary>
        /// <param name="volumeName"> The name of the source volume. </param>
        /// <param name="body"> The fork configuration. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<VolumeClient> ForkVolume(string volumeName, ForkDataDiskVolumeContent body, CancellationToken cancellationToken = default)
        {
            Response<SandboxGroupVolume> response = GetVolumesClient().ForkVolume(volumeName, body, cancellationToken);
            return Response.FromValue(new VolumeClient(GetVolumesClient(), response.Value.VolumeName, response.Value), response.GetRawResponse());
        }

        /// <summary> Forks a volume and returns the new volume's client asynchronously. </summary>
        /// <param name="volumeName"> The name of the source volume. </param>
        /// <param name="body"> The fork configuration. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<VolumeClient>> ForkVolumeAsync(string volumeName, ForkDataDiskVolumeContent body, CancellationToken cancellationToken = default)
        {
            Response<SandboxGroupVolume> response = await GetVolumesClient().ForkVolumeAsync(volumeName, body, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new VolumeClient(GetVolumesClient(), response.Value.VolumeName, response.Value), response.GetRawResponse());
        }

        /// <summary> Uploads a content package from a readable, seekable stream and returns its client. The caller retains ownership of the stream. </summary>
        /// <param name="content"> The content to upload. </param>
        /// <param name="contentType"> The content type of the package. </param>
        /// <param name="labels"> Labels for the package. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<ContentPackageClient> UploadContentPackage(Stream content, string contentType = default, string labels = default, CancellationToken cancellationToken = default)
        {
            ContentPackagesClient client = GetContentPackagesClient();
            Response<ContentPackage> response = client.UploadContentPackage(content, contentType, labels, cancellationToken);
            return Response.FromValue(new ContentPackageClient(client, response.Value.Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Uploads a content package from a readable, seekable stream and returns its client asynchronously. The caller retains ownership of the stream. </summary>
        /// <param name="content"> The content to upload. </param>
        /// <param name="contentType"> The content type of the package. </param>
        /// <param name="labels"> Labels for the package. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<ContentPackageClient>> UploadContentPackageAsync(Stream content, string contentType = default, string labels = default, CancellationToken cancellationToken = default)
        {
            ContentPackagesClient client = GetContentPackagesClient();
            Response<ContentPackage> response = await client.UploadContentPackageAsync(content, contentType, labels, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ContentPackageClient(client, response.Value.Id, response.Value), response.GetRawResponse());
        }

        internal virtual ConnectionsClient GetConnectionsClient()
        {
            return Volatile.Read(ref _cachedConnectionsClient) ?? Interlocked.CompareExchange(ref _cachedConnectionsClient, new ConnectionsClient(
                ClientDiagnostics,
                Pipeline,
                _endpoint,
                _apiVersion,
                _subscriptionId,
                _resourceGroupName,
                _sandboxGroupName), null) ?? _cachedConnectionsClient;
        }

        internal virtual CredentialsClient GetCredentialsClient()
        {
            return Volatile.Read(ref _cachedCredentialsClient) ?? Interlocked.CompareExchange(ref _cachedCredentialsClient, new CredentialsClient(
                ClientDiagnostics,
                Pipeline,
                _endpoint,
                _apiVersion,
                _subscriptionId,
                _resourceGroupName,
                _sandboxGroupName), null) ?? _cachedCredentialsClient;
        }

        internal virtual DiskImagesClient GetDiskImagesClient()
        {
            return Volatile.Read(ref _cachedDiskImagesClient) ?? Interlocked.CompareExchange(ref _cachedDiskImagesClient, new DiskImagesClient(
                ClientDiagnostics,
                Pipeline,
                _endpoint,
                _apiVersion,
                _subscriptionId,
                _resourceGroupName,
                _sandboxGroupName), null) ?? _cachedDiskImagesClient;
        }

        internal virtual PublicDiskImagesClient GetPublicDiskImagesClient()
        {
            return Volatile.Read(ref _cachedPublicDiskImagesClient) ?? Interlocked.CompareExchange(ref _cachedPublicDiskImagesClient, new PublicDiskImagesClient(
                ClientDiagnostics,
                Pipeline,
                _endpoint,
                _apiVersion,
                _subscriptionId,
                _resourceGroupName,
                _sandboxGroupName), null) ?? _cachedPublicDiskImagesClient;
        }

        internal virtual EgressPoliciesClient GetEgressPoliciesClient()
        {
            return Volatile.Read(ref _cachedEgressPoliciesClient) ?? Interlocked.CompareExchange(ref _cachedEgressPoliciesClient, new EgressPoliciesClient(
                ClientDiagnostics,
                Pipeline,
                _endpoint,
                _apiVersion,
                _subscriptionId,
                _resourceGroupName,
                _sandboxGroupName), null) ?? _cachedEgressPoliciesClient;
        }

        internal virtual SecretsClient GetSecretsClient()
        {
            return Volatile.Read(ref _cachedSecretsClient) ?? Interlocked.CompareExchange(ref _cachedSecretsClient, new SecretsClient(
                ClientDiagnostics,
                Pipeline,
                _endpoint,
                _apiVersion,
                _subscriptionId,
                _resourceGroupName,
                _sandboxGroupName), null) ?? _cachedSecretsClient;
        }

        internal virtual SnapshotsClient GetSnapshotsClient()
        {
            return Volatile.Read(ref _cachedSnapshotsClient) ?? Interlocked.CompareExchange(ref _cachedSnapshotsClient, new SnapshotsClient(
                ClientDiagnostics,
                Pipeline,
                _endpoint,
                _apiVersion,
                _subscriptionId,
                _resourceGroupName,
                _sandboxGroupName), null) ?? _cachedSnapshotsClient;
        }

        internal virtual VolumesClient GetVolumesClient()
        {
            return Volatile.Read(ref _cachedVolumesClient) ?? Interlocked.CompareExchange(ref _cachedVolumesClient, new VolumesClient(
                ClientDiagnostics,
                Pipeline,
                _endpoint,
                _apiVersion,
                _subscriptionId,
                _resourceGroupName,
                _sandboxGroupName), null) ?? _cachedVolumesClient;
        }

        internal virtual ContentPackagesClient GetContentPackagesClient()
        {
            return Volatile.Read(ref _cachedContentPackagesClient) ?? Interlocked.CompareExchange(ref _cachedContentPackagesClient, new ContentPackagesClient(
                ClientDiagnostics,
                Pipeline,
                _endpoint,
                _apiVersion,
                _subscriptionId,
                _resourceGroupName,
                _sandboxGroupName), null) ?? _cachedContentPackagesClient;
        }

        internal virtual SandboxesClient GetSandboxesClient()
        {
            return Volatile.Read(ref _cachedSandboxesClient) ?? Interlocked.CompareExchange(ref _cachedSandboxesClient, new SandboxesClient(
                ClientDiagnostics,
                Pipeline,
                _endpoint,
                _apiVersion,
                _subscriptionId,
                _resourceGroupName,
                _sandboxGroupName,
                _webSocketCredential), null) ?? _cachedSandboxesClient;
        }
    }
}
