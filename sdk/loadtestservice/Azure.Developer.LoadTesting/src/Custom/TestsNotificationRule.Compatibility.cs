// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Developer.LoadTesting
{
    public partial class TestsNotificationRule
    {
        /// <summary> Initializes a new instance of <see cref="TestsNotificationRule"/>. </summary>
        /// <param name="displayName"> The name of the notification rule. </param>
        /// <param name="actionGroupIds"> The action groups to notify. </param>
        /// <param name="eventFilters"> The event filters for the notification rule. </param>
        /// <exception cref="ArgumentNullException"> An argument is null. </exception>
        public TestsNotificationRule(string displayName, IEnumerable<string> actionGroupIds, IDictionary<string, TestsNotificationEventFilter> eventFilters) : this()
        {
            if (displayName is null)
            {
                throw new ArgumentNullException(nameof(displayName));
            }

            if (actionGroupIds is null)
            {
                throw new ArgumentNullException(nameof(actionGroupIds));
            }

            if (eventFilters is null)
            {
                throw new ArgumentNullException(nameof(eventFilters));
            }

            DisplayName = displayName;
            foreach (string actionGroupId in actionGroupIds)
            {
                ActionGroupIds.Add(actionGroupId);
            }

            EventFilters = eventFilters;
        }
    }
}
