﻿using System;
using System.Dynamic;
using System.Globalization;

namespace SqlIntro
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double ListPrice { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}