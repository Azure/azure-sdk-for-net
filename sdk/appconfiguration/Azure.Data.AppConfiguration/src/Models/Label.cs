// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.AppConfiguration
{
    /// <summary> A label used to group key-values. </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public partial class Label
#pragma warning restore AZC0012 // Avoid single word type names
    {
        /// <summary> Initializes a new instance of <see cref="Label"/>. </summary>
        /// <param name="name"> The name of the label. </param>
        internal Label(string name)
        {
            Name = name;
        }

        /// <summary> The name of the label. </summary>
        public string Name { get; }
    }
}
