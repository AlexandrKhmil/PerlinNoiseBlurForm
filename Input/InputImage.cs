using System.Drawing;
using System.Windows.Forms;

namespace PerlinNoiseBlurForm.Input
{
    class InputImage
    {
        public static Image Input()
        { 
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return Image.FromFile(openFileDialog.FileName);
                }
            }
            return null;
        }
    }
}
