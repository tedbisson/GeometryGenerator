namespace GeometryGenerator.Geometry
{
    public class Face
    {
        public int A;
        public int B;
        public int C;

        public int uvA;
        public int uvB;
        public int uvC;

        public static Face Empty = new Face(0, 0, 0);

        public Face(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;

            uvA = a;
            uvB = b;
            uvC = c;
        }
    }
}
