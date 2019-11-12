// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage
{
    [Obsolete("This type is only available for backwards compatibility with the 12.0.0 version of Storage libraries. It should not be used for new development.", true)]
    internal struct ReliabilityConfiguration
    {
        public static ReliabilityConfiguration Default = new ReliabilityConfiguration(default, default, default);

        public Action Reset { get; }
        public Action Cleanup { get; }
        public Func<Exception, bool> ExceptionPredicate { get; }

        public ReliabilityConfiguration(Action reset = default, Action cleanup = default, Func<Exception, bool> exceptionPredicate = default)
        {
            Reset = reset ?? NoOp;
            Cleanup = cleanup ?? NoOp;
            ExceptionPredicate = exceptionPredicate ?? AllExceptions;
        }

        private static Action NoOp => () => { };

        private static Func<Exception, bool> AllExceptions => e => true;
    }
}
