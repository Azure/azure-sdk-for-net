//-----------------------------------------------------------------------
// <copyright file="CloudBlobSharedImpl.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Blob
{
    using Microsoft.WindowsAzure.Storage.Blob.Protocol;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Net;

    internal static class CloudBlobSharedImpl
    {
        /// <summary>
        /// Called when the asynchronous operation to commit the blob started by UploadFromStream finishes.
        /// </summary>
        /// <param name="result">The result of the asynchronous operation.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool threads.")]
        internal static void BlobOutputStreamCommitCallback(IAsyncResult result)
        {
            StorageAsyncResult<NullType> storageAsyncResult = (StorageAsyncResult<NullType>)result.AsyncState;
            CloudBlobStream blobStream = (CloudBlobStream)storageAsyncResult.OperationState;
            storageAsyncResult.UpdateCompletedSynchronously(result.CompletedSynchronously);

            try
            {
                blobStream.EndCommit(result);
                blobStream.Dispose();
                storageAsyncResult.OnComplete();
            }
            catch (Exception e)
            {
                storageAsyncResult.OnComplete(e);
            }
        }

        /// <summary>
        /// Implements getting the stream without specifying a range.
        /// </summary>
        /// <param name="blob">The blob.</param>
        /// <param name="attributes">The attributes.</param>
        /// <param name="destStream">The destination stream.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="length">The length.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <returns>
        /// A <see cref="RESTCommand{T}" /> that gets the stream.
        /// </returns>
        internal static RESTCommand<NullType> GetBlobImpl(ICloudBlob blob, BlobAttributes attributes, Stream destStream, long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options)
        {
            string lockedETag = null;
            AccessCondition lockedAccessCondition = null;

            bool isRangeGet = offset.HasValue;
            bool arePropertiesPopulated = false;
            string storedMD5 = null;

            long startingOffset = offset.HasValue ? offset.Value : 0;
            long? startingLength = length;
            long? validateLength = null;

            RESTCommand<NullType> getCmd = new RESTCommand<NullType>(blob.ServiceClient.Credentials, attributes.Uri);

            getCmd.ApplyRequestOptions(options);
            getCmd.RetrieveResponseStream = true;
            getCmd.DestinationStream = destStream;
            getCmd.CalculateMd5ForResponseStream = !options.DisableContentMD5Validation.Value;
            getCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) =>
                BlobHttpWebRequestFactory.Get(uri, serverTimeout, attributes.SnapshotTime, offset, length, options.UseTransactionalMD5.Value, accessCondition, ctx);
            getCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            getCmd.RecoveryAction = (cmd, ex, ctx) =>
            {
                if ((lockedAccessCondition == null) && !string.IsNullOrEmpty(lockedETag))
                {
                    lockedAccessCondition = AccessCondition.GenerateIfMatchCondition(lockedETag);
                    if (accessCondition != null)
                    {
                        lockedAccessCondition.LeaseId = accessCondition.LeaseId;
                    }
                }

                if (cmd.StreamCopyState != null)
                {
                    offset = startingOffset + cmd.StreamCopyState.Length;
                    if (startingLength.HasValue)
                    {
                        length = startingLength.Value - cmd.StreamCopyState.Length;
                    }
                }

                getCmd.BuildRequestDelegate = (uri, builder, serverTimeout, context) =>
                    BlobHttpWebRequestFactory.Get(uri, serverTimeout, attributes.SnapshotTime, offset, length, options.UseTransactionalMD5.Value && !arePropertiesPopulated, lockedAccessCondition ?? accessCondition, context);
            };

            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(offset.HasValue ? HttpStatusCode.PartialContent : HttpStatusCode.OK, resp, NullType.Value, cmd, ex);

                if (!arePropertiesPopulated)
                {
                    CloudBlobSharedImpl.UpdateAfterFetchAttributes(attributes, resp, isRangeGet);
                    storedMD5 = resp.Headers[HttpResponseHeader.ContentMd5];

                    if (!options.DisableContentMD5Validation.Value &&
                        options.UseTransactionalMD5.Value &&
                        string.IsNullOrEmpty(storedMD5))
                    {
                        throw new StorageException(
                            cmd.CurrentResult,
                            SR.MD5NotPresentError,
                            null)
                        {
                            IsRetryable = false
                        };
                    }

                    lockedETag = attributes.Properties.ETag;
                    if (resp.ContentLength >= 0)
                    {
                        validateLength = resp.ContentLength;
                    }

                    arePropertiesPopulated = true;
                }

                return NullType.Value;
            };

            getCmd.PostProcessResponse = (cmd, resp, ctx) =>
            {
                HttpResponseParsers.ValidateResponseStreamMd5AndLength(validateLength, storedMD5, cmd);
                return NullType.Value;
            };

            return getCmd;
        }

        /// <summary>
        /// Implements the FetchAttributes method. The attributes are updated immediately.
        /// </summary>
        /// <param name="blob">The blob.</param>
        /// <param name="attributes">The attributes.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <returns>
        /// A <see cref="RESTCommand{T}" /> that fetches the attributes.
        /// </returns>
        internal static RESTCommand<NullType> FetchAttributesImpl(ICloudBlob blob, BlobAttributes attributes, AccessCondition accessCondition, BlobRequestOptions options)
        {
            RESTCommand<NullType> getCmd = new RESTCommand<NullType>(blob.ServiceClient.Credentials, attributes.Uri);

            getCmd.ApplyRequestOptions(options);
            getCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.GetProperties(uri, serverTimeout, attributes.SnapshotTime, accessCondition, ctx);
            getCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, NullType.Value, cmd, ex);
                CloudBlobSharedImpl.UpdateAfterFetchAttributes(attributes, resp, false);
                return NullType.Value;
            };

            return getCmd;
        }

        /// <summary>
        /// Implementation for the Exists method.
        /// </summary>
        /// <param name="blob">The blob.</param>
        /// <param name="attributes">The attributes.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <returns>
        /// A <see cref="RESTCommand{T}" /> that checks existence.
        /// </returns>
        internal static RESTCommand<bool> ExistsImpl(ICloudBlob blob, BlobAttributes attributes, BlobRequestOptions options)
        {
            RESTCommand<bool> getCmd = new RESTCommand<bool>(blob.ServiceClient.Credentials, attributes.Uri);

            getCmd.ApplyRequestOptions(options);
            getCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.GetProperties(uri, serverTimeout, attributes.SnapshotTime, null /* accessCondition */, ctx);
            getCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                if (resp.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, true, cmd, ex);
                CloudBlobSharedImpl.UpdateAfterFetchAttributes(attributes, resp, false);
                return true;
            };

            return getCmd;
        }

        /// <summary>
        /// Implementation for the SetMetadata method.
        /// </summary>
        /// <param name="blob">The blob.</param>
        /// <param name="attributes">The attributes.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <returns>
        /// A <see cref="RESTCommand{T}" /> that sets the metadata.
        /// </returns>
        internal static RESTCommand<NullType> SetMetadataImpl(ICloudBlob blob, BlobAttributes attributes, AccessCondition accessCondition, BlobRequestOptions options)
        {
            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(blob.ServiceClient.Credentials, attributes.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.SetMetadata(uri, serverTimeout, accessCondition, ctx);
            putCmd.SetHeaders = (r, ctx) => BlobHttpWebRequestFactory.AddMetadata(r, attributes.Metadata);
            putCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, NullType.Value, cmd, ex);
                CloudBlobSharedImpl.UpdateETagLMTAndSequenceNumber(attributes, resp);
                return NullType.Value;
            };

            return putCmd;
        }

        /// <summary>
        /// Implementation for the SetProperties method.
        /// </summary>
        /// <param name="blob">The blob.</param>
        /// <param name="attributes">The attributes.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <returns>
        /// A <see cref="RESTCommand{T}" /> that sets the properties.
        /// </returns>
        internal static RESTCommand<NullType> SetPropertiesImpl(ICloudBlob blob, BlobAttributes attributes, AccessCondition accessCondition, BlobRequestOptions options)
        {
            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(blob.ServiceClient.Credentials, attributes.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.SetProperties(uri, serverTimeout, attributes.Properties, accessCondition, ctx);
            putCmd.SetHeaders = (r, ctx) => BlobHttpWebRequestFactory.AddMetadata(r, attributes.Metadata);
            putCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, NullType.Value, cmd, ex);
                CloudBlobSharedImpl.UpdateETagLMTAndSequenceNumber(attributes, resp);
                return NullType.Value;
            };

            return putCmd;
        }

        /// <summary>
        /// Implements the DeleteBlob method.
        /// </summary>
        /// <param name="blob">The blob.</param>
        /// <param name="attributes">The attributes.</param>
        /// <param name="deleteSnapshotsOption">Whether to only delete the blob, to delete the blob and all snapshots, or to only delete the snapshots.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <returns>
        /// A <see cref="RESTCommand{T}" /> that deletes the blob.
        /// </returns>
        internal static RESTCommand<NullType> DeleteBlobImpl(ICloudBlob blob, BlobAttributes attributes, DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options)
        {
            RESTCommand<NullType> deleteCmd = new RESTCommand<NullType>(blob.ServiceClient.Credentials, attributes.Uri);

            deleteCmd.ApplyRequestOptions(options);
            deleteCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.Delete(uri, serverTimeout, attributes.SnapshotTime, deleteSnapshotsOption, accessCondition, ctx);
            deleteCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            deleteCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Accepted, resp, NullType.Value, cmd, ex);

            return deleteCmd;
        }

        /// <summary>
        /// Generates a <see cref="RESTCommand{T}" /> for acquiring a lease.
        /// </summary>
        /// <param name="blob">The blob.</param>
        /// <param name="attributes">The attributes.</param>
        /// <param name="leaseTime">A <see cref="TimeSpan" /> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If null, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <returns>
        /// A <see cref="RESTCommand{T}" /> implementing the acquire lease operation.
        /// </returns>
        internal static RESTCommand<string> AcquireLeaseImpl(ICloudBlob blob, BlobAttributes attributes, TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options)
        {
            int leaseDuration = -1;
            if (leaseTime.HasValue)
            {
                CommonUtility.AssertInBounds("leaseTime", leaseTime.Value, TimeSpan.FromSeconds(1), TimeSpan.MaxValue);
                leaseDuration = (int)leaseTime.Value.TotalSeconds;
            }

            RESTCommand<string> putCmd = new RESTCommand<string>(blob.ServiceClient.Credentials, attributes.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.Lease(uri, serverTimeout, LeaseAction.Acquire, proposedLeaseId, leaseDuration, null /* leaseBreakPeriod */, accessCondition, ctx);
            putCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Created, resp, null, cmd, ex);
                return BlobHttpResponseParsers.GetLeaseId(resp);
            };

            return putCmd;
        }

        /// <summary>
        /// Generates a <see cref="RESTCommand{T}" /> for renewing a lease.
        /// </summary>
        /// <param name="blob">The blob.</param>
        /// <param name="attributes">The attributes.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <returns>
        /// A <see cref="RESTCommand{T}" /> implementing the renew lease operation.
        /// </returns>
        /// <exception cref="System.ArgumentException">accessCondition</exception>
        internal static RESTCommand<NullType> RenewLeaseImpl(ICloudBlob blob, BlobAttributes attributes, AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtility.AssertNotNull("accessCondition", accessCondition);
            if (accessCondition.LeaseId == null)
            {
                throw new ArgumentException(SR.MissingLeaseIDRenewing, "accessCondition");
            }

            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(blob.ServiceClient.Credentials, attributes.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.Lease(uri, serverTimeout, LeaseAction.Renew, null /* proposedLeaseId */, null /* leaseDuration */, null /* leaseBreakPeriod */, accessCondition, ctx);
            putCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, NullType.Value, cmd, ex);

            return putCmd;
        }

        /// <summary>
        /// Generates a <see cref="RESTCommand{T}" /> for changing a lease ID.
        /// </summary>
        /// <param name="blob">The blob.</param>
        /// <param name="attributes">The attributes.</param>
        /// <param name="proposedLeaseId">The proposed new lease ID.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <returns>
        /// A <see cref="RESTCommand{T}" /> implementing the change lease ID operation.
        /// </returns>
        /// <exception cref="System.ArgumentException">accessCondition</exception>
        internal static RESTCommand<string> ChangeLeaseImpl(ICloudBlob blob, BlobAttributes attributes, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtility.AssertNotNull("accessCondition", accessCondition);
            CommonUtility.AssertNotNull("proposedLeaseId", proposedLeaseId);
            if (accessCondition.LeaseId == null)
            {
                throw new ArgumentException(SR.MissingLeaseIDChanging, "accessCondition");
            }

            RESTCommand<string> putCmd = new RESTCommand<string>(blob.ServiceClient.Credentials, attributes.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.Lease(uri, serverTimeout, LeaseAction.Change, proposedLeaseId, null /* leaseDuration */, null /* leaseBreakPeriod */, accessCondition, ctx);
            putCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, null /* retVal */, cmd, ex);
                return BlobHttpResponseParsers.GetLeaseId(resp);
            };

            return putCmd;
        }

        /// <summary>
        /// Generates a <see cref="RESTCommand{T}" /> for releasing a lease.
        /// </summary>
        /// <param name="blob">The blob.</param>
        /// <param name="attributes">The attributes.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <returns>
        /// A <see cref="RESTCommand{T}" /> implementing the release lease operation.
        /// </returns>
        /// <exception cref="System.ArgumentException">accessCondition</exception>
        internal static RESTCommand<NullType> ReleaseLeaseImpl(ICloudBlob blob, BlobAttributes attributes, AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtility.AssertNotNull("accessCondition", accessCondition);
            if (accessCondition.LeaseId == null)
            {
                throw new ArgumentException(SR.MissingLeaseIDReleasing, "accessCondition");
            }

            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(blob.ServiceClient.Credentials, attributes.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.Lease(uri, serverTimeout, LeaseAction.Release, null /* proposedLeaseId */, null /* leaseDuration */, null /* leaseBreakPeriod */, accessCondition, ctx);
            putCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, NullType.Value, cmd, ex);

            return putCmd;
        }

        /// <summary>
        /// Generates a <see cref="RESTCommand{T}" /> for breaking a lease.
        /// </summary>
        /// <param name="blob">The blob.</param>
        /// <param name="attributes">The attributes.</param>
        /// <param name="breakPeriod">The amount of time to allow the lease to remain, rounded down to seconds.
        /// If null, the break period is the remainder of the current lease, or zero for infinite leases.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <returns>
        /// A <see cref="RESTCommand{T}" /> implementing the break lease operation.
        /// </returns>
        internal static RESTCommand<TimeSpan> BreakLeaseImpl(ICloudBlob blob, BlobAttributes attributes, TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options)
        {
            int? breakSeconds = null;
            if (breakPeriod.HasValue)
            {
                CommonUtility.AssertInBounds("breakPeriod", breakPeriod.Value, TimeSpan.Zero, TimeSpan.MaxValue);
                breakSeconds = (int)breakPeriod.Value.TotalSeconds;
            }

            RESTCommand<TimeSpan> putCmd = new RESTCommand<TimeSpan>(blob.ServiceClient.Credentials, attributes.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.Lease(uri, serverTimeout, LeaseAction.Break, null /* proposedLeaseId */, null /* leaseDuration */, breakSeconds, accessCondition, ctx);
            putCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Accepted, resp, TimeSpan.Zero, cmd, ex);

                int? remainingLeaseTime = BlobHttpResponseParsers.GetRemainingLeaseTime(resp);
                if (!remainingLeaseTime.HasValue)
                {
                    // Unexpected result from service.
                    throw new StorageException(cmd.CurrentResult, SR.LeaseTimeNotReceived, null /* inner */);
                }

                return TimeSpan.FromSeconds(remainingLeaseTime.Value);
            };

            return putCmd;
        }

        /// <summary>
        /// Implementation of the StartCopyFromBlob method. Result is a BlobAttributes object derived from the response headers.
        /// </summary>
        /// <param name="blob">The blob.</param>
        /// <param name="attributes">The attributes.</param>
        /// <param name="source">The URI of the source blob.</param>
        /// <param name="sourceAccessCondition">An object that represents the access conditions for the source blob. If null, no condition is used.</param>
        /// <param name="destAccessCondition">An object that represents the access conditions for the destination blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <returns>
        /// A <see cref="RESTCommand{T}" /> that starts to copy the blob.
        /// </returns>
        /// <exception cref="System.ArgumentException">sourceAccessCondition</exception>
        internal static RESTCommand<string> StartCopyFromBlobImpl(ICloudBlob blob, BlobAttributes attributes, Uri source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options)
        {
            if (sourceAccessCondition != null && !string.IsNullOrEmpty(sourceAccessCondition.LeaseId))
            {
                throw new ArgumentException(SR.LeaseConditionOnSource, "sourceAccessCondition");
            }

            RESTCommand<string> putCmd = new RESTCommand<string>(blob.ServiceClient.Credentials, attributes.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.CopyFrom(uri, serverTimeout, source, sourceAccessCondition, destAccessCondition, ctx);
            putCmd.SetHeaders = (r, ctx) => BlobHttpWebRequestFactory.AddMetadata(r, attributes.Metadata);
            putCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Accepted, resp, null /* retVal */, cmd, ex);
                CopyState state = BlobHttpResponseParsers.GetCopyAttributes(resp);
                attributes.Properties = BlobHttpResponseParsers.GetProperties(resp);
                attributes.Metadata = BlobHttpResponseParsers.GetMetadata(resp);
                attributes.CopyState = state;
                return state.CopyId;
            };

            return putCmd;
        }

        /// <summary>
        /// Implementation of the AbortCopy method. No result is produced.
        /// </summary>
        /// <param name="blob">The blob.</param>
        /// <param name="attributes">The attributes.</param>
        /// <param name="copyId">The copy ID of the copy operation to abort.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the operation. If null, no condition is used.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <returns>
        /// A <see cref="RESTCommand{T}" /> that aborts the copy.
        /// </returns>
        internal static RESTCommand<NullType> AbortCopyImpl(ICloudBlob blob, BlobAttributes attributes, string copyId, AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtility.AssertNotNull("copyId", copyId);

            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(blob.ServiceClient.Credentials, attributes.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.AbortCopy(uri, serverTimeout, copyId, accessCondition, ctx);
            putCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.NoContent, resp, NullType.Value, cmd, ex);
            
            return putCmd;
        }

        /// <summary>
        /// Updates this blob with the given attributes at the end of a fetch attributes operation.
        /// </summary>
        /// <param name="attributes">The new attributes.</param>
        /// <param name="response">The response.</param>
        /// <param name="ignoreMD5">if set to <c>true</c>, blob's MD5 will not be updated.</param>
        /// <exception cref="System.InvalidOperationException"></exception>
        internal static void UpdateAfterFetchAttributes(BlobAttributes attributes, HttpWebResponse response, bool ignoreMD5)
        {
            BlobProperties properties = BlobHttpResponseParsers.GetProperties(response);

            // If BlobType is specified and the value returned from cloud is different, 
            // then it's a client error and we need to throw.
            if (attributes.Properties.BlobType != BlobType.Unspecified && attributes.Properties.BlobType != properties.BlobType)
            {
                throw new InvalidOperationException(SR.BlobTypeMismatch);
            }

            if (ignoreMD5)
            {
                properties.ContentMD5 = attributes.Properties.ContentMD5;
            }

            attributes.Properties = properties;
            attributes.Metadata = BlobHttpResponseParsers.GetMetadata(response);
            attributes.CopyState = BlobHttpResponseParsers.GetCopyAttributes(response);
        }

        /// <summary>
        /// Retrieve ETag, LMT, and Sequence-Number from response.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <param name="response">The response to parse.</param>
        internal static void UpdateETagLMTAndSequenceNumber(BlobAttributes attributes, HttpWebResponse response)
        {
            BlobProperties parsedProperties = BlobHttpResponseParsers.GetProperties(response);
            attributes.Properties.ETag = parsedProperties.ETag ?? attributes.Properties.ETag;
            attributes.Properties.LastModified = parsedProperties.LastModified ?? attributes.Properties.LastModified;
            attributes.Properties.PageBlobSequenceNumber = parsedProperties.PageBlobSequenceNumber ?? attributes.Properties.PageBlobSequenceNumber;
            if (parsedProperties.Length > 0)
            {
                attributes.Properties.Length = parsedProperties.Length;
            }
        }

        /// <summary>
        /// Converts the source blob of a copy operation to an appropriate access URI, taking Shared Access Signature credentials into account.
        /// </summary>
        /// <param name="source">The source blob.</param>
        /// <returns>A URI addressing the source blob, using SAS if appropriate.</returns>
        internal static Uri SourceBlobToUri(ICloudBlob source)
        {
            CommonUtility.AssertNotNull("source", source);
            return source.ServiceClient.Credentials.TransformUri(source.SnapshotQualifiedUri);
        }
    }
}
