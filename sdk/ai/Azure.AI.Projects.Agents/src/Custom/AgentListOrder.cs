// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects.Agents;

[CodeGenType("PageOrder")]
public readonly partial struct AgentListOrder
{
    /// <summary> Sort the list in ascending order by created-at timestamp. </summary>
    [CodeGenMember("Asc")]
    public static AgentListOrder Ascending { get; } = new AgentListOrder(AscValue);

    /// <summary> Sort the list in descending order by created-at timestamp. </summary>
    [CodeGenMember("Desc")]
    public static AgentListOrder Descending { get; } = new AgentListOrder(DescValue);
}
