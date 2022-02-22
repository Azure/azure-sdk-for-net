// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;

namespace Azure.Storage.Test.Shared
{
    public class StorageRecordedTestSanitizer : RecordedTestSanitizer
    {
        private const string SignatureQueryName = "sig";
        private const string CopySourceName = "x-ms-copy-source";
        private const string RenameSource = "x-ms-rename-source";
        private const string CopySourceAuthorization = "x-ms-copy-source-authorization";
        private const string PreviousSnapshotUrl = "x-ms-previous-snapshot-url";
        private const string FileRenameSource = "x-ms-file-rename-source";

        public StorageRecordedTestSanitizer()
        {
            UriRegexSanitizers.Add(UriRegexSanitizer.CreateWithQueryParameter(SignatureQueryName, SanitizeValue));

#if NETFRAMEWORK
            // Uri uses different escaping for some special characters between .NET Framework and Core. Because the Test Proxy runs on .NET
            // Core, we need to normalize to the .NET Core escaping when matching and storing the recordings when running tests on NetFramework.
            UriRegexSanitizers.Add(new UriRegexSanitizer("\\(", "%28"));
            UriRegexSanitizers.Add(new UriRegexSanitizer("\\)", "%29"));
            UriRegexSanitizers.Add(new UriRegexSanitizer("\\!", "%21"));
            UriRegexSanitizers.Add(new UriRegexSanitizer("\\'", "%27"));
            UriRegexSanitizers.Add(new UriRegexSanitizer("\\*", "%2A"));
            // Encode any colons in the Uri except for the one in the scheme
            UriRegexSanitizers.Add(new UriRegexSanitizer("(?<group>:)[^//]", "%3A") {GroupForReplace = "group"});
#endif

            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("x-ms-encryption-key", SanitizeValue));
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(CopySourceAuthorization, SanitizeValue));
            HeaderRegexSanitizers.Add(HeaderRegexSanitizer.CreateWithQueryParameter(CopySourceName, SignatureQueryName, SanitizeValue));
            HeaderRegexSanitizers.Add(HeaderRegexSanitizer.CreateWithQueryParameter(RenameSource, SignatureQueryName, SanitizeValue));
            HeaderRegexSanitizers.Add(HeaderRegexSanitizer.CreateWithQueryParameter(PreviousSnapshotUrl, SignatureQueryName, SanitizeValue));
            HeaderRegexSanitizers.Add(HeaderRegexSanitizer.CreateWithQueryParameter(FileRenameSource, SignatureQueryName, SanitizeValue));

            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"client_secret=(?<group>.*?)(?=&|$)", SanitizeValue)
            {
                GroupForReplace = "group"
            });
        }
    }
}
