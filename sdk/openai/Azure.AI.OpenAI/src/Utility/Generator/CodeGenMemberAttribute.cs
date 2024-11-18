// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.AI.OpenAI;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
internal class CodeGenMemberAttribute : CodeGenTypeAttribute
{
    public CodeGenMemberAttribute() : base(null)
    {
    }

    public CodeGenMemberAttribute(string originalName) : base(originalName)
    {
    }
}
