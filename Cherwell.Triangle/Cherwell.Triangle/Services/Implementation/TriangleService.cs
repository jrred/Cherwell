using System;
using System.Collections.Generic;

using Cherwell.Triangle.Services.Contracts;
using Cherwell.Triangle.Models;

namespace Cherwell.Triangle.Services.Implementation
{
    public class TriangleService : ITriangleService
    {
        /// <summary>
        /// TriangleService (constructor)
        /// </summary>
        public TriangleService()
        {
            try
            {
                Init();
            }
            catch (Exception ex)
            {
                // TO DO: Put in exception handling here 
            }
        }

        /// <summary>
        /// Init
        /// </summary>
        private void Init()
        {
        }

        /// <summary>
        /// GetTriangleVertices
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns>VertexContainer</returns>
        public VertexContainer GetTriangleVertices(string coordinates)
        {
            // ROWS ARE LETTERS
            // COLUMNS ARE NUMBERS

            try
            {
                string row = coordinates[0].ToString().ToUpper();
                string colstr = coordinates[1].ToString();
                int col = Convert.ToInt32(colstr);

                var vertexContainer = new VertexContainer();
                vertexContainer.Vertices = new List<Vertex>();

                Vertex v1 = new Vertex();
                Vertex v2 = new Vertex();
                Vertex v3 = new Vertex();

                int rowNum = (int)(row.ToCharArray()[0]) - 65;
                int colNum = col - 1;

                if (colNum % 2 != 0)
                {
                    // even numbered columns (e.g. A2, A4, etc.)
                    v1.X = (colNum / 2) * 10 + 10;
                    v1.Y = rowNum * 10 + 10;
                    v1.Name = "V1";
                    v2.X = v1.X - 10;
                    v2.Y = v1.Y - 10;
                    v2.Name = "V2";
                    v3.X = v1.X;
                    v3.Y = v1.Y - 10;
                    v3.Name = "V3";
                }
                else
                {
                    // even numbered columns (e.g. A2, A4, etc.)
                    v1.X = (colNum / 2) * 10;
                    v1.Y = rowNum * 10 + 10;
                    v1.Name = "V1";
                    v2.X = v1.X;
                    v2.Y = v1.Y - 10;
                    v2.Name = "V2";
                    v3.X = v1.X + 10;
                    v3.Y = v1.Y;
                    v3.Name = "V3";
                }

                vertexContainer.Vertices.Add(v1);
                vertexContainer.Vertices.Add(v2);
                vertexContainer.Vertices.Add(v3);

                return vertexContainer;
            }
            catch
            {
                throw new Exception("Input was not in a correct format");
            }
        }

        /// <summary>
        /// GetTriangleCoordinates
        /// </summary>
        /// <param name="vertices"></param>
        /// <returns>CoordinatesContainer</returns>
        public CoordinatesContainer GetTriangleCoordinates(string vertices)
        {
            try
            {
                string[] vertexArray = vertices.Split(',');

                int v1X = Convert.ToInt32(vertexArray[0]);
                int v1Y = Convert.ToInt32(vertexArray[1]);
                int v2X = Convert.ToInt32(vertexArray[2]);
                int v2Y = Convert.ToInt32(vertexArray[3]);
                int v3X = Convert.ToInt32(vertexArray[4]);
                int v3Y = Convert.ToInt32(vertexArray[5]);

                Vertex v1 = new Vertex { X = v1X, Y = v1Y };
                Vertex v2 = new Vertex { X = v2X, Y = v2Y };
                Vertex v3 = new Vertex { X = v3X, Y = v3Y };

                int rowNum = 0;
                int colNum = 0;

                // get row (zero based)
                int yMid = 0;

                // get col (zero based)
                // even numbered column
                if (v2.Y == v3.Y)
                {
                    yMid = (v1.Y + v3.Y) / 2;
                    rowNum = ((yMid + 5) / 10) - 1;
                    colNum = v1.X / 6;
                }
                else
                // odd numbered column
                {
                    yMid = (v2.Y + v3.Y) / 2;
                    rowNum = ((yMid + 5) / 10) - 1;
                    colNum = v3.X / 6;
                }

                string coordinates = ((char)(rowNum + 65)).ToString() + (colNum + 1).ToString();

                return new CoordinatesContainer { Coordinates = coordinates };
            }
            catch
            {
                throw new Exception("Input was not in a correct format");
            }
        }
    }
}
