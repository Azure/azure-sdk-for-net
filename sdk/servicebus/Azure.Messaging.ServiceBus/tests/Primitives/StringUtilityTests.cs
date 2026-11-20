// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Messaging.ServiceBus.Primitives;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="StringUtility" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class StringUtilityTests
    {
        /// <summary>
        ///   Provides the lock token test cases for the <see cref="StringUtility.GetFormattedLockTokens(IReadOnlyList{ServiceBusReceivedMessage})" /> tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> LockTokenCases()
        {
            var first = Guid.NewGuid();
            var second = Guid.NewGuid();
            var third = Guid.NewGuid();

            yield return new object[] { Array.Empty<Guid>() };
            yield return new object[] { new[] { Guid.Empty } };
            yield return new object[] { new[] { Guid.Empty, Guid.Empty } };
            yield return new object[] { new[] { first } };
            yield return new object[] { new[] { first, second, third } };
            yield return new object[] { new[] { Guid.Empty, first } };
            yield return new object[] { new[] { first, Guid.Empty } };
            yield return new object[] { new[] { first, Guid.Empty, second, Guid.Empty, third } };
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="StringUtility.GetFormattedLockTokens(IReadOnlyList{ServiceBusReceivedMessage})" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(LockTokenCases))]
        public void GetFormattedLockTokensForMessagesMatchesLockTokens(Guid[] lockTokens)
        {
            var messages = lockTokens
                .Select(lockToken => new ServiceBusReceivedMessage { LockTokenGuid = lockToken })
                .ToList();

            var expected = $"[{string.Join(", ", lockTokens.Where(lockToken => lockToken != Guid.Empty))}]";

            Assert.That(StringUtility.GetFormattedLockTokens(messages), Is.EqualTo(expected));
            Assert.That(StringUtility.GetFormattedLockTokens(lockTokens), Is.EqualTo(expected));
        }
    }
}
