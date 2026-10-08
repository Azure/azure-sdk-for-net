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
        public virtual SandboxResource GetSandbox(string id)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            return new SandboxResource(GetSandboxesClient(), id);
        }

        /// <summary> Gets a client for a connection in this group. </summary>
        /// <param name="id"> The identifier of the connection. </param>
        /// <returns> A client scoped to the connection. </returns>
        public virtual ConnectionResource GetConnection(string id)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            return new ConnectionResource(GetConnectionsClient(), id);
        }

        /// <summary> Gets a client for a content package in this group. </summary>
        /// <param name="id"> The identifier of the content package. </param>
        /// <returns> A client scoped to the content package. </returns>
        public virtual ContentPackageResource GetContentPackage(string id)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            return new ContentPackageResource(GetContentPackagesClient(), id);
        }

        /// <summary> Gets a client for a credential in this group. </summary>
        /// <param name="credentialName"> The name of the credential. </param>
        /// <returns> A client scoped to the credential. </returns>
        public virtual CredentialResource GetCredential(string credentialName)
        {
            Argument.AssertNotNullOrEmpty(credentialName, nameof(credentialName));
            return new CredentialResource(GetCredentialsClient(), credentialName);
        }

        /// <summary> Gets a client for a disk image in this group. </summary>
        /// <param name="id"> The identifier of the disk image. </param>
        /// <returns> A client scoped to the disk image. </returns>
        public virtual DiskImageResource GetDiskImage(string id)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            return new DiskImageResource(GetDiskImagesClient(), id);
        }

        /// <summary> Gets a client for a public disk image. </summary>
        /// <param name="name"> The name of the public disk image. </param>
        /// <returns> A client scoped to the public disk image. </returns>
        public virtual PublicDiskImageResource GetPublicDiskImage(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            return new PublicDiskImageResource(GetPublicDiskImagesClient(), name);
        }

        /// <summary> Gets a client for an egress policy in this group. </summary>
        /// <param name="policyId"> The identifier of the egress policy. </param>
        /// <returns> A client scoped to the egress policy. </returns>
        public virtual EgressPolicyResource GetEgressPolicy(string policyId)
        {
            Argument.AssertNotNullOrEmpty(policyId, nameof(policyId));
            return new EgressPolicyResource(GetEgressPoliciesClient(), policyId);
        }

        /// <summary> Gets a client for a secret in this group. </summary>
        /// <param name="secretId"> The identifier of the secret. </param>
        /// <returns> A client scoped to the secret. </returns>
        public virtual SecretResource GetSecret(string secretId)
        {
            Argument.AssertNotNullOrEmpty(secretId, nameof(secretId));
            return new SecretResource(GetSecretsClient(), secretId);
        }

        /// <summary> Gets a client for a snapshot in this group. </summary>
        /// <param name="id"> The identifier of the snapshot. </param>
        /// <returns> A client scoped to the snapshot. </returns>
        public virtual SnapshotResource GetSnapshot(string id)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            return new SnapshotResource(GetSnapshotsClient(), id);
        }

        /// <summary> Gets a client for a volume in this group. </summary>
        /// <param name="volumeName"> The name of the volume. </param>
        /// <returns> A client scoped to the volume. </returns>
        public virtual VolumeResource GetVolume(string volumeName)
        {
            Argument.AssertNotNullOrEmpty(volumeName, nameof(volumeName));
            return new VolumeResource(GetVolumesClient(), volumeName);
        }

        /// <summary> Lists sandboxes as resource clients. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="labels"> Comma-separated label selector. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual Pageable<SandboxResource> GetSandboxes(string skipToken = default, string labels = default, CancellationToken cancellationToken = default)
        {
            return new ResourcePageable<SandboxProperties, SandboxResource>(
                GetSandboxesClient().GetSandboxes(skipToken, labels, cancellationToken),
                model => new SandboxResource(GetSandboxesClient(), model.Id, model));
        }

        /// <summary> Lists sandboxes as resource clients asynchronously. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="labels"> Comma-separated label selector. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual AsyncPageable<SandboxResource> GetSandboxesAsync(string skipToken = default, string labels = default, CancellationToken cancellationToken = default)
        {
            return new ResourceAsyncPageable<SandboxProperties, SandboxResource>(
                GetSandboxesClient().GetSandboxesAsync(skipToken, labels, cancellationToken),
                model => new SandboxResource(GetSandboxesClient(), model.Id, model));
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

        /// <summary> Lists connections as resource clients. </summary>
        /// <param name="includeSandboxIds"> Whether to include sandbox identifiers using each connection. </param>
        /// <param name="labels"> Comma-separated key=value labels that all resources must match. </param>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual Pageable<ConnectionResource> GetConnections(bool? includeSandboxIds = default, string labels = default, string skipToken = default, CancellationToken cancellationToken = default)
        {
            return new ResourcePageable<SandboxConnection, ConnectionResource>(
                GetConnectionsClient().GetConnections(includeSandboxIds, labels, skipToken, cancellationToken),
                model => new ConnectionResource(GetConnectionsClient(), model.Id, model));
        }

        /// <summary> Lists connections as resource clients asynchronously. </summary>
        /// <param name="includeSandboxIds"> Whether to include sandbox identifiers using each connection. </param>
        /// <param name="labels"> Comma-separated key=value labels that all resources must match. </param>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual AsyncPageable<ConnectionResource> GetConnectionsAsync(bool? includeSandboxIds = default, string labels = default, string skipToken = default, CancellationToken cancellationToken = default)
        {
            return new ResourceAsyncPageable<SandboxConnection, ConnectionResource>(
                GetConnectionsClient().GetConnectionsAsync(includeSandboxIds, labels, skipToken, cancellationToken),
                model => new ConnectionResource(GetConnectionsClient(), model.Id, model));
        }

        /// <summary> Lists content packages as resource clients. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="labels"> Comma-separated label selector. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual Pageable<ContentPackageResource> GetContentPackages(string skipToken = default, string labels = default, CancellationToken cancellationToken = default)
        {
            return new ResourcePageable<ContentPackage, ContentPackageResource>(
                GetContentPackagesClient().GetContentPackages(skipToken, labels, cancellationToken),
                model => new ContentPackageResource(GetContentPackagesClient(), model.Id, model));
        }

        /// <summary> Lists content packages as resource clients asynchronously. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="labels"> Comma-separated label selector. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual AsyncPageable<ContentPackageResource> GetContentPackagesAsync(string skipToken = default, string labels = default, CancellationToken cancellationToken = default)
        {
            return new ResourceAsyncPageable<ContentPackage, ContentPackageResource>(
                GetContentPackagesClient().GetContentPackagesAsync(skipToken, labels, cancellationToken),
                model => new ContentPackageResource(GetContentPackagesClient(), model.Id, model));
        }

        /// <summary> Lists credentials as resource clients. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual Pageable<CredentialResource> GetCredentials(string skipToken = default, CancellationToken cancellationToken = default)
        {
            return new ResourcePageable<SandboxGroupCredential, CredentialResource>(
                GetCredentialsClient().GetCredentials(skipToken, cancellationToken),
                model => new CredentialResource(GetCredentialsClient(), model.Name, model));
        }

        /// <summary> Lists credentials as resource clients asynchronously. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual AsyncPageable<CredentialResource> GetCredentialsAsync(string skipToken = default, CancellationToken cancellationToken = default)
        {
            return new ResourceAsyncPageable<SandboxGroupCredential, CredentialResource>(
                GetCredentialsClient().GetCredentialsAsync(skipToken, cancellationToken),
                model => new CredentialResource(GetCredentialsClient(), model.Name, model));
        }

        /// <summary> Lists disk images as resource clients. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="labels"> Comma-separated label selector. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual Pageable<DiskImageResource> GetDiskImages(string skipToken = default, string labels = default, CancellationToken cancellationToken = default)
        {
            return new ResourcePageable<DiskImage, DiskImageResource>(
                GetDiskImagesClient().GetDiskImages(skipToken, labels, cancellationToken),
                model => new DiskImageResource(GetDiskImagesClient(), model.Id, model));
        }

        /// <summary> Lists disk images as resource clients asynchronously. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="labels"> Comma-separated label selector. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual AsyncPageable<DiskImageResource> GetDiskImagesAsync(string skipToken = default, string labels = default, CancellationToken cancellationToken = default)
        {
            return new ResourceAsyncPageable<DiskImage, DiskImageResource>(
                GetDiskImagesClient().GetDiskImagesAsync(skipToken, labels, cancellationToken),
                model => new DiskImageResource(GetDiskImagesClient(), model.Id, model));
        }

        /// <summary> Lists public disk images as resource clients. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual Pageable<PublicDiskImageResource> GetPublicDiskImages(string skipToken = default, CancellationToken cancellationToken = default)
        {
            return new ResourcePageable<PublicDiskImage, PublicDiskImageResource>(
                GetPublicDiskImagesClient().GetPublicDiskImages(skipToken, cancellationToken),
                model => new PublicDiskImageResource(GetPublicDiskImagesClient(), model.Name, model));
        }

        /// <summary> Lists public disk images as resource clients asynchronously. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual AsyncPageable<PublicDiskImageResource> GetPublicDiskImagesAsync(string skipToken = default, CancellationToken cancellationToken = default)
        {
            return new ResourceAsyncPageable<PublicDiskImage, PublicDiskImageResource>(
                GetPublicDiskImagesClient().GetPublicDiskImagesAsync(skipToken, cancellationToken),
                model => new PublicDiskImageResource(GetPublicDiskImagesClient(), model.Name, model));
        }

        /// <summary> Lists egress policies as resource clients. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual Pageable<EgressPolicyResource> GetEgressPolicies(string skipToken = default, CancellationToken cancellationToken = default)
        {
            return new ResourcePageable<NamedEgressPolicy, EgressPolicyResource>(
                GetEgressPoliciesClient().GetEgressPolicies(skipToken, cancellationToken),
                model => new EgressPolicyResource(GetEgressPoliciesClient(), model.Id, model));
        }

        /// <summary> Lists egress policies as resource clients asynchronously. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual AsyncPageable<EgressPolicyResource> GetEgressPoliciesAsync(string skipToken = default, CancellationToken cancellationToken = default)
        {
            return new ResourceAsyncPageable<NamedEgressPolicy, EgressPolicyResource>(
                GetEgressPoliciesClient().GetEgressPoliciesAsync(skipToken, cancellationToken),
                model => new EgressPolicyResource(GetEgressPoliciesClient(), model.Id, model));
        }

        /// <summary> Lists secrets as resource clients. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual Pageable<SecretResource> GetSecrets(string skipToken = default, CancellationToken cancellationToken = default)
        {
            return new ResourcePageable<SandboxSecret, SecretResource>(
                GetSecretsClient().GetSecrets(skipToken, cancellationToken),
                model => new SecretResource(GetSecretsClient(), model.Id, model));
        }

        /// <summary> Lists secrets as resource clients asynchronously. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual AsyncPageable<SecretResource> GetSecretsAsync(string skipToken = default, CancellationToken cancellationToken = default)
        {
            return new ResourceAsyncPageable<SandboxSecret, SecretResource>(
                GetSecretsClient().GetSecretsAsync(skipToken, cancellationToken),
                model => new SecretResource(GetSecretsClient(), model.Id, model));
        }

        /// <summary> Lists snapshots as resource clients. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="labels"> Comma-separated label selector. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual Pageable<SnapshotResource> GetSnapshots(string skipToken = default, string labels = default, CancellationToken cancellationToken = default)
        {
            return new ResourcePageable<SandboxSnapshot, SnapshotResource>(
                GetSnapshotsClient().GetSnapshots(skipToken, labels, cancellationToken),
                model => new SnapshotResource(GetSnapshotsClient(), model.Id, model));
        }

        /// <summary> Lists snapshots as resource clients asynchronously. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="labels"> Comma-separated label selector. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual AsyncPageable<SnapshotResource> GetSnapshotsAsync(string skipToken = default, string labels = default, CancellationToken cancellationToken = default)
        {
            return new ResourceAsyncPageable<SandboxSnapshot, SnapshotResource>(
                GetSnapshotsClient().GetSnapshotsAsync(skipToken, labels, cancellationToken),
                model => new SnapshotResource(GetSnapshotsClient(), model.Id, model));
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

        /// <summary> Lists volumes as resource clients. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="labels"> Comma-separated label selector. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual Pageable<VolumeResource> GetVolumes(string skipToken = default, string labels = default, CancellationToken cancellationToken = default)
        {
            return new ResourcePageable<SandboxGroupVolume, VolumeResource>(
                GetVolumesClient().GetVolumes(skipToken, labels, cancellationToken),
                model => new VolumeResource(GetVolumesClient(), model.VolumeName, model));
        }

        /// <summary> Lists volumes as resource clients asynchronously. </summary>
        /// <param name="skipToken"> Continuation token for paginated results. </param>
        /// <param name="labels"> Comma-separated label selector. </param>
        /// <param name="cancellationToken"> The cancellation token for service requests. </param>
        public virtual AsyncPageable<VolumeResource> GetVolumesAsync(string skipToken = default, string labels = default, CancellationToken cancellationToken = default)
        {
            return new ResourceAsyncPageable<SandboxGroupVolume, VolumeResource>(
                GetVolumesClient().GetVolumesAsync(skipToken, labels, cancellationToken),
                model => new VolumeResource(GetVolumesClient(), model.VolumeName, model));
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

        /// <summary> Creates a sandbox and returns its resource client. </summary>
        /// <param name="content"> Sandbox create request. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<SandboxResource> CreateSandbox(CreateSandboxContent content, CancellationToken cancellationToken = default)
        {
            Response<SandboxProperties> response = GetSandboxesClient().CreateSandbox(content, cancellationToken);
            return Response.FromValue(new SandboxResource(GetSandboxesClient(), response.Value.Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Creates a sandbox and returns its resource client asynchronously. </summary>
        /// <param name="content"> Sandbox create request. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<SandboxResource>> CreateSandboxAsync(CreateSandboxContent content, CancellationToken cancellationToken = default)
        {
            Response<SandboxProperties> response = await GetSandboxesClient().CreateSandboxAsync(content, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new SandboxResource(GetSandboxesClient(), response.Value.Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Creates a connection and returns its resource client. </summary>
        /// <param name="body"> The connection to create. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<ConnectionResource> CreateConnection(CreateConnectionContent body, CancellationToken cancellationToken = default)
        {
            Response<SandboxConnection> response = GetConnectionsClient().CreateConnection(body, cancellationToken);
            return Response.FromValue(new ConnectionResource(GetConnectionsClient(), response.Value.Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Creates a connection and returns its resource client asynchronously. </summary>
        /// <param name="body"> The connection to create. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<ConnectionResource>> CreateConnectionAsync(CreateConnectionContent body, CancellationToken cancellationToken = default)
        {
            Response<SandboxConnection> response = await GetConnectionsClient().CreateConnectionAsync(body, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ConnectionResource(GetConnectionsClient(), response.Value.Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Sets a credential and returns its resource client. </summary>
        /// <param name="credentialName"> The name of the credential. </param>
        /// <param name="body"> The credential to set. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<CredentialResource> SetCredential(string credentialName, CreateSandboxGroupCredentialContent body, CancellationToken cancellationToken = default)
        {
            Response<SandboxGroupCredential> response = GetCredentialsClient().SetCredential(credentialName, body, cancellationToken);
            return Response.FromValue(new CredentialResource(GetCredentialsClient(), credentialName, response.Value), response.GetRawResponse());
        }

        /// <summary> Sets a credential and returns its resource client asynchronously. </summary>
        /// <param name="credentialName"> The name of the credential. </param>
        /// <param name="body"> The credential to set. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<CredentialResource>> SetCredentialAsync(string credentialName, CreateSandboxGroupCredentialContent body, CancellationToken cancellationToken = default)
        {
            Response<SandboxGroupCredential> response = await GetCredentialsClient().SetCredentialAsync(credentialName, body, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new CredentialResource(GetCredentialsClient(), credentialName, response.Value), response.GetRawResponse());
        }

        /// <summary> Creates a disk image and returns its resource client. </summary>
        /// <param name="body"> The disk image to create. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<DiskImageResource> CreateDiskImage(CreateDiskImageContent body, CancellationToken cancellationToken = default)
        {
            Response<DiskImage> response = GetDiskImagesClient().CreateDiskImage(body, cancellationToken);
            return Response.FromValue(new DiskImageResource(GetDiskImagesClient(), response.Value.Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Creates a disk image and returns its resource client asynchronously. </summary>
        /// <param name="body"> The disk image to create. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<DiskImageResource>> CreateDiskImageAsync(CreateDiskImageContent body, CancellationToken cancellationToken = default)
        {
            Response<DiskImage> response = await GetDiskImagesClient().CreateDiskImageAsync(body, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new DiskImageResource(GetDiskImagesClient(), response.Value.Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Sets an egress policy and returns its resource client. </summary>
        /// <param name="policyId"> The identifier of the policy. </param>
        /// <param name="resource"> The policy to set. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<EgressPolicyResource> SetEgressPolicy(string policyId, NamedEgressPolicy resource, CancellationToken cancellationToken = default)
        {
            Response<NamedEgressPolicy> response = GetEgressPoliciesClient().SetEgressPolicy(policyId, resource, cancellationToken);
            return Response.FromValue(new EgressPolicyResource(GetEgressPoliciesClient(), policyId, response.Value), response.GetRawResponse());
        }

        /// <summary> Sets an egress policy and returns its resource client asynchronously. </summary>
        /// <param name="policyId"> The identifier of the policy. </param>
        /// <param name="resource"> The policy to set. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<EgressPolicyResource>> SetEgressPolicyAsync(string policyId, NamedEgressPolicy resource, CancellationToken cancellationToken = default)
        {
            Response<NamedEgressPolicy> response = await GetEgressPoliciesClient().SetEgressPolicyAsync(policyId, resource, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new EgressPolicyResource(GetEgressPoliciesClient(), policyId, response.Value), response.GetRawResponse());
        }

        /// <summary> Sets a secret and returns its resource client. </summary>
        /// <param name="secretId"> The identifier of the secret. </param>
        /// <param name="body"> The secret to set. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<SecretResource> SetSecret(string secretId, SetSecretContent body, CancellationToken cancellationToken = default)
        {
            Response<SandboxSecret> response = GetSecretsClient().SetSecret(secretId, body, cancellationToken);
            return Response.FromValue(new SecretResource(GetSecretsClient(), secretId, response.Value), response.GetRawResponse());
        }

        /// <summary> Sets a secret and returns its resource client asynchronously. </summary>
        /// <param name="secretId"> The identifier of the secret. </param>
        /// <param name="body"> The secret to set. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<SecretResource>> SetSecretAsync(string secretId, SetSecretContent body, CancellationToken cancellationToken = default)
        {
            Response<SandboxSecret> response = await GetSecretsClient().SetSecretAsync(secretId, body, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new SecretResource(GetSecretsClient(), secretId, response.Value), response.GetRawResponse());
        }

        /// <summary> Creates a snapshot of a sandbox and returns its resource client. </summary>
        /// <param name="sandboxId"> The identifier of the sandbox. </param>
        /// <param name="body"> The snapshot to create. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<SnapshotResource> CreateSnapshot(string sandboxId, CreateSnapshotContent body, CancellationToken cancellationToken = default)
        {
            Response<SandboxSnapshot> response = GetSandboxesClient().CreateSnapshot(sandboxId, body, cancellationToken);
            return Response.FromValue(new SnapshotResource(GetSnapshotsClient(), response.Value.Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Creates a snapshot of a sandbox and returns its resource client asynchronously. </summary>
        /// <param name="sandboxId"> The identifier of the sandbox. </param>
        /// <param name="body"> The snapshot to create. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<SnapshotResource>> CreateSnapshotAsync(string sandboxId, CreateSnapshotContent body, CancellationToken cancellationToken = default)
        {
            Response<SandboxSnapshot> response = await GetSandboxesClient().CreateSnapshotAsync(sandboxId, body, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new SnapshotResource(GetSnapshotsClient(), response.Value.Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Creates a volume and returns its resource client. </summary>
        /// <param name="volumeName"> The name of the volume. </param>
        /// <param name="body"> The volume to create. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<VolumeResource> CreateVolume(string volumeName, SandboxGroupVolume body, CancellationToken cancellationToken = default)
        {
            Response<SandboxGroupVolume> response = GetVolumesClient().CreateVolume(volumeName, body, cancellationToken);
            return Response.FromValue(new VolumeResource(GetVolumesClient(), volumeName, response.Value), response.GetRawResponse());
        }

        /// <summary> Creates a volume and returns its resource client asynchronously. </summary>
        /// <param name="volumeName"> The name of the volume. </param>
        /// <param name="body"> The volume to create. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<VolumeResource>> CreateVolumeAsync(string volumeName, SandboxGroupVolume body, CancellationToken cancellationToken = default)
        {
            Response<SandboxGroupVolume> response = await GetVolumesClient().CreateVolumeAsync(volumeName, body, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new VolumeResource(GetVolumesClient(), volumeName, response.Value), response.GetRawResponse());
        }

        /// <summary> Forks a volume and returns the new volume's resource client. </summary>
        /// <param name="volumeName"> The name of the source volume. </param>
        /// <param name="body"> The fork configuration. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<VolumeResource> ForkVolume(string volumeName, ForkDataDiskVolumeContent body, CancellationToken cancellationToken = default)
        {
            Response<SandboxGroupVolume> response = GetVolumesClient().ForkVolume(volumeName, body, cancellationToken);
            return Response.FromValue(new VolumeResource(GetVolumesClient(), response.Value.VolumeName, response.Value), response.GetRawResponse());
        }

        /// <summary> Forks a volume and returns the new volume's resource client asynchronously. </summary>
        /// <param name="volumeName"> The name of the source volume. </param>
        /// <param name="body"> The fork configuration. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<VolumeResource>> ForkVolumeAsync(string volumeName, ForkDataDiskVolumeContent body, CancellationToken cancellationToken = default)
        {
            Response<SandboxGroupVolume> response = await GetVolumesClient().ForkVolumeAsync(volumeName, body, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new VolumeResource(GetVolumesClient(), response.Value.VolumeName, response.Value), response.GetRawResponse());
        }

        /// <summary> Uploads a content package from a readable, seekable stream and returns its resource client. The caller retains ownership of the stream. </summary>
        /// <param name="content"> The content to upload. </param>
        /// <param name="contentType"> The content type of the package. </param>
        /// <param name="labels"> Labels for the package. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual Response<ContentPackageResource> UploadContentPackage(Stream content, string contentType = default, string labels = default, CancellationToken cancellationToken = default)
        {
            ContentPackagesClient client = GetContentPackagesClient();
            Response<ContentPackage> response = client.UploadContentPackage(content, contentType, labels, cancellationToken);
            return Response.FromValue(new ContentPackageResource(client, response.Value.Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Uploads a content package from a readable, seekable stream and returns its resource client asynchronously. The caller retains ownership of the stream. </summary>
        /// <param name="content"> The content to upload. </param>
        /// <param name="contentType"> The content type of the package. </param>
        /// <param name="labels"> Labels for the package. </param>
        /// <param name="cancellationToken"> The cancellation token for the request. </param>
        public virtual async Task<Response<ContentPackageResource>> UploadContentPackageAsync(Stream content, string contentType = default, string labels = default, CancellationToken cancellationToken = default)
        {
            ContentPackagesClient client = GetContentPackagesClient();
            Response<ContentPackage> response = await client.UploadContentPackageAsync(content, contentType, labels, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ContentPackageResource(client, response.Value.Id, response.Value), response.GetRawResponse());
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
                _sandboxGroupName), null) ?? _cachedSandboxesClient;
        }
    }
}
