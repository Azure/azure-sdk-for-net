// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a complete Bicep program composed of statements.
/// </summary>
/// <param name="body">The statements that make up the program body.</param>
public class BicepProgram(params BicepStatement[] body)
{
    /// <summary>
    /// Gets the statements that make up the program body.
    /// </summary>
    public BicepStatement[] Body { get; } = body;
    /// <summary>
    /// Gets or sets the module name for this program.
    /// </summary>
    public string? ModuleName { get; set; }
    /// <inheritdoc />
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
