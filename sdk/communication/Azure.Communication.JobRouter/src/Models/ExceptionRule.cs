// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("ExceptionRule")]
    public partial class ExceptionRule
    {
        /// <summary> Initializes a new instance of ExceptionRule. </summary>
        /// <param name="trigger"> The trigger for this exception rule. </param>
        /// <param name="actions"> A dictionary collection of actions to perform once the exception is triggered. Key is the Id of each exception action. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="trigger"/> or <paramref name="actions"/> is null. </exception>
        public ExceptionRule(JobExceptionTrigger trigger, IDictionary<string, ExceptionAction?> actions)
        {
            if (trigger == null)
            {
                throw new ArgumentNullException(nameof(trigger));
            }
            if (actions == null)
            {
                throw new ArgumentNullException(nameof(actions));
            }

            Trigger = trigger;
            Actions = actions;
        }

        /// <summary> A dictionary collection of actions to perform once the exception is triggered. Key is the Id of each exception action. </summary>
        public IDictionary<string, ExceptionAction?> Actions { get; }
    }
}
