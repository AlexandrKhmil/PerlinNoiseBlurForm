namespace PerlinNoiseBlurForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_load = new System.Windows.Forms.Button();
            this.pb_image = new System.Windows.Forms.PictureBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_process = new System.Windows.Forms.Button();
            this.l_text = new System.Windows.Forms.Label();
            this.nud_threads = new System.Windows.Forms.NumericUpDown();
            this.l_time = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_threads)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(12, 12);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(50, 25);
            this.btn_load.TabIndex = 0;
            this.btn_load.Text = "Load";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // pb_image
            // 
            this.pb_image.Location = new System.Drawing.Point(12, 43);
            this.pb_image.Name = "pb_image";
            this.pb_image.Size = new System.Drawing.Size(500, 500);
            this.pb_image.TabIndex = 1;
            this.pb_image.TabStop = false;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(462, 12);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(50, 25);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_process
            // 
            this.btn_process.Location = new System.Drawing.Point(68, 12);
            this.btn_process.Name = "btn_process";
            this.btn_process.Size = new System.Drawing.Size(55, 25);
            this.btn_process.TabIndex = 3;
            this.btn_process.Text = "Process";
            this.btn_process.UseVisualStyleBackColor = true;
            this.btn_process.Click += new System.EventHandler(this.btn_process_Click);
            // 
            // l_text
            // 
            this.l_text.AutoSize = true;
            this.l_text.Location = new System.Drawing.Point(129, 18);
            this.l_text.Name = "l_text";
            this.l_text.Size = new System.Drawing.Size(94, 13);
            this.l_text.TabIndex = 4;
            this.l_text.Text = "Кол-во потоков - ";
            // 
            // nud_threads
            // 
            this.nud_threads.Location = new System.Drawing.Point(229, 16);
            this.nud_threads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_threads.Name = "nud_threads";
            this.nud_threads.Size = new System.Drawing.Size(50, 20);
            this.nud_threads.TabIndex = 5;
            this.nud_threads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_threads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // l_time
            // 
            this.l_time.AutoSize = true;
            this.l_time.Location = new System.Drawing.Point(285, 18);
            this.l_time.Name = "l_time";
            this.l_time.Size = new System.Drawing.Size(114, 13);
            this.l_time.TabIndex = 6;
            this.l_time.Text = "Время выполнения - ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 560);
            this.Controls.Add(this.l_time);
            this.Controls.Add(this.nud_threads);
            this.Controls.Add(this.l_text);
            this.Controls.Add(this.btn_process);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.pb_image);
            this.Controls.Add(this.btn_load);
            this.Name = "Form1";
            this.Text = "Шум Перлина";
            ((System.ComponentModel.ISupportInitialize)(this.pb_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_threads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.PictureBox pb_image;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_process;
        private System.Windows.Forms.Label l_text;
        private System.Windows.Forms.NumericUpDown nud_threads;
        private System.Windows.Forms.Label l_time;
    }
}

