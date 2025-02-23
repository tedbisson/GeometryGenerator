using GeometryGenerator.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGenerator.Generators
{
    /// <summary>
    /// Generates a spherical mesh of radius 1 centered at the origin.
    /// 
    ///   UV coordinates are mapped from spherical coordinates to UV space.
    ///   Using a left hand coordinate system, with the poles at y = +/- 1.0f.
    ///   
    /// Sources:
    ///   https://danielsieger.com/blog/2021/03/27/generating-spheres.html
    /// </summary>
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

            // Create the mesh for the sphere geometry.
            Mesh mesh = new Mesh("Sphere");

            // Start with the north pole.
            int v0 = mesh.AddVertex(new Vector3(0, 1, 0));
            mesh.AddUV(Vector2.Zero);

            // Work through each stack from north to south pole.
            for (int i = 0; i < stacks - 1; ++i)
            {
                double phi = Math.PI * (i + 1.0) / stacks;

                // Work around the sphere for each slice.
                for (int j = 0; j < slices; ++j)
                {
                    double theta = Math.Tau * j / slices;

                    double x = Math.Sin(phi) * Math.Cos(theta);
                    double y = Math.Cos(phi);
                    double z = Math.Sin(phi) * Math.Sin(theta);
                    mesh.AddVertex(new Vector3((float)x, (float)y, (float)z));

                    double u = 1.0 - theta / Math.Tau;
                    double v = 1.0 - phi / Math.PI;
                    Vector2 uv = new Vector2((float)u, (float)v);
                    mesh.AddUV(uv);
                }
            }

            // Add the south pole.
            int v1 = mesh.AddVertex(new Vector3(0, -1, 0));

            // Add faces for the top and bottom stacks.
            for (int i = 0; i < slices; ++i)
            {
                int i0 = i + 1;
                int i1 = (i + 1) % slices + 1;
                Vector2 uvTop = new Vector2((mesh.UVs[i1].X + mesh.UVs[i0].X) / 2.0f, 1.0f);
                Face face = new Face(v0, i1, i0);
                face.uvA = mesh.AddUV(uvTop);
                mesh.AddFace(face);

                i0 = i + slices * (stacks - 2) + 1;
                i1 = (i + 1) % slices + slices * (stacks - 2) + 1;
                Vector2 uvBottom = new Vector2((mesh.UVs[i0].X + mesh.UVs[i1].X) / 2.0f, 0.0f);
                face = new Face(v1, i0, i1);
                face.uvA = mesh.AddUV(uvBottom);
                mesh.AddFace(face);
            }

            // Add triangles per slice.
            for (int j = 0; j < stacks - 2; ++j)
            {
                int j0 = j * slices + 1;
                int j1 = (j + 1) * slices + 1;
                int i, i0, i1, i2, i3;
                for (i = 0; i < slices - 1; ++i)
                {
                    i0 = j0 + i;
                    i1 = j0 + (i + 1) % slices;
                    i2 = j1 + (i + 1) % slices;
                    i3 = j1 + i;

                    mesh.AddFace(new Face(i0, i1, i2));
                    mesh.AddFace(new Face(i0, i2, i3));
                }

                // The last slice requires "unwrapped" uv coords.
                Face face;
                {
                    i = slices - 1;

                    i0 = j0 + i;
                    i1 = j0 + (i + 1) % slices;
                    i2 = j1 + (i + 1) % slices;
                    i3 = j1 + i;

                    face = new Face(i0, i1, i2);
                    mesh.AddFace(face);
                    face.uvA = UpdateUVIfNeeded(mesh, i0);
                    face.uvB = UpdateUVIfNeeded(mesh, i1);
                    face.uvC = UpdateUVIfNeeded(mesh, i2);

                    face = new Face(i0, i2, i3);
                    mesh.AddFace(face);
                    face.uvA = UpdateUVIfNeeded(mesh, i0);
                    face.uvB = UpdateUVIfNeeded(mesh, i2);
                    face.uvC = UpdateUVIfNeeded(mesh, i3);
                }
            }

            return new Model(mesh);
        }

        /// <summary>
        /// This function prevents triangles textured from the right edge from
        /// wrapping undesirably to the left including the entire texture, rather
        /// than repeating the texture to the right.
        /// </summary>
        /// <param name="mesh"></param>
        /// <param name="i"></param>
        /// <returns>Returns the UV index for the existing coordinate or a new
        /// unwrapped instance if needed.</returns>
        private int UpdateUVIfNeeded(
            Mesh mesh,
            int i)
        {
            // Only wrap coordinates along the right edge of the texture.
            if (mesh.UVs[i].X != 1.0)
                return i;

            // Create a new UV that wraps back to the left edge of the texture.
            return mesh.AddUV(new Vector2(0.0f, mesh.UVs[i].Y));
        }
    }
}
