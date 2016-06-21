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
        // 그래프 객체
        Graph NewGraph = new Graph();

        public FrmEveryChart()
        {
            InitializeComponent();

            NewGraph.GraphMargin.Left = 54;
            NewGraph.GraphMargin.Top = 49;
            NewGraph.GraphMargin.Right = 10;

            // 현재 원점의 위치를 정한다.
            NewGraph.CurrentOriginPoint = Graph.OriginPointPosition.LowerLeft;
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
            // 수학 포인트 : 실제 포인트를 원점의 위치에 맞게 변환한 포인트
            PointF MathPoint = new PointF();
            // 그래프 포인트 : 그래프에 있는 포인트
            PointF GraphPoint = new PointF();
            // 데이터 값
            float Value;
            // 데이터의 최소값
            float Min;
            // 데이터의 최대값
            float Max;
            // 수학 포인트를 둘러싸는 사각형
            RectangleF MathPointRect = new RectangleF(0, 0, 10, 10);
            // 그래프 포인트를 둘러싸는 사각형
            RectangleF GraphPointRect = new RectangleF(0, 0 , 10, 10);

            // 그리는 위치를 정한다.
            NewGraph.DrawRect = new RectangleF(0, ButtonDockPanel.Height, panel1.Width, panel1.Height);

            // 컴퓨터가 인식하는 포인트를 초기화한다.
            RealPoint = new PointF(700, 500);

            // 컴퓨터의 좌표에서 수학 포인트로 바꾼다.
            MathPoint = NewGraph.RealPointToMathPoint(RealPoint);
            MathPointRect.X = MathPoint.X - MathPointRect.Width * 0.5f;  // 0.5f는 점의 너비의 절반 값으로 원점의 X값을 정하기 위한 값.
            MathPointRect.Y = MathPoint.Y - MathPointRect.Height * 0.5f; // 0.5f는 점의 높이의 절반 값으로 원점의 Y값을 정하기 위한 값.

            // 그래프 포인트를 표시한다.
            e.Graphics.FillEllipse(Brushes.Black, MathPointRect);

            // 데이터 값을 정의한다.
            Value = 23;
            //Value = 1;
            // 최소값을 정의한다.
            Min = 0;
            // 최대값을 정의한다.
            Max = 70;
            //Max = 13;
            // 그래프 포인트를 구한다.
            //GraphPoint = NewGraph.GetMathXPoint(Value, Min, Max);
            GraphPoint = NewGraph.GetMathYPoint(Value, Min, Max);
            GraphPointRect.X = GraphPoint.X - MathPointRect.Width * 0.5f;
            GraphPointRect.Y = GraphPoint.Y - MathPointRect.Height * 0.5f;

            // 그래프 포인트를 표시한다.
            e.Graphics.FillEllipse(Brushes.Red, GraphPointRect);

            // 꺾은 선 그래프를 그린다.
            DrawLineGraph(e);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            // 마우스 커서가 가리키는 위치의 X값
            int XValue = e.X;
            // 마우스 커서가 가리키는 위치의 Y값
            int YValue = e.Y;

            // 수학 포인트의 X 좌표값을 표시한다.
            lbMathPointXValue.Text = NewGraph.GetMathPointXValue(XValue).ToString();

            // 수학 포인트의 Y 좌표값을 표시한다.
            lbMapthPointYValue.Text = NewGraph.GetMathPointYValue(YValue).ToString();

            // 데이터의 X 값을 표시한다.
            lbXData.Text = NewGraph.XCoordinateToXData(XValue, 0, 12, NewGraph.DrawRect).ToString();
            // 데이터의 Y 값을 표시한다.
            lbYData.Text = NewGraph.XCoordinateToXData(YValue, 0, 60, NewGraph.DrawRect).ToString();
        }

        private void DrawLineGraph(PaintEventArgs e)
        {
            // 긴 수평선의 시작점의 실제 포인트 : 폼 위의 좌표
            PointF LongHorizonStartRealPoint;
            // 긴 수평선의 끝점의 실제 포인트
            PointF LongHorizonEndRealPoint;
            // 긴 수평선의 시작점
            PointF LongHorizonStartPoint = new PointF();
            // 긴 수평선의 끝점
            PointF LongHorizonEndPoint = new PointF();
            // 선을 그리는 펜
            Pen LinePen = Pens.Blue;

            // 긴 수평선을 그리는 부분
            // 긴 수평선의 시작점의 실제 포인트를 초기화한다.
            LongHorizonStartRealPoint = new PointF(0, ButtonDockPanel.Height * 2.5f);                                       // 2.5f는 긴 수평선을 그리기 위해 정한 값.
            // 긴 수평선의 시작점의 실제 포인트의 좌표에서 긴 수평선의 시작점으로 바꾼다.
            LongHorizonStartPoint = NewGraph.RealPointToMathPoint(LongHorizonStartRealPoint);
            // 긴 수평선의 끝점의 실제 포인트를 초기화한다.
            LongHorizonEndRealPoint = new PointF(panel1.Width - NewGraph.GraphMargin.Right, ButtonDockPanel.Height * 2.5f); // 2.5f는 긴 수평선을 그리기 위해 정한 값.
            // 긴 수평선의 끝점의 실제 포인트의 좌표에서 긴 수평선의 끝점으로 바꾼다.
            LongHorizonEndPoint = NewGraph.RealPointToMathPoint(LongHorizonEndRealPoint);
            // 긴 수평선을 그린다.
            e.Graphics.DrawLine(LinePen, LongHorizonStartPoint, LongHorizonEndPoint);

            // 긴 수직선을 그리는 부분
        }
    }
}
