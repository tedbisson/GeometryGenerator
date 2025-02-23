using GeometryGenerator.Geometry;

namespace GeometryGenerator.Generators
{
    interface Generator
    {
        /// <summary>
        /// Name describing the generator implementation.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Returns a WinForms Panel containing appropriate fields for
        /// the creation of the implemented geometry.
        /// </summary>
        /// <returns>A Panel to be displayed to the user.</returns>
        Panel OptionsPanel();

        /// <summary>
        /// Creates a model for the geometry implementation.
        /// 
        /// Creation parameters are retrieved from the OptionsPanel.
        /// </summary>
        /// <returns>A new model with the requested geometry.</returns>
        Model Create();
    }
}
