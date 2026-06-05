// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace Azure.AI.Projects.Agents;

public partial class ProjectsAgentRecord
{
    internal AgentObjectVersions Versions { get; }

    /// <summary> Returns the most recent version of this agent. </summary>
    public ProjectsAgentVersion GetLatestVersion() => Versions.Latest;
}
