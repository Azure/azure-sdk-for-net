// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Azure.Storage.DataMovement
{
    internal class PlanFileReader
    {
        private readonly string _planFilePath;
        /// <summary>
        /// Constructor.
        /// </summary>
        public PlanFileReader(string planFolderPath)
        {
            // Resolve the given path to an absolute path in case it isn't one already
            _planFilePath = Path.GetFullPath(planFolderPath);
        }

        public static JobPartPlanHeader ReadPlanFile()
        {
            throw new Exception();
        }
    }
}
