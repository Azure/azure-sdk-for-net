// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    /// <summary>
    /// This class encapsulates constant values from the Azure Monitor Swagger
    /// <see href="https://github.com/Azure/azure-rest-api-specs/blob/4eb2ae1846ac79a993cabc378436b6218baaa1ed/specification/applicationinsights/data-plane/Monitor.Exporters/preview/2020-09-15_Preview/swagger.json"/>
    /// and the Ingestion service data models
    /// <see href="https://docs.microsoft.com/azure/azure-monitor/app/data-model"/>.
    /// NOTE: Some of these max lengths are not defined in the Swagger. Must refer to the internal service repo.
    /// </summary>
    /// <remarks>
    /// MaxLength (inclusive) defines the maximum number of characters.
    /// LessThanDays (exclusive) defines the upper limit of days.
    /// MaxFrames (inclusive) defines the maximum number of frames.
    /// </remarks>
    internal static class SchemaConstants
    {
        /// <remarks>
        /// If a Key exceeds maximum allowable length limit, then that particular Key-Value pair should be dropped.
        /// </remarks>
        public const int KVP_MaxKeyLength = 150;
        public const int KVP_MaxValueLength = 8192;

        /// <remarks>
        /// Represents 1 tick (1 ten-millionth of a second) less than 1000 days.
        /// </remarks>
        public const string Duration_MaxValue = "999.23:59:59.9999999";

        // TODO: AvailabilityData is currently not in use (2022-06-10).
        public const int AvailabilityData_Id_MaxLength = 512;
        public const int AvailabilityData_Name_MaxLength = 1024;
        public const int AvailabilityData_RunLocation_MaxLength = 1024;
        public const int AvailabilityData_Message_MaxLength = 8192;
        public const int AvailabilityData_Properties_MaxKeyLength = KVP_MaxKeyLength;
        public const int AvailabilityData_Properties_MaxValueLength = KVP_MaxValueLength;
        public const int AvailabilityData_Measurements_MaxKeyLength = KVP_MaxKeyLength;
        public const int AvailabilityData_Duration_LessThanDays = 1000;

        // TODO: DataPoint is currently not in use (2022-06-10).
        public const int DataPoint_Ns_MaxLength = 256;
        public const int DataPoint_Name_MaxLength = 1024;

        // TODO: EventData is currently not in use (2022-06-10).
        public const int EventData_Name_MaxLength = 512;
        public const int EventData_Properties_MaxKeyLength = KVP_MaxKeyLength;
        public const int EventData_Properties_MaxValueLength = 8192;
        public const int EventData_Measurements_MaxKeyLength = KVP_MaxKeyLength;

        public const int ExceptionData_ProblemId_MaxLength = 1024;
        public const int ExceptionData_Properties_MaxKeyLength = KVP_MaxKeyLength;
        public const int ExceptionData_Properties_MaxValueLength = KVP_MaxValueLength;
        public const int ExceptionData_Measurements_MaxKeyLength = KVP_MaxKeyLength; // TODO: ExceptionData.Measurements is currently not in use (2022-06-07).

        public const int ExceptionDetails_TypeName_MaxLength = 1024;
        public const int ExceptionDetails_Message_MaxLength = 32768;
        public const int ExceptionDetails_Stack_MaxLength = 32768;
        public const int ExceptionDetails_Stack_MaxFrames = 100;

        public const int MessageData_Message_MaxLength = 32768;
        public const int MessageData_Properties_MaxKeyLength = KVP_MaxKeyLength;
        public const int MessageData_Properties_MaxValueLength = KVP_MaxValueLength;
        public const int MessageData_Measurements_MaxKeyLength = KVP_MaxKeyLength; // TODO: MessageData.Measurements is currently not in use (2022-06-10).

        public const int MetricsData_Properties_MaxKeyLength = KVP_MaxKeyLength;
        public const int MetricsData_Properties_MaxValueLength = KVP_MaxValueLength;

        // TODO: PageViewData is currently not in use (2022-06-10).
        public const int PageViewData_Id_MaxLength = 512;
        public const int PageViewData_Name_MaxLength = 1024;
        public const int PageViewData_Url_MaxLength = 2048;
        public const int PageViewData_ReferredUri_MaxLength = 2048;
        public const int PageViewData_Properties_MaxKeyLength = KVP_MaxKeyLength;
        public const int PageViewData_Properties_MaxValueLength = KVP_MaxValueLength;
        public const int PageViewData_Measurements_MaxKeyLength = KVP_MaxKeyLength;
        public const int PageViewData_Duration_LessThanDays = 1000;

        // TODO: PageViewPerfData is currently not in use (2022-06-10).
        public const int PageViewPerfData_Id_MaxLength = 512;
        public const int PageViewPerfData_Name_MaxLength = 1024;
        public const int PageViewPerfData_Url_MaxLength = 2048;
        public const int PageViewPerfData_Properties_MaxKeyLength = KVP_MaxKeyLength;
        public const int PageViewPerfData_Properties_MaxValueLength = KVP_MaxValueLength;
        public const int PageViewPerfData_Measurements_MaxKeyLength = KVP_MaxKeyLength;
        public const int PageViewPerfData_Duration_LessThanDays = 1000;

        public const int RemoteDependencyData_Id_MaxLength = 512;
        public const int RemoteDependencyData_Name_MaxLength = 1024;
        public const int RemoteDependencyData_ResultCode_MaxLength = 1024;
        public const int RemoteDependencyData_Data_MaxLength = 8192;
        public const int RemoteDependencyData_Type_MaxLength = 1024;
        public const int RemoteDependencyData_Target_MaxLength = 1024;
        public const int RemoteDependencyData_Properties_MaxKeyLength = KVP_MaxKeyLength;
        public const int RemoteDependencyData_Properties_MaxValueLength = KVP_MaxValueLength;
        public const int RemoteDependencyData_Measurements_MaxKeyLength = KVP_MaxKeyLength; // TODO: RemoteDependencyData.Measurements is currently not in use (2022-06-10).
        public static readonly TimeSpan RemoteDependencyData_Duration_LessThanDays = TimeSpan.FromDays(1000);

        public const int RequestData_Id_MaxLength = 512;
        public const int RequestData_Name_MaxLength = 1024;
        public const int RequestData_ResponseCode_MaxLength = 1024;
        public const int RequestData_Source_MaxLength = 1024; // TODO: RequestData.Source is currently not in use (2022-06-10).
        public const int RequestData_Url_MaxLength = 2048;
        public const int RequestData_Properties_MaxKeyLength = KVP_MaxKeyLength;
        public const int RequestData_Properties_MaxValueLength = KVP_MaxValueLength;
        public const int RequestData_Measurements_MaxKeyLength = KVP_MaxKeyLength; // TODO: RequestData.Measurements is currently not in use (2022-06-10).
        public static readonly TimeSpan RequestData_Duration_LessThanDays = TimeSpan.FromDays(1000);

        public const int StackFrame_Method_MaxLength = 1024;
        public const int StackFrame_Assembly_MaxLength = 1024;
        public const int StackFrame_FileName_MaxLength = 1024;

        public const int TelemetryEnvelope_Seq_MaxLength = 64; // TODO: TelemetryItem.Sequence is currently not in use (2022-06-20).
        public const int TelemetryEnvelope_Name_MaxLength = 1024;
        public const int TelemetryEnvelope_Time_MaxLength = 64;
        public const int TelemetryEnvelope_InstrumentationKey_MaxLength = 40;

        public const int Tags_AiOperationId_MaxLength = 128;
        public const int Tags_AiOperationName_MaxLength = 1024;
        public const int Tags_AiOperationParentId_MaxLength = 512;
        public const int Tags_AiUserAuthUserId_MaxLength = 1024;
        public const int Tags_AiUserId_MaxLength = 1024;
        public const int Tags_AiApplicationVer_MaxLength = 1024;
        public const int Tags_AiCloudRole_MaxLength = 256;
        public const int Tags_AiCloudRoleInstance_MaxLength = 256;
        public const int Tags_AiInternalSdkVersion_MaxLength = 64;
    }
}
