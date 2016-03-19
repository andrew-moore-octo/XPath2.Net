﻿// Microsoft Public License (Ms-PL)
// See the file License.rtf or License.txt for the license details.

// Copyright (c) 2011, Semyon A. Chertkov (semyonc@gmail.com)
// All rights reserved.

using System;

namespace Wmhelp.XPath2.Proxy
{
    internal class ByteProxyFactory : ValueProxyFactory
    {
        public const int Code = 17;

        public override ValueProxy Create(object value)
        {
            return new ByteProxy((byte) value);
        }

        public override int GetValueCode()
        {
            return Code;
        }

        public override Type GetValueType()
        {
            return typeof (Byte);
        }

        public override Type GetResultType()
        {
            return typeof (Int32);
        }

        public override bool IsNumeric => true;

        public override int Compare(ValueProxyFactory other)
        {
            switch (other.GetValueCode())
            {
                case SByteProxyFactory.Code:
                    return 1;

                case Code:
                    return 0;

                case UShortFactory.Code:
                case UIntFactory.Code:
                case ULongFactory.Code:
                case ShortFactory.Code:
                case IntFactory.Code:
                case LongFactory.Code:
                case IntegerProxyFactory.Code:
                case DecimalProxyFactory.Code:
                case FloatFactory.Code:
                case DoubleProxyFactory.Code:
                    return -1;

                default:
                    return -2;
            }
        }
    }
}