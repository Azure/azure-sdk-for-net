// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep comment statement.
/// </summary>
/// <param name="comment">The comment text.</param>
public class CommentStatement(string comment) : BicepStatement
{
    /// <summary>
    /// Gets the comment text.
    /// </summary>
    public string Comment { get; } = comment;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append("// ").Append(Comment).AppendLine();
}
