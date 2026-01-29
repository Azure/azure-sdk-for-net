// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public class BicepProgram(params BicepStatement[] body)
{
    public BicepStatement[] Body { get; } = body;
    public string? ModuleName { get; set; }
    public override string ToString()
    {
        BicepWriter writer = new();
        // if (ModuleName != null) { writer.Append("// module ").Append(ModuleName).AppendLine(); }
        foreach (BicepStatement statement in Body)
        {
            writer = writer.Append(statement).AppendLine();
        }
        return writer.ToString();
    }
}
