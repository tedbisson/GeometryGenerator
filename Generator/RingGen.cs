using GeometryGenerator.Geometry;
using System.Numerics;

namespace GeometryGenerator.Generator
{
    public static class RingGen
    {
        public class CreateParams
        {
            public int Tracks;
            public int Sectors;
            public float InnerRadius;
            public float OuterRadius;

            public CreateParams(
                int tracks,
                int sectors,
                float innerRadius,
                float outerRadius)
            {
                Tracks = tracks;
                Sectors = sectors;
                InnerRadius = innerRadius;
                OuterRadius = outerRadius;
            }
        }

        public static Mesh Create(CreateParams createParams)
        {
            Mesh mesh = new Mesh("Ring");

            float deltaTheta = MathF.Tau / createParams.Sectors;
            float deltaRadius = (createParams.OuterRadius - createParams.InnerRadius) / createParams.Tracks;

            // Create vertices around the ring.
            float radius = createParams.InnerRadius;
            for (int track = 0; track <= createParams.Tracks; ++track)
            {
                float theta = 0.0f;
                for (int sector = 0; sector < createParams.Sectors; ++sector)
                {
                    Vector3 v = new Vector3(
                        radius * MathF.Sin(theta),
                        radius * MathF.Cos(theta),
                        0.0f);

                    mesh.AddVertex(v);

                    theta += deltaTheta;
                }

                radius += deltaRadius;
            }

            // Create faces.
            for (int track = 0; track < createParams.Tracks; ++track)
            {
                for (int sector = 0; sector < createParams.Sectors - 1; ++sector)
                {
                    int a = track * createParams.Sectors + sector;
                    int b = a + 1;
                    int c = a + createParams.Sectors;
                    int d = c + 1;

                    mesh.AddFace(new Face(a, b, c));
                    mesh.AddFace(new Face(a, c, b));

                    mesh.AddFace(new Face(b, d, c));
                    mesh.AddFace(new Face(b, c, d));
                }

                {
                    int a = track * createParams.Sectors + createParams.Sectors - 1;
                    int b = a + 1 - createParams.Sectors;
                    int c = a + createParams.Sectors;
                    int d = c + 1 - createParams.Sectors;

                    mesh.AddFace(new Face(a, b, c));
                    mesh.AddFace(new Face(a, c, b));

                    mesh.AddFace(new Face(b, d, c));
                    mesh.AddFace(new Face(b, c, d));
                }

            }

            return mesh;
        }
    }
}
