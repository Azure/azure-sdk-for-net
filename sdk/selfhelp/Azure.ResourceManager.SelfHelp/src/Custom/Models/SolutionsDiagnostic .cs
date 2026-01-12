// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.SelfHelp;

namespace Azure.ResourceManager.SelfHelp.Models
{
    /// <summary> Solutions Diagnostic. </summary>
    public partial class SolutionsDiagnostic
    {
        /// <summary> Required parameters of this item. </summary>
        public IReadOnlyList<string> RequiredParameters { get; }

        /// <summary> Diagnostic insights. </summary>
        public IReadOnlyList<SelfHelpDiagnosticInsight> Insights { get; }
    }
}
