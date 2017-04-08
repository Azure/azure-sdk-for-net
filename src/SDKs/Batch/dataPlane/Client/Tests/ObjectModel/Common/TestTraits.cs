// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace BatchTestCommon
{
    public static class TestTraits
    {
        public static class Duration
        {
            public const string TraitName = "Duration";

            public static class Values
            {
                public const string LongLongDuration = "Long Long Duration (> 2 minutes)";
                public const string LongDuration = "Long Duration (> 30 seconds, < 2 minutes)";
                public const string MediumDuration = "Medium Duration (> 5 seconds, < 30 seconds)";
                public const string ShortDuration = "Short Duration (>1 second, < 5 seconds)";
                public const string VeryShortDuration = "Very Short Duration (< 1 second)";
            }
        }
    }
}
