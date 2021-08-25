// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Reflection;

namespace Azure.ResourceManager.Resources.Tests.Helpers
{
    public static class TemplateLoader
    {
        public static string LoadTemplateContents(string templateName) => File.ReadAllText(Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "ScenarioTests",
            "DeploymentTemplates",
            $"{templateName}.json"));
    }
}
