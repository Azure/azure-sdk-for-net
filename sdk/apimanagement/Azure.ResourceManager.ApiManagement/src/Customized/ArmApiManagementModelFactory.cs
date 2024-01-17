// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure;
using Azure.Core;
using Azure.ResourceManager.ApiManagement;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ApiManagement.Models
{
    public static partial class ArmApiManagementModelFactory
    {
        /// <summary> Initializes a new instance of RequestReportRecordContract. </summary>
        /// <param name="apiId"> API identifier path. /apis/{apiId}. </param>
        /// <param name="operationId"> Operation identifier path. /apis/{apiId}/operations/{operationId}. </param>
        /// <param name="productId"> Product identifier path. /products/{productId}. </param>
        /// <param name="userId"> User identifier path. /users/{userId}. </param>
        /// <param name="method"> The HTTP method associated with this request.. </param>
        /// <param name="uri"> The full URL associated with this request. </param>
        /// <param name="ipAddress"> The client IP address associated with this request. </param>
        /// <param name="backendResponseCode"> The HTTP status code received by the gateway as a result of forwarding this request to the backend. </param>
        /// <param name="responseCode"> The HTTP status code returned by the gateway. </param>
        /// <param name="responseSize"> The size of the response returned by the gateway. </param>
        /// <param name="timestamp"> The date and time when this request was received by the gateway in ISO 8601 format. </param>
        /// <param name="cache"> Specifies if response cache was involved in generating the response. If the value is none, the cache was not used. If the value is hit, cached response was returned. If the value is miss, the cache was used but lookup resulted in a miss and request was fulfilled by the backend. </param>
        /// <param name="apiTime"> The total time it took to process this request. </param>
        /// <param name="serviceTime"> he time it took to forward this request to the backend and get the response back. </param>
        /// <param name="apiRegion"> Azure region where the gateway that processed this request is located. </param>
        /// <param name="subscriptionResourceId"> Subscription identifier path. /subscriptions/{subscriptionId}. </param>
        /// <param name="requestId"> Request Identifier. </param>
        /// <param name="requestSize"> The size of this request.. </param>
        /// <returns> A new <see cref="Models.RequestReportRecordContract"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("BackendResponseCode has been replaced by BackendResponseCodeInteger", false)]
        public static RequestReportRecordContract RequestReportRecordContract(string apiId = null, string operationId = null, string productId = null, string userId = null, RequestMethod? method = null, Uri uri = null, IPAddress ipAddress = null, string backendResponseCode = null, int? responseCode = null, int? responseSize = null, DateTimeOffset? timestamp = null, string cache = null, double? apiTime = null, double? serviceTime = null, string apiRegion = null, ResourceIdentifier subscriptionResourceId = null, string requestId = null, int? requestSize = null)
            => new RequestReportRecordContract(apiId, operationId, productId, userId, method, uri, ipAddress, int.Parse(backendResponseCode), responseCode, responseSize, timestamp, cache, apiTime, serviceTime, apiRegion, subscriptionResourceId, requestId, requestSize);
    }
}
