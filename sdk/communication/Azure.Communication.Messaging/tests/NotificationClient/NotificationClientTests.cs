// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Communication.Messaging
{
    public class NotificationClientTests
    {
        [Test]
        public async Task SendMessageShouldSucceed()
        {
            var notificationClient = new NotificationClient("<connection string>");
            var options = new SendMessageOptions("d8fbaac7-c949-4bf1-8ba9-29b467d97547", new List<string> { "+1(604)360-9258" }, "hiiiiii");
            SendMessageResponse response = await notificationClient.SendMessageAsync(options);
            Assert.IsNotNull(response.Result[0].Id);
            Assert.AreEqual(MessageStatus.Enqueued, response.Result[0].Status);
        }
    }
}
