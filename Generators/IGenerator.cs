using GeometryGenerator.Geometry;

namespace GeometryGenerator.Generators
{
    interface IGenerator
    {
        /// <summary>
        /// Name describing the generator implementation.
        /// </summary>
        string ToString();

        /// <summary>
        /// Returns a WinForms Panel containing appropriate fields for
        /// the creation of the implemented geometry.
        /// </summary>
        /// <returns>A Panel to be displayed to the user.</returns>
        Panel GetOptionsPanel();

        /// <summary>
        /// Creates a model for the geometry implementation.
        /// 
        /// Creation parameters are retrieved from the OptionsPanel.
        /// </summary>
        /// <returns>A new model with the requested geometry.</returns>
        Model Create(Dictionary<string, float> optionValues);

        /// <summary>
        /// Returns a dictionary containing the values to be used to
        /// generate the geometyr.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, float> GetValues();
    }
}
