// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Reflection;
using Xunit;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class WebPubSubTriggerValueProviderTests
    {
        [Theory]
        [InlineData("connectioncontext")]
        [InlineData("reason")]
        [InlineData("message")]
        public void TestGetValueByName_Valid(string name)
        {
            var triggerEvent = new WebPubSubTriggerEvent
            {
                ConnectionContext = new ConnectionContext
                {
                    ConnectionId = "000000",
                    EventName = "message",
                    EventType = WebPubSubEventType.User,
                    Hub = "testhub",
                    UserId = "user1"
                },
                Reason = "reason",
                Message = new WebPubSubMessage("message"),
            };

            var value = typeof(WebPubSubTriggerEvent)
                .GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(triggerEvent);
            Assert.NotNull(value);
        }
    }
}
