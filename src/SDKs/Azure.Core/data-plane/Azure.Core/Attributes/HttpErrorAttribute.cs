// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Core
{
    /// <summary>
    /// Represents errors that the application might handle.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class HttpErrorAttribute : KnownExceptionAttribute
    {
        public HttpErrorAttribute(Type exceptionType, int statusCode)
            : base(exceptionType)
        {
            StatusCode = statusCode;
        }

        public int StatusCode { get; }
    }
}
