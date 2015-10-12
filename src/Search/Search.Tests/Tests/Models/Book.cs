// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System;

namespace Microsoft.Azure.Search.Tests
{
    internal class Book
    {
        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime? PublishDate { get; set; }

        public override bool Equals(object obj)
        {
            Book other = obj as Book;

            if (other == null)
            {
                return false;
            }

            return 
                ISBN == other.ISBN && 
                Title == other.Title && 
                Author == other.Author &&
                PublishDate == other.PublishDate;
        }

        public override int GetHashCode()
        {
            return (ISBN != null) ? ISBN.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return string.Format(
                "ISBN: {0}; Title: {1}; Author: {2}; PublishDate: {3}", 
                ISBN, 
                Title, 
                Author, 
                PublishDate);
        }
    }
}
