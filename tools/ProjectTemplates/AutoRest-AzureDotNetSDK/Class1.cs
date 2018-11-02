using System;

namespace AutoRest_AzureDotNetSDK
{
    public class Class1
    {
        /*
            If you get compile error that looks like it cannot restore certain nuget packages (e.g. Microsoft.Rest.*)
            that means you have created this project outside the .NET SDK local repository.
            There are certain target and common pacakges that every .NET SDK needs.

            Also if you getting multiple compile errors that seems random.
            Please open VS developer prompt, go to the local repository root and execute the following
            msbuild build.proj

            This will download the build tools needed to build .NET SDK repository.
            Close VS and reopen after you are done downloading build tools.
			
			Check if AssemblyInfo data is accorate in AssemblyInfo.cs

        */
    }
}
