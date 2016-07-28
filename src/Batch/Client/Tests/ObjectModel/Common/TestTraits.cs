// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

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
