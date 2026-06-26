// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Extensions.OpenAI;

/// <summary> Specifies the grammar syntax used by a response grammar. </summary>
[CodeGenType("GrammarSyntax1")]
public enum ResponsesGrammarSyntax
{
    /// <summary> Uses Lark syntax. </summary>
    Lark,
    /// <summary> Uses regular expression syntax. </summary>
    Regex
}
