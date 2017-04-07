// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.AppService.Fluent.Models;

namespace Microsoft.Azure.Management.AppService.Fluent
{
    /// <summary>
    /// An immutable client-side representation of a connection string on a web app.
    /// </summary>
    internal partial class ConnectionStringImpl  :
        IConnectionString
    {
        ///GENMHASH:45A4D243BCC3EB6FA01DA00F52FDF305:425D09AC93B7A17B1A16F0D028F706A2
        internal  ConnectionStringImpl(string name, ConnStringValueTypePair valueTypePair, bool sticky)
        {
            //$ this.name = name;
            //$ this.valueTypePair = valueTypePair;
            //$ this.sticky = sticky;
            //$ }

        }

        ///GENMHASH:683EC8CC1E0263C925A3D81103936F1D:735925B0656EA32EBE39A6B447AE1D3E
        public bool Sticky()
        {
            //$ return sticky;

            return false;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:2436A145BB7A20817F8EDCB98EB71DCC
        public string Name()
        {
            //$ return name;

            return null;
        }

        ///GENMHASH:C1D104519E98AFA1614D0BFD517E6100:18B92DD992B7E69E1D4A68A29BF97252
        public string Value()
        {
            //$ return valueTypePair.Value();

            return null;
        }

        ///GENMHASH:8442F1C1132907DE46B62B277F4EE9B7:E58B813F3257652C573FB849FE5045B8
        public ConnectionStringType Type()
        {
            //$ return valueTypePair.Type();

            return ConnectionStringType.MY_SQL;
        }
    }
}