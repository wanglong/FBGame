using FBGame.Core.Entities;
using Moq;
using NUnit.Framework;
using System;

namespace FBGame.UnitTests.FBGame.Core
{
    [TestFixture]
    public class LineSegmentTest
    {
        private IPointDemo endpoint;
        private IPointDemo startpoint;

        [SetUp]
        public void SetUpforTest()
        {
            startpoint = newMockPoint();
            endpoint = newMockPoint();
        }

        private IPointDemo newMockPoint()
        {
            var point1 = new Mock<IPointDemo>().SetupAllProperties();
            point1.Setup( z => z.DistanceTo(It.IsAny<IPointDemo>()))
                .Callback(x=> x = );
            point1.Setup(x => x.GetNextPoint(It.IsAny<double>(), It.IsAny<double>())).Returns(new PointDemo() { Xcoordinate = 10, Ycoordinate = 10 });
            return point1.Object;
        }

        [Test]
        public void ToListTest_Normal()
        {
            endpoint.Xcoordinate = 100;
            endpoint.Ycoordinate = 100;
            startpoint.Xcoordinate = 100;
            startpoint.Ycoordinate = 200;

            LineSegment line = new LineSegment() { StartPoint = startpoint, EndPoint = endpoint, Precision = 1 };
            int count = line.ToList().Count;

            Assert.AreEqual(100, count);
        }
    }
}
