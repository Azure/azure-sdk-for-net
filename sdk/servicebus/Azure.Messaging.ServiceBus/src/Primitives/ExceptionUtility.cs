// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Primitives
{
    using System;

    internal class ExceptionUtility
    {
        public ArgumentException Argument(string paramName, string message)
        {
            return new ArgumentException(message, paramName);
        }

        public Exception ArgumentNull(string paramName)
        {
            return new ArgumentNullException(paramName);
        }

        public ArgumentException ArgumentNullOrWhiteSpace(string paramName)
        {
            return this.Argument(paramName, Resources.ArgumentNullOrWhiteSpace.FormatForUser(paramName));
        }

        public ArgumentOutOfRangeException ArgumentOutOfRange(string paramName, object actualValue, string message)
        {
            return new ArgumentOutOfRangeException(paramName, actualValue, message);
        }

        public Exception AsError(Exception exception)
        {
            return exception;
        }
    }
}
