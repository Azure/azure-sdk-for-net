// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Extensions.OpenAI;

public partial class AgentWorkflowPreviewActionResponseItem
{
    /// <summary> Gets or sets the kind of CSDL action. </summary>
    public string Kind
    {
        get => CSDLActionKind;
        set => CSDLActionKind = value;
    }
}
