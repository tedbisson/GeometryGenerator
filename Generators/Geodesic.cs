using GeometryGenerator.Geometry;

namespace GeometryGenerator.Generators
{
    public class Geodesic : OptionsPanel, IGenerator
    {
        /// <summary>
        /// Descriptions for each of the fields that should be available in
        /// the options panel, needed to generate this geometry.   
        /// </summary>
        private OptionsPanel.Descriptor[] m_optionDescriptors =
        {
            new OptionsPanel.Descriptor("Divisions", 3, 0, 6),
        };

        public Geodesic()
        {
            CreateFromDescriptors(m_optionDescriptors);
        }

        public override string ToString()
        {
            return "Geodesic";
        }

        public Model Create(Dictionary<string, float> optionValues)
        {
            // Extract the required creation values.
            int divisions = (int)optionValues["Divisions"];

            return new Model();
        }
    }
}
