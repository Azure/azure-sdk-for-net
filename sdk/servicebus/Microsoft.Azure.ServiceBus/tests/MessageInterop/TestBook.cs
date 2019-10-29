// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests.MessageInterop
{
    using System;

    public class TestBook
    {
        public TestBook() { }

        public TestBook(string name, int id, int count)
        {
            this.Name = name;
            this.Count = count;
            this.Id = id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var testBook = (TestBook)obj;

            return
                this.Name.Equals(testBook.Name, StringComparison.OrdinalIgnoreCase) &&
                this.Count == testBook.Count &&
                this.Id == testBook.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string Name { get; set; }

        public int Count { get; set; }

        public int Id { get; set; }
    }
}
