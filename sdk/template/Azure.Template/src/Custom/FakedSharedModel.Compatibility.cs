// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Template
{
    public partial class FakedSharedModel
    {
        /// <summary> Initializes a new instance of <see cref="FakedSharedModel"/>. </summary>
        /// <param name="tag"> The tag. </param>
        /// <param name="createdOn"> The created date. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tag"/> is null. </exception>
        public FakedSharedModel(string tag, DateTimeOffset createdOn) : this()
        {
            if (tag is null)
            {
                throw new ArgumentNullException(nameof(tag));
            }

            Tag = tag;
            CreatedOn = createdOn;
        }
    }
}
