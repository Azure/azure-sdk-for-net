// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
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

            TrainCustomModel().Wait();

            //GetCustomModelsSummary();
        }

        private static async Task TrainCustomModel()
        {
            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new CustomFormClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            string sasUrl = "https://annelostorage01.blob.core.windows.net/container-formreco?sp=rl&st=2020-02-29T17:07:48Z&se=2020-03-01T17:07:48Z&sv=2019-02-02&sr=c&sig=Ls4zfs2hidZ4VS%2BiEkRv1Y6brqjf0te1VfI72HodsRE%3D";
            var trainingOperation = client.StartTraining(sasUrl);

            await trainingOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(4));
            if (trainingOperation.HasValue)
            {
                Model model = trainingOperation.Value;
            }
            else
            {
                Console.WriteLine("LRO did not return a value.");
            }
        }

        private static void GetCustomModelsSummary()
        {
            string subscriptionKey = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_SUBSCRIPTION_KEY");
            string formRecognizerEndpoint = Environment.GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

            var client = new CustomFormClient(new Uri(formRecognizerEndpoint), new FormRecognizerApiKeyCredential(subscriptionKey));

            var models = client.GetCustomModelSummary();
        }
    }
}
