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

            NewGraph.GraphMargin.Left = 200;
            NewGraph.GraphMargin.Top = 120;
            NewGraph.GraphMargin.Right = 10;
            NewGraph.GraphMargin.Bottom = 120;

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
            // 긴 수평선의 시작점
            PointF LongHorizonStartPoint;
            // 긴 수평선의 끝점
            PointF LongHorizonEndPoint;
            // 선을 그리는 펜
            Pen LinePen = Pens.Blue;
            // 긴 수직선의 시작점
            PointF LongVerticalStartPoint;
            // 긴 수직선의 끝점
            PointF LongVerticalEndPoint;
            // 그래프 영역
            RectangleF GraphRect = new RectangleF(NewGraph.GraphMargin.Left, NewGraph.GraphMargin.Top, 
                                    panel1.Width - NewGraph.GraphMargin.Left - NewGraph.GraphMargin.Right, 
                                    panel1.Height - NewGraph.GraphMargin.Top - NewGraph.GraphMargin.Bottom);

            // 그래프 영역을 정의한다.
            NewGraph.DrawRect = GraphRect;

            // 그래프 영역을 그리는 부분
            e.Graphics.DrawRectangle(LinePen, GraphRect.Left, GraphRect.Top, GraphRect.Width, GraphRect.Height);

            // 긴 수평선을 그리는 부분
            // 긴 수평선의 시작점을 구한다.
            LongHorizonStartPoint = new PointF(0, GraphRect.Top + GraphRect.Height);
            // 긴 수평선의 끝점의 실제 포인트의 좌표에서 긴 수평선의 끝점으로 바꾼다.
            LongHorizonEndPoint = new PointF(GraphRect.Right, GraphRect.Top + GraphRect.Height);
            // 긴 수평선을 그린다.
            e.Graphics.DrawLine(LinePen, LongHorizonStartPoint, LongHorizonEndPoint);

            // 긴 수직선을 그리는 부분
            // 긴 수직선의 시작점을 구한다.
            LongVerticalStartPoint = new PointF(GraphRect.Left, GraphRect.Top);
            // 긴 수직선의 끝점을 구한다.
            LongVerticalEndPoint = new PointF(GraphRect.Left, panel1.Height); 
            // 긴 수직선을 그린다.
            e.Graphics.DrawLine(LinePen, LongVerticalStartPoint, LongVerticalEndPoint);


        }
    }
}
