// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects;

[CodeGenType("ListAgentsRequestOrder")]
public readonly partial struct AgentListOrder
{
    [CodeGenMember("Asc")]
    public static AgentListOrder Ascending { get; } = new AgentListOrder(AscValue);

    [CodeGenMember("Desc")]
    public static AgentListOrder Descending { get; } = new AgentListOrder(DescValue);
}
