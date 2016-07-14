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
            PieChart = 3,    // 원 그래프.
            SpeacialGraph1 = 4, // 특수 그래프1.
            SpeacialGraph2 = 5  // 특수 그래프2.
        }

        // 그래프의 원점의 위치
        public OriginPointPosition CurrentOriginPoint = OriginPointPosition.LowerLeft;
        // 그래프의 상태
        public CurrentGraph CurrentState = CurrentGraph.None;
        // 그래프의 마진
        public Padding GraphMargin = new Padding(0, 0, 0, 0);

        #region X축 
        // 큰 눈금의 개수
        public int BigHorizontalGridCount = 0;
        // 눈금의 개수
        public int HorizontalGridCount = 0;
        public PointF VerticalGridStartPoint;
        public PointF VerticalGridEndPoint;
        // X축 눈금에 해당하는 숫자
        public int HorizontalGridNumber;
        // X축 눈금 하나에 해당하는 값
        public float OneGridXValue = 1.0f;
        // X축 눈금에 해당하는 숫자의 위치
        public PointF HorizontalGridNumberPoint;
        // X의 최대값
        public double XMax = 0.0f;
        // X의 최소값
        public double XMin = 0.0f;
        #endregion

        #region Y축 
        public PointF HorizontalGridStartPoint = new PointF(0, 0);
        public PointF HorizontalGridEndPoint = new PointF(0, 0);
        // 큰 눈금의 개수
        public int BigVerticalGridCount = 0;
        // 눈금의 개수
        public int VerticalGridCount = 0;
        // Y축 눈금에 해당하는 숫자
        public int VerticalGridNumber;
        // Y축 눈금 하나에 해당하는 값
        public float OneGridYValue;
        // X축 눈금에 해당하는 숫자의 위치
        public PointF VerticalGridNumberPoint;
        // Y의 최대값
        public double YMax = 0.0f;
        // Y의 최소값
        public double YMin = 0.0f;
        #endregion

        #region 데이터
        public System.Collections.SortedList DataList = new System.Collections.SortedList();
        #endregion

        #region 꺾은 선 그래프
        // 점의 색상
        public SolidBrush PointBrush;
        // 점을 그리는 사각형
        public RectangleF DataPointRect;
        // 점의 반지름
        public float PointRadius;
        // 점의 크기
        public float PointSize;
        // 선의 색상
        public Pen DataLinePen;
        // 선의 시작점
        public PointF DataLineStartPoint;
        // 선의 끝점
        public PointF DataLineEndPoint;
        #endregion

        #region 막대 그래프
        // 막대의 색상
        public SolidBrush BarBrush;
        // 막대
        public RectangleF BarRect;
        // 막대의 왼쪽 상단에 있는 점
        public PointF BarPoint;
        #endregion

        // 실제 그래프 영역
        RectangleF _RealRect = new Rectangle(0, 0, 0, 0);
        public RectangleF RealRect
        {
            get { return _RealRect; }
            set { _RealRect = value; }
        }

        // 그래프를 그리는 영역
        RectangleF _DrawRect = new RectangleF(0, 0, 0, 0);
        public RectangleF DrawRect
        {
            get { return _DrawRect; }
            set { _DrawRect = value; }
        }

        /// <summary>
        /// 컴퓨터의 좌표에서 수학 포인트로 치환한다.
        /// </summary>
        /// <param name="RealPoint">컴퓨터의 좌표</param>
        /// <returns>수학 좌표</returns>
        public PointF RealPointToMathPoint(PointF RealPoint)
        {
            // 수학 포인트
            PointF MathPoint = new PointF();

            switch (CurrentOriginPoint)
            {
                case OriginPointPosition.LowerLeft:
                    // 원점이 왼쪽 아래인 수학 포인트를 구한다.
                    MathPoint.X = RealPoint.X;
                    MathPoint.Y = DrawRect.Height - RealPoint.Y;
                    break;
                case OriginPointPosition.LowerRight:
                    // 원점이 오른쪽 아래인 수학 포인트를 구한다.
                    MathPoint.X = DrawRect.Width - RealPoint.X;
                    MathPoint.Y = DrawRect.Height - RealPoint.Y;
                    break;
                case OriginPointPosition.UpperRight:
                    // 원점이 오른쪽 위인 수학 포인트를 구한다.
                    MathPoint.X = DrawRect.Width - RealPoint.X;
                    MathPoint.Y = RealPoint.Y;
                    break;
                case OriginPointPosition.UpperLeft:
                    // 원점이 왼쪽 위인 수학 포인트를 구한다.
                    MathPoint.X = RealPoint.X;
                    MathPoint.Y = RealPoint.Y;
                    break;
                default:
                    break;
            }

            return MathPoint;
        }

        /// <summary>
        /// 그래프 좌표에서 수학 좌표로 바꾼다.
        /// </summary>
        /// <param name="GraphPoint">그래프 좌표</param>
        /// <returns>수학 좌표</returns>
        public PointF GraphPointToMathPoint(PointF GraphPoint)
        {
            // 수학 포인트
            PointF MathPoint = new PointF();

            switch (CurrentOriginPoint)
            {
                case OriginPointPosition.LowerLeft:
                    // 원점이 왼쪽 아래인 수학 포인트를 구한다.
                    MathPoint.X = GraphPoint.X + GraphMargin.Left;
                    MathPoint.Y = DrawRect.Height - GraphPoint.Y + GraphMargin.Top;
                    break;
                case OriginPointPosition.LowerRight:
                    // 원점이 오른쪽 아래인 수학 포인트를 구한다.
                    MathPoint.X = DrawRect.Width - GraphPoint.X + GraphMargin.Right;
                    MathPoint.Y = DrawRect.Height - GraphPoint.Y + GraphMargin.Bottom;
                    break;
                case OriginPointPosition.UpperRight:
                    // 원점이 오른쪽 위인 수학 포인트를 구한다.
                    MathPoint.X = DrawRect.Width - GraphPoint.X + GraphMargin.Right;
                    MathPoint.Y = GraphPoint.Y + GraphMargin.Top;
                    break;
                case OriginPointPosition.UpperLeft:
                    // 원점이 왼쪽 위인 수학 포인트를 구한다.
                    MathPoint.X = GraphPoint.X + GraphMargin.Left;
                    MathPoint.Y = GraphPoint.Y + GraphMargin.Top;
                    break;
                default:
                    break;
            }

            return MathPoint;
        }

        /// <summary>
        /// 컴퓨터 좌표의 X값을 수학 포인트의 X값으로 바꾼다.
        /// </summary>
        /// <param name="RealPointXValue">컴퓨터가 인식하는 좌표의 X값</param>
        /// <returns>수학 좌표의 X값</returns>
        public float GetMathPointXValue(int RealPointXValue)
        {
            // 수학 포인트의 X값
            float MathPointXValue = -1.0f;

            switch (CurrentOriginPoint)
            {
                case OriginPointPosition.LowerLeft:
                    // 원점이 왼쪽 아래인 수학 포인트의 X값을 구한다.
                    MathPointXValue = RealPointXValue;
                    break;
                case OriginPointPosition.LowerRight:
                    // 원점이 오른쪽 아래인 수학 포인트의 X값을 구한다.
                    MathPointXValue = RealRect.Width - RealPointXValue;
                    break;
                case OriginPointPosition.UpperRight:
                    // 원점이 오른쪽 위인 수학 포인트의 X값을 구한다.
                    MathPointXValue = RealRect.Width - RealPointXValue;
                    break;
                case OriginPointPosition.UpperLeft:
                    // 원점이 왼쪽 위인 수학 포인트의 X값을 구한다.
                    MathPointXValue = RealPointXValue;
                    break;
                default:
                    break;
            }

            return MathPointXValue;
        }

        /// <summary>
        /// 컴퓨터 좌표의 X값을 수학 포인트의 Y값으로 바꾼다.
        /// </summary>
        /// <param name="RealPointYValue">컴퓨터 좌표의 Y값</param>
        /// <returns>수학 좌표의 Y값</returns>
        public float GetMathPointYValue(int RealPointYValue)
        {
            // 수학 포인트의 X값
            float MathPointYValue = -1.0f;

            switch (CurrentOriginPoint)
            {
                case OriginPointPosition.LowerLeft:
                    // 원점이 왼쪽 아래인 수학 포인트의 X값을 구한다.
                    MathPointYValue = RealRect.Height - RealPointYValue;
                    break;
                case OriginPointPosition.LowerRight:
                    MathPointYValue = RealRect.Height - RealPointYValue;
                    break;
                case OriginPointPosition.UpperRight:
                    MathPointYValue = RealPointYValue;
                    break;
                case OriginPointPosition.UpperLeft:
                    MathPointYValue = RealPointYValue;
                    break;
                default:
                    break;
            }

            return MathPointYValue;
        }

        /// <summary>
        /// 데이터 값에 대한 수학 좌표의 X값을 구한다.
        /// </summary>
        /// <param name="Value">데이터의 X값</param>
        /// <param name="Min">데이터의 X값의 최소값</param>
        /// <param name="Max">데이터의 X값의 최대값</param>
        /// <returns></returns>
        public PointF GetMathXPoint(double Value, double Min, double Max)
        {
            PointF GraphPoint = new PointF();
            PointF MathXPoint = new PointF();

            // 값이 최소값보다 크고 최대값보다 작은지 확인한다.
            if (Value >= Min && Value <= Max)
            {
                // 맞으면 실제 포인트의 X값을 구한다.
                GraphPoint.X = System.Convert.ToSingle((DrawRect.Width * (Value - Min)) / (Max - Min));
                GraphPoint.Y = 0;
            }

            MathXPoint = GraphPointToMathPoint(GraphPoint);

            return MathXPoint;
        }

        /// <summary>
        /// 데이터 값에 대한 수학 좌표의 Y값을 구한다.
        /// </summary>
        /// <param name="Value">데이터의 Y값</param>
        /// <param name="Min">데이터의 Y값의 최소값</param>
        /// <param name="Max">데이터의 Y값의 최대값</param>
        /// <returns></returns>
        public PointF GetMathYPoint(double Value, double Min, double Max)
        {
            PointF GraphPoint = new PointF();
            PointF MathYPoint = new PointF();

            // 값이 최소값보다 크고 최대값보다 작은지 확인한다.
            if (Value >= Min && Value <= Max)
            {
                GraphPoint.X = 0;
                // 맞으면 실제 포인트의 Y값을 구한다.
                GraphPoint.Y = System.Convert.ToSingle((DrawRect.Height * (Value - Min)) / (Max - Min));
            }

            MathYPoint = GraphPointToMathPoint(GraphPoint);

            return MathYPoint;
        }

        /// <summary>
        /// 입력 받은 데이터 좌표의 X값으로 데이터의 X값을 구한다.
        /// </summary>
        /// <param name="XCoordinate">데이터 좌표의 X값</param>
        /// <param name="XMin">X의 최소값</param>
        /// <param name="XMax">X의 최대값</param>
        /// <param name="DrawRect">그래프를 그리는 사각형</param>
        /// <returns>데이터의 X</returns>
        public float XCoordinateToXData(float XCoordinate, float XMin, float XMax, RectangleF DrawRect)
        {
            float XData = 0.0f;

            // 데이터의 X값을 구한다.
            switch (CurrentOriginPoint)
            {
                case OriginPointPosition.LowerLeft:
                    XData = Math.Abs(((XCoordinate - GraphMargin.Left) * (XMax - XMin)) / DrawRect.Width);
                    break;
                case OriginPointPosition.LowerRight:
                    XData = Math.Abs((XMax - (((XCoordinate - GraphMargin.Left) * (XMax - XMin)) / DrawRect.Width)));
                    break;
                case OriginPointPosition.UpperRight:
                    XData = Math.Abs((XMax- (((XCoordinate - GraphMargin.Left) * (XMax - XMin)) / DrawRect.Width)));
                    break;
                case OriginPointPosition.UpperLeft:
                    XData = Math.Abs(((XCoordinate - GraphMargin.Left) * (XMax - XMin)) / DrawRect.Width);
                    break;
                default:
                    break;
            }

            return XData;
        }

        /// <summary>
        /// 입력 받은 데이터 좌표의 Y값으로 데이터의 Y값을 구한다.
        /// </summary>
        /// <param name="YCoordinate">데이터 좌표의 Y값</param>
        /// <param name="YMin">Y값의 최소값</param>
        /// <param name="YMax">Y값의 최대값</param>
        /// <param name="DrawRect">그래프를 그리는 사각형</param>
        /// <returns>데이터의 Y값</returns>
        public float YCoordinateToYData(float YCoordinate, float YMin, float YMax, RectangleF DrawRect)
        {
            float YData = 0.0f;

            // 데이터의 Y값을 구한다.
            switch (CurrentOriginPoint)
            {
                case OriginPointPosition.LowerLeft:
                    YData = Math.Abs(YMax - (((YCoordinate - GraphMargin.Bottom) * (YMax - YMin)) / DrawRect.Height));
                    break;
                case OriginPointPosition.LowerRight:
                    YData = Math.Abs(YMax - (((YCoordinate - GraphMargin.Bottom) * (YMax - YMin)) / DrawRect.Height));
                    break;
                case OriginPointPosition.UpperRight:
                    YData = Math.Abs(((YCoordinate - GraphMargin.Top) * (YMax - YMin)) / DrawRect.Height);
                    break;
                case OriginPointPosition.UpperLeft:
                    YData = Math.Abs(((YCoordinate - GraphMargin.Bottom) * (YMax - YMin)) / DrawRect.Height);
                    break;
                default:
                    break;
            }

            return YData;
        }
    }
}
