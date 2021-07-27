// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Core.Samples
{
    public class EventSamples
    {
        [Test]
        public void SyncHandler()
        {
            #region Snippet:Azure_Core_Samples_EventSamples_SyncHandler
            var client = new AlarmClient();
            client.Ring += (SyncAsyncEventArgs e) =>
            {
                Console.WriteLine("Wake up!");
                return Task.CompletedTask;
            };

            client.Snooze();
            #endregion
        }

        [Test]
        public async Task AsyncHandler()
        {
            #region Snippet:Azure_Core_Samples_EventSamples_AsyncHandler
            var client = new AlarmClient();
            client.Ring += async (SyncAsyncEventArgs e) =>
            {
                await Console.Out.WriteLineAsync("Wake up!");
            };

            await client.SnoozeAsync();
            #endregion
        }
        [Test]
        public async Task CombinedHandler()
        {
            #region Snippet:Azure_Core_Samples_EventSamples_CombinedHandler
            var client = new AlarmClient();
            client.Ring += async (SyncAsyncEventArgs e) =>
            {
                if (e.IsRunningSynchronously)
                {
                    Console.WriteLine("Wake up!");
                }
                else
                {
                    await Console.Out.WriteLineAsync("Wake up!");
                }
            };

            client.Snooze(); // sync call that blocks
            await client.SnoozeAsync(); // async call that doesn't block
            #endregion
        }

        [Test]
        public void Exceptions()
        {
            #region Snippet:Azure_Core_Samples_EventSamples_Exceptions
            var client = new AlarmClient();
            client.Ring += (SyncAsyncEventArgs e) =>
                throw new InvalidOperationException("Alarm unplugged.");

            try
            {
                client.Snooze();
            }
            catch (AggregateException ex)
            {
                ex.Handle(e => e is InvalidOperationException);
                Console.WriteLine("Please switch to your backup alarm.");
            }
            #endregion
        }
    }
}
