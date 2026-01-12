// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.ResourceManager.SelfHelp;

namespace Azure.ResourceManager.SelfHelp.Models
{
    /// <summary> Troubleshooter step. </summary>
    public partial class SelfHelpStep
    {
        /// <summary> Gets the Inputs. </summary>
        public IReadOnlyList<TroubleshooterStepInput> Inputs { get; }

        /// <summary> Gets the Insights. </summary>
        public IReadOnlyList<SelfHelpDiagnosticInsight> Insights { get; }
    }
}
