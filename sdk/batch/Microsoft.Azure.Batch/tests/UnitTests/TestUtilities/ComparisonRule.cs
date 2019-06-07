// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
