// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Azure.Devices.Client;

namespace Azure.IoT.TimeSeriesInsights.Tests
{
    internal class QueryTestsHelper
    {
        internal const string Humidity = "Humidity";
        internal const string Temperature = "Temperature";

        internal static async Task SendEventsToHubAsync(
            DeviceClient client,
            TimeSeriesId tsiId,
            TimeSeriesIdProperty[] timeSeriesIdProperties,
            int numberOfEventsToSend)
        {
            IDictionary<string, object> messageBase = BuildMessageBase(timeSeriesIdProperties, tsiId);
            double minTemperature = 20;
            double minHumidity = 60;
            var rand = new Random();

            // Build the message base that is used as the base for every event going out
            for (int i = 0; i < numberOfEventsToSend; i++)
            {
                double currentTemperature = minTemperature + rand.NextDouble() * 15;
                double currentHumidity = minHumidity + rand.NextDouble() * 20;
                messageBase[Temperature] = currentTemperature;
                messageBase[Humidity] = currentHumidity;
                string messageBody = JsonSerializer.Serialize(messageBase);
                var message = new Message(Encoding.ASCII.GetBytes(messageBody))
                {
                    ContentType = "application/json",
                    ContentEncoding = "utf-8",
                };

                Func<Task> sendEventAct = async () => await client.SendEventAsync(message).ConfigureAwait(false);
                await sendEventAct.Should().NotThrowAsync();
            }
        }

        internal static IDictionary<string, object> BuildMessageBase(TimeSeriesIdProperty[] timeSeriesIdProperties, TimeSeriesId tsiId)
        {
            var messageBase = new Dictionary<string, object>();
            string[] tsiIdArray = tsiId.ToArray();
            for (int i = 0; i < timeSeriesIdProperties.Count(); i++)
            {
                TimeSeriesIdProperty idProperty = timeSeriesIdProperties[i];
                string tsiIdValue = tsiIdArray[i];
                messageBase[idProperty.Name] = tsiIdValue;
            }

            return messageBase;
        }
    }
}
