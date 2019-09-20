// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
