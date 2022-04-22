// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.Media.VideoAnalyzer.Edge.Models
{
    public partial class ParameterDefinition
    {
        /// <summary> Initializes a new instance of ParameterDefinition. </summary>
        /// <param name="name"> The name of the parameter defined in the pipeline topology. </param>
        /// <param name="value"> The value to supply for the named parameter defined in the pipeline topology. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="value"/> is null. </exception>
        public ParameterDefinition(string name, string value)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            Value = value;
        }
    }
}
