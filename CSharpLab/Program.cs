using CSharpLab.A00_Basis;
using CSharpLab.A01_Generics;
using CSharpLab.A02_Delegate;
using CSharpLab.A03_Constructor;
using CSharpLab.A05_Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> t = new List<Student>()
            {
                new Student(){
                    Name = "aa",
                    Course = new List<Course>()  {
                        new Course(){CourseName = "a1"},
                    }
                },
                new Student() {
                    Name = "bb",
                    Course = new List<Course>(){
                        new Course(){CourseName = "b1"},
                        new Course(){CourseName = "b2"},
                    }
                },
                 new Student() {
                    Name = "cc",
                    Course = new List<Course>(){
                        new Course(){CourseName = "c1"},
                        new Course(){CourseName = "c2"},
                        new Course(){CourseName = "c3"},
                    }
                }
            };
            List<Course> c = new List<Course>();
            var data1 = t.Select(x => x.Course).ToList();
            foreach (var item in data1)
            {
                c.AddRange(item);
            }

            //A00_Basis();
            //A01_Generics();
            //A02_Delegate();
            //A02_Func();
            //A02_LambdaExpression();
            //A03_Constructor_Demo();
            A05_Enum_Demo();
        }

        private static bool aaa(Book x)
        {
            return x.OnSell == false;
        }


        private static List<Book> NewMethod()
        {
            var b = BookHelper.GetBookList();

            return b.OrderBy(x => x.Price).ToList();
        }

        private static void A00_Basis()
        {
            var a = new A00_BasisDemo();
            a.Demo1();
        }

        private static void A01_Generics()
        {
            var a = new APIData<Product, int>()
            {
                Version = "V1",
                ErrorCode = 0,
                Data = new Product()
                {
                    ID = 87,
                    Name = "產品"
                }
            };
            var cc = JsonHelper.ToJson(a);

            var c = JsonHelper.JsonToObject<APIData<Product, int>>("a");
        }

        private static void A02_Delegate()
        {
            var a = new DelegateDemo();
            a.Demo();
        }
        private static void A02_Func()
        {
            var a = new A02_Func();
            a.Demo();
        }

        private static void A02_LambdaExpression()
        {
            var a = new A02_LambdaExpression();
            a.Demo();
        }

        private static void A03_Constructor_Demo()
        {
            var a = new A03_Constructor_Demo();
            a.繼承Demo();
            a.thisDemo();
            a.baseDemo();
        }

        private static void A05_Enum_Demo()
        {
            var a = new A05_Enum_Demo();
            a.demo();
        }

    }

    public class Student
    {
        public string Name { get; set; }
        public List<Course> Course { get; set; }
    }

    public class Course
    {
        public string CourseName { get; set; }
    }
}
