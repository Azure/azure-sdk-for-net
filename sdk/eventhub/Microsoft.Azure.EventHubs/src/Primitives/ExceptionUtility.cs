// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;
    using System.Runtime.ExceptionServices;

    class ExceptionUtility
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
            return Argument(paramName, Resources.ArgumentNullOrWhiteSpace.FormatForUser(paramName));
        }

        public ArgumentOutOfRangeException ArgumentOutOfRange(string paramName, object actualValue, string message)
        {
            return new ArgumentOutOfRangeException(paramName, actualValue, message);
        }

        public InvalidOperationException InvalidOperation(string message)
        {
            return new InvalidOperationException(message);
        }

        public Exception AsError(Exception exception)
        {
            EventHubsEventSource.Log.ThrowingExceptionError(exception.ToString());
            return exception;
        }

        /// <summary>
        ///     Attempts to prepare the exception for re-throwing by preserving the stack trace. The returned exception should be immediately thrown.
        /// </summary>
        /// <param name="exception">The exception. May not be <c>null</c>.</param>
        /// <returns>The <see cref="Exception"/> that was passed into this method.</returns>
        public static Exception PrepareForRethrow(Exception exception)
        {
            ExceptionDispatchInfo.Capture(exception).Throw();
            // The code cannot ever get here. We just return a value to work around a badly-designed API (ExceptionDispatchInfo.Throw):
            //  https://connect.microsoft.com/VisualStudio/feedback/details/689516/exceptiondispatchinfo-api-modifications (http://www.webcitation.org/6XQ7RoJmO)
            return exception;
        }
    }
}
