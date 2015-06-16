﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dragon;

namespace UnitTests
{
    [TestClass]
    public class TestLexer
    {
        [TestMethod]
        public void TestTag()
        {
            Assert.AreEqual(256, Tag.AND);
            Assert.AreEqual(257, Tag.BASIC);
            Assert.AreEqual(258, Tag.BREAK);
            Assert.AreEqual(259, Tag.DO);
            Assert.AreEqual(260, Tag.ELSE);
            Assert.AreEqual(261, Tag.EQ);
            Assert.AreEqual(262, Tag.FALSE);
            Assert.AreEqual(263, Tag.GE);
            Assert.AreEqual(264, Tag.ID);
            Assert.AreEqual(265, Tag.IF);
            Assert.AreEqual(266, Tag.INDEX);
            Assert.AreEqual(267, Tag.LE);
            Assert.AreEqual(268, Tag.MINUS);
            Assert.AreEqual(269, Tag.NE);
            Assert.AreEqual(270, Tag.NUM);
            Assert.AreEqual(271, Tag.OR);
            Assert.AreEqual(272, Tag.REAL);
            Assert.AreEqual(273, Tag.TEMP);
            Assert.AreEqual(274, Tag.TRUE);
            Assert.AreEqual(275, Tag.WHILE);
        }

        [TestMethod]
        public void TestToken()
        {
            var tok_c = new Token('c');
            Assert.AreEqual('c', tok_c.TagValue);
            Assert.AreEqual("c", tok_c.ToString());

            var tok_9 = new Token('9');
            Assert.AreEqual('9', tok_9.TagValue);
            Assert.AreEqual("9", tok_9.ToString());
        }

        [TestMethod]
        public void TestNum()
        {
            var num_0 = new Num(0);
            Assert.AreEqual(Tag.NUM, num_0.TagValue);
            Assert.AreEqual(0, num_0.Value);

            var num_42 = new Num(42);
            Assert.AreEqual(Tag.NUM, num_42.TagValue);
            Assert.AreEqual(42, num_42.Value);

            var num_10000 = new Num(10000);
            Assert.AreEqual(Tag.NUM, num_10000.TagValue);
            Assert.AreEqual(10000, num_10000.Value);
        }
    }
}