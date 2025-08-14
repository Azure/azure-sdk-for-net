// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Pipeline;

internal interface ISupportsTransportCertificateUpdate
{
    /// <summary>
    /// Event that is triggered when the transport needs to be updated.
    /// </summary>
    public event Action<HttpPipelineTransportOptions>? TransportOptionsChanged;
}