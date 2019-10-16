// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure
{
    public class RequestFailedException : Exception
    {
        public int Status { get; }

        public RequestFailedException(string message) : this(0, message)
        {
        }

        public RequestFailedException(string message, Exception? innerException) : this(0, message, innerException)
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
