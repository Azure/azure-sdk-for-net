// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Method to get system directory. This method has been added to .NET Standard 2.0, but since we target 1.4, need to write it. 
    /// Gets the system directory to get the install path for Azure CLI. 
    /// </summary>
    internal class EnvironmentHelper
    {
#if netstandard14
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = false)]
        static extern int GetSystemDirectoryW([Out] StringBuilder lpBuffer, int jSize);

        const int MaxShortPath = 260;
        
        public static string SystemDirectory
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (GetSystemDirectoryW(sb, MaxShortPath) == 0)
                {
                    throw new Exception("Unable to get system directory");
                }
                return sb.ToString();
            }
        }
#endif
    }
}
