// -----------------------------------------------------------------------------------------
// <copyright file="TableTestBase.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

using System;
using System.Text;

namespace Microsoft.WindowsAzure.Storage.Table
{
    public class TableTestBase : TestBase
    {
        public static string GenerateRandomTableName()
        {
            return "tbl" + Guid.NewGuid().ToString().Replace("-", "");
        }

        /*
        public static async void CleanupTables()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            try
            {
                IEnumerable<CloudTable> tables = tableClient.ListTables();
                foreach (CloudTable table in tables)
                {
                    await table.DeleteAsync();
                }
            }
            catch (Exception)
            {
            }
        }*/

        public static string GenerateRandomStringFromCharset(int TableNameLength, string LegalChars, Random rand)
        {
            StringBuilder retString = new StringBuilder();
            for (int n = 0; n < TableNameLength; n++)
            {
                retString.Append(LegalChars[rand.Next(LegalChars.Length - 1)]);
            }

            return retString.ToString();
        }
    }
}
