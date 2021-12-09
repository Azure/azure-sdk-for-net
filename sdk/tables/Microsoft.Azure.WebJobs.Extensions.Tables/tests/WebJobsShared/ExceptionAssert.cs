// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Host.TestCommon
{
    public static class ExceptionAssert
    {
        public static void ThrowsArgument(Action action, string expectedParameterName, string expectedMessage)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => action.Invoke());
            Assert.AreEqual(expectedParameterName, exception.ParamName);
            string fullExpectedMessage = GetFullExpectedArgumentMessage(expectedMessage, expectedParameterName);
            Assert.AreEqual(fullExpectedMessage, exception.Message);
        }
        public static void ThrowsArgumentNull(Action action, string expectedParameterName)
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => action.Invoke());
            Assert.AreEqual(expectedParameterName, exception.ParamName);
        }
        public static void ThrowsArgumentOutOfRange(Action action, string expectedParameterName, string expectedMessage)
        {
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => action.Invoke());
            Assert.AreEqual(expectedParameterName, exception.ParamName);
            string fullExpectedMessage = GetFullExpectedArgumentMessage(expectedMessage, expectedParameterName);
            Assert.AreEqual(fullExpectedMessage, exception.Message);
        }
        public static void ThrowsInvalidOperation(Action action, string expectedMessage)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => action.Invoke());
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        private static string GetFullExpectedArgumentMessage(string message, string parameterName)
        {
            if (parameterName == null)
            {
                return message;
            }
#if NET461
            return $"{message}{Environment.NewLine}Parameter name: {parameterName}";
#else
            return $"{message} (Parameter '{parameterName}')";
#endif
        }
    }
}