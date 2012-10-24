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
    using System;
    using System.IO;
    using System.Net;
    using Microsoft.WindowsAzure.Storage.Blob.Protocol;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    internal static class CloudBlobSharedImpl
    {
        /// <summary>
        /// Implements getting the stream without specifying a range.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="SynchronousTask"/> that gets the stream.</returns>
        internal static RESTCommand<NullType> GetBlobImpl(ICloudBlob blob, BlobAttributes attributes, Stream destStream, long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options)
        {
            string lockedETag = null;
            AccessCondition lockedAccessCondition = null;

            bool isRangeGet = offset.HasValue;
            bool arePropertiesPopulated = false;
            string storedMD5 = null;

            long startingOffset = offset.HasValue ? offset.Value : 0;
            long? startingLength = length;

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

                if (ctx.StreamCopyState != null)
                {
                    offset = startingOffset + ctx.StreamCopyState.Length;
                    if (startingLength.HasValue)
                    {
                        length = startingLength.Value - ctx.StreamCopyState.Length;
                    }
                }

                getCmd.BuildRequestDelegate = (uri, builder, serverTimeout, context) =>
                    BlobHttpWebRequestFactory.Get(uri, serverTimeout, attributes.SnapshotTime, offset, length, options.UseTransactionalMD5.Value && !arePropertiesPopulated, lockedAccessCondition ?? accessCondition, context);
            };

            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(offset.HasValue ? HttpStatusCode.PartialContent : HttpStatusCode.OK, resp, NullType.Value, cmd, ex, ctx);

                if (!arePropertiesPopulated)
                {
                    CloudBlobSharedImpl.UpdateAfterFetchAttributes(attributes, resp, isRangeGet);
                    storedMD5 = resp.Headers[HttpResponseHeader.ContentMd5];

                    if (!options.DisableContentMD5Validation.Value &&
                        options.UseTransactionalMD5.Value &&
                        string.IsNullOrEmpty(storedMD5))
                    {
                        throw new StorageException(
                            ctx.CurrentResult,
                            SR.MD5NotPresentError,
                            null)
                        {
                            IsRetryable = false
                        };
                    }

                    lockedETag = attributes.Properties.ETag;
                    arePropertiesPopulated = true;
                }

                return NullType.Value;
            };

            getCmd.PostProcessResponse = (cmd, resp, ex, ctx) =>
            {
                long validateLength = startingLength.HasValue ? startingLength.Value : (attributes.Properties.Length - startingOffset);
                HttpResponseParsers.ValidateResponseStreamMd5AndLength(validateLength, storedMD5, ctx);
                return NullType.Value;
            };

            return getCmd;
        }

        /// <summary>
        /// Implements the FetchAttributes method. The attributes are updated immediately.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that fetches the attributes.</returns>
        internal static RESTCommand<NullType> FetchAttributesImpl(ICloudBlob blob, BlobAttributes attributes, AccessCondition accessCondition, BlobRequestOptions options)
        {
            RESTCommand<NullType> getCmd = new RESTCommand<NullType>(blob.ServiceClient.Credentials, attributes.Uri);

            getCmd.ApplyRequestOptions(options);
            getCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.GetProperties(uri, serverTimeout, attributes.SnapshotTime, accessCondition, ctx);
            getCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, NullType.Value, cmd, ex, ctx);
                CloudBlobSharedImpl.UpdateAfterFetchAttributes(attributes, resp, false);
                return NullType.Value;
            };

            return getCmd;
        }

        /// <summary>
        /// Implementation for the Exists method.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that checks existence.</returns>
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

                if (resp.StatusCode == HttpStatusCode.PreconditionFailed)
                {
                    return true;
                }

                return HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, true, cmd, ex, ctx);
            };

            return getCmd;
        }

        /// <summary>
        /// Implementation for the SetMetadata method.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that sets the metadata.</returns>
        internal static RESTCommand<NullType> SetMetadataImpl(ICloudBlob blob, BlobAttributes attributes, AccessCondition accessCondition, BlobRequestOptions options)
        {
            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(blob.ServiceClient.Credentials, attributes.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.SetMetadata(uri, serverTimeout, accessCondition, ctx);
            putCmd.SetHeaders = (r, ctx) => BlobHttpWebRequestFactory.AddMetadata(r, attributes.Metadata);
            putCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, NullType.Value, cmd, ex, ctx);
                CloudBlobSharedImpl.ParseSizeAndLastModified(attributes, resp);
                return NullType.Value;
            };

            return putCmd;
        }

        /// <summary>
        /// Implementation for the SetProperties method.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that sets the metadata.</returns>
        internal static RESTCommand<NullType> SetPropertiesImpl(ICloudBlob blob, BlobAttributes attributes, AccessCondition accessCondition, BlobRequestOptions options)
        {
            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(blob.ServiceClient.Credentials, attributes.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.SetProperties(uri, serverTimeout, attributes.Properties, accessCondition, ctx);
            putCmd.SetHeaders = (r, ctx) => BlobHttpWebRequestFactory.AddMetadata(r, attributes.Metadata);
            putCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, NullType.Value, cmd, ex, ctx);
                CloudBlobSharedImpl.ParseSizeAndLastModified(attributes, resp);
                return NullType.Value;
            };

            return putCmd;
        }

        /// <summary>
        /// Implements the DeleteBlob method.
        /// </summary>
        /// <param name="deleteSnapshotsOption">Whether to only delete the blob, to delete the blob and all snapshots, or to only delete the snapshots.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that deletes the blob.</returns>
        internal static RESTCommand<NullType> DeleteBlobImpl(ICloudBlob blob, BlobAttributes attributes, DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options)
        {
            RESTCommand<NullType> deleteCmd = new RESTCommand<NullType>(blob.ServiceClient.Credentials, attributes.Uri);

            deleteCmd.ApplyRequestOptions(options);
            deleteCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.Delete(uri, serverTimeout, attributes.SnapshotTime, deleteSnapshotsOption, accessCondition, ctx);
            deleteCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            deleteCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Accepted, resp, NullType.Value, cmd, ex, ctx);

            return deleteCmd;
        }

        /// <summary>
        /// Generates a <see cref="RESTCommand"/> for acquiring a lease.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If null, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> implementing the acquire lease operation.</returns>
        internal static RESTCommand<string> AcquireLeaseImpl(ICloudBlob blob, BlobAttributes attributes, TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options)
        {
            int leaseDuration = -1;
            if (leaseTime.HasValue)
            {
                CommonUtils.AssertInBounds("leaseTime", leaseTime.Value, TimeSpan.FromSeconds(1), TimeSpan.MaxValue);
                leaseDuration = (int)leaseTime.Value.TotalSeconds;
            }

            RESTCommand<string> putCmd = new RESTCommand<string>(blob.ServiceClient.Credentials, attributes.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.Lease(uri, serverTimeout, LeaseAction.Acquire, proposedLeaseId, leaseDuration, null /* leaseBreakPeriod */, accessCondition, ctx);
            putCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Created, resp, null, cmd, ex, ctx);
                return BlobHttpResponseParsers.GetLeaseId(resp);
            };

            return putCmd;
        }

        /// <summary>
        /// Generates a <see cref="RESTCommand"/> for renewing a lease.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> implementing the renew lease operation.</returns>
        internal static RESTCommand<NullType> RenewLeaseImpl(ICloudBlob blob, BlobAttributes attributes, AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("accessCondition", accessCondition);
            if (accessCondition.LeaseId == null)
            {
                throw new ArgumentException(SR.MissingLeaseIDRenewing, "accessCondition");
            }

            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(blob.ServiceClient.Credentials, attributes.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.Lease(uri, serverTimeout, LeaseAction.Renew, null /* proposedLeaseId */, null /* leaseDuration */, null /* leaseBreakPeriod */, accessCondition, ctx);
            putCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, NullType.Value, cmd, ex, ctx);

            return putCmd;
        }

        /// <summary>
        /// Generates a <see cref="RESTCommand"/> for changing a lease ID.
        /// </summary>
        /// <param name="proposedLeaseId">The proposed new lease ID.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> implementing the change lease ID operation.</returns>
        internal static RESTCommand<string> ChangeLeaseImpl(ICloudBlob blob, BlobAttributes attributes, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("accessCondition", accessCondition);
            CommonUtils.AssertNotNull("proposedLeaseId", proposedLeaseId);
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
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, null /* retVal */, cmd, ex, ctx);
                return BlobHttpResponseParsers.GetLeaseId(resp);
            };

            return putCmd;
        }

        /// <summary>
        /// Generates a <see cref="RESTCommand"/> for releasing a lease.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> implementing the release lease operation.</returns>
        internal static RESTCommand<NullType> ReleaseLeaseImpl(ICloudBlob blob, BlobAttributes attributes, AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("accessCondition", accessCondition);
            if (accessCondition.LeaseId == null)
            {
                throw new ArgumentException(SR.MissingLeaseIDReleasing, "accessCondition");
            }

            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(blob.ServiceClient.Credentials, attributes.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.Lease(uri, serverTimeout, LeaseAction.Release, null /* proposedLeaseId */, null /* leaseDuration */, null /* leaseBreakPeriod */, accessCondition, ctx);
            putCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, NullType.Value, cmd, ex, ctx);

            return putCmd;
        }

        /// <summary>
        /// Generates a <see cref="RESTCommand"/> for breaking a lease.
        /// </summary>
        /// <param name="breakPeriod">The amount of time to allow the lease to remain, rounded down to seconds.
        /// If null, the break period is the remainder of the current lease, or zero for infinite leases.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> implementing the break lease operation.</returns>
        internal static RESTCommand<TimeSpan> BreakLeaseImpl(ICloudBlob blob, BlobAttributes attributes, TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options)
        {
            int? breakSeconds = null;
            if (breakPeriod.HasValue)
            {
                CommonUtils.AssertInBounds("breakPeriod", breakPeriod.Value, TimeSpan.FromSeconds(0), TimeSpan.MaxValue);
                breakSeconds = (int)breakPeriod.Value.TotalSeconds;
            }

            RESTCommand<TimeSpan> putCmd = new RESTCommand<TimeSpan>(blob.ServiceClient.Credentials, attributes.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.Lease(uri, serverTimeout, LeaseAction.Break, null /* proposedLeaseId */, null /* leaseDuration */, breakSeconds, accessCondition, ctx);
            putCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Accepted, resp, TimeSpan.Zero, cmd, ex, ctx);

                int? remainingLeaseTime = BlobHttpResponseParsers.GetRemainingLeaseTime(resp);
                if (!remainingLeaseTime.HasValue)
                {
                    // Unexpected result from service.
                    throw new StorageException(ctx.CurrentResult, SR.LeaseTimeNotReceived, null /* inner */);
                }

                return TimeSpan.FromSeconds(remainingLeaseTime.Value);
            };

            return putCmd;
        }

        /// <summary>
        /// Implementation of the StartCopyFromBlob method. Result is a BlobAttributes object derived from the response headers.
        /// </summary>
        /// <param name="source">The URI of the source blob.</param>
        /// <param name="sourceAccessCondition">An object that represents the access conditions for the source blob. If null, no condition is used.</param>
        /// <param name="destAccessCondition">An object that represents the access conditions for the destination blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="setResult">A delegate for setting the BlobAttributes result.</param>
        /// <returns>A <see cref="RESTCommand"/> that starts to copy the blob.</returns>
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
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Accepted, resp, null /* retVal */, cmd, ex, ctx);
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
        /// <param name="copyId">The copy ID of the copy operation to abort.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the operation. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that copies the blob.</returns>
        internal static RESTCommand<NullType> AbortCopyImpl(ICloudBlob blob, BlobAttributes attributes, string copyId, AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("copyId", copyId);

            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(blob.ServiceClient.Credentials, attributes.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.AbortCopy(uri, serverTimeout, copyId, accessCondition, ctx);
            putCmd.SignRequest = blob.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, NullType.Value, cmd, ex, ctx);

            return putCmd;
        }

        /// <summary>
        /// Updates this blob with the given attributes a the end of a fetch attributes operation.
        /// </summary>
        /// <param name="attributes">The new attributes.</param>
        internal static void UpdateAfterFetchAttributes(BlobAttributes attributes, HttpWebResponse response, bool ignoreMD5)
        {
            BlobProperties properties = BlobHttpResponseParsers.GetProperties(response);

            // If BlobType is specified and the value returned from cloud is different, 
            // then it's a client error and we need to throw.
            if (attributes.Properties.BlobType != BlobType.Unspecified && attributes.Properties.BlobType != properties.BlobType)
            {
                throw new InvalidOperationException(SR.BlobTypeMismatchExceptionMessage);
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
        /// Retreive ETag and LastModified date time from response.
        /// </summary>
        /// <param name="response">The response to parse.</param>
        internal static void ParseSizeAndLastModified(BlobAttributes attributes, HttpWebResponse response)
        {
            BlobProperties parsedProperties = BlobHttpResponseParsers.GetProperties(response);
            attributes.Properties.ETag = parsedProperties.ETag ?? attributes.Properties.ETag;
            attributes.Properties.LastModified = parsedProperties.LastModified ?? attributes.Properties.LastModified;
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
            Uri sourceUri = source.ServiceClient.Credentials.TransformUri(source.Uri);

            if (source.SnapshotTime.HasValue)
            {
                UriQueryBuilder builder = new UriQueryBuilder();
                builder.Add("snapshot", BlobRequest.ConvertDateTimeToSnapshotString(source.SnapshotTime.Value));
                sourceUri = builder.AddToUri(sourceUri);
            }

            return sourceUri;
        }
    }
}
