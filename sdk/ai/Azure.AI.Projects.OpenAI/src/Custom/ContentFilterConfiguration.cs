// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("RaiConfig")]
public partial class ContentFilterConfiguration
{
    /// <summary> The name of the RAI policy to apply. </summary>
    [CodeGenMember("RaiPolicyName")]
    public string PolicyName { get; set; }

    /// <summary> Initializes a new instance of <see cref="ContentFilterConfiguration"/>. </summary>
    /// <param name="policyName"> The name of the RAI policy to apply. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="policyName"/> is null. </exception>
    public ContentFilterConfiguration(string policyName)
    {
        Argument.AssertNotNull(policyName, nameof(policyName));

        PolicyName = policyName;
    }
}
