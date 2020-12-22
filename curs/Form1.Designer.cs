namespace curs
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.trackBar1Speed = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBar2Value = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1Speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2Value)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(12, 12);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(776, 301);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            // 
            // trackBar1Speed
            // 
            this.trackBar1Speed.Location = new System.Drawing.Point(12, 318);
            this.trackBar1Speed.Maximum = 15;
            this.trackBar1Speed.Minimum = 11;
            this.trackBar1Speed.Name = "trackBar1Speed";
            this.trackBar1Speed.Size = new System.Drawing.Size(182, 45);
            this.trackBar1Speed.TabIndex = 1;
            this.trackBar1Speed.Value = 11;
            this.trackBar1Speed.Scroll += new System.EventHandler(this.trackBar1Speed_Scroll);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // trackBar2Value
            // 
            this.trackBar2Value.Location = new System.Drawing.Point(12, 370);
            this.trackBar2Value.Maximum = 50;
            this.trackBar2Value.Minimum = 5;
            this.trackBar2Value.Name = "trackBar2Value";
            this.trackBar2Value.Size = new System.Drawing.Size(182, 45);
            this.trackBar2Value.TabIndex = 2;
            this.trackBar2Value.TickFrequency = 15;
            this.trackBar2Value.Value = 5;
            this.trackBar2Value.Scroll += new System.EventHandler(this.trackBar2Value_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Скорость частиц";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 402);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Количество частиц";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar2Value);
            this.Controls.Add(this.trackBar1Speed);
            this.Controls.Add(this.picDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1Speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2Value)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.TrackBar trackBar1Speed;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trackBar2Value;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

