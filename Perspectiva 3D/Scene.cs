using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Perspectiva_3D
{
    public class Scene
    {
        private Figure _fig_;
        public int _angle_;

        public Scene(Figure figures)
        {
            _fig_ = figures;
        }

        public void Draw(Graphics graphics, int viewWidth, int viewHeight) //Width and Height of the Form
        {
            graphics.Clear(Color.Gray); //Clears Form

            // Draw x-axis
           // graphics.DrawLine(new Pen(Color.Red), 0, viewHeight / 2, viewWidth, viewHeight / 2);

            // Draw y-axis
           // graphics.DrawLine(new Pen(Color.Red), viewWidth / 2, 0, viewWidth / 2, viewHeight);


            var projected = new Vertex[_fig_.Vertices.Length]; //Creates an array of vertices to store the projected vertices.

            for (var i = 0; i < _fig_.Vertices.Length; i++) //loops through each vertex in the figure.
            {
                var vertex = _fig_.Vertices[i]; //gets the current vertex being processed.

                var transformed = vertex.RotateX(0);

                //IF block to check angle to see if it should move. 

                if (_angle_ > 0 && _angle_ < 90) //Around X 
                {
                    transformed = vertex.RotateX(_angle_);
                }
                else if (_angle_ > 90 && _angle_ < 180) 
                {
                    transformed = vertex.RotateY(_angle_); //Around Y
                }
                else if (_angle_ > 180 && _angle_ < 270) 
                {
                    transformed = vertex.RotateZ(_angle_); //Around Z
                }
                else
                {
                    transformed = vertex.RotateX(_angle_).RotateY(_angle_).RotateZ(_angle_); //Around all of them
                }
                projected[i] = transformed.Project(viewWidth, viewHeight, 256, 6); 
                
                /*
                applies a projection transformation to the vertex and stores the projected
                vertex in the projected array. The projection transformation maps the 3D
                vertex onto a 2D plane based on the position of the viewer (represented by
                the viewWidth, viewHeight, and viewDistance variables) and the field of view (fov). */
            }

            for (var j = 0; j < 6; j++) //Iterates through 6 faces
            {
                graphics.DrawLine(Pens.Black, //first vertice of the Jth face
                    (int)projected[_fig_.Faces[j, 0]].X, //X coordinate of the first vertex of the jth face to an integer, indicating the starting point of the line on the x - axis.
                    (int)projected[_fig_.Faces[j, 0]].Y, //Y coordinate of the first vertex of the jth face to an integer, indicating the starting point of the line on the y-axis.
                    (int)projected[_fig_.Faces[j, 1]].X,
                    (int)projected[_fig_.Faces[j, 1]].Y);


                graphics.DrawLine(Pens.Black, //Second Vertice of the Jth face
                    (int)projected[_fig_.Faces[j, 1]].X,
                    (int)projected[_fig_.Faces[j, 1]].Y,
                    (int)projected[_fig_.Faces[j, 2]].X,
                    (int)projected[_fig_.Faces[j, 2]].Y);

                graphics.DrawLine(Pens.Black, //Third Vertice of the Jth face
                    (int)projected[_fig_.Faces[j, 2]].X,
                    (int)projected[_fig_.Faces[j, 2]].Y, 
                    (int)projected[_fig_.Faces[j, 3]].X, 
                    (int)projected[_fig_.Faces[j, 3]].Y); 

                graphics.DrawLine(Pens.Black, //Fourth Vertice of the Jth Face
                    (int)projected[_fig_.Faces[j, 3]].X, 
                    (int)projected[_fig_.Faces[j, 3]].Y,
                    (int)projected[_fig_.Faces[j, 0]].X, 
                    (int)projected[_fig_.Faces[j, 0]].Y);
            }
            _angle_++;
        }
    }
}
