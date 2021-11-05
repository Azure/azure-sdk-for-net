// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Amqp
{
    using System;
    using Microsoft.Azure.EventHubs.Amqp;
    using Xunit;

    public class AmqpExceptionHandlerTests
    {
        /// <summary>
        /// Validate TryTranslateToRetriableException doesn't translate mismatching error.
        /// </summary>
        [Fact]
        [DisplayTestMethodName]
        public void InvalidOperationExceptionWithoutClosingMessageNotTranslated()
        {
            var invalidOperationException = new InvalidOperationException("this is some other error");

            EventHubsException newException;
            var translated = AmqpExceptionHelper.TryTranslateToRetriableException(invalidOperationException, out newException);

            Assert.False(translated, "TryTranslateToRetriableException returned true");
        }

        /// <summary>
        /// Validate TryTranslateToRetriableException doesn't translate mismatching exception.
        /// </summary>
        [Fact]
        [DisplayTestMethodName]
        public void MismatchingExceptionNotTranslated()
        {
            var argumentException = new ArgumentException();

            EventHubsException newException;
            var translated = AmqpExceptionHelper.TryTranslateToRetriableException(argumentException, out newException);

            Assert.False(translated, "TryTranslateToRetriableException returned true");
        }

        /// <summary>
        /// Validate InvalidOperationException with 'connection is closing' message translates to retriable EventHubsException
        /// </summary>
        [Fact]
        [DisplayTestMethodName]
        public void InvalidOperationExceptionWithClosingMessageTranslated()
        {
            var invalidOperationException = new InvalidOperationException("Can't create session when the connection is closing.");
            
            EventHubsException newException;
            var translated = AmqpExceptionHelper.TryTranslateToRetriableException(invalidOperationException, out newException);

            Assert.True(translated, "TryTranslateToRetriableException returned false");
            Assert.True(newException.IsTransient, "newException.IsTransient == false");
            Assert.True(newException.InnerException == invalidOperationException, "newException.InnerException != invalidOperationException");
        }
    }
}
