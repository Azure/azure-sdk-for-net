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
