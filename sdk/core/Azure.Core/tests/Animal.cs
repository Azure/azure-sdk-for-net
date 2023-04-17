// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Core.Tests
{
    public class Animal
    {
        public bool IsTired { get; set; } = false;
        public bool IsHungry { get; set; } = false;
        public double Weight { get; set; }
        public string LatinName { get; set; }
        public string Name { get; set; }

        public Animal(double weight)
        {
            Weight = weight;
        }

        // A cat is rested and hungry after it sleeps
        public void Sleep()
        {
            IsTired = false;
            IsHungry = true;
        }

        // Eating makes a cat not hungry
        public void Eat()
        {
            // eating when not hungry makes a cat sleepy
            if (!IsHungry)
            {
                IsTired = true;
            }

            IsHungry = false;
        }

        public virtual string Noise()
        {
            return "Ooh";
        }
    }
}
