// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel.Rest.Core;
using System.Threading;

namespace System.ServiceModel.Rest;

public class RequestOptions : PipelineOptions
{
    // TODO: remove transport parameter once the policy is in this dll
    public RequestOptions(PipelineTransport<PipelineMessage> transport)
        : base(transport) { }

    public CancellationToken CancellationToken { get; set; }
}
