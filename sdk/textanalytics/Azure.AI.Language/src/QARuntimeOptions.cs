// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.Language
{
    /// <summary>
    /// Options that allow callers to specify details about how the operation
    /// is run and what information is returned from it by the service.
    /// </summary>
    public class QARuntimeOptions: ClientOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QARuntimeOptions"/>
        /// class.
        /// </summary>
        public QARuntimeOptions()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QARuntimeOptions"/>
        /// </summary>
        /// <param name="environment">environment</param>
        /// <param name="kbid">kbid</param>
        internal QARuntimeOptions(string environment = "prebuilt", string kbid = "prebuilt")
        {
            Environment = environment;
            Kbid = kbid;
        }

        /// <summary>
        /// environment - test or prod or prebuilt
        /// </summary>
        public string Environment { get; set; }

        /// <summary>
        /// KbId - knowledge base id - GUID or "prebuilt" for prebuilt API
        /// </summary>
        public string Kbid { get; set; }
    }
}
