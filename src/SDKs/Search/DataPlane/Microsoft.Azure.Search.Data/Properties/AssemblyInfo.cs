// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: AssemblyVersion("5.0.0.0")]
[assembly: AssemblyFileVersion("5.0.2.0")]

[assembly: AssemblyTitle("Microsoft Azure Search Data Library")]
[assembly: AssemblyDescription("Use this assembly if you're developing a .NET application using Azure Search, and you only need to query or update documents in your indexes. If you also need to create or update indexes, synonym maps, or other service-level resources, use the Microsoft.Azure.Search assembly instead.")]

[assembly: InternalsVisibleTo("Search.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100b5fc90e7027f67871e773a8fde8938c81dd402ba65b9201d60593e96c492651e889cc13f1415ebb53fac1131ae0bd333c5ee6021672d9718ea31a8aebd0da0072f25d87dba6fc90ffd598ed4da35e44c398c454307e8e33b8426143daec9f596836f97c8f74750e5975c64e2189f45def46b2a2b1247adc3652bf5c308055da9")]

namespace Microsoft.Azure.Search
{
    internal class Consts
    {
        // Putting this in AssemblyInfo.cs so we remember to change it when the major SDK version changes.
        public const string TargetApiVersion = "2017-11-11";
    }
}
