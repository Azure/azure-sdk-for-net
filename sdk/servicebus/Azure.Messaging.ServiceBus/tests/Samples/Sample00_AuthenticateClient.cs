// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample00_AuthenticateClient : ServiceBusLiveTestBase
    {
        /// <summary>
        /// Authenticate with <see cref="DefaultAzureCredential"/>.
        /// </summary>
        public async Task AuthenticateWithAAD()
        {
            #region Snippet:ServiceBusAuthAAD
            // Create a ServiceBusClient that will authenticate through Active Directory
            string fullyQualifiedNamespace = "yournamespace.servicebus.windows.net";
            await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
            #endregion
        }

        /// <summary>
        /// Authenticate with a connection string.
        /// </summary>
        public async Task AuthenticateWithConnectionString()
        {
            #region Snippet:ServiceBusAuthConnString
            // Create a ServiceBusClient that will authenticate using a connection string
            string connectionString = "<connection_string>";
            await using ServiceBusClient client = new(connectionString);
            #endregion
        }

        /// <summary>
        /// Authenticate with an AzureNamedKeyCredential.
        /// </summary>
        public async Task AuthenticateWithAzureNamedKeyCredential()
        {
            #region Snippet:ServiceBusAuthNamedKey
            var credential = new AzureNamedKeyCredential("<name>", "<key>");
            await using ServiceBusClient client = new("yournamespace.servicebus.windows.net", credential);
            #endregion
        }

        /// <summary>
        /// Authenticate with an AzureSasCredential.
        /// </summary>
        [Test]
        public async Task AuthenticateWithAzureSasCredential()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusAuthSasKey
#if SNIPPET
                string keyName = "<key_name>";
                string key = "<key>";
                string fullyQualifiedNamespace = "<yournamespace.servicebus.windows.net>";
                string queueName = "<queue_name>";
#else
                string keyName = TestEnvironment.SharedAccessKeyName;
                string key = TestEnvironment.SharedAccessKey;
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;
#endif
                using HMACSHA256 hmac = new(Encoding.UTF8.GetBytes(key));
                UriBuilder builder = new(fullyQualifiedNamespace)
                {
                    Scheme = "amqps",
                    // scope our SAS token to the queue that is being used to adhere to the principle of least privilege
                    Path = queueName
                };

                string url = WebUtility.UrlEncode(builder.Uri.AbsoluteUri);
                long exp = DateTimeOffset.Now.AddHours(1).ToUnixTimeSeconds();
                string sig = WebUtility.UrlEncode(Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(url + "\n" + exp))));

                string sasToken = $"SharedAccessSignature sr={url}&sig={sig}&se={exp}&skn={keyName}";

                AzureSasCredential credential = new(sasToken);
                await using ServiceBusClient client = new(fullyQualifiedNamespace, credential);
                #endregion
                await using ServiceBusSender sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(new ServiceBusMessage("Hello world!"));
            }
        }
    }
}
