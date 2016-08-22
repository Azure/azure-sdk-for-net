// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;

[assembly: AssemblyTitle("Microsoft Azure Search Library")]
[assembly: AssemblyDescription("Makes it easy to develop a .NET application that uses Azure Search.")]

[assembly: AssemblyVersion("2.0.0.0")]
[assembly: AssemblyFileVersion("2.0.1.0")]

[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("Microsoft Azure .NET SDK")]
[assembly: AssemblyCopyright("Copyright (c) Microsoft Corporation")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: NeutralResourcesLanguage("en")]
[assembly: InternalsVisibleTo("Search.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100b5fc90e7027f67871e773a8fde8938c81dd402ba65b9201d60593e96c492651e889cc13f1415ebb53fac1131ae0bd333c5ee6021672d9718ea31a8aebd0da0072f25d87dba6fc90ffd598ed4da35e44c398c454307e8e33b8426143daec9f596836f97c8f74750e5975c64e2189f45def46b2a2b1247adc3652bf5c308055da9")]

namespace Microsoft.Azure.Search
{
    internal class Consts
    {
        // Putting this in AssemblyInfo.cs so we remember to change it when the major SDK version changes.
        public const string TargetApiVersion = "2015-02-28-Preview";
    }
}
