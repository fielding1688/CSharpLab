﻿using CSharpLab.A00_Basis;
using CSharpLab.A01_Generics;
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
            A00_Basis();
            //A01_Generics();
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

    }
}
