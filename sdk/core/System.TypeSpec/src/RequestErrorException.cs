// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ServiceModel.Rest;

public class RequestErrorException : Exception
{
    private Result _result;

    public RequestErrorException(Result result) : base(result.Content.ToString())
    {
        _result = result;
    }

    public override string ToString()
    {
        return _result.Content.ToString();
    }
}
