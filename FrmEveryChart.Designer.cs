﻿namespace EveryChart
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
            this.btnBarGraph = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnBarGraph
            // 
            this.btnBarGraph.Location = new System.Drawing.Point(12, 12);
            this.btnBarGraph.Name = "btnBarGraph";
            this.btnBarGraph.Size = new System.Drawing.Size(97, 23);
            this.btnBarGraph.TabIndex = 0;
            this.btnBarGraph.Text = "막대 그래프";
            this.btnBarGraph.UseVisualStyleBackColor = true;
            this.btnBarGraph.Click += new System.EventHandler(this.btnBarGraph_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 515);
            this.panel1.TabIndex = 1;
            // 
            // FrmEveryChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 555);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBarGraph);
            this.Name = "FrmEveryChart";
            this.Text = "모든 차트";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBarGraph;
        private System.Windows.Forms.Panel panel1;
    }
}

