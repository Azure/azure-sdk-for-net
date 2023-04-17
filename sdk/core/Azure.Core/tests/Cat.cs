// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Core.Tests
{

    public class Cat : Animal
    {
        public Cat(string name, double weight) : base(weight)
        {
            Name = name;
        }

        LatinName = "Felis catus";

        public override string Noise()
        {
            return "Meow!";
        }
    }
}
