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
              var coefficient = CreateCombinations(roots,i);
              foreach(var combi_tmp in coefficient)
              {
                  double coefficientTmp = 1;
                  foreach(var value in conbi_tmp)
                      coefficientTmp*=value;
                  coefficient+=coefficientTmp;
              }
              coefficients[i]=coefficient;
          }
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

            static List<List<double>> CreateCombinations(double[] numbers, int r)
    {
        List<List<double>> result = new List<List<double>>();
        List<double> combinationTmp = new List<double>();

        CreateCombinations(numbers, r, 0, combinationTmp, result);

        return result;
    }
    static void CreateCombinations(double[] numbers, int r_tmp, int start, List<double> combinationTmp, List<List<double>> result)
    {
        if (r_tmp == 0)// r個の要素を選び終わった
        {
            result.Add(new List<double>(combinationTmp));
            return;
        }

        for (int i = start; i <= numbers.Length - r_tmp; i++)
        {
            combinationTmp.Add(numbers[i]);
            CreateCombinations(numbers, r_tmp - 1, i + 1, combinationTmp, result);
            combinationTmp.RemoveAt(combinationTmp.Count - 1);
        }
    }
    }
}
