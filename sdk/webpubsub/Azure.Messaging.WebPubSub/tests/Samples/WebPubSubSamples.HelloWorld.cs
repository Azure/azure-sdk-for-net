// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Messaging.WebPubSub;
using Azure.Rest.WebPubSub.Tests;
using NUnit.Framework;

namespace Azure.Template.Tests.Samples
{
    public class WebPubSubSamples : SamplesBase<WebPubSubTestEnvironment>
    {
        public void HelloWorld()
        {
            var endpoint = TestEnvironment.Endpoint;
            var key = TestEnvironment.Key;

            #region Snippet:WebPubSubHelloWorld
            var serviceClient = new WebPubSubServiceClient("some_hub", new AzureKeyCredential(key), new Uri(endpoint));

            serviceClient.SendToAll("Hello World!");
            #endregion
        }

        public void Authenticate()
        {
            var endpoint = TestEnvironment.Endpoint;
            var key = TestEnvironment.Key;

            #region Snippet:WebPubSubAuthenticate
            var serviceClient = new WebPubSubServiceClient("some_hub", new AzureKeyCredential(key), new Uri(endpoint));
            #endregion
        }

        public void HelloWorldWithConnectionString()
        {
            var connectionString = TestEnvironment.ConnectionString;

            #region Snippet:WebPubSubHelloWorldConnStr
            var serviceClient = new WebPubSubServiceClient(connectionString, "some_hub");

            serviceClient.SendToAll("Hello World!");
            #endregion
        }

        public void JsonMessage()
        {
            var endpoint = TestEnvironment.Endpoint;
            var key = TestEnvironment.Key;

            #region Snippet:WebPubSubSendJson
            var serviceClient = new WebPubSubServiceClient("some_hub", new AzureKeyCredential(key), new Uri(endpoint));

            serviceClient.SendToAll("application/json",
                RequestContent.Create(
                    new
                    {
                        Foo = "Hello World!",
                        Bar = 42
                    }));
            #endregion
        }

        public void BinaryMessage()
        {
            var endpoint = TestEnvironment.Endpoint;
            var key = TestEnvironment.Key;

            #region Snippet:WebPubSubSendBinary
            var serviceClient = new WebPubSubServiceClient("some_hub", new AzureKeyCredential(key), new Uri(endpoint));

            Stream stream = BinaryData.FromString("Hello World!").ToStream();
            serviceClient.SendToAll("application/octet-stream", RequestContent.Create(stream));
            #endregion
        }

        public void AddUserToGroup()
        {
            var endpoint = TestEnvironment.Endpoint;
            var key = TestEnvironment.Key;

            #region Snippet:WebPubAddUserToGroup
            var client = new WebPubSubServiceClient("some_hub", new AzureKeyCredential(key), new Uri(endpoint));

            client.AddUserToGroup("some_group", "some_user");

            // Avoid sending messages to users who do not exist.
            if (client.UserExists("some_user", CancellationToken.None).Value)
            {
                client.SendToUser("some_user", "Hi, I am glad you exist!");
            }

            client.RemoveUserFromGroup("some_group", "some_user");
            #endregion
        }
    }
}
