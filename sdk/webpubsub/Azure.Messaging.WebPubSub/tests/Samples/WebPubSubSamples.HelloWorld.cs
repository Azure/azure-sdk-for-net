// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
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
            var client = new WebPubSubServiceClient(new Uri(endpoint), "some_hub", new AzureKeyCredential(key));

            client.SendToAll("Hello World!");
            #endregion
        }

        public void HelloWorldWithConnectionString()
        {
            var connectionString = TestEnvironment.ConnectionString;

            #region Snippet:WebPubSubHelloWorld
            var client = new WebPubSubServiceClient(connectionString, "some_hub");

            client.SendToAll("Hello World!");
            #endregion
        }

        public void JsonMessage()
        {
            var endpoint = TestEnvironment.Endpoint;
            var key = TestEnvironment.Key;

            #region Snippet:WebPubSubSendJson
            var client = new WebPubSubServiceClient(new Uri(endpoint), "some_hub", new AzureKeyCredential(key));

            client.SendToAll(RequestContent.Create(
                new {
                    Foo = "Hello World!",
                    Bar = "Hi!"
                }
            ));
            #endregion
        }

        public void BinaryMessage()
        {
            var endpoint = TestEnvironment.Endpoint;
            var key = TestEnvironment.Key;

            #region Snippet:WebPubSubSendJson
            var client = new WebPubSubServiceClient(new Uri(endpoint), "some_hub", new AzureKeyCredential(key));

            Stream stream = BinaryData.FromString("Hello World!").ToStream();

            client.SendToAll(RequestContent.Create(stream), HttpHeader.Common.OctetStreamContentType.Value);
            #endregion
        }

        public void AddUserToGroup()
        {
            var endpoint = TestEnvironment.Endpoint;
            var key = TestEnvironment.Key;

            #region Snippet:WebPubSubSendJson
            var client = new WebPubSubServiceClient(new Uri(endpoint), "some_hub", new AzureKeyCredential(key));

            client.AddUserToGroup("some_group", "some_user");

            // Avoid sending messages to users who do not exist.
            if (client.UserExists("some_user"))
            {
                client.SendToUser("some_user", "Hi, I am glad you exist!");
            }

            client.RemoveUserFromGroup("some_group", "some_user");
            #endregion
        }
    }
}
