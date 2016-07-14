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

            // 그래프를 초기화한다.
            NewGraph.CurrentState = Graph.CurrentGraph.LineGraph;

            // 원점의 위치를 초기화한다.
            NewGraph.CurrentOriginPoint = Graph.OriginPointPosition.LowerLeft;

            // 실제 영역을 정한다.
            NewGraph.RealRect = new RectangleF(panel1.Left, panel1.Top, panel1.Width, panel1.Height);

            // 콤보박스 초기화
            cbGraph.Text = "LineGraph";
            cbGraph.SelectedIndex = 0;
            cbOriginPoint.Text = "LowerLeft";
            cbOriginPoint.SelectedIndex = 0;

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

        private void cbGraph_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbGraph.SelectedIndex)
            {
                case 0:
                    {
                        NewGraph.CurrentState = Graph.CurrentGraph.LineGraph;
                        panel1.Invalidate();
                    }
                    break;
                case 1:
                    {
                        NewGraph.CurrentState = Graph.CurrentGraph.BarGraph;
                        panel1.Invalidate();
                    }
                    break;
                case 2:
                    {
                        NewGraph.CurrentState = Graph.CurrentGraph.PieChart;
                        panel1.Invalidate();
                    }
                    break;
                case 3:
                    {
                        NewGraph.CurrentState = Graph.CurrentGraph.SpeacialGraph1;
                        panel1.Invalidate();
                    }
                    break;
                case 4:
                    {
                        NewGraph.CurrentState = Graph.CurrentGraph.SpeacialGraph2;
                        panel1.Invalidate();
                    }
                    break;
                default:
                    break;
            }
        }

        private void cbOrigin_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbOriginPoint.SelectedIndex)
            {
                case 0:
                    {
                        NewGraph.CurrentOriginPoint = Graph.OriginPointPosition.LowerLeft;
                        panel1.Invalidate();
                    }
                    break;
                case 1:
                    {
                        NewGraph.CurrentOriginPoint = Graph.OriginPointPosition.LowerRight;
                        panel1.Invalidate();
                    }
                    break;
                case 2:
                    {
                        NewGraph.CurrentOriginPoint = Graph.OriginPointPosition.UpperLeft;
                        panel1.Invalidate();
                    }
                    break;
                case 3:
                    {
                        NewGraph.CurrentOriginPoint = Graph.OriginPointPosition.UpperRight;
                        panel1.Invalidate();
                    }
                    break;
                default:
                    break;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // 실제 영역을 정한다.
            NewGraph.RealRect = new RectangleF(panel1.Left, panel1.Top, panel1.Width, panel1.Height);

            switch (NewGraph.CurrentState)
            {
                case Graph.CurrentGraph.None:
                    break;
                case Graph.CurrentGraph.LineGraph:
                    {
                        // 그래프를 정한다.
                        NewGraph.CurrentState = Graph.CurrentGraph.LineGraph;

                        // 그래프의 마진을 정한다.
                        NewGraph.GraphMargin.Left = 200;
                        NewGraph.GraphMargin.Top = 120;
                        NewGraph.GraphMargin.Right = 10;
                        NewGraph.GraphMargin.Bottom = 120;

                        // X값의 최소값을 정의한다. 
                        NewGraph.XMin = 0;
                        // X값의 최대값을 정의한다.
                        NewGraph.XMax = 12;
                        // Y값의 최소값을 정의한다.
                        NewGraph.YMin = 0;
                        // Y값의 최대값을 정의한다.
                        NewGraph.YMax = 60;

                        // X축 눈금의 개수
                        NewGraph.BigHorizontalGridCount = Convert.ToInt32(Math.Round(System.Convert.ToDouble((NewGraph.XMax - NewGraph.XMin) / NewGraph.OneGridXValue))) + 1;
                        // X축 눈금의 개수
                        NewGraph.HorizontalGridCount = NewGraph.BigHorizontalGridCount;

                        // 데이터를 가져온다.
                        GetData(NewGraph);

                        // 꺾은 선 그래프를 그린다.
                        DrawLineGraph(NewGraph, e);

                    }
                    break;
                case Graph.CurrentGraph.BarGraph:
                    {
                        // 그래프의 마진을 정한다.
                        NewGraph.GraphMargin.Left = 120;
                        NewGraph.GraphMargin.Top = 120;
                        NewGraph.GraphMargin.Right = 10;
                        NewGraph.GraphMargin.Bottom = 50;
                        // X값의 최소값을 정의한다. 
                        NewGraph.XMin = 2005;
                        // X값의 최대값을 정의한다. 
                        NewGraph.XMax = 2009;
                        // Y값의 최소값을 정의한다.
                        NewGraph.YMin = 0;
                        // Y값의 최대값을 정의한다.
                        NewGraph.YMax = 7000;

                        // X축 눈금의 개수
                        NewGraph.BigHorizontalGridCount = Convert.ToInt32(Math.Round(System.Convert.ToDouble((NewGraph.XMax - NewGraph.XMin) / NewGraph.OneGridXValue))) + 1;
                        // X축 눈금의 개수
                        NewGraph.HorizontalGridCount = NewGraph.BigHorizontalGridCount;

                        // 데이터를 가져온다.
                        GetData(NewGraph);

                        // 막대 그래프를 그린다.
                        DrawBarGraph(NewGraph, e);
                    }
                    break;
                case Graph.CurrentGraph.PieChart:
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
                case Graph.CurrentGraph.PieChart:
                    break;
                case Graph.CurrentGraph.SpeacialGraph1:
                    break;
                case Graph.CurrentGraph.SpeacialGraph2:
                    break;
                default:
                    break;
            }

            // 데이터의 X 값을 표시한다.
            lbXData.Text = Math.Round(System.Convert.ToDouble(NewGraph.XCoordinateToXData(XValue, XMin, XMax, NewGraph.DrawRect)), 1).ToString();
            // 데이터의 Y 값을 표시한다.
            lbYData.Text = Math.Round(System.Convert.ToDouble(NewGraph.YCoordinateToYData(YValue, YMin, YMax, NewGraph.DrawRect)), 1).ToString();
        }

        private void DrawLineGraph(Graph NewGraph, PaintEventArgs e)
        {

            // 선을 그리는 펜
            Pen LinePen = new Pen(Color.Blue, 1.0f);

            // 그래프 영역
            RectangleF DrawRect = new RectangleF(NewGraph.GraphMargin.Left, NewGraph.GraphMargin.Top,
                                    panel1.Width - NewGraph.GraphMargin.Left - NewGraph.GraphMargin.Right,
                                    panel1.Height - NewGraph.GraphMargin.Top - NewGraph.GraphMargin.Bottom);
            #region 글자
            // 글자 폰트
            Font TextFont = new Font("Arial", 22);
            // 글자를 그리는 펜
            Brush TextBrush = Brushes.Teal;
            #endregion

            #region 그래프
            // 점의 색상
            NewGraph.PointBrush = new SolidBrush(Color.Red);
            // 점의 반지름
            NewGraph.PointRadius = 5.0f;
            // 점의 크기
            NewGraph.PointSize = 10.0f;
            // 선의 색상
            NewGraph.DataLinePen = new Pen(Color.Red, 2.0f);
            #endregion


            // X축 눈금 하나에 해당하는 값
            NewGraph.OneGridXValue = 1.0f;

            // Y축 눈금 하나에 해당하는 값
            NewGraph.OneGridYValue = 10.0f;

            // 그리기 영역을 정의한다.
            NewGraph.DrawRect = DrawRect;

            // 그래프의 제목을 그린다.
            e.Graphics.DrawString("월별 책의 판매량", TextFont, new SolidBrush(Color.Blue),
                new PointF(NewGraph.RealRect.Width * 0.5f, NewGraph.GraphMargin.Top * 0.6f));

            // 그래프 영역을 그리는 부분
            e.Graphics.DrawRectangle(LinePen, DrawRect.Left, DrawRect.Top, DrawRect.Width, DrawRect.Height);

            // 긴 수평선을 그린다.
            e.Graphics.DrawLine(LinePen, new PointF(0, DrawRect.Top + DrawRect.Height),
                new PointF(DrawRect.Right, DrawRect.Top + DrawRect.Height));

            // 긴 수직선을 그린다.
            e.Graphics.DrawLine(LinePen, new PointF(DrawRect.Left, DrawRect.Top), new PointF(DrawRect.Left, panel1.Height));

            // 대각선을 그린다.
            e.Graphics.DrawLine(LinePen, new PointF(0, panel1.Height), new PointF(DrawRect.Left, DrawRect.Bottom));

            // "판매량"을 그리는 부분
            e.Graphics.DrawString("판매량", TextFont, TextBrush, new PointF(NewGraph.GraphMargin.Left / 15.0f, // 15.0f : "판매량" 위치의 X값을 구하기 위한 값.
                                                                                NewGraph.GraphMargin.Top + DrawRect.Height + 10.0f)); // 10.0f : "판매량"의 높이를 맞추기 위한 값.

            // "월"을 그리는 부분
            e.Graphics.DrawString("월", TextFont, TextBrush, new PointF(NewGraph.GraphMargin.Left * 7.5f / 10.0f, // 7.5f / 10.0f : "월"의 위치의 X값을 구하기 위한 값.
                                                                         NewGraph.GraphMargin.Top + DrawRect.Height
                                                                         + NewGraph.GraphMargin.Bottom * 0.5f)); // 0.5f : "월"의 위치의 Y값을 구하기 위한 값.

            #region X축 눈금
            // 그래프의 세로 눈금을 그리는 부분
            NewGraph.VerticalGridStartPoint = new PointF(DrawRect.Left + DrawRect.Width / NewGraph.HorizontalGridCount, DrawRect.Top);
            NewGraph.VerticalGridEndPoint = new PointF(DrawRect.Left + DrawRect.Width / NewGraph.HorizontalGridCount, DrawRect.Top + DrawRect.Height);
            // X축 눈금의 숫자의 위치를 구한다.
            NewGraph.VerticalGridNumberPoint = new PointF(NewGraph.VerticalGridStartPoint.X - 15.0f,
                                                            NewGraph.VerticalGridEndPoint.Y
                                                             + (NewGraph.DrawRect.Height / NewGraph.HorizontalGridCount) * 0.3f); // 15.0f는 숫자의 X좌표를 정하기 위한 값으로 고정 값.            
            #endregion

            #region Y축 눈금
            // Y축 큰 눈금의 개수
            NewGraph.BigVerticalGridCount = Convert.ToInt32(Math.Round(System.Convert.ToDouble((NewGraph.YMax - NewGraph.YMin) / NewGraph.OneGridYValue))) + 1;
            // Y축 눈금의 개수
            NewGraph.VerticalGridCount = NewGraph.BigVerticalGridCount * 5; // 5 : 큰 눈금들 사이에 있는 눈금의 개수
            // 그래프의 X축의 시작점과 끝점을 정한다.
            NewGraph.HorizontalGridStartPoint = new PointF(DrawRect.Left, DrawRect.Top + DrawRect.Height / NewGraph.VerticalGridCount);
            NewGraph.HorizontalGridEndPoint = new PointF(DrawRect.Left + DrawRect.Width, DrawRect.Top + DrawRect.Height / NewGraph.VerticalGridCount);
            // Y축 눈금의 숫자의 위치를 구한다.
            NewGraph.HorizontalGridNumberPoint = new PointF(DrawRect.Left - 50.0f,
                DrawRect.Top + DrawRect.Height * 3.0f / NewGraph.VerticalGridCount); // 50.0f은 숫자의 X좌표 값을 설정하기 위한 값이고 3.0f는 숫자의 높이를 정하기 위한 값으로 고정값.
            #endregion

            // 그래프의 가로 눈금을 그린다.
            DrawHorizontalGrid(NewGraph, LinePen, TextFont, TextBrush, e);

            // 그래프의 세로 눈금을 그린다.
            DrawVerticalGrid(NewGraph, LinePen, TextFont, TextBrush, e);

            // 그래프의 점을 그린다.
            DrawGraphPoint(NewGraph, e);

            // 그래프의 선을 그린다.
            DrawGraphLine(NewGraph, e);

            // 데이터를 초기화한다.
            NewGraph.DataList.Clear();
        }

        private void DrawHorizontalGrid(Graph NewGraph, Pen LinePen, Font TextFont, Brush TextBrush, PaintEventArgs e)
        {

            switch (NewGraph.CurrentState)
            {
                case Graph.CurrentGraph.None:
                    break;
                case Graph.CurrentGraph.LineGraph:
                    {
                        // 그래프의 원점의 위치에 따른 Y축 눈금의 첫 번째 숫자를 구한다.
                        if (NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.LowerLeft || NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.LowerRight)
                        {
                            NewGraph.HorizontalGridNumber = NewGraph.BigVerticalGridCount - 1; // 꼭대기에 있는 Y축 눈금에 해당하는 숫자를 그리지 않기 위해서 1을 뺌.
                        }
                        else
                        {
                            NewGraph.HorizontalGridNumber = 1;
                        }

                        for (int i = 0; i < NewGraph.BigVerticalGridCount; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                LinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                                if (j == 4)
                                {
                                    LinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                                }
                                // 그래프의 가로 눈금를 그린다.
                                e.Graphics.DrawLine(LinePen, NewGraph.HorizontalGridStartPoint, NewGraph.HorizontalGridEndPoint);
                                NewGraph.HorizontalGridStartPoint.Y += NewGraph.DrawRect.Height / NewGraph.VerticalGridCount;
                                NewGraph.HorizontalGridEndPoint.Y += NewGraph.DrawRect.Height / NewGraph.VerticalGridCount;
                            }

                            if (i > 0) // 원점에 "0"을 중복해서 그리지 않는다.
                            {
                                // 가로 눈금의 숫자를 그린다.
                                e.Graphics.DrawString((NewGraph.HorizontalGridNumber * NewGraph.OneGridYValue).ToString(), TextFont, TextBrush, NewGraph.HorizontalGridNumberPoint);
                                NewGraph.HorizontalGridNumberPoint.Y += NewGraph.DrawRect.Height / NewGraph.VerticalGridCount * 5.0f; // 눈금의 숫자를 그리는 위치를 작은 눈금 다섯 개씩 이동한다.

                                // Y축 눈금의 숫자를 구한다.
                                if (NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.LowerLeft || NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.LowerRight)
                                {
                                    NewGraph.HorizontalGridNumber--;
                                }
                                else
                                {
                                    NewGraph.HorizontalGridNumber++;
                                }
                            }
                        }

                        // "(만 권)"을 그린다.
                        e.Graphics.DrawString("(만 권)", TextFont, TextBrush, new PointF(NewGraph.DrawRect.Left - 100.0f, // 100.0f는 글자의 X좌표를 설정하기 위한 값
                                                                                        NewGraph.DrawRect.Top - NewGraph.DrawRect.Height
                                                                                        / NewGraph.VerticalGridCount));

                        if (NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.UpperLeft || NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.UpperRight)
                        {
                            // "0"을 그린다.
                            e.Graphics.DrawString("0", TextFont, TextBrush, new PointF(NewGraph.DrawRect.Left - 50.0f, // 50.0f은 "0"의 X좌표를 정하기 위한 값
                                                                                      NewGraph.DrawRect.Top + NewGraph.DrawRect.Height * (NewGraph.VerticalGridCount - 4.0f) /
                                                                                      NewGraph.VerticalGridCount)); // 4.0f는 "0"의 높이를 정하기 위한 값
                        }
                    }
                    break;
                case Graph.CurrentGraph.BarGraph:
                    {
                        // 그래프 가로 눈금을 그리는 부분
                        NewGraph.HorizontalGridStartPoint = new PointF(NewGraph.DrawRect.Left, NewGraph.DrawRect.Top + NewGraph.DrawRect.Height / NewGraph.VerticalGridCount);
                        NewGraph.HorizontalGridEndPoint = new PointF(NewGraph.DrawRect.Left + NewGraph.DrawRect.Width,
                                                                     NewGraph.DrawRect.Top + NewGraph.DrawRect.Height / NewGraph.VerticalGridCount);
                        NewGraph.HorizontalGridNumberPoint = new PointF(NewGraph.DrawRect.Left - 80.0f, NewGraph.DrawRect.Top - 20.0f);                                                           // 80.0f은 숫자의 X좌표 값을 설정하기 위한 값이고 20.0f는 숫자의 높이를 정하기 위한 값으로 고정값.
                        for (int i = 0; i <= NewGraph.BigVerticalGridCount; i++)
                        {
                            // 가로 눈금를 그린다.
                            e.Graphics.DrawLine(LinePen, NewGraph.HorizontalGridStartPoint, NewGraph.HorizontalGridEndPoint);
                            NewGraph.HorizontalGridStartPoint.Y += NewGraph.DrawRect.Height / NewGraph.VerticalGridCount;
                            NewGraph.HorizontalGridEndPoint.Y += NewGraph.DrawRect.Height / NewGraph.VerticalGridCount;

                            // 가로 눈금의 숫자를 그린다.
                            e.Graphics.DrawString(((NewGraph.BigVerticalGridCount - i) * NewGraph.OneGridYValue).ToString(), TextFont, TextBrush,
                                                  NewGraph.HorizontalGridNumberPoint);
                            NewGraph.HorizontalGridNumberPoint.Y += NewGraph.DrawRect.Height / NewGraph.VerticalGridCount;
                        }
                    }
                    break;
                case Graph.CurrentGraph.PieChart:
                    break;
                case Graph.CurrentGraph.SpeacialGraph1:
                    break;
                case Graph.CurrentGraph.SpeacialGraph2:
                    break;
                default:
                    break;
            }


        }

        private void DrawVerticalGrid(Graph NewGraph, Pen LinePen, Font TextFont, Brush TextBrush, PaintEventArgs e)
        {
            switch (NewGraph.CurrentState)
            {
                case Graph.CurrentGraph.None:
                    break;
                case Graph.CurrentGraph.LineGraph:
                    {
                        // 눈금의 숫자를 정의한다.
                        if (NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.LowerRight || NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.UpperRight)
                        {
                            NewGraph.VerticalGridNumber = NewGraph.HorizontalGridCount - 1; // 맨 왼쪽에 있는 큰 눈금에 숫자를 표시하지 않기 위해서 1을 뺌.
                        }
                        else
                        {
                            NewGraph.VerticalGridNumber = 1;
                        }

                        for (int i = 0; i < NewGraph.HorizontalGridCount; i++)
                        {
                            // 세로 눈금을 그린다.
                            e.Graphics.DrawLine(LinePen, NewGraph.VerticalGridStartPoint, NewGraph.VerticalGridEndPoint);


                            if (i < NewGraph.HorizontalGridCount - 1) // 마지막 큰 눈금에 숫자를 표시하지 않는다.
                            {

                                // 세로 눈금에 해당하는 숫자를 그린다.
                                e.Graphics.DrawString((NewGraph.VerticalGridNumber * NewGraph.OneGridXValue).ToString(), TextFont, TextBrush, NewGraph.VerticalGridNumberPoint);
                                NewGraph.VerticalGridNumberPoint.X += NewGraph.DrawRect.Width / NewGraph.HorizontalGridCount;

                                // 눈금의 숫자를 구한다.
                                if (NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.LowerRight || NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.UpperRight)
                                {
                                    NewGraph.VerticalGridNumber--;
                                }
                                else
                                {
                                    NewGraph.VerticalGridNumber++;
                                }
                            }

                            NewGraph.VerticalGridStartPoint.X += NewGraph.DrawRect.Width / NewGraph.HorizontalGridCount;
                            NewGraph.VerticalGridEndPoint.X += NewGraph.DrawRect.Width / NewGraph.HorizontalGridCount;

                        }

                        // 가로 눈금에 "0"을 그린다.
                        if (NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.LowerRight || NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.UpperRight)
                        {
                            e.Graphics.DrawString("0", TextFont, TextBrush, NewGraph.VerticalGridNumberPoint);
                        }
                    }
                    break;
                case Graph.CurrentGraph.BarGraph:
                    {
                        // 그래프의 세로 눈금을 그리는 부분
                        NewGraph.VerticalGridStartPoint = new PointF(NewGraph.DrawRect.Left + NewGraph.DrawRect.Width / NewGraph.HorizontalGridCount,
                                                                     NewGraph.DrawRect.Top + NewGraph.DrawRect.Height - 10.0f);
                        NewGraph.VerticalGridEndPoint = new PointF(NewGraph.DrawRect.Left + NewGraph.DrawRect.Width / NewGraph.HorizontalGridCount,
                                                                    NewGraph.DrawRect.Top + NewGraph.DrawRect.Height);
                        NewGraph.VerticalGridNumberPoint = new PointF(NewGraph.DrawRect.Left + (NewGraph.DrawRect.Width / NewGraph.HorizontalGridCount * 0.2f),
                                                                      NewGraph.VerticalGridEndPoint.Y + 10.0f); // 0.2f는 숫자의 X좌표를, 10.0f는 숫자의 Y좌표를 정하기 위한 값으로 고정 값.
                        for (int i = 0; i <= NewGraph.HorizontalGridCount; i++)
                        {
                            e.Graphics.DrawLine(LinePen, NewGraph.VerticalGridStartPoint, NewGraph.VerticalGridEndPoint);

                            // 세로 눈금에 해당하는 숫자를 그린다.
                            e.Graphics.DrawString((i + NewGraph.XMin).ToString(), TextFont, TextBrush, NewGraph.VerticalGridNumberPoint);
                            NewGraph.VerticalGridNumberPoint.X += NewGraph.DrawRect.Width / NewGraph.HorizontalGridCount;

                            NewGraph.VerticalGridStartPoint.X += NewGraph.DrawRect.Width / NewGraph.HorizontalGridCount;
                            NewGraph.VerticalGridEndPoint.X += NewGraph.DrawRect.Width / NewGraph.HorizontalGridCount;

                        }
                    }
                    break;
                case Graph.CurrentGraph.PieChart:
                    break;
                case Graph.CurrentGraph.SpeacialGraph1:
                    break;
                case Graph.CurrentGraph.SpeacialGraph2:
                    break;
                default:
                    break;
            }
        }

        private void GetData(Graph NewGraph)
        {
            Random Blend = new Random();
            double RandomYData = 0.0;

            for (int i = 0; i < NewGraph.HorizontalGridCount; i++)
            {
                RandomYData = Blend.Next(System.Convert.ToInt32(Math.Round(NewGraph.YMin)),
                                     System.Convert.ToInt32(Math.Round(NewGraph.YMax)));

                // X값이 순차적이지 않은 막대 그래프의 경우에는 0보다 큰 값들 중 최소값이 XMin이 된다.
                if(NewGraph.CurrentState == Graph.CurrentGraph.BarGraph)
                {
                    NewGraph.DataList.Add(NewGraph.XMin + NewGraph.OneGridXValue * i, RandomYData);
                }
                else
                {
                    NewGraph.DataList.Add(NewGraph.XMin + NewGraph.OneGridXValue * (i + 1), RandomYData);
                }
            }
        }

        private void DrawGraphPoint(Graph NewGraph, PaintEventArgs e)
        {
            // 현재 데이터의 X값
            double CurrentKey = 0.0;
            // 현재 데이터의 Y값
            double CurrentValue = 0.0;
            // 현재 데이터의 표시하는 점의 X값
            float CurrentPointX = 0.0f;

            switch (NewGraph.CurrentState)
            {
                case Graph.CurrentGraph.None:
                    break;
                case Graph.CurrentGraph.LineGraph:
                    {
                        // 점을 그리는 사각형을 정의한다.
                        for (int i = 0; i < NewGraph.DataList.Count - 1; i++)  // 마지막 그리드에 점을 그리지 않기 위해서 1을 뺐다.
                        {
                            // 현재 데이터의 값들을 구한다.
                            CurrentKey = System.Convert.ToDouble(NewGraph.DataList.GetKey(i));
                            CurrentValue = System.Convert.ToDouble(NewGraph.DataList[CurrentKey]);

                            // 현재 데이터를 표시하는 점의 X값을 구한다.
                            if (NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.LowerRight || NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.UpperRight)
                            {
                                CurrentPointX = NewGraph.GraphMargin.Left - NewGraph.GraphMargin.Right + NewGraph.GetMathXPoint(CurrentKey, NewGraph.XMin,
                                                                    NewGraph.XMax + NewGraph.OneGridXValue).X - NewGraph.PointRadius;
                            }
                            else
                            {
                                CurrentPointX = NewGraph.GetMathXPoint(CurrentKey, NewGraph.XMin, NewGraph.XMax + NewGraph.OneGridXValue).X - NewGraph.PointRadius;
                            }

                            // 현재 데이터에 해당하는 점을 그리는 사각형을 구한다.
                            NewGraph.DataPointRect = new RectangleF(CurrentPointX,
                                                                    NewGraph.GetMathYPoint(CurrentValue, NewGraph.YMin, NewGraph.YMax + NewGraph.OneGridYValue).Y
                                                                    - NewGraph.PointRadius, NewGraph.PointSize, NewGraph.PointSize);

                            // 점을 그린다.
                            e.Graphics.FillEllipse(NewGraph.PointBrush, NewGraph.DataPointRect);
                        }
                    }
                    break;
                case Graph.CurrentGraph.PieChart:
                    break;
                case Graph.CurrentGraph.SpeacialGraph1:
                    break;
                case Graph.CurrentGraph.SpeacialGraph2:
                    break;
                default:
                    break;
            }
        }

        private void DrawGraphLine(Graph NewGraph, PaintEventArgs e)
        {
            // 현재 데이터의 X값
            double CurrentKey = 0.0;
            // 현재 데이터의 Y값
            double CurrentValue = 0.0;
            // 다음 데이터의 X값
            double NextKey = 0.0;
            // 다음 데이터의 Y값
            double NextValue = 0.0;
            // 현재 데이터의 표시하는 점의 X값
            float CurrentPointX = 0.0f;
            // 다음 데이터의 표시하는 점의 X값
            float NextPointX = 0.0f;

            switch (NewGraph.CurrentState)
            {
                case Graph.CurrentGraph.None:
                    break;
                case Graph.CurrentGraph.LineGraph:
                    {
                        // 그래프의 선을 그리는 부분
                        for (int i = 0; i < NewGraph.DataList.Count - 2; i++) // 마지막 점을 시작점으로 하는 선을 그리지 않기 위해서 2을 뺐다.
                        {
                            // 현재 데이터의 X값, Y값과 다음 데이터의 X값과 Y값을 구한다.
                            CurrentKey = System.Convert.ToDouble(NewGraph.DataList.GetKey(i));
                            CurrentValue = System.Convert.ToDouble(NewGraph.DataList[CurrentKey]);
                            NextKey = System.Convert.ToDouble(NewGraph.DataList.GetKey(i + 1));
                            NextValue = System.Convert.ToDouble(NewGraph.DataList[NextKey]);

                            // 현재 데이터를 표시하는 점의 X값을 구한다.
                            if (NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.LowerRight || NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.UpperRight)
                            {
                                CurrentPointX = NewGraph.GraphMargin.Left - NewGraph.GraphMargin.Right + NewGraph.GetMathXPoint(CurrentKey, NewGraph.XMin,
                                                                    NewGraph.XMax + NewGraph.OneGridXValue).X;
                            }
                            else
                            {
                                CurrentPointX = NewGraph.GetMathXPoint(CurrentKey, NewGraph.XMin, NewGraph.XMax + NewGraph.OneGridXValue).X;
                            }

                            // 다음 데이터를 표시하는 점의 X값을 구한다.
                            if (NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.LowerRight || NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.UpperRight)
                            {
                                NextPointX = NewGraph.GraphMargin.Left - NewGraph.GraphMargin.Right + NewGraph.GetMathXPoint(NextKey, NewGraph.XMin,
                                                                    NewGraph.XMax + NewGraph.OneGridXValue).X;
                            }
                            else
                            {
                                NextPointX = NewGraph.GetMathXPoint(NextKey, NewGraph.XMin, NewGraph.XMax + NewGraph.OneGridXValue).X;
                            }

                            // 선의 시작점과 끝점을 구한다.
                            NewGraph.DataLineStartPoint = new PointF(CurrentPointX,
                                                                     NewGraph.GetMathYPoint(CurrentValue, NewGraph.YMin, NewGraph.YMax + NewGraph.OneGridYValue).Y);
                            NewGraph.DataLineEndPoint = new PointF(NextPointX,
                                                                NewGraph.GetMathYPoint(NextValue, NewGraph.YMin, NewGraph.YMax + NewGraph.OneGridYValue).Y);

                            // 선을 그린다.
                            e.Graphics.DrawLine(NewGraph.DataLinePen, NewGraph.DataLineStartPoint, NewGraph.DataLineEndPoint);

                        }
                    }
                    break;
                case Graph.CurrentGraph.PieChart:
                    break;
                case Graph.CurrentGraph.SpeacialGraph1:
                    break;
                case Graph.CurrentGraph.SpeacialGraph2:
                    break;
                default:
                    break;
            }
        }

        private void FrmEveryChart_SizeChanged(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void DrawBarGraph(Graph NewGraph, PaintEventArgs e)
        {
            // 선을 그리는 펜
            Pen LinePen = new Pen(Color.Blue, 1.0f);
            // 그래프 영역
            RectangleF DrawRect = new RectangleF(NewGraph.GraphMargin.Left, NewGraph.GraphMargin.Top,
                                    panel1.Width - NewGraph.GraphMargin.Left - NewGraph.GraphMargin.Right,
                                    panel1.Height - NewGraph.GraphMargin.Top - NewGraph.GraphMargin.Bottom);
            // 글자 폰트
            Font TextFont = new Font("Arial", 22);
            // 글자를 그리는 펜
            Brush TextBrush = Brushes.Teal;

            // X축 눈금 하나에 해당하는 값
            NewGraph.OneGridXValue = 1.0f;
            // Y축 눈금 하나에 해당하는 값
            NewGraph.OneGridYValue = 1000.0f;
            // 가로 큰 눈금의 개수
            NewGraph.BigHorizontalGridCount = Convert.ToInt32(Math.Round(System.Convert.ToDouble((NewGraph.XMax - NewGraph.XMin) / NewGraph.OneGridXValue))) + 1;
            // 세로 큰 눈금의 개수
            NewGraph.BigVerticalGridCount = Convert.ToInt32(Math.Round(System.Convert.ToDouble((NewGraph.YMax - NewGraph.YMin) / NewGraph.OneGridYValue)));
            // 가로 눈금의 개수
            NewGraph.HorizontalGridCount = NewGraph.BigHorizontalGridCount;
            // 세로 눈금의 개수
            NewGraph.VerticalGridCount = NewGraph.BigVerticalGridCount;
            // 막대의 색상
            NewGraph.BarBrush = new SolidBrush(Color.Blue);

            // 그리기 영역을 정의한다.
            NewGraph.DrawRect = DrawRect;

            // 그래프 영역을 그리는 부분
            e.Graphics.DrawRectangle(LinePen, NewGraph.DrawRect.Left, NewGraph.DrawRect.Top, NewGraph.DrawRect.Width, NewGraph.DrawRect.Height);

            // 그래프의 제목을 그린다.
            e.Graphics.DrawString("연도별 매출 성장 변화 추이", TextFont, new SolidBrush(Color.Blue), new PointF(NewGraph.RealRect.Width * 0.3f, NewGraph.GraphMargin.Top * 0.6f));

            // 그래프의 가로 눈금을 그린다.
            DrawHorizontalGrid(NewGraph, LinePen, TextFont, TextBrush, e);

            // 그래프의 세로 눈금을 그린다.
            DrawVerticalGrid(NewGraph, LinePen, TextFont, TextBrush, e);

            switch (NewGraph.CurrentOriginPoint)
            {
                case Graph.OriginPointPosition.LowerLeft:
                    {
                        // 그래프의 막대를 그린다.
                        DrawBar(NewGraph, e);
                    }
                    break;
                case Graph.OriginPointPosition.LowerRight:
                    break;
                case Graph.OriginPointPosition.UpperRight:
                    break;
                case Graph.OriginPointPosition.UpperLeft:
                    break;
                default:
                    break;
            }

            // 데이터를 초기화한다.
            NewGraph.DataList.Clear();
        }

        private void DrawBar(Graph NewGraph, PaintEventArgs e)
        {
            NewGraph.BarBrush = new SolidBrush(Color.Blue);

            // 그래프의 막대를 그리는 부분
            for (int i = 0; i < NewGraph.DataList.Count; i++)
            {
               NewGraph.BarRect = new RectangleF(NewGraph.GetMathXPoint(System.Convert.ToDouble(NewGraph.DataList.GetKey(i)), NewGraph.XMin, 
                                                                        NewGraph.XMax + NewGraph.OneGridXValue).X + 
                                                                        (NewGraph.DrawRect.Width / NewGraph.HorizontalGridCount / 3), // 그래프의 막대를 큰 눈금의 3분의 1만큼 뒤로 이동시킨다.
                                                 NewGraph.GetMathYPoint(System.Convert.ToDouble(NewGraph.DataList[NewGraph.DataList.GetKey(i)]),
                                                                        NewGraph.YMin, NewGraph.YMax).Y,
                                                       30, 30);
               e.Graphics.FillRectangle(NewGraph.BarBrush, NewGraph.BarRect);
            }
        }
    }
}
