// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.AlphaIds.Models;
using NUnit.Framework;

namespace Azure.Communication.AlphaIds.Tests.Samples
{
    public partial class Sample1_AlphaIdsClient : AlphaIdsClientTestBase
    {
        public Sample1_AlphaIdsClient(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task GetConfiguration()
        {
            AlphaIdsClient client = CreateAlphaIdsClientClient();

            #region Snippet:Azure_Communication_AlphaIds_GetConfiguration
            try
            {
                AlphaIdConfiguration configuration = await client.GetConfigurationAsync();

                Console.WriteLine($"The usage of Alpha IDs is currently {(configuration.Enabled ? "enabled" : "disabled")}");
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status == 403)
                {
                    Console.WriteLine("Resource is not eligible for Alpha ID usage");
                }
            }
            #endregion
        }
    }
}
