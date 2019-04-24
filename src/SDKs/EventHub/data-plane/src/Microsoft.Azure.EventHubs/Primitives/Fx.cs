// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;
    using System.Diagnostics;

    static class Fx
    {
        private static readonly Lazy<ExceptionUtility> exceptionUtility = new Lazy<ExceptionUtility>(() => new ExceptionUtility());

        public static ExceptionUtility Exception => exceptionUtility.Value;

        [Conditional("DEBUG")]
        public static void Assert(bool condition, string message)
        {
            Debug.Assert(condition, message);
        }
    }
}
