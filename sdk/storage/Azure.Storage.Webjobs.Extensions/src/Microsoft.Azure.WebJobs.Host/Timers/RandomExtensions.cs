// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Host.Timers
{
    internal static class RandomExtensions
    {
        public static double Next(this Random random, double minValue, double maxValue)
        {
            if (random == null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            return ((maxValue - minValue) * random.NextDouble()) + minValue;
        }
    }
}
