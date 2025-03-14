// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.OnlineExperimentation
{
    public partial struct ValidationResultOption
    {
        /// <summary>
        /// Determines if this result is <see cref="Valid"/>.
        /// </summary>
        /// <returns><see langword="true"/> if this instance is <see cref="Valid"/>, otherwise <see langword="false"/>. </returns>
        public bool IsValid()
        {
            return Equals(Valid);
        }
    }
}
