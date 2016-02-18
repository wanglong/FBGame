//======================================================================
//
//        Copyright (C) 2016 home    
//        All rights reserved 
//       
//        命名空间:  FBGame.Core.Entities
//        CLR版本:   4.0.30319.42000
//        创建年份:  2016
// 
//        created by home at 2016/2/18 20:38:49
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
using System.Collections.Generic;

namespace FBGame.Core.Entities
{
    public class LineSegment
    {
        public IPointDemo StartPoint { set; get; }
        public IPointDemo EndPoint { set; get; }

        public double Precision { set; get; }
        public List<IPointDemo> ToList()
        {
            double length = StartPoint.DistanceTo(EndPoint);
            int num = Convert.ToInt16(Math.Floor(length / Precision));
            List<IPointDemo> pointList = new List<IPointDemo>();
            for (int i = 0; i <= num; i++)
            {
                pointList.Add(StartPoint.GetNextPoint(Math.Atan2(EndPoint.Ycoordinate - StartPoint.Ycoordinate, EndPoint.Xcoordinate - StartPoint.Xcoordinate), Precision * i));
            }

            return pointList;
        }
    }
}
