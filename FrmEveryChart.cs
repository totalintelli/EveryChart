﻿using System;
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

            // 현재 그래프를 정한다.
            NewGraph.CurrentState = Graph.CurrentGraph.LineGraph;
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
            // X값의 최소값
            float XMin;
            // X값의 최대값
            float XMax;
            // Y값의 최소값
            float YMin;
            // Y값의 최대값
            float YMax;

            switch (NewGraph.CurrentState)
            {
                case Graph.CurrentGraph.None:
                    break;
                case Graph.CurrentGraph.LineGraph:
                    {
                        // X값의 최소값을 정의한다. 
                        XMin = 0;
                        // X값의 최대값을 정의한다.
                        XMax = 12;
                        // Y값의 최소값을 정의한다.
                        YMin = 0;
                        // Y값의 최대값을 정의한다.
                        YMax = 60;
                        // 꺾은 선 그래프를 그린다.
                        DrawLineGraph(e, XMin, XMax, YMin, YMax);
                    }
                    break;
                case Graph.CurrentGraph.BarGraph:
                    break;
                case Graph.CurrentGraph.CircleGraph:
                    break;
                case Graph.CurrentGraph.SpeacialGraph1:
                    break;
                case Graph.CurrentGraph.SpeacialGraph2:
                    break;
                default:
                    break;
            }
           
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

        private void DrawLineGraph(PaintEventArgs e, float XMin, float XMax, float YMin, float YMax)
        {
            // 긴 수평선의 시작점
            PointF LongHorizonStartPoint;
            // 긴 수평선의 끝점
            PointF LongHorizonEndPoint;
            // 선을 그리는 펜
            Pen LinePen = new Pen(Color.Blue, 1.0f);
            // 긴 수직선의 시작점
            PointF LongVerticalStartPoint;
            // 긴 수직선의 끝점
            PointF LongVerticalEndPoint;
            // 그래프 영역
            RectangleF GraphRect = new RectangleF(NewGraph.GraphMargin.Left, NewGraph.GraphMargin.Top, 
                                    panel1.Width - NewGraph.GraphMargin.Left - NewGraph.GraphMargin.Right, 
                                    panel1.Height - NewGraph.GraphMargin.Top - NewGraph.GraphMargin.Bottom);
            // 대각선의 시작점
            PointF DiagonalStartPoint;
            // 대각선의 끝점
            PointF DiagonalEndPoint;
            // 판매량 글자열
            String SalesVolume = "판매량";
            // 글자 폰트
            Font TextFont = new Font("Arial", 22);
            // 글자를 그리는 펜
            Brush TextBrush = Brushes.Teal;
            // 판매량의 위치
            PointF SalesVolumePoint;
            // 월 글자열
            String Month = "월";
            // 월의 위치
            PointF MonthPoint;
            // 가로 큰 눈금의 개수
            int BigHorizontalGridCount = Convert.ToInt32(Math.Round(System.Convert.ToDouble(XMax - XMin))) + 1;
            // 세로 큰 눈금의 개수
            int BigVertialGridCount = Convert.ToInt32(Math.Round(System.Convert.ToDouble(YMax - YMin))) / 10 + 1;
            // 가로 눈금의 개수
            int HorizontalGridCount = BigHorizontalGridCount;
            // 세로 눈금의 개수
            int VertalGridCount = BigVertialGridCount * 5;
            // 가로 눈금의 시작 위치
            PointF HorizontalGridStartPoint;
            // 가로 눈금의 끝 위치
            PointF HorizontalGridEndPoint;
            // 세로 눈금으 시작 위치
            PointF VertialGridStartPoint;
            // 세로 눈금의 끝 위치
            PointF VerticalGridEndPoint;
            // 숫자의 위치
            PointF NumberPoint;

            // 그리기 영역을 정의한다.
            NewGraph.DrawRect = new RectangleF(0, ButtonDockPanel.Height, panel1.Width, panel1.Height - ButtonDockPanel.Height);

            
            // 그래프 영역을 그리는 부분
            e.Graphics.DrawRectangle(LinePen, GraphRect.Left, GraphRect.Top, GraphRect.Width, GraphRect.Height);

            // 그래프 가로 눈금과 세로 눈금을 그리는 부분
            HorizontalGridStartPoint = new PointF(GraphRect.Left, GraphRect.Top + GraphRect.Height / VertalGridCount);
            HorizontalGridEndPoint = new PointF(GraphRect.Left + GraphRect.Width, GraphRect.Top + GraphRect.Height / VertalGridCount);
            NumberPoint = new PointF(GraphRect.Left - 50.0f, GraphRect.Top + GraphRect.Height * 3.0f/ VertalGridCount); // 50.0f와 3.0f는 글자의 위치를 설정하기 위한 값으로 고정값.
            for (int i = 0; i < BigVertialGridCount; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    LinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    if(j == 4)
                    {
                        LinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    }
                    // 가로 눈금를 그린다.
                    e.Graphics.DrawLine(LinePen, HorizontalGridStartPoint, HorizontalGridEndPoint);
                    HorizontalGridStartPoint.Y += GraphRect.Height / VertalGridCount;
                    HorizontalGridEndPoint.Y += GraphRect.Height / VertalGridCount;
                }
                if(i > 0)
                {
                    // 세로 눈금의 숫자를 그린다.
                    e.Graphics.DrawString(((BigVertialGridCount - i) * 10.0f).ToString(), TextFont, TextBrush, NumberPoint);
                    NumberPoint.Y += GraphRect.Height * 5.0f / VertalGridCount;
                }
            }

            // "(만 권)"을 그린다.
            e.Graphics.DrawString("(만 권)", TextFont, TextBrush, new PointF(GraphRect.Left - 100.0f, GraphRect.Top - GraphRect.Height / VertalGridCount)); // 100.0f는 글자의 위치를 설정하기 위한 값으로 고정값.               
            // "0"을 그린다.
            e.Graphics.DrawString("0", TextFont, TextBrush, new PointF(GraphRect.Left - 50.0f, 
                                                                        GraphRect.Top + GraphRect.Height * (VertalGridCount - 4.0f) / VertalGridCount));  // 50.0f와 4.0f는 글자의 위치를 설정하기 위한 값으로 고정값.

            // 그래프의 세로 눈금을 그리는 부분
            VertialGridStartPoint = new PointF(GraphRect.Left + GraphRect.Width / HorizontalGridCount, GraphRect.Top);
            VerticalGridEndPoint = new PointF(GraphRect.Left + GraphRect.Width / HorizontalGridCount, GraphRect.Top + GraphRect.Height);
            for (int i = 0; i < HorizontalGridCount; i++)
            {
               e.Graphics.DrawLine(LinePen, VertialGridStartPoint, VerticalGridEndPoint);
               VertialGridStartPoint.X += GraphRect.Width / HorizontalGridCount;
               VerticalGridEndPoint.X += GraphRect.Width / HorizontalGridCount;
            }

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

            // 대각선을 그리는 부분
            // 대각선의 시작점을 구한다.
            DiagonalStartPoint = new PointF(0, panel1.Height);
            // 대각선의 끝점을 구한다.
            DiagonalEndPoint = new PointF(GraphRect.Left, GraphRect.Bottom);
            // 대각선을 그린다.
            e.Graphics.DrawLine(LinePen, DiagonalStartPoint, DiagonalEndPoint);

            // 판매량의 위치를 구한다.
            SalesVolumePoint = NewGraph.RealPointToMathPoint(new PointF(10, 60));
            // "판매량"을 그리는 부분
            e.Graphics.DrawString(SalesVolume, TextFont, TextBrush, SalesVolumePoint);

            // 월의 위치를 구한다. 
            MonthPoint = NewGraph.RealPointToMathPoint(new PointF(150, 20));
            // "월"을 그리는 부분
            e.Graphics.DrawString(Month, TextFont, TextBrush, MonthPoint);
        }
    }
}
