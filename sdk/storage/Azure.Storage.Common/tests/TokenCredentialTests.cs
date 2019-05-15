// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azure.Storage.Common.Test
{
    [TestClass]
    public class TokenCredentialTests
    {

        [TestMethod]
        [Description("Basic instantiation and disposal.")]
        public void TokenDispose()
        {
            var token = new TokenCredentials("TOKEN_STRING");
            token.Dispose();
        }

        [TestMethod]
        [Description("Basic timer triggering test.")]
        public void TimerShouldTriggerPeriodically()
        {
            // token updater is triggered every 5 seconds
            var tokenCredential = new TokenCredentials("", FastTokenUpdater);

            // make sure the token starts with the right value, t=0
            Assert.AreEqual("0", tokenCredential.Token);

            // wait until timer triggers for the first time and validate token value, t=6
            Task.Delay(TimeSpan.FromSeconds(1.2)).Wait();
            Assert.AreEqual("00", tokenCredential.Token);

            // wait until timer triggers for the second time and validate token value, t=12
            Task.Delay(TimeSpan.FromSeconds(1.2)).Wait();
            Assert.AreEqual("000", tokenCredential.Token);

            // stop the time and make sure it does not trigger anymore, t=18
            tokenCredential.Dispose();
            Task.Delay(TimeSpan.FromSeconds(1.2)).Wait();
            Assert.AreEqual("000", tokenCredential.Token);
        }

        [TestMethod]
        [Description("Make sure the token updater only gets triggered after the previous update finishes.")]
        public void UpdaterShouldRunOneAtATime()
        {
            // token updater is triggered every 5 seconds
            // however, the slow updater takes 10 seconds to provide a new token
            var tokenCredential = new TokenCredentials("", SlowTokenUpdater);

            // make sure the token starts with the right value, t=0
            Assert.AreEqual("0", tokenCredential.Token);

            // check on the token while updater is running, t=6
            Task.Delay(TimeSpan.FromSeconds(1.2)).Wait();
            Assert.AreEqual("0", tokenCredential.Token);

            // check on the token after updater is done for the first time, t=16
            // the first updater should have finished at t=15
            Task.Delay(TimeSpan.FromSeconds(2)).Wait();
            Assert.AreEqual("00", tokenCredential.Token);

            // check on the token while updater is running, t=22
            // the second updater should have been triggered at t=20
            Task.Delay(TimeSpan.FromSeconds(1.2)).Wait();
            Assert.AreEqual("00", tokenCredential.Token);

            // check on the token after updater is done for the second time, t=32
            // the second updater should have finished at t=30
            Task.Delay(TimeSpan.FromSeconds(2)).Wait();
            Assert.AreEqual("000", tokenCredential.Token);

            // stop the timer and make sure it is not triggered anymore, t=50
            tokenCredential.Dispose();
            Task.Delay(TimeSpan.FromSeconds(3.6)).Wait();
            Assert.AreEqual("000", tokenCredential.Token);
        }

        [TestMethod]
        [Description("Test the situation where the periodic token updater throws an exception.")]
        public async Task ErrorThrownWhenTimerIsTriggered()
        {
            var tokenCredential = new TokenCredentials("0", BrokenTokenUpdater);

            // make sure the token starts with the right value, t=0
            Assert.AreEqual("0", tokenCredential.Token);

            // wait until timer triggers for the first time and validate token value, t=6
            await Task.Delay(TimeSpan.FromSeconds(1));
            Assert.AreEqual("0", tokenCredential.Token);

            // wait until timer triggers for the second time and validate token value, 6=12
            await Task.Delay(TimeSpan.FromSeconds(1));
            Assert.AreEqual("0", tokenCredential.Token);

            // stop the time and make sure it does not trigger anymore, t=18
            tokenCredential.Dispose();
            await Task.Delay(TimeSpan.FromSeconds(1));
            Assert.AreEqual("0", tokenCredential.Token);
        }

        /// <summary>
        /// This is the fast token updater.
        /// It simply appends '0' to the current token.
        /// </summary>
        private static Task<TimeSpan> FastTokenUpdater(ITokenCredentials credential)
        {
            credential.SetToken(credential.Token + "0");
            return Task.FromResult(TimeSpan.FromSeconds(1));
        }

        /// <summary>
        /// This is the super slow token updater. It simulates situations where a token needs to be retrieved from a potato server.
        /// It waits for 10 seconds and then simply appends '0' to the current token.
        /// </summary>
        private static Task<TimeSpan> SlowTokenUpdater(ITokenCredentials credential)
        {
            Task.Delay(TimeSpan.FromSeconds(2)).ConfigureAwait(false).GetAwaiter().GetResult();
            credential.SetToken(credential.Token + "0");
            return Task.FromResult(TimeSpan.FromSeconds(1));
        }

        /// <summary>
        /// This updater throws exceptions. It simulates situations where errors occur while retrieving a token from a potato server.
        /// </summary>
        private static Task<TimeSpan> BrokenTokenUpdater(ITokenCredentials credential)
            => throw new Exception();
    }
}
