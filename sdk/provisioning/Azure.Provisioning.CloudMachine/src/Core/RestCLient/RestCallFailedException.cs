// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;

namespace Azure
{
    public class RestCallFailedException : Exception
    {
        public RestCallFailedException(string message, PipelineResponse response)
            : base(message, new System.ClientModel.ClientResultException(response)) { }
    }
}
