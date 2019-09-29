// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure
{
    public class ResourceModifiedException : Exception
    {
        public int Status { get; }

        public ResourceModifiedException()
            : this(304, "Resource was modified.", null)
        {
        }

        public ResourceModifiedException(int status, string message, Exception? innerException)
            : base(message, innerException)
        {
            Status = status;
        }
    }
}
