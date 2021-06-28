// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// A custom class for Conditions, which define the logic contained in WHERE objects.
    /// </summary>
    internal abstract class ConditionBase
    {
        public abstract string GetConditionText();
    }
}
