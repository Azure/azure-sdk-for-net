// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
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

        /// <summary>
        /// Gets the Lease ID for this lease.
        /// </summary>
        public virtual string LeaseId { get; private set; }

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        private HttpPipeline Pipeline => FileClient?.Pipeline ?? ShareClient?.Pipeline;

        /// <summary>
        /// The version of the service to use when sending requests.
        /// </summary>
        internal virtual ShareClientOptions.ServiceVersion Version => FileClient?.Version ?? ShareClient.Version;

        /// <summary>
        /// The <see cref="ClientDiagnostics"/> instance used to create diagnostic scopes
        /// every request.
        /// </summary>
        internal virtual ClientDiagnostics ClientDiagnostics => FileClient?.ClientDiagnostics ?? ShareClient?.ClientDiagnostics;

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
        internal ShareLeaseClient(ShareClient client, string leaseId = null)
        {
            _share = client ?? throw Errors.ArgumentNull(nameof(client));
            LeaseId = leaseId ?? CreateUniqueLeaseId();
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
        /// </remarks>
        private async Task<Response<ShareFileLease>> AcquireInternal(
            TimeSpan? duration,
            bool async,
            CancellationToken cancellationToken)
        {
            EnsureClient();
            using (Pipeline.BeginLoggingScope(nameof(ShareLeaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareLeaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(LeaseId)}: {LeaseId}\n");
                try
                {
                    if (FileClient != null)
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

                        return await FileRestClient.Share.AcquireLeaseAsync(
                            ClientDiagnostics,
                            Pipeline,
                            Uri,
                            Version.ToVersionString(),
                            duration: serviceDuration,
                            proposedLeaseId: LeaseId,
                            async: async,
                            operationName: $"{nameof(ShareLeaseClient)}.{nameof(Acquire)}",
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
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
            EnsureClient();
            using (Pipeline.BeginLoggingScope(nameof(ShareLeaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareLeaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(LeaseId)}: {LeaseId}");
                try
                {
                    if (FileClient != null)
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
                    else
                    {
                        return await FileRestClient.Share.ReleaseLeaseAsync(
                            ClientDiagnostics,
                            Pipeline,
                            Uri,
                            LeaseId,
                            Version.ToVersionString(),
                            async: async,
                            operationName: $"{nameof(ShareLeaseClient)}.{nameof(Release)}",
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
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
            EnsureClient();
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
                    if (FileClient != null)
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
                    else
                    {
                        return await FileRestClient.Share.ChangeLeaseAsync(
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
            EnsureClient();
            using (Pipeline.BeginLoggingScope(nameof(ShareLeaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareLeaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(LeaseId)}: {LeaseId}");
                try
                {
                    if (FileClient != null)
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
                    else
                    {
                        return (await FileRestClient.Share.BreakLeaseAsync(
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
        /// </remarks>
        private async Task<Response<ShareFileLease>> RenewInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            EnsureClient();
            using (Pipeline.BeginLoggingScope(nameof(ShareLeaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(ShareLeaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(LeaseId)}: {LeaseId}");
                try
                {
                    if (FileClient != null)
                    {
                        throw new InvalidOperationException($"{nameof(Renew)} only supports Share Leases");
                    }
                    else
                    {
                        return await FileRestClient.Share.RenewLeaseAsync(
                            ClientDiagnostics,
                            Pipeline,
                            Uri,
                            LeaseId,
                            Version.ToVersionString(),
                            async: async,
                            operationName: $"{nameof(ShareLeaseClient)}.{nameof(Renew)}",
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
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
