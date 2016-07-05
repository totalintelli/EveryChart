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

            // 현재 그래프를 정한다.
            NewGraph.CurrentState = Graph.CurrentGraph.LineGraph;
            // 현재 원점의 위치를 정한다.
            //NewGraph.CurrentOriginPoint = Graph.OriginPointPosition.LowerLeft;
            //NewGraph.CurrentOriginPoint = Graph.OriginPointPosition.UpperLeft;
            NewGraph.CurrentOriginPoint = Graph.OriginPointPosition.LowerRight;
            //NewGraph.CurrentOriginPoint = Graph.OriginPointPosition.UpperRight;

            // 실제 영역을 정한다.
            NewGraph.RealRect = new RectangleF(panel1.Left, panel1.Top, panel1.Width, panel1.Height);
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
            // 데이터들
            float[,] Data = new float[11, 2];
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
                        // 데이터들을 정의한다.
                        Data[0, 0] = 1;
                        Data[0, 1] = 23;
                        Data[1, 0] = 2;
                        Data[1, 1] = 32;
                        Data[2, 0] = 3;
                        Data[2, 1] = 50;
                        Data[3, 0] = 4;
                        Data[3, 1] = 44;
                        Data[4, 0] = 5;
                        Data[4, 1] = 52;
                        Data[5, 0] = 6;
                        Data[5, 1] = 49;
                        Data[6, 0] = 7;
                        Data[6, 1] = 38;
                        Data[7, 0] = 8;
                        Data[7, 1] = 36;
                        Data[8, 0] = 10;
                        Data[8, 1] = 57;
                        Data[9, 0] = 11;
                        Data[9, 1] = 51;
                        Data[10, 0] = 12;
                        Data[10, 1] = 55;
                        // 꺾은 선 그래프를 그린다.
                        DrawLineGraph(e, XMin, XMax, YMin, YMax, Data);
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
            // X값의 최소값
            float XMin = 0.0f;
            // X값의 최대값
            float XMax = 0.0f;
            // Y값의 최소값
            float YMin = 0.0f;
            // Y값의 최대값
            float YMax = 0.0f;

            // 수학 포인트의 X 좌표값을 표시한다.
            lbMathPointXValue.Text = NewGraph.GetMathPointXValue(XValue).ToString();

            // 수학 포인트의 Y 좌표값을 표시한다.
            lbMapthPointYValue.Text = NewGraph.GetMathPointYValue(YValue).ToString();

            switch (NewGraph.CurrentState)
            {
                case Graph.CurrentGraph.None:
                    break;
                case Graph.CurrentGraph.LineGraph:
                    NewGraph.DrawRect = new RectangleF(NewGraph.GraphMargin.Left, NewGraph.GraphMargin.Top,
                                    panel1.Width - NewGraph.GraphMargin.Left - NewGraph.GraphMargin.Right,
                                    panel1.Height - NewGraph.GraphMargin.Top - NewGraph.GraphMargin.Bottom);
                    XMin = 0.0f;
                    XMax = 13.0f;
                    YMin = 0.0f;
                    YMax = 70.0f;
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

            // 데이터의 X 값을 표시한다.
            lbXData.Text = NewGraph.XCoordinateToXData(XValue, XMin, XMax, NewGraph.DrawRect).ToString();
            // 데이터의 Y 값을 표시한다.
            lbYData.Text = NewGraph.YCoordinateToYData(YValue, YMin, YMax, NewGraph.DrawRect).ToString();
        }

        private void DrawLineGraph(PaintEventArgs e, float XMin, float XMax, float YMin, float YMax, float[,] Data)
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
            int BigVerticalGridCount = Convert.ToInt32(Math.Round(System.Convert.ToDouble(YMax - YMin))) / 10 + 1;
            // 가로 눈금의 개수
            int HorizontalGridCount = BigHorizontalGridCount;
            // 세로 눈금의 개수
            int VerticalGridCount = BigVerticalGridCount * 5;
            // 가로 눈금의 시작 위치
            PointF HorizontalGridStartPoint;
            // 가로 눈금의 끝 위치
            PointF HorizontalGridEndPoint;
            // 세로 눈금으 시작 위치
            PointF VerticalGridStartPoint;
            // 세로 눈금의 끝 위치
            PointF VerticalGridEndPoint;
            // 숫자의 위치
            PointF NumberPoint;
            // 점의 색상
            SolidBrush PointBrush = new SolidBrush(Color.Red);
            // 점을 그리는 사각형
            RectangleF DataPointRect;
            // 점의 반지름
            float PointRadius = 5.0f;
            // 점의 크기
            float PointSize = 10.0f;
            // X축 눈금 하나에 해당하는 값
            float OneGridXValue = 1.0f;
            // Y축 눈금 하나에 해당하는 값
            float OneGridYValue = 10.0f;
            // 선의 색상
            Pen DataLinePen = new Pen(Color.Red, 2.0f);
            // 선의 시작점
            PointF DataLineStartPoint;
            // 선의 끝점
            PointF DataLineEndPoint;

            // 그리기 영역을 정의한다.
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

            // 대각선을 그리는 부분
            // 대각선의 시작점을 구한다.
            DiagonalStartPoint = new PointF(0, panel1.Height);
            // 대각선의 끝점을 구한다.
            DiagonalEndPoint = new PointF(GraphRect.Left, GraphRect.Bottom);
            // 대각선을 그린다.
            e.Graphics.DrawLine(LinePen, DiagonalStartPoint, DiagonalEndPoint);

            // 판매량의 위치를 구한다.
            SalesVolumePoint = new PointF(10.0f, 450.0f); // 10.0f와 450.0f는 판매량의 위치에 대한 X값과 Y값으로 고정값.
            // "판매량"을 그리는 부분
            e.Graphics.DrawString(SalesVolume, TextFont, TextBrush, SalesVolumePoint);

            // 월의 위치를 구한다. 
            MonthPoint = new PointF(150.0f, 500.0f);      // 150.0f와 500.0f는 월의 위치에 대한 X값과 Y값으로 고정값.
            // "월"을 그리는 부분
            e.Graphics.DrawString(Month, TextFont, TextBrush, MonthPoint);

            switch (NewGraph.CurrentOriginPoint)
            {
                case Graph.OriginPointPosition.LowerLeft:
                    {
                        // 그래프 가로 눈금을 그리는 부분
                        HorizontalGridStartPoint = new PointF(GraphRect.Left, GraphRect.Top + GraphRect.Height / VerticalGridCount);
                        HorizontalGridEndPoint = new PointF(GraphRect.Left + GraphRect.Width, GraphRect.Top + GraphRect.Height / VerticalGridCount);
                        NumberPoint = new PointF(GraphRect.Left - 50.0f, GraphRect.Top + GraphRect.Height * 3.0f / VerticalGridCount); // 50.0f은 숫자의 X좌표 값을 설정하기 위한 값이고 3.0f는 숫자의 높이를 정하기 위한 값으로 고정값.
                        for (int i = 0; i < BigVerticalGridCount; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                LinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                                if (j == 4)
                                {
                                    LinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                                }
                                // 가로 눈금를 그린다.
                                e.Graphics.DrawLine(LinePen, HorizontalGridStartPoint, HorizontalGridEndPoint);
                                HorizontalGridStartPoint.Y += GraphRect.Height / VerticalGridCount;
                                HorizontalGridEndPoint.Y += GraphRect.Height / VerticalGridCount;
                            }
                            if (i > 0)
                            {
                                // 세로 눈금의 숫자를 그린다.
                                e.Graphics.DrawString(((BigVerticalGridCount - i) * 10.0f).ToString(), TextFont, TextBrush, NumberPoint);
                                NumberPoint.Y += GraphRect.Height * 5.0f / VerticalGridCount;
                            }
                        }

                        // "(만 권)"을 그린다.
                        e.Graphics.DrawString("(만 권)", TextFont, TextBrush, new PointF(GraphRect.Left - 100.0f, GraphRect.Top - GraphRect.Height / VerticalGridCount)); // 100.0f는 글자의 X좌표를 설정하기 위한 값으로 고정값.               
                           
                        // "0"을 그린다.
                        e.Graphics.DrawString("0", TextFont, TextBrush, new PointF(GraphRect.Left - 50.0f,
                                                                                    GraphRect.Top + GraphRect.Height * (VerticalGridCount - 4.0f) / VerticalGridCount)); // 50.0f은 "0"의 X좌표를, 4.0f는 "0"의 높이를 설정하기 위한 값으로 고정값.

                        // 그래프의 세로 눈금을 그리는 부분
                        VerticalGridStartPoint = new PointF(GraphRect.Left + GraphRect.Width / HorizontalGridCount, GraphRect.Top);
                        VerticalGridEndPoint = new PointF(GraphRect.Left + GraphRect.Width / HorizontalGridCount, GraphRect.Top + GraphRect.Height);
                        NumberPoint = new PointF(VerticalGridStartPoint.X - 15.0f, VerticalGridEndPoint.Y + GraphRect.Height / VerticalGridCount);                       // 15.0f는 숫자의 X좌표를 정하기 위한 값으로 고정 값.,
                        for (int i = 0; i < HorizontalGridCount; i++)
                        {
                            e.Graphics.DrawLine(LinePen, VerticalGridStartPoint, VerticalGridEndPoint);
                            if (i < HorizontalGridCount - 1)
                            {
                                e.Graphics.DrawString((i + 1).ToString(), TextFont, TextBrush, NumberPoint);
                                NumberPoint.X += GraphRect.Width / HorizontalGridCount;
                            }

                            VerticalGridStartPoint.X += GraphRect.Width / HorizontalGridCount;
                            VerticalGridEndPoint.X += GraphRect.Width / HorizontalGridCount;

                        }

                        // 그래프의 점을 그리는 부분
                        // 점을 그리는 사각형을 정의한다.
                        for (int i = 0; i < Data.GetLength(0); i++)
                        {
                            DataPointRect = new RectangleF(NewGraph.GetMathXPoint(Data[i, 0], XMin, XMax + OneGridXValue).X - PointRadius,
                                                                    NewGraph.GetMathYPoint(Data[i, 1], YMin, YMax + OneGridYValue).Y - PointRadius, PointSize, PointSize);
                            e.Graphics.FillEllipse(PointBrush, DataPointRect);
                        }
                        // 그래프의 선을 그리는 부분
                        for (int i = 0; i < Data.GetLength(0); i++)
                        {
                            DataLineStartPoint = new PointF(NewGraph.GetMathXPoint(Data[i, 0], XMin, XMax + OneGridXValue).X,
                                                                NewGraph.GetMathYPoint(Data[i, 1], YMin, YMax + OneGridYValue).Y);
                            if (i < Data.GetLength(0) - 1)
                            {
                                DataLineEndPoint = new PointF(NewGraph.GetMathXPoint(Data[i + 1, 0], XMin, XMax + OneGridXValue).X,
                                                                NewGraph.GetMathYPoint(Data[i + 1, 1], YMin, YMax + OneGridYValue).Y);
                                e.Graphics.DrawLine(DataLinePen, DataLineStartPoint, DataLineEndPoint);
                            }

                        }
                    }
                    break;
                case Graph.OriginPointPosition.LowerRight:
                    // 그래프 가로 눈금을 그리는 부분
                    HorizontalGridStartPoint = new PointF(GraphRect.Left, GraphRect.Top + GraphRect.Height / VerticalGridCount);
                    HorizontalGridEndPoint = new PointF(GraphRect.Left + GraphRect.Width, GraphRect.Top + GraphRect.Height / VerticalGridCount);
                    NumberPoint = new PointF(GraphRect.Left - 50.0f, GraphRect.Top + GraphRect.Height * 3.0f / VerticalGridCount); // 50.0f은 숫자의 X좌표 값을 설정하기 위한 값이고 3.0f는 숫자의 높이를 정하기 위한 값으로 고정값.
                    for (int i = 0; i < BigVerticalGridCount; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            LinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                            if (j == 4)
                            {
                                LinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                            }
                            // 가로 눈금를 그린다.
                            e.Graphics.DrawLine(LinePen, HorizontalGridStartPoint, HorizontalGridEndPoint);
                            HorizontalGridStartPoint.Y += GraphRect.Height / VerticalGridCount;
                            HorizontalGridEndPoint.Y += GraphRect.Height / VerticalGridCount;
                        }
                        if (i > 0)
                        {
                            // 세로 눈금의 숫자를 그린다.
                            e.Graphics.DrawString(((BigVerticalGridCount - i) * 10.0f).ToString(), TextFont, TextBrush, NumberPoint);
                            NumberPoint.Y += GraphRect.Height * 5.0f / VerticalGridCount;
                        }
                    }

                    // "(만 권)"을 그린다.
                    e.Graphics.DrawString("(만 권)", TextFont, TextBrush, new PointF(GraphRect.Left - 100.0f, GraphRect.Top - GraphRect.Height / VerticalGridCount)); // 100.0f는 글자의 X좌표를 설정하기 위한 값으로 고정값.               

                    // "0"을 그린다.
                    e.Graphics.DrawString("0", TextFont, TextBrush, new PointF(GraphRect.Left - 50.0f,
                                                                                GraphRect.Top + GraphRect.Height * (VerticalGridCount - 4.0f) / VerticalGridCount)); // 50.0f은 "0"의 X좌표를, 4.0f는 "0"의 높이를 설정하기 위한 값으로 고정값.
                    break;
                case Graph.OriginPointPosition.UpperRight:
            
                    break;
                case Graph.OriginPointPosition.UpperLeft:
                    {
                        // 그래프 가로 눈금을 그리는 부분
                        HorizontalGridStartPoint = new PointF(GraphRect.Left, GraphRect.Top + GraphRect.Height / VerticalGridCount);
                        HorizontalGridEndPoint = new PointF(GraphRect.Left + GraphRect.Width, GraphRect.Top + GraphRect.Height / VerticalGridCount);
                        NumberPoint = new PointF(GraphRect.Left - 50.0f, GraphRect.Top + GraphRect.Height * 3.0f / VerticalGridCount); // 50.0f은 숫자의 X좌표 값을 설정하기 위한 값이고 3.0f는 숫자의 높이를 정하기 위한 값으로 고정값.
                        for (int i = 0; i < BigVerticalGridCount; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                LinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                                if (j == 4)
                                {
                                    LinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                                }
                                // 가로 눈금를 그린다.
                                e.Graphics.DrawLine(LinePen, HorizontalGridStartPoint, HorizontalGridEndPoint);
                                HorizontalGridStartPoint.Y += GraphRect.Height / VerticalGridCount;
                                HorizontalGridEndPoint.Y += GraphRect.Height / VerticalGridCount;
                            }
                            if (i > 0)
                            {
                                // 세로 눈금의 숫자를 그린다.
                                e.Graphics.DrawString( (i * 10.0f).ToString(), TextFont, TextBrush, NumberPoint);
                                NumberPoint.Y += GraphRect.Height * 5.0f / VerticalGridCount;
                            }
                        }

                        // "(만 권)"을 그린다.
                        e.Graphics.DrawString("(만 권)", TextFont, TextBrush, new PointF(GraphRect.Left - 100.0f,
                                                                                    GraphRect.Top + GraphRect.Height * (VerticalGridCount - 4.0f) / VerticalGridCount));   // 50.0f은 "0"의 X좌표를, 4.0f는 "0"의 높이를 설정하기 위한 값으로 고정값.

                        // "0"을 그린다.
                        e.Graphics.DrawString("0", TextFont, TextBrush, new PointF(GraphRect.Left - 50.0f, GraphRect.Top - GraphRect.Height / VerticalGridCount)); // 100.0f는 글자의 X좌표를 설정하기 위한 값으로 고정값.

                        // 그래프의 세로 눈금을 그리는 부분
                        VerticalGridStartPoint = new PointF(GraphRect.Left + GraphRect.Width / HorizontalGridCount, GraphRect.Top);
                        VerticalGridEndPoint = new PointF(GraphRect.Left + GraphRect.Width / HorizontalGridCount, GraphRect.Top + GraphRect.Height);
                        NumberPoint = new PointF(VerticalGridStartPoint.X - 15.0f, VerticalGridEndPoint.Y + GraphRect.Height / VerticalGridCount);                       // 15.0f는 숫자의 X좌표를 정하기 위한 값으로 고정 값.,
                        for (int i = 0; i < HorizontalGridCount; i++)
                        {
                            e.Graphics.DrawLine(LinePen, VerticalGridStartPoint, VerticalGridEndPoint);
                            if (i < HorizontalGridCount - 1)
                            {
                                e.Graphics.DrawString((i + 1).ToString(), TextFont, TextBrush, NumberPoint);
                                NumberPoint.X += GraphRect.Width / HorizontalGridCount;
                            }

                            VerticalGridStartPoint.X += GraphRect.Width / HorizontalGridCount;
                            VerticalGridEndPoint.X += GraphRect.Width / HorizontalGridCount;

                        }

                        // 그래프의 점을 그리는 부분
                        // 점을 그리는 사각형을 정의한다.
                        for (int i = 0; i < Data.GetLength(0); i++)
                        {
                            DataPointRect = new RectangleF(NewGraph.GetMathXPoint(Data[i, 0], XMin, XMax + OneGridXValue).X - PointRadius,
                                                                    NewGraph.GetMathYPoint(Data[i, 1], YMin, YMax + OneGridYValue).Y - PointRadius, PointSize, PointSize);
                            e.Graphics.FillEllipse(PointBrush, DataPointRect);
                        }
                        // 그래프의 선을 그리는 부분
                        for (int i = 0; i < Data.GetLength(0); i++)
                        {
                            DataLineStartPoint = new PointF(NewGraph.GetMathXPoint(Data[i, 0], XMin, XMax + OneGridXValue).X,
                                                                NewGraph.GetMathYPoint(Data[i, 1], YMin, YMax + OneGridYValue).Y);
                            if (i < Data.GetLength(0) - 1)
                            {
                                DataLineEndPoint = new PointF(NewGraph.GetMathXPoint(Data[i + 1, 0], XMin, XMax + OneGridXValue).X,
                                                                NewGraph.GetMathYPoint(Data[i + 1, 1], YMin, YMax + OneGridYValue).Y);
                                e.Graphics.DrawLine(DataLinePen, DataLineStartPoint, DataLineEndPoint);
                            }

                        }
                    }
                    break;
                default:
                    break;
            }

            

            
        }
    }
}
