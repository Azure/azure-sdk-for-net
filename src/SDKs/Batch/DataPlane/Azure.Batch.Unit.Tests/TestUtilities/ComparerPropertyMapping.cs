// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Azure.Batch.Unit.Tests.TestUtilities
{
    using System;

    public class ComparerPropertyMapping
    {
        public Type Type1 { get; private set; }

        public Type Type2 { get; private set; }

        public string Property1Name { get; private set; }

        public string Property2Name { get; private set; }

        public ComparerPropertyMapping(Type type1, Type type2, string property1Name, string property2Name)
        {
            this.Type1 = type1;
            this.Type2 = type2;
            this.Property1Name = property1Name;
            this.Property2Name = property2Name;
        }

        /// <summary>
        /// Returns the name of the other property if a match was found, otherwise returns null.
        /// </summary>
        /// <returns>the name of the other property if a match was found, otherwise returns null.</returns>
        public string FindMatch(Type t, string propertyName)
        {
            if (this.Type1 == t && string.Equals(this.Property1Name, propertyName))
            {
                return this.Property2Name;
            }
            else if (this.Type2 == t && string.Equals(this.Property2Name, propertyName))
            {
                return this.Property1Name;
            }

            return null;
        }
    }
}
