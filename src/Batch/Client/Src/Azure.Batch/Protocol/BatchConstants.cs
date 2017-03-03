//-----------------------------------------------------------------------
// <copyright file="BatchConstants.cs" company="Microsoft">
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

namespace Microsoft.Azure.Batch.Protocol
{

    /// <summary>
    /// Constants defined in batch client.
    /// </summary>
    internal static class BatchConstants
    {
        /// <summary>
        /// String format for Batch API group version.
        /// [YYYY-MM-DD]
        /// </summary>
        internal const string GroupVersionStringFormat = "yyyy-MM-dd";

        /// <summary>
        /// String format for Batch API major minor version.
        /// [Major.Minor]
        /// </summary>
        internal const string MajorMinorVersionStringFormat = "{0}.{1}";

        /// <summary>
        /// String format for Batch API version.
        /// [GroupVersion.MajorMinorVersion]
        /// </summary>
        internal const string ApiVersionStringFormat = "{0}.{1}";

        /// <summary>
        /// utf-8 char set.
        /// </summary>
        internal const string UTF8CharSet = "utf-8";

        /// <summary>
        /// metadata string in url.
        /// </summary>
        internal const string MetadataStringInUri = "$metadata";

        /// <summary>
        /// The maximum results the Batch service can return.
        /// </summary>
        internal const int BatchServiceMaxResults = 1000;

        /// <summary>
        /// A constant representing a kilo-byte (Non-SI version).
        /// </summary>
        internal const long KB = 1024;

        /// <summary>
        /// A constant representing a megabyte (Non-SI version).
        /// </summary>
        internal const long MB = 1024 * KB;

        /// <summary>
        /// A constant representing a megabyte (Non-SI version).
        /// </summary>
        internal const long GB = 1024 * MB;

        /// <summary>
        /// The maximum size of a string property for the Batch service in bytes, 4MB is the limit.
        /// </summary>
        internal const long BatchServiceRequestMaxPayload = 4 * BatchConstants.MB;

        /// <summary>
        /// The maximum payload the Batch service can return (1000 * 4MB).
        /// </summary>
        internal const long BatchServiceResponseMaxPayload = 4 * BatchConstants.GB;

        /// <summary>
        /// Forward slash.
        /// </summary>
        internal const string ForwardSlash = "/";

        /// <summary>
        /// Property separator.
        /// </summary>
        internal const string PropertySeparator = ",";

        /// <summary>
        /// Common name to be used for all loggers.
        /// </summary>
        internal const string LogSourceName = "Microsoft.Azure.Batch";

        /// <summary>
        /// The default certificate algorithm.
        /// </summary>
        public const string DefaultCertificateAlgorithm = "sha1";

        /// <summary>
        /// Delimiter for the composition of certificate's algorithm and thumbprint.
        /// </summary>
        public const char CertificateAlgorithmAndThumbprintDelimiter = '-';
        
        /// <summary>
        /// The namespace for all entity types defined in the EdmModel.
        /// </summary>
        public const string EntityNameSpace = "Microsoft.Azure.Batch.Protocol.Entities";

        /// <summary>
        /// The entity namespace plus dot in the end.
        /// </summary>
        public const string EntityNameSpaceDot = BatchConstants.EntityNameSpace + ".";

        /// <summary>
        /// Default unknown enum value from server.
        /// </summary>
        public const string UnmappedEnumValueFromServer = "Unmapped";
    }

    internal static class BatchHttpHeaderConstants
    {
         /// <summary>
        /// The prefix for a Batch custom header.
        /// </summary>
        internal const string BatchCustomHeaderNamePrefix = "ocp-batch-";

        /// <summary>
        /// The prefix for an Azure custom header.
        /// </summary>
        internal const string AzureCustomHeaderNamePrefix = "ocp-";

        /// <summary>
        /// The date.
        /// </summary>
        internal const string Date = AzureCustomHeaderNamePrefix + "date";

        /// <summary>
        /// The key-name.
        /// </summary>
        internal const string KeyNameHeader = AzureCustomHeaderNamePrefix + "key-name";

        /// <summary>
        /// A unique id for the current operation which is generated by the Batch service.
        /// </summary>
        internal const string RequestId = "request-id";

        /// <summary>
        /// Caller generated request identity, in the form of a GUID with no decoration such as curly braces 
        /// e.g. client-request-id: 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0. 
        /// </summary>
        internal const string ClientRequestId = "client-request-id";

        /// <summary>
        /// The request header instructs whether the server to include the client-request-id in the response.
        /// </summary>
        internal const string ReturnClientRequestId = "return-client-request-id";

        /// <summary>
        /// The OData service version header.
        /// If specified by a client it means the client can interpret a message with the indicated version of the OData protocol. 
        /// The Batch service returns the OData version of the response.
        /// </summary>
        internal const string DataServiceVersion = "DataServiceVersion";

        /// <summary>
        /// The minimum OData service version header.
        /// If specified it means that the response can be interpreted by a client that
        /// knows at least the indicated version (or later). 
        /// </summary>
        internal const string MinDataServiceVersion = "MinDataServiceVersion";

        /// <summary>
        /// The maximum OData service version header.
        /// If specified it means that the response can be interpreted by a client 
        /// that only knows up to the version indicated in this header.
        /// </summary>
        internal const string MaxDataServiceVersion = "MaxDataServiceVersion";

        /// <summary>
        /// Request: Mime type of request body (PUT/POST/PATCH) 
        /// </summary>
        internal const string ContentType = "Content-Type";

        /// <summary>
        /// Content length header.
        /// </summary>
        internal const string ContentLength = "Content-Length";

        /// <summary>
        /// Content-ID header.
        /// </summary>
        internal const string ContentId = "Content-ID";

        /// <summary>
        /// Disable header.
        /// </summary>
        internal const string Disabled = BatchCustomHeaderNamePrefix + "disabled";

        /// <summary>
        /// IsDirectory header.
        /// </summary>
        public const string IsDirectory = BatchCustomHeaderNamePrefix + "file-isdirectory";

        /// <summary>
        /// FileUrl Header
        /// </summary>
        public const string FileUrl = BatchCustomHeaderNamePrefix + "file-url";

        /// <summary>
        /// Creation time (file).
        /// </summary>
        public const string CreationTime = AzureCustomHeaderNamePrefix + "creation-time";

        /// <summary>
        /// file range.
        /// </summary>
        public const string CustomRange = AzureCustomHeaderNamePrefix + "range";

        /// <summary>
        /// File range format in the header.
        /// {0} the file beginning position to read.
        /// {1} the file end position to read.
        /// </summary>
        public const string CustomRangeFormat = "bytes={0}-{1}";

        /// <summary>
        /// The Batch service returns this header if responding with no body to POST, PUT, PATCH.
        /// </summary>
        internal const string DataServiceId = "DataServiceId";

        /// <summary>
        /// Location header.
        /// </summary>
        internal const string Location = "Location";

        /// <summary>
        /// ETag.
        /// </summary>
        internal const string ETag = "ETag";

        /// <summary>
        /// The last-modified header.
        /// </summary>
        internal const string LastModified = "Last-Modified";
    }

    internal static class BatchErrorCode
    {
        internal const string RestApiErrorCode = "Rest api error";
        internal const string ODataErrorCode = "OData error";
        internal const string ODataEntityErrorCode = "OData entity error";
        internal const string TLSFEAzureErrorErrorCode = "TLSFE AzureError error";
        internal const string UnspecifiedErrorCode = "Unspecified error";
        internal const string NoAzureErrorReturned = "No Azure Error returned";
    }
}
