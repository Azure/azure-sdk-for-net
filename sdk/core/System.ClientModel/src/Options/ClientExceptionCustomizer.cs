// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public class ClientExceptionCustomizer
{
    public abstract ClientResultException FromResponse(PipelineResponse response);
    public abstract Task<ClientResultException> FromResponseAsync(PipelineResponse response);
}
