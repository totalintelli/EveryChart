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

                        // 꺾은 선 그래프를 그린다.
                        DrawLineGraph(NewGraph, e);

                        // 데이터를 가져온다.
                        GetData(NewGraph);
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
            RectangleF GraphRect = new RectangleF(NewGraph.GraphMargin.Left, NewGraph.GraphMargin.Top,
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
            NewGraph.DrawRect = GraphRect;
        
            // 그래프의 제목을 그린다.
            e.Graphics.DrawString("월별 책의 판매량", TextFont, new SolidBrush(Color.Blue), 
                new PointF(NewGraph.RealRect.Width * 0.5f, NewGraph.GraphMargin.Top * 0.6f));

            // 그래프 영역을 그리는 부분
            e.Graphics.DrawRectangle(LinePen, GraphRect.Left, GraphRect.Top, GraphRect.Width, GraphRect.Height);

            // 긴 수평선을 그린다.
            e.Graphics.DrawLine(LinePen, new PointF(0, GraphRect.Top + GraphRect.Height),
                new PointF(GraphRect.Right, GraphRect.Top + GraphRect.Height));

            // 긴 수직선을 그린다.
            e.Graphics.DrawLine(LinePen, new PointF(GraphRect.Left, GraphRect.Top), new PointF(GraphRect.Left, panel1.Height));

            // 대각선을 그린다.
            e.Graphics.DrawLine(LinePen, new PointF(0, panel1.Height), new PointF(GraphRect.Left, GraphRect.Bottom));

            // "판매량"을 그리는 부분
            e.Graphics.DrawString("판매량", TextFont, TextBrush, new PointF(NewGraph.GraphMargin.Left / 15.0f,                      // 15.0f : "판매량" 위치의 X값을 구하기 위한 값.
                                                                                NewGraph.GraphMargin.Top + GraphRect.Height + 10.0f)); // 10.0f : "판매량"의 높이를 맞추기 위한 값.

            // "월"을 그리는 부분
            e.Graphics.DrawString("월", TextFont, TextBrush, new PointF(NewGraph.GraphMargin.Left * 7.5f / 10.0f,                     // 7.5f / 10.0f : "월"의 위치의 X값을 구하기 위한 값.
                                                                         NewGraph.GraphMargin.Top + GraphRect.Height 
                                                                         + NewGraph.GraphMargin.Bottom * 0.5f));                       // 0.5f : "월"의 위치의 Y값을 구하기 위한 값.);

            #region X축 눈금
            // X축 눈금의 개수
            NewGraph.BigHorizontalGridCount = Convert.ToInt32(Math.Round(System.Convert.ToDouble((NewGraph.XMax - NewGraph.XMin) / NewGraph.OneGridXValue))) + 1;
            // X축 눈금의 개수
            NewGraph.HorizontalGridCount = NewGraph.BigHorizontalGridCount;
            // 그래프의 세로 눈금을 그리는 부분
            NewGraph.VerticalGridStartPoint = new PointF(GraphRect.Left + GraphRect.Width / NewGraph.HorizontalGridCount, GraphRect.Top);
            NewGraph.VerticalGridEndPoint = new PointF(GraphRect.Left + GraphRect.Width / NewGraph.HorizontalGridCount, GraphRect.Top + GraphRect.Height);
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
            NewGraph.HorizontalGridStartPoint = new PointF(GraphRect.Left, GraphRect.Top + GraphRect.Height / NewGraph.VerticalGridCount);
            NewGraph.HorizontalGridEndPoint = new PointF(GraphRect.Left + GraphRect.Width, GraphRect.Top + GraphRect.Height / NewGraph.VerticalGridCount);
            // Y축 눈금의 숫자의 위치를 구한다.
            NewGraph.HorizontalGridNumberPoint = new PointF(GraphRect.Left - 50.0f,
                GraphRect.Top + GraphRect.Height * 3.0f / NewGraph.VerticalGridCount); // 50.0f은 숫자의 X좌표 값을 설정하기 위한 값이고 3.0f는 숫자의 높이를 정하기 위한 값으로 고정값.
            #endregion

            switch (NewGraph.CurrentOriginPoint)
            {
                case Graph.OriginPointPosition.LowerLeft:
                    {
                        // 그래프의 가로 눈금을 그린다.
                        DrawHorizontalGrid(NewGraph, LinePen, TextFont, TextBrush, e);

                        // 그래프의 세로 눈금을 그린다.
                        DrawVerticalGrid(NewGraph, LinePen, TextFont, TextBrush, e);

                        // 그래프의 점을 그린다.
                        DrawGraphPoint(NewGraph, e);

                        // 그래프의 선을 그리는 부분
                        //for (int i = 0; i < Data.GetLength(0); i++)
                        //{
                        //    DataLineStartPoint = new PointF(NewGraph.GetMathXPoint(Data[i, 0], NewGraph.XMin, NewGraph.XMax + NewGraph.OneGridXValue).X,
                        //                                        NewGraph.GetMathYPoint(Data[i, 1], NewGraph.YMin, NewGraph.YMax + NewGraph.OneGridYValue).Y);
                        //    if (i < Data.GetLength(0) - 1)
                        //    {
                        //        DataLineEndPoint = new PointF(NewGraph.GetMathXPoint(Data[i + 1, 0], NewGraph.XMin, NewGraph.XMax + NewGraph.OneGridXValue).X,
                        //                                        NewGraph.GetMathYPoint(Data[i + 1, 1], NewGraph.YMin, NewGraph.YMax + NewGraph.OneGridYValue).Y);
                        //        e.Graphics.DrawLine(DataLinePen, DataLineStartPoint, DataLineEndPoint);
                        //    }

                        //}

                        // 데이터를 초기화한다.
                        NewGraph.DataList.Clear();
                    }
                    break;
                 /*
                case Graph.OriginPointPosition.LowerRight:
                    // 그래프의 가로 눈금을 그린다.
                    DrawHorizontalGrid(NewGraph, LinePen, TextFont, TextBrush, e);

                    for (int i = 0; i < HorizontalGridCount; i++)
                    {
                        e.Graphics.DrawLine(LinePen, VerticalGridStartPoint, VerticalGridEndPoint);

                        // 세로 눈금에 해당하는 숫자를 그린다.
                        if (i < HorizontalGridCount - 1)
                        {
                            e.Graphics.DrawString((HorizontalGridCount - (i + 1)).ToString(), TextFont, TextBrush, NumberPoint);
                            NumberPoint.X += GraphRect.Width / HorizontalGridCount;
                        }

                        VerticalGridStartPoint.X += GraphRect.Width / HorizontalGridCount;
                        VerticalGridEndPoint.X += GraphRect.Width / HorizontalGridCount;

                    }

                    // 그래프의 점을 그리는 부분
                    // 점을 그리는 사각형을 정의한다.
                    for (int i = 0; i < Data.GetLength(0); i++)
                    {
                        DataPointRect = new RectangleF(NewGraph.GraphMargin.Left - NewGraph.GraphMargin.Right + NewGraph.GetMathXPoint(Data[i, 0], XMin, XMax + OneGridXValue).X - PointRadius,
                                                                NewGraph.GetMathYPoint(Data[i, 1], YMin, YMax + OneGridYValue).Y - PointRadius, PointSize, PointSize);
                        e.Graphics.FillEllipse(PointBrush, DataPointRect);
                    }

                    // 그래프의 선을 그리는 부분
                    for (int i = 0; i < Data.GetLength(0); i++)
                    {
                        DataLineStartPoint = new PointF(NewGraph.GraphMargin.Left - NewGraph.GraphMargin.Right + NewGraph.GetMathXPoint(Data[i, 0], XMin, XMax + OneGridXValue).X,
                                                            NewGraph.GetMathYPoint(Data[i, 1], YMin, YMax + OneGridYValue).Y);
                        if (i < Data.GetLength(0) - 1)
                        {
                            DataLineEndPoint = new PointF(NewGraph.GraphMargin.Left - NewGraph.GraphMargin.Right + NewGraph.GetMathXPoint(Data[i + 1, 0], XMin, XMax + OneGridXValue).X,
                                                            NewGraph.GetMathYPoint(Data[i + 1, 1], YMin, YMax + OneGridYValue).Y);
                            e.Graphics.DrawLine(DataLinePen, DataLineStartPoint, DataLineEndPoint);
                        }

                    }

                    break;
                case Graph.OriginPointPosition.UpperRight:
                    {
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
                                // 가로 눈금의 숫자를 그린다.
                                e.Graphics.DrawString((i * 10.0f).ToString(), TextFont, TextBrush, NumberPoint);
                                NumberPoint.Y += GraphRect.Height * 5.0f / VerticalGridCount;
                            }
                        }


                        // 그래프의 세로 눈금을 그리는 부분
                        VerticalGridStartPoint = new PointF(GraphRect.Left + GraphRect.Width / HorizontalGridCount, GraphRect.Top);
                        VerticalGridEndPoint = new PointF(GraphRect.Left + GraphRect.Width / HorizontalGridCount, GraphRect.Top + GraphRect.Height);
                        NumberPoint = new PointF(VerticalGridStartPoint.X - 15.0f, VerticalGridEndPoint.Y + GraphRect.Height / VerticalGridCount);                         // 15.0f는 숫자의 X좌표를 정하기 위한 값으로 고정 값.
                        for (int i = 0; i < HorizontalGridCount; i++)
                        {
                            e.Graphics.DrawLine(LinePen, VerticalGridStartPoint, VerticalGridEndPoint);

                            // 세로 눈금에 해당하는 숫자를 그린다.
                            if (i < HorizontalGridCount - 1)
                            {
                                e.Graphics.DrawString((HorizontalGridCount - (i + 1)).ToString(), TextFont, TextBrush, NumberPoint);
                                NumberPoint.X += GraphRect.Width / HorizontalGridCount;
                            }

                            VerticalGridStartPoint.X += GraphRect.Width / HorizontalGridCount;
                            VerticalGridEndPoint.X += GraphRect.Width / HorizontalGridCount;

                        }

                        // 그래프의 점을 그리는 부분
                        // 점을 그리는 사각형을 정의한다.
                        for (int i = 0; i < Data.GetLength(0); i++)
                        {
                            DataPointRect = new RectangleF(NewGraph.GraphMargin.Left - NewGraph.GraphMargin.Right + NewGraph.GetMathXPoint(Data[i, 0], XMin, XMax + OneGridXValue).X - PointRadius,
                                                                    NewGraph.GetMathYPoint(Data[i, 1], YMin, YMax + OneGridYValue).Y - PointRadius, PointSize, PointSize);
                            e.Graphics.FillEllipse(PointBrush, DataPointRect);
                        }
                    }

                    // 그래프의 선을 그리는 부분
                    for (int i = 0; i < Data.GetLength(0); i++)
                    {
                        DataLineStartPoint = new PointF(NewGraph.GraphMargin.Left - NewGraph.GraphMargin.Right + NewGraph.GetMathXPoint(Data[i, 0], XMin, XMax + OneGridXValue).X,
                                                            NewGraph.GetMathYPoint(Data[i, 1], YMin, YMax + OneGridYValue).Y);
                        if (i < Data.GetLength(0) - 1)
                        {
                            DataLineEndPoint = new PointF(NewGraph.GraphMargin.Left - NewGraph.GraphMargin.Right + NewGraph.GetMathXPoint(Data[i + 1, 0], XMin, XMax + OneGridXValue).X,
                                                            NewGraph.GetMathYPoint(Data[i + 1, 1], YMin, YMax + OneGridYValue).Y);
                            e.Graphics.DrawLine(DataLinePen, DataLineStartPoint, DataLineEndPoint);
                        }

                    }

                    break;
                case Graph.OriginPointPosition.UpperLeft:
                    {
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
                                // 가로 눈금의 숫자를 그린다.
                                e.Graphics.DrawString((i * OneGridYValue).ToString(), TextFont, TextBrush, NumberPoint);
                                NumberPoint.Y += GraphRect.Height * 5.0f / VerticalGridCount;
                            }
                        }


                        for (int i = 0; i < HorizontalGridCount; i++)
                        {
                            e.Graphics.DrawLine(LinePen, VerticalGridStartPoint, VerticalGridEndPoint);

                            // 세로 눈금에 해당하는 숫자를 그린다.
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
                    */
                default:
                    break;
            }

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
                        if(NewGraph.CurrentOriginPoint ==Graph.OriginPointPosition.LowerLeft || NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.LowerRight)
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

                        // 세로 눈금의 "0"을 그린다.
                        if (NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.UpperLeft || NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.UpperRight)
                        {
                            e.Graphics.DrawString("0", TextFont, TextBrush, NewGraph.HorizontalGridNumberPoint);
                        }
                    }
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
                                if(NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.LowerRight || NewGraph.CurrentOriginPoint == Graph.OriginPointPosition.UpperRight)
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

                        // "(만 권)"을 그린다.
                        e.Graphics.DrawString("(만 권)", TextFont, TextBrush, new PointF(NewGraph.DrawRect.Left - 100.0f, NewGraph.DrawRect.Top - NewGraph.DrawRect.Height / NewGraph.VerticalGridCount)); // 100.0f는 글자의 X좌표를 설정하기 위한 값으로 고정값.               

                        // "0"을 그린다.
                        e.Graphics.DrawString("0", TextFont, TextBrush, new PointF(NewGraph.DrawRect.Left - 50.0f,
                                                                                    NewGraph.DrawRect.Top + NewGraph.DrawRect.Height * (NewGraph.VerticalGridCount - 4.0f) / NewGraph.VerticalGridCount)); // 50.0f은 "0"의 X좌표를, 4.0f는 "0"의 높이를 설정하기 위한 값으로 고정값.
                    }
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
        }

        private void GetData(Graph NewGraph)
        {
            Random Blend = new Random();
            double RandomYData = 0.0;

            for(int i = 0; i < NewGraph.HorizontalGridCount; i++)
            {
                RandomYData = Blend.Next(System.Convert.ToInt32(Math.Round(NewGraph.YMin)),
                                     System.Convert.ToInt32(Math.Round(NewGraph.YMax)));
                NewGraph.DataList.Add(NewGraph.XMin + NewGraph.OneGridXValue * (i + 1), RandomYData);
            }
        }
            
        private void DrawGraphPoint(Graph NewGraph, PaintEventArgs e)
        {
            switch (NewGraph.CurrentState)
            {
                case Graph.CurrentGraph.None:
                    break;
                case Graph.CurrentGraph.LineGraph:
                    {
                        // 리스트의 위치
                        int i = 0;
                        // 점을 그리는 사각형을 정의한다.
                        foreach (KeyValuePair<double, double> Couple in NewGraph.DataList)
                        {
                            NewGraph.DataPointRect = new RectangleF(NewGraph.GetMathXPoint(Couple.Key, NewGraph.XMin, 
                                                                    NewGraph.XMax + NewGraph.OneGridXValue).X - NewGraph.PointRadius,
                                                                    NewGraph.GetMathYPoint(Couple.Value, NewGraph.YMin, NewGraph.YMax + NewGraph.OneGridYValue).Y 
                                                                    - NewGraph.PointRadius, NewGraph.PointSize, NewGraph.PointSize);
                            e.Graphics.FillEllipse(NewGraph.PointBrush, NewGraph.DataPointRect);
                            i++;
                        }
                    }
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
            RectangleF GraphRect = new RectangleF(NewGraph.GraphMargin.Left, NewGraph.GraphMargin.Top,
                                    panel1.Width - NewGraph.GraphMargin.Left - NewGraph.GraphMargin.Right,
                                    panel1.Height - NewGraph.GraphMargin.Top - NewGraph.GraphMargin.Bottom);
            // 글자 폰트
            Font TextFont = new Font("Arial", 22);
            // 글자를 그리는 펜
            Brush TextBrush = Brushes.Teal;
            // X축 눈금 하나에 해당하는 값
            float OneGridXValue = 1.0f;
            // Y축 눈금 하나에 해당하는 값
            float OneGridYValue = 1000.0f;
            // 가로 큰 눈금의 개수
            int BigHorizontalGridCount = Convert.ToInt32(Math.Round(System.Convert.ToDouble((NewGraph.XMax - NewGraph.XMin) / OneGridXValue))) + 1;
            // 세로 큰 눈금의 개수
            int BigVerticalGridCount = Convert.ToInt32(Math.Round(System.Convert.ToDouble((NewGraph.YMax - NewGraph.YMin) / OneGridYValue)));
            // 가로 눈금의 개수
            int HorizontalGridCount = BigHorizontalGridCount;
            // 세로 눈금의 개수
            int VerticalGridCount = BigVerticalGridCount;
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
            // 선의 색상
            Pen DataLinePen = new Pen(Color.Red, 2.0f);
            // 선의 시작점
            PointF DataLineStartPoint;
            // 선의 끝점
            PointF DataLineEndPoint;
            // 제목 글자
            String TitleText = "연도별 매출 성장 변화 추이";
            // 제목의 색상
            SolidBrush TitleBrush = new SolidBrush(Color.Blue);
            // 제목의 위치
            PointF TitlePoint;

            // 그리기 영역을 정의한다.
            NewGraph.DrawRect = GraphRect;

            // 그래프 영역을 그리는 부분
            e.Graphics.DrawRectangle(LinePen, GraphRect.Left, GraphRect.Top, GraphRect.Width, GraphRect.Height);

            // 제목의 위치를 정한다.
            TitlePoint = new PointF(NewGraph.RealRect.Width * 0.3f, NewGraph.GraphMargin.Top * 0.6f);
            // 그래프의 제목을 그린다.
            e.Graphics.DrawString(TitleText, TextFont, TitleBrush, TitlePoint);

            switch (NewGraph.CurrentOriginPoint)
            {
                case Graph.OriginPointPosition.LowerLeft:
                    {
                        // 그래프 가로 눈금을 그리는 부분
                        HorizontalGridStartPoint = new PointF(GraphRect.Left, GraphRect.Top + GraphRect.Height / VerticalGridCount);
                        HorizontalGridEndPoint = new PointF(GraphRect.Left + GraphRect.Width, GraphRect.Top + GraphRect.Height / VerticalGridCount);
                        NumberPoint = new PointF(GraphRect.Left - 80.0f, GraphRect.Top - 20.0f);                                                           // 80.0f은 숫자의 X좌표 값을 설정하기 위한 값이고 20.0f는 숫자의 높이를 정하기 위한 값으로 고정값.
                        for (int i = 0; i <= BigVerticalGridCount; i++)
                        {
                            // 가로 눈금를 그린다.
                            e.Graphics.DrawLine(LinePen, HorizontalGridStartPoint, HorizontalGridEndPoint);
                            HorizontalGridStartPoint.Y += GraphRect.Height / VerticalGridCount;
                            HorizontalGridEndPoint.Y += GraphRect.Height / VerticalGridCount;
                            
                            // 가로 눈금의 숫자를 그린다.
                            e.Graphics.DrawString(((BigVerticalGridCount - i) * OneGridYValue).ToString(), TextFont, TextBrush, NumberPoint);
                            NumberPoint.Y += GraphRect.Height / VerticalGridCount;
                        }

                        // 그래프의 세로 눈금을 그리는 부분
                        VerticalGridStartPoint = new PointF(GraphRect.Left + GraphRect.Width / HorizontalGridCount, GraphRect.Top + GraphRect.Height - 10.0f);
                        VerticalGridEndPoint = new PointF(GraphRect.Left + GraphRect.Width / HorizontalGridCount, GraphRect.Top + GraphRect.Height);
                        NumberPoint = new PointF(GraphRect.Left + (GraphRect.Width / HorizontalGridCount * 0.2f), VerticalGridEndPoint.Y + 10.0f); // 0.2f는 숫자의 X좌표를, 10.0f는 숫자의 Y좌표를 정하기 위한 값으로 고정 값.
                        for (int i = 0; i <= HorizontalGridCount; i++)
                        {
                            e.Graphics.DrawLine(LinePen, VerticalGridStartPoint, VerticalGridEndPoint);

                            // 세로 눈금에 해당하는 숫자를 그린다.
                            e.Graphics.DrawString((i + NewGraph.XMin).ToString(), TextFont, TextBrush, NumberPoint);
                            NumberPoint.X += GraphRect.Width / HorizontalGridCount;

                            VerticalGridStartPoint.X += GraphRect.Width / HorizontalGridCount;
                            VerticalGridEndPoint.X += GraphRect.Width / HorizontalGridCount;

                        }

                        // 그래프의 점을 그리는 부분
                        // 점을 그리는 사각형을 정의한다.
                        //for (int i = 0; i < Data.GetLength(0); i++)
                        //{
                        //    DataPointRect = new RectangleF(NewGraph.GetMathXPoint(Data[i, 0], XMin, XMax + OneGridXValue).X - PointRadius,
                        //                                            NewGraph.GetMathYPoint(Data[i, 1], YMin, YMax + OneGridYValue).Y - PointRadius, PointSize, PointSize);
                        //    e.Graphics.FillEllipse(PointBrush, DataPointRect);
                        //}

                        // 그래프의 선을 그리는 부분
                        //for (int i = 0; i < Data.GetLength(0); i++)
                        //{
                        //    DataLineStartPoint = new PointF(NewGraph.GetMathXPoint(Data[i, 0], XMin, XMax + OneGridXValue).X,
                        //                                        NewGraph.GetMathYPoint(Data[i, 1], YMin, YMax + OneGridYValue).Y);
                        //    if (i < Data.GetLength(0) - 1)
                        //    {
                        //        DataLineEndPoint = new PointF(NewGraph.GetMathXPoint(Data[i + 1, 0], XMin, XMax + OneGridXValue).X,
                        //                                        NewGraph.GetMathYPoint(Data[i + 1, 1], YMin, YMax + OneGridYValue).Y);
                        //        e.Graphics.DrawLine(DataLinePen, DataLineStartPoint, DataLineEndPoint);
                        //    }

                        //}
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
        }
    }
}
