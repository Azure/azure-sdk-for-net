// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventGrid;
using Azure.Messaging.EventGrid.SystemEvents;

namespace Azure.Data.AppConfiguration.Samples
{
#pragma warning disable 649 // Field is not initialized
#pragma warning disable SA1400 // Declare the access modifier
    public partial class ConfigurationSamples
    {
#region Snippet:AzConfigSample8_ChangeNotification_SharedClient
        // The shared ConfigurationClient used by application
        ConfigurationClient SharedConfigurationClient;
#endregion

#region Snippet:AzConfigSample8_ChangeNotification
        public void HandleEventGridNotification(string data)
        {
            var events = EventGridEvent.ParseMany(new BinaryData(data));

            foreach (EventGridEvent eventGridEvent in events)
            {
                if (eventGridEvent.TryGetSystemEventData(out object systemData) &&
                    systemData is AppConfigurationKeyValueModifiedEventData valueModifiedEventData)
                {
                    SharedConfigurationClient.UpdateSyncToken(valueModifiedEventData.SyncToken);

                    Response<ConfigurationSetting> updatedSetting = SharedConfigurationClient.GetConfigurationSetting(valueModifiedEventData.Key, valueModifiedEventData.Label);
                    Console.WriteLine($"Setting was updated. Key: {updatedSetting.Value.Key} Value: {updatedSetting.Value.Value}");
                }
            }
        }
#endregion
    }
}
