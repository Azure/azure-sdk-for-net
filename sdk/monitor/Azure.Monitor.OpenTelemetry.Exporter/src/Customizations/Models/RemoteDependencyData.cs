﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class RemoteDependencyData
    {
        // https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/trace/semantic_conventions/database.md#connection-level-attributes
        internal static readonly HashSet<string?> s_sqlDbs = new HashSet<string?>() { "mssql" };

        public RemoteDependencyData(int version, Activity activity, ref ActivityTagsProcessor activityTagsProcessor) : base(version)
        {
            string? dependencyName = null;
            bool isNewSchemaVersion = false;
            Properties = new ChangeTrackingDictionary<string, string>();
            Measurements = new ChangeTrackingDictionary<string, double>();

            if (activityTagsProcessor.activityType.HasFlag(OperationType.V2))
            {
                isNewSchemaVersion = true;
                activityTagsProcessor.activityType &= ~OperationType.V2;
            }

            switch (activityTagsProcessor.activityType)
            {
                case OperationType.Http:
                    SetHttpDependencyPropertiesAndDependencyName(activity, ref activityTagsProcessor.MappedTags, isNewSchemaVersion, out dependencyName);
                    break;
                case OperationType.Db:
                    SetDbDependencyProperties(ref activityTagsProcessor.MappedTags);
                    break;
                case OperationType.Rpc:
                    SetRpcDependencyProperties(ref activityTagsProcessor.MappedTags);
                    break;
                case OperationType.Messaging:
                    SetMessagingDependencyProperties(activity, ref activityTagsProcessor.MappedTags);
                    break;
            }

            dependencyName ??= activity.DisplayName;
            Name = dependencyName?.Truncate(SchemaConstants.RemoteDependencyData_Name_MaxLength);
            Id = activity.Context.SpanId.ToHexString();
            Duration = activity.Duration < SchemaConstants.RemoteDependencyData_Duration_LessThanDays
                ? activity.Duration.ToString("c", CultureInfo.InvariantCulture)
                : SchemaConstants.Duration_MaxValue;
            Success = activity.Status != ActivityStatusCode.Error;

            if (activityTagsProcessor.AzureNamespace != null)
            {
                Type = TraceHelper.GetAzureSDKDependencyType(activity.Kind, activityTagsProcessor.AzureNamespace);
            }
            else if (activity.Kind == ActivityKind.Internal)
            {
                Type = "InProc";
            }

            TraceHelper.AddActivityLinksToProperties(activity, ref activityTagsProcessor.UnMappedTags);
            TraceHelper.AddPropertiesToTelemetry(Properties, ref activityTagsProcessor.UnMappedTags);
        }

        private void SetHttpDependencyPropertiesAndDependencyName(Activity activity, ref AzMonList httpTagObjects, bool isNewSchemaVersion, out string dependencyName)
        {
            string? httpUrl;
            string? resultCode;
            string? target;

            if (isNewSchemaVersion)
            {
                httpUrl = AzMonList.GetTagValue(ref httpTagObjects, SemanticConventions.AttributeUrlFull)?.ToString();
                dependencyName = httpTagObjects.GetNewSchemaHttpDependencyName(httpUrl) ?? activity.DisplayName;
                target = httpTagObjects.GetNewSchemaHttpDependencyTarget();
                resultCode = AzMonList.GetTagValue(ref httpTagObjects, SemanticConventions.AttributeHttpResponseStatusCode)?.ToString();
            }
            else
            {
                httpUrl = httpTagObjects.GetDependencyUrl();
                dependencyName = httpTagObjects.GetHttpDependencyName(httpUrl) ?? activity.DisplayName;
                target = httpTagObjects.GetHttpDependencyTarget();
                resultCode = AzMonList.GetTagValue(ref httpTagObjects, SemanticConventions.AttributeHttpStatusCode)?.ToString();
            }

            Type = "Http";
            Data = httpUrl?.Truncate(SchemaConstants.RemoteDependencyData_Data_MaxLength);
            Target = target?.Truncate(SchemaConstants.RemoteDependencyData_Target_MaxLength);
            ResultCode = resultCode?.Truncate(SchemaConstants.RemoteDependencyData_ResultCode_MaxLength) ?? "0";
        }

        private void SetDbDependencyProperties(ref AzMonList dbTagObjects)
        {
            var dbAttributeTagObjects = AzMonList.GetTagValues(ref dbTagObjects, SemanticConventions.AttributeDbStatement, SemanticConventions.AttributeDbSystem);
            Data = dbAttributeTagObjects[0]?.ToString().Truncate(SchemaConstants.RemoteDependencyData_Data_MaxLength);
            var (DbName, DbTarget) = dbTagObjects.GetDbDependencyTargetAndName();
            Target = DbTarget?.Truncate(SchemaConstants.RemoteDependencyData_Target_MaxLength);
            Type = s_sqlDbs.Contains(dbAttributeTagObjects[1]?.ToString()) ? "SQL" : dbAttributeTagObjects[1]?.ToString().Truncate(SchemaConstants.RemoteDependencyData_Type_MaxLength);

            // special case for db.name
            var sanitizedDbName = DbName?.Truncate(SchemaConstants.KVP_MaxValueLength);
            if (sanitizedDbName != null)
            {
                Properties.Add(SemanticConventions.AttributeDbName, sanitizedDbName);
            }
        }

        private void SetRpcDependencyProperties(ref AzMonList rpcTagObjects)
        {
            var rpcAttributeTagObjects = AzMonList.GetTagValues(ref rpcTagObjects, SemanticConventions.AttributeRpcService, SemanticConventions.AttributeRpcSystem, SemanticConventions.AttributeRpcStatus);
            Data = rpcAttributeTagObjects[0]?.ToString().Truncate(SchemaConstants.RemoteDependencyData_Data_MaxLength);
            Type = rpcAttributeTagObjects[1]?.ToString().Truncate(SchemaConstants.RemoteDependencyData_Type_MaxLength);
            ResultCode = rpcAttributeTagObjects[2]?.ToString().Truncate(SchemaConstants.RemoteDependencyData_ResultCode_MaxLength);
        }

        private void SetMessagingDependencyProperties(Activity activity, ref AzMonList messagingTagObjects)
        {
            var (messagingUrl, target) = messagingTagObjects.GetMessagingUrlAndSourceOrTarget(activity.Kind);
            Data = messagingUrl?.Truncate(SchemaConstants.RemoteDependencyData_Data_MaxLength);
            Target = target?.Truncate(SchemaConstants.RemoteDependencyData_Target_MaxLength);
            Type = AzMonList.GetTagValue(ref messagingTagObjects, SemanticConventions.AttributeMessagingSystem)?.ToString().Truncate(SchemaConstants.RemoteDependencyData_Type_MaxLength);
        }
    }
}
