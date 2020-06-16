// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Messaging.ServiceBus.Management
{
    internal class ManagementClientConstants
    {
        public const int QueueNameMaximumLength = 260;
        public const int TopicNameMaximumLength = 260;
        public const int SubscriptionNameMaximumLength = 50;
        public const int RuleNameMaximumLength = 50;

        public const string AtomNamespace = "http://www.w3.org/2005/Atom";
        public const string ServiceBusNamespace = "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect";
        public const string XmlSchemaInstanceNamespace = "http://www.w3.org/2001/XMLSchema-instance";
        public const string XmlSchemaNamespace = "http://www.w3.org/2001/XMLSchema";
        public const string SerializationNamespace = "http://schemas.microsoft.com/2003/10/Serialization/";
        public const string AtomContentType = "application/atom+xml";
        public const string apiVersionQuery = "api-version=" + ApiVersion;
        public const string ApiVersion = "2017-04";

        public const string ServiceBusSupplementartyAuthorizationHeaderName = "ServiceBusSupplementaryAuthorization";
        public const string ServiceBusDlqSupplementaryAuthorizationHeaderName = "ServiceBusDlqSupplementaryAuthorization";
        public const string HttpErrorSubCodeFormatString = "SubCode={0}";
        public static string ConflictOperationInProgressSubCode =
            string.Format(CultureInfo.InvariantCulture, HttpErrorSubCodeFormatString, ExceptionErrorCodes.ConflictOperationInProgress.ToString("D"));
        public static string ForbiddenInvalidOperationSubCode =
            string.Format(CultureInfo.InvariantCulture,
                HttpErrorSubCodeFormatString, ExceptionErrorCodes.ForbiddenInvalidOperation.ToString("D"));

        public static readonly TimeSpan MinimumAllowedTimeToLive = TimeSpan.FromSeconds(1);
        public static readonly TimeSpan MaximumAllowedTimeToLive = TimeSpan.MaxValue;
        public static readonly TimeSpan MinimumLockDuration = TimeSpan.FromSeconds(5);
        public static readonly TimeSpan MaximumLockDuration = TimeSpan.FromMinutes(5);
        public static readonly TimeSpan MinimumAllowedAutoDeleteOnIdle = TimeSpan.FromMinutes(5);
        public static readonly TimeSpan MaximumDuplicateDetectionHistoryTimeWindow = TimeSpan.FromDays(7);
        public static readonly TimeSpan MinimumDuplicateDetectionHistoryTimeWindow = TimeSpan.FromSeconds(20);
        public const int MinAllowedMaxDeliveryCount = 1;
        public const int MaxUserMetadataLength = 1024;

        public static char[] InvalidEntityPathCharacters = { '@', '?', '#', '*' };

        // Authorization constants
        public const int SupportedClaimsCount = 3;

        /// <summary>Specifies the error codes of the exceptions.</summary>
        public enum ExceptionErrorCodes
        {
            /// <summary>A parse error encountered while processing a request.</summary>
            BadRequest = 40000,
            /// <summary>A generic unauthorized error.</summary>
            UnauthorizedGeneric = 40100,
            /// <summary>The service bus has no transport security.</summary>
            NoTransportSecurity = 40101,
            /// <summary>The token is missing.</summary>
            MissingToken = 40102,
            /// <summary>The signature is invalid.</summary>
            InvalidSignature = 40103,
            /// <summary>The audience is invalid.</summary>
            InvalidAudience = 40104,
            /// <summary>A malformed token.</summary>
            MalformedToken = 40105,
            /// <summary>The token had expired.</summary>
            ExpiredToken = 40106,
            /// <summary>The audience is not found.</summary>
            AudienceNotFound = 40107,
            /// <summary>The expiry date not found.</summary>
            ExpiresOnNotFound = 40108,
            /// <summary>The issuer cannot be found.</summary>
            IssuerNotFound = 40109,
            /// <summary>The signature cannot be found.</summary>
            SignatureNotFound = 40110,
            /// <summary>The incoming ip has been rejected by policy.</summary>
            IpRejected = 40111,
            /// <summary>The incoming ip is not in acled subnet.</summary>
            IpNotInAcledSubNet = 40112,
            /// <summary>A generic forbidden error.</summary>
            ForbiddenGeneric = 40300,
            /// <summary>Operation is not allowed.</summary>
            ForbiddenInvalidOperation = 40301,
            /// <summary>The endpoint is not found.</summary>
            EndpointNotFound = 40400,
            /// <summary>The destination is invalid.</summary>
            InvalidDestination = 40401,
            /// <summary>The namespace is not found.</summary>
            NamespaceNotFound = 40402,
            /// <summary>The store lock is lost.</summary>
            StoreLockLost = 40500,
            /// <summary>The SQL filters exceeded its allowable maximum number.</summary>
            SqlFiltersExceeded = 40501,
            /// <summary>The correlation filters exceeded its allowable maximum number.</summary>
            CorrelationFiltersExceeded = 40502,
            /// <summary>The subscriptions exceeded its allowable maximum number.</summary>
            SubscriptionsExceeded = 40503,
            /// <summary>A conflict during updating occurred.</summary>
            UpdateConflict = 40504,
            /// <summary>The Service Bus entity is at full capacity.</summary>
            EventHubAtFullCapacity = 40505,
            /// <summary>A generic conflict error.</summary>
            ConflictGeneric = 40900,
            /// <summary>An operation is in progress.</summary>
            ConflictOperationInProgress = 40901,
            /// <summary>The entity is not found.</summary>
            EntityGone = 41000,
            /// <summary>An internal error that is not specified.</summary>
            UnspecifiedInternalError = 50000,
            /// <summary>The error of data communication.</summary>
            DataCommunicationError = 50001,
            /// <summary>An internal error.</summary>
            InternalFailure = 50002,
            /// <summary>The provider is unreachable.</summary>
            ProviderUnreachable = 50003,
            /// <summary>The server is busy.</summary>
            ServerBusy = 50004,
            /// <summary> Archive Storage Account Server is busy. </summary>
            ArchiveStorageAccountServerBusy = 50005,
            /// <summary> Archive Storage Account ResourceId is invalid. </summary>
            InvalidArchiveStorageAccountResourceId = 50006,
            /// <summary>The error is caused by bad gateway.</summary>
            BadGatewayFailure = 50200,
            /// <summary>The gateway did not receive a timely response from the upstream server.</summary>
            GatewayTimeoutFailure = 50400,
            /// <summary>This exception detail will be used for those exceptions that are thrown without specific any explicit exception detail.</summary>
            UnknownExceptionDetail = 60000,
        }
    }
}
