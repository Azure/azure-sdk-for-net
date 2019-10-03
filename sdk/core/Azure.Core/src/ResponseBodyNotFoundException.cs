// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure
{
    // TODO: Derive from common ResponseException type.
    public class ResponseBodyNotFoundException : Exception
    {
        public int Status { get; }

        public ResponseBodyNotFoundException(int status, string message, Exception? innerException = null)
            : base(message, innerException)
        {
            Status = status;
        }
    }
}
