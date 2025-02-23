namespace GeometryGenerator.Geometry
{
    public class Model
    {
        public List<Mesh> Meshes = new List<Mesh>();

        public Model()
        {
        }

        /// <summary>
        /// Creates a new model with the mesh provided.
        /// </summary>
        /// <param name="mesh">The single mesh to add to the model.</param>
        public Model(Mesh mesh)
        {
            Meshes.Add(mesh);
        }
    }
}
