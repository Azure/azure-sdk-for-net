// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;

namespace SubscriptionCleaner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Subscription authorization file name example: 
            // Azure CLI Demo-2d.azureauth
            // -2d means that resource groups should be deleted after 2 days.
            string[] files = Directory.GetFiles(Environment.GetEnvironmentVariable("AZURE_CLEANUP_AUTH_LOCATION"), "*.azureauth");

            Console.WriteLine($"Found {files.Length} subscriptions to clean-up...");
            foreach (var file in files)
            {
                Console.WriteLine($"Cleaning subscription from auth '{file}'");
                try
                {
                    //=================================================================
                    // Authenticate
                    AzureCredentials credentials = SdkContext.AzureCredentialsFactory.FromFile(file);

                    var azure = Azure
                        .Configure()
                        .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                        .Authenticate(credentials)
                        .WithDefaultSubscription();

                    var client = new Microsoft.Azure.Management.ResourceManager.ResourceManagementClient(credentials);
                    client.SubscriptionId = credentials.DefaultSubscriptionId;

                    Regex r = new Regex(@"-(\d)d", RegexOptions.IgnoreCase);
                    var matches = r.Matches(Path.GetFileName(file));
                    int dayTTL = -1;

                    if (matches.Count > 0)
                    {
                        dayTTL = Convert.ToInt32(matches[0].Value[1]) - '0';
                        Console.WriteLine($" - Resource group TTL for this subscription is '{dayTTL}' day(s).");
                    }

                    try
                    {
                        foreach (var rg in azure.ResourceGroups.List())
                        {
                            try
                            {
                                if (rg.Name.EndsWith("-permanent", StringComparison.OrdinalIgnoreCase))
                                {
                                    Console.WriteLine($" - Resource Group '{rg.Name}' is marked as 'DO NOT DELETE'. Skipping.");
                                    continue;
                                }
                                if ("Deleting".Equals(rg.ProvisioningState, StringComparison.OrdinalIgnoreCase))
                                {
                                    Console.WriteLine($" - Resource Group '{rg.Name}' is already in 'Deleting' state.");
                                    continue;
                                }

                                var rgCreationTime = GetRGCreationDateTime(credentials, client, rg);

                                if (dayTTL != -1)
                                {
                                    var duration = (DateTime.Now - rgCreationTime).TotalDays;
                                    if (duration < dayTTL)
                                    {
                                        Console.WriteLine($" - Resource Group '{rg.Name}' was created less than {dayTTL} day(s) ago. Skipping.");
                                        continue;
                                    }
                                }

                                client.ResourceGroups.BeginDeleteWithHttpMessagesAsync(rg.Name)
                                    .ConfigureAwait(false)
                                    .GetAwaiter()
                                    .GetResult();

                                Console.WriteLine($" - Deleted Resource Group '{rg.Name}'.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($" [ERROR]: Exception while deleting Resource Group '{rg.Name}'.");
                                Console.WriteLine(ex);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($" [ERROR]: Exception while listing Resource Groups.");
                        Console.WriteLine(ex);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" [ERROR]: Exception during authentication.");
                    Console.WriteLine(ex);
                }
            }
            Console.WriteLine("Cleanup finished ");
        }

        private static DateTime GetRGCreationDateTime(
            AzureCredentials credentials,
            Microsoft.Azure.Management.ResourceManager.ResourceManagementClient client,
            IResourceGroup rg)
        {
            var url = $"{client.BaseUri.AbsoluteUri}subscriptions/{client.SubscriptionId}/resourceGroups/{rg.Name}?$expand=createdTime&api-version={client.ApiVersion}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            credentials.ProcessHttpRequestAsync(request, CancellationToken.None)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            var response = client.HttpClient.SendAsync(request)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Resource Group '{rg.Name}' did not return creation date. Skipping.");
            }

            string responseContent = response.Content.ReadAsStringAsync()
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            JObject body = null;
            if (!string.IsNullOrWhiteSpace(responseContent))
            {
                body = JObject.Parse(responseContent);
            }
            else
            {
                throw new Exception($"Resource Group '{rg.Name}' did not provide body content. Skipping.");
            }

            if (body == null ||
                body["createdTime"] == null)
            {
                throw new Exception($"Resource Group '{rg.Name}' did not return creation date in the body message. Skipping.");
            }

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };

            string str = SafeJsonConvert.SerializeObject(body["createdTime"], settings).Trim( new[] { '\"'});
            return DateTime.Parse(str);
        }
    }
}
