// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Globalization;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class RemoteDependencyData
    {
        public RemoteDependencyData(int version, Activity activity, ref ActivityTagsProcessor activityTagsProcessor) : base(version)
        {
            string? dependencyName = null;
            bool isNewSchemaVersion = activityTagsProcessor.IsV2;
            Properties = new ChangeTrackingDictionary<string, string>();
            Measurements = new ChangeTrackingDictionary<string, double>();

            // Process based on operation type
            switch (activityTagsProcessor.BaseActivityType)
            {
                case OperationType.Http:
                    SetHttpDependencyPropertiesAndDependencyName(activity, ref activityTagsProcessor.MappedTags, isNewSchemaVersion, out dependencyName);
                    break;
                case OperationType.Db:
                    SetDbDependencyProperties(ref activityTagsProcessor.MappedTags, isNewSchemaVersion);
                    break;
                case OperationType.Messaging:
                    SetMessagingDependencyProperties(activity, ref activityTagsProcessor.MappedTags);
                    break;
                default:
                    Target = activityTagsProcessor.MappedTags.GetTargetUsingServerAddressAndPort();
                    break;
            }

            // Check for Microsoft override attributes only if present (avoids overhead for standalone OTel usage)
            if (activityTagsProcessor.HasOverrideAttributes)
            {
                var overrideData = activityTagsProcessor.MappedTags[SemanticSlot.MicrosoftDependencyData]?.ToString();
                var overrideName = activityTagsProcessor.MappedTags[SemanticSlot.MicrosoftDependencyName]?.ToString();
                var overrideTarget = activityTagsProcessor.MappedTags[SemanticSlot.MicrosoftDependencyTarget]?.ToString();
                var overrideType = activityTagsProcessor.MappedTags[SemanticSlot.MicrosoftDependencyType]?.ToString();
                var overrideResultCode = activityTagsProcessor.MappedTags[SemanticSlot.MicrosoftDependencyResultCode]?.ToString();

                // Apply overrides if present (these take precedence)
                if (!string.IsNullOrEmpty(overrideData))
                {
                    Data = overrideData.Truncate(SchemaConstants.RemoteDependencyData_Data_MaxLength);
                }

                if (!string.IsNullOrEmpty(overrideName))
                {
                    dependencyName = overrideName;
                }

                if (!string.IsNullOrEmpty(overrideTarget))
                {
                    Target = overrideTarget.Truncate(SchemaConstants.RemoteDependencyData_Target_MaxLength);
                }

                if (!string.IsNullOrEmpty(overrideType))
                {
                    Type = overrideType.Truncate(SchemaConstants.RemoteDependencyData_Type_MaxLength);
                }

                if (!string.IsNullOrEmpty(overrideResultCode))
                {
                    ResultCode = overrideResultCode.Truncate(SchemaConstants.RemoteDependencyData_ResultCode_MaxLength);
                }
            }

            dependencyName ??= activity.DisplayName;
            Name = dependencyName?.Truncate(SchemaConstants.RemoteDependencyData_Name_MaxLength);
            Id = activity.Context.SpanId.ToHexString();
            Duration = activity.Duration < SchemaConstants.RemoteDependencyData_Duration_LessThanDays
                ? activity.Duration.ToString("c", CultureInfo.InvariantCulture)
                : SchemaConstants.Duration_MaxValue;
            Success = activity.Status != ActivityStatusCode.Error;

            // Set Type from Azure namespace if present (unless already set by override attribute)
            if (activityTagsProcessor.AzureNamespace != null)
            {
                if (string.IsNullOrEmpty(Type))
                {
                    Type = TraceHelper.GetAzureSDKDependencyType(activity.Kind, activityTagsProcessor.AzureNamespace);
                }
            }
            else if (activity.Kind == ActivityKind.Internal)
            {
                if (string.IsNullOrEmpty(Type))
                {
                    Type = "InProc";
                }
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
                httpUrl = httpTagObjects[SemanticSlot.UrlFull]?.ToString();
                dependencyName = httpTagObjects.GetNewSchemaHttpDependencyName(httpUrl) ?? activity.DisplayName;
                target = httpTagObjects.GetNewSchemaHttpDependencyTarget();
                resultCode = httpTagObjects[SemanticSlot.HttpResponseStatusCode]?.ToString();
            }
            else
            {
                httpUrl = httpTagObjects.GetDependencyUrl();
                dependencyName = httpTagObjects.GetHttpDependencyName(httpUrl) ?? activity.DisplayName;
                target = httpTagObjects.GetHttpDependencyTarget();
                resultCode = httpTagObjects[SemanticSlot.HttpStatusCode]?.ToString();
            }

            Type = "Http";
            Data = httpUrl?.Truncate(SchemaConstants.RemoteDependencyData_Data_MaxLength);
            Target = target?.Truncate(SchemaConstants.RemoteDependencyData_Target_MaxLength);
            ResultCode = resultCode?.Truncate(SchemaConstants.RemoteDependencyData_ResultCode_MaxLength) ?? "0";
        }

        private void SetDbDependencyProperties(ref AzMonList dbTagObjects, bool isNewSchemaVersion)
        {
            SemanticSlot statementSlot;
            SemanticSlot systemSlot;
            if (isNewSchemaVersion)
            {
                statementSlot = SemanticSlot.DbQueryText;
                systemSlot = SemanticSlot.DbSystemName;
            }
            else
            {
                statementSlot = SemanticSlot.DbStatement;
                systemSlot = SemanticSlot.DbSystem;
            }

            var dbStatement = dbTagObjects[statementSlot];
            var dbSystem = dbTagObjects[systemSlot];
            Data = dbStatement?.ToString().Truncate(SchemaConstants.RemoteDependencyData_Data_MaxLength);
            var (DbName, DbTarget) = dbTagObjects.GetDbDependencyTargetAndName(isNewSchemaVersion);
            Target = DbTarget?.Truncate(SchemaConstants.RemoteDependencyData_Target_MaxLength);
            Type = AzMonListExtensions.s_dbSystems.Contains(dbSystem?.ToString()) ? "SQL" : dbSystem?.ToString().Truncate(SchemaConstants.RemoteDependencyData_Type_MaxLength);

            // special case for db.name
            var sanitizedDbName = DbName?.Truncate(SchemaConstants.KVP_MaxValueLength);
            if (sanitizedDbName != null)
            {
                Properties.Add(SemanticConventions.AttributeDbName, sanitizedDbName);
            }
        }

        private void SetMessagingDependencyProperties(Activity activity, ref AzMonList messagingTagObjects)
        {
            var (messagingUrl, target) = messagingTagObjects.GetMessagingUrlAndSourceOrTarget(activity.Kind);
            Data = messagingUrl?.Truncate(SchemaConstants.RemoteDependencyData_Data_MaxLength);
            Target = target?.Truncate(SchemaConstants.RemoteDependencyData_Target_MaxLength);
            Type = messagingTagObjects[SemanticSlot.MessagingSystem]?.ToString().Truncate(SchemaConstants.RemoteDependencyData_Type_MaxLength);
        }
    }
}
