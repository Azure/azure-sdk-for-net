// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Azure.OpenAI.Inference.Tests
{
    public abstract class OpenAITestBase
    {
        private static string configFile = "config.txt";
        private static string repoDirectoryName = "azure-sdk-for-net";
        private static string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
        private static string s = Path.DirectorySeparatorChar.ToString();
        private static string repoLevelFilePath = GetTopLevelFilePath(currentPath, repoDirectoryName);
        private static string solutionLevelFilePath = $@"{repoLevelFilePath}{s}sdk{s}cognitiveservices{s}Azure.OpenAI.Inference";
        private static Dictionary<string, string> configFileDict = File.ReadAllLines($@"{solutionLevelFilePath}{s}secrets{s}{configFile}")
                                       .Select(x => x.Split('='))
                                       .ToDictionary(x => x[0], x => x[1]);
        private static readonly string endpoint = configFileDict["azureEndpoint"];
        private static readonly string key = configFileDict["azureApiKey"];
        private static readonly string deploymentId = configFileDict["azureDeploymentId"];

        protected static string DeploymentId => deploymentId;

        private Type TypeName => GetType();

        protected OpenAIClient GetClient()
        {
            var client = new OpenAIClient(new Uri(endpoint), new AzureKeyCredential(key));
            return client;
        }

        private static string GetTopLevelFilePath(string currentDir, string topLevel)
        {
            var dirInfo = new DirectoryInfo(currentDir);
            while (!String.Equals(dirInfo.Name, topLevel))
            {
                dirInfo = dirInfo.Parent;
            }
            return dirInfo.FullName;
        }
    }
}
