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
            // 세로축에 쓰는 60
            string SixtyText = "60";
            // 세로축에 쓰는 60의 위치
            PointF SixtyTextPoint = new PointF(Width * 3 / 16.0f, Height * 2 / 11.0f);
            // 세로축에 쓰는 50
            string FiftyText = "50";
            // 세로축에 쓰는 50의 위치
            PointF FiftyTextPoint = new PointF(Width * 3 / 16.0f, Height * 3 / 11.0f);
            // 세로축에 쓰는 40
            string FourtyText = "40";
            // 세로축에 쓰는 40의 위치
            PointF FourtyTextPoint = new PointF(Width * 3 / 16.0f, Height * 4 / 11.0f);
            // 세로축에 쓰는 30
            string ThirtyText = "30";
            // 세로축에 쓰는 30의 위치
            PointF ThirtyTextPoint = new PointF(Width * 3 / 16.0f, Height * 5 / 11.0f);
            // 세로축에 쓰는 20
            string TwentyText = "20";
            // 세로축에 쓰는 20의 위치
            PointF TwentyTextPoint = new PointF(Width * 3 / 16.0f, Height * 6 / 11.0f);
            // 세로축에 쓰는 10
            string TenText = "10";
            // 세로축에 쓰는 10의 위치
            PointF TenTextPoint = new PointF(Width * 3 / 16.0f, Height * 7 / 11.0f);
            // 세로축에 쓰는 0
            string ZeroText = "0";
            // 세로축에 쓰는 0의 위치
            PointF ZeroTextPoint = new PointF(Width * 3 / 16.0f, Height * 7.5f / 11.0f);

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
            g.DrawString(TenText, TitleFont, TextBrush, TenTextPoint);

            // 세로 축에 0을 그린다.
            g.DrawString(ZeroText, TitleFont, TextBrush, ZeroTextPoint);
        }
    }
}
