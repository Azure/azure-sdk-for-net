// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ServiceModel.Rest;

public class RequestErrorException : Exception
{
    private IResponse _result;

    public RequestErrorException(IResponse response) : base(response.Content.ToString())
    {
        _result = response;
    }

    public override string ToString()
    {
        return _result.Content.ToString();
    }
}
