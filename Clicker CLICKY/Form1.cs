using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Clicker_CLICKY
{
    public partial class Form1 : Form
    {
        int Clicks = 0;
        int Byte = 0;
        int Bool = 0;
        int Float = 0;

        int String = 0;









        bool blueboarder = false;
        public Form1()
        {
            InitializeComponent();

            DoubleBuffered = true;
            text_update();
            glow();
            

        }

        private void glow()
        {
            /// button glower
            Bitmap btmp = new Bitmap(this.Width, this.Height);
            Graphics g = Graphics.FromImage(btmp);

            glow2(richTextBox1.Bounds,100,100,100,g);
            glow2(textBox1.Bounds, 100, 100, 100, g);
            glow2(button1.Bounds, 0, 155, 0, g);
            glow2(button2.Bounds, 0, 155, 0, g);
            glow2(button3.Bounds, 0, 155, 0, g);
            glow2(button4.Bounds, 0, 155, 0, g);
            glow2(button5.Bounds, 55, 55, 177, g);
            
            
            this.BackgroundImage = btmp;
        }

        /// <summary>
        /// This makes boxes glow a cool color, rgb up to 255, r is the rectangle.
        /// </summary>
        private void glow2(Rectangle r, int red, int green, int blue, Graphics g)
        {
            

            for (int i = 0; i < 10; i++)
            {
                Rectangle newR = new Rectangle(r.X - i, r.Y - i, r.Width + (i * 2), r.Height + (i * 2));
                g.DrawRectangle(new Pen(Color.FromArgb(100-(i*10), red, green, blue)), newR);

            }
            
        }

        private async void text_update()
        {
           

            richTextBox1.Text = (
                "Code Bits : "+Clicks + "\n" +
                "Code Bytes : " + Byte + "\n" +
                "Code Bools : " + Bool + "\n" +
                "Code Float : " + Float + "\n" + "\n" +
                "Code String : " + String
                );
            button1.Text = ("Click: " + (1 + (Byte / 4) + (Bool) + (Float * 2) + String) + " Bytes");
            button2.Text = ("Buy "+ (1 + (Bool / 5) + (Float) + String) +" Bytes : Cost " + (8 + Bool) + " Bits");
            button3.Text = ("Buy " + (1 + (Float / 6) + String) + " Bools : Cost " + (16 + Float) + " Bytes");
            button4.Text = ("Buy " + (1 + String) + " Float : Cost " + (32) + " Bools");
            // Next line is for Rebirth
            button5.Text = ("Buy " + (1) + " String : Cost " + (100) + " Float");





            //Info textbox
            textBox1.Text = ("Green -> Light Blue");
            // This is for more visual stuff
            if (Clicks <= 100) { button1.BackColor = Color.FromArgb(0, 0, 0+Clicks, 0); }
            if (Clicks >= 100) { button1.BackColor = Color.FromArgb(0, 0, 100, 0); }

            



            await Task.Delay(9);
            text_update();
        }
        /// <summary>
        /// THIS IS THE BUTTONS :3  Have fun!!!
        /// </summary>


        private async void button1_Click(object sender, EventArgs e)
        {
            Clicks += 1 + (Byte/4)+(Bool)+(Float*2) + String;
            
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (Clicks >= (8+ Bool))
            {
                Clicks -= (8 + Bool);
                Byte += 1 +(Bool/5) + (Float) + String;
            }
            else {
                button2.ForeColor = Color.Red; 
                await Task.Delay(300);
                button2.ForeColor = Color.Lime;
            }
            
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (Byte >= 16+ Float)
            {
                Byte -= 16+ Float;
                Bool += 1+(Float / 6) + String;
            }
            else
            {
                button3.ForeColor = Color.Red;
                await Task.Delay(300);
                button3.ForeColor = Color.Lime;
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (Bool >= 32)
            {
                Bool -= 32;
                Float += 1 + String;
            }
            else
            {
                button4.ForeColor = Color.Red;
                await Task.Delay(300);
                button4.ForeColor = Color.Lime;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //                    START OF NEW BUTTONS
        private async void button5_Click(object sender, EventArgs e)
        {
            if (Float >= 100)
            {
                Clicks = 0;
                Byte = 0;
                Bool = 0;
                Float = 0;
                String += 1;
            }
            else
            {
                button5.ForeColor = Color.Red;
                await Task.Delay(300);
                button5.ForeColor = Color.DodgerBlue;
            }
            if (blueboarder==false) { blueboarder = true; richTextBox1.BackColor = Color.FromArgb(255, 0, 0, 10); }

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            glow();

        }
    }

}