// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using NUnit.Framework;

namespace Azure.CrossBoundary.RoundTrip.Tests
{
    public class SerializedAddtionalRawDataTests
    {
        [Test]
        // Solution 1: change _serializedAdditionalRawData from `private protected` to `protected`
        public void Solution1_MakeItProtected()
        {
            var model = TestHelper.ReadModelFromFile<RoundTripInheritanceModel>("SerializedAddtionalRawData_Solution1.json",
                new ModelReaderWriterOptions("W2"));// Arbitrary options other than "W"
            string json = TestHelper.ReadJsonFromModel<RoundTripInheritanceModel>(model, new ModelReaderWriterOptions("W2"));
        }

        //[Test]
        //public void Solution2_MakeItOwnProperty()
        //{

        //}
    }
}
