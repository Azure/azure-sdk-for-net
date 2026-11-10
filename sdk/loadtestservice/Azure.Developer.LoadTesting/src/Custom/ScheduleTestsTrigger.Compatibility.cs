// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Developer.LoadTesting
{
    public partial class ScheduleTestsTrigger
    {
        /// <summary> Initializes a new instance of <see cref="ScheduleTestsTrigger"/>. </summary>
        /// <param name="displayName"> The name of the trigger. </param>
        /// <param name="testIds"> The test identifiers for the trigger. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="displayName"/> or <paramref name="testIds"/> is null. </exception>
        public ScheduleTestsTrigger(string displayName, IEnumerable<string> testIds) : this()
        {
            if (displayName is null)
            {
                throw new ArgumentNullException(nameof(displayName));
            }

            if (testIds is null)
            {
                throw new ArgumentNullException(nameof(testIds));
            }

            DisplayName = displayName;
            foreach (string testId in testIds)
            {
                TestIds.Add(testId);
            }
        }
    }
}
