// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace Azure.AI.Projects.Agents;

public partial class AgentRecord
{
    internal AgentObjectVersions Versions { get; }

    public AgentVersion GetLatestVersion() => Versions.Latest;
}
