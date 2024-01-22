using System.Numerics;

namespace cSolverBeta
{
    internal class Program//下位移行のために簡略していないところがある
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            //Console.WriteLine(string.Join(",", CreateEquation(new double[] { 1, 2 }).Select(x => x.ToString())));
            //Console.WriteLine(string.Join(",", CreateEquation(new double[] { 7, 4 }).Select(x => x.ToString())));
            Console.WriteLine(string.Join(",", CreateEquation(new double[] { 1, 2, 3 }).Select(x => x.ToString())));
            //Console.WriteLine(string.Join(",", CreateEquation(new double[] { 9, 1, 3 }).Select(x => x.ToString())));
            //Console.WriteLine(string.Join(",", CreateEquation(new double[] { 1, 2, 3, 4 }).Select(x => x.ToString())));



            //Console.WriteLine(ComplexArray2String(Equat2_Formula(1, 2, -15)));

            /*
         1,-3,1
1,-11,1
             */


        }

        static double[] CreateEquation(double[] roots)
        {
            int n = roots.Length;//解の数
            var coefficients = new double[n + 1];//係数
            coefficients[0] = 1;

            for (int i = 1; i <= n; i++)//x^(n-i)の係数を求める
            {
                for (int j = 0; j < n; j++)//j+1個目の( )とそれ以降をかける
                {
                    for (int j_ = j; j_ < n; j_++)//
                    {
                        double tmp = -roots[j];
                        int c = 1;
                        //Console.WriteLine($"x^{n - i}/{i}/{j}/k {tmp}");
                        for (int k = j + 1; k < n && c < i; k++)//i回かける//↑とk+1個目の( )をかける
                        {

                            tmp *= -roots[k];
                            c++;
                            Console.WriteLine($"x^{n - i}/i:{i}/j:{j}/k:{k} t:{tmp} c:{c}  *{k}({tmp / -roots[k]}*{-roots[k]}={tmp})");
                        }
                        if (c == i)//定数項個数はiと等しい (x+1)(x+2)(x+3)でi=2(=xの項になる)のとき2回
                            coefficients[i] += tmp;


                    }
                }
            }//todo:諦めて参照するインデックスの配列を作る([0,1],[0,2],...)

            return coefficients;
        }

        static int NCR(int n, int r)
        {
            int a = 1, b = 1;
            for (int i = 0; i < r; i++)
            {
                a *= n - i;
                b *= r - i;
            }
            return a / b;
        }


        static string ComplexArray2String(Complex[] complexArray)
        {
            return string.Join("\n", complexArray.Select((x, i) => $"x{i + 1}:{Complex2String(x)}"));
        }

        static string Complex2String(Complex complex)
        {
            if (complex.Imaginary == 0)
                return complex.Real.ToString();
            else if (complex.Imaginary > 0)
                return complex.Real.ToString() + "+" + complex.Imaginary.ToString();
            else
                return complex.Real.ToString() + complex.Imaginary.ToString();
        }

        static Complex[] Equat2_Formula(double a1, double a2 = 0, double a3 = 0)
        {
            var root = Complex.Sqrt(a2 * a2 - 4 * a1 * a3);
            var x1 = (-a2 + root) / (2 * a1);
            var x2 = (-a2 - root) / (2 * a1);
            return new Complex[] { x1, x2 };
        }
    }
}
