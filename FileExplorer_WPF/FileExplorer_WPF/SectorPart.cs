using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FileExplorer_WPF
{
    /// <summary>
    /// 参考地址：https://www.cnblogs.com/yiyan127/p/WPF-Simple-PieChart.html
    /// 扇形
    /// </summary>
    public class SectorPart
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="spanAngle">跨越角度</param>
        /// <param name="fillBrush">填充画刷</param>
        public SectorPart(double spanAngle, Brush fillBrush)
        {
            this.SpanAngle = spanAngle;
            this.FillBrush = fillBrush;
        }

        /// <summary>
        /// 跨越角度,单位为角度,取值范围为0到360
        /// </summary>
        public double SpanAngle { get; set; }

        /// <summary>
        /// 填充画刷
        /// </summary>
        public Brush FillBrush { get; set; }
    }

}
