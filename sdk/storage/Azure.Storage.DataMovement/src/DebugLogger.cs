// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    internal static class DebugLogger
    {
        public static void Log(string message)
        {
            int logCount = 1;
            string _logPath = $"C:\\Users\\amnguye\\OneDrive - Microsoft\\Documents\\Debug_Logs\\debug{logCount}.log";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(_logPath, true))
            {
                file.WriteLine(message);
            }
        }
    }
}
