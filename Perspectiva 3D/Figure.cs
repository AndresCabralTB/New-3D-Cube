using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perspectiva_3D
{
    public class Figure
    {
        public Figure(Vertex[] vertex, int[,] faces) //Array of vertices, and 2d array of faces
        {
            Vertices = vertex;
            Faces = faces;

            /*
             * This constructor allows you to create a new Figure object 
             * by passing in an array of Vertex objects and an array of integers 
             * that represents the faces of the figure. By using this constructor, 
             * you can encapsulate the vertices and faces of a 3D figure into a 
             * single object, which makes it easier to work with and manipulate 
             * the figure in your code.
             */
        }

        public Vertex[] Vertices { get; set; }

        public int[,] Faces { get; set; }
    }
}
