// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Automation.Tests.Helpers
{
    public class DscConfigurationDefinition
    {
        public DscConfigurationDefinition(string configName, string psScript, string description,
            string contentHashValue, string contentHashAlgorithm, string contentType)
        {
            ConfigurationName = configName;
            PsScript = psScript;
            Description = description;
            ContentHashValue = contentHashValue;
            ContentHashAlgorithm = contentHashAlgorithm;
            ContentType = contentType;
        }

        public string ContentType { get; set; }

        public string ContentHashAlgorithm { get; set; }

        public string ContentHashValue { get; set; }

        public string Description { get; set; }

        public string PsScript { get; }

        public string ConfigurationName { get; }

        public static DscConfigurationDefinition TestSimpleConfigurationDefinition = new DscConfigurationDefinition(
            "SampleConfiguration", @"Configuration SampleConfiguration {
    Node SampleConfiguration.localhost {
        WindowsFeature IIS {
            Name = ""Web - Server"";
        Ensure = ""Present""; 
}}}", "sample configuration test", "A9E5DB56BA21513F61E0B3868816FDC6D4DF5131F5617D7FF0D769674BD5072F", "sha256", "embeddedContent");
    }
}