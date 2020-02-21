// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Files.Shares.Models;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Files.Shares.Specialized
{
    /// <summary>
    /// The <see cref="ShareLeaseClient"/> allows you to manipulate Azure
    /// Storage leases on files.
    /// </summary>
    public class ShareLeaseClient
    {
        /// <summary>
        /// The <see cref="ShareFileClient"/> to manage leases for.
        /// </summary>
        private readonly ShareFileClient _file;

        /// <summary>
        /// The <see cref="ShareFileClient"/> to manage leases for.
        /// </summary>
        protected virtual ShareFileClient FileClient => _file;

        /// <summary>
        /// Gets the URI of the object being leased.
        /// </summary>
        public Uri Uri => FileClient?.Uri;

        /// <summary>
        /// Gets the Lease ID for this lease.
        /// </summary>
        public virtual string LeaseId { get; private set; }

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        private HttpPipeline Pipeline => FileClient?.Pipeline;

        /// <summary>
        /// The version of the service to use when sending requests.
        /// </summary>
        internal virtual ShareClientOptions.ServiceVersion Version => FileClient.Version;

        /// <summary>
        /// The <see cref="ClientDiagnostics"/> instance used to create diagnostic scopes
        /// every request.
        /// </summary>
        internal virtual ClientDiagnostics ClientDiagnostics => FileClient?.ClientDiagnostics;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareLeaseClient"/> class
        /// for mocking.
        /// </summary>
        protected ShareLeaseClient()
        {
            _file = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareLeaseClient"/> class.
        /// </summary>
        /// <param name="client">
        /// A <see cref="ShareFileClient"/> representing the file being leased.
        /// </param>
        /// <param name="leaseId">
        /// An optional lease ID.  If no lease ID is provided, a random lease
        /// ID will be created.
        /// </param>
        public ShareLeaseClient(ShareFileClient client, string leaseId = null)
        {
            _file = client ?? throw Errors.ArgumentNull(nameof(client));
            LeaseId = leaseId ?? CreateUniqueLeaseId();
        }

        /// <summary>
        /// Gets a unique lease ID.
        /// </summary>
        /// <returns>A unique lease ID.</returns>
        private static string CreateUniqueLeaseId() => Guid.NewGuid().ToString();

        #region Acquire
        /// <summary>
        /// The <see cref="Acquire"/> operation acquires a lease on
        /// the file.
        ///
        /// If the file does not have an active lease, the File service
        /// creates a lease on the file and returns it.  If the
        /// file has an active lease, you can only request a new lease
        /// using the active lease ID as <see cref="LeaseId"/>
        ///
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareFileLease> Acquire(
            CancellationToken cancellationToken = default) =>
            AcquireInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="AcquireAsync"/> operation acquires a lease on
        /// the file.
        ///
        /// If the file does not have an active lease, the File service
        /// creates a lease on the file and returns it.  If the
        /// file has an active lease, you can only request a new lease
        /// using the active lease ID as <see cref="LeaseId"/>.
        ///
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareFileLease>> AcquireAsync(
            CancellationToken cancellationToken = default) =>
            await AcquireInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="AcquireInternal"/> operation acquires a lease on
        /// the file.
        ///
        /// If the file does not have an active lease, the File service
        /// creates a lease on the file and returns it.  If the
        /// file has an active lease, you can only request a new lease
        /// using the active lease ID as <see cref="LeaseId"/>.
        ///
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareFileLease>> AcquireInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareLeaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareLeaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(LeaseId)}: {LeaseId}\n");
                try
                {
                    return await FileRestClient.File.AcquireLeaseAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        Version.ToVersionString(),
                        duration: Constants.File.Lease.InfiniteLeaseDuration,
                        proposedLeaseId: LeaseId,
                        async: async,
                        operationName: $"{nameof(ShareLeaseClient)}.{nameof(Acquire)}",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(ShareLeaseClient));
                }
            }
        }
        #endregion Acquire

        #region Release
        /// <summary>
        /// The <see cref="Release"/> operation releases the
        /// files's previously-acquired lease.
        ///
        /// The lease may be released if the <see cref="LeaseId"/>
        /// matches that associated with the file.  Releasing the
        /// lease allows another client to immediately acquire the lease for the
        /// file as soon as the release is complete.
        ///
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileLeaseReleaseInfo}"/> describing the
        /// updated blob or container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<FileLeaseReleaseInfo> Release(
            CancellationToken cancellationToken = default) =>
            ReleaseInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="ReleaseAsync"/> operation releases the
        /// files's previously-acquired lease.
        ///
        /// The lease may be released if the <see cref="LeaseId"/>
        /// matches that associated with the file.  Releasing the
        /// lease allows another client to immediately acquire the lease for the
        /// file as soon as the release is complete.
        ///
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileLeaseReleaseInfo}"/> describing the
        /// updated file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<FileLeaseReleaseInfo>> ReleaseAsync(
            CancellationToken cancellationToken = default) =>
            await ReleaseInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="ReleaseInternal"/> operation releases the
        /// files's previously-acquired lease.
        ///
        /// The lease may be released if the <see cref="LeaseId"/>
        /// matches that associated with the file.  Releasing the
        /// lease allows another client to immediately acquire the lease for the
        /// file as soon as the release is complete.
        ///
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileLeaseReleaseInfo}"/> describing the
        /// updated file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal virtual async Task<Response<FileLeaseReleaseInfo>> ReleaseInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareLeaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareLeaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(LeaseId)}: {LeaseId}");
                try
                {
                    return await FileRestClient.File.ReleaseLeaseAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        leaseId: LeaseId,
                        Version.ToVersionString(),
                        async: async,
                        operationName: $"{nameof(ShareLeaseClient)}.{nameof(Release)}",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(ShareLeaseClient));
                }
            }
        }
        #endregion Release

        #region Change
        /// <summary>
        /// The <see cref="Change"/> operation changes the lease
        /// of an active lease.  A change must include the current
        /// <see cref="LeaseId"/> and a new <paramref name="proposedId"/>.
        ///
        /// </summary>
        /// <param name="proposedId">
        /// An optional proposed lease ID, in a GUID string format. A
        /// <see cref="RequestFailedException"/> will be thrown if the
        /// proposed lease ID is not in the correct format.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileLease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareFileLease> Change(
            string proposedId,
            CancellationToken cancellationToken = default) =>
            ChangeInternal(
                proposedId,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="ChangeAsync"/> operation changes the lease
        /// of an active lease.  A change must include the current
        /// <see cref="LeaseId"/> and a new <paramref name="proposedId"/>.
        ///
        /// </summary>
        /// <param name="proposedId">
        /// An optional proposed lease ID, in a GUID string format. A
        /// <see cref="RequestFailedException"/> will be thrown if the
        /// proposed lease ID is not in the correct format.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareFileLease>> ChangeAsync(
            string proposedId,
            CancellationToken cancellationToken = default) =>
            await ChangeInternal(
                proposedId,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="ChangeInternal"/> operation changes the lease
        /// of an active lease.  A change must include the current
        /// <see cref="LeaseId"/> and a new <paramref name="proposedId"/>.
        ///
        /// </summary>
        /// <param name="proposedId">
        /// An optional proposed lease ID, in a GUID string format. A
        /// <see cref="RequestFailedException"/> will be thrown if the
        /// proposed lease ID is not in the correct format.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileLease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareFileLease>> ChangeInternal(
            string proposedId,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareLeaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareLeaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(LeaseId)}: {LeaseId}\n" +
                    $"{nameof(proposedId)}: {proposedId}");
                try
                {
                    return await FileRestClient.File.ChangeLeaseAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        leaseId: LeaseId,
                        Version.ToVersionString(),
                        proposedLeaseId: proposedId,
                        async: async,
                        operationName: $"{nameof(ShareLeaseClient)}.{nameof(Change)}",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(ShareLeaseClient));
                }
            }
        }
        #endregion Change

        #region Break
        /// <summary>
        /// The <see cref="Break"/> operation breaks the files's
        /// previously-acquired lease (if it exists).
        ///
        /// Once a lease is broken, it cannot be renewed.  Any authorized
        /// request can break the lease; the request is not required to
        /// specify a matching lease ID.
        ///
        /// A lease that has been broken can also be released.  A client can
        /// immediately acquire a file lease that has been
        /// released.
        ///
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileLease}"/> describing the broken lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ShareFileLease> Break(
            CancellationToken cancellationToken = default) =>
            BreakInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="BreakAsync"/> operation breaks the files's
        /// previously-acquired lease (if it exists).
        ///
        /// Once a lease is broken, it cannot be renewed.  Any authorized
        /// request can break the lease; the request is not required to
        /// specify a matching lease ID.
        ///
        /// A lease that has been broken can also be released.  A client can
        /// immediately acquire a file lease that has been
        /// released.
        ///
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileLease}"/> describing the broken lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ShareFileLease>> BreakAsync(
            CancellationToken cancellationToken = default) =>
            await BreakInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="BreakInternal"/> operation breaks the files's
        /// previously-acquired lease (if it exists).
        ///
        /// Once a lease is broken, it cannot be renewed.  Any authorized
        /// request can break the lease; the request is not required to
        /// specify a matching lease ID.
        ///
        /// A lease that has been broken can also be released.  A client can
        /// immediately acquire a file lease that has been
        /// released.
        ///
        /// </summary>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileLease}"/> describing the broken lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<ShareFileLease>> BreakInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(ShareLeaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareLeaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(LeaseId)}: {LeaseId}");
                try
                {
                    return (await FileRestClient.File.BreakLeaseAsync(
                        ClientDiagnostics,
                        Pipeline,
                        Uri,
                        Version.ToVersionString(),
                        leaseId: LeaseId,
                        async: async,
                        operationName: $"{nameof(ShareLeaseClient)}.{nameof(Break)}",
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false))
                        .ToLease();
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(ShareLeaseClient));
                }
            }
        }
        #endregion Break
    }

    /// <summary>
    /// Add easy to discover methods to <see cref="ShareFileClient"/> for
    /// easily creating <see cref="ShareLeaseClient"/>
    /// instances.
    /// </summary>
    public static partial class SpecializedFileExtensions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShareLeaseClient"/> class.
        /// </summary>
        /// <param name="client">
        /// A <see cref="ShareFileClient"/> representing the file being leased.
        /// </param>
        /// <param name="leaseId">
        /// An optional lease ID.  If no lease ID is provided, a random lease
        /// ID will be created.
        /// </param>
        public static ShareLeaseClient GetShareLeaseClient(
            this ShareFileClient client,
            string leaseId = null) =>
            new ShareLeaseClient(client, leaseId);
    }
}
