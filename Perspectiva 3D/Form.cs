using System.Drawing;
using System.Windows.Forms;

namespace Perspectiva_3D
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Vertex[] _vert_;
        public Scene _scene_;
        public int[,] _faces_;
        public int _angle_;

        public Graphics g;
        Bitmap bmp;

        public Form()
        {
            InitializeComponent();

            timer1.Start();

            init();

            _scene_ = new Scene(new Figure(_vert_, _faces_));

            Render();
        }


        private void init()
        {
            _vert_ = new Vertex[] //Each corner of the cube
            {
                new Vertex(-1, 1, -1),      // Top left corner (Front)      0
                new Vertex(1, 1, -1),       // Top right corner (Front)     1
                new Vertex(1, -1, -1),      // Bottom Right Corner (Front)  2
                new Vertex(-1, -1, -1),     //Bottom Left Corner (Front)    3

                new Vertex(-1, 1, 1),       //Top Left Corner (Back)        4
                new Vertex(1, 1, 1),        //Top Right Corner (Back)       5
                new Vertex(1, -1, 1),       //Bottom Right Corner (Back)    6
                new Vertex(-1, -1, 1)       //Bottom Left Corner (Back)     7
            };

            _faces_ = new int[,] // each face is a {}, thus, there are 6 face -------- 4 Columns = 4 vertices in this face
            {
                {
                    0, 1, 2, 3 //Front Face
                },
                {
                    1, 5, 6, 2 //Right Face
                },
                {
                    5, 4, 7, 6 //Back Face 
                },
                {
                    4, 0, 3, 7 //Left Face
                },
                {
                    0, 4, 5, 1 //Top Face
                },
                {
                    3, 2, 6, 7 //Bottom
                }  
            };
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           PCT.Invalidate();
           //Render();
           _angle_ += 2;
        }
        public void Render()
        {
            bmp =new Bitmap(PCT.Width, PCT.Height);
            g = Graphics.FromImage(bmp);

            PCT.Image = bmp;
            _scene_.Draw(g, PCT.Width, PCT.Height); //Gives the width and height of the client area of the form.(Basically the whole window) 
        }

    }
}