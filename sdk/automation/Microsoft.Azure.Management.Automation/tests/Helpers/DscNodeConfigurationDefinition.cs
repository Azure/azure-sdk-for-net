// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Automation.Tests.Helpers
{
    public class DscNodeConfigurationDefinition
    {
        public DscNodeConfigurationDefinition(string configName, string nodeConfigName, string nodeConfigurationContent,
            string contentHashValue, string contentHashAlgorithm = null, string contentType = null, string contentVersion = null)
        {
            ConfigurationName = configName;
            NodeConfigurationName = nodeConfigName;
            NodeConfigurationContent = nodeConfigurationContent;
            ContentHashValue = contentHashValue;
            ContentHashAlgorithm = contentHashAlgorithm;
            ContentType = contentType;
            ContentVersion = contentVersion;
        }

        public string ConfigurationName { get; set; }

        public string ContentVersion { get; set; }

        public string ContentType { get; set; }

        public string ContentHashAlgorithm { get; set; }

        public string ContentHashValue { get; set; }

        public string NodeConfigurationContent { get; }

        public string NodeConfigurationName { get; }

        public static DscNodeConfigurationDefinition TestSimpleConfigurationDefinition = new DscNodeConfigurationDefinition(
            "SampleConfiguration",
            "SampleConfiguration.localhost", 
            @"instance of MSFT_RoleResource as $MSFT_RoleResource1ref
{
    ResourceID = ""[WindowsFeature]IIS"";
    Ensure = ""Present"";
    SourceInfo = ""::3::32::WindowsFeature"";
    Name = ""Web-Server""; 
    ModuleName = ""PsDesiredStateConfiguration"";
    ModuleVersion = ""1.0"";
    ConfigurationName = ""SampleConfiguration"";
};

instance of OMI_ConfigurationDocument
{
    Version=""2.0.0"";
    MinimumCompatibleVersion = ""1.0.0"";
    CompatibleVersionAdditionalProperties= {""Omi_BaseResource:ConfigurationName""};
    Author=""vameru"";
    GenerationDate=""03/30/2017 13:40:25"";
    GenerationHost=""VAMERU-BACKEND"";
    Name=""SampleConfiguration"";
};", 
            "6DE256A57F01BFA29B88696D5E77A383D6E61484C7686E8DB955FA10ACE9FFE5", 
            "sha256", 
            "embeddedContent", 
            "1.0");

    }
}
