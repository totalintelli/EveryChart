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
        enum OriginPointPosition
        {
           LowerLeft = 0,  // 원점이 왼쪽 아래에 있는 경우
           LowerRight = 1, // 원점이 오른쪽 아래에 있는 경우
           UpperRight = 2, // 원점이 오른쪽 위에 있는 경우
           UpperLeft = 3   // 원점이 왼쪽 위에 있는 경우
        }

        enum CurrentGraph
        {
            None = 0,           // 그래프가 없음.
            LineGraph = 1,      // 꺾은선 그래프.
            BarGraph = 2,       // 막대 그래프.
            CircleGraph = 3,    // 원 그래프.
            SpeacialGraph1 = 4, // 특수 그래프1.
            SpeacialGraph2 = 5  // 특수 그래프2.
        }

        // 그래프의 원점의 위치
        OriginPointPosition CurrentOriginPoint = OriginPointPosition.LowerLeft;
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

            // 중점을 표시한다.
            e.Graphics.DrawLine(Pens.Blue, new PointF(0, 0), new PointF(panel1.Width, panel1.Height));
            e.Graphics.DrawLine(Pens.Blue, new PointF(panel1.Width, 0), new PointF(0, panel1.Height));

            //RealPoint = new PointF(panel1.Width / 2.0f, panel1.Height / 2.0f);
            //RealPoint = new PointF(0.0f, 0.0f);
            //RealPoint = new PointF(0.0f, ButtonDockPanel.Height);
            //RealPoint = new PointF(panel1.Width, ButtonDockPanel.Height);
            RealPoint = new PointF(panel1.Width, 0);

            // 수학 포인트를 구한다.
            MathicaPoint1 = MathPoint(RealPoint);
            // 수학 포인트의 좌표를 표시한다.
            e.Graphics.FillEllipse(Brushes.Red, MathicaPoint1.X, MathicaPoint1.Y, 10, 10);
        }

        private PointF MathPoint(PointF RealPoint)
        {
            // 수학 포인트
            PointF MathPoint = new PointF();

            switch (CurrentOriginPoint)
            {
                case OriginPointPosition.LowerLeft:
                    // 원점이 왼쪽 아래인 수학 포인트를 구한다.
                    MathPoint.X = RealPoint.X - 5;                  // 5는 점의 너비의 절반 값으로 원점의 X값을 정하기 위한 값.
                    MathPoint.Y = panel1.Height - RealPoint.Y - 5;  // 5는 점의 높이의 절반 값으로 원점의 Y값을 정하기 위한 값.
                    break;
                case OriginPointPosition.LowerRight:
                    break;
                case OriginPointPosition.UpperRight:
                    break;
                case OriginPointPosition.UpperLeft:
                    break;
                default:
                    break;
            }
            
            return MathPoint;
        }
    }
}
