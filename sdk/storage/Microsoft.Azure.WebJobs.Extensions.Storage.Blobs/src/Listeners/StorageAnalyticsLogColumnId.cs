// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    /// <summary>
    /// Zero-based index of fields in a Storage Analytics Log entry format consumed by the WebJobs SDK.
    /// </summary>
    /// <remarks>
    /// Each version 1.0 log entry adheres to the following format:
    /// <![CDATA[
    /// <version-number>;<request-start-time>;<operation-type>;<request-status>;<http-status-code>;<end-to-end-latency-in-ms>;<server-latency-in-ms>;<authentication-type>;<requester-account-name>;<owner-account-name>;<service-type>;<request-url>;<requested-object-key>;<request-id-header>;<operation-count>;<requester-ip-address>;<request-version-header>;<request-header-size>;<request-packet-size>;<response-header-size>;<response-packet-size>;<request-content-length>;<request-md5>;<server-md5>;<etag-identifier>;<last-modified-time>;<conditions-used>;<user-agent-header>;<referrer-header>;<client-request-id>
    /// ]]>
    /// Storage Analytics Log Format defined at <a href="http://msdn.microsoft.com/en-us/library/windowsazure/hh343259.aspx"/>
    /// </remarks>
    /// <seealso cref="StorageAnalyticsLogEntry"/>
    internal enum StorageAnalyticsLogColumnId
    {
        /// <summary>
        /// The version of Storage Analytics Logging used to record the entry.
        /// </summary>
        VersionNumber = 0,
        RequestStartTime = 1,
        OperationType = 2,
        RequestStatus = 3,
        HttpStatusCode = 4,
        EndToEndLatencyInMs = 5,
        ServerLatencyInMs = 6,
        AuthenticationType = 7,
        RequesterAccountName = 8,
        OwnerAccountName = 9,
        ServiceType = 10,
        RequestUrl = 11,
        RequestedObjectKey = 12,
        RequestIdHeader = 13,
        OperationCount = 14,

        /// <summary>
        /// Index of the last column in a log entry.
        /// </summary>
        LastColumn = 29
    }
}
