namespace SelectorCapture
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtSelector = new TextBox();
            SuspendLayout();
            // 
            // txtSelector
            // 
            txtSelector.Dock = DockStyle.Top;
            txtSelector.Location = new Point(0, 0);
            txtSelector.Multiline = true;
            txtSelector.Name = "txtSelector";
            txtSelector.ReadOnly = true;
            txtSelector.Size = new Size(796, 60);
            txtSelector.TabIndex = 0;
            //txtSelector.TextChanged += txtSelector_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 61);
            Controls.Add(txtSelector);
            Name = "Form1";
            Text = "Seletor Capture";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtSelector;
    }
}
