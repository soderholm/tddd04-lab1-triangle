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


        [TestCleanup]
        public void Cleanup()
        {
            Triangle.Sides = null;
        }
        

        [TestMethod]
        public void TestInvalid()
        {
            Triangle.Sides = new int[] {1,2,3};
            Action testInvalid = () => Triangle.DetectType();
            testInvalid.ShouldThrow<InvalidTriangleException>();
        }

        [TestMethod]
        public void TestWrongArraySize()
        {
            Triangle.Sides = new int[] { 2, 2};
            Action testInvalid = () => Triangle.DetectType();
            testInvalid.ShouldThrow<InvalidTriangleException>();
        }


        [TestMethod]
        public void TestEquilateral()
        {
            Triangle.Sides = new int[] { 1, 1, 1 };
            Assert.AreEqual(Triangle.TriangleType.EQUILATERAL, Triangle.DetectType());
        }

        [TestMethod]
        public void TestIsosceles()
        {
            Triangle.Sides = new int[] { 2, 2, 1 };
            Assert.AreEqual(Triangle.TriangleType.ISOSCELES, Triangle.DetectType());
        }

        [TestMethod]
        public void TestScalene()
        {
            Triangle.Sides = new int[] { 2, 3, 4 };
            Assert.AreEqual(Triangle.TriangleType.SCALENE, Triangle.DetectType());
        }



        [TestMethod]
        public void TestNegativeInput()
        {
            Triangle.Sides = new int[] { -2, 3, 4 };
            Action testNegativeInput = () => Triangle.DetectType();
            testNegativeInput.ShouldThrow<InvalidTriangleException>();
        }


    }
}
