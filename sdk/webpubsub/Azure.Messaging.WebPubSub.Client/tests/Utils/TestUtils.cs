// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Buffers;
using System.Text.Json;
using Azure.Core;
using System.Reflection;
using Azure.Messaging.WebPubSub.Clients;
using NUnit.Framework;

namespace Azure.Messaging.WebPubSub.Client.Tests
{
    internal static class TestUtils
    {
        private const int DefaultTimeout = 5000;

        public static void AssertTimeout(params Task[] task)
        {
            Assert.False(Task.WaitAll(task, 500));
        }

        public static Task OrTimeout(this Task task, int milliseconds = DefaultTimeout, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int? lineNumber = null)
        {
            return OrTimeout(task, new TimeSpan(0, 0, 0, 0, milliseconds), memberName, filePath, lineNumber);
        }

        public static async Task OrTimeout(this Task task, TimeSpan timeout, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int? lineNumber = null)
        {
            if (task.IsCompleted)
            {
                await task;
                return;
            }

            var cts = new CancellationTokenSource();
            var completed = await Task.WhenAny(task, Task.Delay(Debugger.IsAttached ? Timeout.InfiniteTimeSpan : timeout, cts.Token));
            if (completed != task)
            {
                throw new TimeoutException(GetMessage(memberName, filePath, lineNumber));
            }
            cts.Cancel();

            await task;
        }

        public static Task<T> OrTimeout<T>(this Task<T> task, int milliseconds = DefaultTimeout, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int? lineNumber = null)
        {
            return OrTimeout(task, new TimeSpan(0, 0, 0, 0, milliseconds), memberName, filePath, lineNumber);
        }

        public static async Task<T> OrTimeout<T>(this Task<T> task, TimeSpan timeout, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int? lineNumber = null)
        {
            if (task.IsCompleted)
            {
                return await task;
            }

            var cts = new CancellationTokenSource();
            var completed = await Task.WhenAny(task, Task.Delay(Debugger.IsAttached ? Timeout.InfiniteTimeSpan : timeout, cts.Token));
            if (completed != task)
            {
                throw new TimeoutException(GetMessage(memberName, filePath, lineNumber));
            }
            cts.Cancel();

            return await task;
        }

        public static async Task OrThrowIfOtherFails(this Task task, Task otherTask)
        {
            var completed = await Task.WhenAny(task, otherTask);
            if (completed == otherTask && otherTask.IsFaulted)
            {
                // Manifest the exception
                otherTask.GetAwaiter().GetResult();
                throw new Exception("Unreachable code");
            }
            else
            {
                // Await the task we were asked to await. Either it's finished, or the otherTask finished successfully, and it's not our job to check that
                await task;
            }
        }

        public static async Task<T> OrThrowIfOtherFails<T>(this Task<T> task, Task otherTask)
        {
            await OrThrowIfOtherFails((Task)task, otherTask);

            // If we get here, 'task' is finished and succeeded.
            return task.GetAwaiter().GetResult();
        }

        public static T GetPrivateField<T>(this object obj, string name)
        {
            var fieldInfo = obj.GetType().GetField(name, BindingFlags.NonPublic | BindingFlags.Instance);
            return (T)fieldInfo.GetValue(obj);
        }

        public static ReadOnlySequence<byte> GetPayload(object msg)
        {
            return new ReadOnlySequence<byte>(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(msg)));
        }

        public static ReadOnlySequence<byte> GetConnectedPayload(string connectionId = null, string userId = null) => GetPayload(new { type = "system", @event = "connected", userId = userId ?? "user", connectionId = connectionId ?? "connection", reconnectionToken = "rec" });
        public static ReadOnlySequence<byte> GetDisconnectedPayload(string reason = null) => GetPayload(new { type = "system", @event = "disconnected", message = reason ?? "reason" });
        public static ReadOnlySequence<byte> GetGroupMessagePayload(long sequenceId) => GetPayload(new
        {
            sequenceId = sequenceId,
            type = "message",
            from = "group",
            group = "testgroup",
            dataType = "text",
            data = "textdata",
            fromUserId = "user"
        });
        public static ReadOnlySequence<byte> GetServerMessagePayload(long sequenceId) => GetPayload(new
        {
            sequenceId = sequenceId,
            type = "message",
            from = "server",
            dataType = "text",
            data = "textdata"
        });
        public static ReadOnlySequence<byte> GetAckMessagePayload(long ackId, string error) => GetPayload(new
        {
            type = "ack",
            ackId = ackId,
            success = string.IsNullOrEmpty(error),
            error = new
            {
                name = string.IsNullOrEmpty(error) ? error : "noError",
                message = "message"
            }
        });

        public static WebPubSubClientOptions GetClientOptionsForRetryTest(Action<RetryOptions> action = null)
        {
            var option = new WebPubSubClientOptions();
            option.MessageRetryOptions.Delay = TimeSpan.FromMilliseconds(10);
            option.MessageRetryOptions.MaxDelay = TimeSpan.FromMilliseconds(30);
            option.MessageRetryOptions.MaxRetries = 3;
            action?.Invoke(option.MessageRetryOptions);
            return option;
        }

        public static RetryOptions GetRetryOptions()
        {
            return (RetryOptions)typeof(RetryOptions).GetConstructor(
                  BindingFlags.NonPublic | BindingFlags.Instance,
                  null, Type.EmptyTypes, null).Invoke(null);
        }

        private static string GetMessage(string memberName, string filePath, int? lineNumber)
        {
            if (!string.IsNullOrEmpty(memberName))
            {
                return $"Operation in {memberName} timed out at {filePath}:{lineNumber}";
            }
            else
            {
                return "Operation timed out";
            }
        }
    }
}
