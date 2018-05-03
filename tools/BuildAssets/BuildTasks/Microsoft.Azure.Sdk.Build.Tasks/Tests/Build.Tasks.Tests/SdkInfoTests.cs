// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Build.Tasks.Tests
{
    using NuGet.Packaging;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Xunit;


    public class SdkInfoTests
    {
        const string NUGET_PKG_NAME = "Build.Tasks.Tests.1.0.0.nupkg";

        string sdkSampleAssemblyDir;
        public SdkInfoTests()
        {
            string codeBasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            Uri codeBaseUri = new Uri(codeBasePath);

            sdkSampleAssemblyDir = codeBaseUri.LocalPath;
        }

        [Fact]
        public void TagMultipleApiVersions()
        {
            GetApiMap("SdkInfo_Compute");
            VerifyNupkg();
        }



        internal void GetApiMap(string sdkInfoTypeName = "")
        {
            string sdkAsmPath = Path.Combine(sdkSampleAssemblyDir, "SdkInfoSample.dll");

            Assembly sdkAsm = Assembly.LoadFrom(sdkAsmPath);
            List<Type> typeList = sdkAsm.GetTypes().Where<Type>((t) => t.Name.EndsWith("SdkInfo")).ToList<Type>();
            Type someType = typeList.First<Type>();

            IEnumerable<Tuple<string, string, string>> apiMap = (IEnumerable<Tuple<string,string,string>>) someType.GetProperty(sdkInfoTypeName).GetValue(null, null);
            
            Assert.NotNull(apiMap);
        }


        /// <summary>
        /// We use external Nuget.Packaging nuget package to read nuget package contents.
        /// This package is published by nuget team.
        /// </summary>
        internal void VerifyNupkg()
        {
            string NugetPkgDir = Path.GetDirectoryName(sdkSampleAssemblyDir);
            string nugetPkg = Path.Combine(NugetPkgDir, NUGET_PKG_NAME);

            using (PackageArchiveReader pkgRdr = new PackageArchiveReader(nugetPkg))
            {
                string tag = pkgRdr.NuspecReader.GetMetadataValue("tags");
            }   
        }
    }
}
