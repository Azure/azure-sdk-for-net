﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal static class Constants
    {
        public const string AzureSignalRConnectionStringName = "AzureSignalRConnectionString";
        public const string AzureSignalREndpoints = "Azure:SignalR:Endpoints";
        public const string AzureSignalRHubProtocol = "Azure:SignalR:HubProtocol";
        public static string AzureSignalRNewtonsoftCamelCase = $"{AzureSignalRHubProtocol}:NewtonsoftJson:CamelCase";
        public const string ServiceTransportTypeName = "AzureSignalRServiceTransportType";
        public const string AsrsHeaderPrefix = "X-ASRS-";
        public const string AsrsConnectionIdHeader = AsrsHeaderPrefix + "Connection-Id";
        public const string AsrsUserClaims = AsrsHeaderPrefix + "User-Claims";
        public const string AsrsUserId = AsrsHeaderPrefix + "User-Id";
        public const string AsrsHubNameHeader = AsrsHeaderPrefix + "Hub";
        public const string AsrsCategory = AsrsHeaderPrefix + "Category";
        public const string AsrsEvent = AsrsHeaderPrefix + "Event";
        public const string AsrsClientQueryString = AsrsHeaderPrefix + "Client-Query";
        public const string AsrsSignature = AsrsHeaderPrefix + "Signature";
        public const string JsonContentType = "application/json";
        public const string MessagePackContentType = "application/x-msgpack";
        public const string OnConnected = "OnConnected";
        public const string OnDisconnected = "OnDisconnected";

        public const string FunctionsWorkerRuntime = "FUNCTIONS_WORKER_RUNTIME";
        public const string FunctionsWorkerProductInfoKey = "func";
        public const string DotnetWorker = "dotnet";
    }
}