// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class ConnectionStringBuilderTests
    {
        [Fact]
        [DisplayTestMethodName]
        void ParseAndBuild()
        {
            var csb = new EventHubsConnectionStringBuilder(TestUtility.EventHubsConnectionString);

            // Try update settings and rebuild the connection string.
            csb.Endpoint = new Uri("sb://newendpoint");
            csb.EntityPath = "newentitypath";
            csb.OperationTimeout = TimeSpan.FromSeconds(100);
            csb.SasKeyName = "newsaskeyname";
            csb.SasKey = "newsaskey";
            var newConnectionString = csb.ToString();

            // Now try creating a new ConnectionStringBuilder from modified connection string.
            var newCsb = new EventHubsConnectionStringBuilder(newConnectionString);

            // Validate modified values on the new connection string builder.
            Assert.Equal(new Uri("sb://newendpoint"), newCsb.Endpoint);
            Assert.Equal("newentitypath", newCsb.EntityPath);
            Assert.Equal(TimeSpan.FromSeconds(100), newCsb.OperationTimeout);
            Assert.Equal("newsaskeyname", newCsb.SasKeyName);
            Assert.Equal("newsaskey", newCsb.SasKey);
        }

        [Fact]
        [DisplayTestMethodName]
        void CustomEndpoint()
        {
            // Use 'sb' scheme intentionally. Connection string builder will replace it with 'amqps'.
            var endpoint = new Uri("sb://mynamespace.someotherregion.windows");
            var entityPath = "myentity";
            var sharedAccessKeyName = "mySAS";
            var sharedAccessKey = "mySASKey";

            // Create connection string builder instance and then generate connection string.
            var csb = new EventHubsConnectionStringBuilder(endpoint, entityPath, sharedAccessKeyName, sharedAccessKey);
            var generatedConnectionString = csb.ToString();

            // Validate generated connection string.
            // Endpoint validation.
            var expectedLiteral = $"Endpoint={endpoint.ToString().Replace("sb://", "amqps://")}";
            Assert.True(generatedConnectionString.Contains(expectedLiteral),
                $"Generated connection string doesn't contain expected Endpoint. Expected: '{expectedLiteral}' in '{generatedConnectionString}'");

            // SAS Name
            expectedLiteral = $"SharedAccessKeyName={sharedAccessKeyName}";
            Assert.True(generatedConnectionString.Contains(expectedLiteral),
                $"Generated connection string doesn't contain expected SAS Name. Expected: '{expectedLiteral}' in '{generatedConnectionString}'");

            // SAS Key
            expectedLiteral = $"SharedAccessKey={sharedAccessKey}";
            Assert.True(generatedConnectionString.Contains(expectedLiteral),
                $"Generated connection string doesn't contain expected SAS Key. Expected: '{expectedLiteral}' in '{generatedConnectionString}'");

            // Entity Path
            expectedLiteral = $"EntityPath={entityPath}";
            Assert.True(generatedConnectionString.Contains(expectedLiteral),
                $"Generated connection string doesn't contain expected SAS Key. Expected: '{expectedLiteral}' in '{generatedConnectionString}'");

            // Now try creating a new ConnectionStringBuilder from generated connection string.
            // This should not fail.
            var csbNew = new EventHubsConnectionStringBuilder(generatedConnectionString);

            // Validate new builder.
            Assert.True(csbNew.Endpoint == csb.Endpoint, $"Original and New CSB mismatch at Endpoint. Original: {csb.Endpoint} New: {csbNew.Endpoint}");
            Assert.True(csbNew.SasKeyName == csb.SasKeyName, $"Original and New CSB mismatch at SasKeyName. Original: {csb.SasKeyName} New: {csbNew.SasKeyName}");
            Assert.True(csbNew.SasKey == csb.SasKey, $"Original and New CSB mismatch at SasKey. Original: {csb.SasKey} New: {csbNew.SasKey}");
            Assert.True(csbNew.EntityPath == csb.EntityPath, $"Original and New CSB mismatch at EntityPath. Original: {csb.EntityPath} New: {csbNew.EntityPath}");
        }

        [Fact]
        [DisplayTestMethodName]
        void InvalidConnectionStrings()
        {
            var invalidStrings = new List<string>();

            // Missing the endpoint definition.
            invalidStrings.Add("SharedAccessKeyName=xxxxxx;SharedAccessKey=xxxx;");

            // Missing SAS key name.
            invalidStrings.Add("Endpoint=sb://myehnamespace.servicebus.windows.net;SharedAccessKey=xxxx;");

            // Missing SAS key.
            invalidStrings.Add("SharedAccessKeyName=xxxxxx;SharedAccessKeyName=xxxx;");

            // SAS token with SAS key.
            invalidStrings.Add("Endpoint=sb://myehnamespace.servicebus.windows.net;SharedAccessKeyName=xxxxxx;SharedAccessKey=xxxx;SharedAccessSignature=xxxxx;");

            foreach (var invalidString in invalidStrings)
            {
                TestUtility.Log($"Testing invalid connection string '{invalidString}'");
                var csb = new EventHubsConnectionStringBuilder(invalidString);

                // ToString should throw.
                Assert.ThrowsAsync<ArgumentException>(() =>
                {
                    csb.ToString();
                    throw new InvalidOperationException("ToString() should have failed");
                });
            }
        }

        [Fact]
        [DisplayTestMethodName]
        async Task UseSharedAccessSignatureApi()
        {
            // Generate shared access token.
            var csb = new EventHubsConnectionStringBuilder(TestUtility.EventHubsConnectionString);
            var tokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(csb.SasKeyName, csb.SasKey);
            var token = await tokenProvider.GetTokenAsync(csb.Endpoint.ToString(), TimeSpan.FromSeconds(120));
            var sharedAccessSignature = token.TokenValue.ToString();

            // Create connection string builder by SharedAccessSignature overload.
            var csbNew = new EventHubsConnectionStringBuilder(csb.Endpoint, csb.EntityPath, sharedAccessSignature, TimeSpan.FromSeconds(60));

            // Create new client with updated connection string.
            var ehClient = EventHubClient.CreateFromConnectionString(csbNew.ToString());

            // Send one event
            TestUtility.Log("Sending one message.");
            var ehSender = ehClient.CreatePartitionSender("0");
            var eventData = new EventData(Encoding.UTF8.GetBytes("Hello EventHub by partitionKey!"));
            await ehSender.SendAsync(eventData);

            // Receive event.
            TestUtility.Log("Receiving one message.");
            var ehReceiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromStart());
            var msg = await ehReceiver.ReceiveAsync(1);
            Assert.True(msg != null, "Failed to receive message.");

            // Get EH runtime information.
            TestUtility.Log("Getting Event Hub runtime information.");
            var ehInfo = await ehClient.GetRuntimeInformationAsync();
            Assert.True(ehInfo != null, "Failed to get runtime information.");

            // Get EH partition runtime information.
            TestUtility.Log("Getting Event Hub partition '0' runtime information.");
            var partitionInfo = await ehClient.GetPartitionRuntimeInformationAsync("0");
            Assert.True(ehInfo != null, "Failed to get runtime partition information.");
        }
    }
}
