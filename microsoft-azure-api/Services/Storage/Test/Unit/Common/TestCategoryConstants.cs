// -----------------------------------------------------------------------------------------
// <copyright file="TestCategoryConstants.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

// -----------------------------------------------------------------------------------------
// <copyright file="TestCategoryConstants.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

using System;

namespace Microsoft.WindowsAzure.Storage
{
    public class ComponentCategory
    {
        public const string Auth = "Auth";

        public const string Core = "Core";

        public const string RetryPolicies = "RetryPolicies";

        public const string Blob = "Blob";

        public const string Queue = "Queue";

        public const string Table = "Table";
    }

    public class TestTypeCategory
    {
        public const string UnitTest = "UnitTest";

        public const string FuntionalTest = "FuntionalTest";

        public const string StressTest = "StressTest";
    }

    public class SmokeTestCategory
    {
        public const string Smoke = "Smoke";

        public const string NonSmoke = "NonSmoke";
    }

    public class TenantTypeCategory
    {
        public const string DevStore = "DevStore";

        public const string DevFabric = "DevFabric";

        public const string Cloud = "Cloud";
    }
}
