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

using Hyak.Common;
using Hyak.Common.Internals;
using Xunit;
using Xunit.Extensions;

namespace Microsoft.Azure.Common.Test.Internals
{
    public class ParserHelperTests
    {
        [Theory]
        [InlineData("{ error }", true)]
        [InlineData(" { error }", true)]
        [InlineData("		{ error }", true)]
        [InlineData("		}", false)]
        [InlineData(" }", false)]
        [InlineData("}", false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData(" 		", false)]
        [InlineData(null, false)]
        public void IsJsonWorksWithoutValidation(string body, bool expectedResult)
        {
            Assert.Equal(expectedResult, CloudException.IsJson(body));
        }

        [Theory]
        [InlineData("{ }", true)]
        [InlineData("{ 'error' : 'message' }", true)]
        [InlineData(" { 'error' : 'message' }", true)]
        [InlineData("		{ 'error' : 'message' }", true)]
        [InlineData("		{ 'error' : ", false)]
        [InlineData("		}", false)]
        [InlineData(" }", false)]
        [InlineData("}", false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData(" 		", false)]
        [InlineData(null, false)]
        public void IsJsonWorksWithValidation(string body, bool expectedResult)
        {
            Assert.Equal(expectedResult, CloudException.IsJson(body, true));
        }

        [Theory]
        [InlineData("<error/>", true)]
        [InlineData(" <error/>", true)]
        [InlineData("		<error/>", true)]
        [InlineData("		>", false)]
        [InlineData(" >", false)]
        [InlineData(">", false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData(" 		", false)]
        [InlineData(null, false)]
        public void IsXmlWorksWithoutValidation(string body, bool expectedResult)
        {
            Assert.Equal(expectedResult, CloudException.IsXml(body));
        }

        [Theory]
        [InlineData("<error/>", true)]
        [InlineData(" <error/>", true)]
        [InlineData("		<error/>", true)]
        [InlineData("		<error>", false)]
        [InlineData("		>", false)]
        [InlineData(" >", false)]
        [InlineData(">", false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData(" 		", false)]
        [InlineData(null, false)]
        public void IsXmlWorksWithValidation(string body, bool expectedResult)
        {
            Assert.Equal(expectedResult, CloudException.IsXml(body, true));
        }
    }
}
