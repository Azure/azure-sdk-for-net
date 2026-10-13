// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Extensions.OpenAI;

/// <summary>
/// authentication details for OpenApiFunctionDefinition
/// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="OpenApiAnonymousAuthenticationDetails"/>, <see cref="OpenApiProjectConnectionAuthenticationDetails"/>, and <see cref="OpenApiManagedAuthenticationDetails"/>.
/// </summary>
public abstract partial class OpenApiAuthenticationDetails
{
    /// <summary> Initializes a new instance of <see cref="OpenApiAuthenticationDetails"/>. </summary>
    /// <param name="kind"> The type of authentication, must be anonymous/project_connection/managed_identity. </param>
    protected OpenApiAuthenticationDetails(OpenApiAuthenticationKind kind)
    {
        Kind = kind;
    }

    /// <summary> The type of authentication, must be anonymous/project_connection/managed_identity. </summary>
    protected OpenApiAuthenticationKind Kind { get; set; }
}
