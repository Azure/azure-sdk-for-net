// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.AI.Extensions.OpenAI;

/// <summary> Represents options for configuring a project responses client. </summary>
/// <remarks>
/// This type is retained for binary compatibility. New code should use
/// <see cref="ProjectOAIResponsesClientOptions"/>, which derives from
/// <c>OpenAI.Responses.ResponsesClientOptions</c> in alignment with the upstream
/// OpenAI client option hierarchy.
/// </remarks>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class ProjectResponsesClientOptions : ProjectOpenAIClientOptions
{
}
