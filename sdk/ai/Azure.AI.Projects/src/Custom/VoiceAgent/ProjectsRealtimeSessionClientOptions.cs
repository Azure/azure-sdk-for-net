// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects
{
    /// <summary>
    /// The options for ProjectsRealtimeSessionClient.
    /// </summary>
    [Experimental("AAIP002")]
    public class ProjectsRealtimeSessionClientOptions
    {
        /// <summary>
        /// The constructor for the ProjectsRealtimeSessionClientOptions.
        /// </summary>
        /// <param name="parentClient">The ProjectsRealtimeClient used by session client.</param>
        /// <param name="tokenProperties">The properties, used to obtain the tokens.</param>
        public ProjectsRealtimeSessionClientOptions(ProjectsRealtimeClient parentClient, IReadOnlyDictionary<string, object> tokenProperties)
        {
            ParentClient = parentClient;
            TokenProperties = tokenProperties;
        }

        internal ProjectsRealtimeSessionClientOptions(ProjectsRealtimeClient parentClient, IReadOnlyDictionary<string, object> tokenProperties, string experimentalHeaders)
            :this(parentClient, tokenProperties)
        {
            ExperimentalHeaders = experimentalHeaders;
        }

        /// <summary>
        /// Model name.
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Intent.
        /// </summary>
        public string Intent { get; set; }
        /// <summary>
        /// Parent ProjectsRealtimeClient.
        /// </summary>
        public ProjectsRealtimeClient ParentClient { get; }
        /// <summary>
        /// Authentication properties.
        /// </summary>
        public IReadOnlyDictionary<string, object> TokenProperties { get; }
        /// <summary>
        /// The value for FoundryFeatures headers.
        /// </summary>
        internal string ExperimentalHeaders { get; set; } = RealtimeClientHelper.ExperimentalHeaders(null);
    }
}
