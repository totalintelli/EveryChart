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
            CircleGraph = 2,    // 원 그래프.
            SpeacialGraph1 = 3, // 특수 그래프1.
            SpeacialGraph2 = 4, // 특수 그래프2.
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
            DrawLineGraph();
            CurrentState = CurrentGraph.LineGraph;
        }

        /// <summary>
        /// 꺽은 선 그래프를 그리는 함수
        /// </summary>
        private void DrawLineGraph()
        {
            panel1.CreateGraphics().Clear(panel1.BackColor);

            // 패널의 너비
            float Width = panel1.Width;
            // 패널의 높이
            float Height = panel1.Height - ButtonDockPanel.Height;
            
            // 세로 눈금 하나 당 단위 그리드의 개수
            int GridCount = 5;
            // panel1에 그릴 준비를 한다.
            Graphics g = panel1.CreateGraphics();
            // 제목 글자열
            string Title = "월별 책의 판매량";
            // 단위 그리드의 너비
            float GridWidth = panel1.Width / 17.0f;
            // 단위 그리드의 높이
            float GridHeight = panel1.Height / 10.0f;
            // 글자의 크기
            float TextSize = 1;
            if (GridWidth > 0 && GridHeight > 0)
            {
                TextSize = (GridWidth + GridHeight) / 8.0f;
            } 
            // 제목의 폰트
            Font TitleFont = new Font("SansSerif", TextSize);
            // 제목의 색상
            SolidBrush TitleBrush = new SolidBrush(Color.Blue);
            // 제목의 위치
            PointF TitlePoint = new PointF(Width / 2.0f, ButtonDockPanel.Height); // 1/ 2.0f는 제목의 위치를 정하기 위한 값으로 고정값.
            // Y축 글자열
            // (만 권)
            string KwanText = "(만 권)";
            // (만 권)의 색상
            SolidBrush TextBrush = new SolidBrush(Color.Teal);
            // (만 권)의 위치
            PointF KwanTextPoint = new PointF(GridWidth * 1.6f, ButtonDockPanel.Height + GridHeight * 0.5f);
            // 축의 색상
            Pen LinePen = Pens.Blue;
            // 아래쪽 가로축의 시작 위치
            PointF UnderHorizonStartPoint = new PointF(0.0f, ButtonDockPanel.Height + GridHeight * 7.5f);
            // 아래쪽 가로축의 끝 위치
            PointF UnderHorizonEndPoint = new PointF(GridWidth * 16.0f, ButtonDockPanel.Height + GridHeight * 7.5f);
            // 왼쪽 세로축의 시작 위치
            PointF LeftVerticalStartPoint = new PointF(GridWidth * 3.0f, ButtonDockPanel.Height + GridHeight * 0.5f);
            // 왼쪽 세로축의 끝 위치
            PointF LeftVerticalEndPoint = new PointF(GridWidth * 3.0f, panel1.Height);
            // 오른쪽 세로축의 시작 위치
            PointF RightVerticalStartPoint = new PointF(GridWidth * 16.0f, GridHeight);
            // 오른쪽 세로축의 끝 위치
            PointF RightVerticalEndPoint = new PointF(GridWidth * 16.0f, GridHeight * 8.0f);
            // 왼쪽 아래 대각선의 시작 위치
            PointF LeftDiagonalStartPoint = new PointF(0.0f, panel1.Height);
            // 왼쪽 아래 대각선의 끝 위치
            PointF LeftDiagonalEndPoint = new PointF(GridWidth * 3.0f, ButtonDockPanel.Height + GridHeight * 7.5f);
            // 왼쪽 아래에 있는 "판매량" 
            string SalesVolumeText = "판매량";
            // 왼쪽 아래에 있는 "판매량"의 위치
            PointF SalesVolumeTextPoint = new PointF(0.0f, UnderHorizonStartPoint.Y + GridHeight * 0.1f);
            // 왼쪽 아래에 있는 "월"
            string MonthText = "월";
            // 왼쪽 아래에 있는 "월"의 위치
            PointF MonthTextPoint = new PointF(GridWidth * 2.5f, UnderHorizonStartPoint.Y + GridHeight * 0.9f);
            // 차트의 세로 줄의 개수
            int VerticalLineCount = 13;
            // 차트의 세로 줄의 시작 위치
            PointF VerticalLineStartPoint = new PointF(GridWidth * 4.0f, ButtonDockPanel.Height + GridHeight * 0.5f);
            // 차트의 세로 줄의 끝 위치
            PointF VerticalLineEndPoint = new PointF(GridWidth * 4.0f, ButtonDockPanel.Height + GridHeight * 7.5f);
            // 차트의 가로 줄의 개수
            int HorizontalLineCount = 7;
            // 차트의 가로 줄의 시작 위치
            PointF HorizontalLineStartPoint = new PointF(GridWidth * 3.0f, ButtonDockPanel.Height + GridHeight * 0.5f);
            // 차트의 가로 줄의 끝 위치
            PointF HorizontalLineEndPoint = new PointF(GridWidth * 16.0f, ButtonDockPanel.Height + GridHeight * 0.5f);
            // 차트의 숫자
            int Number = 1;
            // 글자화된 차트의 숫자
            string NumberText;
            // 차트의 숫자의 위치
            PointF TextPoint = new PointF(GridWidth * 3.8f, ButtonDockPanel.Height + GridHeight * 7.7f);
            // 데이터의 좌표값들
            List<PointF> DataPoints = new List<PointF>();
            // 단위 그리드 사각형의 정보
            RectangleF GridRect = new RectangleF(GridWidth * 4.0f, GridHeight, GridWidth, GridHeight);
            // 차트의 원점의 좌표값
            PointF OriginPoint = new PointF(GridWidth * 3.0f, ButtonDockPanel.Height + GridHeight * 7.5f);
            // 차트에 있는 점의 색상
            SolidBrush ChartBrush = new SolidBrush(Color.Red);
            // 차트에 있는 점들을 둘러싼 사각형들
            List<RectangleF> ChartPointRects = new List<RectangleF>();
            // 점들을 있는 선들의 색상
            Pen ChartPen = Pens.Red;
            // 차트에 있는 점들
            List<PointF> ChartPoints = new List<PointF>();

            // 차트의 선을 제외한 나머지 부분을 그린다.
            // 제목을 그린다.
            g.DrawString(Title, TitleFont, TitleBrush, TitlePoint);
            // 세로 축에 (만 권)을 그린다.
            g.DrawString(KwanText, TitleFont, TextBrush, KwanTextPoint);
            // 아래쪽 가로 축을 그린다.
            g.DrawLine(LinePen, UnderHorizonStartPoint, UnderHorizonEndPoint);
            // 왼쪽 세로 축을 그린다.
            g.DrawLine(LinePen, LeftVerticalStartPoint, LeftVerticalEndPoint);
            // 왼쪽 아래 대각선을 그린다.
            g.DrawLine(LinePen, LeftDiagonalStartPoint, LeftDiagonalEndPoint);
            // "판매량"을 그린다.
            g.DrawString(SalesVolumeText, TitleFont, TextBrush, SalesVolumeTextPoint);
            // "월"을 그린다.
            g.DrawString(MonthText, TitleFont, TextBrush, MonthTextPoint);
            // 차트의 세로 줄을 그린다.
            for (int i = 0; i < VerticalLineCount; i++)
            {
                NumberText = Number.ToString();
                // 실선을 그린다.
                g.DrawLine(LinePen, VerticalLineStartPoint, VerticalLineEndPoint);
                // 글씨를 그린다.
                if (i < VerticalLineCount - 1)
                {
                    g.DrawString(NumberText, TitleFont, TextBrush, TextPoint);
                    Number++;
                }


                // 세로 줄을 한 칸씩 이동시킨다.
                VerticalLineStartPoint.X += GridWidth;
                VerticalLineEndPoint.X += GridWidth;
                TextPoint.X += GridWidth;

            }

            TextPoint = new PointF(GridWidth * 2.4f, ButtonDockPanel.Height + GridHeight * 1.3f);
            Number = 60;

            // 차트의 가로 줄을 그린다.
            for (int i = 0; i < HorizontalLineCount; i++)
            {
                //차트에 넣을 숫자를 구한다.
                NumberText = Number.ToString();

                // 실선을 그린다.
                g.DrawLine(LinePen, HorizontalLineStartPoint, HorizontalLineEndPoint);
                // 글씨를 그린다.
                g.DrawString(NumberText, TitleFont, TextBrush, TextPoint);

                using (Pen the_pen = new Pen(Color.Blue))
                {
                    the_pen.DashStyle = DashStyle.Dot;
                    // 차트의 가로 눈금을 그린다.
                    for (int j = 0; j < GridCount; j++)
                    {
                        g.DrawLine(the_pen, HorizontalLineStartPoint, HorizontalLineEndPoint);
                        HorizontalLineStartPoint.Y += GridHeight / GridCount;
                        HorizontalLineEndPoint.Y += GridHeight / GridCount;
                    }

                }

                // 글씨를 한 칸씩 이동시킨다.
                if (i < HorizontalLineCount - 2)
                {
                    TextPoint.Y += GridHeight;
                }
                else
                {
                    TextPoint.Y += GridHeight / 2.0f;
                }

                Number -= 10;
            }

            // 데이터의 좌표값들을 추가한다.
            DataPoints.Add(new PointF(1, 23));
            DataPoints.Add(new PointF(2, 32));
            DataPoints.Add(new PointF(3, 50));
            DataPoints.Add(new PointF(4, 44));
            DataPoints.Add(new PointF(5, 52));
            DataPoints.Add(new PointF(6, 49));
            DataPoints.Add(new PointF(7, 38));
            DataPoints.Add(new PointF(8, 36));
            DataPoints.Add(new PointF(10, 58));
            DataPoints.Add(new PointF(11, 52));
            DataPoints.Add(new PointF(12, 56));

            // 차트의 점을 그린다.
            for (int i = 0; i < 11; i++)
            {
                ChartPointRects.Add(GetChartRect(DataPoints[i], GridRect, VerticalLineCount, OriginPoint, TextSize));
                g.FillEllipse(ChartBrush, ChartPointRects[i]);
            }

            // 선이 지나갈 부분의 보조점을 찍는다.
            for (int j = 0; j < 11; j++)
            {
                ChartPoints.Add(GetChartPoint(DataPoints[j], GridRect, VerticalLineCount, OriginPoint, TextSize));
            }

            // 차트의 선을 그린다.
            for (int k = 0; k < 10; k++)
            {
                g.DrawLine(ChartPen, ChartPoints[k], ChartPoints[k + 1]);
            }
        }

        /// <summary>
        /// 차트에 있는 점을 둘러싼 사각형을 구한다.
        /// </summary>
        /// <param name="DataPoint">좌표값</param>
        /// <param name="GridRect">단위 그리드 사각형 정보</param>
        /// <param name="VerticalNumberCount">세로 눈금의 숫자의 개수</param>
        /// <param name="OriginPoint">차트의 원점</param>
        /// <param name="TextSize">글자의 사이즈이자 점의 크기</param>
        /// <returns>차트에 있는 점을 둘러싼 사각형</returns>
        private RectangleF GetChartRect(PointF DataPoint, RectangleF GridRect, int VerticalNumberCount, PointF OriginPoint, float TextSize)
        {
            // 차트에서의 점의 위치
            RectangleF ChartPointRect = new RectangleF(OriginPoint.X - TextSize, OriginPoint.Y - TextSize, TextSize, TextSize);

            // 차트에서의 점의 위치를 구한다.
            ChartPointRect.X = OriginPoint.X + (GridRect.Width * DataPoint.X) - (ChartPointRect.Width / 2.0f);
            ChartPointRect.Y = OriginPoint.Y - ((GridRect.Height / 10.0f) * DataPoint.Y) - (ChartPointRect.Height / 2.0f);

            // 차트에서의 점의 위치를 출력한다.
            return ChartPointRect;
        }

        /// <summary>
        /// 차트에 있는 점의 좌표값을 구한다.
        /// </summary>
        /// <param name="DataPoint">좌표값</param>
        /// <param name="GridRect">단위 그리드 사각형 정보</param>
        /// <param name="VerticalNumberCount">세로 눈금의 숫자의 개수</param>
        /// <param name="OriginPoint">차트의 원점</param>
        /// <param name="TextSize">글자의 사이즈이자 점의 크기</param>
        /// <returns>차트에 있는 점의 좌표값</returns>
        private PointF GetChartPoint(PointF DataPoint, RectangleF GridRect, int VerticalNumberCount, PointF OriginPoint, float TextSize)
        {
            // 차트에서의 점의 위치
            PointF ChartPoint = new PointF(OriginPoint.X, OriginPoint.Y);

            // 차트에서의 점의 위치를 구한다.
            ChartPoint.X = OriginPoint.X + (GridRect.Width * DataPoint.X);
            ChartPoint.Y = OriginPoint.Y - ((GridRect.Height / 10.0f) * DataPoint.Y);

            // 차트에서의 점의 위치를 출력한다.
            return ChartPoint;
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            switch (CurrentState)
            {
                case CurrentGraph.None:
                    panel1.CreateGraphics().Clear(panel1.BackColor);
                    break;
                case CurrentGraph.LineGraph:
                    DrawLineGraph();
                    break;
                case CurrentGraph.CircleGraph:
                    break;
                case CurrentGraph.SpeacialGraph1:
                    break;
                case CurrentGraph.SpeacialGraph2:
                    break;
                default:
                    break;
            }
        }
    }
}
