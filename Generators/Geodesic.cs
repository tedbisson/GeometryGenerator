using GeometryGenerator.Geometry;
using System;
using System.Collections.Generic;

namespace GeometryGenerator.Generators
{
    public class Geodesic : Generator
    {
        //private int m_divisions = 3;

        public string Name { get { return "Geodesic"; } }

        public Panel OptionsPanel()
        {
            return new Panel();
        }

        public Model Create()
        {
            return new Model();
        }
    }
}
