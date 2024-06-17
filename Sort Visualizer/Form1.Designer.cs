namespace Sort_Visualizer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btn_rng = new Button();
            btn_reset = new Button();
            cbx_noi = new ComboBox();
            btn_numberOfItems = new Button();
            btn_delayChange = new Button();
            cbx_delay = new ComboBox();
            tmr_delay = new System.Windows.Forms.Timer(components);
            btn_Sort = new Button();
            cbx_algs = new ComboBox();
            SuspendLayout();
            // 
            // btn_rng
            // 
            btn_rng.Location = new Point(1136, 375);
            btn_rng.Name = "btn_rng";
            btn_rng.Size = new Size(230, 90);
            btn_rng.TabIndex = 0;
            btn_rng.Text = "Randomize numbers";
            btn_rng.UseVisualStyleBackColor = true;
            btn_rng.Click += btn_rng_Click;
            // 
            // btn_reset
            // 
            btn_reset.Location = new Point(1136, 12);
            btn_reset.Name = "btn_reset";
            btn_reset.Size = new Size(230, 90);
            btn_reset.TabIndex = 1;
            btn_reset.Text = "Reset";
            btn_reset.UseVisualStyleBackColor = true;
            btn_reset.Click += btn_reset_Click;
            // 
            // cbx_noi
            // 
            cbx_noi.FormattingEnabled = true;
            cbx_noi.Items.AddRange(new object[] { "8", "16", "32", "64", "128", "256", "512" });
            cbx_noi.Location = new Point(1136, 133);
            cbx_noi.Name = "cbx_noi";
            cbx_noi.Size = new Size(230, 33);
            cbx_noi.TabIndex = 2;
            cbx_noi.Text = "64";
            // 
            // btn_numberOfItems
            // 
            btn_numberOfItems.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_numberOfItems.Location = new Point(1136, 172);
            btn_numberOfItems.Name = "btn_numberOfItems";
            btn_numberOfItems.Size = new Size(230, 51);
            btn_numberOfItems.TabIndex = 3;
            btn_numberOfItems.Text = "Change the number of items";
            btn_numberOfItems.UseVisualStyleBackColor = true;
            btn_numberOfItems.Click += btn_numberOfItems_Click;
            // 
            // btn_delayChange
            // 
            btn_delayChange.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_delayChange.Location = new Point(1136, 293);
            btn_delayChange.Name = "btn_delayChange";
            btn_delayChange.Size = new Size(230, 51);
            btn_delayChange.TabIndex = 5;
            btn_delayChange.Text = "Change the delay btwn actions\r\n";
            btn_delayChange.UseVisualStyleBackColor = true;
            btn_delayChange.Click += btn_delayChange_Click;
            // 
            // cbx_delay
            // 
            cbx_delay.FormattingEnabled = true;
            cbx_delay.Items.AddRange(new object[] { "5", "10", "20", "50", "100", "200", "500", "1000" });
            cbx_delay.Location = new Point(1136, 254);
            cbx_delay.Name = "cbx_delay";
            cbx_delay.Size = new Size(230, 33);
            cbx_delay.TabIndex = 4;
            cbx_delay.Text = "50";
            // 
            // tmr_delay
            // 
            tmr_delay.Interval = 50;
            // 
            // btn_Sort
            // 
            btn_Sort.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Sort.Location = new Point(1136, 535);
            btn_Sort.Name = "btn_Sort";
            btn_Sort.Size = new Size(230, 51);
            btn_Sort.TabIndex = 8;
            btn_Sort.Text = "Sort";
            btn_Sort.UseVisualStyleBackColor = true;
            btn_Sort.Click += btn_Sort_Click;
            // 
            // cbx_algs
            // 
            cbx_algs.FormattingEnabled = true;
            cbx_algs.Items.AddRange(new object[] { "Bubble Sort" });
            cbx_algs.Location = new Point(1136, 496);
            cbx_algs.Name = "cbx_algs";
            cbx_algs.Size = new Size(230, 33);
            cbx_algs.TabIndex = 7;
            cbx_algs.Text = "Bubble Sort";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1378, 1099);
            Controls.Add(btn_Sort);
            Controls.Add(cbx_algs);
            Controls.Add(btn_delayChange);
            Controls.Add(cbx_delay);
            Controls.Add(btn_numberOfItems);
            Controls.Add(cbx_noi);
            Controls.Add(btn_reset);
            Controls.Add(btn_rng);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_rng;
        private Button btn_reset;
        private ComboBox cbx_noi;
        private Button btn_numberOfItems;
        private Button btn_delayChange;
        private ComboBox cbx_delay;
        private System.Windows.Forms.Timer tmr_delay;
        private Button btn_Sort;
        private ComboBox cbx_algs;
    }
}