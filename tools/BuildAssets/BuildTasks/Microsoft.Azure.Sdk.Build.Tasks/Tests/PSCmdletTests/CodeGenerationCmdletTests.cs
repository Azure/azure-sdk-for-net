using System;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Xunit;

namespace PSCmdLets.Tests
{
    public class CodeGenerationCmdletTests
    {
        static String scriptsPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), @"TestAssets\SampleRepo\src\SDKs\Compute\Management.Compute");
        static String genDir = new Uri(Path.Combine(scriptsPath, "Generated")).AbsolutePath;
        static String azureStackScriptPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), @"TestAssets\SampleRepo\src\AzureStack\AzureAdmin\");
        static String azureStackGenDir = new Uri(Path.Combine(azureStackScriptPath, "Generated")).AbsolutePath;
        static String metadataDir = new Uri(Path.Combine(scriptsPath, @"..\..\_metadata")).AbsolutePath;

        [Fact]
        public void BasicCodeGenerationWithDefaultGenDirectoryScenario()
        {
            try
            {
                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    PowerShellInstance.AddScript("powershell.exe -ExecutionPolicy Bypass -File " + new Uri(Path.Combine(scriptsPath, "test1.ps1")).AbsolutePath);
                    var result = PowerShellInstance.Invoke();
                    Assert.NotEmpty(result);
                    Assert.Empty(PowerShellInstance.Streams.Error);
                    Assert.True(Directory.Exists(genDir));
                    Assert.NotEmpty(Directory.GetFiles(genDir));
                    Assert.True(Directory.Exists(metadataDir));
                    // Check if metadata correctly generated
                    var sdkInfoFile = (new Uri(Path.Combine(genDir, "SdkInfo_ComputeManagementClient.cs"))).AbsolutePath;
                    Assert.True(File.Exists(sdkInfoFile));
                    String txt = File.ReadAllText(sdkInfoFile);
                    var regex = new Regex(@"(.*)\/\/ BEGIN: Code Generation Metadata Section(?<metadata>\n|.)*\/\/ END: Code Generation Metadata Section");
                    var match = regex.Match(txt);
                    Assert.True(match.Success);
                    Assert.NotEmpty(match.Groups[0].Captures);
                    var metadataTxt = match.Groups[0].Captures[0].Value;
                    Assert.NotEmpty(metadataTxt);
                    Assert.Contains("public static readonly String GithubForkName = \"Azure\";", metadataTxt);
                    Assert.Contains("public static readonly String GithubBranchName = \"master\";", metadataTxt);
                    Assert.Contains("public static readonly String CodeGenerationErrors = \"\";", metadataTxt);
                    Assert.Contains("public static readonly String GithubRepoName = \"azure-rest-api-specs\";", metadataTxt);
                }
            }
            finally
            {
                Cleanup();
            }
        }

        [Fact]
        public void CodeGenerationWithSdkGenDirectoryScenario()
        {
            try
            {
                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    PowerShellInstance.AddScript("powershell.exe -ExecutionPolicy Bypass -File " + new Uri(Path.Combine(scriptsPath, "test2.ps1")).AbsolutePath);
                    var result = PowerShellInstance.Invoke();
                    Assert.NotEmpty(result);
                    Assert.Empty(PowerShellInstance.Streams.Error);
                    Assert.True(Directory.Exists(genDir));
                    Assert.NotEmpty(Directory.GetFiles(genDir));
                    Assert.True(Directory.Exists(metadataDir));
                }
            }
            finally
            {
                Cleanup();
            }
        }

        [Fact]
        public void CodeGenerationWithSdkRootDirectoryScenario()
        {
            try
            {
                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    PowerShellInstance.AddScript("powershell.exe -ExecutionPolicy Bypass -File " + new Uri(Path.Combine(scriptsPath, "test3.ps1")).AbsolutePath);
                    var result = PowerShellInstance.Invoke();
                    Assert.NotEmpty(result);
                    Assert.Empty(PowerShellInstance.Streams.Error);
                    Assert.True(Directory.Exists(genDir));
                    Assert.NotEmpty(Directory.GetFiles(genDir));
                    Assert.True(Directory.Exists(metadataDir));
                }
            }
            finally
            {
                Cleanup();
            }
        }

        [Fact]
        public void NonSDKsCodeGenerationScenario()
        {
            try
            {
                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    PowerShellInstance.AddScript("powershell.exe -ExecutionPolicy Bypass -File " + new Uri(Path.Combine(azureStackScriptPath, "test5.ps1")).AbsolutePath);

                    var result = PowerShellInstance.Invoke();
                    Assert.NotEmpty(result);
                    Assert.Empty(PowerShellInstance.Streams.Error);
                    Assert.True(Directory.Exists(azureStackGenDir));
                    Assert.NotEmpty(Directory.GetFiles(azureStackGenDir));
                    Assert.True(Directory.Exists(metadataDir));
                }
            }
            finally
            {
                Cleanup();
            }
            
        }

        [Fact]
        public void CodeGenerationWithLocalSpecScenario()
        {
            try
            {
                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    PowerShellInstance.AddScript("powershell.exe -ExecutionPolicy Bypass -File " + new Uri(Path.Combine(scriptsPath, "test4.ps1")).AbsolutePath);
                    var result = PowerShellInstance.Invoke();
                    Assert.NotEmpty(result);
                    Assert.Empty(PowerShellInstance.Streams.Error);
                    Assert.True(Directory.Exists(genDir));
                    Assert.NotEmpty(Directory.GetFiles(genDir));
                }
            }
            finally
            {
                Cleanup();
            }
        }

        private void Cleanup()
        {
            if (Directory.Exists(genDir))
            {
                Directory.Delete(genDir, true);
            }
            if (Directory.Exists(azureStackGenDir))
            {
                Directory.Delete(azureStackGenDir, true);
            }
            if (Directory.Exists(metadataDir))
            {
                Directory.Delete(metadataDir, true);
            }
        }
    }
}
