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
            // 그래프의 마진
            Padding GraphMargin = new Padding(panel1.Width / 4, ButtonDockPanel.Height + (panel1.Height - ButtonDockPanel.Height) * 1 / 10, 
                                                10, (panel1.Height - ButtonDockPanel.Height) * 2 / 10);
            // 실제 포인트 : 폼 위의 좌표
            PointF RealPoint;
            // 그래프 포인트 : 그래프에 있는 포인트
            PointF GraphPoint = new PointF();
            // 데이터 값
            float Value;
            // 데이터의 최소값
            float Min;
            // 데이터의 최대값
            float Max;
            // X값 여부
            bool IsX = false;
            // 그래프 포인트를 둘러싸는 사각형
            RectangleF GraphPointRect = new RectangleF(0, 0 , 10, 10);

            RealPoint = new PointF(ButtonDockPanel.Width, ButtonDockPanel.Height);

            CurrentOriginPoint = OriginPointPosition.LowerLeft;

            // 데이터 값을 정의한다.
            //Value = 23;
            Value = 1;
            // 최소값을 정의한다.
            Min = 0;
            // 최대값을 정의한다.
            //Max = 70;
            Max = 13;
            // X값 여부를 정한다.
            //IsX = false;
            IsX = true;
            // 그래프 포인트를 구한다.
            GraphPoint = GetGraphPoint(Value, Min, Max, IsX, GraphMargin);
            GraphPointRect.X = GraphPoint.X;
            GraphPointRect.Y = GraphPoint.Y;
            // 그래프 포인트를 표시한다.
            e.Graphics.FillEllipse(Brushes.Red, GraphPointRect);

        }

        private PointF GetMathPoint(PointF RealPoint)
        {
            // 수학 포인트
            PointF MathPoint = new PointF();

            switch (CurrentOriginPoint)
            {
                case OriginPointPosition.LowerLeft:
                    // 원점이 왼쪽 아래인 수학 포인트를 구한다.
                    MathPoint.X = RealPoint.X - 5;                 // 5는 점의 너비의 절반 값으로 원점의 X값을 정하기 위한 값.
                    MathPoint.Y = panel1.Height - RealPoint.Y - 5; // 5는 점의 높이의 절반 값으로 원점의 Y값을 정하기 위한 값.
                    break;
                case OriginPointPosition.LowerRight:
                    // 원점이 오른쪽 아래인 수학 포인트를 구한다.
                    MathPoint.X = panel1.Width - RealPoint.X - 5;  // 5는 점의 너비의 절반 값으로 원점의 X값을 정하기 위한 값.
                    MathPoint.Y = panel1.Height - RealPoint.Y - 5; // 5는 점의 너비의 절반 값으로 원점의 Y값을 정하기 위한 값.
                    break;
                case OriginPointPosition.UpperRight:
                    // 원점이 오른쪽 위인 수학 포인트를 구한다.
                    MathPoint.X = panel1.Width - RealPoint.X - 5;  // 5는 점의 너비의 절반 값으로 원점의 X값을 정하기 위한 값.
                    MathPoint.Y = RealPoint.Y - 5; // 5는 점의 너비의 절반 값으로 원점의 Y값을 정하기 위한 값.
                    break;
                case OriginPointPosition.UpperLeft:
                    // 원점이 왼쪽 위인 수학 포인트를 구한다.
                    MathPoint.X = RealPoint.X - 5;                // 5는 점의 너비의 절반 값으로 원점의 X값을 정하기 위한 값.
                    MathPoint.Y = RealPoint.Y - 5;                // 5는 점의 너비의 절반 값으로 원점의 Y값을 정하기 위한 값.
                    break;
                default:
                    break;
            }
            
            return MathPoint;
        }

        private PointF GetGraphPoint(float Value, float Min, float Max, bool IsX, Padding GraphMargin)
        {
            PointF GraphPoint = new PointF();
            PointF RealPoint = new PointF();

            // 값이 최소값보다 크고 최대값보다 작은지 확인한다.
            if(Value >= Min && Value <= Max)
            {
                // 맞으면, X값인지 확인한다.
                if (IsX)
                {
                    // X값이면 실제 포인트의 X값을 구한다.
                    RealPoint.X = GraphMargin.Left + ((panel1.Width - GraphMargin.Left - GraphMargin.Right) * Value) / (Max - Min);
                    RealPoint.Y = 0;
                }
                else
                {
                    RealPoint.X = 0;
                    // X값이 아니면 실제 포인트의 Y값을 구한다.
                    RealPoint.Y = GraphMargin.Top + ((panel1.Height - GraphMargin.Top - GraphMargin.Bottom) * Value) / (Max - Min);
                }
            }

            GraphPoint = GetMathPoint(RealPoint);

            return GraphPoint;
        }
    }
}
