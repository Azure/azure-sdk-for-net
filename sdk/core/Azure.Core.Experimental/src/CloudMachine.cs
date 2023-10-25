// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using Azure.Core;

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
        public string Id { get; }

        /// <summary>
        /// Friendly name of CloudMachine. It's stored as a Tag of all Azure resources associated with the machine.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Azure subscription ID.
        /// </summary>
        public string SubscriptionId { get; }

        /// <summary>
        /// Azure region, e.g. westus2
        /// </summary>
        public string Region { get; }

        private int Version { get; }

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
            return new CloudMachine(id, defaultDisplayName, subscriptionId, region, 1);
        }

        /// <summary>
        /// Loads CloudMachine settings from configurationFile
        /// </summary>
        /// <param name="configurationFile">Default value is .azure\cloudmachine.json</param>
        /// <exception cref="InvalidCloudMachineConfigurationException"></exception>
        public CloudMachine(string? configurationFile = default)
        {
            configurationFile ??= Path.Combine(".azure", "cloudmachine.json");

            try
            {
                byte[] configurationContent = File.ReadAllBytes(configurationFile);
                var document = JsonDocument.Parse(configurationContent);
                JsonElement json = document.RootElement.GetProperty("CloudMachine");

                Id = ReadString(json, "id", configurationFile);
                SubscriptionId = ReadString(json, "subscriptionId", configurationFile);
                Region = ReadString(json, "region", configurationFile);
                DisplayName = ReadString(json, "name", configurationFile);
                Version = ReadInt32(json, "version", configurationFile);
            }
            catch (Exception e) when (e is not InvalidCloudMachineConfigurationException)
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

                Id = ReadString(json, "id", nameof(configurationContent));
                SubscriptionId = ReadString(json, "subscriptionId", nameof(configurationContent));
                Region = ReadString(json, "region", nameof(configurationContent));
                DisplayName = ReadString(json, "name", nameof(configurationContent));
                Version = ReadInt32(json, "version", nameof(configurationContent));
            }
            catch (Exception e) when (e is not InvalidCloudMachineConfigurationException)
            {
                throw new InvalidCloudMachineConfigurationException(nameof(configurationContent), setting: null, e);
            }
        }

        private CloudMachine(string id, string displayName, string subscriptionId, string region, int version)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNullOrEmpty(displayName, nameof(displayName));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(region, nameof(region));
            Argument.AssertInRange(version, 0, int.MaxValue, nameof(version));

            Id = id;
            DisplayName = displayName;
            SubscriptionId = subscriptionId;
            Region = region;
            Version = version;
        }

        /// <summary>
        /// Save CloudMachine configuration to a stream.
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
        /// Save CloudMachine configuration to a file.
        /// </summary>
        /// <param name="filepath"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Save(string filepath)
        {
            string? directory = Path.GetDirectoryName(filepath);
            if (directory != null && !Directory.Exists(directory)) Directory.CreateDirectory(directory);
            using FileStream stream = File.OpenWrite(filepath);
            Save(stream);
        }

        private static string ReadString(JsonElement json, string key, string configurationStoreDisplayName)
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
        private static int ReadInt32(JsonElement json, string key, string configurationStoreDisplayName)
        {
            try {
                var value = json.GetProperty(key).GetInt32();
                return value;
            }
            catch (Exception e) {
                throw new InvalidCloudMachineConfigurationException(configurationStoreDisplayName, key, e);
            }
        }

        private static string GenerateCloudMachineId()
        {
            var guid = Guid.NewGuid();
            var guidString = guid.ToString("N");
            var cnId = "cm" + guidString.Substring(0, 15); // we can increase it to 20, but the template name cannot be that long
            return cnId;
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
