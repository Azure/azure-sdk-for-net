using System;
using System.IO;
using Microsoft.Azure.Services.AppAuthentication.TestCommon;
using Xunit;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    public class VisualStudioTokenProviderFileTests
    {
        [Fact]
        public void ParseFileWithOneProvider()
        {
            var visualStudioTokenProviderFile = VisualStudioTokenProviderFile.Parse(File.ReadAllText(Path.Combine(Constants.TestFilesPath, "VisualStudioSingleTokenProvider.json")));

            Assert.NotNull(visualStudioTokenProviderFile);
            Assert.NotNull(visualStudioTokenProviderFile.TokenProviders);
            Assert.Equal(1, visualStudioTokenProviderFile.TokenProviders.Count);

            Assert.Equal(Constants.TokenProviderPath, visualStudioTokenProviderFile.TokenProviders[0].Path);
            Assert.NotNull(visualStudioTokenProviderFile.TokenProviders[0].Arguments);

            Assert.Equal(Constants.ServiceConfigFileArgument, visualStudioTokenProviderFile.TokenProviders[0].Arguments[0]);
        }

        [Fact]
        public void ParseFileWithMultipleProviders()
        {
            var visualStudioTokenProviderFile = VisualStudioTokenProviderFile.Parse(File.ReadAllText(Path.Combine(Constants.TestFilesPath, "VisualStudioMultiTokenProvider.json")));

            Assert.NotNull(visualStudioTokenProviderFile);
            Assert.NotNull(visualStudioTokenProviderFile.TokenProviders);
            Assert.Equal(3, visualStudioTokenProviderFile.TokenProviders.Count);

            Assert.Equal(Constants.TokenProviderPath, visualStudioTokenProviderFile.TokenProviders[0].Path);
            Assert.NotNull(visualStudioTokenProviderFile.TokenProviders[0].Arguments);
            Assert.NotNull(visualStudioTokenProviderFile.TokenProviders[1].Arguments);

            Assert.Equal(Constants.ServiceConfigFileArgumentName, visualStudioTokenProviderFile.TokenProviders[0].Arguments[0]);
            Assert.Equal(Constants.ServiceConfigFileArgument, visualStudioTokenProviderFile.TokenProviders[0].Arguments[1]);
        }

        [Fact]
        public void ParseFileError()
        {
            Exception exception = Assert.Throws<FormatException>(() => VisualStudioTokenProviderFile.Parse(File.ReadAllText(Path.Combine(Constants.TestFilesPath, "VisualStudioTokenProviderMissingPreference.json"))));

            Assert.Contains(Constants.TokenProviderFileFormatExceptionMessage, exception.Message);
            Assert.Contains(Constants.PreferenceNotFound, exception.Message);
        }
    }
}
