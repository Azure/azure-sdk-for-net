//-----------------------------------------------------------------------
// <copyright file="SR.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Core
{
    using System;

    /// <summary>
    /// Provides a standard set of errors that could be thrown from the client library.
    /// </summary>
    internal class SR
    {
        public const string ArgumentEmptyError = "The argument must not be empty string.";
        public const string ArgumentOutOfRangeError = "The argument is out of range";
        public const string ArgumentTooLargeError = "The argument '{0}' is larger than maximum of '{1}'";
        public const string ArgumentTooSmallError = "The argument '{0}' is smaller than minimum of '{1}'";
        public const string AttachToTableServiceContext = "Cannot attach to a TableStorageDataServiceContext object. These objects already contain the functionality for accessing the table storage service.";
        public const string BinaryMessageShouldUseBase64Encoding = "EncodeMessage should be true for binary message.";
        public const string BlobQSharedKeyLiteUnsuppported = "Versions before 2009-09-19 do not support Shared Key Lite for Blob And Queue, current target version '{0}'";
        public const string BlobSizeReductonError = "Cannot change size below currently written size";
        public const string BlobSizeTypeMismatch = "A stream blob must have a blob size of 0.";
        public const string BlobTooLargeError = "The blob is larger than maximum supported size '{0}'";
        public const string BlobTypeMismatchExceptionMessage = "BlobType of the blob reference doesn't match BlobType of the blob.";
        public const string BlocksExistError = "Data already uploaded";
        public const string BlocksTooSmallError = "The block size must be positive value";
        public const string BlockTooLargeError = "Block size can not be larger than '{0}'";
        public const string CannotCreateSASForSnapshot = "Cannot create Shared Access Signature for snapshots. Perform the operation on the root blob instead.";
        public const string CannotCreateSASSignatureForGivenCred = "Cannot create Shared Access Signature as the credentials does not have account name information. Please check that the credentials used support creating Shared Access Signature.";
        public const string CannotCreateSASWithoutAccountKey = "Cannot create Shared Access Signature unless Account Key credentials are used.";
        public const string CannotModifySnapshot = "Cannot perform this operation on a blob representing a snapshot.";
        public const string CannotRetryNonSeekableStreamError = "Cannot retry operation using a source stream which does not support seek. To avoid this exception set the RetryPolicy to NoRetry or use a seekable stream.";
        public const string CannotUpdateKeyWithoutAccountKeyCreds = "Cannot update key unless Account Key credentials are used.";
        public const string ClientSideTimeoutError = "Server operation did not finish within user specified timeout '{0}' seconds, check if operation is valid or try increasing the timeout.";
        public const string ConditionalRequiresDateTime = "If-Modified-Since and If-Unmodified-Since require a DateTime value.";
        public const string ConditionalRequiresETag = "If-Match and If-None-Match require an ETag value.";
        public const string ConditionNotMatchedError = "The conditionals specified for this operation did not match server.";
        public const string ConfigurationSettingPublisherError = "SetConfigurationSettingPublisher needs to be called before FromConfigurationSetting can be used";
        public const string CopyAborted = "The copy operation has been aborted by the user.";
        public const string CopyFailed = "The copy operation failed with the following error message: {0}";
        public const string CopyUnknownId = "No copy with the given ID was found. Either the copy was never started or the copy status was deleted or overwritten by a subsequent copy.";
        public const string CredentialsCantSignRequest = "The supplied credentials '{0'} cannot be used to sign request";
        public const string DeleteSnapshotsNotValidError = "The option '{0}' must be 'None' to delete a specific snapshot specified by '{1}'";
        public const string IncompatibleAddressesProvided = "Cannot combine incompatible absolute Uris base '{0}'  relative '{1}'.When trying to combine 2 absolute Uris, the base uri should be a valid base of the relative Uri.";
        public const string InvalidAclType = "Invalid acl public access type returned '{0}'. Expected blob or container.";
        public const string InvalidContinuationType = "The continuation type passed in is unexpected. Please verify that the correct continuation type is passed in. Expected {0}, found {1}";
        public const string InvalidPageSize = "Page data must be a multiple of 512 bytes.";
        public const string InvalidQueryParametersInsideBlobAddress = "Invalid query parameters inside Blob address '{0}'.";
        public const string ListSnapshotsWithDelimiterError = "Listing snapshots is only supported in flat mode (no delimiter). Consider setting the useFlatBlobListing parameter to true.";
        public const string MD5MismatchError = "Calculated MD5 does not match existing property";
        public const string MD5NotPresentError = "MD5 does not exist. If you do not want to force validation, please disable UseTransactionalMD5.";
        public const string MD5NotPossible = "MD5 cannot be calculated for an existing page blob because it would require reading the existing data. Please disable StoreBlobContentMD5.";
        public const string MessageTooLarge = "Messages cannot be larger than {0} bytes.";
        public const string MissingAccountInformationInUri = "Cannot find account information inside Uri '{0}'";
        public const string MissingContainerInformation = "Invalid blob address '{0}', missing container information";
        public const string MissingMandatoryParamtersForSAS = "Missing mandatory parameters for valid Shared Access Signature";
        public const string MissingXmsDateInHeader = "Canonicalization did not find a non empty x-ms-date header in the WebRequest. Please use a WebRequest with a valid x-ms-date header in RFC 123 format (example request.Headers[x-ms-date] = DateTime.UtcNow.ToString(R, CultureInfo.InvariantCulture))";
        public const string MultipleCredentialsProvided = "Cannot provide credentials as part of the address and as constructor parameter. Either pass in the address or use a different constructor.";
        public const string MultipleSnapshotTimesProvided = "Multiple different snapshot times provided as part of query '{0}' and as constructor parameter '{1}'.";
        public const string MustCallEndMoveNextSegmentFirst = "EndMoveNextSegment must be called before the Current property can be accessed.";
        public const string NoMoreResultsForSegmentCursor = "The segment cursor has no more results.";
        public const string NotSupportedForPageBlob = "This operation is not supported for creating a PageBlob. Use other operations to create a PageBlob.";
        public const string PathStyleUriMissingAccountNameInformation = "Missing account name information inside path style uri. Path style uris should be of the form http://<IPAddressPlusPort>/<accountName>";
        public const string RelativeAddressNotPermitted = "Address '{0}' is not an absolute address. Relative addresses are not permitted in here.";
        public const string SeekTooFarError = "Attempting to seek past the end of the stream";
        public const string SeekTooLowError = "Attempting to seek before the start of the stream";
        public const string ServerReturnedMoreThanMaxResults = "Server returned more that MaxResults requested";
        public const string SnapshotTimePassedTwice = "Snapshot query parameter is already defined in the blobUri. Either pass in a snapshotTime parameter or use a full URL with a snapshot query parameter.";
        public const string TableNameInvalid = "'{0}' is not a valid table name.";
        public const string TooManyBlocksError = "The number of blocks is larger than the maximum of '{0}'";
        public const string TooManyPolicyIdentifiers = "Too many '{0}' shared access policy identifiers provided. Server does not support setting more than '{1}' on a single container, queue, or table.";
        public const string UndefinedBlobType = "The blob type cannot be undefined.";
        public const string TimeoutExceptionMessage = "The client could not finish the operation within specified timeout.";
        public const string UnexpectedElement = "Unexpected Element '{0}'";
        public const string UnexpectedEmptyElement = "Unexpected Empty Element '{0}'";
        public const string UnexpectedContinuationType = "Unexpected Continuation Type";
        public const string InvalidLeaseStatus = "Invalid lease status in response: '{0}'";
        public const string InvalidLeaseState = "Invalid lease state in response: '{0}'";
        public const string InvalidLeaseDuration = "Invalid lease duration in response: '{0}'";
        public const string BlobDataCorrupted = "Blob data corrupted (integrity check failed), Expected value is '{0}', retrieved '{1}'";
        public const string MissingLeaseIDRenewing = "A lease ID must be specified when renewing a lease.";
        public const string MissingLeaseIDChanging = "A lease ID must be specified when changing a lease.";
        public const string MissingLeaseIDReleasing = "A lease ID must be specified when releasing a lease.";
        public const string LeaseTimeNotReceived = "Valid lease time expected but not received from the service.";
        public const string InvalidBlobListItem = "Invalid blob list item returned";
        public const string LeaseConditionOnSource = "A lease condition cannot be specified on the source of a copy.";
        public const string TableEndPointNotConfigured = "No table endpoint configured.";
        public const string MissingCredentials = "No credentials provided.";
        public const string QueueEndPointNotConfigured = "No queue endpoint configured.";
        public const string BlobEndPointNotConfigured = "No blob endpoint configured.";
        public const string ParseError = "Error parsing value";
        public const string OperationCanceled = "Operation was canceled by user.";
        public const string InternalStorageError = "Unexpected internal storage client error.";
        public const string BlobTypeMismatch = "BlobType of the blob reference doesn't match BlobType of the blob.";
        public const string UnexpectedResponseCode = "Unexpected response code, Expected:{0}, Received:{1}";
        public const string UnexpectedResponseCodeForOperation = "Unexpected response code for operation : ";
        public const string ContentMD5NotCalculated = "The operation requires a response body but no data was copied to the destination buffer.";
        public const string BlobDataCorruptedIncorrectNumberOfBytes = "Blob data corrupted. Incorrect number of bytes received '{0}' / '{1}'";
        public const string CryptoFunctionFailed = "Crypto function failed with error code '{0}'";
        public const string ResourceConsumed = "Resource consumed";
        public const string InvalidMetricsLevel = "Invalid metrics level specified.";
        public const string MetricVersionNull = "The metrics version is null or empty.";
        public const string InvalidLoggingLevel = "Invalid logging operations specified.";
        public const string LoggingVersionNull = "The logging version is null or empty.";
        public const string EmptyBatchOperation = "Cannot execute an empty batch operation";
        public const string ETagMissingForDelete = "Delete requires an ETag (which may be the '*' wildcard).";
        public const string ETagMissingForMerge = "Merge requires an ETag (which may be the '*' wildcard).";
        public const string ETagMissingForReplace = "Replace requires an ETag (which may be the '*' wildcard).";
        public const string BatchWithRetreiveContainsOtherOperations = "A batch transaction with a retrieve operation cannot contain any other operations.";
        public const string PartitionKey = "All entities in a given batch must have the same partition key.";
        public const string ConcurrentOperationsNotSupported = "Could not acquire exclusive use of the TableServiceContext, Concurrent operations are not supported.";
        public const string TakeCountNotPositive = "Take count must be positive and greater than 0.";
        public const string ExtendedErrorUnavailable = "An unknown error has occured, extended error information not available.";
    }
}
