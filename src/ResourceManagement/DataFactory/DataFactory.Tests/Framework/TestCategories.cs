// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

namespace DataFactory.Tests.Framework
{
    public static class TraitName
    {
        public const string TestType = "Type";
        public const string Function = "Function";
    }

    public static class TestType
    {
        // Tests must belong to exactly one of these categories 
        #region Disjoint Required categories

        public const string Unit = "Unit";
        public const string Scenario = "Scenario";

        #endregion

        // Tests may additionally belong to one or more of these categories
        #region Other categories

        public const string Conversion = "Conversion";
        public const string Registration = "Registration";

        #endregion
    }
}
