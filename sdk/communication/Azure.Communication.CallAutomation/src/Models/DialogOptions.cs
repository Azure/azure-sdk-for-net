// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The DialogOptions. </summary>
    public class DialogOptions
    {
        /// <summary>
        /// Initializes a new instance of <see cref="DialogOptions"/>.
        /// </summary>
        /// <param name="botAppId">Bot identifier.</param>
        /// <param name="dialogContext">Dialog Context.</param>
        internal DialogOptions(string botAppId, IDictionary<string, object> dialogContext)
        {
            BotAppId = botAppId;
            DialogContext = dialogContext;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="DialogOptions"/>.
        /// </summary>
        /// <param name="dialogOptionsInternal">Internal Object.</param>
        internal DialogOptions(DialogOptionsInternal dialogOptionsInternal)
        {
            BotAppId = dialogOptionsInternal.BotAppId;
            DialogContext = dialogOptionsInternal.DialogContext;
        }
        /// <summary> Bot identifier. </summary>
        public string BotAppId { get; set; }
        /// <summary> Dialog context. </summary>
        public IDictionary<string, object> DialogContext { get; }
    }
}
