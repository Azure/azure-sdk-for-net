// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Azure.Quantum.Client;
using Microsoft.Azure.Quantum.Optimization;
//using NUnit.Framework;


namespace Microsoft.Azure.Quantum.Samples
{
    /// <summary>
    /// Sample to access the QIO SDK used to solve an optimization problems.
    /// </summary>
    public class QioSample
    {
        /// <summary>
        /// Authenticate with <see cref="DefaultAzureCredential"/>.
        /// </summary>
        public void Solve()
        {
            #region Snippet:SampleSnippetsQio

            IQuantumClient client = new QuantumClient()

            IProblem problem = new Problem(
                name: "myOptimizationProblem",
                type: ProblemType.ising);

            problem.AddTerm(w: -1, indices: new int[2] { 0, 1 });

            // or
            Term term = new Term(w: -1, indices: new int[2] { 0, 1 });
            problem.AddTerm(term);

            // or
            problem.AddTerms(terms);
            #endregion
        }
    }
}
