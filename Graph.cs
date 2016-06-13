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
        public Padding GraphMargin = new Padding(0, 0, 0, 0);

        // 실제 그래프 영역
        RectangleF _DrawRect = new RectangleF(0, 0, 0, 0);
        public RectangleF DrawRect
        {
            get { return _DrawRect; }
            set { _DrawRect = value; }
        }

        /// <summary>
        /// 수학 포인트를 구한다.
        /// </summary>
        /// <param name="RealPoint">컴퓨터가 인식하는 좌표</param>
        /// <returns></returns>
        public PointF GetMathPoint(PointF RealPoint)
        {
            // 수학 포인트
            PointF MathPoint = new PointF();

            switch (CurrentOriginPoint)
            {
                case OriginPointPosition.LowerLeft:
                    // 원점이 왼쪽 아래인 수학 포인트를 구한다.
                    MathPoint.X = RealPoint.X + GraphMargin.Left;
                    MathPoint.Y = DrawRect.Height - RealPoint.Y - GraphMargin.Bottom + GraphMargin.Top;
                    break;
                case OriginPointPosition.LowerRight:
                    // 원점이 오른쪽 아래인 수학 포인트를 구한다.
                    MathPoint.X = DrawRect.Width - RealPoint.X + GraphMargin.Right;
                    MathPoint.Y = DrawRect.Height - RealPoint.Y - GraphMargin.Bottom + GraphMargin.Top;
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
        
        /// <summary>
        /// 수학 포인트의 X값을 구한다.
        /// </summary>
        /// <param name="RealPointXValue">컴퓨터가 인식하는 좌표의 X값</param>
        /// <returns>수학 포인트의 X값</returns>
        public float GetMathPointXValue(int RealPointXValue) {
            // 수학 포인트의 X값
            float MathPointXValue = -1.0f;

            switch (CurrentOriginPoint)
            {
                case OriginPointPosition.LowerLeft:
                    // 원점이 왼쪽 아래인 수학 포인트의 X값을 구한다.
                    MathPointXValue = RealPointXValue + GraphMargin.Left;
                    break;
                case OriginPointPosition.LowerRight:
                    MathPointXValue = DrawRect.Width - RealPointXValue + GraphMargin.Right;
                    break;
                case OriginPointPosition.UpperRight:
                    MathPointXValue = DrawRect.Width - RealPointXValue + GraphMargin.Left;
                    break;
                case OriginPointPosition.UpperLeft:
                    MathPointXValue = RealPointXValue + GraphMargin.Left;
                    break;
                default:
                    break;
            }

            return MathPointXValue;
        }

        /// <summary>
        /// 수학 포인트의 Y값을 구한다.
        /// </summary>
        /// <param name="RealPointYValue">컴퓨터가 인식하는 좌표의 Y값</param>
        /// <returns>수학 포인트의 Y값</returns>
        public float GetMathPointYValue(int RealPointYValue)
        {
            // 수학 포인트의 X값
            float MathPointYValue = -1.0f;

            switch (CurrentOriginPoint)
            {
                case OriginPointPosition.LowerLeft:
                    // 원점이 왼쪽 아래인 수학 포인트의 X값을 구한다.
                    MathPointYValue = DrawRect.Height - RealPointYValue;
                    break;
                case OriginPointPosition.LowerRight:
                    MathPointYValue = DrawRect.Height - RealPointYValue;
                    break;
                case OriginPointPosition.UpperRight:
                    MathPointYValue = RealPointYValue - GraphMargin.Top;
                    break;
                case OriginPointPosition.UpperLeft:
                    MathPointYValue = RealPointYValue - GraphMargin.Top;
                    break;
                default:
                    break;
            }

            return MathPointYValue;
        }

        /// <summary>
        /// 그래프 포인트의 X좌표를 구한다.
        /// </summary>
        /// <param name="Value">데이터의 X값</param>
        /// <param name="Min">데이터의 X값의 최소값</param>
        /// <param name="Max">데이터의 X값의 최대값</param>
        /// <returns></returns>
        public PointF GetMathXPoint(float Value, float Min, float Max)
        {
            PointF GraphPoint = new PointF();
            PointF MathXPoint = new PointF();

            // 값이 최소값보다 크고 최대값보다 작은지 확인한다.
            if (Value >= Min && Value <= Max)
            {
                // 맞으면 실제 포인트의 X값을 구한다.
                GraphPoint.X = ((DrawRect.Width * Value) / (Max - Min));
                GraphPoint.Y = 0;
            }

            MathXPoint = GetMathPoint(GraphPoint);

            return MathXPoint;
        }

        /// <summary>
        /// 그래프 포인트의 Y좌표를 구한다.
        /// </summary>
        /// <param name="Value">데이터의 Y값</param>
        /// <param name="Min">데이터의 Y값의 최소값</param>
        /// <param name="Max">데이터의 Y값의 최대값</param>
        /// <returns></returns>
        public PointF GetMathYPoint(float Value, float Min, float Max)
        {
            PointF GraphPoint = new PointF();
            PointF MathYPoint = new PointF();

            // 값이 최소값보다 크고 최대값보다 작은지 확인한다.
            if (Value >= Min && Value <= Max)
            {
                GraphPoint.X = 0;
                // 맞으면 실제 포인트의 Y값을 구한다.
                GraphPoint.Y = ((DrawRect.Height * Value) / (Max - Min));
            }

            MathYPoint = GetMathPoint(GraphPoint);

            return MathYPoint;
        }
    }
}
