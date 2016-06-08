using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveryChart
{
    public partial class FrmEveryChart : Form
    {
        enum CurrentGraph
        {
            None = 0,           // 그래프가 없음.
            LineGraph = 1,      // 꺾은선 그래프.
            BarGraph = 2,       // 막대 그래프.
            CircleGraph = 3,    // 원 그래프.
            SpeacialGraph1 = 4, // 특수 그래프1.
            SpeacialGraph2 = 5  // 특수 그래프2.
        }

        // 그래프의 상태
        CurrentGraph CurrentState = CurrentGraph.None;

        public FrmEveryChart()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 꺽은 선 그래프를 그리는 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLineGraph_Click(object sender, EventArgs e)
        {
            // 현재 상태를 꺾은 선 그래프로 정한다.
            panel1.Invalidate();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // 실제 포인트 : 폼 위의 좌표
            PointF RealPoint;
            // X축 범위의 최소값
            float XMin = 0.0f;
            // X축 범위의 최대값
            float XMax = 10.0f;
            // Y축 범위의 최소값
            float YMin = 0.0f;
            // Y축 범위의 최대값
            float YMax = 10.0f;
            // 수학 포인트 : 원점이 폼의 왼쪽 하단인 포인트
            PointF MathicaPoint1 = new PointF();

            RealPoint = new PointF(panel1.Width / 2, panel1.Height / 2);

            // 수학 포인트를 구한다.
            MathicaPoint1 = MathPoint(RealPoint, XMin, XMax, YMin, YMax);

            // 수학 포인트의 좌표를 표시한다.
            e.Graphics.DrawString(RealPoint.X.ToString(), new Font("Gulim", 12), Brushes.Black, 10, 50);
            e.Graphics.DrawString(RealPoint.Y.ToString(), new Font("Gulim", 12), Brushes.Black, 10, 70);
            e.Graphics.DrawString(MathicaPoint1.X.ToString(), new Font("Gulim", 12), Brushes.Black, 10, 90);
            e.Graphics.DrawString(MathicaPoint1.Y.ToString(), new Font("Gulim", 12), Brushes.Black, 10, 110);
        }

        private PointF MathPoint(PointF RealPoint, float XMin, float XMax, float YMin, float YMax)
        {
            // 수학 포인트
            PointF MathPoint = new PointF();

            // 수학 포인트를 구한다.
            MathPoint.X = RealPoint.X * ((XMax - XMin) / panel1.Width);
            MathPoint.Y = ((panel1.Height - RealPoint.Y) / panel1.Height) * (YMax - YMin);

            return MathPoint;
        }
    }
}
