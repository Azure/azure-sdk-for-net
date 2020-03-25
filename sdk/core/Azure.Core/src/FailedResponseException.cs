// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure
{
    public class RequestFailedException : Exception
    {
        public int Status { get; }

        public RequestFailedException(int status, string message)
            : this(status, message, null)
        { }

        public RequestFailedException(int status, string message, Exception? innerException)
            : base(message, innerException)
        {
            Status = status;
        }
    }
}
