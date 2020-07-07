// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>
    /// Provides parameter details that can be used for showing the parameter
    /// in the WebJobs Dashboard.
    /// </summary>
    /// <remarks>
    /// Note: These descriptions are NOT localized - they will only be used in
    /// the English Dashboard. However, currently the Dashboard itself is not
    /// localized.
    /// </remarks>
    public class ParameterDisplayHints
    {
        /// <summary>
        /// Gets or sets the parameter description.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets the prompt that will be shown next to the
        /// user input control.
        /// </summary>
        public virtual string Prompt { get; set; }

        /// <summary>
        /// Gets or sets the default value.
        /// </summary>
        public virtual string DefaultValue { get; set; }
    }
}
