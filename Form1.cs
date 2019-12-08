using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerlinNoiseBlurForm
{
    public partial class Form1 : Form
    {
        Image I;
        Bitmap R;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            I = Input.InputImage.Input();
            pb_image.Image = I;
        }

        private void btn_process_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            R = PerlinNoise.Handler.Process((Bitmap)I, (int)nud_threads.Value);
             
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            l_time.Text = $"Время выполнения - {elapsedMs} ms";

            pb_image.Image = R;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Output.OutputImage.Output(R);
        }
    }
}
