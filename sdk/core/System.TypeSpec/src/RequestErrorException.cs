// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ServiceModel.Rest;

public class RequestErrorException : Exception
{
    private Result result;

    public RequestErrorException(Result result)
    {
        this.result = result;
    }
}
