// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.EventHubs.Tests.Samples
{
    public static class TriggerSingleModel
    {
        public class Dog
        {
            public string Name { get; set; }
            public string Breed { get; set; }
            public int Age { get; set; }
        }

        #region Snippet:TriggerSingleModel
        [FunctionName("TriggerSingleModel")]
        public static void Run(
            [EventHubTrigger("<event_hub_name>", Connection = "<connection_name>")] Dog dog,
            ILogger logger)
        {
            logger.LogInformation($"Who's a good dog? {dog.Name} is!");
        }
        #endregion
    }
}