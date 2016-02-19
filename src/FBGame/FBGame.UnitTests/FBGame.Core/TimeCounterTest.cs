//======================================================================
//
//        Copyright (C) 2016 Administrator    
//        All rights reserved 
//       
//        命名空间:  adccPC
//        CLR版本:   4.0.30319.42000
//        创建年份:  2016
// 
//        created by Administrator at 2016/2/18 16:18:54
//        本人博客：http://www.jianshu.com/users/86c7d3a175e3/latest_articles
//
//        描述说明：
//
//
//        修改历史：
//        --------------------------------------------------------------
//        Name    |    Date   |   Remark                               
//        --------------------------------------------------------------
//        
//        --------------------------------------------------------------
//
//        --------------------------------------------------------------
// 
//        --------------------------------------------------------------
//               
//        注:转载请保留此信息
//
//======================================================================

using System;
using NUnit.Framework;
using FBGame.Core.DomainServices;
using System.Threading;

namespace FBGame.UnitTests.FBGame.Core
{
    public class when_working_with_the_TimeCounter_start 
    { 
        protected ITimeCounter _timeCounter;
        protected int _time = 5;
        protected virtual void Because_of()
        {
            _timeCounter = new TimeCounter();
            _timeCounter.SetTime(_time);
            _timeCounter.Start();
        }

        protected void MockTimeCount(int timePoint)
        {
            int startTime = 0;
            while (startTime < timePoint)
            {
                _timeCounter.SetAutoEvent(true);
                startTime++;
                Thread.Sleep(1000);
                _timeCounter.SetAutoEvent(false);
            }
        }
    }

    [TestFixture]
    public class and_by_time_point :
        when_working_with_the_TimeCounter_start
    {
        private int _runningStatus = 1;
        private int _overStatus = 0;
        private Random _radom;
 
        [SetUp]
        protected override void Because_of()
        {
            base.Because_of();
            _radom = new Random();
        }

        [Test]
        public void which_in_the_time_then_TimeCounter_status_should_be_running()
        {
            int timePoint = _radom.Next(0, 5);
            base.MockTimeCount(timePoint);

            Assert.AreEqual(_runningStatus, base._timeCounter.GetCurrentStatus());
            Assert.AreEqual(string.Format("00:0{0}", timePoint), base._timeCounter.GetCurrentTimePointStr());
        }

        [Test]
        public void which_after_the_time_then_TimeCounter_status_should_be_over()
        {
            int timePoint = _radom.Next(6, 10);
            base.MockTimeCount(timePoint);

            Assert.AreEqual(_overStatus, base._timeCounter.GetCurrentStatus());
            Assert.AreEqual(string.Format("00:0{0}", base._time), base._timeCounter.GetCurrentTimePointStr());
        }
    }
}
