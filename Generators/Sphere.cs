using GeometryGenerator.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGenerator.Generators
{
    public class Sphere : OptionsPanel, IGenerator
    {
        /// <summary>
        /// Descriptions for each of the fields that should be available in
        /// the options panel, needed to generate this geometry.   
        /// </summary>
        private OptionsPanel.Descriptor[] m_optionDescriptors = 
        {
            new OptionsPanel.Descriptor("Stacks", 32, 3, 256),
            new OptionsPanel.Descriptor("Slices", 32, 4, 256),
        };

        public Sphere()
        {
            CreateFromDescriptors(m_optionDescriptors);
        }

        public override string ToString()
        {
            return "Sphere";
        }

        public Model Create(Dictionary<string, float> optionValues)
        {
            // Extract the required creation values.
            int stacks = (int)optionValues["Stacks"];
            int slices = (int)optionValues["Slices"];


            return new Model();
        }
    }
}
