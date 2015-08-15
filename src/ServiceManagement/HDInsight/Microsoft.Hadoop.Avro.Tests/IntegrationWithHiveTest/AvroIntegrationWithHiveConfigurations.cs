// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Avro.Tests
{
    internal sealed class AvroIntegrationWithHiveConfigurations
    {
        public const int AvroBlockSize = 5;
        public const string HiveExtraTableName = "avrolargeclassextratbl";
        public const string HiveTableName = "avrolargeclasstbl";
        public const int NumberOfAvroRecords = 100;
        public const string QueryResultFolder = "avrolargeclassqueryfolder";
        public const string TestRootDirectory = "avrohiveintegrationtest";
    }
}
