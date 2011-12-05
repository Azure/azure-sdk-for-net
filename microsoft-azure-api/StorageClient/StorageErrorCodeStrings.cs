//-----------------------------------------------------------------------
// <copyright file="StorageErrorCodeStrings.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
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
// <summary>
//    Contains code for the StorageErrorCodeStrings class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    /// <summary>
    /// Provides error code strings that are common to all storage services.
    /// </summary>
    public static class StorageErrorCodeStrings
    {
        /// <summary>
        /// The specified HTTP verb is not supported.
        /// </summary>
        public const string UnsupportedHttpVerb = "UnsupportedHttpVerb";

        /// <summary>
        /// The Content-Length header is required for this request.
        /// </summary>
        public const string MissingContentLengthHeader = "MissingContentLengthHeader";

        /// <summary>
        /// A required header was missing.
        /// </summary>
        public const string MissingRequiredHeader = "MissingRequiredHeader";

        /// <summary>
        /// A required XML node was missing.
        /// </summary>
        public const string MissingRequiredXmlNode = "MissingRequiredXmlNode";

        /// <summary>
        /// One or more header values are not supported.
        /// </summary>
        public const string UnsupportedHeader = "UnsupportedHeader";

        /// <summary>
        /// One or more XML nodes are not supported.
        /// </summary>
        public const string UnsupportedXmlNode = "UnsupportedXmlNode";

        /// <summary>
        /// One or more header values are invalid.
        /// </summary>
        public const string InvalidHeaderValue = "InvalidHeaderValue";

        /// <summary>
        /// One or more XML node values are invalid.
        /// </summary>
        public const string InvalidXmlNodeValue = "InvalidXmlNodeValue";

        /// <summary>
        /// A required query parameter is missing.
        /// </summary>
        public const string MissingRequiredQueryParameter = "MissingRequiredQueryParameter";

        /// <summary>
        /// One or more query parameters is not supported.
        /// </summary>
        public const string UnsupportedQueryParameter = "UnsupportedQueryParameter";

        /// <summary>
        /// One or more query parameters are invalid.
        /// </summary>
        public const string InvalidQueryParameterValue = "InvalidQueryParameterValue";

        /// <summary>
        /// One or more query parameters are out of range.
        /// </summary>
        public const string OutOfRangeQueryParameterValue = "OutOfRangeQueryParameterValue";

        /// <summary>
        /// The URI is invalid.
        /// </summary>
        public const string InvalidUri = "InvalidUri";

        /// <summary>
        /// The HTTP verb is invalid.
        /// </summary>
        public const string InvalidHttpVerb = "InvalidHttpVerb";

        /// <summary>
        /// The metadata key is empty.
        /// </summary>
        public const string EmptyMetadataKey = "EmptyMetadataKey";

        /// <summary>
        /// The request body is too large.
        /// </summary>
        public const string RequestBodyTooLarge = "RequestBodyTooLarge";

        /// <summary>
        /// The specified XML document is invalid.
        /// </summary>
        public const string InvalidXmlDocument = "InvalidXmlDocument";

        /// <summary>
        /// An internal error occurred.
        /// </summary>
        public const string InternalError = "InternalError";

        /// <summary>
        /// Authentication failed.
        /// </summary>
        public const string AuthenticationFailed = "AuthenticationFailed";

        /// <summary>
        /// The specified MD5 hash does not match the server value.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Naming",
            "CA1709:IdentifiersShouldBeCasedCorrectly",
            MessageId = "Md",
            Justification = "The casing matches the storage constant the identifier represents.")]
        public const string Md5Mismatch = "Md5Mismatch";

        /// <summary>
        /// The specified MD5 hash is invalid.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Naming",
            "CA1709:IdentifiersShouldBeCasedCorrectly",
            MessageId = "Md",
            Justification = "The casing matches the storage constant the identifier represents.")]
        public const string InvalidMd5 = "InvalidMd5";

        /// <summary>
        /// The input is out of range.
        /// </summary>
        public const string OutOfRangeInput = "OutOfRangeInput";

        /// <summary>
        /// The input is invalid.
        /// </summary>
        public const string InvalidInput = "InvalidInput";

        /// <summary>
        /// The operation timed out.
        /// </summary>
        public const string OperationTimedOut = "OperationTimedOut";

        /// <summary>
        /// The specified resource was not found.
        /// </summary>
        public const string ResourceNotFound = "ResourceNotFound";

        /// <summary>
        /// The specified metadata is invalid.
        /// </summary>
        public const string InvalidMetadata = "InvalidMetadata";

        /// <summary>
        /// The specified metadata is too large.
        /// </summary>
        public const string MetadataTooLarge = "MetadataTooLarge";

        /// <summary>
        /// The specified condition was not met.
        /// </summary>
        public const string ConditionNotMet = "ConditionNotMet";

        /// <summary>
        /// The specified range is invalid.
        /// </summary>
        public const string InvalidRange = "InvalidRange";

        /// <summary>
        /// The specified container was not found.
        /// </summary>
        public const string ContainerNotFound = "ContainerNotFound";

        /// <summary>
        /// The specified container already exists.
        /// </summary>
        public const string ContainerAlreadyExists = "ContainerAlreadyExists";

        /// <summary>
        /// The specified container is disabled.
        /// </summary>
        public const string ContainerDisabled = "ContainerDisabled";

        /// <summary>
        /// The specified container is being deleted.
        /// </summary>
        public const string ContainerBeingDeleted = "ContainerBeingDeleted";

        /// <summary>
        /// The server is busy.
        /// </summary>
        public const string ServerBusy = "ServerBusy";
    }
}