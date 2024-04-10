// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Developer.DevCenter.Models;

namespace Azure.Developer.DevCenter.Tests.Samples
{
    public partial class DevCenterSamples: SamplesBase<DevCenterClientTestEnvironment>
    {
        public async Task StopStartRestartDevBoxAsync()
        {
            #region Snippet:Azure_DevCenter_GetDevBox_Scenario
            // Create DevBox-es client
            string devCenterUri = "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com";
            var endpoint = new Uri(devCenterUri);
            var credential = new DefaultAzureCredential();
            var devBoxesClient = new DevBoxesClient(endpoint, credential);

            //Dev Box properties
            var projectName = "MyProject";
            var devBoxName = "MyDevBox";
            var user = "me";

            // Grab the dev box
            DevBox devBox = await devBoxesClient.GetDevBoxAsync(projectName, user, devBoxName);
            #endregion

            #region Snippet:Azure_DevCenter_StopDevBox_Scenario
            if (devBox.PowerState == PowerState.Running)
            {
                //Stop the dev box
                await devBoxesClient.StopDevBoxAsync(
                    WaitUntil.Completed,
                    projectName,
                    user,
                    devBoxName);

                Console.WriteLine($"Completed stopping the dev box.");
            }
            #endregion

            #region Snippet:Azure_DevCenter_StartDevBox_Scenario
            //Start the dev box
            Operation response = await devBoxesClient.StartDevBoxAsync(
                WaitUntil.Started,
                projectName,
                user,
                devBoxName);

            response.WaitForCompletionResponse();
            Console.WriteLine($"Completed starting the dev box.");

            #endregion

            #region Snippet:Azure_DevCenter_RestartDevBox_Scenario
            //Restart the dev box
            await devBoxesClient.RestartDevBoxAsync(
                WaitUntil.Completed,
                projectName,
                user,
                devBoxName);

            Console.WriteLine($"Completed restarting the dev box.");
            #endregion
        }
    }
}
