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
        public FrmEveryChart()
        {
            InitializeComponent();
        }

        private void btnLineGraph_Click(object sender, EventArgs e)
        {
            panel1.CreateGraphics().Clear(panel1.BackColor);

            // 패널의 너비
            float Width = panel1.Width;
            // 패널의 높이
            float Height = panel1.Height;
            // 단위 그리드의 너비
            float GridWidth = panel1.Width / 17.0f;
            // 단위 그리드의 높이
            float GridHeight = panel1.Height / 10.0f;
            // 세로 눈금 하나 당 단위 그리드의 개수
            int GridCount = 5;
            // panel1에 그릴 준비를 한다.
            Graphics g = panel1.CreateGraphics();
            // 제목 글자열
            string Title = "월별 책의 판매량";
            // 제목의 폰트
            Font TitleFont = new Font("SansSerif", 18);
            // 제목의 색상
            SolidBrush TitleBrush = new SolidBrush(Color.Blue);
            // 제목의 위치
            PointF TitlePoint = new PointF(Width / 2.0f, 0); // 1/ 2.0f는 제목의 위치를 정하기 위한 값으로 고정값.
            // Y축 글자열
            // (만 권)
            string KwanText = "(만 권)";
            // (만 권)의 색상
            SolidBrush TextBrush = new SolidBrush(Color.Teal);
            // (만 권)의 위치
            PointF KwanTextPoint = new PointF(GridWidth * 1.1f, GridHeight);
            // 가로축에 있는 12의 위치
            PointF TwelveTextPoint = new PointF(GridWidth * 14.6f, GridHeight * 8);
            // 축의 색상
            Pen LinePen = Pens.Blue;
            // 아래쪽 가로축의 시작 위치
            PointF UnderHorizonStartPoint = new PointF(0, GridHeight * 8);
            // 아래쪽 가로축의 끝 위치
            PointF UnderHorizonEndPoint = new PointF(GridWidth * 16, GridHeight * 8);
            // 왼쪽 세로축의 시작 위치
            PointF LeftVerticalStartPoint = new PointF(GridWidth * 3, GridHeight);
            // 왼쪽 세로축의 끝 위치
            PointF LeftVerticalEndPoint = new PointF(GridWidth * 3, Height);
            // 위쪽 가로축의 시작 위치
            PointF UpperHorizonStartPoint = new PointF(GridWidth * 3, GridHeight);
            // 위쪽 가로축의 끝 위치
            PointF UpperHorizonEndPoint = new PointF(GridWidth * 16, GridHeight);
            // 오른쪽 세로축의 시작 위치
            PointF RightVerticalStartPoint = new PointF(GridWidth * 16, GridHeight);
            // 오른쪽 세로축의 끝 위치
            PointF RightVerticalEndPoint = new PointF(GridWidth * 16, GridHeight * 8);
            // 왼쪽 아래 대각선의 시작 위치
            PointF LeftDiagonalStartPoint = new PointF(0, Height);
            // 왼쪽 아래 대각선의 끝 위치
            PointF LeftDiagonalEndPoint = new PointF(GridWidth * 3, GridHeight * 8);
            // 왼쪽 아래에 있는 "판매량" 
            string SalesVolumeText = "판매량";
            // 왼쪽 아래에 있는 "판매량"의 위치
            PointF SalesVolumeTextPoint = new PointF(0, GridHeight * 8.2f);
            // 왼쪽 아래에 있는 "월"
            string MonthText = "월";
            // 왼쪽 아래에 있는 "월"의 위치
            PointF MonthTextPoint = new PointF(GridWidth * 2.2f, GridHeight * 9);
            // 차트의 세로 줄의 개수
            int VerticalLineCount = 13;
            // 차트의 세로 줄의 시작 위치
            PointF VerticalLineStartPoint = new PointF(GridWidth * 4, GridHeight);
            // 차트의 세로 줄의 끝 위치
            PointF VerticalLineEndPoint = new PointF(GridWidth * 4, GridHeight * 8);
            // 차트의 가로 줄의 개수
            int HorizontalLineCount = 7;
            // 차트의 가로 줄의 시작 위치
            PointF HorizontalLineStartPoint = new PointF(GridWidth * 3, GridHeight);
            // 차트의 가로 줄의 끝 위치
            PointF HorizontalLineEndPoint = new PointF(GridWidth * 16, GridHeight);
            // 차트의 숫자
            int Number = 1;
            // 글자화된 차트의 숫자
            string NumberText;
            // 차트의 숫자의 위치
            PointF TextPoint = new PointF(GridWidth * 3.75f, GridHeight * 8);

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
                if(i < VerticalLineCount - 1)
                {
                    g.DrawString(NumberText, TitleFont, TextBrush, TextPoint);
                    Number++;
                }
                
                
                // 세로 줄을 한 칸씩 이동시킨다.
                VerticalLineStartPoint.X += GridWidth;
                VerticalLineEndPoint.X += GridWidth;
                TextPoint.X += GridWidth;

            }

            TextPoint = new PointF(GridWidth * 2.2f, GridHeight * 1.7f);
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

            

        }
    }
}
