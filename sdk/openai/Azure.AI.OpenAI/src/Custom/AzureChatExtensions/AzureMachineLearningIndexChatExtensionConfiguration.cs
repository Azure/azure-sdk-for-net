// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.AI.OpenAI;

[CodeGenSuppress("AzureMachineLearningIndexChatExtensionConfiguration", typeof(AzureMachineLearningIndexChatExtensionParameters))]
public partial class AzureMachineLearningIndexChatExtensionConfiguration : AzureChatExtensionConfiguration
{
    // CUSTOM CODE NOTE:
    //    These changes facilitate the direct use of the extension "configuration" classes for access to their
    //    constituent "parameter" values. These serialize into a subordinate payload within the wire format
    //    REST structure but don't convey additional semantic meaning, so internalizing parameter types and then
    //    plumbing the configuration through substantially simplifies the experience.

    /// <summary> Initializes a new instance of <see cref="AzureMachineLearningIndexChatExtensionConfiguration"/>. </summary>
    public AzureMachineLearningIndexChatExtensionConfiguration()
    {
        Type = AzureChatExtensionType.AzureMachineLearningIndex;
        Parameters = new AzureMachineLearningIndexChatExtensionParameters();
    }

    internal AzureMachineLearningIndexChatExtensionParameters Parameters { get; }

    /// <inheritdoc cref="AzureMachineLearningIndexChatExtensionParameters.Authentication"/>
    public OnYourDataAuthenticationOptions Authentication
    {
        get => Parameters.Authentication;
        set => Parameters.Authentication = value;
    }
    /// <inheritdoc cref="AzureMachineLearningIndexChatExtensionParameters.DocumentCount"/>
    public int? DocumentCount
    {
        get => Parameters.DocumentCount;
        set => Parameters.DocumentCount = value;
    }
    /// <inheritdoc cref="AzureMachineLearningIndexChatExtensionParameters.ShouldRestrictResultScope"/>
    public bool? ShouldRestrictResultScope
    {
        get => Parameters.ShouldRestrictResultScope;
        set => Parameters.ShouldRestrictResultScope = value;
    }
    /// <inheritdoc cref="AzureMachineLearningIndexChatExtensionParameters.Strictness"/>
    public int? Strictness
    {
        get => Parameters.Strictness;
        set => Parameters.Strictness = value;
    }
    /// <inheritdoc cref="AzureMachineLearningIndexChatExtensionParameters.RoleInformation"/>
    public string RoleInformation
    {
        get => Parameters.RoleInformation;
        set => Parameters.RoleInformation = value;
    }
    /// <inheritdoc cref="AzureMachineLearningIndexChatExtensionParameters.ProjectResourceId"/>
    public string ProjectResourceId
    {
        get => Parameters.ProjectResourceId;
        set => Parameters.ProjectResourceId = value;
    }
    /// <inheritdoc cref="AzureMachineLearningIndexChatExtensionParameters.Name"/>
    public string Name
    {
        get => Parameters.Name;
        set => Parameters.Name = value;
    }
    /// <inheritdoc cref="AzureMachineLearningIndexChatExtensionParameters.Version"/>
    public string Version
    {
        get => Parameters.Version;
        set => Parameters.Version = value;
    }
    /// <inheritdoc cref="AzureMachineLearningIndexChatExtensionParameters.Filter"/>
    public string Filter
    {
        get => Parameters.Filter;
        set => Parameters.Filter = value;
    }
}
