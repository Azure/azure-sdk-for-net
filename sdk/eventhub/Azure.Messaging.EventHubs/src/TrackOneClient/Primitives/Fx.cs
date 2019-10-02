// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;

namespace TrackOne
{
    internal static class Fx
    {
        private static readonly Lazy<ExceptionUtility> s_exceptionUtility = new Lazy<ExceptionUtility>(() => new ExceptionUtility());

        public static ExceptionUtility Exception => s_exceptionUtility.Value;

        [Conditional("DEBUG")]
        public static void Assert(bool condition, string message)
        {
            Debug.Assert(condition, message);
        }
    }
}
