using GeometryGenerator.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGenerator.Generators
{
    public class Disc : Generator
    {
        //private int m_sectors = 48;
        //private int m_tracks = 8;
        //private float m_innerRadius = 1.2f;
        //private float m_outerRadius = 1.6f;

        public string Name { get { return "Disc"; } }

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
