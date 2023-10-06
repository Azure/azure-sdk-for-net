// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core.Pipeline;

// TODO: for now, we need to revisit the abstraction layers and probably clean this up later.

public abstract class MessagePipelineTransport : PipelineTransport<PipelineMessage, PipelinePolicy>
{
}
