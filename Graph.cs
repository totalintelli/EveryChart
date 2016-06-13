using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveryChart
{
    public class Graph
    {
        public enum OriginPointPosition
        {
            LowerLeft = 0,  // 원점이 왼쪽 아래에 있는 경우
            LowerRight = 1, // 원점이 오른쪽 아래에 있는 경우
            UpperRight = 2, // 원점이 오른쪽 위에 있는 경우
            UpperLeft = 3   // 원점이 왼쪽 위에 있는 경우
        }

        public enum CurrentGraph
        {
            None = 0,           // 그래프가 없음.
            LineGraph = 1,      // 꺾은선 그래프.
            BarGraph = 2,       // 막대 그래프.
            CircleGraph = 3,    // 원 그래프.
            SpeacialGraph1 = 4, // 특수 그래프1.
            SpeacialGraph2 = 5  // 특수 그래프2.
        }

        // 그래프의 원점의 위치
        public OriginPointPosition CurrentOriginPoint = OriginPointPosition.LowerLeft;
        // 그래프의 상태
        public CurrentGraph CurrentState = CurrentGraph.None;
        // 그래프의 마진
        public Padding GraphMargin = new Padding(0, 49, 0, 0);

        // 실제 그래프 영역
        RectangleF _DrawRect = new RectangleF(0, 0, 0, 0);
        public RectangleF DrawRect
        {
            get { return _DrawRect; }
            set { _DrawRect = value; }
        }

        public PointF GetMathPoint(PointF RealPoint)
        {
            // 수학 포인트
            PointF MathPoint = new PointF();

            switch (CurrentOriginPoint)
            {
                case OriginPointPosition.LowerLeft:
                    // 원점이 왼쪽 아래인 수학 포인트를 구한다.
                    MathPoint.X = RealPoint.X + GraphMargin.Left;
                    MathPoint.Y = DrawRect.Height - RealPoint.Y - GraphMargin.Bottom;
                    break;
                case OriginPointPosition.LowerRight:
                    // 원점이 오른쪽 아래인 수학 포인트를 구한다.
                    MathPoint.X = DrawRect.Width - RealPoint.X + GraphMargin.Right;
                    MathPoint.Y = DrawRect.Height - RealPoint.Y - GraphMargin.Bottom;
                    break;
                case OriginPointPosition.UpperRight:
                    // 원점이 오른쪽 위인 수학 포인트를 구한다.
                    MathPoint.X = DrawRect.Width - RealPoint.X + GraphMargin.Right;
                    MathPoint.Y = RealPoint.Y + GraphMargin.Top;
                    break;
                case OriginPointPosition.UpperLeft:
                    // 원점이 왼쪽 위인 수학 포인트를 구한다.
                    MathPoint.X = RealPoint.X + GraphMargin.Left;
                    MathPoint.Y = RealPoint.Y + GraphMargin.Top;
                    break;
                default:
                    break;
            }

            return MathPoint;
        }



        public PointF GetGraphPoint(float Value, float Min, float Max, bool IsX)
        {
            PointF GraphPoint = new PointF();
            PointF RealPoint = new PointF();

            // 값이 최소값보다 크고 최대값보다 작은지 확인한다.
            if (Value >= Min && Value <= Max)
            {
                // 맞으면, X값인지 확인한다.
                if (IsX)
                {
                    // X값이면 실제 포인트의 X값을 구한다.
                    RealPoint.X = GraphMargin.Left + ((DrawRect.Width * Value) / (Max - Min));
                    RealPoint.Y = 0;
                }
                else
                {
                    RealPoint.X = 0;
                    // X값이 아니면 실제 포인트의 Y값을 구한다.
                    RealPoint.Y = GraphMargin.Top + ((DrawRect.Height * Value) / (Max - Min));
                }
            }

            GraphPoint = GetMathPoint(RealPoint);

            return GraphPoint;
        }
    }
}
