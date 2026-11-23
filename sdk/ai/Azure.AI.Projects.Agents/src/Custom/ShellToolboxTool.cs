// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.Projects.Agents;

public partial class ShellToolboxTool
{
    /// <summary> Gets the AllowedCallers. </summary>
    public IList<CallableToolAllowedCaller> AllowedCallers { get; }
}
