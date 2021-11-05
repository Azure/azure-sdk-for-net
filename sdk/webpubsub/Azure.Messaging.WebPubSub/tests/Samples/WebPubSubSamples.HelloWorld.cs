// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Messaging.WebPubSub;
using Azure.Rest.WebPubSub.Tests;

namespace Azure.Template.Tests.Samples
{
    public class WebPubSubSamples : SamplesBase<WebPubSubTestEnvironment>
    {
        public void HelloWorld()
        {
            var endpoint = TestEnvironment.Endpoint;
            var key = TestEnvironment.Key;

            #region Snippet:WebPubSubHelloWorld
            var serviceClient = new WebPubSubServiceClient(new Uri(endpoint), "some_hub", new AzureKeyCredential(key));

            serviceClient.SendToAll("Hello World!");
            #endregion
        }

        public void Authenticate()
        {
            var endpoint = TestEnvironment.Endpoint;
            var key = TestEnvironment.Key;

            #region Snippet:WebPubSubAuthenticate
            var serviceClient = new WebPubSubServiceClient(new Uri(endpoint), "some_hub", new AzureKeyCredential(key));
            #endregion
        }

        public void HelloWorldWithConnectionString()
        {
            var connectionString = TestEnvironment.ConnectionString;

            var serviceClient = new WebPubSubServiceClient(connectionString, "some_hub");

            serviceClient.SendToAll("Hello World!");
        }

        public void JsonMessage()
        {
            var endpoint = TestEnvironment.Endpoint;
            var key = TestEnvironment.Key;

            #region Snippet:WebPubSubSendJson
            var serviceClient = new WebPubSubServiceClient(new Uri(endpoint), "some_hub", new AzureKeyCredential(key));

            serviceClient.SendToAll(RequestContent.Create(
                    new
                    {
                        Foo = "Hello World!",
                        Bar = 42
                    }),
                    ContentType.ApplicationJson);
            #endregion
        }

        public void BinaryMessage()
        {
            var endpoint = TestEnvironment.Endpoint;
            var key = TestEnvironment.Key;

            #region Snippet:WebPubSubSendBinary
            var serviceClient = new WebPubSubServiceClient(new Uri(endpoint), "some_hub", new AzureKeyCredential(key));

            Stream stream = BinaryData.FromString("Hello World!").ToStream();
            serviceClient.SendToAll(RequestContent.Create(stream), ContentType.ApplicationOctetStream);
            #endregion
        }

        public void AddUserToGroup()
        {
            var endpoint = TestEnvironment.Endpoint;
            var key = TestEnvironment.Key;

            var client = new WebPubSubServiceClient(new Uri(endpoint), "some_hub", new AzureKeyCredential(key));

            client.AddUserToGroup("some_group", "some_user");

            // Avoid sending messages to users who do not exist.
            if (client.UserExists("some_user").Value)
            {
                client.SendToUser("some_user", "Hi, I am glad you exist!");
            }

            client.RemoveUserFromGroup("some_group", "some_user");
        }
    }
}
