namespace EveryChart
{
    partial class FrmEveryChart
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLineGraph = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ButtonDockPanel = new System.Windows.Forms.Panel();
            this.cbGraph = new System.Windows.Forms.ComboBox();
            this.cbOriginPoint = new System.Windows.Forms.ComboBox();
            this.lbYData = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbXData = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbMapthPointYValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbMathPointXValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.ButtonDockPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLineGraph
            // 
            this.btnLineGraph.Location = new System.Drawing.Point(12, 12);
            this.btnLineGraph.Name = "btnLineGraph";
            this.btnLineGraph.Size = new System.Drawing.Size(97, 23);
            this.btnLineGraph.TabIndex = 0;
            this.btnLineGraph.Text = "그래프 갱신";
            this.btnLineGraph.UseVisualStyleBackColor = true;
            this.btnLineGraph.Click += new System.EventHandler(this.btnLineGraph_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.ButtonDockPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 555);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // ButtonDockPanel
            // 
            this.ButtonDockPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonDockPanel.Controls.Add(this.cbGraph);
            this.ButtonDockPanel.Controls.Add(this.cbOriginPoint);
            this.ButtonDockPanel.Controls.Add(this.lbYData);
            this.ButtonDockPanel.Controls.Add(this.label6);
            this.ButtonDockPanel.Controls.Add(this.lbXData);
            this.ButtonDockPanel.Controls.Add(this.label5);
            this.ButtonDockPanel.Controls.Add(this.label4);
            this.ButtonDockPanel.Controls.Add(this.label3);
            this.ButtonDockPanel.Controls.Add(this.lbMapthPointYValue);
            this.ButtonDockPanel.Controls.Add(this.label2);
            this.ButtonDockPanel.Controls.Add(this.lbMathPointXValue);
            this.ButtonDockPanel.Controls.Add(this.label1);
            this.ButtonDockPanel.Controls.Add(this.btnLineGraph);
            this.ButtonDockPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonDockPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonDockPanel.Name = "ButtonDockPanel";
            this.ButtonDockPanel.Size = new System.Drawing.Size(754, 49);
            this.ButtonDockPanel.TabIndex = 0;
            // 
            // cbGraph
            // 
            this.cbGraph.FormattingEnabled = true;
            this.cbGraph.Items.AddRange(new object[] {
            "LineGraph",
            "BarGraph"});
            this.cbGraph.Location = new System.Drawing.Point(158, 14);
            this.cbGraph.Name = "cbGraph";
            this.cbGraph.Size = new System.Drawing.Size(121, 20);
            this.cbGraph.TabIndex = 12;
            this.cbGraph.SelectedIndexChanged += new System.EventHandler(this.cbGraph_SelectedIndexChanged);
            // 
            // cbOriginPoint
            // 
            this.cbOriginPoint.FormattingEnabled = true;
            this.cbOriginPoint.Items.AddRange(new object[] {
            "LowerLeft"});
            this.cbOriginPoint.Location = new System.Drawing.Point(325, 14);
            this.cbOriginPoint.Name = "cbOriginPoint";
            this.cbOriginPoint.Size = new System.Drawing.Size(121, 20);
            this.cbOriginPoint.TabIndex = 11;
            this.cbOriginPoint.SelectedIndexChanged += new System.EventHandler(this.cbOrigin_SelectedIndexChanged);
            // 
            // lbYData
            // 
            this.lbYData.AutoSize = true;
            this.lbYData.Location = new System.Drawing.Point(680, 29);
            this.lbYData.Name = "lbYData";
            this.lbYData.Size = new System.Drawing.Size(38, 12);
            this.lbYData.TabIndex = 10;
            this.lbYData.Text = "label7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(646, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "Y  =";
            // 
            // lbXData
            // 
            this.lbXData.AutoSize = true;
            this.lbXData.Location = new System.Drawing.Point(601, 29);
            this.lbXData.Name = "lbXData";
            this.lbXData.Size = new System.Drawing.Size(38, 12);
            this.lbXData.TabIndex = 8;
            this.lbXData.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(567, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "X = ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(495, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "데이터 값 : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(523, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "좌표 :";
            // 
            // lbMapthPointYValue
            // 
            this.lbMapthPointYValue.AutoSize = true;
            this.lbMapthPointYValue.Location = new System.Drawing.Point(680, 12);
            this.lbMapthPointYValue.Name = "lbMapthPointYValue";
            this.lbMapthPointYValue.Size = new System.Drawing.Size(38, 12);
            this.lbMapthPointYValue.TabIndex = 4;
            this.lbMapthPointYValue.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(646, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y  =";
            // 
            // lbMathPointXValue
            // 
            this.lbMathPointXValue.AutoSize = true;
            this.lbMathPointXValue.Location = new System.Drawing.Point(601, 12);
            this.lbMathPointXValue.Name = "lbMathPointXValue";
            this.lbMathPointXValue.Size = new System.Drawing.Size(38, 12);
            this.lbMathPointXValue.TabIndex = 2;
            this.lbMathPointXValue.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(567, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "X = ";
            // 
            // FrmEveryChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 555);
            this.Controls.Add(this.panel1);
            this.Name = "FrmEveryChart";
            this.Text = "모든 차트";
            this.SizeChanged += new System.EventHandler(this.FrmEveryChart_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.ButtonDockPanel.ResumeLayout(false);
            this.ButtonDockPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLineGraph;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel ButtonDockPanel;
        private System.Windows.Forms.Label lbMathPointXValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbMapthPointYValue;
        private System.Windows.Forms.Label lbYData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbXData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbOriginPoint;
        private System.Windows.Forms.ComboBox cbGraph;
    }
}

