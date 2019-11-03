// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//using Azure.Core.Testing;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;

//namespace Azure.AI.TextAnalytics.Samples
//{
//    [LiveOnly]
//    public partial class ConfigurationSamples
//    {
//        [Test]
//        public void DetectLanguageBatchAdvanced()
//        {
//            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
//            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

//            // Instantiate a client that will be used to call the service.
//            var client = new TextAnalyticsClient(endpoint, subscriptionKey);

//            var inputs = new List<string>
//            {
//                "Hello world",
//                "Bonjour tout le monde",
//                "Hola mundo",
//                ":) :( :D"
//            };

//            Debug.WriteLine($"Detecting language for input batch:");
//            // TODO: pretty print batch.
//            var perInputLanguages = client.DetectLanguages(inputs);

//            foreach (var languages in perInputLanguages)
//            {
//                Debug.WriteLine($"Detected language {languages[0].Name} with confidence {languages[0].Score}.");
//            }
//        }
//    }
//}
