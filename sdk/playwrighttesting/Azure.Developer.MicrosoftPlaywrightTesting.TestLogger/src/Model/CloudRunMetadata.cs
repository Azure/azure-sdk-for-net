﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model
{
    internal class CloudRunMetadata
    {
        internal string? WorkspaceId { get; set; }
        internal string? RunId { get; set; }
        internal Uri? BaseUri { get; set; }
        internal string? PortalUrl
        {
            get { return ReporterConstants.s_portalBaseUrl + Uri.EscapeDataString(WorkspaceId) + ReporterConstants.s_reportingRoute + Uri.EscapeDataString(RunId); }
        }
        internal bool EnableResultPublish { get; set; } = true;
        internal bool EnableGithubSummary { get; set; } = true;
        internal DateTime TestRunStartTime { get; set; }
        internal TokenDetails? AccessTokenDetails { get; set; }
    }
}
