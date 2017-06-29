// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace TestCommon
{
    public class TestBase
    {

        protected TestingParameters parameters = null;

        public TestBase() : this(TestingParameters.LoadFromFile())
        {
            // Empty
        }

        public TestBase(TestingParameters parameters)
        {
            this.parameters = parameters ?? throw new Exception("parameters file is null");
        }

        /// <summary>
        /// Run a test that accepts no arguments
        /// </summary>
        /// <param name="test"></param>
        protected void RunTest(Action test)
        {
            Exception caught = null;

            try {
                test();
            } catch (Exception ex) {
                caught = ex;
            } finally {
                if (caught != null) {
                    throw new Exception("Test failed", caught);
                }
            }
        }
        
    }
}
