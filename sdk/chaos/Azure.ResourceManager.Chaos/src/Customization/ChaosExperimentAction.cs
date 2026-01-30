// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Chaos.Models
{
    public abstract partial class ChaosExperimentAction
    {
        /// <summary> Initializes a new instance of <see cref="ChaosExperimentAction"/>. </summary>
        /// <param name="name"> String that represents a Capability URN. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        protected ChaosExperimentAction(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }
    }
}
