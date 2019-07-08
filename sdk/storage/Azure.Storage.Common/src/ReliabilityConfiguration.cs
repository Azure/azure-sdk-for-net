// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Storage.Common
{
    struct ReliabilityConfiguration
    {
        public static ReliabilityConfiguration Default = new ReliabilityConfiguration(default, default, default);

        public Action Reset { get; }
        public Action Cleanup { get; }
        public Func<Exception, bool> ExceptionPredicate { get; }

        public ReliabilityConfiguration(Action reset = default, Action cleanup = default, Func<Exception, bool> exceptionPredicate = default)
        {
            this.Reset = reset ?? NoOp;
            this.Cleanup = cleanup ?? NoOp;
            this.ExceptionPredicate = exceptionPredicate ?? AllExceptions;
        }

        static Action NoOp => () => { };
        static Func<Exception, bool> AllExceptions => e => true;
    }
}
