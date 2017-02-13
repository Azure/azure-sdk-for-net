// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Microsoft.Azure.Common.Authentication
{
    /// <summary>
    /// An implementation of <see cref="IWin32Window"/> that gives the
    /// windows handle for the current console window.
    /// </summary>
    public class ConsoleParentWindow : IWin32Window
    {
        public IntPtr Handle { get { return NativeMethods.GetConsoleWindow(); } }

        static class NativeMethods
        {
            [DllImport("kernel32.dll")]
            public static extern IntPtr GetConsoleWindow();
        }
    }
}
