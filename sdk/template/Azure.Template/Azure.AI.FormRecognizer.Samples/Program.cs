// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Template;

namespace Azure.AI.FormRecognizer.Samples
{
    /// <summary>
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new CustomFormClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            var models = client.GetCustomModelSummary();

        }
    }
}
