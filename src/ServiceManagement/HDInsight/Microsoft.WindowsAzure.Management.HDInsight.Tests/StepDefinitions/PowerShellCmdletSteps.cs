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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.StepDefinitions
{
    using System.Management.Automation;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;

    [Binding]
    public class PowerShellCmdletSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [Given(@"I have installed the AzureHDInsight Cmdlets")]
        public void DoNothing()
        {
            // Do NOTHING, this is simply to provide the Gherkin Syntax.
        }

        [When(@"I lists the available CmdLets")]
        // Okay, we technically don't list all the Cmdlets installed on the system.
        // We only care about the ones linked into the test.
        public void WhenIListsTheAvailableCmdLets()
        {
            this.LocateCmdlets();
        }

        private class CmdletHouse
        {
            public CmdletHouse()
            {
                this.ParameterSets = new Dictionary<string, ICollection<ParameterHouse>>();
            }
            public Type Type { get; set; }
            public IDictionary<string, ICollection<ParameterHouse>> ParameterSets { get; private set; }
        }

        private class ParameterHouse
        {
            public ParameterHouse()
            {
                this.Aliases = new List<string>();
            }
            public PropertyInfo Property { get; set; }
            public string FullName { get; set; }
            public ParameterAttribute Parameter { get; set; }
            public ICollection<string> Aliases { get; private set; }
        }

        private Dictionary<string, CmdletHouse> LocateCmdlets()
        {
            Dictionary<string, CmdletHouse> cmdlets;
            if (!ScenarioContext.Current.TryGetValue(CmdTestingConstants.Cmdlets, out cmdlets))
            {
                cmdlets = new Dictionary<string, CmdletHouse>();
                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    foreach (var type in assembly.GetTypes())
                    {
                        if (typeof(Cmdlet).IsAssignableFrom(type))
                        {
                            var cmdletAttribute = type.GetCustomAttribute(typeof(CmdletAttribute)).As<CmdletAttribute>();
                            if (cmdletAttribute.IsNotNull())
                            {
                                string verb = cmdletAttribute.VerbName;
                                string noun = cmdletAttribute.NounName;
                                string name = verb + "-" + noun;
                                var cmdletHouse = new CmdletHouse() { Type = type };
                                cmdlets.Add(name, cmdletHouse);

                                // Locate all the parameter sets.
                                foreach (var propertyInfo in type.GetProperties())
                                {
                                    var aliases = new List<string>();
                                    // Get all the Aliases
                                    var paramAliases = propertyInfo.GetCustomAttributes(typeof(AliasAttribute)).Cast<AliasAttribute>();
                                    if (paramAliases.Any())
                                    {
                                        aliases.AddRange(paramAliases.SelectMany(a => a.AliasNames));
                                    }
                                    // Get all the ParameterAttributes
                                    var paramAttribs = propertyInfo.GetCustomAttributes(typeof(ParameterAttribute)).Cast<ParameterAttribute>();
                                    if (paramAttribs.Any())
                                    {
                                        foreach (var paramAttrib in paramAttribs)
                                        {
                                            var parameterSet = paramAttrib.ParameterSetName;
                                            var parameterHouse = new ParameterHouse()
                                            {
                                                FullName = propertyInfo.Name,
                                                Property = propertyInfo,
                                                Parameter = paramAttrib,
                                            };
                                            parameterHouse.Aliases.AddRange(aliases);
                                            ICollection<ParameterHouse> parameters;
                                            if (!cmdletHouse.ParameterSets.TryGetValue(parameterSet, out parameters))
                                            {
                                                parameters = new List<ParameterHouse>();
                                                cmdletHouse.ParameterSets.Add(parameterSet, parameters);
                                            }
                                            parameters.Add(parameterHouse);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                ScenarioContext.Current.Add(CmdTestingConstants.Cmdlets, cmdlets);
            }
            return cmdlets;
        }

        private static class CmdTestingConstants
        {
            public const string Cmdlets = "Cmdlets";
            public const string TestingCmdlet = "TestingCmdlet";
            public const string TestingParameterSet = "TestingParameterSet";
            public const string TestingParameter = "TestingParameter";
            public const string TestedParameterSet = "TestedParameterSet";
            public const string TestedParameters = "TestedParameters";
        }

        [Then(@"There exists a ""(.*)"" PowerShell Cmdlet")]
        public void ThenThereExistsAGet_AzureHDInsightClusterPowerShellCmdlet(string cmdletName)
        {
            var cmdlets = this.LocateCmdlets();
            Assert.IsTrue(cmdlets.ContainsKey(cmdletName), "The requested Cmdlet '{0}' was not found", cmdletName);
        }

        [Given(@"I am using the ""(.*)"" PowerShell Cmdlet")]
        [When(@"I am using the ""(.*)"" PowerShell Cmdlet")]
        public void GivenIAmUsingTheGet_AzureHDInsightClusterPowerShellCmdlet(string cmdletName)
        {
            var cmdlets = this.LocateCmdlets();
            Assert.IsTrue(cmdlets.ContainsKey(cmdletName), "The requested Cmdlet '{0}' was not found", cmdletName);
            ScenarioContext.Current[CmdTestingConstants.TestingCmdlet] = this.LocateCmdlets()[cmdletName];
        }

        [When(@"I am using the ""(.*)"" parameter set")]
        public void WhenIAmUsingTheParameterSet(string parameterSet)
        {
            this.SetTestingParameterSet(parameterSet);
        }

        [Then(@"there exists a ""(.*)"" parameter set")]
        public void ThenThereExistsAParameterSet(string parameterSetName)
        {
            this.SetTestingParameterSet(parameterSetName);
        }

        [Then(@"no parameter in the set shares the same position with another parameter from the set")]
        public void ThenNoParameterInTheSetSharesTheSamePositionWithAnotherParameterFromTheSet()
        {
            var parameterSet = this.GetTestingParameterSet();
            Dictionary<int, ParameterHouse> parameters = new Dictionary<int, ParameterHouse>();
            foreach (var parameterHouse in parameterSet)
            {
                if (parameterHouse.Parameter.Position != int.MinValue)
                {
                    if (!parameters.ContainsKey(parameterHouse.Parameter.Position))
                    {
                        parameters.Add(parameterHouse.Parameter.Position,
                                       parameterHouse);
                    }
                    else
                    {
                        var usedParameter = parameters[parameterHouse.Parameter.Position];
                        Assert.Fail("The position '{0}' was attempted to be used by parameter '{1}' but was already used by parameter '{2}'",
                                    parameterHouse.Parameter.Position, 
                                    parameterHouse.FullName, 
                                    usedParameter.FullName);
                    }
                }
            }
        }

        [Then(@"only one parameter in the set is set to take its value from the pipeline")]
        public void ThenOnlyOneParameterInTheSetIsSetToTakeItsValueFromThePipeline()
        {
            var parameterSet = this.GetTestingParameterSet();
            ParameterHouse valueFromPipeline = null;
            foreach (var parameterHouse in parameterSet)
            {
                if (parameterHouse.Parameter.ValueFromPipeline)
                {
                    if (valueFromPipeline.IsNotNull())
                    {
                        Assert.Fail("The parameter '{0}' is attempting to accept its value from the pipeline for this parameter set but the parameter '{1}' has already done so.",
                                    parameterHouse.FullName, 
                                    valueFromPipeline.FullName);
                    }
                    else
                    {
                        valueFromPipeline = parameterHouse;
                    }
                }
            }
        }

        [Then(@"no parameter lacks either a Getter or a Setter")]
        public void ThenNoParameterLacksEitherAGetterOrASetter()
        {
            var cmdlet = this.GetTestingCmdlet();
            foreach (var parameterSet in cmdlet.ParameterSets)
            {
                foreach (var parameterHouse in parameterSet.Value)
                {
                    Assert.IsTrue(parameterHouse.Property.GetMethod.IsNotNull(),
                                  "The parameter '{0}' lacks a getter", 
                                  parameterHouse.FullName);
                    Assert.IsTrue(parameterHouse.Property.SetMethod.IsNotNull(),
                                  "The parameter '{0}' lacks a setter",
                                  parameterHouse.FullName);
                }
            }
        }

        [Then(@"no parameter in any parameter set shares a name or alias with another parameter")]
        public void ThenNoParameterInAnyParameterSetSharesANameOrAliasWithAnotherParameter()
        {
            var cmdlet = this.GetTestingCmdlet();
            Dictionary<string, ParameterHouse> parameters = new Dictionary<string, ParameterHouse>(StringComparer.OrdinalIgnoreCase);
            Dictionary<string, ParameterHouse> nameUsages = new Dictionary<string, ParameterHouse>(StringComparer.OrdinalIgnoreCase);
            
            foreach (var parameterSet in cmdlet.ParameterSets)
            {
                foreach (var parameterHouse in parameterSet.Value)
                {
                    if (!parameters.ContainsKey(parameterHouse.FullName))
                    {
                        parameters.Add(parameterHouse.FullName, parameterHouse);
                    }
                }
            }

            foreach (var parameterHouse in parameters.Values)
            {
                if (!nameUsages.ContainsKey(parameterHouse.FullName))
                {
                    foreach (var alias in parameterHouse.Aliases)
                    {
                        if (!nameUsages.ContainsKey(alias))
                        {
                            nameUsages.Add(alias,
                                           parameterHouse);
                        }
                        else
                        {
                            var usedFirst = nameUsages[alias];
                            Assert.Fail("The Alias '{0}' of the parameter '{1}' was already utilized by the parameter '{2}' as a name or alias.",
                                        alias,
                                        parameterHouse.FullName,
                                        usedFirst.FullName);
                        }
                    }
                }
                else
                {
                    var usedFirst = nameUsages[parameterHouse.FullName];
                    Assert.Fail("The parameter name '{0}' was already utilized by the parameter '{1}' as an alias.",
                                parameterHouse.FullName,
                                usedFirst.FullName);
                }
            }
        }

        [Then(@"there are no additional parameters in the parameter set")]
        public void ThenThereAreNoAdditionalParametersInTheParameterSet()
        {
            var parameterSet = this.GetTestingParameterSet();
            Assert.IsTrue(ScenarioContext.Current.ContainsKey(CmdTestingConstants.TestedParameters),
                          "No parameters appear to have been tested.  Did you forget to test the existence of at least one parameter.");
            var tested = ScenarioContext.Current[CmdTestingConstants.TestedParameters].As<IEnumerable<string>>();

            var q = (from l in parameterSet.Select(h => h.FullName)
                     join r in tested
                       on l equals r
                     into outer
                     from o in outer.DefaultIfEmpty()
                     where o.IsNull()
                     select l);
            string msg = string.Format("The test specifies that there should be no additional parameters in this parameter set however {0} additional parameters where found.  The following parameter names where found \"{1}\".",
                                       q.Count(), 
                                       string.Join(",", q.Select(s => "'" + s + "'")));
            Assert.AreEqual(0, q.Count(), msg);
        }

        [Then(@"there exists no further parameter sets")]
        public void ThenThereExistsNoFurtherParameterSets()
        {
            var cmdlet = this.GetTestingCmdlet();
            Assert.IsTrue(ScenarioContext.Current.ContainsKey(CmdTestingConstants.TestedParameterSet),
                          "No parameter sets appear to have been tested.  Did you forget to test the existence of at least one parameter set.");
            var tested = ScenarioContext.Current[CmdTestingConstants.TestedParameterSet].As<IEnumerable<string>>();
            
            var q = (from l in cmdlet.ParameterSets.Keys
                     join r in tested
                       on l equals r
                     into outer
                     from o in outer.DefaultIfEmpty()
                    where o.IsNull()
                   select l); 
            string msg = string.Format("The test specifies that there should be no additional parameter sets however {0} additional sets where found.  The following parameter set names where found \"{1}\".", 
                                       q.Count(), 
                                       string.Join(",", q.Select(s => "'" + s + "'")));
            Assert.AreEqual(0, q.Count(), msg);
        }

        private CmdletHouse GetTestingCmdlet()
        {
            Assert.IsTrue(ScenarioContext.Current.ContainsKey(CmdTestingConstants.TestingCmdlet),
                          "There is no Cmdlet currently being tested.  Did you forget to specify that you were using a Cmdlet?");
            var testingCmdlet = ScenarioContext.Current[CmdTestingConstants.TestingCmdlet].As<CmdletHouse>();
            return testingCmdlet;
        }

        private IEnumerable<ParameterHouse> FindParameterSet(string parameterSetName)
        {
            var testingCmdlet = this.GetTestingCmdlet();
            Assert.IsTrue(testingCmdlet.ParameterSets.ContainsKey(parameterSetName), "The specified parameter set '{0}' could not be found", parameterSetName);
            var parameterSet = testingCmdlet.ParameterSets[parameterSetName].As<IEnumerable<ParameterHouse>>();
            return parameterSet;
        }

        private void SetTestingParameterSet(string parameterSetName)
        {
            var parameterSet = this.FindParameterSet(parameterSetName);
            ScenarioContext.Current[CmdTestingConstants.TestingParameterSet] = parameterSet;
            ICollection<string> testedParameterSets;
            if (!ScenarioContext.Current.TryGetValue(CmdTestingConstants.TestedParameterSet,
                                                     out testedParameterSets))
            {
                testedParameterSets = new List<string>();
                ScenarioContext.Current.Add(CmdTestingConstants.TestedParameterSet,
                                            testedParameterSets);
            }
            testedParameterSets.Add(parameterSetName);
        }

        private void SetTestingParameter(string parameterName)
        {
            var testingParameterSet = this.GetTestingParameterSet();
            var testingParameter = testingParameterSet.FirstOrDefault(p => p.FullName == parameterName);
            Assert.IsNotNull(testingParameter,
                             "The specified parameter '{0}' was not found.", 
                             parameterName);
            ScenarioContext.Current[CmdTestingConstants.TestingParameter] = testingParameter;
            ICollection<string> testedParameters;
            if (!ScenarioContext.Current.TryGetValue(CmdTestingConstants.TestedParameters,
                                                     out testedParameters))
            {
                testedParameters = new List<string>();
                ScenarioContext.Current.Add(CmdTestingConstants.TestedParameters,
                                            testedParameters);
            }
            testedParameters.Add(parameterName);
        }

        private IEnumerable<ParameterHouse> GetTestingParameterSet()
        {
            Assert.IsTrue(ScenarioContext.Current.ContainsKey(CmdTestingConstants.TestingParameterSet),
                          "There is no ParameterSet being tested.  Did you forget to specify that you were using a parameter set?");
            var testingParameterSet = ScenarioContext.Current[CmdTestingConstants.TestingParameterSet].As<IEnumerable<ParameterHouse>>();
            return testingParameterSet;
        }
            
        [Then(@"there exists a ""(.*)"" Cmdlet parameter")]
        public void ThenThereExistsASubscriptionIdCmdletParameter(string parameterName)
        {
            this.SetTestingParameter(parameterName);
        }

        private ParameterHouse GetTestingParameter()
        {
            Assert.IsTrue(ScenarioContext.Current.ContainsKey(CmdTestingConstants.TestingParameter),
                          "There is no Parameter being tested.  Did you forget to specify that you were using a parameter?");
            var parameter = ScenarioContext.Current[CmdTestingConstants.TestingParameter].As<ParameterHouse>();
            return parameter;
        }

        [Then(@"it is (a required|an optional) parameter")]
        public void ThenItIsARequiredParameter(string requiredOrOptional)
        {
            var parameter = this.GetTestingParameter();
            if (requiredOrOptional == "a required")
            {
                Assert.IsTrue(parameter.Parameter.Mandatory,
                              "The parameter '{0}' for this parameter set is not specified as required.", 
                              parameter.FullName);
            }
            else
            {
                Assert.IsFalse(parameter.Parameter.Mandatory,
                               "The parameter '{0}' for this parameter set is not specified as optional.", 
                               parameter.FullName);
            }
        }

        [Then(@"it is specified as parameter (.*)")]
        public void ThenItItSpecifiedAsParameter(int position)
        {
            var parameter = this.GetTestingParameter();
            if (parameter.Parameter.Position == int.MinValue)
            {
                Assert.AreEqual(position, 
                                parameter.Parameter.Position,
                                "The parameter '{0}' for this parameter set is not in the specified position of '{1}', it instead does not specify a position.",
                                parameter.FullName, 
                                position);
            }
            Assert.AreEqual(position, 
                            parameter.Parameter.Position, 
                            "The parameter '{0}' for this parameter set is not in the specified position of '{1}', it is instead in the position '{2}'",
                            parameter.FullName, 
                            position, 
                            parameter.Parameter.Position);
        }

        [Then(@"it is of type ""(.*)""")]
        public void ThenItIsOfType(string typeName)
        {
            var parameter = this.GetTestingParameter();
            Assert.AreEqual(typeName,
                            parameter.Property.PropertyType.Name,
                            "The parameter was suppose to be of type '{0}' but is actually of type '{1}'",
                            typeName,
                            parameter.Property.PropertyType.Name);
        }

        [Then(@"it (can not|can) take its value from the pipeline")]
        public void ThenItItIsCanNotTakeItsValueFromThePipeline(string canOrCanNot)
        {
            var parameter = this.GetTestingParameter();
            if (canOrCanNot == "can")
            {
                Assert.IsTrue(parameter.Parameter.ValueFromPipeline,
                              "The parameter '{0}' for this parameter set can not take it's value from the pipeline.", 
                              parameter.FullName);
            }
            else
            {
                Assert.IsFalse(parameter.Parameter.ValueFromPipeline,
                               "The parameter '{0}' for this parameter set can take it's value from the pipeline.", 
                               parameter.FullName);
            }
        }
    }
}
