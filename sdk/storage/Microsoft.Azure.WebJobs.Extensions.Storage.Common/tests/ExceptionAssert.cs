// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests
{
    public static class ExceptionAssert
    {
        public static void ThrowsArgumentNull(Action action, string expectedParameterName)
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => action.Invoke());
            Assert.AreEqual(expectedParameterName, exception.ParamName);
        }

        public static void ThrowsInvalidOperation(Action action, string expectedMessage)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => action.Invoke());
            Assert.AreEqual(expectedMessage, exception.Message);
        }
    }
}
