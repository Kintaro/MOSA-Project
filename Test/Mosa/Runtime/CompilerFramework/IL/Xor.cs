﻿/*
 * (c) 2008 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Alex Lyman (<mailto:mail.alex.lyman@gmail.com>)
 *  Simon Wollwage (<mailto:rootnode@mosa-project.org>)
 */

using System;
using System.Collections.Generic;
using System.Text;
using MbUnit.Framework;

namespace Test.Mosa.Runtime.CompilerFramework.IL
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class Xor : MosaCompilerTestRunner
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expect"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        delegate bool I4_I1_I1(int expect, sbyte a, sbyte b);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Row(1, 2)]
        [Row(23, 21)]
        [Row(1, -2)]
        [Row(-1, 2)]
        [Row(0, 0)]
        [Row(-17, -2)]
        // And reverse
        [Row(2, 1)]
        [Row(21, 23)]
        [Row(-2, 1)]
        [Row(2, -1)]
        [Row(-2, -17)]
        // (MinValue, X) Cases
        [Row(sbyte.MinValue, 0)]
        [Row(sbyte.MinValue, 1)]
        [Row(sbyte.MinValue, 17)]
        [Row(sbyte.MinValue, 123)]
        [Row(sbyte.MinValue, -0)]
        [Row(sbyte.MinValue, -1)]
        [Row(sbyte.MinValue, -17)]
        [Row(sbyte.MinValue, -123)]
        // (MaxValue, X) Cases
        [Row(sbyte.MaxValue, 0)]
        [Row(sbyte.MaxValue, 1)]
        [Row(sbyte.MaxValue, 17)]
        [Row(sbyte.MaxValue, 123)]
        [Row(sbyte.MaxValue, -0)]
        [Row(sbyte.MaxValue, -1)]
        [Row(sbyte.MaxValue, -17)]
        [Row(sbyte.MaxValue, -123)]
        // (X, MinValue) Cases
        [Row(0, sbyte.MinValue)]
        [Row(1, sbyte.MinValue)]
        [Row(17, sbyte.MinValue)]
        [Row(123, sbyte.MinValue)]
        [Row(-0, sbyte.MinValue)]
        [Row(-1, sbyte.MinValue)]
        [Row(-17, sbyte.MinValue)]
        [Row(-123, sbyte.MinValue)]
        // (X, MaxValue) Cases
        [Row(0, sbyte.MaxValue)]
        [Row(1, sbyte.MaxValue)]
        [Row(17, sbyte.MaxValue)]
        [Row(123, sbyte.MaxValue)]
        [Row(-0, sbyte.MaxValue)]
        [Row(-1, sbyte.MaxValue)]
        [Row(-17, sbyte.MaxValue)]
        [Row(-123, sbyte.MaxValue)]
        // Extremvaluecases
        [Row(sbyte.MinValue, sbyte.MaxValue)]
        [Row(sbyte.MaxValue, sbyte.MinValue)]
        [Test, Author("rootnode", "rootnode@mosa-project.org")]
        public void XorI1(sbyte a, sbyte b)
        {
            CodeSource = "static class Test { static bool XorI1(int expect, sbyte a, sbyte b) { return expect == (a ^ b); } }";
            Assert.IsTrue((bool)Run<I4_I1_I1>("", "Test", "XorI1", a ^ b, a, b));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expect"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        delegate bool U4_U1_U1(uint expect, byte a, byte b);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Row(1, 2)]
        [Row(23, 21)]
        // And reverse
        [Row(2, 1)]
        [Row(21, 23)]
        // (MinValue, X) Cases
        [Row(byte.MinValue, 0)]
        [Row(byte.MinValue, 1)]
        [Row(byte.MinValue, 17)]
        [Row(byte.MinValue, 123)]
        // (MaxValue, X) Cases
        [Row(byte.MaxValue, 0)]
        [Row(byte.MaxValue, 1)]
        [Row(byte.MaxValue, 17)]
        [Row(byte.MaxValue, 123)]
        // (X, MinValue) Cases
        [Row(0, byte.MinValue)]
        [Row(1, byte.MinValue)]
        [Row(17, byte.MinValue)]
        [Row(123, byte.MinValue)]
        // (X, MaxValue) Cases
        [Row(0, byte.MaxValue)]
        [Row(1, byte.MaxValue)]
        [Row(17, byte.MaxValue)]
        [Row(123, byte.MaxValue)]
        // Extremvaluecases
        [Row(byte.MinValue, byte.MaxValue)]
        [Row(byte.MaxValue, byte.MinValue)]
        [Test, Author("rootnode", "rootnode@mosa-project.org")]
        public void XorU1(byte a, byte b)
        {
            CodeSource = "static class Test { static bool XorU1(uint expect, byte a, byte b) { return expect == (a ^ b); } }";
            Assert.IsTrue((bool)Run<U4_U1_U1>("", "Test", "XorU1", (uint)(a ^ b), a, b));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expect"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        delegate bool I4_I2_I2(int expect, short a, short b);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Row(1, 2)]
        [Row(23, 21)]
        [Row(1, -2)]
        [Row(-1, 2)]
        [Row(0, 0)]
        [Row(-17, -2)]
        // And reverse
        [Row(2, 1)]
        [Row(21, 23)]
        [Row(-2, 1)]
        [Row(2, -1)]
        [Row(-2, -17)]
        // (MinValue, X) Cases
        [Row(short.MinValue, 0)]
        [Row(short.MinValue, 1)]
        [Row(short.MinValue, 17)]
        [Row(short.MinValue, 123)]
        [Row(short.MinValue, -0)]
        [Row(short.MinValue, -1)]
        [Row(short.MinValue, -17)]
        [Row(short.MinValue, -123)]
        // (MaxValue, X) Cases
        [Row(short.MaxValue, 0)]
        [Row(short.MaxValue, 1)]
        [Row(short.MaxValue, 17)]
        [Row(short.MaxValue, 123)]
        [Row(short.MaxValue, -0)]
        [Row(short.MaxValue, -1)]
        [Row(short.MaxValue, -17)]
        [Row(short.MaxValue, -123)]
        // (X, MinValue) Cases
        [Row(0, short.MinValue)]
        [Row(1, short.MinValue)]
        [Row(17, short.MinValue)]
        [Row(123, short.MinValue)]
        [Row(-0, short.MinValue)]
        [Row(-1, short.MinValue)]
        [Row(-17, short.MinValue)]
        [Row(-123, short.MinValue)]
        // (X, MaxValue) Cases
        [Row(0, short.MaxValue)]
        [Row(1, short.MaxValue)]
        [Row(17, short.MaxValue)]
        [Row(123, short.MaxValue)]
        [Row(-0, short.MaxValue)]
        [Row(-1, short.MaxValue)]
        [Row(-17, short.MaxValue)]
        [Row(-123, short.MaxValue)]
        // Extremvaluecases
        [Row(short.MinValue, short.MaxValue)]
        [Row(short.MaxValue, short.MinValue)]
        [Test, Author("rootnode", "rootnode@mosa-project.org")]
        public void XorI2(short a, short b)
        {
            short e = (short)(a ^ b);
            CodeSource = "static class Test { static bool XorI2(int expect, short a, short b) { return expect == (a ^ b); } }";
            Assert.IsTrue((bool)Run<I4_I2_I2>("", "Test", "XorI2", (a ^ b), a, b));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expect"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        delegate bool U4_U2_U2(uint expect, ushort a, ushort b);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Row(1, 2)]
        [Row(23, 21)]
        // And reverse
        [Row(2, 1)]
        [Row(21, 23)]
        // (MinValue, X) Cases
        [Row(ushort.MinValue, 0)]
        [Row(ushort.MinValue, 1)]
        [Row(ushort.MinValue, 17)]
        [Row(ushort.MinValue, 123)]
        // (MaxValue, X) Cases
        [Row(ushort.MaxValue, 0)]
        [Row(ushort.MaxValue, 1)]
        [Row(ushort.MaxValue, 17)]
        [Row(ushort.MaxValue, 123)]
        // (X, MinValue) Cases
        [Row(0, ushort.MinValue)]
        [Row(1, ushort.MinValue)]
        [Row(17, ushort.MinValue)]
        [Row(123, ushort.MinValue)]
        // (X, MaxValue) Cases
        [Row(0, ushort.MaxValue)]
        [Row(1, ushort.MaxValue)]
        [Row(17, ushort.MaxValue)]
        [Row(123, ushort.MaxValue)]
        // Extremvaluecases
        [Row(ushort.MinValue, ushort.MaxValue)]
        [Row(ushort.MaxValue, ushort.MinValue)]
        [Test, Author("rootnode", "rootnode@mosa-project.org")]
        public void XorU2(ushort a, ushort b)
        {
            ushort e = (ushort)(a ^ b);
            CodeSource = "static class Test { static bool XorU2(uint expect, ushort a, ushort b) { return expect == (a ^ b); } }";
            Assert.IsTrue((bool)Run<U4_U2_U2>("", "Test", "XorU2", (uint)(a ^ b), a, b));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expect"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        delegate bool I4_I4_I4(int expect, int a, int b);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Row(1, 2)]
        [Row(23, 21)]
        [Row(1, -2)]
        [Row(-1, 2)]
        [Row(0, 0)]
        [Row(-17, -2)]
        // And reverse
        [Row(2, 1)]
        [Row(21, 23)]
        [Row(-2, 1)]
        [Row(2, -1)]
        [Row(-2, -17)]
        // (MinValue, X) Cases
        [Row(int.MinValue, 0)]
        [Row(int.MinValue, 1)]
        [Row(int.MinValue, 17)]
        [Row(int.MinValue, 123)]
        [Row(int.MinValue, -0)]
        [Row(int.MinValue, -1)]
        [Row(int.MinValue, -17)]
        [Row(int.MinValue, -123)]
        // (MaxValue, X) Cases
        [Row(int.MaxValue, 0)]
        [Row(int.MaxValue, 1)]
        [Row(int.MaxValue, 17)]
        [Row(int.MaxValue, 123)]
        [Row(int.MaxValue, -0)]
        [Row(int.MaxValue, -1)]
        [Row(int.MaxValue, -17)]
        [Row(int.MaxValue, -123)]
        // (X, MinValue) Cases
        [Row(0, int.MinValue)]
        [Row(1, int.MinValue)]
        [Row(17, int.MinValue)]
        [Row(123, int.MinValue)]
        [Row(-0, int.MinValue)]
        [Row(-1, int.MinValue)]
        [Row(-17, int.MinValue)]
        [Row(-123, int.MinValue)]
        // (X, MaxValue) Cases
        [Row(0, int.MaxValue)]
        [Row(1, int.MaxValue)]
        [Row(17, int.MaxValue)]
        [Row(123, int.MaxValue)]
        [Row(-0, int.MaxValue)]
        [Row(-1, int.MaxValue)]
        [Row(-17, int.MaxValue)]
        [Row(-123, int.MaxValue)]
        // Extremvaluecases
        [Row(int.MinValue, int.MaxValue)]
        [Row(int.MaxValue, int.MinValue)]
        [Test, Author("rootnode", "rootnode@mosa-project.org")]
        public void XorI4(int a, int b)
        {
            CodeSource = "static class Test { static bool XorI4(int expect, int a, int b) { return expect == (a ^ b); } }";
            Assert.IsTrue((bool)Run<I4_I4_I4>("", "Test", "XorI4", (a ^ b), a, b));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expect"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        delegate bool U4_U4_U4(uint expect, uint a, uint b);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Row(1, 2)]
        [Row(23, 21)]
        // And reverse
        [Row(2, 1)]
        [Row(21, 23)]
        // (MinValue, X) Cases
        [Row(uint.MinValue, 0)]
        [Row(uint.MinValue, 1)]
        [Row(uint.MinValue, 17)]
        [Row(uint.MinValue, 123)]
        // (MaxValue, X) Cases
        [Row(uint.MaxValue, 0)]
        [Row(uint.MaxValue, 1)]
        [Row(uint.MaxValue, 17)]
        [Row(uint.MaxValue, 123)]
        // (X, MinValue) Cases
        [Row(0, uint.MinValue)]
        [Row(1, uint.MinValue)]
        [Row(17, uint.MinValue)]
        [Row(123, uint.MinValue)]
        // (X, MaxValue) Cases
        [Row(0, uint.MaxValue)]
        [Row(1, uint.MaxValue)]
        [Row(17, uint.MaxValue)]
        [Row(123, uint.MaxValue)]
        // Extremvaluecases
        [Row(uint.MinValue, uint.MaxValue)]
        [Row(uint.MaxValue, uint.MinValue)]
        [Test, Author("rootnode", "rootnode@mosa-project.org")]
        public void XorU4(uint a, uint b)
        {
            CodeSource = "static class Test { static bool XorU4(uint expect, uint a, uint b) { return expect == (a ^ b); } }";
            Assert.IsTrue((bool)Run<U4_U4_U4>("", "Test", "XorU4", (uint)(a ^ b), a, b));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expect"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        delegate bool I8_I8_I8(long expect, long a, long b);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Row(1, 2)]
        [Row(23, 21)]
        [Row(1, -2)]
        [Row(-1, 2)]
        [Row(0, 0)]
        [Row(-17, -2)]
        // And reverse
        [Row(2, 1)]
        [Row(21, 23)]
        [Row(-2, 1)]
        [Row(2, -1)]
        [Row(-2, -17)]
        // (MinValue, X) Cases
        [Row(long.MinValue, 0)]
        [Row(long.MinValue, 1)]
        [Row(long.MinValue, 17)]
        [Row(long.MinValue, 123)]
        [Row(long.MinValue, -0)]
        [Row(long.MinValue, -1)]
        [Row(long.MinValue, -17)]
        [Row(long.MinValue, -123)]
        // (MaxValue, X) Cases
        [Row(long.MaxValue, 0)]
        [Row(long.MaxValue, 1)]
        [Row(long.MaxValue, 17)]
        [Row(long.MaxValue, 123)]
        [Row(long.MaxValue, -0)]
        [Row(long.MaxValue, -1)]
        [Row(long.MaxValue, -17)]
        [Row(long.MaxValue, -123)]
        // (X, MinValue) Cases
        [Row(0, long.MinValue)]
        [Row(1, long.MinValue)]
        [Row(17, long.MinValue)]
        [Row(123, long.MinValue)]
        [Row(-0, long.MinValue)]
        [Row(-1, long.MinValue)]
        [Row(-17, long.MinValue)]
        [Row(-123, long.MinValue)]
        // (X, MaxValue) Cases
        [Row(0, long.MaxValue)]
        [Row(1, long.MaxValue)]
        [Row(17, long.MaxValue)]
        [Row(123, long.MaxValue)]
        [Row(-0, long.MaxValue)]
        [Row(-1, long.MaxValue)]
        [Row(-17, long.MaxValue)]
        [Row(-123, long.MaxValue)]
        // Extremvaluecases
        [Row(long.MinValue, long.MaxValue)]
        [Row(long.MaxValue, long.MinValue)]
        [Test, Author("rootnode", "rootnode@mosa-project.org")]
        public void XorI8(long a, long b)
        {
            CodeSource = "static class Test { static bool XorI8(long expect, long a, long b) { return expect == (a ^ b); } }";
            Assert.IsTrue((bool)Run<I8_I8_I8>("", "Test", "XorI8", (a ^ b), a, b));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expect"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        delegate bool U8_U8_U8(ulong expect, ulong a, ulong b);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Row(1, 2)]
        [Row(23, 21)]
        // And reverse
        [Row(2, 1)]
        [Row(21, 23)]
        // (MinValue, X) Cases
        [Row(ulong.MinValue, 0)]
        [Row(ulong.MinValue, 1)]
        [Row(ulong.MinValue, 17)]
        [Row(ulong.MinValue, 123)]
        // (MaxValue, X) Cases
        [Row(ulong.MaxValue, 0)]
        [Row(ulong.MaxValue, 1)]
        [Row(ulong.MaxValue, 17)]
        [Row(ulong.MaxValue, 123)]
        // (X, MinValue) Cases
        [Row(0, ulong.MinValue)]
        [Row(1, ulong.MinValue)]
        [Row(17, ulong.MinValue)]
        [Row(123, ulong.MinValue)]
        // (X, MaxValue) Cases
        [Row(0, ulong.MaxValue)]
        [Row(1, ulong.MaxValue)]
        [Row(17, ulong.MaxValue)]
        [Row(123, ulong.MaxValue)]
        // Extremvaluecases
        [Row(ulong.MinValue, ulong.MaxValue)]
        [Row(ulong.MaxValue, ulong.MinValue)]
        [Test, Author("rootnode", "rootnode@mosa-project.org")]
        public void XorU8(ulong a, ulong b)
        {
            CodeSource = "static class Test { static bool XorU8(ulong expect, ulong a, ulong b) { return expect == (a ^ b); } }";
            Assert.IsTrue((bool)Run<U8_U8_U8>("", "Test", "XorU8", (ulong)(a ^ b), a, b));
        }
    }
}
