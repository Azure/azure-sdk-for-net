// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ApprovalTests.Reporters;

#if FullNetFx
[assembly: UseReporter(typeof(XUnit2Reporter), typeof(AllFailingTestsClipboardReporter))]
#else
[assembly: UseReporter(typeof(XUnit2Reporter))]
#endif
