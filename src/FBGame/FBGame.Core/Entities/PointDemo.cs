//======================================================================
//
//        Copyright (C) 2016 home    
//        All rights reserved 
//       
//        命名空间:  FBGame.Core.Entities
//        CLR版本:   4.0.30319.42000
//        创建年份:  2016
// 
//        created by home at 2016/2/18 20:33:24
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBGame.Core.Entities
{
    public interface IPointDemo
    {
        double Xcoordinate { set; get; }
        double Ycoordinate { set; get; }
        IPointDemo GetNextPoint(double dir, double dis);
        double DistanceTo(IPointDemo point);
    }

    public class PointDemo : IPointDemo
    {
        public double Xcoordinate { get; set; }

        public double Ycoordinate { get; set; }

        public double DistanceTo(IPointDemo point)
        {
            return Math.Sqrt(Math.Pow(Xcoordinate - point.Xcoordinate, 2) + Math.Pow(Ycoordinate - point.Ycoordinate, 2));
        }

        public IPointDemo GetNextPoint(double dir, double dis)
        {
            return new PointDemo() { Xcoordinate = Xcoordinate + Math.Cos(dir) * dis, Ycoordinate = Ycoordinate + Math.Sin(dir) * dis };
        }
    }
}
