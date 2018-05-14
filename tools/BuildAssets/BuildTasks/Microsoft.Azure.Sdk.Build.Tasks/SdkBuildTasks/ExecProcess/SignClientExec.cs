// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.ExecProcess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SignClientExec : ShellExec
    {
        //ESRPClient sign ​-a c:/somefolder/auth.json, -c c:/somefolder/config.json -p c:/somefolder/policy.json -i c:/somefolder/input.json -o c:/somefolder/output.json

        public string AuthConfigArg { get; set; }

        public string ConfigArg { get; set; }

        public string PolicyConfigArg { get; set; }

        public string InputArg { get; set; }

        public string OutputArg { get; set; }

        public SignClientExec()
        {

        }

        

        private void BuildClientCmdLine()
        {

        }
    }
}
