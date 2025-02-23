using GeometryGenerator.Geometry;

namespace GeometryGenerator.Generators
{
    public class Disc : OptionsPanel, IGenerator
    {
        /// <summary>
        /// Descriptions for each of the fields that should be available in
        /// the options panel, needed to generate this geometry.   
        /// </summary>
        private OptionsPanel.Descriptor[] m_optionDescriptors =
        {
            new OptionsPanel.Descriptor("Sectors", 32, 3, 512),
            new OptionsPanel.Descriptor("Tracks", 4, 1, 128),
            new OptionsPanel.Descriptor("InnerRadius", 1.2f, 0.1f, 10.0f),
            new OptionsPanel.Descriptor("OuterRadius", 1.6f, 0.1f, 10.0f),
        };

        public Disc()
        {
            CreateFromDescriptors(m_optionDescriptors);
        }

        public override string ToString()
        {
            return "Disc";
        }

        public Model Create(Dictionary<string, float> optionValues)
        {
            // Extract the required creation values.
            int sectors = (int)optionValues["Stacks"];
            int tracks = (int)optionValues["Slices"];
            float innerRadius = optionValues["InnerRadius"];
            float outerRadius = optionValues["OuterRadius"];

            return new Model();
        }
    }
}
