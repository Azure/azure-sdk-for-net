// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal struct ActivityTagsProcessor
    {
        private static readonly string[] s_semantics = {
            SemanticConventions.AttributeDbStatement,
            SemanticConventions.AttributeDbQueryText,
            SemanticConventions.AttributeDbSystem,
            SemanticConventions.AttributeDbSystemName,
            SemanticConventions.AttributeDbName,
            SemanticConventions.AttributeDbNamespace,

            // required - HTTP
            SemanticConventions.AttributeHttpMethod,
            SemanticConventions.AttributeHttpUrl,
            SemanticConventions.AttributeHttpStatusCode,
            SemanticConventions.AttributeHttpScheme,
            SemanticConventions.AttributeHttpHost,
            SemanticConventions.AttributeHttpHostPort,
            SemanticConventions.AttributeHttpTarget,
            SemanticConventions.AttributeHttpUserAgent,
            SemanticConventions.AttributeHttpRoute,

            // required - HTTP V2
            SemanticConventions.AttributeHttpRequestMethod,
            SemanticConventions.AttributeHttpResponseStatusCode,
            SemanticConventions.AttributeServerAddress,
            SemanticConventions.AttributeServerPort,
            SemanticConventions.AttributeUrlFull,
            SemanticConventions.AttributeUrlPath,
            SemanticConventions.AttributeUrlScheme,
            SemanticConventions.AttributeUrlQuery,
            SemanticConventions.AttributeUserAgentOriginal,
            SemanticConventions.AttributeClientAddress,

            // required - Azure
            SemanticConventions.AttributeAzureNameSpace,

            SemanticConventions.AttributePeerService,
            SemanticConventions.AttributeNetPeerName,
            SemanticConventions.AttributeNetPeerIp,
            SemanticConventions.AttributeNetPeerPort,
            SemanticConventions.AttributeNetHostPort,
            SemanticConventions.AttributeNetHostName,
            "otel.status_code",

            // required - Messaging
            SemanticConventions.AttributeMessagingSystem,
            SemanticConventions.AttributeMessagingDestinationName,
            SemanticConventions.AttributeNetworkProtocolName,

            // Others
            SemanticConventions.AttributeEnduserId,
            SemanticConventions.AttributeEnduserPseudoId,
            SemanticConventions.AttributeMicrosoftClientIp,

            // Microsoft Application Insights Override Attributes
            SemanticConventions.AttributeMicrosoftDependencyData,
            SemanticConventions.AttributeMicrosoftDependencyName,
            SemanticConventions.AttributeMicrosoftOperationName,
            SemanticConventions.AttributeMicrosoftDependencyResultCode,
            SemanticConventions.AttributeMicrosoftDependencyTarget,
            SemanticConventions.AttributeMicrosoftDependencyType,
            SemanticConventions.AttributeMicrosoftRequestName,
            SemanticConventions.AttributeMicrosoftRequestUrl,
            SemanticConventions.AttributeMicrosoftRequestSource,
            SemanticConventions.AttributeMicrosoftRequestResultCode,

            // Context tag attributes from Application Insights shim
            SemanticConventions.AttributeMicrosoftSessionId,
            SemanticConventions.AttributeAiSessionIsFirst,
            SemanticConventions.AttributeAiDeviceId,
            SemanticConventions.AttributeAiDeviceModel,
            SemanticConventions.AttributeAiDeviceOemName,
            SemanticConventions.AttributeAiDeviceType,
            SemanticConventions.AttributeAiDeviceOsVersion,
            SemanticConventions.AttributeMicrosoftSyntheticSource,
            SemanticConventions.AttributeMicrosoftUserAccountId,
        };

        internal static readonly HashSet<string> s_semanticsSet = new(s_semantics);

        public AzMonList MappedTags;
        public AzMonList UnMappedTags;

        public OperationType activityType { get; set; }

        public string? AzureNamespace { get; private set; } = null;

        public string? EndUserId { get; private set; } = null;

        public string? EndUserPseudoId { get; private set; } = null;

        public string? SessionId { get; private set; } = null;

        public string? SessionIsFirst { get; private set; } = null;

        public string? DeviceId { get; private set; } = null;

        public string? DeviceModel { get; private set; } = null;

        public string? DeviceOemName { get; private set; } = null;

        public string? DeviceType { get; private set; } = null;

        public string? DeviceOsVersion { get; private set; } = null;

        public string? SyntheticSource { get; private set; } = null;

        public string? UserAccountId { get; private set; } = null;

        public bool HasOverrideAttributes { get; private set; } = false;

        public ActivityTagsProcessor()
        {
            MappedTags = AzMonList.Initialize();
            UnMappedTags = AzMonList.Initialize();
        }

        public void CategorizeTags(Activity activity)
        {
            foreach (ref readonly var tag in activity.EnumerateTagObjects())
            {
                if (tag.Value == null)
                {
                    continue;
                }

                if (s_semanticsSet.Contains(tag.Key))
                {
                    switch (tag.Key)
                    {
                        case SemanticConventions.AttributeHttpMethod:
                            activityType = OperationType.Http;
                            break;
                        case SemanticConventions.AttributeHttpRequestMethod:
                            activityType = OperationType.Http | OperationType.V2;
                            break;
                        case SemanticConventions.AttributeDbSystemName:
                            activityType = OperationType.Db | OperationType.V2;
                            break;
                        case SemanticConventions.AttributeDbSystem:
                            activityType = OperationType.Db;
                            break;
                        case SemanticConventions.AttributeMessagingSystem:
                            activityType = OperationType.Messaging;
                            break;
                        case SemanticConventions.AttributeAzureNameSpace:
                            AzureNamespace = tag.Value.ToString();
                            break;
                        case SemanticConventions.AttributeEnduserId:
                            EndUserId = tag.Value.ToString();
                            continue;
                        case SemanticConventions.AttributeEnduserPseudoId:
                            EndUserPseudoId = tag.Value.ToString();
                            continue;
                        case SemanticConventions.AttributeMicrosoftSessionId:
                            SessionId = tag.Value.ToString();
                            continue;
                        case SemanticConventions.AttributeAiSessionIsFirst:
                            SessionIsFirst = tag.Value.ToString();
                            continue;
                        case SemanticConventions.AttributeAiDeviceId:
                            DeviceId = tag.Value.ToString();
                            continue;
                        case SemanticConventions.AttributeAiDeviceModel:
                            DeviceModel = tag.Value.ToString();
                            continue;
                        case SemanticConventions.AttributeAiDeviceOemName:
                            DeviceOemName = tag.Value.ToString();
                            continue;
                        case SemanticConventions.AttributeAiDeviceType:
                            DeviceType = tag.Value.ToString();
                            continue;
                        case SemanticConventions.AttributeAiDeviceOsVersion:
                            DeviceOsVersion = tag.Value.ToString();
                            continue;
                        case SemanticConventions.AttributeMicrosoftSyntheticSource:
                            SyntheticSource = tag.Value.ToString();
                            continue;
                        case SemanticConventions.AttributeMicrosoftUserAccountId:
                            UserAccountId = tag.Value.ToString();
                            continue;
                        case SemanticConventions.AttributeMicrosoftDependencyData:
                        case SemanticConventions.AttributeMicrosoftDependencyName:
                        case SemanticConventions.AttributeMicrosoftDependencyTarget:
                        case SemanticConventions.AttributeMicrosoftDependencyType:
                        case SemanticConventions.AttributeMicrosoftDependencyResultCode:
                        case SemanticConventions.AttributeMicrosoftOperationName:
                        case SemanticConventions.AttributeMicrosoftRequestName:
                        case SemanticConventions.AttributeMicrosoftRequestUrl:
                        case SemanticConventions.AttributeMicrosoftRequestSource:
                        case SemanticConventions.AttributeMicrosoftRequestResultCode:
                            HasOverrideAttributes = true;
                            break;
                    }

                    AzMonList.Add(ref MappedTags, tag);
                }
                else
                {
                    // If the tag value is an array, there is no need to check for semantics;
                    // directly add it to the Unmapped list.
                    if (tag.Value is Array array)
                    {
                        AzMonList.Add(ref UnMappedTags, new KeyValuePair<string, object?>(tag.Key, array.ToCommaDelimitedString()));
                        continue;
                    }

                    AzMonList.Add(ref UnMappedTags, tag);
                }
            }
        }

        public void Return()
        {
            MappedTags.Return();
            UnMappedTags.Return();
        }
    }
}
