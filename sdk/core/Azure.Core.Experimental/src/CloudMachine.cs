// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Azure
{
    /// <summary>
    /// Stores configuration of a CloudMachine.
    /// </summary>
    public class CloudMachine
    {
        /// <summary>
        /// Unique identifier of a CloudMachine. It's the name of the resource group of all the CloudMachine resources.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Friendly name of CloudMachine. It's stored as a Tag of all Azure resources associated with the machine.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Azure subscription ID.
        /// </summary>
        public string SubscriptionId { get; private set; }

        /// <summary>
        /// Azure region, e.g. westus2
        /// </summary>
        public string Region { get; private set; }

        private int Version { get; set; }

        /// <summary>
        /// Creates a new CloudMachine
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <remarks>DisplayName is initialized to id. It can be changed by setting the DisplayName property.</remarks>
        public static CloudMachine Create(string subscriptionId, string region)
        {
            if (string.IsNullOrEmpty(subscriptionId)) throw new ArgumentNullException(nameof(subscriptionId));
            if (string.IsNullOrEmpty(region)) throw new ArgumentNullException(nameof(region));

            var id = GenerateCloudMachineId();
            var defaultDisplayName = $"{id}@{DateTime.UtcNow:d}";
            var cm = new CloudMachine(id, defaultDisplayName, subscriptionId, region, 1);
            return cm;
        }

        /// <summary>
        /// Loads CloudMachine settings from configurationFile
        /// </summary>
        /// <param name="configurationFile"></param>
        /// <exception cref="InvalidCloudMachineConfigurationException"></exception>
        public CloudMachine(string configurationFile = ".\\cloudconfig.json")
        {
            try
            {
                byte[] configurationContent = File.ReadAllBytes(configurationFile);
                var document = JsonDocument.Parse(configurationContent);
                JsonElement json = document.RootElement.GetProperty("CloudMachine");

                Id = ReaderString(json, "id", configurationFile);
                SubscriptionId = ReaderString(json, "subscriptionId", configurationFile);
                Region = ReaderString(json, "region", configurationFile);
                DisplayName = ReaderString(json, "name", configurationFile);
                Version = ReaderInt32(json, "version", configurationFile);
            }
            catch (InvalidCloudMachineConfigurationException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new InvalidCloudMachineConfigurationException(configurationFile, setting: null, e);
            }
        }

        /// <summary>
        /// Loads CloudMachine settings from stream.
        /// </summary>
        /// <param name="configurationContent"></param>
        /// <exception cref="InvalidCloudMachineConfigurationException"></exception>
        public CloudMachine(Stream configurationContent)
        {
            try
            {
                var document = JsonDocument.Parse(configurationContent);
                JsonElement json = document.RootElement.GetProperty("CloudMachine");

                Id = ReaderString(json, "id", nameof(configurationContent));
                SubscriptionId = ReaderString(json, "subscriptionId", nameof(configurationContent));
                Region = ReaderString(json, "region", nameof(configurationContent));
                DisplayName = ReaderString(json, "name", nameof(configurationContent));
                Version = ReaderInt32(json, "version", nameof(configurationContent));
            }
            catch (InvalidCloudMachineConfigurationException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new InvalidCloudMachineConfigurationException(nameof(configurationContent), setting: null, e);
            }
        }

        /// <summary>
        /// Loads CloudMachine settings from configuration system
        /// </summary>
        public CloudMachine(IConfiguration configuration)
        {
            try {
                Id = ReadString(configuration, "CloudMachine:id");
                SubscriptionId = ReadString(configuration, "CloudMachine:subscriptionId");
                Region = ReadString(configuration, "CloudMachine:region");
                DisplayName = ReadString(configuration, "CloudMachine:name");
                Version = ReadInt32(configuration, "CloudMachine:version");
            }
            catch (InvalidCloudMachineConfigurationException) {
                throw;
            }
            catch (Exception e) {
                throw new InvalidCloudMachineConfigurationException(nameof(IConfiguration), setting: null, e);
            }
        }

        private CloudMachine(string id, string displayName, string subscriptionId, string region, int version)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            if (string.IsNullOrEmpty(displayName)) throw new ArgumentNullException(nameof(displayName));
            if (string.IsNullOrEmpty(subscriptionId)) throw new ArgumentNullException(nameof(subscriptionId));
            if (string.IsNullOrEmpty(region)) throw new ArgumentNullException(nameof(region));
            if (version<0) throw new ArgumentOutOfRangeException(nameof(version));

            Id = id;
            DisplayName = displayName;
            SubscriptionId = subscriptionId;
            Region = region;
            Version = version;
        }

        /// <summary>
        /// Save CloudMachine configuration to a stream
        /// </summary>
        /// <param name="stream"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Save(Stream stream)
        {
            var options = new JsonWriterOptions() { Indented = true };
            using var json = new Utf8JsonWriter(stream, options);
            json.WriteStartObject();
            json.WriteStartObject("CloudMachine");
            json.WriteString("id", Id);
            json.WriteString("name", DisplayName);
            json.WriteString("subscriptionId", SubscriptionId);
            json.WriteString("region", Region);
            json.WriteNumber("version", Version);
            json.WriteEndObject();
            json.WriteEndObject();
            json.Flush();
        }

        /// <summary>
        /// Save CloudMachine configuration to a file
        /// </summary>
        /// <param name="filepath"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Save(string filepath)
        {
            using var stream = File.OpenWrite(filepath);
            Save(stream);
        }

        private static string ReaderString(JsonElement json, string key, string configurationStoreDisplayName)
        {
            try {
                var value = json.GetProperty(key).GetString()!;
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(key);
                return value;
            }
            catch (Exception e) {
                throw new InvalidCloudMachineConfigurationException(configurationStoreDisplayName, key, e);
            }
        }
        private static int ReaderInt32(JsonElement json, string key, string configurationStoreDisplayName)
        {
            try {
                var value = json.GetProperty(key).GetInt32();
                return value;
            }
            catch (Exception e) {
                throw new InvalidCloudMachineConfigurationException(configurationStoreDisplayName, key, e);
            }
        }

        private static string ReadString(IConfiguration configuration, string key)
        {
            var value = configuration[key]!;
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(key);
            return value;
        }
        private static int ReadInt32(IConfiguration configuration, string key)
        {
            var valueText = configuration[key];
            if (string.IsNullOrEmpty(valueText)) throw new ArgumentNullException(key);
            var value = int.Parse(valueText);
            return value;
        }

        private static string GenerateCloudMachineId()
        {
            var guid = Guid.NewGuid();
            var guidString = guid.ToString("N");
            var cnId = "cm" + guidString.Substring(0, 15); // we can increase it to 20, but the template name cannot be that long
            return cnId;
        }

        // helper to to throw the right exception
        private static Stream OpenStream(string configurationFile)
        {
            try
            {
                return File.OpenRead(configurationFile);
            }
            catch (Exception e)
            {
                throw new InvalidCloudMachineConfigurationException(configurationFile, setting: null, e);
            }
        }

        internal class InvalidCloudMachineConfigurationException : InvalidOperationException
        {
            public InvalidCloudMachineConfigurationException(string configurationStoreDisplayName, string? setting, Exception innerException) :
                base(CreateMessage(configurationStoreDisplayName, setting), innerException)
            { }

            public static string CreateMessage(string configurationStoreDisplayName, string? setting)
            {
                if (setting != null)
                    return $"ERROR: Configuration setting {setting} not found in {configurationStoreDisplayName} or invalid format.";
                else
                    return $"ERROR: Configuration store {configurationStoreDisplayName} not found or invalid format.";
            }
        }
    }
}
