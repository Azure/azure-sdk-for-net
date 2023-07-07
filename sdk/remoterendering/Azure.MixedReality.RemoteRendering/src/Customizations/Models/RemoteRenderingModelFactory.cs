// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

[assembly: CodeGenSuppressType("MixedRealityRemoteRenderingModelFactory")]

namespace Azure.MixedReality.RemoteRendering
{
    /// <summary>
    /// Model factory that enables mocking for the Remote Rendering library.
    /// </summary>
    public static partial class RemoteRenderingModelFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssetConversionOutput"/> class for mocking purposes.
        /// </summary>
        public static AssetConversionOutput AssetConversionOutput(Uri outputAssetUri)
            => new AssetConversionOutput(outputAssetUri.ToString());

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteRenderingServiceError"/> class for mocking purposes.
        /// </summary>
        public static RemoteRenderingServiceError RemoteRenderingServiceError(string code, string message, IReadOnlyList<RemoteRenderingServiceError> details, string target, RemoteRenderingServiceError innerError)
            => new RemoteRenderingServiceError(code, message, details, target, innerError);

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetConversion"/> class for mocking purposes.
        /// </summary>
        public static AssetConversion AssetConversion(string conversionId, AssetConversionOptions options, AssetConversionOutput output, RemoteRenderingServiceError error, AssetConversionStatus status, DateTimeOffset createdOn)
            => new AssetConversion(conversionId, options, output, error, status, createdOn);

        /// <summary>
        /// Initializes a new instance of the <see cref="RenderingSession"/> class for mocking purposes.
        /// </summary>
        public static RenderingSession RenderingSession(string sessionId, int? arrInspectorPort, int? handshakePort, int? elapsedTimeMinutes, string host, int? maxLeaseTimeMinutes, RenderingServerSize size, RenderingSessionStatus status, float? teraflops, RemoteRenderingServiceError error, DateTimeOffset? createdOn)
            => new RenderingSession(sessionId, arrInspectorPort, handshakePort, elapsedTimeMinutes, host, maxLeaseTimeMinutes, size, status, teraflops, error, createdOn);
    }
}
