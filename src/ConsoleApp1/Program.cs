using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PyramidTestRunner.RunTests();

            Console.ReadLine();
        }
    }

    public class Pyramid
    {
        public string Build(int size)
        {
            var pyramid = new StringBuilder();
            for (var i = 0; i < size; i++)
            {
                pyramid.Append(' ', size - i - 1);
                pyramid.Append('/');
                pyramid.Append(' ', i * 2);
                pyramid.Append('\\');
                if (i != size - 1) pyramid.Append("\r\n");
            }

            return pyramid.ToString();
        }
    }

    public class PyramidTests
    {
        private Pyramid _Pyramid;

        public PyramidTests()
        {
            _Pyramid = new Pyramid();
        }

        [Test]
        public void Pyramid_GivenBuildInputOf1_Outputs1StoryPyramid()
        {
            var result = _Pyramid.Build(1);
            Assert.IsEqual(@"/\", result);
        }

        [Test]
        public void Pyramid_GivenBuildInputOf2_Outputs2StoryPyramid()
        {
            var result = _Pyramid.Build(2);
            var expected =
@" /\
/  \";
            Assert.IsEqual(expected, result);
        }

        [Test]
        public void Pyramid_GivenBuildInputOf3_Outputs3StoryPyramid()
        {
            var result = _Pyramid.Build(3);
            var expected =
@"  /\
 /  \
/    \";
            Assert.IsEqual(expected, result);
        }
    }

    public class TestAttribute : Attribute { }
    public class IgnoreAttribute : Attribute { }
    public class PyramidTestRunner
    {
        public static void RunTests()
        {
            var testClass = new PyramidTests();

            try
            {
                foreach (var method in testClass.GetType().GetMethods())
                {
                    var isTest = method.IsDefined(typeof(TestAttribute));
                    var isIgnored = method.IsDefined(typeof(IgnoreAttribute));
                    if (isTest && !isIgnored)
                    {
                        method.Invoke(testClass, new object[] { });
                    }
                }
                Console.WriteLine("Tests succeeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Stack Trace:");
                Console.WriteLine(e);
            }
        }
    }

    public class Assert
    {
        public static void IsEqual(string expected, string actual)
        {
            if (expected != actual)
            {
                Console.WriteLine("Expected");
                Console.WriteLine(expected);
                Console.WriteLine('\n');
                Console.WriteLine("Actual");
                Console.WriteLine(actual);
                throw new Exception();
            }
        }
    }
}
