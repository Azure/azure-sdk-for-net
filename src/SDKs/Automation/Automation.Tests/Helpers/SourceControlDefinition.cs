// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Automation.Tests.Helpers
{
    public class SourceControlDefinition
    {
        public SourceControlDefinition(string sourceControlName, string repoUrl, string branch, string folderPath, bool autoSync,
                                       bool publishRunbook, string sourceType, string securityToken, string description,
                                       string updateBranchName, bool updateAutoPublish)
        {
            SourceControlName = sourceControlName;
            RepoUrl = repoUrl;
            Branch = branch;
            FolderPath = folderPath;
            AutoSync = autoSync;
            PublishRunbook = publishRunbook;
            SourceType = sourceType;
            SecurityToken = securityToken;
            Description = description;
            UpdateBranchName = updateBranchName;
            UpdateAutoPublish = updateAutoPublish;
        }

        public string SourceControlName { get; set; }

        public string RepoUrl { get; set; }

        public string Branch { get; set; }

        public string FolderPath { get; set; }

        public string SourceType { get; set; }

        public string SecurityToken { get; set; }

        public string Description { get; set; }

        public string UpdateBranchName { get; set; }

        public bool AutoSync { get; set; }

        public bool PublishRunbook { get; set; }

        public bool UpdateAutoPublish { get; set; }

        public static SourceControlDefinition TestSimpleSourceControlDefinition = new SourceControlDefinition(
                                                                                        "swaggerSourceControl",
                                                                                        "https://miaromero.visualstudio.com/_git/Marvin",
                                                                                        "master",
                                                                                        "/FolderOne",
                                                                                        false,
                                                                                        true,
                                                                                        "VsoGit",
                                                                                        "nzbxgndni3haxhy27mpyyocwlupsuj66o3fiu3xlhsybf62ffsoa",
                                                                                        "test creating a Source Control",
                                                                                        "BranchTwo",
                                                                                         false
                                                                                    );
    }
}