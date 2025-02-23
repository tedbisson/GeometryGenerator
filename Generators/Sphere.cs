using GeometryGenerator.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGenerator.Generators
{
    public class Sphere : Generator
    {
        //private int m_stacks = 32;
        //private int m_slices = 32;

        public string Name { get { return "Sphere"; } }

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
