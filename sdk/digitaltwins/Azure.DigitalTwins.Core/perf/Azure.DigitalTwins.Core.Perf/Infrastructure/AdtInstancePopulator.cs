// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.DigitalTwins.Core.Perf.Infrastructure
{
    internal class AdtInstancePopulator
    {
        private static readonly string s_dtdlDirectoryPath = Path.Combine(GetWorkingDirectory(), "Infrastructure");

        private static readonly string s_modelsPath = Path.Combine(s_dtdlDirectoryPath, "Models");
        private static readonly string s_twinsPath = Path.Combine(s_dtdlDirectoryPath, "Twins");

        private const string RoomModelFileName = "Room.json";
        private const string RoomTwinFileName = "RoomTwin.json";

        public static async Task CreateRoomModelAsync(DigitalTwinsClient client)
        {
            await client.CreateModelsAsync(new List<string> { GetRoomModel() }).ConfigureAwait(false);
        }

        public static async Task CreateIndividualRoomTwins(DigitalTwinsClient client, string testId, long countOftwins)
        {
            string batchTwinPrefix = $"room-{testId}-{Guid.NewGuid().ToString().Substring(0, 8)}";
            for (long i = 0; i < countOftwins; i++)
            {
                string twinId = $"{batchTwinPrefix}-{i}";
                await client.CreateOrReplaceDigitalTwinAsync(twinId, GetRoomTwin(testId)).ConfigureAwait(false);
            }
        }

        public static string GetRoomModel()
        {
            return LoadFileFromPath(s_modelsPath, RoomModelFileName);
        }

        public static BasicDigitalTwin GetRoomTwin(string testId)
        {
            string value = LoadFileFromPath(s_twinsPath, RoomTwinFileName).Replace("TEST_ID", testId);
            return JsonSerializer.Deserialize<BasicDigitalTwin>(value);
        }

        private static string GetWorkingDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().Location;
            var uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        private static string LoadFileFromPath(string path, string fileName)
        {
            string[] allFilesPath = Directory.GetFiles(path, "*.json");
            try
            {
                string filePathOfInterest = allFilesPath.Where(s => Path.GetFileName(s) == fileName).FirstOrDefault();
                return File.ReadAllText(filePathOfInterest);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading twin types from disk due to: {ex.Message}", ConsoleColor.Red);
                Environment.Exit(0);
            }

            return null;
        }
    }
}
