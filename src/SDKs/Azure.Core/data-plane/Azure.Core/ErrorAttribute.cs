// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Core
{
    public class KnownExceptionAttribute : Attribute
    {
        public KnownExceptionAttribute(Type exceptionType)
            => ExceptionType = exceptionType;

        public Type ExceptionType { get; }

        public string Message { get; set; }
    }

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

    /// <summary>
    /// Represents errors resulting from misuse of the API. The application code should be changed/fixed.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class UsageErrorsAttribute : KnownExceptionAttribute
    {
        public UsageErrorsAttribute(Type exceptionType, params int[] statusCodes)
            : base(exceptionType)
        {
            StatusCodes = statusCodes;
        }

        public ReadOnlyMemory<int> StatusCodes { get; }
    }
}
