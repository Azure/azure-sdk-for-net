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
    /// <summary>
    /// Provides a standard set of errors that could be thrown from the client library.
    /// </summary>
    internal class SR
    {
        public const string ArgumentEmptyError = "The argument must not be empty string.";
        public const string ArgumentOutOfRangeError = "The argument is out of range. Value passed: {0}";
        public const string ArgumentTooLargeError = "The argument '{0}' is larger than maximum of '{1}'";
        public const string ArgumentTooSmallError = "The argument '{0}' is smaller than minimum of '{1}'";
        public const string BatchWithRetreiveContainsOtherOperations = "A batch transaction with a retrieve operation cannot contain any other operations.";
        public const string BinaryMessageShouldUseBase64Encoding = "EncodeMessage should be true for binary message.";
        public const string BlobDataCorrupted = "Blob data corrupted (integrity check failed), Expected value is '{0}', retrieved '{1}'";
        public const string BlobEndPointNotConfigured = "No blob endpoint configured.";
        public const string BlobInvalidSequenceNumber = "The sequence number may not be specified for an increment operation.";
        public const string BlobStreamAlreadyCommitted = "Blob stream has already been committed once.";
        public const string BlobStreamFlushPending = "Blob stream has a pending flush operation. Please call EndFlush first.";
        public const string BlobStreamReadPending = "Blob stream has a pending read operation. Please call EndRead first.";
        public const string BlobTypeMismatch = "Blob type of the blob reference doesn't match blob type of the blob.";
        public const string BufferTooSmall = "The provided buffer is too small to fit in the blob data given the offset.";
        public const string BufferManagerProvidedIncorrectLengthBuffer = "The IBufferManager provided an incorrect length buffer to the stream, Expected {0}, received {1}. Buffer length should equal the value returned by IBufferManager.GetDefaultBufferSize().";
        public const string CannotCreateSASForSnapshot = "Cannot create Shared Access Signature for snapshots. Perform the operation on the root blob instead.";
        public const string CannotCreateSASSignatureForGivenCred = "Cannot create Shared Access Signature as the credentials does not have account name information. Please check that the credentials used support creating Shared Access Signature.";
        public const string CannotCreateSASWithoutAccountKey = "Cannot create Shared Access Signature unless Account Key credentials are used.";
        public const string CannotModifySnapshot = "Cannot perform this operation on a blob representing a snapshot.";
        public const string CannotUpdateKeyWithoutAccountKeyCreds = "Cannot update key unless Account Key credentials are used.";
        public const string CannotUpdateSasWithoutSasCreds = "Cannot update Shared Access Signature unless Sas credentials are used.";
        public const string ConcurrentOperationsNotSupported = "Could not acquire exclusive use of the TableServiceContext, Concurrent operations are not supported.";
        public const string ContentMD5NotCalculated = "The operation requires a response body but no data was copied to the destination buffer.";
        public const string CopyAborted = "The copy operation has been aborted by the user.";
        public const string CopyFailed = "The copy operation failed with the following error message: {0}";
        public const string CryptoFunctionFailed = "Crypto function failed with error code '{0}'";
        public const string DeleteSnapshotsNotValidError = "The option '{0}' must be 'None' to delete a specific snapshot specified by '{1}'";
        public const string EmptyBatchOperation = "Cannot execute an empty batch operation";
        public const string ETagMissingForDelete = "Delete requires an ETag (which may be the '*' wildcard).";
        public const string ETagMissingForMerge = "Merge requires an ETag (which may be the '*' wildcard).";
        public const string ETagMissingForReplace = "Replace requires an ETag (which may be the '*' wildcard).";
        public const string ExceptionOccurred = "An exception has occurred. For more information please deserialize this message via RequestResult.TranslateFromExceptionMessage.";
        public const string ExtendedErrorUnavailable = "An unknown error has occurred, extended error information not available.";
        public const string IncorrectNumberOfBytes = "Incorrect number of bytes received. Expected '{0}', received '{1}'";
        public const string InternalStorageError = "Unexpected internal storage client error.";
        public const string InvalidAclType = "Invalid acl public access type returned '{0}'. Expected blob or container.";
        public const string InvalidBlobListItem = "Invalid blob list item returned";
        public const string InvalidBlobName = "Blob name is invalid. Valid names should be 1 through 1024 characters long and should not end with a . or /";
        public const string InvalidContainerName = "Container name is invalid. Valid names start and end with a lower case letter or a number and has in between a lower case letter, number or dash with no consecutive dashes and is 3 through 63 characters long";
        public const string InvalidDirectoryName = "Directory name is invalid. Valid names should be 1 through 1024 characters long and should not end with a . or /";
        public const string InvalidLeaseStatus = "Invalid lease status in response: '{0}'";
        public const string InvalidLeaseState = "Invalid lease state in response: '{0}'";
        public const string InvalidLeaseDuration = "Invalid lease duration in response: '{0}'";
        public const string InvalidLoggingLevel = "Invalid logging operations specified.";
        public const string InvalidMetricsLevel = "Invalid metrics level specified.";
        public const string InvalidPageSize = "Page data must be a multiple of 512 bytes.";
        public const string InvalidQueueName = "Queue name is invalid. Valid names start and end with a lower case letter or a number and has in between a lower case letter, number or dash with no consecutive dashes and is 3 through 63 characters long";
        public const string InvalidTableName = "Table name is invalid. Valid names are case insensitive, start with a letter and is followed by letters or numbers and is 3 through 63 characters long";
        public const string IQueryableExtensionObjectMustBeTableQuery = "Query must be a TableQuery<T>";
        public const string LeaseConditionOnSource = "A lease condition cannot be specified on the source of a copy.";
        public const string LeaseTimeNotReceived = "Valid lease time expected but not received from the service.";
        public const string LengthNotInRange = "The length provided is out of range. The range must be between 0 and the length of the byte array.";
        public const string ListSnapshotsWithDelimiterError = "Listing snapshots is only supported in flat mode (no delimiter). Consider setting the useFlatBlobListing parameter to true.";
        public const string LoggingVersionNull = "The logging version is null or empty.";
        public const string MD5MismatchError = "Calculated MD5 does not match existing property";
        public const string MD5NotPossible = "MD5 cannot be calculated for an existing page blob because it would require reading the existing data. Please disable StoreBlobContentMD5.";
        public const string MD5NotPresentError = "MD5 does not exist. If you do not want to force validation, please disable UseTransactionalMD5.";
        public const string MessageTooLarge = "Messages cannot be larger than {0} bytes.";
        public const string MetricVersionNull = "The metrics version is null or empty.";
        public const string MissingAccountInformationInUri = "Cannot find account information inside Uri '{0}'";
        public const string MissingContainerInformation = "Invalid blob address '{0}', missing container information";
        public const string MissingCredentials = "No credentials provided.";
        public const string MissingLeaseIDChanging = "A lease ID must be specified when changing a lease.";
        public const string MissingLeaseIDReleasing = "A lease ID must be specified when releasing a lease.";
        public const string MissingLeaseIDRenewing = "A lease ID must be specified when renewing a lease.";
        public const string MissingMandatoryParametersForSAS = "Missing mandatory parameters for valid Shared Access Signature";
        public const string MultipleCredentialsProvided = "Cannot provide credentials as part of the address and as constructor parameter. Either pass in the address or use a different constructor.";
        public const string MultipleSnapshotTimesProvided = "Multiple different snapshot times provided as part of query '{0}' and as constructor parameter '{1}'.";
        public const string OffsetNotInRange = "The offset provided is out of range. The range must be between 0 and the length of the byte array.";
        public const string OperationCanceled = "Operation was canceled by user.";
        public const string ParseError = "Error parsing value";
        public const string PartitionKey = "All entities in a given batch must have the same partition key.";
        public const string PathStyleUriMissingAccountNameInformation = "Missing account name information inside path style uri. Path style uris should be of the form http://<IPAddressPlusPort>/<accountName>";
        public const string PutBlobNeedsStoreBlobContentMD5 = "When uploading a blob in a single request, StoreBlobContentMD5 must be set to true if UseTransactionalMD5 is true, because the MD5 calculated for the transaction will be stored in the blob.";
        public const string QueueEndPointNotConfigured = "No queue endpoint configured.";
        public const string RelativeAddressNotPermitted = "Address '{0}' is not an absolute address. Relative addresses are not permitted in here.";
        public const string ResourceConsumed = "Resource consumed";
        public const string StreamLengthError = "The length of the stream exceeds the permitted length.";
        public const string StreamLengthMismatch = "Cannot specify both copyLength and maxLength.";
        public const string StreamLengthShortError = "The requested number of bytes exceeds the length of the stream remaining from the specified position.";
        public const string TableEndPointNotConfigured = "No table endpoint configured.";
        public const string TableQueryDynamicPropertyAccess = "Accessing property dictionary of DynamicTableEntity requires a string constant for property name.";
        public const string TableQueryEntityPropertyInQueryNotSupported = "Referencing {0} on EntityProperty only supported with properties dictionary exposed via DynamicTableEntity.";
        public const string TableQueryFluentMethodNotAllowed = "Fluent methods may not be invoked on a Query created via CloudTable.CreateQuery<T>()";
        public const string TableQueryMustHaveQueryProvider = "Unknown Table. The TableQuery does not have an associated CloudTable Reference. Please execute the query via the CloudTable ExecuteQuery APIs.";
        public const string TableQueryTypeMustImplementITableEnitty = "TableQuery Generic Type must implement the ITableEntity Interface";
        public const string TableQueryTypeMustHaveDefaultParameterlessCtor = "TableQuery Generic Type must provide a default parameterless constructor.";
        public const string TakeCountNotPositive = "Take count must be positive and greater than 0.";
        public const string TimeoutExceptionMessage = "The client could not finish the operation within specified timeout.";
        public const string TooManyPolicyIdentifiers = "Too many '{0}' shared access policy identifiers provided. Server does not support setting more than '{1}' on a single container, queue, or table.";
        public const string TraceAbort = "Aborting pending request due to timeout.";
        public const string TraceAbortError = "Could not abort pending request because of {0}.";
        public const string TraceAbortRetry = "Aborting pending retry due to user request.";
        public const string TraceDownload = "Downloading response body.";
        public const string TraceGenericError = "Exception thrown during the operation: {0}.";
        public const string TraceGetResponse = "Waiting for response.";
        public const string TraceGetResponseError = "Exception thrown while waiting for response: {0}.";
        public const string TraceIgnoreAttribute = "Omitting property '{0}' from serialization/de-serialization because IgnoreAttribute has been set on that property.";
        public const string TraceInitRequestError = "Exception thrown while initializing request: {0}.";
        public const string TraceMissingDictionaryEntry = "Omitting property '{0}' from de-serialization because there is no corresponding entry in the dictionary provided.";
        public const string TraceNonPublicGetSet = "Omitting property '{0}' from serialization/de-serialization because the property's getter/setter are not public.";
        public const string TracePrepareUpload = "Preparing to write request data.";
        public const string TracePrepareUploadError = "Exception thrown while preparing to write request data: {0}.";
        public const string TracePreProcessDone = "Response headers were processed successfully, proceeding with the rest of the operation.";
        public const string TracePreProcessError = "Exception thrown while processing response: {0}.";
        public const string TracePostProcess = "Processing response body.";
        public const string TracePostProcessError = "Exception thrown while ending operation: {0}.";
        public const string TraceResponse = "Response received. Status code = {0}, Request ID = {1}, Content-MD5 = {2}, ETag = {3}.";
        public const string TraceRetry = "Retrying failed operation.";
        public const string TraceRetryCheck = "Checking if the operation should be retried. Retry count = {0}, HTTP status code = {1}, Retryable exception = {2}, Exception = {3}.";
        public const string TraceRetryDecisionPolicy = "Retry policy did not allow for a retry. Failing with {0}.";
        public const string TraceRetryDecisionTimeout = "Operation cannot be retried because we are out of time. Failing with {0}.";
        public const string TraceRetryDelay = "Operation will be retried after {0}ms.";
        public const string TraceRetryError = "Exception thrown while retrying operation: {0}.";
        public const string TraceStartRequestAsync = "Starting asynchronous request to {0}.";
        public const string TraceStartRequestSync = "Starting synchronous request to {0}.";
        public const string TraceStringToSign = "StringToSign = {0}.";
        public const string TraceSuccess = "Operation completed successfully.";
        public const string TraceUpload = "Writing request data.";
        public const string TraceUploadError = "Exception thrown while writing request data: {0}.";
        public const string UndefinedBlobType = "The blob type cannot be undefined.";
        public const string UnexpectedElement = "Unexpected Element '{0}'";
        public const string UnexpectedEmptyElement = "Unexpected Empty Element '{0}'";
        public const string UnexpectedContinuationType = "Unexpected Continuation Type";
        public const string UnexpectedResponseCode = "Unexpected response code, Expected:{0}, Received:{1}";
        public const string UnexpectedResponseCodeForOperation = "Unexpected response code for operation : ";

#if WINDOWS_PHONE
        public const string WindowsPhoneDoesNotSupportMD5 = "MD5 is not supported on Windows Phone";
#endif
        // Table IQueryable Exception messages
        public const string ALinqCouldNotConvert = "Could not convert constant {0} expression to string.";
        public const string ALinqMethodNotSupported = "The method '{0}' is not supported.";
        public const string ALinqUnaryNotSupported = "The unary operator '{0}' is not supported.";
        public const string ALinqBinaryNotSupported = "The binary operator '{0}' is not supported.";
        public const string ALinqConstantNotSupported = "The constant for '{0}' is not supported.";
        public const string ALinqTypeBinaryNotSupported = "An operation between an expression and a type is not supported.";
        public const string ALinqConditionalNotSupported = "The conditional expression is not supported.";
        public const string ALinqParameterNotSupported = "The parameter expression is not supported.";
        public const string ALinqMemberAccessNotSupported = "The member access of '{0}' is not supported.";
        public const string ALinqLambdaNotSupported = "Lambda Expressions not supported.";
        public const string ALinqNewNotSupported = "New Expressions not supported.";
        public const string ALinqMemberInitNotSupported = "Member Init Expressions not supported.";
        public const string ALinqListInitNotSupported = "List Init Expressions not supported.";
        public const string ALinqNewArrayNotSupported = "New Array Expressions not supported.";
        public const string ALinqInvocationNotSupported = "Invocation Expressions not supported.";
        public const string ALinqUnsupportedExpression = "The expression type {0} is not supported.";
        public const string ALinqCanOnlyProjectTheLeaf = "Can only project the last entity type in the query being translated.";
        public const string ALinqCantCastToUnsupportedPrimitive = "Can't cast to unsupported type '{0}'";
        public const string ALinqCantTranslateExpression = "The expression {0} is not supported.";
        public const string ALinqCantNavigateWithoutKeyPredicate = "Navigation properties can only be selected from a single resource. Specify a key predicate to restrict the entity set to a single instance.";
        public const string ALinqCantReferToPublicField = "Referencing public field '{0}' not supported in query option expression.  Use public property instead.";
        public const string ALinqCannotConstructKnownEntityTypes = "Construction of entity type instances must use object initializer with default constructor.";
        public const string ALinqCannotCreateConstantEntity = "Referencing of local entity type instances not supported when projecting results.";
        public const string ALinqExpressionNotSupportedInProjectionToEntity = "Initializing instances of the entity type {0} with the expression {1} is not supported.";
        public const string ALinqExpressionNotSupportedInProjection = "Constructing or initializing instances of the type {0} with the expression {1} is not supported.";
        public const string ALinqProjectionMemberAssignmentMismatch = "Cannot initialize an instance of entity type '{0}' because '{1}' and '{2}' do not refer to the same source entity.";
        public const string ALinqPropertyNamesMustMatchInProjections = "Cannot assign the value from the {0} property to the {1} property.  When projecting results into a entity type, the property names of the source type and the target type must match for the properties being projected.";
        public const string ALinqQueryOptionOutOfOrder = "The {0} query option cannot be specified after the {1} query option.";
        public const string ALinqQueryOptionsOnlyAllowedOnLeafNodes = "Can only specify query options (orderby, where, take, skip) after last navigation.";
    }
}
