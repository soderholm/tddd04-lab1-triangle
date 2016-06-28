using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Program;
using FluentAssertions;

namespace TriangleTest
{
    [TestClass]
    public class TriangleTester
    {

        public Triangle Triangle { get; set; }

        [TestInitialize]
        public void Setup() {
            Triangle = new Triangle();
        }

        [TestMethod]
        public void TestInvalid()
        {
            Triangle.Sides = new int[] {1,2,3};
            Action testInvalid = () => Triangle.DetectType();
            testInvalid.ShouldThrow<InvalidTriangleException>();
        }


    }
}
