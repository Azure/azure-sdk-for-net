// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Tests.PatchModels
{
    public partial class SimpleStandardModel
    {
        public SimpleStandardModel() { }

        internal SimpleStandardModel(string name, int count, DateTimeOffset updatedOn)
        {
            Name = name;
            Count = count;
            UpdatedOn = updatedOn;
        }

        public string Name { get; set; }

        public int? Count { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
