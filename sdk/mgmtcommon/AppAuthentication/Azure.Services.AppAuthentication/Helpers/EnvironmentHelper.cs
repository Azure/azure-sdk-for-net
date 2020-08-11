// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Method to get system directory. This method has been added to .NET Standard 2.0, but since we target 1.4, need to write it. 
    /// Gets the system directory to get the install path for Azure CLI. 
    /// </summary>
    internal class EnvironmentHelper
    {
#if !FullNetFx
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = false)]
        static extern int GetSystemDirectoryW([Out] StringBuilder lpBuffer, int jSize);

        const int MaxShortPath = 260;
#endif

        public static string SystemDirectory
        {
            get
            {
#if !FullNetFx
                StringBuilder sb = new StringBuilder();
                if (GetSystemDirectoryW(sb, MaxShortPath) == 0)
                {
                    throw new Exception("Unable to get system directory");
                }
                return sb.ToString();
#else
                return Environment.SystemDirectory;
#endif
            }
        }

        /// <summary>
        /// Method to get environment variable value. For supported frameworks, the method looks in both process and machine target locations.
        /// </summary>
        internal static string GetEnvironmentVariable(string variable)
        {
            string value;

#if FullNetFx || NETSTANDARD2_0
            value = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process);
            if (string.IsNullOrWhiteSpace(value))
            {
                value = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Machine);
            }
#else
            value = Environment.GetEnvironmentVariable(variable);
#endif

            return value;
        }
    }
}
