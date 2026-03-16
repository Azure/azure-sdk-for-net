// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects.Agents
{
    internal partial class InternalProjectsClient
    {
        /// <summary> Initializes a new instance of InternalProjectsClient from a <see cref="InternalProjectsClientSettings"/>. </summary>
        /// <param name="settings"> The settings for InternalProjectsClient. </param>
        [Experimental("SCME0002")]
        public InternalProjectsClient(InternalProjectsClientSettings settings) : this(AuthenticationPolicy.Create(settings), settings?.Endpoint, settings?.Options)
        {
        }
    }
}
