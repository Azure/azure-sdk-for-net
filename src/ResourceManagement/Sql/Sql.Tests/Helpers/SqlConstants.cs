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

namespace Sql.Tests
{
    public class SqlConstants
    {
        public static readonly Guid DbSloShared = new Guid("910b4fcb-8a29-4c3e-958f-f7ba794388b2"); // Web / Business
        public static readonly Guid DbSloBasic = new Guid("dd6d99bb-f193-4ec1-86f2-43d3bccbc49c"); // Basic
        public static readonly Guid DbSloS0 = new Guid("f1173c43-91bd-4aaa-973c-54e79e15235b"); // S0
        public static readonly Guid DbSloS1 = new Guid("1b1ebd4d-d903-4baa-97f9-4ea675f5e928"); // S1
        public static readonly Guid DbSloS2 = new Guid("455330e1-00cd-488b-b5fa-177c226f28b7"); // S2
    }
}
