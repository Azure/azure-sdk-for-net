// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Messaging.EventGrid.Namespaces.Samples
{
    public partial class Samples_EventGridClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_PublishCloudEvent_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridSenderClient client = new EventGridSenderClient(endpoint, "<topicName>", credential);

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
                source = "<source>",
                type = "<type>",
                specversion = "<specversion>",
            });
            Response response = client.SendEvent(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_PublishCloudEvent_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridSenderClient client = new EventGridSenderClient(endpoint, "<topicName>", credential);

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
                source = "<source>",
                type = "<type>",
                specversion = "<specversion>",
            });
            Response response = await client.SendEventAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_PublishCloudEvent_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridSenderClient client = new EventGridSenderClient(endpoint, "<topicName>", credential);

            CloudEvent @event = new CloudEvent("<source>", "<type>", new { foo = "bar" });
            Response response = client.Send(@event);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_PublishCloudEvent_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridSenderClient client = new EventGridSenderClient(endpoint, "<topicName>", credential);

            CloudEvent @event = new CloudEvent("<source>", "<type>", new { foo = "bar" });
            Response response = await client.SendAsync(@event);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_PublishCloudEvent_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridSenderClient client = new EventGridSenderClient(endpoint, "<topicName>", credential);

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
                source = "<source>",
                data = new object(),
                data_base64 = new object(),
                type = "<type>",
                time = "2022-05-10T14:57:31.2311892-04:00",
                specversion = "<specversion>",
                dataschema = "<dataschema>",
                datacontenttype = "<datacontenttype>",
                subject = "<subject>",
            });
            Response response = client.SendEvent(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_PublishCloudEvent_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridSenderClient client = new EventGridSenderClient(endpoint, "<topicName>", credential);

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
                source = "<source>",
                data = new object(),
                data_base64 = new object(),
                type = "<type>",
                time = "2022-05-10T14:57:31.2311892-04:00",
                specversion = "<specversion>",
                dataschema = "<dataschema>",
                datacontenttype = "<datacontenttype>",
                subject = "<subject>",
            });
            Response response = await client.SendEventAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_PublishCloudEvent_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridSenderClient client = new EventGridSenderClient(endpoint, "<topicName>", credential);

            CloudEvent @event = new CloudEvent("<source>", "<type>", new { foo = "bar" })
            {
                Id = "<id>",
                Data = BinaryData.FromObjectAsJson(new object()),
                Time = DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"),
                DataSchema = "<dataschema>",
                DataContentType = "<datacontenttype>",
                Subject = "<subject>",
            };
            Response response = client.Send(@event);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_PublishCloudEvent_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridSenderClient client = new EventGridSenderClient(endpoint, "<topicName>", credential);

            CloudEvent @event = new CloudEvent("<source>", "<type>", new { foo = "bar" })
            {
                Id = "<id>",
                Data = BinaryData.FromObjectAsJson(new object()),
                Time = DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"),
                DataSchema = "<dataschema>",
                DataContentType = "<datacontenttype>",
                Subject = "<subject>",
            };
            Response response = await client.SendAsync(@event);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_PublishCloudEvents_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridSenderClient client = new EventGridSenderClient(endpoint, "<topicName>", credential);

            using RequestContent content = RequestContent.Create(new object[]
            {
new
{
id = "<id>",
source = "<source>",
type = "<type>",
specversion = "<specversion>",
}
            });
            Response response = client.SendEvent(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_PublishCloudEvents_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridSenderClient client = new EventGridSenderClient(endpoint, "<topicName>", credential);

            using RequestContent content = RequestContent.Create(new object[]
            {
new
{
id = "<id>",
source = "<source>",
type = "<type>",
specversion = "<specversion>",
}
            });
            Response response = await client.SendEventAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_PublishCloudEvents_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridSenderClient client = new EventGridSenderClient(endpoint, "<topicName>", credential);

            Response response = client.Send(new CloudEvent[]
            {
                new CloudEvent("<source>", "<type>", new { foo = "bar" })
            });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_PublishCloudEvents_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridSenderClient client = new EventGridSenderClient(endpoint, "<topicName>", credential);

            Response response = await client.SendAsync(new CloudEvent[]
            {
                new CloudEvent("<source>", "<type>", new { foo = "bar" })
            });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_PublishCloudEvents_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridSenderClient client = new EventGridSenderClient(endpoint, "<topicName>", credential);

            using RequestContent content = RequestContent.Create(new object[]
            {
new
{
id = "<id>",
source = "<source>",
data = new object(),
data_base64 = new object(),
type = "<type>",
time = "2022-05-10T14:57:31.2311892-04:00",
specversion = "<specversion>",
dataschema = "<dataschema>",
datacontenttype = "<datacontenttype>",
subject = "<subject>",
}
            });
            Response response = client.SendEvent(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_PublishCloudEvents_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridSenderClient client = new EventGridSenderClient(endpoint, "<topicName>", credential);

            using RequestContent content = RequestContent.Create(new object[]
            {
new
{
id = "<id>",
source = "<source>",
data = new object(),
data_base64 = new object(),
type = "<type>",
time = "2022-05-10T14:57:31.2311892-04:00",
specversion = "<specversion>",
dataschema = "<dataschema>",
datacontenttype = "<datacontenttype>",
subject = "<subject>",
}
            });
            Response response = await client.SendEventAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_PublishCloudEvents_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridSenderClient client = new EventGridSenderClient(endpoint, "<topicName>", credential);

            Response response = client.Send(new CloudEvent[]
            {
                new CloudEvent("<source>", "<type>", new { foo = "bar" })
                {
                    Id = "<id>",
                    Data = BinaryData.FromObjectAsJson(new object()),
                    Time = DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"),
                    DataSchema = "<dataschema>",
                    DataContentType = "<datacontenttype>",
                    Subject = "<subject>",
                }
            });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_PublishCloudEvents_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridSenderClient client = new EventGridSenderClient(endpoint, "<topicName>", credential);

            Response response = await client.SendAsync(new CloudEvent[]
            {
                new CloudEvent("<source>", "<type>", new { foo = "bar" })
                {
                    Id = "<id>",
                    Data = BinaryData.FromObjectAsJson(new object()),
                    Time = DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"),
                    DataSchema = "<dataschema>",
                    DataContentType = "<datacontenttype>",
                    Subject = "<subject>",
                }
            });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_ReceiveCloudEvents_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response response = client.Receive((int?)null, (TimeSpan?)null, (RequestContext)null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("brokerProperties").GetProperty("lockToken").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("brokerProperties").GetProperty("deliveryCount").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("source").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("specversion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_ReceiveCloudEvents_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response response = await client.ReceiveAsync((int?)null, (TimeSpan?)null, (RequestContext)null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("brokerProperties").GetProperty("lockToken").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("brokerProperties").GetProperty("deliveryCount").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("source").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("specversion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_ReceiveCloudEvents_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response<ReceiveResult> response = client.Receive();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_ReceiveCloudEvents_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response<ReceiveResult> response = await client.ReceiveAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_ReceiveCloudEvents_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response response = client.Receive(1234, TimeSpan.FromSeconds(10), (RequestContext)null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("brokerProperties").GetProperty("lockToken").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("brokerProperties").GetProperty("deliveryCount").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("source").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("data").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("data_base64").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("time").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("specversion").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("dataschema").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("datacontenttype").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("subject").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_ReceiveCloudEvents_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response response = await client.ReceiveAsync(1234, TimeSpan.FromSeconds(10), (RequestContext)null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("brokerProperties").GetProperty("lockToken").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("brokerProperties").GetProperty("deliveryCount").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("source").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("data").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("data_base64").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("time").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("specversion").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("dataschema").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("datacontenttype").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("event").GetProperty("subject").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_ReceiveCloudEvents_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response<ReceiveResult> response = client.Receive(maxEvents: 1234, maxWaitTime: TimeSpan.FromSeconds(10));
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_ReceiveCloudEvents_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response<ReceiveResult> response = await client.ReceiveAsync(maxEvents: 1234, maxWaitTime: TimeSpan.FromSeconds(10));
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_AcknowledgeCloudEvents_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = client.Acknowledge(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("lockToken").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("succeededLockTokens")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_AcknowledgeCloudEvents_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = await client.AcknowledgeAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("lockToken").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("succeededLockTokens")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_AcknowledgeCloudEvents_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response<AcknowledgeResult> response = client.Acknowledge(new string[] { "<lockTokens>" });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_AcknowledgeCloudEvents_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response<AcknowledgeResult> response = await client.AcknowledgeAsync(new string[] { "<lockTokens>" });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_AcknowledgeCloudEvents_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = client.Acknowledge(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("lockToken").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("innererror").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("succeededLockTokens")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_AcknowledgeCloudEvents_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = await client.AcknowledgeAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("lockToken").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("innererror").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("succeededLockTokens")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_AcknowledgeCloudEvents_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response<AcknowledgeResult> response = client.Acknowledge(new string[] { "<lockTokens>" });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_AcknowledgeCloudEvents_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response<AcknowledgeResult> response = await client.AcknowledgeAsync(new string[] { "<lockTokens>" });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_ReleaseCloudEvents_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = client.Release(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("lockToken").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("succeededLockTokens")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_ReleaseCloudEvents_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = await client.ReleaseAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("lockToken").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("succeededLockTokens")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_ReleaseCloudEvents_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response<ReleaseResult> response = client.Release(new string[] { "<lockTokens>" });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_ReleaseCloudEvents_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response<ReleaseResult> response = await client.ReleaseAsync(new string[] { "<lockTokens>" });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_ReleaseCloudEvents_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = client.Release(content, releaseDelayInSeconds: "0");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("lockToken").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("innererror").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("succeededLockTokens")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_ReleaseCloudEvents_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = await client.ReleaseAsync(content, releaseDelayInSeconds: "0");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("lockToken").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("innererror").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("succeededLockTokens")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_ReleaseCloudEvents_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response<ReleaseResult> response = client.Release(new string[] { "<lockTokens>" }, delay: ReleaseDelay.NoDelay);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_ReleaseCloudEvents_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response<ReleaseResult> response = await client.ReleaseAsync(new string[] { "<lockTokens>" }, delay: ReleaseDelay.NoDelay);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_RejectCloudEvents_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = client.Reject(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("lockToken").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("succeededLockTokens")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_RejectCloudEvents_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = await client.RejectAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("lockToken").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("succeededLockTokens")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_RejectCloudEvents_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response<RejectResult> response = client.Reject(new string[] { "<lockTokens>" });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_RejectCloudEvents_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response<RejectResult> response = await client.RejectAsync(new string[] { "<lockTokens>" });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_RejectCloudEvents_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = client.Reject(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("lockToken").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("innererror").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("succeededLockTokens")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_RejectCloudEvents_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = await client.RejectAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("lockToken").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("innererror").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("succeededLockTokens")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_RejectCloudEvents_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response<RejectResult> response = client.Reject(new string[] { "<lockTokens>" });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_RejectCloudEvents_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response<RejectResult> response = await client.RejectAsync(new string[] { "<lockTokens>" });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_RenewCloudEventLocks_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = client.RenewLocks(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("lockToken").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("succeededLockTokens")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_RenewCloudEventLocks_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = await client.RenewLocksAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("lockToken").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("succeededLockTokens")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_RenewCloudEventLocks_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response<RenewLocksResult> response = client.RenewLocks(new string[] { "<lockTokens>" });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_RenewCloudEventLocks_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response<RenewLocksResult> response = await client.RenewLocksAsync(new string[] { "<lockTokens>" });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_RenewCloudEventLocks_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = client.RenewLocks(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("lockToken").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("innererror").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("succeededLockTokens")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_RenewCloudEventLocks_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = await client.RenewLocksAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("lockToken").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("failedLockTokens")[0].GetProperty("error").GetProperty("innererror").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("succeededLockTokens")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_RenewCloudEventLocks_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response<RenewLocksResult> response = client.RenewLocks(new string[] { "<lockTokens>" });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_RenewCloudEventLocks_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridReceiverClient client = new EventGridReceiverClient(endpoint, "<topicName>", "<eventSubscriptionName>", credential);

            Response<RenewLocksResult> response = await client.RenewLocksAsync(new string[] { "<lockTokens>" });
        }
    }
}
