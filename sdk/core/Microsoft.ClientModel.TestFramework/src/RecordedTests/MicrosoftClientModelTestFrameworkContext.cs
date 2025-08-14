// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework.TestProxy;
using Microsoft.ClientModel.TestFramework.TestProxy.Admin;
using System.ClientModel.Primitives;

namespace Microsoft.ClientModel.TestFramework;

[ModelReaderWriterBuildable(typeof(BodyKeySanitizer))]
[ModelReaderWriterBuildable(typeof(BodyRegexSanitizer))]
[ModelReaderWriterBuildable(typeof(CustomDefaultMatcher))]
[ModelReaderWriterBuildable(typeof(HeaderRegexSanitizer))]
[ModelReaderWriterBuildable(typeof(TestProxyStartInformation))]
[ModelReaderWriterBuildable(typeof(UriRegexSanitizer))]
[ModelReaderWriterBuildable(typeof(ApplyCondition))]
public partial class MicrosoftClientModelTestFrameworkContext
{
}
