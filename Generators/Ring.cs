using GeometryGenerator.Geometry;

namespace GeometryGenerator.Generators
{
    public class Ring : OptionsPanel, IGenerator
    {
        /// <summary>
        /// Descriptions for each of the fields that should be available in
        /// the options panel, needed to generate this geometry.   
        /// </summary>
        private OptionsPanel.Descriptor[] m_optionDescriptors =
        {
            new OptionsPanel.Descriptor("Segments", 32, 3, 512),
            new OptionsPanel.Descriptor("Width", 1.0f, 0.1f, 10.0f),
        };

        public Ring()
        {
            CreateFromDescriptors(m_optionDescriptors);
        }

        public override string ToString()
        {
            return "Ring";
        }

        public Model Create(Dictionary<string, float> optionValues)
        {
            // Extract the required creation values.
            int segments = (int)optionValues["Segments"];
            float width = optionValues["Width"];


            return new Model();
        }
    }
}
