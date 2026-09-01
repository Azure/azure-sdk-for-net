// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class SemanticSlotMap
    {
        private static readonly Dictionary<string, SemanticSlot> s_slots = new(capacity: (int)SemanticSlot.Count)
        {
            [SemanticConventions.AttributeDbStatement] = SemanticSlot.DbStatement,
            [SemanticConventions.AttributeDbQueryText] = SemanticSlot.DbQueryText,
            [SemanticConventions.AttributeDbSystem] = SemanticSlot.DbSystem,
            [SemanticConventions.AttributeDbSystemName] = SemanticSlot.DbSystemName,
            [SemanticConventions.AttributeDbName] = SemanticSlot.DbName,
            [SemanticConventions.AttributeDbNamespace] = SemanticSlot.DbNamespace,

            [SemanticConventions.AttributeHttpMethod] = SemanticSlot.HttpMethod,
            [SemanticConventions.AttributeHttpUrl] = SemanticSlot.HttpUrl,
            [SemanticConventions.AttributeHttpStatusCode] = SemanticSlot.HttpStatusCode,
            [SemanticConventions.AttributeHttpScheme] = SemanticSlot.HttpScheme,
            [SemanticConventions.AttributeHttpHost] = SemanticSlot.HttpHost,
            [SemanticConventions.AttributeHttpHostPort] = SemanticSlot.HttpHostPort,
            [SemanticConventions.AttributeHttpTarget] = SemanticSlot.HttpTarget,
            [SemanticConventions.AttributeHttpUserAgent] = SemanticSlot.HttpUserAgent,
            [SemanticConventions.AttributeHttpRoute] = SemanticSlot.HttpRoute,

            [SemanticConventions.AttributeHttpRequestMethod] = SemanticSlot.HttpRequestMethod,
            [SemanticConventions.AttributeHttpResponseStatusCode] = SemanticSlot.HttpResponseStatusCode,
            [SemanticConventions.AttributeServerAddress] = SemanticSlot.ServerAddress,
            [SemanticConventions.AttributeServerPort] = SemanticSlot.ServerPort,
            [SemanticConventions.AttributeUrlFull] = SemanticSlot.UrlFull,
            [SemanticConventions.AttributeUrlPath] = SemanticSlot.UrlPath,
            [SemanticConventions.AttributeUrlScheme] = SemanticSlot.UrlScheme,
            [SemanticConventions.AttributeUrlQuery] = SemanticSlot.UrlQuery,
            [SemanticConventions.AttributeUserAgentOriginal] = SemanticSlot.UserAgentOriginal,
            [SemanticConventions.AttributeClientAddress] = SemanticSlot.ClientAddress,

            [SemanticConventions.AttributeAzureNameSpace] = SemanticSlot.AzureNameSpace,

            [SemanticConventions.AttributePeerService] = SemanticSlot.PeerService,
            [SemanticConventions.AttributeNetPeerName] = SemanticSlot.NetPeerName,
            [SemanticConventions.AttributeNetPeerIp] = SemanticSlot.NetPeerIp,
            [SemanticConventions.AttributeNetPeerPort] = SemanticSlot.NetPeerPort,
            [SemanticConventions.AttributeNetHostPort] = SemanticSlot.NetHostPort,
            [SemanticConventions.AttributeNetHostName] = SemanticSlot.NetHostName,
            ["otel.status_code"] = SemanticSlot.OtelStatusCode,

            [SemanticConventions.AttributeMessagingSystem] = SemanticSlot.MessagingSystem,
            [SemanticConventions.AttributeMessagingDestinationName] = SemanticSlot.MessagingDestinationName,
            [SemanticConventions.AttributeNetworkProtocolName] = SemanticSlot.NetworkProtocolName,

            [SemanticConventions.AttributeEnduserId] = SemanticSlot.EnduserId,
            [SemanticConventions.AttributeEnduserPseudoId] = SemanticSlot.EnduserPseudoId,
            [SemanticConventions.AttributeMicrosoftClientIp] = SemanticSlot.MicrosoftClientIp,

            [SemanticConventions.AttributeMicrosoftDependencyData] = SemanticSlot.MicrosoftDependencyData,
            [SemanticConventions.AttributeMicrosoftDependencyName] = SemanticSlot.MicrosoftDependencyName,
            [SemanticConventions.AttributeMicrosoftOperationName] = SemanticSlot.MicrosoftOperationName,
            [SemanticConventions.AttributeMicrosoftDependencyResultCode] = SemanticSlot.MicrosoftDependencyResultCode,
            [SemanticConventions.AttributeMicrosoftDependencyTarget] = SemanticSlot.MicrosoftDependencyTarget,
            [SemanticConventions.AttributeMicrosoftDependencyType] = SemanticSlot.MicrosoftDependencyType,
            [SemanticConventions.AttributeMicrosoftRequestName] = SemanticSlot.MicrosoftRequestName,
            [SemanticConventions.AttributeMicrosoftRequestUrl] = SemanticSlot.MicrosoftRequestUrl,
            [SemanticConventions.AttributeMicrosoftRequestSource] = SemanticSlot.MicrosoftRequestSource,
            [SemanticConventions.AttributeMicrosoftRequestResultCode] = SemanticSlot.MicrosoftRequestResultCode,

            [SemanticConventions.AttributeMicrosoftSessionId] = SemanticSlot.MicrosoftSessionId,
            [SemanticConventions.AttributeAiDeviceId] = SemanticSlot.AiDeviceId,
            [SemanticConventions.AttributeAiDeviceModel] = SemanticSlot.AiDeviceModel,
            [SemanticConventions.AttributeAiDeviceType] = SemanticSlot.AiDeviceType,
            [SemanticConventions.AttributeAiDeviceOsVersion] = SemanticSlot.AiDeviceOsVersion,
            [SemanticConventions.AttributeMicrosoftSyntheticSource] = SemanticSlot.MicrosoftSyntheticSource,
            [SemanticConventions.AttributeMicrosoftUserAccountId] = SemanticSlot.MicrosoftUserAccountId,
        };

        public static bool TryGetSlot(string key, out SemanticSlot slot) => s_slots.TryGetValue(key, out slot);
    }
}
