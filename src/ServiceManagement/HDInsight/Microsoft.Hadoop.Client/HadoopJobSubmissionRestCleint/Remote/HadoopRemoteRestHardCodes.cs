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
namespace Microsoft.Hadoop.Client.WebHCatRest
{
    internal static class HadoopRemoteRestConstants
    {
        //NIEN: we should really think about setting this up as a cascade (IE Jobs is TempeltonV1 + "/Jobs"). 
        //      we should also consider the versioning aspects of this.. perhaps the classname should change to HadoopRemoteRestV1HardCodes?
        internal const string Jobs = "templeton/v1/jobs";
        internal const string UserName = "user.name";
        internal const string ShowAllFields = "fields=*";
        internal const string Authorization = "Authorization";
        internal const string TempletonV1 = "templeton/v1/";
        internal const string Hive = "templeton/v1/hive";
        internal const string Pig = "templeton/v1/pig";
        internal const string Sqoop = "templeton/v1/sqoop";
        internal const string MapReduceJar = "templeton/v1/mapreduce/jar";
        internal const string MapReduceStreaming = "templeton/v1/mapreduce/streaming";
        internal const string EnableLogging = "enablelog";
    }
}