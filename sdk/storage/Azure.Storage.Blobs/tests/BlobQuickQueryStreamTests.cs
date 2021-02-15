// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Test;
using NUnit.Framework;
using static Azure.Storage.Test.Shared.BlobTestBase;

namespace Azure.Storage.Blobs.Test
{
    public class BlobQuickQueryStreamTests
    {
        [Test]
        public void ValidateReadParameters()
        {
            TestHelper.AssertExpectedException(
                () => BlobQuickQueryStream.ValidateReadParameters(buffer: null, offset: 0, count: 0),
                new ArgumentException($"Parameter cannot be null.", "buffer"));

            TestHelper.AssertExpectedException(
                () => BlobQuickQueryStream.ValidateReadParameters(buffer: new byte[10], offset: -1, count: 0),
                new ArgumentException($"Parameter cannot be negative.", "offset"));

            TestHelper.AssertExpectedException(
                () => BlobQuickQueryStream.ValidateReadParameters(buffer: new byte[10], offset: 0, count: -1),
                new ArgumentException($"Parameter cannot be negative.", "count"));

            TestHelper.AssertExpectedException(
                () => BlobQuickQueryStream.ValidateReadParameters(buffer: new byte[5], offset: 6, count: 6),
                new ArgumentException("The sum of offset and count cannot be greater than buffer length."));
        }

        [Test]
        public void ProcessErrorRecord()
        {
            // Arrange
            bool fatal = true;
            string name = "name";
            string description = "description";
            long position = 12345;

            Dictionary<string, object> record = new Dictionary<string, object>
            {
                { Constants.QuickQuery.Fatal, fatal },
                { Constants.QuickQuery.Name, name },
                { Constants.QuickQuery.Description, description },
                { Constants.QuickQuery.Position, position }
            };

            BlobQueryError expectedError = new BlobQueryError
            {
                IsFatal = fatal,
                Name = name,
                Description = description,
                Position = position
            };

            BlobQueryErrorHandler errorHandler = new BlobQueryErrorHandler(expectedError);

            BlobQuickQueryStream quickQueryStream = new BlobQuickQueryStream(
                new MemoryStream(),
                default,
                errorHandler.Handle);

            // Act
            quickQueryStream.ProcessErrorRecord(record);
        }
    }
}
