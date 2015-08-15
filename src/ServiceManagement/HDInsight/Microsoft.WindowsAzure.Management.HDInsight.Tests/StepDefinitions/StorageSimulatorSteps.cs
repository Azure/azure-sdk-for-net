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
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.StepDefinitions
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.Storage;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using TechTalk.SpecFlow;

    [Binding]
    public class StorageSimulatorSteps
    {
        private Exception exception;
        private IStorageAbstraction abstraction;
        private IEnumerable<Uri> list;
        private string data;
        private bool? found;
            
        [Given(@"I (apply|don't apply) storage abstraction simulation")]
        public void GivenIApplyOrDoNotApplyStorageAccountSimulation(string applyOrNot)
        {
            if (applyOrNot.Equals("don't apply", StringComparison.OrdinalIgnoreCase))
            {
                var manager = ServiceLocator.Instance.Locate<IServiceLocationSimulationManager>();
                manager.MockingLevel = ServiceLocationMockingLevel.ApplyIndividualTestMockingOnly;
            }
        }

        [Given(@"I have the Windows Azure Blob storage abstraction for the account '(.*)'")]
        public void GivenIHaveTheStorageAbstraction(string account)
        {
            account = Constants.WabsProtocolSchemeName + account;
            var factory = ServiceLocator.Instance.Locate<IWabStorageAbstractionFactory>();
            // NOTE: when run against production we should pull the key out of the valid creds file.
            var creds = new WindowsAzureStorageAccountCredentials() { Name = account, Key = string.Empty };
            abstraction = factory.Create(creds);
        }

        [When(@"I try to delete the path '(.*)'")]
        public void WhenITryToDeleteTheContainer(string path)
        {
            path = path.Replace("wabs", Constants.WabsProtocol);
            try
            {
                this.abstraction.Delete(new Uri(path));
            }
            catch (Exception ex)
            {
                this.exception = ex;
            }
        }

        [Then(@"a(?:n) '(.*)' is thrown containing the message '(.*)'")]
        public void ThenA_type_ExecptionIsThrownContainingTheMessage_msg(string type, string msg)
        {
            Assert.IsNotNull(exception, "The test expcected an exception but none was thrown.");
            Assert.AreEqual(this.exception.GetType().Name, 
                            type, 
                            "The exception was expected to be of type '{0}' but instead was of type '{1}' : {2}.", 
                            type, 
                            this.exception.GetType().Name,
                            this.exception);
            Assert.IsTrue(this.exception.Message.Contains(msg),
                          "The exception was expected to contain the string '{0}' as part of it's message but was instead '{1}'",
                          msg,
                          this.exception.Message);
        }

        [When(@"I read the data from the path '(.*)'")]
        public void WhenIReadTheDataFromThePath_path(string path)
        {
            path = path.Replace("wabs", Constants.WabsProtocol);
            Uri uri = new Uri(path);
            try
            {
                using (var stream = this.abstraction.Read(uri).WaitForResult())
                using (var reader = new StreamReader(stream))
                {
                    this.data = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                this.exception = ex;
            }
        }

        [When(@"I write the data ""(.*)"" to the path '(.*)'")]
        public void WhenIWriteData_data_ToTheItem_path(string data, string location)
        {
            location = location.Replace("wabs", Constants.WabsProtocol);
            Uri uri = new Uri(location);
            try
            {
                using (var stream = new MemoryStream())
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(data);
                    writer.Flush();
                    stream.Flush();
                    stream.Position = 0;
                    this.abstraction.Write(uri, stream);
                }
            }
            catch (Exception ex)
            {
                this.exception = ex;
            }
        }

        [When(@"I check existence of the path '(.*)'")]
        public void WhenICheckExistenceOfThePath(string path)
        {
            path = path.Replace("wabs", Constants.WabsProtocol);
            this.found = this.abstraction.Exists(new Uri(path)).WaitForResult();
        }

        [When(@"I list the items under the path '(.*)'((?: recursively)?)")]
        public void WhenIListTheItemsUnderThepath_path(string path, string recursively)
        {
            path = path.Replace("wabs", Constants.WabsProtocol);
            this.list = this.abstraction.List(new Uri(path), recursively.IsNotNullOrEmpty()).WaitForResult();
        }

        [Then(@"the number of items returned should be (\d+)")]
        public void ThenTheNumberOfItemsReturnedSHouldBe_count(int count)
        {
            Assert.IsNotNull(this.list,
                             "The test expected {0} items to be returned but instead a null result was returned",
                             count);
            Assert.AreEqual(count, 
                            this.list.Count(), 
                            "The test expected {0} items to be returned but instead {1} were returned.",
                            count,
                            this.list.Count());
        }

        [Then(@"no error should be returned from the storage abstraction")]
        public void ThenNoErrorIsReturnedFromTheStorageAbstraction()
        {
            Assert.IsNull(exception, "No exception was expected but instead the following exception was returned: {0}", this.exception);
        }

        [Then(@"the existence check should return (false|true)")]
        public void ThenTheExistenceCheckShouldReturn_falseOrTrue(bool check)
        {
            Assert.IsNotNull(this.found, "An existence check was expected but none was performed");
            Assert.AreEqual(check,
                            this.found.Value,
                            "The existence check expected to return {0} but instead returned {1}",
                            check,
                            this.found.Value);
        }

        [Then(@"the value of the data should be ""(.*)""")]
        public void ThenTheValueOfTheDataShouldBe(string data)
        {
            Assert.AreEqual(data,
                            this.data,
                            "The data returned was expected to be \"{0}\" but instead was \"{1}\"",
                            data,
                            this.data);
        }
    }
}
