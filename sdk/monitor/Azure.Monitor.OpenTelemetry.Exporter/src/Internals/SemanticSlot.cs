// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    /// <summary>
    /// Dense index assigned to each attribute recognized by <see cref="ActivityTagsProcessor"/>.
    /// Lets callers read a mapped tag by array index instead of scanning for a string key.
    /// </summary>
    internal enum SemanticSlot : byte
    {
        DbStatement,
        DbQueryText,
        DbSystem,
        DbSystemName,
        DbName,
        DbNamespace,

        HttpMethod,
        HttpUrl,
        HttpStatusCode,
        HttpScheme,
        HttpHost,
        HttpHostPort,
        HttpTarget,
        HttpUserAgent,
        HttpRoute,

        HttpRequestMethod,
        HttpResponseStatusCode,
        ServerAddress,
        ServerPort,
        UrlFull,
        UrlPath,
        UrlScheme,
        UrlQuery,
        UserAgentOriginal,
        ClientAddress,

        AzureNameSpace,

        PeerService,
        NetPeerName,
        NetPeerIp,
        NetPeerPort,
        NetHostPort,
        NetHostName,
        OtelStatusCode,

        MessagingSystem,
        MessagingDestinationName,
        NetworkProtocolName,

        EnduserId,
        EnduserPseudoId,
        MicrosoftClientIp,

        MicrosoftDependencyData,
        MicrosoftDependencyName,
        MicrosoftOperationName,
        MicrosoftDependencyResultCode,
        MicrosoftDependencyTarget,
        MicrosoftDependencyType,
        MicrosoftRequestName,
        MicrosoftRequestUrl,
        MicrosoftRequestSource,
        MicrosoftRequestResultCode,

        MicrosoftSessionId,
        AiDeviceId,
        AiDeviceModel,
        AiDeviceType,
        AiDeviceOsVersion,
        MicrosoftSyntheticSource,
        MicrosoftUserAccountId,

        /// <summary>Not a slot. Sizes the backing index.</summary>
        Count,
    }
}
