// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Base.Diagnostics
{
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
