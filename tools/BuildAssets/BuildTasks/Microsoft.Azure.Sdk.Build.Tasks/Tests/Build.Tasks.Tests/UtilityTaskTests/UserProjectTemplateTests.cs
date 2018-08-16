// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Build.Tasks.Tests.UtilityTaskTests
{
    using Microsoft.Azure.Sdk.Build.UtilityTasks;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class UserProjectTemplateTests: BuildTestBase
    {
        [Fact]
        public void ProjectTemplateInstall()
        {
            string toolsDir = this.ToolsRootDir;
            string vsTemplateDir = this.GetVSTemplatesDir();

            InstallProjectTemplates templateTsk = new InstallProjectTemplates();
            templateTsk.ToolsDirPath = toolsDir;
            templateTsk.Execute();

            foreach(string templateName in templateTsk.templateDirNames)
            {
                string fullPath = string.Concat(Path.Combine(vsTemplateDir, templateName), ".zip");
                Assert.True(File.Exists(fullPath));
            }
        }

        private string GetVSTemplatesDir()
        {
            string userTemplateDir = string.Empty;
            string userProfDir = Environment.GetEnvironmentVariable("UserProfile");

            if (Directory.Exists(userProfDir))
            {
                string templateDir = Path.Combine(userProfDir, @"Documents\Visual Studio 2017\Templates\ProjectTemplates");
                if (Directory.Exists(templateDir))
                {
                    userTemplateDir = templateDir;
                }
            }

            return userTemplateDir;
        }
    }
}
