// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    public readonly partial struct CurrencyValue
    {
        /// <summary> Initializes a new instance of CurrencyValue. </summary>
        /// <param name="amount"> Currency amount. </param>
        /// <param name="symbol"> Currency symbol label, if any. </param>
        /// <param name="code"> Resolved currency code (ISO 4217), if any. </param>
        internal CurrencyValue(double amount, string symbol, string code)
        {
            Amount = amount;
            Symbol = symbol;
            Code = code;
        }

        /// <summary>
        /// Currency amount.
        /// </summary>
        public double Amount { get; }

        /// <summary>
        /// Currency symbol label, if any.
        /// </summary>
        [CodeGenMember("CurrencySymbol")]
        public string Symbol { get; }

        /// <summary>
        /// Resolved currency code (ISO 4217), if any.
        /// </summary>
        [CodeGenMember("CurrencyCode")]
        public string Code { get; }
    }
}
