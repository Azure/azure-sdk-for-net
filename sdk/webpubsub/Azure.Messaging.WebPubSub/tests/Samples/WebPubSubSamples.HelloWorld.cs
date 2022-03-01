// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;

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
            var connectionString = TestEnvironment.ConnectionString;

            #region Snippet:WebPubSubHelloWorld
            var serviceClient = new WebPubSubServiceClient(connectionString, "some_hub");

            serviceClient.SendToAll("Hello World!");
            #endregion
        }

        public void Authenticate()
        {
            var connectionString = TestEnvironment.ConnectionString;
            var endpoint = ParseConnectionString(connectionString)["Endpoint"];
            var key = ParseConnectionString(connectionString)["AccessKey"];

            #region Snippet:WebPubSubAuthenticate
            // Create a WebPubSubServiceClient that will authenticate using a key credential.
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
            var connectionString = TestEnvironment.ConnectionString;

            #region Snippet:WebPubSubSendJson
            var serviceClient = new WebPubSubServiceClient(connectionString, "some_hub");

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
            var connectionString = TestEnvironment.ConnectionString;

            #region Snippet:WebPubSubSendBinary
            var serviceClient = new WebPubSubServiceClient(connectionString, "some_hub");

            Stream stream = BinaryData.FromString("Hello World!").ToStream();
            serviceClient.SendToAll(RequestContent.Create(stream), ContentType.ApplicationOctetStream);
            #endregion
        }

        public void AddUserToGroup()
        {
            var connectionString = TestEnvironment.ConnectionString;
            var client = new WebPubSubServiceClient(connectionString, "some_hub");

            #region Snippet:WebPubSubAddUserToGroup
            client.AddUserToGroup("some_group", "some_user");

            // Avoid sending messages to users who do not exist.
            if (client.UserExists("some_user").Value)
            {
                client.SendToUser("some_user", "Hi, I am glad you exist!");
            }

            client.RemoveUserFromGroup("some_group", "some_user");
            #endregion
        }

        private static Dictionary<string, string> ParseConnectionString(string connectionString)
        {
            return connectionString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(pair =>
            {
                var map = pair.Split('=');
                if (map.Length != 2)
                {
                    return default;
                }
                return new KeyValuePair<string, string>(map[0], map[1]);
            }).Where(s => !string.IsNullOrEmpty(s.Key)).ToDictionary(p => p.Key, p => p.Value, StringComparer.OrdinalIgnoreCase);
        }
    }
}
