// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public class CommentStatement(string comment) : BicepStatement
{
    public string Comment { get; } = comment;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append("// ").Append(Comment).AppendLine();
}
