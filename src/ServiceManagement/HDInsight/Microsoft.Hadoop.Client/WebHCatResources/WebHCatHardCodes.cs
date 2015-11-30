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
namespace Microsoft.Hadoop.Client.WebHCatResources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal static class WebHCatConstants
    {
        internal const string Jar = "jar";
        internal const string Execute = "execute";
        internal const string Command = "command";
        internal const string File = "file";
        internal const string Class = "class";
        internal const string StatusDirectory = "statusdir";
        internal const string Arg = "arg";
        internal const string Files = "files";
        internal const string LibJars = "libjars";
        internal const string UserName = "user.name";
        internal const string CmdEnv = "cmdenv";
        internal const string Define = "define";
        internal const string DefineJobName = "hdInsightJobName";
        internal const string FormUrlEncoded = "application/x-www-form-urlencoded";
        internal const string Input = "input";
        internal const string Output = "output";
        internal const string Mapper = "mapper";
        internal const string Reducer = "reducer";
        internal const string Combiner = "combiner";
        internal const string Callback = "callback";

        internal static string[] GetRestrictedCharactersInQuery()
        {
            return new string[]
            {
                "%",
                "\r",
                "\n"
            };
        }
    }
}
