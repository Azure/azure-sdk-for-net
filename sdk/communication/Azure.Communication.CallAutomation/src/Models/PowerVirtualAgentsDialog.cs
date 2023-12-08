﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The PowerVirtualAgentsDialog. </summary>
    [CodeGenModel("PowerVirtualAgentsDialog")]
    [CodeGenSuppress("PowerVirtualAgentsDialog", typeof(IDictionary<string, object>), typeof(string))]
    public partial class PowerVirtualAgentsDialog : BaseDialog
    {
        /// <summary> Initializes a new instance of PowerVirtualAgentsDialogInternal. </summary>
        /// <param name="botAppId"> Bot identifier. </param>
        /// <param name="context"> Dialog context. </param>
        /// <param name="language"> Language. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="botAppId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="context"/> is null. </exception>
        public PowerVirtualAgentsDialog(string botAppId, IDictionary<string, object> context, string language = null) : base(DialogInputType.PowerVirtualAgents)
        {
            Argument.AssertNotNull(botAppId, nameof(botAppId));
            Argument.AssertNotNull(context, nameof(context));

            BotAppId = botAppId;
            Context = context;
            Language = language;
        }

        /// <summary> Initializes a new instance of PowerVirtualAgentsDialog. </summary>
        /// <param name="kind"> Determines the type of the dialog. </param>
        /// <param name="context"> Dialog context. </param>
        /// <param name="botAppId"> Bot identifier. </param>
        /// <param name="language"> Language. </param>
        internal PowerVirtualAgentsDialog(DialogInputType kind, IDictionary<string, object> context, string botAppId, string language) : base(DialogInputType.PowerVirtualAgents, context)
        {
            BotAppId = botAppId;
            Language = language;
        }
    }
}
