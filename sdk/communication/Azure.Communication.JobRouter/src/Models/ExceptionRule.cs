// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;

namespace Azure.Communication.JobRouter
{
    public partial class ExceptionRule
    {
        /// <summary> Initializes a new instance of an exception rule. </summary>
        /// <param name="id"> Id of an exception rule. </param>
        /// <param name="trigger"> The trigger for this exception rule. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="trigger"/>. </exception>
        public ExceptionRule(string id, ExceptionTrigger trigger)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Trigger = trigger ?? throw new ArgumentNullException(nameof(trigger));
        }

        /// <summary> A collection of actions to perform once the exception is triggered. </summary>
        public IList<ExceptionAction> Actions { get; } = new List<ExceptionAction>();
    }
}
