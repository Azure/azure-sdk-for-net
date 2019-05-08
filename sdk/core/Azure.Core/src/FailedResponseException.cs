// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure
{
    public class RequestFailedException : Exception
    {
        public int Status { get; }

        public string ResponseDetails { get; }

        public RequestFailedException(int status, string message, string responseDetails)
            : this(status, message, responseDetails, null)
        {}

        public RequestFailedException(int status, string message, string responseDetails, Exception innerException)
            : base(message, innerException)
        {
            Status = status;
            ResponseDetails = responseDetails;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + ResponseDetails;
        }
    }
}
