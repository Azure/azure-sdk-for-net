// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ServiceModel.Rest.Core;

public class RequestErrorException : Exception
{
    private PipelineResponse _result;

    public RequestErrorException(PipelineResponse response) : base(response.Content.ToString())
    {
        _result = response;
    }

    public override string ToString()
    {
        return _result.Content.ToString();
    }
}
