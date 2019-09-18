namespace Abacus
{
    partial class AbacusMainForm
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
            this.beedColumns1 = new Abacus.BeedColumns();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.동작ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.털기리셋ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // beedColumns1
            // 
            this.beedColumns1.BackColor = System.Drawing.Color.Transparent;
            this.beedColumns1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.beedColumns1.columns = 10;
            this.beedColumns1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.beedColumns1.Location = new System.Drawing.Point(0, 45);
            this.beedColumns1.Margin = new System.Windows.Forms.Padding(0);
            this.beedColumns1.Name = "beedColumns1";
            this.beedColumns1.Size = new System.Drawing.Size(1708, 851);
            this.beedColumns1.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 869);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 27);
            this.label1.TabIndex = 36;
            this.label1.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.동작ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1708, 45);
            this.menuStrip1.TabIndex = 37;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 동작ToolStripMenuItem
            // 
            this.동작ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.털기리셋ToolStripMenuItem});
            this.동작ToolStripMenuItem.Name = "동작ToolStripMenuItem";
            this.동작ToolStripMenuItem.Size = new System.Drawing.Size(93, 41);
            this.동작ToolStripMenuItem.Text = "동작";
            // 
            // 털기리셋ToolStripMenuItem
            // 
            this.털기리셋ToolStripMenuItem.Name = "털기리셋ToolStripMenuItem";
            this.털기리셋ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.털기리셋ToolStripMenuItem.Size = new System.Drawing.Size(336, 48);
            this.털기리셋ToolStripMenuItem.Text = "털기(리셋)";
            this.털기리셋ToolStripMenuItem.Click += new System.EventHandler(this.ResetToolStripMenuItem_Click);
            // 
            // AbacusMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1708, 896);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.beedColumns1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AbacusMainForm";
            this.Text = "주산";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BeedColumns beedColumns1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 동작ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 털기리셋ToolStripMenuItem;
    }
}

