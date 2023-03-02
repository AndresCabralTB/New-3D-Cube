using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Perspectiva_3D
{
    public class Vertex
    {
        public Vertex(float x, float y, float z) //Constructor to initialize the object's data members and set up any necessary state.
        {
            // We declare these variables to allows the object to store and retrieve the values of x, y, and z as properties.

            X = x;
            Y = y;
            Z = z;
            
        }

        public float X { get; set; } //Public Property of type Float. It provides a way to read or write the value of X from outside the class.

        public float Y { get; set; }
        public float Z { get; set; }

        /* 
            The get accessor is used to retrieve the value of the X property, while the set accessor is used to assign a new value to the X property. 
         
            Using the get and set accessors, the X property can be accessed from other parts of the code like a public field, but with the added
            advantage of controlling how the property is accessed and modified 
        */

        public Vertex RotateX(int angle)
        {
            float rad = (float)(angle * Math.PI / 180); //Converts to angle to Radians
            float cos = (float)Math.Cos(rad); //Calculates the cos on the angle (in radians)
            float sin = (float)Math.Sin(rad); //Caluclates the sin of the angle (in radians)

            float yn = (Y * cos) - (Z * sin); //Perform the rotation of Y
            float zn = (Y * sin) + (Z * cos); //Perform the rotation of Z

            return new Vertex(X, yn, zn); //Returns a new Vertex object that has been rotated around the X axis by the specified angle.
        }

        public Vertex RotateY(int angle)
        {
            float rad = (float)(angle * Math.PI / 180);
            float cos = (float)Math.Cos(rad);
            float sin = (float)Math.Sin(rad);
            float Zn = (Z * cos) - (X * sin);
            float Xn = (Z * sin) + (X * cos);
            return new Vertex(Xn, Y, Zn);
        }

        public Vertex RotateZ(int angle)
        {
            float rad = (float)(angle * Math.PI / 180);
            float cos = (float)Math.Cos(rad);
            float sin = (float)Math.Sin(rad);
            float Xn = (X * cos) - (Y * sin);
            float Yn = (X * sin) + (Y * cos);
            return new Vertex(Xn, Yn, Z);
        }

        public Vertex Project(int viewWidth, int viewHeight, int fov, int viewDistance)
        {
            
            float factor = fov / (viewDistance + Z);
            float Xn = X * factor + viewWidth / 2;
            float Yn = Y * factor + viewHeight / 2;
            return new Vertex(Xn, Yn, 0);

            /*
            The method first calculates a projection factor based on the vertex's distance
            from the viewer ("viewDistance") and the field of view ("fov") 
            
            It then uses this factor to calculate the 2D coordinates ("Xn" and "Yn") of the
            projected vertex on the screen space, based on the vertex's original 3D coordinates 
            ("X" and "Y") and the size of the screen ("viewWidth" and "viewHeight").

            Finally, the method returns a new "Vertex" object with the projected coordinates 
            ("Xn" and "Yn"), but with a "Z" value of 0 since the projection is on a 2D plane.
             */

        }
    }
}
