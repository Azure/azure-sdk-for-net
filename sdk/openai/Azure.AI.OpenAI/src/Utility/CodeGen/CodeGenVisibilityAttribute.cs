// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.OpenAI;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
internal partial class CodeGenVisibilityAttribute : Attribute
{
    public string MemberName { get; }
    public CodeGenVisibility Visibility { get; }
    public Type[] Parameters { get; }

    public CodeGenVisibilityAttribute(string memberName, CodeGenVisibility visibility, params Type[] parameters)
    {
        MemberName = memberName;
        Visibility = visibility;
        Parameters = parameters;
    }
}

internal enum CodeGenVisibility
{
    Internal,
    Public,
}