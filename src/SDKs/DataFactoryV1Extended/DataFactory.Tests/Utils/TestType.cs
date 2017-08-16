// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace DataFactory.Tests.Utils
{
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

        #endregion
    }
}
