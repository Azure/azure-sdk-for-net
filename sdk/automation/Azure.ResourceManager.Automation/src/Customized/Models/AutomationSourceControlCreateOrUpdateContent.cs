// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Compatibility shim preserving GA setters for flattened source control create/update properties.
    [CodeGenSuppress("AutomationSourceControlCreateOrUpdateContent")]
    [CodeGenSuppress("Branch")]
    [CodeGenSuppress("Description")]
    [CodeGenSuppress("FolderPath")]
    [CodeGenSuppress("IsAutoPublishRunbookEnabled")]
    [CodeGenSuppress("IsAutoSyncEnabled")]
    [CodeGenSuppress("RepoUri")]
    [CodeGenSuppress("SecurityToken")]
    [CodeGenSuppress("SourceType")]
    public partial class AutomationSourceControlCreateOrUpdateContent
    {
        /// <summary> Initializes a new instance of <see cref="AutomationSourceControlCreateOrUpdateContent"/>. </summary>
        public AutomationSourceControlCreateOrUpdateContent()
        {
            Properties = new SourceControlCreateOrUpdateProperties();
        }

        /// <summary> The repo branch of the source control. Include branch as empty string for VsoTfvc. </summary>
        public string Branch
        {
            get => Properties.Branch;
            set => Properties.Branch = value;
        }

        /// <summary> The user description of the source control. </summary>
        public string Description
        {
            get => Properties.Description;
            set => Properties.Description = value;
        }

        /// <summary> The folder path of the source control. Path must be relative. </summary>
        public string FolderPath
        {
            get => Properties.FolderPath;
            set => Properties.FolderPath = value;
        }

        /// <summary> The auto publish of the source control. Default is true. </summary>
        public bool? IsAutoPublishRunbookEnabled
        {
            get => Properties.IsAutoPublishRunbookEnabled;
            set => Properties.IsAutoPublishRunbookEnabled = value;
        }

        /// <summary> The auto async of the source control. Default is false. </summary>
        public bool? IsAutoSyncEnabled
        {
            get => Properties.IsAutoSyncEnabled;
            set => Properties.IsAutoSyncEnabled = value;
        }

        /// <summary> The repo url of the source control. </summary>
        public Uri RepoUri
        {
            get => Properties.RepoUri;
            set => Properties.RepoUri = value;
        }

        /// <summary> The authorization token for the repo of the source control. </summary>
        public SourceControlSecurityTokenProperties SecurityToken
        {
            get => Properties.SecurityToken;
            set => Properties.SecurityToken = value;
        }

        /// <summary> The source type. Must be one of VsoGit, VsoTfvc, GitHub, case sensitive. </summary>
        public SourceControlSourceType? SourceType
        {
            get => Properties.SourceType;
            set => Properties.SourceType = value;
        }
    }
}
