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
        private readonly JobPlanFileName _planFile;
        /// <summary>
        /// Constructor.
        /// </summary>
        public PlanFileReader(string name)
        {
            // Resolve the given path to an absolute path in case it isn't one already
            _planFile = new JobPlanFileName(name);
        }

        public static JobPartPlanHeader ReadPlanFile()
        {
            throw new Exception();
        }
    }
}
