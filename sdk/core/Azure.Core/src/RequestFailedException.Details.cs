// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure
{
    public partial class RequestFailedException
    {
        private readonly struct ErrorDetails
        {
            public ErrorDetails(string message, string? errorCode, IDictionary<string, string>? data)
            {
                Message = message;
                ErrorCode = errorCode;
                Data = data;
            }

            public string Message { get; }

            public string? ErrorCode { get; }

            public IDictionary<string, string>? Data { get; }
        }
    }
}
