// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenTelemetry.Exporter.AzureMonitor
{
    internal static class RemoteDependencyConstants
    {
        public const string AzureBlob = "Azure blob";
        public const string AzureDocumentDb = "Azure DocumentDB";
        public const string AzureEventHubs = "Azure Event Hubs";
        public const string AzureIotHub = "Azure IoT Hub";
        public const string AzureQueue = "Azure queue";
        public const string AzureTable = "Azure table";
        public const string AzureSearch = "Azure Search";
        public const string AzureServiceBus = "Azure Service Bus";

        public const string SQL = "SQL";
        public const string HTTP = "Http";
        public const string AI = "Http (tracked component)";

        public const string InProc = "InProc";
        public const string QueueMessage = "Queue Message";

        public const string WcfService = "WCF Service";
        public const string WebService = "Web Service";

        public const string HttpRequestOperationDetailName = "HttpRequest";
        public const string HttpResponseOperationDetailName = "HttpResponse";
        public const string HttpResponseHeadersOperationDetailName = "HttpResponseHeaders";

        public const string SqlCommandOperationDetailName = "SqlCommand";

        public const string DependencyErrorPropertyKey = "Error";
    }
}
