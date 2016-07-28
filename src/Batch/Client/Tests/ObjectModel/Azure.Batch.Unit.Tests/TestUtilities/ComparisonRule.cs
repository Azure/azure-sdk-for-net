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

﻿namespace Azure.Batch.Unit.Tests.TestUtilities
{
    using System;

    public class ComparisonRule
    {
        public Type Type1 { get; private set; }

        public Type Type2 { get; private set; }

        public Func<object, object, ObjectComparer.CheckEqualityResult> Comparer { get; private set; }

        public string Type1PropertyName { get; private set; }

        public string Type2PropertyName { get; private set; }

        private ComparisonRule(
            Type type1,
            Type type2,
            Func<object, object, ObjectComparer.CheckEqualityResult> comparer,
            string type1PropertyName,
            string type2PropertyName)
        {
            this.Type1 = type1;
            this.Type2 = type2;

            this.Comparer = comparer;

            this.Type1PropertyName = type1PropertyName;
            this.Type2PropertyName = type2PropertyName;
        }

        public ComparisonRule Flip()
        {
            return new ComparisonRule(this.Type2, this.Type1, (o1, o2) => this.Comparer(o2, o1), this.Type2PropertyName, this.Type1PropertyName);
        }

        public static ComparisonRule Create<TOne, TTwo>(Type type1, Type type2, Func<TOne, TTwo, ObjectComparer.CheckEqualityResult> comparer, string type1PropertyName, string type2PropertyName)
        {
            return new ComparisonRule(
                type1,
                type2,
                (one, two) => comparer((TOne)one, (TTwo)two),
                type1PropertyName,
                type2PropertyName);
        }
    }
}
