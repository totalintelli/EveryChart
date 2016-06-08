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
            this.btnLineGraph.Text = "꺾은 선 그래프";
            this.btnLineGraph.UseVisualStyleBackColor = true;
            this.btnLineGraph.Click += new System.EventHandler(this.btnLineGraph_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Controls.Add(this.ButtonDockPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 555);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ButtonDockPanel
            // 
            this.ButtonDockPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonDockPanel.Controls.Add(this.btnLineGraph);
            this.ButtonDockPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonDockPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonDockPanel.Name = "ButtonDockPanel";
            this.ButtonDockPanel.Size = new System.Drawing.Size(754, 49);
            this.ButtonDockPanel.TabIndex = 0;
            // 
            // FrmEveryChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 555);
            this.Controls.Add(this.panel1);
            this.Name = "FrmEveryChart";
            this.Text = "모든 차트";
            this.panel1.ResumeLayout(false);
            this.ButtonDockPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLineGraph;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel ButtonDockPanel;
    }
}

