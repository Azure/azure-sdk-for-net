// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Shared;

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
        /// The <see cref="ShareClient"/> to manage leases for.
        /// </summary>
        private readonly ShareClient _share;

        /// <summary>
        /// The <see cref="ShareClient"/> to manage leases for.
        /// </summary>
        protected virtual ShareClient ShareClient => _share;

        /// <summary>
        /// Gets the URI of the object being leased.
        /// </summary>
        public Uri Uri => FileClient?.Uri ?? ShareClient?.Uri;

        private string _leaseId;
        /// <summary>
        /// Gets the Lease ID for this lease.
        /// </summary>
        public virtual string LeaseId
        {
            get => Volatile.Read(ref _leaseId);
            private set => Volatile.Write(ref _leaseId, value);
        }

        /// <summary>
        /// <see cref="ShareClientConfiguration"/>.
        /// </summary>
        internal virtual ShareClientConfiguration ClientConfiguration => FileClient?.ClientConfiguration ?? ShareClient?.ClientConfiguration;

        /// <summary>
        /// The <see cref="TimeSpan"/> representing an infinite lease duration.
        /// </summary>
        public static readonly TimeSpan InfiniteLeaseDuration = TimeSpan.FromSeconds(Constants.File.Lease.InfiniteLeaseDuration);

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareLeaseClient"/> class
        /// for mocking.
        /// </summary>
        protected ShareLeaseClient()
        {
            _file = null;
            _share = null;
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

            ShareUriBuilder uriBuilder = new ShareUriBuilder(client.Uri)
            {
                ShareName = null,
                DirectoryOrFilePath = null
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareLeaseClient"/> class.
        /// </summary>
        /// <param name="client">
        /// A <see cref="ShareClient"/> representing the share being leased.
        /// </param>
        /// <param name="leaseId">
        /// An optional lease ID.  If no lease ID is provided, a random lease
        /// ID will be created.
        /// </param>
        public ShareLeaseClient(ShareClient client, string leaseId = null)
        {
            _share = client ?? throw Errors.ArgumentNull(nameof(client));
            LeaseId = leaseId ?? CreateUniqueLeaseId();

            ShareUriBuilder uriBuilder = new ShareUriBuilder(client.Uri)
            {
                ShareName = null
            };
        }

        /// <summary>
        /// Gets a unique lease ID.
        /// </summary>
        /// <returns>A unique lease ID.</returns>
        private static string CreateUniqueLeaseId() => Guid.NewGuid().ToString();

        /// <summary>
        /// Ensure either the File or Share is present.
        /// </summary>
        private void EnsureClient()
        {
            if (FileClient == null && ShareClient == null)
            {
                // This can only happen if someone's not being careful while mocking
                throw ShareErrors.FileOrShareMissing(nameof(ShareLeaseClient), nameof(FileClient), nameof(ShareClient));
            }
        }

        #region Acquire
        /// <summary>
        /// The <see cref="Acquire(TimeSpan?, CancellationToken)"/> operation acquires a lease on
        /// the file.
        ///
        /// If the file does not have an active lease, the File service
        /// creates a lease on the file and returns it.  If the
        /// file has an active lease, you can only request a new lease
        /// using the active lease ID as <see cref="LeaseId"/>
        ///
        /// </summary>
        /// <param name="duration">
        /// Specifies the duration of the lease, in seconds, or specify
        /// <see cref="InfiniteLeaseDuration"/> for a lease that never expires.
        /// A non-infinite lease can be between 15 and 60 seconds.
        /// Files only support infinite lease.
        /// A lease duration cannot be changed using <see cref="RenewAsync"/>
        /// or <see cref="ChangeAsync"/>.
        /// <param name="cancellationToken">
        /// </param>
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<ShareFileLease> Acquire(
            TimeSpan? duration = default,
            CancellationToken cancellationToken = default) =>
            AcquireInternal(
                duration: duration,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="AcquireAsync(TimeSpan?, CancellationToken)"/> operation acquires a lease on
        /// the file.
        ///
        /// If the file does not have an active lease, the File service
        /// creates a lease on the file and returns it.  If the
        /// file has an active lease, you can only request a new lease
        /// using the active lease ID as <see cref="LeaseId"/>.
        ///
        /// </summary>
        /// <param name="duration">
        /// Specifies the duration of the lease, in seconds, or specify
        /// <see cref="InfiniteLeaseDuration"/> for a lease that never expires.
        /// A non-infinite lease can be between 15 and 60 seconds.
        /// Files only support infinite lease.
        /// A lease duration cannot be changed using <see cref="RenewAsync"/>
        /// or <see cref="ChangeAsync"/>.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<ShareFileLease>> AcquireAsync(
            TimeSpan? duration = default,
            CancellationToken cancellationToken = default) =>
            await AcquireInternal(
                duration: duration,
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="AcquireAsync(CancellationToken)"/> operation acquires a lease on
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<ShareFileLease> Acquire(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            CancellationToken cancellationToken) =>
            AcquireInternal(
                duration: default,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="AcquireAsync(CancellationToken)"/> operation acquires a lease on
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<ShareFileLease>> AcquireAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            CancellationToken cancellationToken) =>
            await AcquireInternal(
                duration: default,
                async: true,
                cancellationToken: cancellationToken)
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
        /// <param name="duration">
        /// Specifies the duration of the lease, in seconds, or specify
        /// <see cref="InfiniteLeaseDuration"/> for a lease that never expires.
        /// A non-infinite lease can be between 15 and 60 seconds.
        /// A lease duration cannot be changed using <see cref="RenewAsync"/>
        /// or <see cref="ChangeAsync"/>.
        /// </param>
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<ShareFileLease>> AcquireInternal(
            TimeSpan? duration,
            bool async,
            CancellationToken cancellationToken)
        {
            EnsureClient();
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareLeaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareLeaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(LeaseId)}: {LeaseId}\n");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareLeaseClient)}.{nameof(Acquire)}");

                try
                {
                    scope.Start();
                    Response<ShareFileLease> response;
                    if (FileClient != null)
                    {
                        ResponseWithHeaders<FileAcquireLeaseHeaders> fileResponse;

                        if (async)
                        {
                            fileResponse = await FileClient.FileRestClient.AcquireLeaseAsync(
                                duration: (int)Constants.File.Lease.InfiniteLeaseDuration,
                                proposedLeaseId: LeaseId,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            fileResponse = FileClient.FileRestClient.AcquireLease(
                                duration: (int)Constants.File.Lease.InfiniteLeaseDuration,
                                proposedLeaseId: LeaseId,
                                cancellationToken: cancellationToken);
                        }

                        response = Response.FromValue(
                            fileResponse.ToShareFileLease(),
                            fileResponse.GetRawResponse());
                    }
                    else
                    {
                        // Int64 is an overflow safe cast relative to TimeSpan.MaxValue
                        long serviceDuration;

                        if (duration.HasValue && duration.Value >= TimeSpan.Zero)
                        {
                            serviceDuration = Convert.ToInt64(duration.Value.TotalSeconds);
                        }
                        else
                        {
                            serviceDuration = Constants.File.Lease.InfiniteLeaseDuration;
                        }

                        ResponseWithHeaders<ShareAcquireLeaseHeaders> shareResponse;

                        if (async)
                        {
                            shareResponse = await ShareClient.ShareRestClient.AcquireLeaseAsync(
                                duration: (int)serviceDuration,
                                proposedLeaseId: LeaseId,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            shareResponse = ShareClient.ShareRestClient.AcquireLease(
                                duration: (int)serviceDuration,
                                proposedLeaseId: LeaseId,
                                cancellationToken: cancellationToken);
                        }

                        response = Response.FromValue(
                            shareResponse.ToShareFileLease(),
                            shareResponse.GetRawResponse());
                    }
                    LeaseId = response.Value.LeaseId;
                    return response;
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareLeaseClient));
                    scope.Dispose();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        internal virtual async Task<Response<FileLeaseReleaseInfo>> ReleaseInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            EnsureClient();
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareLeaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareLeaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(LeaseId)}: {LeaseId}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareLeaseClient)}.{nameof(Release)}");

                try
                {
                    scope.Start();
                    if (FileClient != null)
                    {
                        ResponseWithHeaders<FileReleaseLeaseHeaders> response;

                        if (async)
                        {
                            response = await FileClient.FileRestClient.ReleaseLeaseAsync(
                                leaseId: LeaseId,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            response = FileClient.FileRestClient.ReleaseLease(
                                leaseId: LeaseId,
                                cancellationToken: cancellationToken);
                        }

                        return Response.FromValue(
                            response.ToFileLeaseReleaseInfo(),
                            response.GetRawResponse());
                    }
                    else
                    {
                        ResponseWithHeaders<ShareReleaseLeaseHeaders> response;

                        if (async)
                        {
                            response = await ShareClient.ShareRestClient.ReleaseLeaseAsync(
                                leaseId: LeaseId,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            response = ShareClient.ShareRestClient.ReleaseLease(
                                leaseId: LeaseId,
                                cancellationToken: cancellationToken);
                        }

                        return Response.FromValue(
                            response.ToFileLeaseReleaseInfo(),
                            response.GetRawResponse());
                    }
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareLeaseClient));
                    scope.Dispose();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<ShareFileLease>> ChangeInternal(
            string proposedId,
            bool async,
            CancellationToken cancellationToken)
        {
            EnsureClient();
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareLeaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareLeaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(LeaseId)}: {LeaseId}\n" +
                    $"{nameof(proposedId)}: {proposedId}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareLeaseClient)}.{nameof(Change)}");

                try
                {
                    scope.Start();
                    Response<ShareFileLease> response;
                    if (FileClient != null)
                    {
                        ResponseWithHeaders<FileChangeLeaseHeaders> fileResponse;

                        if (async)
                        {
                            fileResponse = await FileClient.FileRestClient.ChangeLeaseAsync(
                                leaseId: LeaseId,
                                proposedLeaseId: proposedId,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            fileResponse = FileClient.FileRestClient.ChangeLease(
                                leaseId: LeaseId,
                                proposedLeaseId: proposedId,
                                cancellationToken: cancellationToken);
                        }

                        response = Response.FromValue(
                            fileResponse.ToShareFileLease(),
                            fileResponse.GetRawResponse());
                    }
                    else
                    {
                        ResponseWithHeaders<ShareChangeLeaseHeaders> shareResponse;

                        if (async)
                        {
                            shareResponse = await ShareClient.ShareRestClient.ChangeLeaseAsync(
                                leaseId: LeaseId,
                                proposedLeaseId: proposedId,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            shareResponse = ShareClient.ShareRestClient.ChangeLease(
                                leaseId: LeaseId,
                                proposedLeaseId: proposedId,
                                cancellationToken: cancellationToken);
                        }

                        response = Response.FromValue(
                            shareResponse.ToShareFileLease(),
                            shareResponse.GetRawResponse());
                    }

                    LeaseId = response.Value.LeaseId;
                    return response;
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareLeaseClient));
                    scope.Dispose();
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<ShareFileLease>> BreakInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            EnsureClient();
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareLeaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareLeaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(LeaseId)}: {LeaseId}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareLeaseClient)}.{nameof(Break)}");

                try
                {
                    scope.Start();

                    if (FileClient != null)
                    {
                        ResponseWithHeaders<FileBreakLeaseHeaders> response;

                        if (async)
                        {
                            response = await FileClient.FileRestClient.BreakLeaseAsync(
                                shareFileRequestConditions: null,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            response = FileClient.FileRestClient.BreakLease(
                                shareFileRequestConditions: null,
                                cancellationToken: cancellationToken);
                        }

                        return Response.FromValue(
                            response.ToShareFileLease(),
                            response.GetRawResponse());
                    }
                    else
                    {
                        ResponseWithHeaders<ShareBreakLeaseHeaders> response;

                        if (async)
                        {
                            response = await ShareClient.ShareRestClient.BreakLeaseAsync(
                                breakPeriod: null,
                                shareFileRequestConditions: null,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            response = ShareClient.ShareRestClient.BreakLease(
                                breakPeriod: null,
                                shareFileRequestConditions: null,
                                cancellationToken: cancellationToken);
                        }

                        return Response.FromValue(
                            response.ToShareFileLease(),
                            response.GetRawResponse());
                    }
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareLeaseClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Break

        #region Renew
        /// <summary>
        /// The <see cref="Renew"/> operation renews the
        /// shares's previously-acquired lease.  This API does not
        /// support files.
        ///
        /// The lease can be renewed if the leaseId
        /// matches that associated with the share.  Note that the
        /// lease may be renewed even if it has expired as long as the share
        /// has not been leased again since the expiration of that
        /// lease.  When you renew a lease, the lease duration clock resets.
        ///
        /// </summary>
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<ShareFileLease> Renew(
            CancellationToken cancellationToken = default) =>
            RenewInternal(
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="RenewAsync"/> operation renews the
        /// shares's previously-acquired lease.  This API does not
        /// support files.
        ///
        /// The lease can be renewed if the leaseId
        /// matches that associated with the share.  Note that the
        /// lease may be renewed even if it has expired as long as the share
        /// has not been leased again since the expiration of that
        /// lease.  When you renew a lease, the lease duration clock resets.
        ///
        /// </summary>
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<ShareFileLease>> RenewAsync(
            CancellationToken cancellationToken = default) =>
            await RenewInternal(
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="RenewInternal"/> operation renews the
        /// shares's previously-acquired lease.  This API does not
        /// support files.
        ///
        /// The lease can be renewed if the leaseId
        /// matches that associated with the share.  Note that the
        /// lease may be renewed even if it has expired as long as the share
        /// has not been leased again since the expiration of that
        /// lease.  When you renew a lease, the lease duration clock resets.
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
        /// A <see cref="Response{FileLease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<ShareFileLease>> RenewInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            EnsureClient();
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(ShareLeaseClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(ShareLeaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(LeaseId)}: {LeaseId}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareLeaseClient)}.{nameof(Renew)}");

                try
                {
                    scope.Start();
                    Response<ShareFileLease> response;
                    if (FileClient != null)
                    {
                        throw new InvalidOperationException($"{nameof(Renew)} only supports Share Leases");
                    }
                    else
                    {
                        ResponseWithHeaders<ShareRenewLeaseHeaders> shareResponse;

                        if (async)
                        {
                            shareResponse = await ShareClient.ShareRestClient.RenewLeaseAsync(
                                leaseId: LeaseId,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            shareResponse = ShareClient.ShareRestClient.RenewLease(
                                leaseId: LeaseId,
                                cancellationToken: cancellationToken);
                        }

                        response = Response.FromValue(
                            shareResponse.ToShareFileLease(),
                            shareResponse.GetRawResponse());
                    }

                    LeaseId = response.Value.LeaseId;
                    return response;
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(ShareLeaseClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Renew
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

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareLeaseClient"/> class.
        /// </summary>
        /// <param name="client">
        /// A <see cref="ShareClient"/> representing the share being leased.
        /// </param>
        /// <param name="leaseId">
        /// An optional lease ID.  If no lease ID is provided, a random lease
        /// ID will be created.
        /// </param>
        public static ShareLeaseClient GetShareLeaseClient(
            this ShareClient client,
            string leaseId = null) =>
            new ShareLeaseClient(client, leaseId);
    }
}
