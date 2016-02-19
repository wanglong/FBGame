//======================================================================
//
//        Copyright (C) 2016 Administrator    
//        All rights reserved 
//       
//        命名空间:  adccPC
//        CLR版本:   4.0.30319.42000
//        创建年份:  2016
// 
//        created by Administrator at 2016/2/19 9:40:27
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
using System.Threading;

namespace FBGame.Core.DomainServices
{
    public interface ITimeCounter
    {
        int GetCurrentStatus();
        string GetCurrentTimePointStr();
        void SetAutoEvent(bool bSet);
        void SetTime(int time);
        void Start();
    }

    public class TimeCounter : ITimeCounter
    {
        private int _time;
        private int _status;
        private volatile int _currentPoint;
        private volatile string _currentPointStr;
        private object _mylock = new object();
        private Thread _timeThread;
        static AutoResetEvent _autoEvent = new AutoResetEvent(false);

        public TimeCounter()
        {
            _timeThread = new Thread(new ThreadStart(Run));
            _timeThread.IsBackground = true;
        }

        public void SetAutoEvent(bool bSet)
        {
            if (bSet)
                _autoEvent.Set();
            else
                _autoEvent.Reset();
        }

        public int GetCurrentStatus()
        {
            return _status;
        }

        public string GetCurrentTimePointStr()
        {
            return _currentPointStr;
        }

        public void SetTime(int time)
        {
            _time = time;
        }

        public void Start()
        {
            lock (_mylock)
            {
                _currentPoint = 0;
                _currentPointStr = ToFormateString(_currentPoint);
                _status = 1;
            }

            _timeThread.Start();
        }

        private void Run()
        {
            while (_currentPoint < _time)
            {
                _autoEvent.WaitOne();
                lock (_mylock)
                {
                    _currentPoint++;
                    _currentPointStr = ToFormateString(_currentPoint);
                }

                Thread.Sleep(1000);
            }

            lock (_mylock)
            {
                _status = 0;
            }
        }

        private string ToFormateString(int _currentPoint)
        {
            int minite = _currentPoint / 60;
            string mStr = TimeFormate(minite);
            int second = _currentPoint % 60;
            string sStr = TimeFormate(second);

            return string.Format("{0}:{1}", mStr, sStr);
        }

        private static string TimeFormate(int minite)
        {
            return minite > 10 ? minite.ToString() : string.Format("0{0}", minite);
        }
    }
}
