// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core;

public abstract class PipelineTransport
{
    public abstract PipelineMessage CreateRequest();

    public abstract void Process(PipelineMessage message);

    public abstract ValueTask ProcessAsync(PipelineMessage message);
}
