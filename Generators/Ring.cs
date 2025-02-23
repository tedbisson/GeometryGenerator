using GeometryGenerator.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGenerator.Generators
{
    public class Ring : Generator
    {
        public string Name { get { return "Ring"; } }

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
