// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace StorSimple1200Series.Tests
{
    using System;

    using Microsoft.Azure.Management.StorSimple1200Series;
    using Microsoft.Azure.Management.StorSimple1200Series.Models;

    public static partial class TestUtilities
    {
        #region Extension methods

        #region string
        public static string GetDoubleEncoded(this string input)
        {
            return Uri.EscapeDataString(Uri.EscapeDataString(input));
        }

        #endregion string

        #endregion Extension methods

        #region Private methods

        private static void SetBaseResourceValues(
            this BaseModel baseModel, 
            StorSimpleManagementClient client,
            string resourceGroupName, 
            string managerName)
        {
            baseModel.Client = client;
            baseModel.ResourceGroupName = resourceGroupName;
            baseModel.ManagerName = managerName;
        }
        #endregion
    }
}
