// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    internal class CBORUtil
    {
        /// <summary>
        /// Validate if object of type T is not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public void ValidateObjectNotNull<T>(T obj)
        {
            if (obj == null)
            {
                CBORException exp = new CBORException($"{typeof(T).Name} is null.");
                throw exp;
            }
        }

        /// <summary>
        /// Validate if CBORObject is not null
        /// </summary>
        /// <param name="obj"></param>
        public void ValidateCBORObjectNotNull(CBORObject obj)
        {
            if (obj == null || obj.IsNull)
            {
                CBORException exp = new CBORException("Invalid Null Value for CBOR Object");
                throw exp;
            }
        }

        /// <summary>
        /// Validate if CBORObject is an array
        /// </summary>
        /// <param name="obj"></param>
        public void ValidateCBORObjectIsArray(CBORObject obj)
        {
            ValidateCBORObjectNotNull(obj);

            if (obj.Type != CBORType.Array)
            {
                CBORException exp = new CBORException("CBORObject should be of type Array");
                throw exp;
            }
        }

        /// <summary>
        /// Validate if CBORObject is of type Map
        /// </summary>
        /// <param name="obj"></param>
        public void ValidateCBORObjectIsMap(CBORObject obj)
        {
            ValidateCBORObjectNotNull(obj);

            if (obj.Type != CBORType.Map)
            {
                CBORException exp = new CBORException("CBORObject should be of type Map");
                throw exp;
            }
        }

        /// <summary>
        /// Validate if CBORObject is a byteString of given size
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="byteArraySize"></param>
        public void ValidateByteStringWithSize(CBORObject obj, int byteArraySize)
        {
            ValidateCBORObjectNotNull(obj);

            if (obj.Type != CBORType.ByteString)
            {
                CBORException exp = new CBORException("CBORType must be a byte string");
                throw exp;
            }

            if (obj.GetByteString().Length != byteArraySize)
            {
                CBORException exp = new CBORException($"CBOR ByteString must be of size = {byteArraySize}");
                throw exp;
            }
        }

        public void AddUeidToCBOR(Guid obj, CBORObject cborObj, byte eatRand, int eatUeid, int ueidByteArraySize)
        {
            ValidateCBORObjectNotNull(cborObj);
            byte[] guidBytes = new byte[ueidByteArraySize];
            guidBytes[0] = eatRand;
            Array.Copy(obj.ToByteArray(), 0, guidBytes, 1, ueidByteArraySize - 1);
            _ = cborObj.Add(eatUeid, guidBytes);
        }

        public Guid ExtractGuidFromUEID(byte[] ueid, int guidByteArraySize, int eatRand)
        {
            ValidateObjectNotNull(ueid);
            if (ueid.Length < 1 || ueid[0] != eatRand)
            {
                CBORException exp = new CBORException("UEID format is incorrect");
                throw exp;
            }
            byte[] guidBytes = new byte[guidByteArraySize];
            Array.Copy(ueid, 1, guidBytes, 0, guidByteArraySize);
            return new Guid(guidBytes);
        }
    }
}
