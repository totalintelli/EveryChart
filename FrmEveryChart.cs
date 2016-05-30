﻿using System;
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
            PointF KwanTextPoint = new PointF(Width / 8.0f, Height / 11.0f);
            // 세로축에 있는 60
            string SixtyText = "60";
            // 세로축에 있는 60의 위치
            PointF SixtyTextPoint = new PointF(Width * 3 / 16.0f, Height * 2 / 11.0f);
            // 세로축에 있는 50
            string FiftyText = "50";
            // 세로축에 있는 50의 위치
            PointF FiftyTextPoint = new PointF(Width * 3 / 16.0f, Height * 3 / 11.0f);
            // 세로축에 있는 40
            string FourtyText = "40";
            // 세로축에 있는 40의 위치
            PointF FourtyTextPoint = new PointF(Width * 3 / 16.0f, Height * 4 / 11.0f);
            // 세로축에 있는 30
            string ThirtyText = "30";
            // 세로축에 있는 30의 위치
            PointF ThirtyTextPoint = new PointF(Width * 3 / 16.0f, Height * 5 / 11.0f);
            // 세로축에 있는 20
            string TwentyText = "20";
            // 세로축에 있는 20의 위치
            PointF TwentyTextPoint = new PointF(Width * 3 / 16.0f, Height * 6 / 11.0f);
            // 세로축에 있는 10
            string VerticalTenText = "10";
            // 세로축에 있는 10의 위치
            PointF VerticalTenTextPoint = new PointF(Width * 3 / 16.0f, Height * 7 / 11.0f);
            // 세로축에 있는 0
            string ZeroText = "0";
            // 세로축에 있는 0의 위치
            PointF ZeroTextPoint = new PointF(Width * 3 / 16.0f, Height * 8 / 11.0f);
            // 가로축에 있는 1
            string OneText = "1";
            // 가로축에 있는 1의 위치
            PointF OneTextPoint = new PointF(Width * 4 / 16.0f, Height * 8 / 11.0f);
            // 가로축에 있는 2
            string TwoText = "2";
            // 가로축에 있는 2의 위치
            PointF TwoTextPoint = new PointF(Width * 5 / 16.0f, Height * 8 / 11.0f);
            // 가로축에 있는 3
            string ThreeText = "3";
            // 가로축에 있는 3의 위치
            PointF ThreeTextPoint = new PointF(Width * 6 / 16.0f, Height * 8 / 11.0f);
            // 가로축에 있는 4
            string FourText = "4";
            // 가로축에 있는 4의 위치
            PointF FourTextPoint = new PointF(Width * 7 / 16.0f, Height * 8 / 11.0f);
            // 가로축에 있는 5
            string FiveText = "5";
            // 가로축에 있는 5의 위치
            PointF FiveTextPoint = new PointF(Width * 8 / 16.0f, Height * 8 / 11.0f);
            // 가로축에 있는 6
            string SixText = "6";
            // 가로축에 있는 6의 위치
            PointF SixTextPoint = new PointF(Width * 9 / 16.0f, Height * 8 / 11.0f);
            // 가로축에 있는 7
            string SevenText = "7";
            // 가로축에 있는 7의 위치
            PointF SevenTextPoint = new PointF(Width * 10 / 16.0f, Height * 8 / 11.0f);
            // 가로축에 있는 8
            string EightText = "8";
            // 가로축에 있는 8의 위치
            PointF EightTextPoint = new PointF(Width * 11 / 16.0f, Height * 8 / 11.0f);
            // 가로축에 있는 9
            string NineText = "9";
            // 가로축에 있는 9의 위치
            PointF NineTextPoint = new PointF(Width * 12 / 16.0f, Height * 8 / 11.0f);
            // 가로축에 있는 10
            string HorizontalTenText = "10";
            // 가로축에 있는 10의 위치
            PointF HorizontalTenTextPoint = new PointF(Width * 13 / 16.0f, Height * 8 / 11.0f);
            // 가로축에 있는 11
            string ElevenText = "11";
            // 가로축에 있는 11의 위치
            PointF ElevenTextPoint = new PointF(Width * 14 / 16.0f, Height * 8 / 11.0f);
            // 가로축에 있는 12
            string TwelveText = "12";
            // 가로축에 있는 12의 위치
            PointF TwelveTextPoint = new PointF(Width * 15 / 16.0f, Height * 8 / 11.0f);

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
        }
    }
}
