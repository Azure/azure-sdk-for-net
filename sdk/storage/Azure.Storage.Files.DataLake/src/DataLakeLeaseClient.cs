// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    /// <summary>
    /// The <see cref="DataLakeLeaseClient"/> allows you to manipulate Azure
    /// Storage leases on paths.
    /// </summary>
    public class DataLakeLeaseClient
    {
        /// <summary>
        /// Blob lease client for managing leases.
        /// </summary>
        private readonly BlobLeaseClient _blobLeaseClient;

        /// <summary>
        /// The <see cref="TimeSpan"/> representing an infinite lease duration.
        /// </summary>
        public static readonly TimeSpan InfiniteLeaseDuration = TimeSpan.FromSeconds(Constants.Blob.Lease.InfiniteLeaseDuration);

        /// <summary>
        /// Gets the URI of the object being leased.
        /// </summary>
        public Uri Uri => _blobLeaseClient.Uri;

        /// <summary>
        /// Gets the Lease ID for this lease.
        /// </summary>
        public virtual string LeaseId => _blobLeaseClient.LeaseId;

        /// <summary>
        /// The <see cref="ClientDiagnostics"/> instance used to create diagnostic scopes
        /// every request.
        /// </summary>
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// The <see cref="ClientDiagnostics"/> instance used to create diagnostic scopes
        /// every request.
        /// </summary>
        internal virtual ClientDiagnostics ClientDiagnostics => _clientDiagnostics;

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeLeaseClient"/> class
        /// for mocking.
        /// </summary>
        protected DataLakeLeaseClient()
        {
            _blobLeaseClient = null;
            _clientDiagnostics = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeLeaseClient"/>  class.
        /// </summary>
        /// <param name="client">
        /// A <see cref="BlobClient"/> representing the blob being leased.
        /// </param>
        /// <param name="leaseId">
        /// An optional lease ID.  If no lease ID is provided, a random lease
        /// ID will be created.
        /// </param>
        public DataLakeLeaseClient(DataLakePathClient client, string leaseId = null)
        {
            _blobLeaseClient = new BlobLeaseClient(client.BlobClient, leaseId);
            _clientDiagnostics = client.ClientConfiguration.ClientDiagnostics;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeLeaseClient"/>  class.
        /// </summary>
        /// <param name="client">
        /// A <see cref="DataLakeFileSystemClient"/> representing the file system
        /// being leased.
        /// </param>
        /// <param name="leaseId">
        /// An optional lease ID.  If no lease ID is provided, a random lease
        /// ID will be created.
        /// </param>
        public DataLakeLeaseClient(DataLakeFileSystemClient client, string leaseId = null)
        {
            _blobLeaseClient = new BlobLeaseClient(client.ContainerClient, leaseId);
            _clientDiagnostics = client.ClientConfiguration.ClientDiagnostics;
        }
        #endregion ctors

        #region Acquire
        /// <summary>
        /// The <see cref="Acquire"/> operation acquires a lease on
        /// the path or file system.  The lease <paramref name="duration"/> must
        /// be between 15 to 60 seconds, or infinite (-1).
        ///
        /// If the file system does not have an active lease, the Data Lake service
        /// creates a lease on the path or file system and returns it.  If the
        /// file system has an active lease, you can only request a new lease
        /// using the active lease ID as <see cref="LeaseId"/>, but you can
        /// specify a new <paramref name="duration"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="duration">
        /// Specifies the duration of the lease, in seconds, or specify
        /// <see cref="InfiniteLeaseDuration"/> for a lease that never expires.
        /// A non-infinite lease can be between 15 and 60 seconds.
        /// A lease duration cannot be changed using <see cref="RenewAsync"/> or <see cref="ChangeAsync"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="RequestConditions"/> to add
        /// conditions on acquiring a lease.
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
        public virtual Response<DataLakeLease> Acquire(
            TimeSpan duration,
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeLeaseClient)}.{nameof(Acquire)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobLease> response = _blobLeaseClient.Acquire(
                    duration,
                    conditions,
                    cancellationToken);

                return Response.FromValue(
                    response.Value.ToDataLakeLease(),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="AcquireAsync"/> operation acquires a lease on
        /// the path or file system.  The lease <paramref name="duration"/> must
        /// be between 15 to 60 seconds, or infinite (-1).
        ///
        /// If the file system does not have an active lease, the Data Lake service
        /// creates a lease on the file system or path and returns it.  If the
        /// file system has an active lease, you can only request a new lease
        /// using the active lease ID as <see cref="LeaseId"/>, but you can
        /// specify a new <paramref name="duration"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="duration">
        /// Specifies the duration of the lease, in seconds, or specify
        /// <see cref="InfiniteLeaseDuration"/> for a lease that never expires.
        /// A non-infinite lease can be between 15 and 60 seconds.
        /// A lease duration cannot be changed using <see cref="RenewAsync"/> or <see cref="ChangeAsync"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="RequestConditions"/> to add
        /// conditions on acquiring a lease.
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
        public virtual async Task<Response<DataLakeLease>> AcquireAsync(
            TimeSpan duration,
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeLeaseClient)}.{nameof(Acquire)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobLease> response = await _blobLeaseClient.AcquireAsync(
                    duration,
                    conditions,
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    response.Value.ToDataLakeLease(),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion Acquire

        #region Renew
        /// <summary>
        /// The <see cref="Renew"/> operation renews the path or
        /// file system's previously-acquired lease.
        ///
        /// The lease can be renewed if the leaseId
        /// matches that associated with the path or file system.  Note that the
        /// lease may be renewed even if it has expired as long as the path or
        /// file system has not been leased again since the expiration of that
        /// lease.  When you renew a lease, the lease duration clock resets.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="RequestConditions"/> to add
        /// conditions on acquiring a lease.
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
        public virtual Response<DataLakeLease> Renew(
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeLeaseClient)}.{nameof(Renew)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobLease> response = _blobLeaseClient.Renew(
                    conditions,
                    cancellationToken);

                return Response.FromValue(
                    response.Value.ToDataLakeLease(),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="RenewAsync"/> operation renews the path or
        /// file system's previously-acquired lease.
        ///
        /// The lease can be renewed if the leaseId
        /// matches that associated with the path or file system.  Note that the
        /// lease may be renewed even if it has expired as long as the path or
        /// file system has not been leased again since the expiration of that
        /// lease.  When you renew a lease, the lease duration clock resets.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="RequestConditions"/> to add
        /// conditions on acquiring a lease.
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
        public virtual async Task<Response<DataLakeLease>> RenewAsync(
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeLeaseClient)}.{nameof(Renew)}");

            try
            {
                scope.Start();
                Response<Blobs.Models.BlobLease> response = await _blobLeaseClient.RenewAsync(
                    conditions,
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    response.Value.ToDataLakeLease(),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion Renew

        #region Release
        /// <summary>
        /// The <see cref="Release"/> operation releases the
        /// file system or path's previously-acquired lease.
        ///
        /// The lease may be released if the <see cref="LeaseId"/>
        /// matches that associated with the file system or path.  Releasing the
        /// lease allows another client to immediately acquire the lease for the
        /// file system or path as soon as the release is complete.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="RequestConditions"/> to add
        /// conditions on acquiring a lease.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ReleaseObjectLeaseInfo}"/> describing the
        /// updated path or file system.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<ReleasedObjectInfo> Release(
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeLeaseClient)}.{nameof(Release)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.ReleasedObjectInfo> response = _blobLeaseClient.Release(
                    conditions,
                    cancellationToken);

                return Response.FromValue(
                    new ReleasedObjectInfo(response.Value.ETag, response.Value.LastModified),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="ReleaseAsync"/> operation releases the
        /// file system or path's previously-acquired lease.
        ///
        /// The lease may be released if the <see cref="LeaseId"/>
        /// matches that associated with the file system or path.  Releasing the
        /// lease allows another client to immediately acquire the lease for the
        /// file system or path as soon as the release is complete.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="RequestConditions"/> to add
        /// conditions on acquiring a lease.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ReleasedObjectInfo}"/> describing the
        /// updated path or file system.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<ReleasedObjectInfo>> ReleaseAsync(
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeLeaseClient)}.{nameof(Release)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.ReleasedObjectInfo> response = await _blobLeaseClient.ReleaseAsync(
                    conditions,
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    new ReleasedObjectInfo(response.Value.ETag, response.Value.LastModified),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion Release

        #region Change
        /// <summary>
        /// The <see cref="Change"/> operation changes the lease
        /// of an active lease.  A change must include the current
        /// <see cref="LeaseId"/> and a new <paramref name="proposedId"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="proposedId">
        /// An optional proposed lease ID, in a GUID string format. A
        /// <see cref="RequestFailedException"/> will be thrown if the
        /// proposed lease ID is not in the correct format.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="RequestConditions"/> to add
        /// conditions on acquiring a lease.
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
        public virtual Response<DataLakeLease> Change(
            string proposedId,
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeLeaseClient)}.{nameof(Change)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobLease> response = _blobLeaseClient.Change(
                    proposedId,
                    conditions,
                    cancellationToken);

                return Response.FromValue(
                    response.Value.ToDataLakeLease(),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="ChangeAsync"/> operation changes the lease
        /// of an active lease.  A change must include the current
        /// <see cref="LeaseId"/> and a new <paramref name="proposedId"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="proposedId">
        /// An optional proposed lease ID, in a GUID string format. A
        /// <see cref="RequestFailedException"/> will be thrown if the
        /// proposed lease ID is not in the correct format.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="RequestConditions"/> to add
        /// conditions on acquiring a lease.
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
        public virtual async Task<Response<DataLakeLease>> ChangeAsync(
            string proposedId,
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeLeaseClient)}.{nameof(Change)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobLease> response = await _blobLeaseClient.ChangeAsync(
                    proposedId,
                    conditions,
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    response.Value.ToDataLakeLease(),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion Change

        #region Break
        /// <summary>
        /// The <see cref="Break"/> operation breaks the path or
        /// file system's previously-acquired lease (if it exists).
        ///
        /// Once a lease is broken, it cannot be renewed.  Any authorized
        /// request can break the lease; the request is not required to
        /// specify a matching lease ID.  When a lease is broken, the lease
        /// break <paramref name="breakPeriod"/> is allowed to elapse,
        /// during which time no lease operation except
        /// <see cref="Break"/> and <see cref="Release"/> can be
        /// performed on the path or file system.  When a lease is successfully
        /// broken, the response indicates the interval in seconds until a new
        /// lease can be acquired.
        ///
        /// A lease that has been broken can also be released.  A client can
        /// immediately acquire a path or file system lease that has been
        /// released.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="breakPeriod">
        /// Specifies the proposed duration the lease should continue before
        /// it is broken, in seconds, between 0 and 60.  This break period is
        /// only used if it is shorter than the time remaining on the lease.
        /// If longer, the time remaining on the lease is used.  A new lease
        /// will not be available before the break period has expired, but the
        /// lease may be held for longer than the break period.  If this value
        /// is not provided, a fixed-duration lease breaks after the remaining
        /// lease period elapses, and an infinite lease breaks immediately.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="RequestConditions"/> to add
        /// conditions on acquiring a lease.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the broken lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<DataLakeLease> Break(
            TimeSpan? breakPeriod = default,
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeLeaseClient)}.{nameof(Break)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobLease> response = _blobLeaseClient.Break(
                    breakPeriod,
                    conditions,
                    cancellationToken);

                return Response.FromValue(
                    response.Value.ToDataLakeLease(),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="BreakAsync"/> operation breaks the path or
        /// file system's previously-acquired lease (if it exists).
        ///
        /// Once a lease is broken, it cannot be renewed.  Any authorized
        /// request can break the lease; the request is not required to
        /// specify a matching lease ID.  When a lease is broken, the lease
        /// break <paramref name="breakPeriod"/> is allowed to elapse,
        /// during which time no lease operation except
        /// <see cref="BreakAsync"/> and <see cref="ReleaseAsync"/> can be
        /// performed on the path or file system.  When a lease is successfully
        /// broken, the response indicates the interval in seconds until a new
        /// lease can be acquired.
        ///
        /// A lease that has been broken can also be released.  A client can
        /// immediately acquire a path or file system lease that has been
        /// released.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="breakPeriod">
        /// Specifies the proposed duration the lease should continue before
        /// it is broken, in seconds, between 0 and 60.  This break period is
        /// only used if it is shorter than the time remaining on the lease.
        /// If longer, the time remaining on the lease is used.  A new lease
        /// will not be available before the break period has expired, but the
        /// lease may be held for longer than the break period.  If this value
        /// is not provided, a fixed-duration lease breaks after the remaining
        /// lease period elapses, and an infinite lease breaks immediately.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="RequestConditions"/> to add
        /// conditions on acquiring a lease.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the broken lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<DataLakeLease>> BreakAsync(
            TimeSpan? breakPeriod = default,
           RequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DataLakeLeaseClient)}.{nameof(Break)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobLease> response = await _blobLeaseClient.BreakAsync(
                    breakPeriod,
                    conditions,
                    cancellationToken).ConfigureAwait(false);

                return Response.FromValue(
                    response.Value.ToDataLakeLease(),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion Break
    }
}
