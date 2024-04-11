// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
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
            EventGridClient client = new EventGridClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
                source = "<source>",
                type = "<type>",
                specversion = "<specversion>",
            });
            Response response = client.PublishCloudEvent("<topicName>", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_PublishCloudEvent_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
                source = "<source>",
                type = "<type>",
                specversion = "<specversion>",
            });
            Response response = await client.PublishCloudEventAsync("<topicName>", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_PublishCloudEvent_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            CloudEvent @event = new CloudEvent("<source>", "<type>", new { foo = "bar" });
            Response<PublishResult> response = client.PublishCloudEvent("<topicName>", @event);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_PublishCloudEvent_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            CloudEvent @event = new CloudEvent("<source>", "<type>", new { foo = "bar" });
            Response<PublishResult> response = await client.PublishCloudEventAsync("<topicName>", @event);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_PublishCloudEvent_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

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
            Response response = client.PublishCloudEvent("<topicName>", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_PublishCloudEvent_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

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
            Response response = await client.PublishCloudEventAsync("<topicName>", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_PublishCloudEvent_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            CloudEvent @event = new CloudEvent("<source>", "<type>", new { foo = "bar" })
            {
                Id = "<id>",
                Data = BinaryData.FromObjectAsJson(new object()),
                Time = DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"),
                DataSchema = "<dataschema>",
                DataContentType = "<datacontenttype>",
                Subject = "<subject>",
            };
            Response<PublishResult> response = client.PublishCloudEvent("<topicName>", @event);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_PublishCloudEvent_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            CloudEvent @event = new CloudEvent("<source>", "<type>", new { foo = "bar" })
            {
                Id = "<id>",
                Data = BinaryData.FromObjectAsJson(new object()),
                Time = DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"),
                DataSchema = "<dataschema>",
                DataContentType = "<datacontenttype>",
                Subject = "<subject>",
            };
            Response<PublishResult> response = await client.PublishCloudEventAsync("<topicName>", @event);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_PublishCloudEvents_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

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
            Response response = client.PublishCloudEvents("<topicName>", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_PublishCloudEvents_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

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
            Response response = await client.PublishCloudEventsAsync("<topicName>", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_PublishCloudEvents_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            Response<PublishResult> response = client.PublishCloudEvents("<topicName>", new CloudEvent[]
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
            EventGridClient client = new EventGridClient(endpoint, credential);

            Response<PublishResult> response = await client.PublishCloudEventsAsync("<topicName>", new CloudEvent[]
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
            EventGridClient client = new EventGridClient(endpoint, credential);

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
            Response response = client.PublishCloudEvents("<topicName>", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_PublishCloudEvents_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

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
            Response response = await client.PublishCloudEventsAsync("<topicName>", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_PublishCloudEvents_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            Response<PublishResult> response = client.PublishCloudEvents("<topicName>", new CloudEvent[]
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
            EventGridClient client = new EventGridClient(endpoint, credential);

            Response<PublishResult> response = await client.PublishCloudEventsAsync("<topicName>", new CloudEvent[]
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
            EventGridClient client = new EventGridClient(endpoint, credential);

            Response response = client.ReceiveCloudEvents("<topicName>", "<eventSubscriptionName>", (int?)null, (TimeSpan?)null, (RequestContext)null);

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
            EventGridClient client = new EventGridClient(endpoint, credential);

            Response response = await client.ReceiveCloudEventsAsync("<topicName>", "<eventSubscriptionName>", (int?)null, (TimeSpan?)null, (RequestContext)null);

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
            EventGridClient client = new EventGridClient(endpoint, credential);

            Response<ReceiveResult> response = client.ReceiveCloudEvents("<topicName>", "<eventSubscriptionName>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_ReceiveCloudEvents_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            Response<ReceiveResult> response = await client.ReceiveCloudEventsAsync("<topicName>", "<eventSubscriptionName>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_ReceiveCloudEvents_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            Response response = client.ReceiveCloudEvents("<topicName>", "<eventSubscriptionName>", 1234, TimeSpan.FromSeconds(10), (RequestContext)null);

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
            EventGridClient client = new EventGridClient(endpoint, credential);

            Response response = await client.ReceiveCloudEventsAsync("<topicName>", "<eventSubscriptionName>", 1234, TimeSpan.FromSeconds(10), (RequestContext)null);

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
            EventGridClient client = new EventGridClient(endpoint, credential);

            Response<ReceiveResult> response = client.ReceiveCloudEvents("<topicName>", "<eventSubscriptionName>", maxEvents: 1234, maxWaitTime: TimeSpan.FromSeconds(10));
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_ReceiveCloudEvents_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            Response<ReceiveResult> response = await client.ReceiveCloudEventsAsync("<topicName>", "<eventSubscriptionName>", maxEvents: 1234, maxWaitTime: TimeSpan.FromSeconds(10));
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_AcknowledgeCloudEvents_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = client.AcknowledgeCloudEvents("<topicName>", "<eventSubscriptionName>", content);

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
            EventGridClient client = new EventGridClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = await client.AcknowledgeCloudEventsAsync("<topicName>", "<eventSubscriptionName>", content);

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
            EventGridClient client = new EventGridClient(endpoint, credential);

            AcknowledgeOptions acknowledgeOptions = new AcknowledgeOptions(new string[] { "<lockTokens>" });
            Response<AcknowledgeResult> response = client.AcknowledgeCloudEvents("<topicName>", "<eventSubscriptionName>", acknowledgeOptions);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_AcknowledgeCloudEvents_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            AcknowledgeOptions acknowledgeOptions = new AcknowledgeOptions(new string[] { "<lockTokens>" });
            Response<AcknowledgeResult> response = await client.AcknowledgeCloudEventsAsync("<topicName>", "<eventSubscriptionName>", acknowledgeOptions);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_AcknowledgeCloudEvents_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = client.AcknowledgeCloudEvents("<topicName>", "<eventSubscriptionName>", content);

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
            EventGridClient client = new EventGridClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = await client.AcknowledgeCloudEventsAsync("<topicName>", "<eventSubscriptionName>", content);

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
            EventGridClient client = new EventGridClient(endpoint, credential);

            AcknowledgeOptions acknowledgeOptions = new AcknowledgeOptions(new string[] { "<lockTokens>" });
            Response<AcknowledgeResult> response = client.AcknowledgeCloudEvents("<topicName>", "<eventSubscriptionName>", acknowledgeOptions);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_AcknowledgeCloudEvents_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            AcknowledgeOptions acknowledgeOptions = new AcknowledgeOptions(new string[] { "<lockTokens>" });
            Response<AcknowledgeResult> response = await client.AcknowledgeCloudEventsAsync("<topicName>", "<eventSubscriptionName>", acknowledgeOptions);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_ReleaseCloudEvents_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = client.ReleaseCloudEvents("<topicName>", "<eventSubscriptionName>", content);

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
            EventGridClient client = new EventGridClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = await client.ReleaseCloudEventsAsync("<topicName>", "<eventSubscriptionName>", content);

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
            EventGridClient client = new EventGridClient(endpoint, credential);

            ReleaseOptions releaseOptions = new ReleaseOptions(new string[] { "<lockTokens>" });
            Response<ReleaseResult> response = client.ReleaseCloudEvents("<topicName>", "<eventSubscriptionName>", releaseOptions);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_ReleaseCloudEvents_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            ReleaseOptions releaseOptions = new ReleaseOptions(new string[] { "<lockTokens>" });
            Response<ReleaseResult> response = await client.ReleaseCloudEventsAsync("<topicName>", "<eventSubscriptionName>", releaseOptions);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_ReleaseCloudEvents_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = client.ReleaseCloudEvents("<topicName>", "<eventSubscriptionName>", content, releaseDelayInSeconds: 0);

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
            EventGridClient client = new EventGridClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = await client.ReleaseCloudEventsAsync("<topicName>", "<eventSubscriptionName>", content, releaseDelayInSeconds: 0);

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
            EventGridClient client = new EventGridClient(endpoint, credential);

            ReleaseOptions releaseOptions = new ReleaseOptions(new string[] { "<lockTokens>" });
            Response<ReleaseResult> response = client.ReleaseCloudEvents("<topicName>", "<eventSubscriptionName>", releaseOptions, releaseDelayInSeconds: ReleaseDelay.By0Seconds);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_ReleaseCloudEvents_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            ReleaseOptions releaseOptions = new ReleaseOptions(new string[] { "<lockTokens>" });
            Response<ReleaseResult> response = await client.ReleaseCloudEventsAsync("<topicName>", "<eventSubscriptionName>", releaseOptions, releaseDelayInSeconds: ReleaseDelay.By0Seconds);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_RejectCloudEvents_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = client.RejectCloudEvents("<topicName>", "<eventSubscriptionName>", content);

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
            EventGridClient client = new EventGridClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = await client.RejectCloudEventsAsync("<topicName>", "<eventSubscriptionName>", content);

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
            EventGridClient client = new EventGridClient(endpoint, credential);

            RejectOptions rejectOptions = new RejectOptions(new string[] { "<lockTokens>" });
            Response<RejectResult> response = client.RejectCloudEvents("<topicName>", "<eventSubscriptionName>", rejectOptions);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_RejectCloudEvents_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            RejectOptions rejectOptions = new RejectOptions(new string[] { "<lockTokens>" });
            Response<RejectResult> response = await client.RejectCloudEventsAsync("<topicName>", "<eventSubscriptionName>", rejectOptions);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_RejectCloudEvents_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = client.RejectCloudEvents("<topicName>", "<eventSubscriptionName>", content);

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
            EventGridClient client = new EventGridClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = await client.RejectCloudEventsAsync("<topicName>", "<eventSubscriptionName>", content);

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
            EventGridClient client = new EventGridClient(endpoint, credential);

            RejectOptions rejectOptions = new RejectOptions(new string[] { "<lockTokens>" });
            Response<RejectResult> response = client.RejectCloudEvents("<topicName>", "<eventSubscriptionName>", rejectOptions);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_RejectCloudEvents_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            RejectOptions rejectOptions = new RejectOptions(new string[] { "<lockTokens>" });
            Response<RejectResult> response = await client.RejectCloudEventsAsync("<topicName>", "<eventSubscriptionName>", rejectOptions);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_RenewCloudEventLocks_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = client.RenewCloudEventLocks("<topicName>", "<eventSubscriptionName>", content);

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
            EventGridClient client = new EventGridClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = await client.RenewCloudEventLocksAsync("<topicName>", "<eventSubscriptionName>", content);

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
            EventGridClient client = new EventGridClient(endpoint, credential);

            RenewLockOptions renewLockOptions = new RenewLockOptions(new string[] { "<lockTokens>" });
            Response<RenewCloudEventLocksResult> response = client.RenewCloudEventLocks("<topicName>", "<eventSubscriptionName>", renewLockOptions);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_RenewCloudEventLocks_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            RenewLockOptions renewLockOptions = new RenewLockOptions(new string[] { "<lockTokens>" });
            Response<RenewCloudEventLocksResult> response = await client.RenewCloudEventLocksAsync("<topicName>", "<eventSubscriptionName>", renewLockOptions);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EventGrid_RenewCloudEventLocks_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = client.RenewCloudEventLocks("<topicName>", "<eventSubscriptionName>", content);

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
            EventGridClient client = new EventGridClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                lockTokens = new object[]
            {
"<lockTokens>"
            },
            });
            Response response = await client.RenewCloudEventLocksAsync("<topicName>", "<eventSubscriptionName>", content);

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
            EventGridClient client = new EventGridClient(endpoint, credential);

            RenewLockOptions renewLockOptions = new RenewLockOptions(new string[] { "<lockTokens>" });
            Response<RenewCloudEventLocksResult> response = client.RenewCloudEventLocks("<topicName>", "<eventSubscriptionName>", renewLockOptions);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EventGrid_RenewCloudEventLocks_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            EventGridClient client = new EventGridClient(endpoint, credential);

            RenewLockOptions renewLockOptions = new RenewLockOptions(new string[] { "<lockTokens>" });
            Response<RenewCloudEventLocksResult> response = await client.RenewCloudEventLocksAsync("<topicName>", "<eventSubscriptionName>", renewLockOptions);
        }
    }
}
