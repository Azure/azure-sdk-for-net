// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure
{
    public class RequestFailedException : Exception
    {
        public const int NoStatusCode = 0;
        public int Status { get; }

        public RequestFailedException(string message) : this(NoStatusCode, message)
        {
        }

        public RequestFailedException(string message, Exception? innerException) : this(NoStatusCode, message, innerException)
        {
        }

        public RequestFailedException(int status, string message)
            : this(status, message, null)
        {
        }

        public RequestFailedException(int status, string message, Exception? innerException)
            : base(message, innerException)
        {
            Status = status;
        }
    }
}
