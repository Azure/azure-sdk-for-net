// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("Azure Batch File Conventions")]
[assembly: AssemblyDescription("A convention-based library for saving and retrieving Azure Batch task output files.")]

[assembly: AssemblyVersion("3.0.0.0")] 
[assembly: AssemblyFileVersion("3.2.0.0")]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyProduct("Microsoft Azure")]
[assembly: AssemblyCopyright("Copyright © Microsoft Corporation. All rights reserved.")]

[assembly: ComVisible(false)]

#if !CODESIGN
[assembly: InternalsVisibleTo("AzureBatchFileConventions.Tests")]
[assembly: InternalsVisibleTo("AzureBatchFileConventions.IntegrationTests")]
#endif