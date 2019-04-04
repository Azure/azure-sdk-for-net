// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure
{
    public class RequestFailedException : Exception
    {
        int _status;

        public RequestFailedException(Response response, string summary = null)
            : this(response, summary, null)
        {}

        public RequestFailedException(Response response, string summary, Exception innerException)
            : base(FormatMessage(response, summary), innerException)
        {
            _status = response.Status;
        }

        private static string FormatMessage(Response response, string summary)
        {
            if (summary != null) {
                return $"{summary}{Environment.NewLine}{response}";
            }
            else {
                return response.ToString();
            }
        }

        public int Status => _status; 
    }
}
