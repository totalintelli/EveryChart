using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            // 그리드의 너비
            float GridWidth = panel1.Width / 17.0f;
            // 그리드의 높이
            float GridHeight = panel1.Height / 10.0f;
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
            // 세로축에 있는 60
            string SixtyText = "60";
            // 세로축에 있는 60의 위치
            PointF SixtyTextPoint = new PointF(GridWidth * 2.2f, GridHeight * 1.7f);
            // 세로축에 있는 50
            string FiftyText = "50";
            // 세로축에 있는 50의 위치
            PointF FiftyTextPoint = new PointF(GridWidth * 2.2f, GridHeight * 2.7f);
            // 세로축에 있는 40
            string FourtyText = "40";
            // 세로축에 있는 40의 위치
            PointF FourtyTextPoint = new PointF(GridWidth * 2.2f, GridHeight * 3.7f);
            // 세로축에 있는 30
            string ThirtyText = "30";
            // 세로축에 있는 30의 위치
            PointF ThirtyTextPoint = new PointF(GridWidth * 2.2f, GridHeight * 4.7f);
            // 세로축에 있는 20
            string TwentyText = "20";
            // 세로축에 있는 20의 위치
            PointF TwentyTextPoint = new PointF(GridWidth * 2.2f, GridHeight * 5.7f);
            // 세로축에 있는 10
            string VerticalTenText = "10";
            // 세로축에 있는 10의 위치
            PointF VerticalTenTextPoint = new PointF(GridWidth * 2.2f, GridHeight * 6.7f);
            // 세로축에 있는 0
            string ZeroText = "0";
            // 세로축에 있는 0의 위치
            PointF ZeroTextPoint = new PointF(GridWidth * 2.6f, GridHeight * 7.5f);
            // X축 글자열
            // 가로축에 있는 1
            string OneText = "1";
            // 가로축에 있는 1의 위치
            PointF OneTextPoint = new PointF(GridWidth * 4, GridHeight * 8);
            // 가로축에 있는 2
            string TwoText = "2";
            // 가로축에 있는 2의 위치
            PointF TwoTextPoint = new PointF(GridWidth * 5, GridHeight * 8);
            // 가로축에 있는 3
            string ThreeText = "3";
            // 가로축에 있는 3의 위치
            PointF ThreeTextPoint = new PointF(GridWidth * 6, GridHeight * 8);
            // 가로축에 있는 4
            string FourText = "4";
            // 가로축에 있는 4의 위치
            PointF FourTextPoint = new PointF(GridWidth * 7, GridHeight * 8);
            // 가로축에 있는 5
            string FiveText = "5";
            // 가로축에 있는 5의 위치
            PointF FiveTextPoint = new PointF(GridWidth * 8, GridHeight * 8);
            // 가로축에 있는 6
            string SixText = "6";
            // 가로축에 있는 6의 위치
            PointF SixTextPoint = new PointF(GridWidth * 9, GridHeight * 8);
            // 가로축에 있는 7
            string SevenText = "7";
            // 가로축에 있는 7의 위치
            PointF SevenTextPoint = new PointF(GridWidth * 10, GridHeight * 8);
            // 가로축에 있는 8
            string EightText = "8";
            // 가로축에 있는 8의 위치
            PointF EightTextPoint = new PointF(GridWidth * 11, GridHeight * 8);
            // 가로축에 있는 9
            string NineText = "9";
            // 가로축에 있는 9의 위치
            PointF NineTextPoint = new PointF(GridWidth * 12, GridHeight * 8);
            // 가로축에 있는 10
            string HorizontalTenText = "10";
            // 가로축에 있는 10의 위치
            PointF HorizontalTenTextPoint = new PointF(GridWidth * 13, GridHeight * 8);
            // 가로축에 있는 11
            string ElevenText = "11";
            // 가로축에 있는 11의 위치
            PointF ElevenTextPoint = new PointF(GridWidth * 14, GridHeight * 8);
            // 가로축에 있는 12
            string TwelveText = "12";
            // 가로축에 있는 12의 위치
            PointF TwelveTextPoint = new PointF(GridWidth * 15, GridHeight * 8);
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
            int VerticalLineCount = 12;
            // 차트의 세로 줄의 시작 위치
            PointF VerticalLineStartPoint = new PointF(GridWidth * 4, GridHeight);
            // 차트의 세로 줄의 끝 위치
            PointF VerticalLineEndPoint = new PointF(GridWidth * 4, GridHeight * 8);
            // 차트의 가로 줄의 개수
            int HorizontalLineCount = 7;
            // 차트의 가로 줄의 시작 위치
            PointF HorizontalLineStartPoint = new PointF(GridWidth * 3, GridHeight * 2);
            // 차트의 가로 줄의 끝 위치
            PointF HorizontalLineEndPoint = new PointF(GridWidth * 16, GridHeight * 2);

            // 제목을 그린다.
            g.DrawString(Title, TitleFont, TitleBrush, TitlePoint);

            // 세로 축에 (만 권)을 그린다.
            g.DrawString(KwanText, TitleFont, TextBrush, KwanTextPoint);

            // 세로 축에 60을 그린다.
            g.DrawString(SixtyText, TitleFont, TextBrush, SixtyTextPoint);

            // 세로 축에 50을 그린다.
            g.DrawString(FiftyText, TitleFont, TextBrush, FiftyTextPoint);

            // 세로 축에 40을 그린다.
            g.DrawString(FourtyText, TitleFont, TextBrush, FourtyTextPoint);

            // 세로 축에 30을 그린다.
            g.DrawString(ThirtyText, TitleFont, TextBrush, ThirtyTextPoint);

            // 세로 축에 20을 그린다.
            g.DrawString(TwentyText, TitleFont, TextBrush, TwentyTextPoint);

            // 세로 축에 10을 그린다.
            g.DrawString(VerticalTenText, TitleFont, TextBrush, VerticalTenTextPoint);

            // 세로 축에 0을 그린다.
            g.DrawString(ZeroText, TitleFont, TextBrush, ZeroTextPoint);

            // 가로 축에 1을 그린다.
            g.DrawString(OneText, TitleFont, TextBrush, OneTextPoint);

            // 가로 축에 2를 그린다.
            g.DrawString(TwoText, TitleFont, TextBrush, TwoTextPoint);

            // 가로 축에 3을 그린다.
            g.DrawString(ThreeText, TitleFont, TextBrush, ThreeTextPoint);

            // 가로 축에 4를 그린다.
            g.DrawString(FourText, TitleFont, TextBrush, FourTextPoint);

            // 가로 축에 5를 그린다.
            g.DrawString(FiveText, TitleFont, TextBrush, FiveTextPoint);

            // 가로 축에 6을 그린다.
            g.DrawString(SixText, TitleFont, TextBrush, SixTextPoint);

            // 가로 축에 7을 그린다.
            g.DrawString(SevenText, TitleFont, TextBrush, SevenTextPoint);

            // 가로 축에 8을 그린다.
            g.DrawString(EightText, TitleFont, TextBrush, EightTextPoint);

            // 가로 축에 9를 그린다.
            g.DrawString(NineText, TitleFont, TextBrush, NineTextPoint);

            // 가로 축에 10을 그린다.
            g.DrawString(HorizontalTenText, TitleFont, TextBrush, HorizontalTenTextPoint);

            // 가로 축에 11을 그린다.
            g.DrawString(ElevenText, TitleFont, TextBrush, ElevenTextPoint);

            // 가로 축에 12를 그린다.
            g.DrawString(TwelveText, TitleFont, TextBrush, TwelveTextPoint);

            // 아래쪽 가로 축을 그린다.
            g.DrawLine(LinePen, UnderHorizonStartPoint, UnderHorizonEndPoint);

            // 왼쪽 세로 축을 그린다.
            g.DrawLine(LinePen, LeftVerticalStartPoint, LeftVerticalEndPoint);

            // 오른쪽 가로 축을 그린다.
            g.DrawLine(LinePen, UpperHorizonStartPoint, UpperHorizonEndPoint);

            // 오른쪽 세로 축을 그린다.
            g.DrawLine(LinePen, RightVerticalStartPoint, RightVerticalEndPoint);

            // 왼쪽 아래 대각선을 그린다.
            g.DrawLine(LinePen, LeftDiagonalStartPoint, LeftDiagonalEndPoint);

            // "판매량"을 그린다.
            g.DrawString(SalesVolumeText, TitleFont, TextBrush, SalesVolumeTextPoint);

            // "월"을 그린다.
            g.DrawString(MonthText, TitleFont, TextBrush, MonthTextPoint);

            // 차트의 세로 줄을 그린다.
            for (int i = 0; i < VerticalLineCount; i++)
            {
                
                g.DrawLine(LinePen, VerticalLineStartPoint, VerticalLineEndPoint);

                // 세로 줄을 한 칸씩 이동시킨다.
                VerticalLineStartPoint.X += GridWidth;
                VerticalLineEndPoint.X += GridWidth;
            }

            // 차트의 가로 줄을 그린다.
            for (int i = 0; i < HorizontalLineCount; i++)
            {

                g.DrawLine(LinePen, HorizontalLineStartPoint, HorizontalLineEndPoint);

                // 가로 줄을 한 칸씩 이동시킨다.
                HorizontalLineStartPoint.Y += GridHeight;
                HorizontalLineEndPoint.Y += GridHeight;
            }
        }
    }
}
